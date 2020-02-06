#region License

// Copyright (c) 2018-2020, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using System;
using Exomia.Framework.Game;
using Exomia.Framework.Mathematics;
using Exomia.ParticleSystem.ModifierExecutionStrategy;
using SharpDX;

namespace Exomia.ParticleSystem
{
    /// <summary>
    ///     An emitter. This class cannot be inherited.
    /// </summary>
    public sealed unsafe class Emitter : IEmitter
    {
        /// <summary>
        ///     The default reclaim frequency.
        /// </summary>
        private const float DEFAULT_RECLAIM_FREQUENCY = 60.0f;

        /// <summary>
        ///     The lifespan.
        /// </summary>
        private readonly float _lifespan;

        /// <summary>
        ///     The buffer.
        /// </summary>
        private readonly ParticleBuffer _buffer;

        /// <summary>
        ///     The profile.
        /// </summary>
        private readonly IProfile _profile;

        /// <summary>
        ///     The seconds since last reclaim.
        /// </summary>
        private float _secondsSinceLastReclaim;

        /// <summary>
        ///     The modifiers.
        /// </summary>
        private IModifier[] _modifiers;

        /// <summary>
        ///     Options for controlling the release.
        /// </summary>
        private ReleaseParameters _releaseParameters;

        /// <summary>
        ///     The reclaim frequency.
        /// </summary>
        private float _reclaimFrequency = DEFAULT_RECLAIM_FREQUENCY;

        /// <summary>
        ///     The reclaim cycle time.
        /// </summary>
        private float _reclaimCycleTime = 1f / DEFAULT_RECLAIM_FREQUENCY;

        /// <summary>
        ///     The modifier execution strategy.
        /// </summary>
        private IModifierExecutionStrategy _modifierExecutionStrategy;

        /// <summary>
        ///     Gets the active particles.
        /// </summary>
        /// <value>
        ///     The active particles.
        /// </value>
        public int ActiveParticles
        {
            get { return _buffer.Count; }
        }

        /// <summary>
        ///     Gets or sets the modifiers.
        /// </summary>
        /// <value>
        ///     The modifiers.
        /// </value>
        public IModifier[] Modifiers
        {
            get { return _modifiers; }
            set { _modifiers = value; }
        }

        /// <summary>
        ///     Gets or sets options for controlling the release.
        /// </summary>
        /// <value>
        ///     Options that control the release.
        /// </value>
        public ReleaseParameters ReleaseParameters
        {
            get { return _releaseParameters; }
            set { _releaseParameters = value; }
        }

        /// <summary>
        ///     Gets or sets the reclaim frequency.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> Thrown when one or more arguments are outside the required range. </exception>
        /// <value>
        ///     The reclaim frequency.
        /// </value>
        public float ReclaimFrequency
        {
            get { return _reclaimFrequency; }
            set
            {
                if (value < 1.0f)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value), "ReclaimFrequency must be greater or equal than 1.0f.");
                }
                _reclaimFrequency = value;
                _reclaimCycleTime = 1f / _reclaimFrequency;
            }
        }

        /// <summary>
        ///     Gets or sets the modifier execution strategy.
        /// </summary>
        /// <value>
        ///     The modifier execution strategy.
        /// </value>
        public IModifierExecutionStrategy ModifierExecutionStrategy
        {
            get { return _modifierExecutionStrategy; }
            set { _modifierExecutionStrategy = value; }
        }

        /// <summary>
        ///     Gets the buffer.
        /// </summary>
        /// <value>
        ///     The buffer.
        /// </value>
        public Particle* Buffer
        {
            get { return _buffer.Pointer; }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Emitter" /> class.
        /// </summary>
        /// <param name="capacity"> The capacity. </param>
        /// <param name="lifespan"> The lifespan. </param>
        /// <param name="profile">  The profile. </param>
        /// <exception cref="ArgumentNullException"> Thrown when one or more required arguments are null. </exception>
        public Emitter(int capacity, TimeSpan lifespan, IProfile profile)
        {
            _profile = profile ?? throw new ArgumentNullException(nameof(profile));

            _buffer                    = new ParticleBuffer(capacity);
            _lifespan                  = (float)lifespan.TotalSeconds;
            _modifiers                 = new IModifier[0];
            _releaseParameters         = new ReleaseParameters();
            _modifierExecutionStrategy = SerialModifierExecutionStrategy.Default;
        }

        /// <summary>
        ///     Finalizes an instance of the <see cref="Emitter" /> class.
        /// </summary>
        ~Emitter()
        {
            Dispose(false);
        }

        /// <summary>
        ///     Updates the given gameTime.
        /// </summary>
        /// <param name="gameTime"> The game time. </param>
        public void Update(GameTime gameTime)
        {
            if (_buffer.Count <= 0) { return; }

            _secondsSinceLastReclaim += gameTime.DeltaTimeS;
            if (_secondsSinceLastReclaim > _reclaimCycleTime)
            {
                ReclaimExpiredParticles();
                _secondsSinceLastReclaim -= _reclaimCycleTime;
            }

            if (_buffer.Count > 0)
            {
                Particle* particle = _buffer.Pointer;
                int       count    = _buffer.Count;

                while (count-- > 0)
                {
                    particle->LifeTime += gameTime.DeltaTimeS;
                    particle->Age      =  particle->LifeTime / _lifespan;
                    particle->Position += particle->Velocity * gameTime.DeltaTimeS;

                    particle++;
                }

                _modifierExecutionStrategy.ExecuteModifiers(
                    _modifiers, gameTime.DeltaTimeS, _buffer.Pointer, _buffer.Count);
            }
        }

        /// <summary>
        ///     Triggers.
        /// </summary>
        /// <param name="position"> The position. </param>
        public void Trigger(Vector2 position)
        {
            Release(position, _releaseParameters.Quantity.Get());
        }

        /// <summary>
        ///     Triggers.
        /// </summary>
        /// <param name="p1"> The first Vector2. </param>
        /// <param name="p2"> The second Vector2. </param>
        public void Trigger(Vector2 p1, Vector2 p2)
        {
            Release(p1 + ((p2 - p1) * Random2.Default.NextSingle()), _releaseParameters.Quantity.Get());
        }

        /// <summary>
        ///     Reclaim expired particles.
        /// </summary>
        private void ReclaimExpiredParticles()
        {
            Particle* particle = (Particle*)_buffer.NativePointer;
            int       count    = _buffer.Count;

            int expired = 0;
            while (count-- > 0)
            {
                if (particle->LifeTime < _lifespan) { break; }

                expired++;
                particle++;
            }

            if (expired > 0)
            {
                _buffer.Deallocate(expired);
            }
        }

        /// <summary>
        ///     Releases.
        /// </summary>
        /// <param name="position"> The position. </param>
        /// <param name="release">  The release. </param>
        private void Release(Vector2 position, int release)
        {
            int count = _buffer.Allocate(release, out Particle* particle);

            while (count-- > 0)
            {
                _profile.GetOffsetAndVelocity(&particle->Position, &particle->Velocity);

                particle->Age      =  0f;
                particle->LifeTime =  0f;
                particle->Position += position;
                particle->Velocity *= _releaseParameters.Speed.Get();

                particle->Color    = _releaseParameters.Color.Get();
                particle->Opacity  = _releaseParameters.Opacity.Get();
                particle->Scale    = _releaseParameters.Scale.Get();
                particle->Rotation = _releaseParameters.Rotation.Get();
                particle->Mass     = _releaseParameters.Mass.Get();

                particle++;
            }
        }

        #region IDisposable Support

        /// <summary>
        ///     True if disposed.
        /// </summary>
        private bool _disposed;

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing"> to release both managed and unmanaged resources;  to release only unmanaged resources. </param>
#pragma warning disable IDE0060 // Remove unused parameter
        private void Dispose(bool disposing)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            if (!_disposed)
            {
                _buffer.Dispose();
                _disposed = true;
            }
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
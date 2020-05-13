#region License

// Copyright (c) 2018-2020, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using System;

namespace Exomia.ParticleSystem.Modifiers
{
    /// <summary>
    ///     A modifier base.
    /// </summary>
    public abstract class ModifierBase : IModifier
    {
        private const float DEFAULT_FREQUENCY = 144.0f;

        private float _frequency = DEFAULT_FREQUENCY;
        private float _cycleTime = 1f / DEFAULT_FREQUENCY;
        private int   _particlesUpdatedThisCycle;

        /// <summary>
        ///     Gets or sets the frequency.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> Thrown when one or more arguments are outside the required range. </exception>
        /// <value>
        ///     The frequency.
        /// </value>
        public float Frequency
        {
            get { return _frequency; }
            set
            {
                if (value < 1.0f)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value), "Frequency must be greater or equal than 1.0f.");
                }

                _frequency = value;
                _cycleTime = 1f / _frequency;
            }
        }

        /// <summary>
        ///     Updates this object.
        /// </summary>
        /// <param name="elapsedSeconds"> The elapsed in seconds. </param>
        /// <param name="particle">       [in,out] If non-, the particle. </param>
        /// <param name="count">          Number of. </param>
        public unsafe void Update(float elapsedSeconds, Particle* particle, int count)
        {
            int particlesRemaining = count - _particlesUpdatedThisCycle;
            int particlesToUpdate = Math.Min(
                particlesRemaining, (int)Math.Ceiling((elapsedSeconds / _cycleTime) * count));

            if (particlesToUpdate > 0)
            {
                OnUpdate(_cycleTime, particle + _particlesUpdatedThisCycle, particlesToUpdate);
                _particlesUpdatedThisCycle += particlesToUpdate;
            }

            if (_particlesUpdatedThisCycle >= count)
            {
                _particlesUpdatedThisCycle = 0;
            }
        }

        /// <summary>
        ///     Executes the update action.
        /// </summary>
        /// <param name="elapsedSeconds"> The elapsed in seconds. </param>
        /// <param name="particle">       [in,out] If non-, the particle. </param>
        /// <param name="count">          Number of. </param>
        protected abstract unsafe void OnUpdate(float elapsedSeconds, Particle* particle, int count);
    }
}
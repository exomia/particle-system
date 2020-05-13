#region License

// Copyright (c) 2018-2020, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using System;
using Exomia.Framework.Game;
using SharpDX;

namespace Exomia.ParticleSystem
{
    /// <summary>
    ///     A particle system. This class cannot be inherited.
    /// </summary>
    public sealed class ParticleSystem : IDisposable
    {
        private bool _enabled;
        private IEmitter[] _emitters;

        /// <summary>
        ///     Gets or sets a value indicating whether this object is enabled.
        /// </summary>
        /// <value>
        ///     True if enabled, false if not.
        /// </value>
        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }
        
        /// <summary>
        ///     Gets or sets the emitters.
        /// </summary>
        /// <value>
        ///     The emitters.
        /// </value>
        public IEmitter[] Emitters
        {
            get { return _emitters; }
            set { _emitters = value; }
        }
        
        /// <summary>
        ///     Gets the active particles.
        /// </summary>
        /// <value>
        ///     The active particles.
        /// </value>
        public int ActiveParticles
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < _emitters.Length; i++)
                {
                    sum += _emitters[i].ActiveParticles;
                }
                return sum;
            }
        }

        /// <summary>
        ///     Indexer to get items within this collection using array index syntax.
        /// </summary>
        /// <param name="index"> Zero-based index of the entry to access. </param>
        /// <returns>
        ///     The indexed item.
        /// </returns>
        public IEmitter this[int index]
        {
            get { return _emitters[index]; }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ParticleSystem" /> class.
        /// </summary>
        public ParticleSystem()
        {
            _emitters = new IEmitter[0];
        }

        /// <summary>
        ///     Finalizes an instance of the <see cref="ParticleSystem" /> class.
        /// </summary>
        ~ParticleSystem()
        {
            Dispose(false);
        }
        
        /// <summary>
        ///     Updates the given gameTime.
        /// </summary>
        /// <param name="gameTime"> The game time. </param>
        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < _emitters.Length; i++)
            {
                _emitters[i].Update(gameTime);
            }
        }
        
        /// <summary>
        ///     Triggers the given position.
        /// </summary>
        /// <param name="position"> The position. </param>
        public void Trigger(Vector2 position)
        {
            for (int i = 0; i < _emitters.Length; i++)
            {
                _emitters[i].Trigger(position);
            }
        }
        
        /// <summary>
        ///     Triggers the given position.
        /// </summary>
        /// <param name="p1"> The first Vector2. </param>
        /// <param name="p2"> The second Vector2. </param>
        public void Trigger(Vector2 p1, Vector2 p2)
        {
            for (int i = 0; i < _emitters.Length; i++)
            {
                _emitters[i].Trigger(p1, p2);
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
        /// <param name="disposing">  to release both managed and unmanaged resources;  to release only unmanaged resources. </param>
#pragma warning disable IDE0060 // Remove unused parameter
        private void Dispose(bool disposing)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            if (!_disposed)
            {
                for (int i = 0; i < _emitters.Length; i++)
                {
                    _emitters[i].Dispose();
                }

                _disposed = true;
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
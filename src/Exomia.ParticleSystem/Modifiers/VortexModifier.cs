#region License

// Copyright (c) 2018-2020, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using System;
using SharpDX;

namespace Exomia.ParticleSystem.Modifiers
{
    /// <summary>
    ///     A vortex modifier. This class cannot be inherited.
    /// </summary>
    public sealed class VortexModifier : ModifierBase
    {
        /// <summary>
        ///     Gets or sets the position.
        /// </summary>
        /// <value>
        ///     The position.
        /// </value>
        public Vector2 Position { get; set; }
        
        /// <summary>
        ///     Gets or sets the maximum speed.
        /// </summary>
        /// <value>
        ///     The maximum speed.
        /// </value>
        public float MaxSpeed { get; set; }
        
        /// <summary>
        ///     Gets or sets the mass.
        /// </summary>
        /// <value>
        ///     The mass.
        /// </value>
        public float Mass { get; set; }

        /// <inheritdoc/>
        protected override unsafe void OnUpdate(float elapsedSeconds, Particle* particle, int count)
        {
            while (count-- > 0)
            {
                Vector2 distance = Position - particle->Position;

                float force = (Mass * particle->Mass) / distance.LengthSquared();
                force = Math.Max(Math.Min(force, MaxSpeed), -MaxSpeed) * elapsedSeconds;

                distance.Normalize();
                distance *= force;

                particle->Velocity += distance;

                particle++;
            }
        }
    }
}
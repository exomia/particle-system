#region License

// Copyright (c) 2018-2020, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using SharpDX;

namespace Exomia.ParticleSystem.Modifiers
{
    /// <summary>
    ///     A linear gravity modifier. This class cannot be inherited.
    /// </summary>
    public sealed class LinearGravityModifier : ModifierBase
    {
        /// <summary>
        ///     Gets or sets the direction.
        /// </summary>
        /// <value>
        ///     The direction.
        /// </value>
        public Vector2 Direction { get; set; }

        /// <summary>
        ///     Gets or sets the strength.
        /// </summary>
        /// <value>
        ///     The strength.
        /// </value>
        public float Strength { get; set; }

        /// <inheritdoc/>
        protected override unsafe void OnUpdate(float elapsedSeconds, Particle* particle, int count)
        {
            Vector2 v = Direction * (Strength * elapsedSeconds);

            while (count-- > 0)
            {
                particle->Velocity += v * particle->Mass;
                particle++;
            }
        }
    }
}
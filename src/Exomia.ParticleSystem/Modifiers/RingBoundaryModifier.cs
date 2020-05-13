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
    ///     A ring boundary modifier. This class cannot be inherited.
    /// </summary>
    public sealed class RingBoundaryModifier : ModifierBase
    {
        /// <summary>
        ///     Gets or sets the center.
        /// </summary>
        /// <value>
        ///     The center.
        /// </value>
        public Vector2 Center { get; set; }
        
        /// <summary>
        ///     Gets or sets the radius.
        /// </summary>
        /// <value>
        ///     The radius.
        /// </value>
        public float Radius { get; set; }

        /// <inheritdoc/>
        protected override unsafe void OnUpdate(float elapsedSeconds, Particle* particle, int count)
        {
            while (count-- > 0)
            {
                float distance = Vector2.Distance(particle->Position, Center);
                if (distance > Radius)
                {
                    particle->Opacity = 0;
                }
                particle++;
            }
        }
    }
}
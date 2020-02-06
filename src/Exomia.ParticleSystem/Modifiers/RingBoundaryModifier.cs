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
        ///     The center.
        /// </summary>
        public Vector2 Center { get; set; }

        /// <summary>
        ///     The radius.
        /// </summary>
        public float Radius { get; set; }

        /// <inheritdoc />
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
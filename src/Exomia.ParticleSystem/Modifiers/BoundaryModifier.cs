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
    ///     A boundary modifier. This class cannot be inherited.
    /// </summary>
    public sealed class BoundaryModifier : ModifierBase
    {
        /// <summary>
        ///     Gets or sets the boundary.
        /// </summary>
        /// <value>
        ///     The boundary.
        /// </value>
        public RectangleF Boundary { get; set; }

        /// <inheritdoc/>
        protected override unsafe void OnUpdate(float elapsedSeconds, Particle* particle, int count)
        {
            while (count-- > 0)
            {
                if (!Boundary.Contains(particle->Position))
                {
                    particle->Opacity = 0;
                }

                particle++;
            }
        }
    }
}
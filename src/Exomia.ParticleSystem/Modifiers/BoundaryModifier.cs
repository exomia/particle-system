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
        ///     The boundary.
        /// </summary>
        public RectangleF Boundary;

        /// <summary>
        ///     Executes the update action.
        /// </summary>
        /// <param name="elapsedSeconds"> The elapsed in seconds. </param>
        /// <param name="particle">       [in,out] If non-, the particle. </param>
        /// <param name="count">          Number of. </param>
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
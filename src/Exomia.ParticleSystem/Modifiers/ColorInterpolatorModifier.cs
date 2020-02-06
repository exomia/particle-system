#region License

// Copyright (c) 2018-2020, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using Exomia.Framework.Mathematics;
using SharpDX;

namespace Exomia.ParticleSystem.Modifiers
{
    /// <summary>
    ///     A color interpolator modifier. This class cannot be inherited.
    /// </summary>
    public sealed class ColorInterpolatorModifier : ModifierBase
    {
        /// <summary>
        ///     Gets or sets the color of the initial.
        /// </summary>
        /// <value>
        ///     The color of the initial.
        /// </value>
        public Color InitialColor { get; set; }

        /// <summary>
        ///     Gets or sets the color of the final.
        /// </summary>
        /// <value>
        ///     The color of the final.
        /// </value>
        public Color FinalColor { get; set; }

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
                particle->Color = new Color(
                    Math2.Lerp(InitialColor.R, FinalColor.R, particle->Age),
                    Math2.Lerp(InitialColor.G, FinalColor.G, particle->Age),
                    Math2.Lerp(InitialColor.B, FinalColor.B, particle->Age),
                    Math2.Lerp(InitialColor.A, FinalColor.A, particle->Age));

                particle++;
            }
        }
    }
}
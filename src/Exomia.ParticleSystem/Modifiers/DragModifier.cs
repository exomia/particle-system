#region License

// Copyright (c) 2018-2020, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

namespace Exomia.ParticleSystem.Modifiers
{
    /// <summary>
    ///     A drag modifier. This class cannot be inherited.
    /// </summary>
    public sealed class DragModifier : ModifierBase
    {
        /// <summary>
        ///     Gets or sets the drag coefficient.
        /// </summary>
        /// <value>
        ///     The drag coefficient.
        /// </value>
        public float DragCoefficient { get; set; } = 0.47f;

        /// <summary>
        ///     Gets or sets the density.
        /// </summary>
        /// <value>
        ///     The density.
        /// </value>
        public float Density { get; set; } = 0.5f;

        /// <inheritdoc/>
        protected override unsafe void OnUpdate(float elapsedSeconds, Particle* particle, int count)
        {
            float drag = -DragCoefficient * Density * elapsedSeconds;
            while (count-- > 0)
            {
                particle->Velocity += particle->Velocity * drag * particle->Mass;
                particle++;
            }
        }
    }
}
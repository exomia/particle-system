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
    ///     A rotation modifier. This class cannot be inherited.
    /// </summary>
    public sealed class RotationModifier : ModifierBase
    {
        /// <summary>
        ///     Gets or sets the rotation rate.
        /// </summary>
        /// <value>
        ///     The rotation rate.
        /// </value>
        public float RotationRate { get; set; }

        /// <inheritdoc />
        protected override unsafe void OnUpdate(float elapsedSeconds, Particle* particle, int count)
        {
            float delta = RotationRate * elapsedSeconds;
            while (count-- > 0)
            {
                particle->Rotation += delta;
                particle++;
            }
        }
    }
}
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
    ///     An opacity fast fade modifier. This class cannot be inherited.
    /// </summary>
    public sealed class OpacityFastFadeModifier : ModifierBase
    {
        /// <inheritdoc />
        protected override unsafe void OnUpdate(float elapsedSeconds, Particle* particle, int count)
        {
            while (count-- > 0)
            {
                particle->Opacity = 1.0f - particle->Age;
                particle++;
            }
        }
    }
}
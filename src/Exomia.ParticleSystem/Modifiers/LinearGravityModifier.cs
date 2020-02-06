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
        ///     The direction.
        /// </summary>
        public Vector2 Direction { get; set; }

        /// <summary>
        ///     The strength.
        /// </summary>
        public float Strength { get; set; }

        /// <summary>
        ///     Executes the update action.
        /// </summary>
        /// <param name="elapsedSeconds"> The elapsed in seconds. </param>
        /// <param name="particle">       [in,out] If non-, the particle. </param>
        /// <param name="count">          Number of. </param>
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
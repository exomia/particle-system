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
    ///     A container modifier. This class cannot be inherited.
    /// </summary>
    public sealed class ContainerModifier : ModifierBase
    {
        /// <summary>
        ///     The container.
        /// </summary>
        public RectangleF Container;

        /// <summary>
        ///     The restitution coefficient.
        /// </summary>
        public float RestitutionCoefficient = 1.0f;

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
                if (particle->Position.X < Container.Left)
                {
                    particle->Position.X = Container.Left;
                    particle->Velocity.X = -particle->Velocity.X * RestitutionCoefficient;
                }
                else if (particle->Position.X > Container.Right)
                {
                    particle->Position.X = Container.Right;
                    particle->Velocity.X = -particle->Velocity.X * RestitutionCoefficient;
                }

                if (particle->Position.Y < Container.Top)
                {
                    particle->Position.Y = Container.Top;
                    particle->Velocity.Y = -particle->Velocity.Y * RestitutionCoefficient;
                }
                else if (particle->Position.Y > Container.Bottom)
                {
                    particle->Position.Y = Container.Bottom;
                    particle->Velocity.Y = -particle->Velocity.Y * RestitutionCoefficient;
                }

                particle++;
            }
        }
    }
}
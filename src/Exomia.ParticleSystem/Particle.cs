#region License

// Copyright (c) 2018-2020, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using System.Runtime.InteropServices;
using SharpDX;

namespace Exomia.ParticleSystem
{
    /// <summary>
    ///     A particle.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = SIZE_IN_BYTES)]
    public struct Particle
    {
        /// <summary>
        ///     The size in bytes.
        /// </summary>
        internal const int SIZE_IN_BYTES = 48;

        /// <summary>
        ///     The age.
        /// </summary>
        public float Age;

        /// <summary>
        ///     The life time.
        /// </summary>
        public float LifeTime;

        /// <summary>
        ///     The position.
        /// </summary>
        public Vector2 Position;

        /// <summary>
        ///     The velocity.
        /// </summary>
        public Vector2 Velocity;

        /// <summary>
        ///     The color.
        /// </summary>
        public Color Color;

        /// <summary>
        ///     The opacity.
        /// </summary>
        public float Opacity;

        /// <summary>
        ///     The scale.
        /// </summary>
        public float Scale;

        /// <summary>
        ///     The rotation.
        /// </summary>
        public float Rotation;

        /// <summary>
        ///     The mass.
        /// </summary>
        public float Mass;
    }
}
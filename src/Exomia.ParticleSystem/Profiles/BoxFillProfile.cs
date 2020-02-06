#region License

// Copyright (c) 2018-2020, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using Exomia.Framework.Mathematics;
using SharpDX;

namespace Exomia.ParticleSystem.Profiles
{
    /// <summary>
    ///     A box fill profile. This class cannot be inherited.
    /// </summary>
    public sealed class BoxFillProfile : IProfile
    {
        /// <summary>
        ///     Gets or sets the width.
        /// </summary>
        /// <value>
        ///     The width.
        /// </value>
        public float Width { get; set; } = 0;

        /// <summary>
        ///     Gets or sets the height.
        /// </summary>
        /// <value>
        ///     The height.
        /// </value>
        public float Height { get; set; } = 0;

        /// <summary>
        ///     Gets offset and velocity.
        /// </summary>
        /// <param name="offset">   [in,out] If non-, the offset. </param>
        /// <param name="velocity"> [in,out] If non-, the velocity. </param>
        public unsafe void GetOffsetAndVelocity(Vector2* offset, Vector2* velocity)
        {
            Random2.Default.NextUnitVector(velocity);
            offset->X = Random2.Default.NextSingle(Width * -0.5f, Width * 0.5f);
            offset->Y = Random2.Default.NextSingle(Height * -0.5f, Height * 0.5f);
        }
    }
}
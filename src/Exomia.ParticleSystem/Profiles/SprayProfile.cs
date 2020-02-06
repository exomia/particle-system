#region License

// Copyright (c) 2018-2020, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using System;
using Exomia.Framework.Mathematics;
using SharpDX;

namespace Exomia.ParticleSystem.Profiles
{
    /// <summary>
    ///     A spray profile. This class cannot be inherited.
    /// </summary>
    public sealed class SprayProfile : IProfile
    {
        /// <summary>
        ///     Gets or sets the direction.
        /// </summary>
        /// <value>
        ///     The direction.
        /// </value>
        public Vector2 Direction { get; set; }

        /// <summary>
        ///     Gets or sets the spread.
        /// </summary>
        /// <value>
        ///     The spread.
        /// </value>
        public double Spread { get; set; }

        /// <summary>
        ///     Gets offset and velocity.
        /// </summary>
        /// <param name="offset">   [in,out] If non-, the offset. </param>
        /// <param name="velocity"> [in,out] If non-, the velocity. </param>
        public unsafe void GetOffsetAndVelocity(Vector2* offset, Vector2* velocity)
        {
            offset->X = 0;
            offset->Y = 0;

            double angle = Math.Atan2(Direction.Y, Direction.X);
            angle       = Random2.Default.NextDouble(angle - Spread, angle + Spread);
            velocity->X = (float)Math.Cos(angle);
            velocity->Y = (float)Math.Sin(angle);
        }
    }
}
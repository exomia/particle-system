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
    ///     A circle profile. This class cannot be inherited.
    /// </summary>
    public sealed class CircleProfile : IProfile
    {
        /// <summary>
        ///     Gets or sets the start radius.
        /// </summary>
        /// <value>
        ///     The start radius.
        /// </value>
        public float StartRadius { get; set; } = 0;

        /// <summary>
        ///     Gets or sets the end radius.
        /// </summary>
        /// <value>
        ///     The end radius.
        /// </value>
        public float EndRadius { get; set; } = 0;

        /// <summary>
        ///     Gets or sets the start angle.
        /// </summary>
        /// <value>
        ///     The start angle.
        /// </value>
        public double StartAngle { get; set; } = -Math.PI;

        /// <summary>
        ///     Gets or sets the end angle.
        /// </summary>
        /// <value>
        ///     The end angle.
        /// </value>
        public double EndAngle { get; set; } = Math.PI;

        /// <summary>
        ///     Gets or sets a value indicating whether the radiate.
        /// </summary>
        /// <value>
        ///     True if radiate, false if not.
        /// </value>
        public bool Radiate { get; set; } = false;

        /// <summary>
        ///     Gets offset and velocity.
        /// </summary>
        /// <param name="offset">   [in,out] If non-, the offset. </param>
        /// <param name="velocity"> [in,out] If non-, the velocity. </param>
        public unsafe void GetOffsetAndVelocity(Vector2* offset, Vector2* velocity)
        {
            float radius = Random2.Default.NextSingle(StartRadius, EndRadius);

            double angle = Random2.Default.NextDouble(StartAngle, EndAngle);
            velocity->X = (float)Math.Cos(angle);
            velocity->Y = (float)Math.Sin(angle);

            offset->X = velocity->X * radius;
            offset->Y = velocity->Y * radius;

            if (Radiate) { Random2.Default.NextUnitVector(velocity); }
        }
    }
}
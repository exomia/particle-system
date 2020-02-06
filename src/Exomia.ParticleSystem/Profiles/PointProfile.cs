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
    ///     A point profile. This class cannot be inherited.
    /// </summary>
    public sealed class PointProfile : IProfile
    {
        /// <summary>
        ///     Gets offset and velocity.
        /// </summary>
        /// <param name="offset">   [in,out] If non-, the offset. </param>
        /// <param name="velocity"> [in,out] If non-, the velocity. </param>
        public unsafe void GetOffsetAndVelocity(Vector2* offset, Vector2* velocity)
        {
            offset->X = 0;
            offset->Y = 0;
            Random2.Default.NextUnitVector(velocity);
        }
    }
}
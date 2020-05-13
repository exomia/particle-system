#region License

// Copyright (c) 2018-2020, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using SharpDX;

namespace Exomia.ParticleSystem
{
    /// <summary>
    ///     A release parameters.
    /// </summary>
    public struct ReleaseParameters
    {
        /// <summary>
        ///     The quantity.
        /// </summary>
        public ReleaseParameter<int> Quantity;

        /// <summary>
        ///     The speed.
        /// </summary>
        public ReleaseParameter<float> Speed;

        /// <summary>
        ///     The color.
        /// </summary>
        public ReleaseParameter<Color> Color;

        /// <summary>
        ///     The opacity.
        /// </summary>
        public ReleaseParameter<float> Opacity;

        /// <summary>
        ///     The scale.
        /// </summary>
        public ReleaseParameter<float> Scale;

        /// <summary>
        ///     The rotation.
        /// </summary>
        public ReleaseParameter<float> Rotation;

        /// <summary>
        ///     The mass.
        /// </summary>
        public ReleaseParameter<float> Mass;
    }
}
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

    /// <summary>
    ///     A release parameter.
    /// </summary>
    /// <typeparam name="T"> Generic type parameter. </typeparam>
    public class ReleaseParameter<T>
    {
        /// <summary>
        ///     The value.
        /// </summary>
        protected T _value;

        /// <summary>
        ///     Initializes a new instance of the &lt;see cref="ReleaseParameter&lt;T&gt;"/&gt; class.
        /// </summary>
        /// <param name="value"> The value. </param>
        public ReleaseParameter(T value)
        {
            _value = value;
        }

        /// <summary>
        ///     Implicit cast that converts the given T to a ReleaseParameter.
        /// </summary>
        /// <param name="value"> The value. </param>
        /// <returns>
        ///     The result of the operation.
        /// </returns>
        public static implicit operator ReleaseParameter<T>(T value)
        {
            return new ReleaseParameter<T>(value);
        }

        /// <summary>
        ///     Gets the get.
        /// </summary>
        /// <returns>
        ///     A T.
        /// </returns>
        public virtual T Get()
        {
            return _value;
        }
    }
}
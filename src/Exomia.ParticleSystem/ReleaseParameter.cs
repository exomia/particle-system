#region License

// Copyright (c) 2018-2020, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

namespace Exomia.ParticleSystem
{
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
        ///     Gets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        public T Value
        {
            get { return _value; }
        }

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
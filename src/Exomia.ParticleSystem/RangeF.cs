#region License

// Copyright (c) 2018-2020, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using Exomia.Framework.Mathematics;

namespace Exomia.ParticleSystem
{
    /// <summary>
    ///     A range f. This class cannot be inherited.
    /// </summary>
    public sealed class RangeF : ReleaseParameter<float>
    {
        /// <summary>
        ///     The maximum.
        /// </summary>
        private readonly float _max;

        /// <summary>
        ///     Gets the maximum.
        /// </summary>
        /// <value>
        ///     The maximum value.
        /// </value>
        public float Max
        {
            get { return _max; }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="RangeF" /> class.
        /// </summary>
        /// <param name="min"> The minimum. </param>
        /// <param name="max"> The maximum. </param>
        public RangeF(float min, float max)
            : base(min)
        {
            _max = max;
        }

        /// <summary>
        ///     Gets the get.
        /// </summary>
        /// <returns>
        ///     A float.
        /// </returns>
        public override float Get()
        {
            return Random2.Default.NextSingle(_value, _max);
        }
    }
}
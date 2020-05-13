#region License

// Copyright (c) 2018-2020, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using Exomia.Framework.Mathematics;
using SharpDX;

namespace Exomia.ParticleSystem
{
    /// <summary>
    ///     A range color. This class cannot be inherited.
    /// </summary>
    public sealed class RangeColor : ReleaseParameter<Color>
    {
        /// <summary>
        ///     The maximum.
        /// </summary>
        private readonly Color _max;

        /// <summary>
        ///     Gets the maximum.
        /// </summary>
        /// <value>
        ///     The maximum value.
        /// </value>
        public Color Max
        {
            get { return _max; }
        }
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="RangeColor" /> class.
        /// </summary>
        /// <param name="min"> The minimum. </param>
        /// <param name="max"> The maximum. </param>
        public RangeColor(Color min, Color max)
            : base(min)
        {
            _max = max;
        }

        /// <summary>
        ///     Gets the get.
        /// </summary>
        /// <returns>
        ///     A Color.
        /// </returns>
        public override Color Get()
        {
            return new Color(
                Random2.Default.Next(_value.R, _max.R),
                Random2.Default.Next(_value.G, _max.G),
                Random2.Default.Next(_value.B, _max.B),
                Random2.Default.Next(_value.A, _max.A));
        }
    }
}
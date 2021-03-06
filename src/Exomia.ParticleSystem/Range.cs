﻿#region License

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
    ///     A range. This class cannot be inherited.
    /// </summary>
    public sealed class Range : ReleaseParameter<int>
    {
        /// <summary>
        ///     The maximum.
        /// </summary>
        private readonly int _max;
        
        /// <summary>
        ///     Gets the maximum.
        /// </summary>
        /// <value>
        ///     The maximum value.
        /// </value>
        public int Max
        {
            get { return _max; }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Range" /> class.
        /// </summary>
        /// <param name="min"> The minimum. </param>
        /// <param name="max"> The maximum. </param>
        public Range(int min, int max)
            : base(min)
        {
            _max = max;
        }

        /// <summary>
        ///     Gets the get.
        /// </summary>
        /// <returns>
        ///     An int.
        /// </returns>
        public override int Get()
        {
            return Random2.Default.Next(_value, _max);
        }
    }
}
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
    ///     A range. This class cannot be inherited.
    /// </summary>
    public sealed class Range : ReleaseParameter<int>
    {
        /// <summary>
        ///     The maximum.
        /// </summary>
        private readonly int _max;

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
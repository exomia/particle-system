#region License

// Copyright (c) 2018-2020, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

namespace Exomia.ParticleSystem.Modifiers
{
    /// <summary>
    ///     A scale interpolator modifier. This class cannot be inherited.
    /// </summary>
    public sealed class ScaleInterpolatorModifier : ModifierBase
    {
        /// <summary>
        ///     The initial scale.
        /// </summary>
        private float _initialScale;

        /// <summary>
        ///     The final scale.
        /// </summary>
        private float _finalScale = 1.0f;

        /// <summary>
        ///     The delta scale.
        /// </summary>
        private float _deltaScale = 1.0f;

        /// <summary>
        ///     Gets or sets the initial scale.
        /// </summary>
        /// <value>
        ///     The initial scale.
        /// </value>
        public float InitialScale
        {
            get { return _initialScale; }
            set
            {
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (_initialScale != value)
                {
                    _initialScale = value;
                    _deltaScale   = _finalScale - _initialScale;
                }
            }
        }

        /// <summary>
        ///     Gets or sets the final scale.
        /// </summary>
        /// <value>
        ///     The final scale.
        /// </value>
        public float FinalScale
        {
            get { return _finalScale; }
            set
            {
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (_finalScale != value)
                {
                    _finalScale = value;
                    _deltaScale = _finalScale - _initialScale;
                }
            }
        }

        /// <inheritdoc />
        protected override unsafe void OnUpdate(float elapsedSeconds, Particle* particle, int count)
        {
            while (count-- > 0)
            {
                particle->Scale = (_deltaScale * particle->Age) + _initialScale;
                particle++;
            }
        }
    }
}
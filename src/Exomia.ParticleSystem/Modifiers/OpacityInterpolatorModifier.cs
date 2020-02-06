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
    ///     An opacity interpolator modifier. This class cannot be inherited.
    /// </summary>
    public sealed class OpacityInterpolatorModifier : ModifierBase
    {
        /// <summary>
        ///     The initial opacity.
        /// </summary>
        private float _initialOpacity = 1.0f;

        /// <summary>
        ///     The final opacity.
        /// </summary>
        private float _finalOpacity;

        /// <summary>
        ///     The delta opacity.
        /// </summary>
        private float _deltaOpacity = -1.0f;

        /// <summary>
        ///     Gets or sets the initial opacity.
        /// </summary>
        /// <value>
        ///     The initial opacity.
        /// </value>
        public float InitialOpacity
        {
            get { return _initialOpacity; }
            set
            { 
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (_initialOpacity != value)
                {
                    _initialOpacity = value;
                    _deltaOpacity   = _finalOpacity - _initialOpacity;
                }
            }
        }

        /// <summary>
        ///     Gets or sets the final opacity.
        /// </summary>
        /// <value>
        ///     The final opacity.
        /// </value>
        public float FinalOpacity
        {
            get { return _finalOpacity; }
            set
            {
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (_finalOpacity != value)
                {
                    _finalOpacity = value;
                    _deltaOpacity = _finalOpacity - _initialOpacity;
                }
            }
        }

        /// <inheritdoc />
        protected override unsafe void OnUpdate(float elapsedSeconds, Particle* particle, int count)
        {
            while (count-- > 0)
            {
                particle->Opacity = (_deltaOpacity * particle->Age) + _initialOpacity;
                particle++;
            }
        }
    }
}
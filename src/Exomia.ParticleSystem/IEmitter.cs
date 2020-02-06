#region License

// Copyright (c) 2018-2020, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using System;
using Exomia.Framework.Game;
using SharpDX;

namespace Exomia.ParticleSystem
{
    /// <summary>
    ///     Interface for emitter.
    /// </summary>
    public unsafe interface IEmitter : IDisposable
    {
        /// <summary>
        ///     Gets the active particles.
        /// </summary>
        /// <value>
        ///     The active particles.
        /// </value>
        int ActiveParticles { get; }

        /// <summary>
        ///     Gets or sets options for controlling the release.
        /// </summary>
        /// <value>
        ///     Options that control the release.
        /// </value>
        ReleaseParameters ReleaseParameters { get; set; }

        /// <summary>
        ///     Gets or sets the modifiers.
        /// </summary>
        /// <value>
        ///     The modifiers.
        /// </value>
        IModifier[] Modifiers { get; set; }

        /// <summary>
        ///     Gets the buffer.
        /// </summary>
        /// <value>
        ///     The buffer.
        /// </value>
        Particle* Buffer { get; }

        /// <summary>
        ///     Gets or sets the reclaim frequency.
        /// </summary>
        /// <value>
        ///     The reclaim frequency.
        /// </value>
        float ReclaimFrequency { get; set; }

        /// <summary>
        ///     Updates the given gameTime.
        /// </summary>
        /// <param name="gameTime"> The game time. </param>
        void Update(GameTime gameTime);

        /// <summary>
        ///     Triggers.
        /// </summary>
        /// <param name="position"> The position. </param>
        void Trigger(Vector2 position);

        /// <summary>
        ///     Triggers.
        /// </summary>
        /// <param name="p1"> The first Vector2. </param>
        /// <param name="p2"> The second Vector2. </param>
        void Trigger(Vector2 p1, Vector2 p2);
    }
}
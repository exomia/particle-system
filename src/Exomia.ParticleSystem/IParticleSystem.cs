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
    ///     Interface for particle system.
    /// </summary>
    public interface IParticleSystem : IDisposable
    {
        /// <summary>
        ///     Gets or sets a value indicating whether this object is enabled.
        /// </summary>
        /// <value>
        ///     True if enabled, false if not.
        /// </value>
        bool Enabled { get; set; }

        /// <summary>
        ///     Gets or sets the emitters.
        /// </summary>
        /// <value>
        ///     The emitters.
        /// </value>
        IEmitter[] Emitters { get; set; }

        /// <summary>
        ///     Gets the active particles.
        /// </summary>
        /// <value>
        ///     The active particles.
        /// </value>
        int ActiveParticles { get; }

        /// <summary>
        ///     Indexer to get items within this collection using array index syntax.
        /// </summary>
        /// <param name="index"> Zero-based index of the entry to access. </param>
        /// <returns>
        ///     The indexed item.
        /// </returns>
        IEmitter this[int index] { get; }

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
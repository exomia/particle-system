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
    ///     Interface for modifier.
    /// </summary>
    public interface IModifier
    {
        /// <summary>
        ///     Updates this object.
        /// </summary>
        /// <param name="elapsedSeconds"> The elapsed in seconds. </param>
        /// <param name="particle">       [in,out] If non-, the particle. </param>
        /// <param name="count">          Number of. </param>
        unsafe void Update(float elapsedSeconds, Particle* particle, int count);
    }
}
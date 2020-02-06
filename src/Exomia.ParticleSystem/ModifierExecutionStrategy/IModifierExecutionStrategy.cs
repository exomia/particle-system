#region License

// Copyright (c) 2018-2020, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

namespace Exomia.ParticleSystem.ModifierExecutionStrategy
{
    /// <summary>
    ///     Interface for modifier execution strategy.
    /// </summary>
    public interface IModifierExecutionStrategy
    {
        /// <summary>
        ///     Executes the modifiers operation.
        /// </summary>
        /// <param name="modifiers">      The modifiers. </param>
        /// <param name="elapsedSeconds"> The elapsed in seconds. </param>
        /// <param name="particle">       [in,out] If non-, the particle. </param>
        /// <param name="count">          Number of. </param>
        unsafe void ExecuteModifiers(IModifier[] modifiers, float elapsedSeconds, Particle* particle, int count);
    }
}
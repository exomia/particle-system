#region License

// Copyright (c) 2018-2020, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Exomia.ParticleSystem
{
    /// <summary>
    ///     Buffer for particle. This class cannot be inherited.
    /// </summary>
    sealed unsafe class ParticleBuffer : IDisposable
    {
        /// <summary>
        ///     The native pointer.
        /// </summary>
        private readonly IntPtr _nativePointer;

        /// <summary>
        ///     The pointer.
        /// </summary>
        private readonly Particle* _pointer;

        /// <summary>
        ///     The size.
        /// </summary>
        private readonly int _size;

        /// <summary>
        ///     The tail.
        /// </summary>
        private int _tail;

        /// <summary>
        ///     Gets the native pointer.
        /// </summary>
        /// <value>
        ///     The native pointer.
        /// </value>
        public IntPtr NativePointer
        {
            get { return _nativePointer; }
        }

        /// <summary>
        ///     Gets the pointer.
        /// </summary>
        /// <value>
        ///     The pointer.
        /// </value>
        public Particle* Pointer
        {
            get { return _pointer; }
        }

        /// <summary>
        ///     Gets the available.
        /// </summary>
        /// <value>
        ///     The available.
        /// </value>
        public int Available
        {
            get { return _size - _tail; }
        }

        /// <summary>
        ///     Gets the size in bytes.
        /// </summary>
        /// <value>
        ///     The size in bytes.
        /// </value>
        public int SizeInBytes
        {
            get { return Particle.SIZE_IN_BYTES * _size; }
        }

        /// <summary>
        ///     Gets the active size in bytes.
        /// </summary>
        /// <value>
        ///     The active size in bytes.
        /// </value>
        public int ActiveSizeInBytes
        {
            get { return Particle.SIZE_IN_BYTES * _tail; }
        }

        /// <summary>
        ///     Gets the number of.
        /// </summary>
        /// <value>
        ///     The count.
        /// </value>
        public int Count
        {
            get { return _tail; }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ParticleBuffer" /> class.
        /// </summary>
        /// <param name="size"> The size. </param>
        public ParticleBuffer(int size)
        {
            _size = size;

            _nativePointer = Marshal.AllocHGlobal(SizeInBytes);
            _pointer       = (Particle*)_nativePointer;

            GC.AddMemoryPressure(SizeInBytes);
        }

        /// <summary>
        ///     memcpy call
        ///     Copies the values of num bytes from the location pointed to by source directly to the memory block pointed to by
        ///     destination.
        /// </summary>
        /// <param name="dest">destination ptr</param>
        /// <param name="src">source ptr</param>
        /// <param name="count">count of bytes to copy</param>
        [SuppressUnmanagedCodeSecurity]
        [DllImport(
            "msvcrt.dll", EntryPoint = "memcpy", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        private static extern void MemCpy(void* dest,
                                          void* src,
                                          int   count);

        /// <summary>
        ///     memcpy call
        ///     Copies the values of num bytes from the location pointed to by source directly to the memory block pointed to by
        ///     destination.
        /// </summary>
        /// <param name="dest">destination addr</param>
        /// <param name="src">source addr</param>
        /// <param name="count">count of bytes to copy</param>
        [SuppressUnmanagedCodeSecurity]
        [DllImport(
            "msvcrt.dll", EntryPoint = "memcpy", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        private static extern void MemCpy(IntPtr dest,
                                          IntPtr src,
                                          int    count);

        /// <summary>
        ///     Allocates.
        /// </summary>
        /// <param name="quantity"> The quantity. </param>
        /// <param name="first">    [in,out] If non-, the first. </param>
        /// <returns>
        ///     An int.
        /// </returns>
        public int Allocate(int quantity, out Particle* first)
        {
            //_size - _tail = Available
            int numToRelease = Math.Min(quantity, _size - _tail);
            first =  _pointer + _tail;
            _tail += numToRelease;
            return numToRelease;
        }

        /// <summary>
        ///     Deallocates.
        /// </summary>
        /// <param name="quantity"> The quantity. </param>
        public void Deallocate(int quantity)
        {
            _tail -= quantity;
            MemCpy(_pointer, _pointer + quantity, Particle.SIZE_IN_BYTES * _tail);
        }

        /// <summary>
        ///     Copies to described by destination.
        /// </summary>
        /// <param name="destination"> Destination for the. </param>
        public void CopyTo(IntPtr destination)
        {
            MemCpy(destination, _nativePointer, Particle.SIZE_IN_BYTES * _tail);
        }

        #region IDisposable Support

        /// <summary>
        ///     True if disposed.
        /// </summary>
        private bool _disposed;

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Finalizes an instance of the <see cref="ParticleBuffer" /> class.
        /// </summary>
        ~ParticleBuffer()
        {
            Dispose(false);
        }

        /// <summary>
        ///     Releases the unmanaged resources used by the Exomia.ParticleSystem.ParticleBuffer and optionally releases the
        ///     managed resources.
        /// </summary>
        /// <param name="disposing">  to release both managed and unmanaged resources;  to release only unmanaged resources. </param>
#pragma warning disable IDE0060 // Remove unused parameter
        private void Dispose(bool disposing)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            if (!_disposed)
            {
                Marshal.FreeHGlobal(_nativePointer);
                GC.RemoveMemoryPressure(Particle.SIZE_IN_BYTES * _size);
                _disposed = true;
            }
        }

        #endregion
    }
}
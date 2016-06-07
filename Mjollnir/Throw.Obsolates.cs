#region LICENSE
// Copyright (c) 2008-2016, Hiroaki SHIBUKI
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
//
// * Redistributions of source code must retain the above copyright notice, this
//   list of conditions and the following disclaimer.
//
// * Redistributions in binary form must reproduce the above copyright notice,
//   this list of conditions and the following disclaimer in the documentation
//   and/or other materials provided with the distribution.
//
// * Neither the name of the {organization} nor the names of its
//   contributors may be used to endorse or promote products derived from
//   this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
// OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
#endregion

namespace Mjollnir
{
    using System;

    partial class Throw
    {
        #region If

        [Obsolete]
        public static void If(bool condition, Func<Exception> factory)
        {
            if (factory == null) throw new System.ArgumentNullException(nameof(factory));

            if (condition) throw factory();
        }

        #endregion

        #region IfNull

        [Obsolete]
        public static void IfNull<TParam>(TParam param)
            where TParam : class
        {
            Throw.If(param == null, () => new System.ArgumentNullException());
        }

        [Obsolete]
        public static void IfNull<TParam>(TParam param, string paramName)
            where TParam : class
        {
            Throw.If(paramName == null, () => new System.ArgumentNullException(nameof(paramName)));

            Throw.If(param == null, () => new System.ArgumentNullException(paramName));
        }

        [Obsolete]
        public static void IfNull<TParam>(TParam param, string userMessage, Exception innerException)
            where TParam : class
        {
            Throw.If(userMessage == null, () => new System.ArgumentNullException(nameof(userMessage)));
            Throw.If(innerException == null, () => new System.ArgumentNullException(nameof(innerException)));

            Throw.If(param == null, () => new System.ArgumentNullException(userMessage, innerException));
        }

        [Obsolete]
        public static void IfNull<TParam>(TParam param, string paramName, string userMessage)
            where TParam : class
        {
            Throw.If(paramName == null, () => new System.ArgumentNullException(nameof(paramName)));
            Throw.If(userMessage == null, () => new System.ArgumentNullException(nameof(userMessage)));

            Throw.If(param == null, () => new System.ArgumentNullException(paramName, userMessage));
        }

        #endregion

        #region IfOutOfRange

        [Obsolete]
        public static void IfOutOfRange(bool condition)
        {
            Throw.If(condition, () => new System.ArgumentOutOfRangeException());
        }

        [Obsolete]
        public static void IfOutOfRange(bool condition, string paramName)
        {
            Throw.ArgumentNullException.IfNull(paramName, nameof(paramName));

            Throw.If(condition, () => new System.ArgumentOutOfRangeException(paramName));
        }

        [Obsolete]
        public static void IfOutOfRange(bool condition, string userMessage, Exception innerException)
        {
            Throw.ArgumentNullException.IfNull(userMessage, nameof(userMessage));
            Throw.ArgumentNullException.IfNull(innerException, nameof(innerException));

            Throw.If(condition, () => new System.ArgumentOutOfRangeException(userMessage, innerException));
        }

        [Obsolete]
        public static void IfOutOfRange(bool condition, string paramName, string userMessage)
        {
            Throw.ArgumentNullException.IfNull(paramName, nameof(paramName));
            Throw.ArgumentNullException.IfNull(userMessage, nameof(userMessage));

            Throw.If(condition, () => new System.ArgumentOutOfRangeException(paramName, userMessage));
        }

        [Obsolete]
        public static void IfOutOfRange(bool condition, string paramName, object actualValue, string userMessage)
        {
            Throw.ArgumentNullException.IfNull(paramName, nameof(paramName));
            // actuaValue can be null.
            Throw.ArgumentNullException.IfNull(userMessage, nameof(userMessage));

            Throw.If(condition, () => new System.ArgumentOutOfRangeException(paramName, actualValue, userMessage));
        }

        #endregion

        #region IfInvalidOperation

        [Obsolete]
        public static void IfInvalidOperation(bool condition)
        {
            Throw.If(condition, () => new System.InvalidOperationException());
        }

        [Obsolete]
        public static void IfInvalidOperation(bool condition, string userMessage)
        {
            Throw.ArgumentNullException.IfNull(userMessage, nameof(userMessage));

            Throw.If(condition, () => new System.InvalidOperationException(userMessage));
        }

        [Obsolete]
        public static void IfInvalidOperation(bool condition, string userMessage, Exception innerException)
        {
            Throw.ArgumentNullException.IfNull(userMessage, nameof(userMessage));
            Throw.ArgumentNullException.IfNull(innerException, nameof(innerException));

            Throw.If(condition, () => new System.InvalidOperationException(userMessage, innerException));
        }

        #endregion

        #region IfNotSupported

        [Obsolete]
        public static void IfNotSupported(bool condition)
        {
            Throw.If(condition, () => new System.NotSupportedException());
        }

        [Obsolete]
        public static void IfNotSupported(bool condition, string userMessage)
        {
            Throw.ArgumentNullException.IfNull(userMessage, nameof(userMessage));

            Throw.If(condition, () => new System.NotSupportedException(userMessage));
        }

        [Obsolete]
        public static void IfNotSupported(bool condition, string userMessage, Exception innerException)
        {
            Throw.ArgumentNullException.IfNull(userMessage, nameof(userMessage));
            Throw.ArgumentNullException.IfNull(innerException, nameof(innerException));

            Throw.If(condition, () => new System.NotSupportedException(userMessage, innerException));
        }

        #endregion
    }
}

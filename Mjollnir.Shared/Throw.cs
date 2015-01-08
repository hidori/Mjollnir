#region LICENSE
// Copyright (c) 2008-2015, Hiroaki SHIBUKI
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

    public static partial class Throw
    {
        #region If

        public static void If(bool condition, Func<Exception> factory)
        {
            if (factory == null) throw new ArgumentNullException("factory");

            if (condition) throw factory();
        }

        #endregion

        #region IfNull

        public static void IfNull<TParam>(TParam param)
            where TParam : class
        {
            Throw.If(param == null, () => new ArgumentNullException());
        }

        public static void IfNull<TParam>(TParam param, string paramName)
            where TParam : class
        {
            Throw.If(paramName == null, () => new ArgumentNullException("paramName"));

            Throw.If(param == null, () => new ArgumentNullException(paramName));
        }

        public static void IfNull<TParam>(TParam param, string userMessage, Exception innerException)
            where TParam : class
        {
            Throw.If(userMessage == null, () => new ArgumentNullException("userMessage"));
            Throw.If(innerException == null, () => new ArgumentNullException("innerException"));

            Throw.If(param == null, () => new ArgumentNullException(userMessage, innerException));
        }

        public static void IfNull<TParam>(TParam param, string paramName, string userMessage)
            where TParam : class
        {
            Throw.If(paramName == null, () => new ArgumentNullException("paramName"));
            Throw.If(userMessage == null, () => new ArgumentNullException("userMessage"));

            Throw.If(param == null, () => new ArgumentNullException(paramName, userMessage));
        }

        #endregion

        #region IfOutOfRange

        public static void IfOutOfRange(bool condition)
        {
            Throw.If(condition, () => new ArgumentOutOfRangeException());
        }

        public static void IfOutOfRange(bool condition, string paramName)
        {
            Throw.IfNull(paramName, "paramName");

            Throw.If(condition, () => new ArgumentOutOfRangeException(paramName));
        }

        public static void IfOutOfRange(bool condition, string userMessage, Exception innerException)
        {
            Throw.IfNull(userMessage, "userMessage");
            Throw.IfNull(innerException, "innerException");

            Throw.If(condition, () => new ArgumentOutOfRangeException(userMessage, innerException));
        }

        public static void IfOutOfRange(bool condition, string paramName, string userMessage)
        {
            Throw.IfNull(paramName, "paramName");
            Throw.IfNull(userMessage, "userMessage");

            Throw.If(condition, () => new ArgumentOutOfRangeException(paramName, userMessage));
        }

        public static void IfOutOfRange(bool condition, string paramName, object actualValue, string userMessage)
        {
            Throw.IfNull(paramName, "paramName");
            // actuaValue can be null.
            Throw.IfNull(userMessage, "userMessage");

            Throw.If(condition, () => new ArgumentOutOfRangeException(paramName, actualValue, userMessage));
        }

        #endregion
    }

    public static class Throw<TException> where TException : Exception
    {
        public static void If(bool condition)
        {
            Throw.If(condition, () => (TException)System.Activator.CreateInstance(typeof(TException)));
        }

        public static void If(bool condition, string userMessage)
        {
            Throw.IfNull(userMessage, "userMessage");

            Throw.If(condition, () => (TException)System.Activator.CreateInstance(typeof(TException), new object[] { userMessage }));
        }

        public static void If(bool condition, string userMessage, Exception innerException)
        {
            Throw.IfNull(userMessage, "userMessage");
            Throw.IfNull(innerException, "innerException");

            Throw.If(condition, () => (TException)System.Activator.CreateInstance(typeof(TException), new object[] { userMessage, innerException }));
        }
    }
}

﻿#region LICENSE
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

namespace Mjollnir.Collections.Generic
{
    using System;
    using System.Collections.Generic;

    public static class EqualityComparerFactory
    {
        class EqualityComparer<T> : IEqualityComparer<T>
        {
            public EqualityComparer(Func<T, T, bool> equals, Func<T, int> getHashCode)
            {
                Throw.ArgumentNullException.IfNull(equals, nameof(equals));
                Throw.ArgumentNullException.IfNull(getHashCode, nameof(getHashCode));

                this.equals = equals;
                this.getHashCode = getHashCode;
            }

            Func<T, T, bool> equals;

            Func<T, int> getHashCode;

            public virtual bool Equals(T x, T y)
            {
                return this.equals(x, y);
            }

            public virtual int GetHashCode(T obj)
            {
                return this.getHashCode(obj);
            }
        }

        public static IEqualityComparer<T> Create<T>(Func<T, T, bool> equals, Func<T, int> getHashCode)
        {
            return new EqualityComparer<T>(equals, getHashCode);
        }
    }
}

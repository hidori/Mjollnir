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

namespace Mjollnir.Extensions
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class ByteArrayExtensions
    {
        public static Stream AsStream(this byte[] source, int index, int count)
        {
            Throw.ArgumentNullException.IfNull(source, nameof(source));

            Throw.ArgumentOutOfRangeException.If(index < 0, nameof(index));
            Throw.ArgumentOutOfRangeException.If(count < 0, nameof(count));

            return new MemoryStream(source, index, count);
        }

        public static Stream AsStream(this byte[] source)
        {
            Throw.ArgumentNullException.IfNull(source, nameof(source));

            return source.AsStream(0, source.Count());
        }

        public static Stream ToStream(this IEnumerable<byte> source, int index, int count)
        {
            Throw.ArgumentNullException.IfNull(source, nameof(source));

            return source.Skip(index).Take(count).ToArray().AsStream();
        }

        public static Stream ToStream(this IEnumerable<byte> source)
        {
            Throw.ArgumentNullException.IfNull(source, nameof(source));

            return source.ToArray().AsStream();
        }
    }
}

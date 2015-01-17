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

namespace Mjollnir.Collections.Generic.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public static partial class EnumerableExtensions
    {
        #region ForEach

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            Throw.IfNull(source, "source");
            Throw.IfNull(action, "action");

            foreach (var item in source)
            {
                action(item);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            Throw.IfNull(source, "source");
            Throw.IfNull(action, "action");

            source
                .Select((v, i) => new { Value = v, Index = i })
                .ForEach(_ => action(_.Value, _.Index));
        }

        #endregion

        #region AsReadOnlyCollection

        public static ReadOnlyCollection<T> AsReadOnlyCollection<T>(this IList<T> source)
        {
            Throw.IfNull(source, "source");

            return new ReadOnlyCollection<T>(source);
        }

        #endregion

        #region ToReadOnlyCollection

        public static ReadOnlyCollection<T> ToReadOnlyCollection<T>(this IEnumerable<T> source)
        {
            Throw.IfNull(source, "source");

            return source.ToArray().AsReadOnlyCollection();
        }

        #endregion

        #region AsReadOnlyDictionary

        public static ReadOnlyDictionary<TKey, TValue> AsReadOnlyDictionary<TKey, TValue>(this IDictionary<TKey, TValue> source)
        {
            Throw.IfNull(source, "source");

            return new ReadOnlyDictionary<TKey, TValue>(source);
        }

        #endregion

        #region ToReadOnlyDictionary

        public static ReadOnlyDictionary<TKey, T> ToReadOnlyDictionary<TKey, T>(this IEnumerable<T> source, Func<T, TKey> keySelector)
        {
            Throw.IfNull(source, "source");
            Throw.IfNull(keySelector, "keySelector");

            return source.ToDictionary(keySelector).AsReadOnlyDictionary();
        }

        public static ReadOnlyDictionary<TKey, T> ToReadOnlyDictionary<TKey, T>(this IEnumerable<T> source, Func<T, TKey> keySelector, IEqualityComparer<TKey> keyCcomparer)
        {
            Throw.IfNull(source, "source");
            Throw.IfNull(keySelector, "keySelector");
            Throw.IfNull(keyCcomparer, "keyComparer");

            return source.ToDictionary(keySelector, keyCcomparer).AsReadOnlyDictionary();
        }

        public static ReadOnlyDictionary<TKey, TElement> ToReadOnlyDictionary<T, TKey, TElement>(this IEnumerable<T> source, Func<T, TKey> keySelector, Func<T, TElement> elementSelector)
        {
            Throw.IfNull(source, "source");
            Throw.IfNull(keySelector, "keySelector");
            Throw.IfNull(elementSelector, "elementSelector");

            return source.ToDictionary(keySelector, elementSelector).AsReadOnlyDictionary();
        }

        public static ReadOnlyDictionary<TKey, TElement> ToReadOnlyDictionary<T, TKey, TElement>(this IEnumerable<T> source, Func<T, TKey> keySelector, Func<T, TElement> elementSelector, IEqualityComparer<TKey> keyComparer)
        {
            Throw.IfNull(source, "source");
            Throw.IfNull(keySelector, "keySelector");
            Throw.IfNull(elementSelector, "elementSelector");
            Throw.IfNull(keyComparer, "keyComparer");

            return source.ToDictionary(keySelector, elementSelector, keyComparer).AsReadOnlyDictionary();
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mjollnir.Collections.Generic.Extensions.Tests
{
    [TestClass]
    public partial class EnumerableExtensionsTest
    {
        [TestMethod]
        public void ForEachTest()
        {
            var source = new[] { "A", "B", "C" };

            {
                var action = (Action<string>)(_ => { });

                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ForEach(null, action));
                AssertEx.Throws<ArgumentNullException>(() => source.ForEach(default(Action<string>)));

                var destination = new List<string>();

                source.ForEach(_ => destination.Add(_));

                destination.Is(source);
            }

            {
                var action = (Action<char, int>)((v, i) => { });

                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ForEach(null, action));
                AssertEx.Throws<ArgumentNullException>(() => source.ForEach(default(Action<string, int>)));

                var destination = new List<string>();
                var indexes = new List<int>();

                source.ForEach((v, i) =>
                {
                    destination.Add(v);
                    indexes.Add(i);
                });

                destination.Is(source);
                indexes.Is(Enumerable.Range(0, source.Length));
            }
        }

        [TestMethod]
        public void AsReadOnlyCollectionTest()
        {
            var source = new[] { "A", "B", "C" };

            AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.AsReadOnlyCollection<string>(null));

            var destination = source.AsReadOnlyCollection();

            destination.IsInstanceOf<ReadOnlyCollection<string>>();
            destination.Is(source);
        }

        [TestMethod]
        public void ToReadOnlyCollectionTest()
        {
            var source = new[] { "A", "B", "C" };

            AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyCollection<string>(null));

            var destination = source.ToReadOnlyCollection();

            destination.IsInstanceOf<ReadOnlyCollection<string>>();
            destination.Is(source);
        }

        [TestMethod]
        public void AsReadOnlyDictionaryTest()
        {
            var source = new Dictionary<int, string>
            {
                { 1, "A" },
                { 2, "B" },
                { 3, "C" },
            };

            AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.AsReadOnlyDictionary<int, string>(null));

            var destination = source.AsReadOnlyDictionary();

            destination.IsInstanceOf<ReadOnlyDictionary<int, string>>();
            destination.Is(source);
        }

        class KeyValue
        {
            public int Key { get; set; }

            public string Value { get; set; }
        }

        class KeyEqualityComparer : IEqualityComparer<int>
        {
            public bool Equals(int x, int y)
            {
                return x == y;
            }

            public int GetHashCode(int obj)
            {
                return obj.GetHashCode();
            }
        }

        [TestMethod]
        public void ToReadOnlyDictionaryTest()
        {
            var source = new[]
            {
                new KeyValue { Key = 1, Value = "A" },
                new KeyValue { Key = 2, Value = "B" },
                new KeyValue { Key = 3, Value = "C" },
            };

            var keySelector = ((Func<KeyValue, int>)(_ => _.Key));
            var elementSelector = ((Func<KeyValue, string>)(_ => _.Value));
            var keyComparer = new KeyEqualityComparer();

            {
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<int, KeyValue>(null, null));
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<int, KeyValue>(null, keySelector));
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<int, KeyValue>(source, null));

                var destination = source.ToReadOnlyDictionary(keySelector);

                destination.IsInstanceOf<ReadOnlyDictionary<int, KeyValue>>();
                destination.Is(source.ToDictionary(keySelector).AsReadOnlyDictionary());
            }

            {
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<int, KeyValue>(null, null, null));
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<int, KeyValue>(null, null, keyComparer));
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<int, KeyValue>(null, keySelector, null));
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<int, KeyValue>(null, keySelector, keyComparer));
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<int, KeyValue>(source, null, null));
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<int, KeyValue>(source, keySelector, null));

                var destination = source.ToReadOnlyDictionary(keySelector, keyComparer);

                destination.IsInstanceOf<ReadOnlyDictionary<int, KeyValue>>();
                destination.Is(source.ToDictionary(keySelector, keyComparer).AsReadOnlyDictionary());
            }

            {
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<int, KeyValue>(null, null, null));
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<int, KeyValue>(null, null, keyComparer));
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<int, KeyValue>(null, keySelector, null));
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<int, KeyValue>(null, keySelector, keyComparer));
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<int, KeyValue>(source, null, null));
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<int, KeyValue>(source, keySelector, null));

                var destination = source.ToReadOnlyDictionary(keySelector, keyComparer);

                destination.IsInstanceOf<ReadOnlyDictionary<int, KeyValue>>();
                destination.Is(source.ToDictionary(keySelector, keyComparer).AsReadOnlyDictionary());
            }

            {
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<KeyValue, int, string>(null, null, null));
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<KeyValue, int, string>(null, null, elementSelector));
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<KeyValue, int, string>(null, keySelector, null));
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<KeyValue, int, string>(null, keySelector, elementSelector));
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<KeyValue, int, string>(source, null, null));
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<KeyValue, int, string>(source, keySelector, null));

                var destination = source.ToReadOnlyDictionary(keySelector, elementSelector);

                destination.IsInstanceOf<ReadOnlyDictionary<int, string>>();
                destination.Is(source.ToDictionary(keySelector, elementSelector).AsReadOnlyDictionary());
            }

            {
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<KeyValue, int, string>(null, null, null, null));
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<KeyValue, int, string>(null, null, null, keyComparer));
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<KeyValue, int, string>(null, null, elementSelector, null));
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<KeyValue, int, string>(null, null, elementSelector, keyComparer));
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<KeyValue, int, string>(null, keySelector, null, null));
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<KeyValue, int, string>(null, keySelector, null, keyComparer));
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<KeyValue, int, string>(null, keySelector, elementSelector, null));
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<KeyValue, int, string>(null, keySelector, elementSelector, keyComparer));
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<KeyValue, int, string>(source, null, null, null));
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<KeyValue, int, string>(source, null, null, keyComparer));
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<KeyValue, int, string>(source, null, elementSelector, null));
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<KeyValue, int, string>(source, null, elementSelector, keyComparer));
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<KeyValue, int, string>(source, keySelector, null, null));
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<KeyValue, int, string>(source, keySelector, null, keyComparer));
                AssertEx.Throws<ArgumentNullException>(() => EnumerableExtensions.ToReadOnlyDictionary<KeyValue, int, string>(source, keySelector, elementSelector, null));

                var destination = source.ToReadOnlyDictionary(keySelector, elementSelector, keyComparer);

                destination.IsInstanceOf<ReadOnlyDictionary<int, string>>();
                destination.Is(source.ToDictionary(keySelector, elementSelector, keyComparer).AsReadOnlyDictionary());
            }
        }
    }
}

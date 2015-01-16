using System;
using System.Collections.Generic;
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
    }
}

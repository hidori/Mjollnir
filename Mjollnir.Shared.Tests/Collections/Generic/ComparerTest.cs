using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Mjollnir.Collections.Generic.Tests
{
    [TestClass]
    public class ComparerTest
    {
        [TestMethod]
        public void CreateInstance()
        {
            AssertEx.Throws<ArgumentNullException>(() => new Comparer<int>(null));

            var compare = ((Func<int, int, int>)((x, y) => x - y));

            AssertEx.DoesNotThrow(() => new Comparer<int>(compare));
        }

        [TestMethod]
        public void CompareTest()
        {
            AssertEx.Throws<ArgumentNullException>(() => new Comparer<int>(null));

            var compare = ((Func<int, int, int>)((x, y) => x - y));

            var target = new Comparer<int>(compare);

            target.Compare(0, 0).Is(0);
            target.Compare(0, 1).Is(-1);
            target.Compare(1, 0).Is(1);
        }
    }
}

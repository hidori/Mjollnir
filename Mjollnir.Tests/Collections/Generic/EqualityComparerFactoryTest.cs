using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mjollnir.Collections.Generic.Tests
{
    [TestClass]
    public class EqualityComparerTest
    {
        [TestMethod]
        public void CreateTest()
        {
            var equals = ((Func<int, int, bool>)((x, y) => x == y));
            var getHashCode = ((Func<int, int>)(x => x.GetHashCode()));

            AssertEx.Throws<ArgumentNullException>(() => EqualityComparerFactory.Create<int>(null, null));
            AssertEx.Throws<ArgumentNullException>(() => EqualityComparerFactory.Create<int>(null, getHashCode));
            AssertEx.Throws<ArgumentNullException>(() => EqualityComparerFactory.Create<int>(equals, null));

            var comparer = EqualityComparerFactory.Create<int>(equals, getHashCode);

            comparer.IsInstanceOf<IEqualityComparer<int>>();
            comparer.Equals(1, 1).IsTrue();
            comparer.Equals(1, 3).IsFalse();
            comparer.GetHashCode(3).Is(3.GetHashCode());
        }
    }
}

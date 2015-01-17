using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mjollnir.Collections.Generic.Tests
{
    [TestClass]
    public class ComparerTest
    {
        [TestMethod]
        public void CreateInstance()
        {
            var compare = ((Func<int, int, int>)((x, y) => x - y));

            AssertEx.Throws<ArgumentNullException>(() => ComparerFactory.Create<int>(null));

            var comparer = ComparerFactory.Create<int>(compare);

            comparer.IsInstanceOf<IComparer<int>>();

            comparer.Compare(0, 0).Is(0);
            comparer.Compare(0, 1).Is(-1);
            comparer.Compare(1, 0).Is(1);
        }
    }
}

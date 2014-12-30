using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Mjollnir.Shared.Text.Test
{
    [TestClass]
    public class StringFactoryTest
    {
        [TestMethod]
        public void CreateTest()
        {
            AssertEx.Throws<ArgumentNullException>(() => StringFactory.Create(null));

            StringFactory.Create(sb =>
            {
                sb.Append("A");
                sb.Append("B");
                sb.Append("C");
            })
            .Is("ABC");
        }
    }
}

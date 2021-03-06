﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mjollnir.Test
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

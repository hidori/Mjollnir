using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mjollnir.Extensions.Tests
{
    [TestClass]
    public class ByteArrayExtensionsTest
    {
        [TestMethod]
        public void AsStreamTest()
        {
            var bytes = new[] { (byte)1, (byte)3, (byte)5 };

            {
                AssertEx.Throws<ArgumentNullException>(() => ByteArrayExtensions.AsStream(null));

                using (var stream = bytes.AsStream())
                {
                    stream.ReadByte().Is(1);
                    stream.ReadByte().Is(3);
                    stream.ReadByte().Is(5);

                    stream.Read(new byte[1], 0, 1).Is(0);
                }
            }

            {
                AssertEx.Throws<ArgumentNullException>(() => ByteArrayExtensions.AsStream(null, 1, 1));

                using (var stream = bytes.ToStream(1, 1))
                {
                    stream.ReadByte().Is(3);

                    stream.Read(new byte[1], 0, 1).Is(0);
                }
            }
        }

        [TestMethod]
        public void ToStreamTest()
        {
            var bytes = (IEnumerable<byte>)new[] { (byte)1, (byte)3, (byte)5 };

            {
                AssertEx.Throws<ArgumentNullException>(() => ByteArrayExtensions.ToStream(null));

                using (var stream = bytes.ToStream())
                {
                    stream.ReadByte().Is(1);
                    stream.ReadByte().Is(3);
                    stream.ReadByte().Is(5);

                    stream.Read(new byte[1], 0, 1).Is(0);
                }
            }

            {
                AssertEx.Throws<ArgumentNullException>(() => ByteArrayExtensions.ToStream(null, 1, 1));

                using (var stream = bytes.ToStream(1, 1))
                {
                    stream.ReadByte().Is(3);

                    stream.Read(new byte[1], 0, 1).Is(0);
                }
            }
        }
    }
}

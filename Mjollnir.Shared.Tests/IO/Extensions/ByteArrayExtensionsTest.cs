using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.IO;

namespace Mjollnir.IO.Extensions.Tests
{
    [TestClass]
    public class ByteArrayExtensionsTest
    {
        [TestMethod]
        public void AsStreamTest()
        {
            var buffer = new byte[] { 1, 2, 3, 4 };

            {
                AssertEx.Throws<ArgumentNullException>(() => ByteArrayExtensions.AsStream(null));

                using(var stream = buffer.AsStream())
                using(var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);

                    memoryStream.ToArray().Is(buffer);
                }
            }

            {
                AssertEx.Throws<ArgumentNullException>(() => ByteArrayExtensions.AsStream(null, 0, 0));
                AssertEx.Throws<ArgumentOutOfRangeException>(() => buffer.AsStream(0, -1));
                AssertEx.Throws<ArgumentOutOfRangeException>(() => buffer.AsStream(-1, 0));

                using (var stream = buffer.AsStream(1, 2))
                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);

                    var bytes = memoryStream.ToArray();

                    bytes.Count().Is(2);
                    bytes[0].Is((byte)2);
                    bytes[1].Is((byte)3);
                }
            }
        }
    }
}

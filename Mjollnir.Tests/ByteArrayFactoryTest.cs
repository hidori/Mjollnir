using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mjollnir
{
    [TestClass]
    public class ByteArrayFactoryTest
    {
        [TestMethod]
        public void CreateTest()
        {
            var action = ((Action<Stream>)(stream => 
            {
                stream.WriteByte(1);
                stream.WriteByte(2);
                stream.WriteByte(3);
            }));

            AssertEx.Throws<ArgumentNullException>(() => ByteArrayFactory.Create(null));

            var bytes = ByteArrayFactory.Create(action);

            bytes[0].Is((byte)1);
            bytes[1].Is((byte)2);
            bytes[2].Is((byte)3);
        }
    }
}

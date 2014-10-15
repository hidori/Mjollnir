using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace Mjollnir.IO.Extensions.Tests
{
    [TestClass]
    public class TextReaderExtensionsTest
    {
        [TestMethod]
        public void ReadLinesTest()
        {
            var source = new[] { "a", "b", "c" };

            AssertEx.Throws<ArgumentNullException>(() => TextReaderExtensions.ReadLines(null).ToArray());

            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream))
            {
                foreach (var s in source)
                {
                    writer.WriteLine(s);
                }
                writer.Flush();

                stream.Seek(0, SeekOrigin.Begin);

                using (var reader = new StreamReader(stream))
                {
                    var array = reader.ReadLines().ToArray();

                    array.Count().Is(source.Count());
                    Enumerable.Range(0, array.Count()).All(i => array[i] == source[i]).IsTrue();
                }
            }
        }
    }
}

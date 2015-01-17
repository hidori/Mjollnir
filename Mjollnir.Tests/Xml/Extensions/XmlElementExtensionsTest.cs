using System;
using System.Linq;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mjollnir.Xml.Extensions.Tests
{
    [TestClass]
    public class XmlElementExtensionsTest
    {
        [TestMethod]
        public void AttributesTest()
        {
            var xml = new XmlDocument();

            xml.LoadXml(@"<doc><hoge abc=""123"" def=""456"" /></doc>");

            var ele = (XmlElement)xml.DocumentElement.GetElementsByTagName("hoge")[0];

            {
                AssertEx.Throws<ArgumentNullException>(() => XmlElementExtensions.Attributes(null));

                var attributes = ele.Attributes().ToArray();

                attributes.Count().Is(2);

                attributes[0].Name.Is("abc");
                attributes[0].Value.Is("123");

                attributes[1].Name.Is("def");
                attributes[1].Value.Is("456");
            }

            {
                var predicate = ((Func<XmlAttribute, bool>)(_ => _.Name == "def"));

                AssertEx.Throws<ArgumentNullException>(() => XmlElementExtensions.Attributes(null, null));
                AssertEx.Throws<ArgumentNullException>(() => XmlElementExtensions.Attributes(null, predicate));

                var attributes = ele.Attributes(predicate).ToArray();

                attributes.Count().Is(1);

                attributes[0].Name.Is("def");
                attributes[0].Value.Is("456");
            }
        }

        [TestMethod]
        public void ElementsTest()
        {
            var xml = new XmlDocument();

            xml.LoadXml(@"<doc><hoge>123</hoge><moge>456</moge></doc>");

            {
                AssertEx.Throws<ArgumentNullException>(() => XmlElementExtensions.Elements(null));

                var elements = xml.DocumentElement.Elements().ToArray();

                elements.Count().Is(2);

                elements[0].Name.Is("hoge");
                elements[0].InnerText.Is("123");

                elements[1].Name.Is("moge");
                elements[1].InnerText.Is("456");
            }

            {
                var predicate = ((Func<XmlElement, bool>)(_ => _.Name == "moge"));

                AssertEx.Throws<ArgumentNullException>(() => XmlElementExtensions.Elements(null, null));
                AssertEx.Throws<ArgumentNullException>(() => XmlElementExtensions.Elements(null, predicate));

                var attributes = xml.DocumentElement.Elements(predicate).ToArray();

                attributes.Count().Is(1);

                attributes[0].Name.Is("moge");
                attributes[0].InnerText.Is("456");
            }
        }
    }
}

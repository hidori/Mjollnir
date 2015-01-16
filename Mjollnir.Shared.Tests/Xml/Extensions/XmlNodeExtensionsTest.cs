using System;
using System.Linq;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mjollnir.Xml.Extensions.Tests
{
    [TestClass]
    public class XmlNodeExtensionsTest
    {
        [TestMethod]
        public void NodesTest()
        {
            var xml = new XmlDocument();

            xml.LoadXml(@"<doc><hoge>123</hoge><!-- --><moge>456</moge></doc>");

            {
                AssertEx.Throws<ArgumentNullException>(() => XmlNodeExtensions.Nodes(null));

                var nodes = xml.DocumentElement.Nodes().ToArray();

                nodes.Count().Is(3);

                nodes[0].NodeType.Is(XmlNodeType.Element);
                nodes[0].Name.Is("hoge");
                nodes[0].InnerText.Is("123");

                nodes[1].NodeType.Is(XmlNodeType.Comment);

                nodes[2].NodeType.Is(XmlNodeType.Element);
                nodes[2].Name.Is("moge");
                nodes[2].InnerText.Is("456");
            }

            {
                var predicate = ((Func<XmlNode, bool>)(_ => _.NodeType == XmlNodeType.Element));

                AssertEx.Throws<ArgumentNullException>(() => XmlNodeExtensions.Nodes(null, null));
                AssertEx.Throws<ArgumentNullException>(() => XmlNodeExtensions.Nodes(null, predicate));

                var nodes = xml.DocumentElement.Nodes(predicate).ToArray();

                nodes.Count().Is(2);

                nodes[0].NodeType.Is(XmlNodeType.Element);
                nodes[0].Name.Is("hoge");
                nodes[0].InnerText.Is("123");

                nodes[1].NodeType.Is(XmlNodeType.Element);
                nodes[1].Name.Is("moge");
                nodes[1].InnerText.Is("456");
            }
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Mjollnir.Xml.Linq.Extensions.Tests
{
    [TestClass]
    public class XElementExtentionsTest
    {
        [TestMethod]
        public void WalkTest()
        {
            var xml = XDocument.Parse(@"<doc><hoge>123<hogehoge>789</hogehoge>123</hoge><moge>456<mogemoge>ABC</mogemoge>456</moge></doc>");

            var elements = new List<XElement>();

            xml.Root.Walk(e => elements.Add(e));

            elements.Count.Is(5);

            elements[0].Name.Is("doc");
            elements[0].Value.Is("123789123456ABC456");

            elements[1].Name.Is("hoge");
            elements[1].Value.Is("123789123");

            elements[2].Name.Is("hogehoge");
            elements[2].Value.Is("789");

            elements[3].Name.Is("moge");
            elements[3].Value.Is("456ABC456");

            elements[4].Name.Is("mogemoge");
            elements[4].Value.Is("ABC");
        }
    }
}

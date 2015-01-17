using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mjollnir
{
	[TestClass]
	public class ActivaterTest
	{
		class Hoge
		{
			public Hoge()
			{
				this.Value = string.Empty;
			}

			public Hoge(char c, int count)
			{
				this.Value = new string(c, count);
			}

			public string Value { get; set; }
		}

		[TestMethod]
		public void CreateInstanceTest()
		{
			Activator.CreateInstance<Hoge>().Value.Is(string.Empty);

			{
				AssertEx.Throws<ArgumentNullException>(() => Activator.CreateInstance<Hoge>(null));

				var c = 'a';
				var count = 4;

				Activator.CreateInstance<Hoge>(new object[] { c, count }).Value.Is(new string(c, count));
			}
		}
	}
}

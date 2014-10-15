using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mjollnir.Extensions.Tests
{
    [TestClass]
    public class ComparableExtensionsTest
    {
        [TestMethod]
        public void EqualToTest()
        {
            ComparableExtensions.EqualTo<string>(null, null).IsTrue();
            ComparableExtensions.EqualTo<string>(null, "a").IsFalse();
            ComparableExtensions.EqualTo<string>("a", null).IsFalse();
            ComparableExtensions.EqualTo<string>("a", "a").IsTrue();
            ComparableExtensions.EqualTo<string>("a", "b").IsFalse();
            ComparableExtensions.EqualTo<string>("b", "a").IsFalse();
        }

        [TestMethod]
        public void GreaterThanTest()
        {
            ComparableExtensions.GreaterThan<string>(null, null).IsFalse();
            ComparableExtensions.GreaterThan<string>(null, "a").IsFalse();
            ComparableExtensions.GreaterThan<string>("a", null).IsTrue();
            ComparableExtensions.GreaterThan<string>("a", "a").IsFalse();
            ComparableExtensions.GreaterThan<string>("a", "b").IsFalse();
            ComparableExtensions.GreaterThan<string>("b", "a").IsTrue();
        }

        [TestMethod]
        public void GreaterThanOrEqualToTest()
        {
            ComparableExtensions.GreaterThanOrEqualTo<string>(null, null).IsTrue();
            ComparableExtensions.GreaterThanOrEqualTo<string>(null, "a").IsFalse();
            ComparableExtensions.GreaterThanOrEqualTo<string>("a", null).IsTrue();
            ComparableExtensions.GreaterThanOrEqualTo<string>("a", "a").IsTrue();
            ComparableExtensions.GreaterThanOrEqualTo<string>("a", "b").IsFalse();
            ComparableExtensions.GreaterThanOrEqualTo<string>("b", "a").IsTrue();
        }

        [TestMethod]
        public void LessThanTest()
        {
            ComparableExtensions.LessThan<string>(null, null).IsFalse();
            ComparableExtensions.LessThan<string>(null, "a").IsTrue();
            ComparableExtensions.LessThan<string>("a", null).IsFalse();
            ComparableExtensions.LessThan<string>("a", "a").IsFalse();
            ComparableExtensions.LessThan<string>("a", "b").IsTrue();
            ComparableExtensions.LessThan<string>("b", "a").IsFalse();
        }

        [TestMethod]
        public void LessThanOrEqualTo()
        {
            ComparableExtensions.LessThanOrEqualTo<string>(null, null).IsTrue();
            ComparableExtensions.LessThanOrEqualTo<string>(null, "a").IsTrue();
            ComparableExtensions.LessThanOrEqualTo<string>("a", null).IsFalse();
            ComparableExtensions.LessThanOrEqualTo<string>("a", "a").IsTrue();
            ComparableExtensions.LessThanOrEqualTo<string>("a", "b").IsTrue();
            ComparableExtensions.LessThanOrEqualTo<string>("b", "a").IsFalse();
        }

        [TestMethod]
        public void BetweenTest()
        {
            ComparableExtensions.Between<string>(null, null, null).IsTrue();
            ComparableExtensions.Between<string>(null, null, "a").IsTrue();
            ComparableExtensions.Between<string>(null, "a", null).IsFalse();
            ComparableExtensions.Between<string>(null, "a", "a").IsFalse();
            ComparableExtensions.Between<string>("a", null, null).IsFalse();
            ComparableExtensions.Between<string>("a", null, "a").IsTrue();
            ComparableExtensions.Between<string>("a", "a", null).IsFalse();
            ComparableExtensions.Between<string>("a", "a", "a").IsTrue();

            ComparableExtensions.Between<string>(null, "a", "b").IsFalse();
            ComparableExtensions.Between<string>(null, "b", "a").IsFalse();
            ComparableExtensions.Between<string>("a", null, "b").IsTrue();
            ComparableExtensions.Between<string>("a", "b", null).IsFalse();
            ComparableExtensions.Between<string>("b", null, "a").IsFalse();
            ComparableExtensions.Between<string>("b", "a", null).IsFalse();

            ComparableExtensions.Between<string>("a", "b", "c").IsFalse();
            ComparableExtensions.Between<string>("a", "c", "b").IsFalse();
            ComparableExtensions.Between<string>("b", "a", "c").IsTrue();
            ComparableExtensions.Between<string>("b", "c", "a").IsFalse();
            ComparableExtensions.Between<string>("c", "a", "b").IsFalse();
            ComparableExtensions.Between<string>("c", "b", "a").IsFalse();
        }
    }
}

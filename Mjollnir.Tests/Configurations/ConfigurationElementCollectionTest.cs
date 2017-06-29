using NUnit.Framework;
using System.Configuration;

namespace Mjollnir.Configurations
{
    public class T : ConfigurationElement
    {
        public string Key { get; set; }
    }

    [TestFixture(TestOf = typeof(ConfigurationElementCollection<T>))]
    public class ConfigurationElementCollectionTest : ConfigurationElementCollection<T>
    {
        static class Settings
        {
            public const string Key = "ABCdef";
        }

        protected override object GetElementKey(T element)
        {
            return element.Key;
        }

        [Test(Description = "GetElementKey(ConfigurationElement) メソッドの単体テスト", TestOf = typeof(ConfigurationElementCollection<T>))]
        public void GetElementKeyTest()
        {
            var element = new T { Key = Settings.Key };

            // SPEC: GetElementKey(ConfigurationElement) は、GetElementKey(T) と同じ値を返す。
            var key = this.GetElementKey((ConfigurationElement)element);
            key.Is(this.GetElementKey(element));
            key.Is(Settings.Key);
        }

        [Test(Description = "CreateNewelement() メソッドの単体テスト", TestOf = typeof(ConfigurationElementCollection<T>))]
        public void CreateNewElementTest()
        {
            // SPECL: CreateNewElement() は、T 型のオブジェクトインスタンスを返す。
            this.CreateNewElement().IsInstanceOf<T>();
        }

        [Test(Description = "プロパティの単体テスト", TestOf = typeof(ConfigurationElementCollection<T>))]
        public void PropertiesTest()
        {
            // SPEC: CollectionType プロパティは、ConfigurationElementCollectionType.BaseMap を返す。
            this.CollectionType.Is(ConfigurationElementCollectionType.BasicMap);
        }
    }
}

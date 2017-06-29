using System.Configuration;

namespace Mjollnir.Configurations
{
    /// <summary>
    /// 構成要素コレクションの基本実装を提供します。
    /// </summary>
    /// <typeparam name="T">構成要素の型</typeparam>
    public abstract class ConfigurationElementCollection<T> : ConfigurationElementCollection
        where T : ConfigurationElement, new()
    {
        /// <summary>
        /// 構成要素のキーを取得します。
        /// </summary>
        /// <param name="element">構成要素</param>
        /// <returns>構成要素のキーとなるオブジェクトインスタンス</returns>
        protected abstract object GetElementKey(T element);

        /// <summary>
        /// 構成要素のキーを取得します。
        /// </summary>
        /// <param name="element">構成要素</param>
        /// <returns>構成要素のキーとなるオブジェクトインスタンス</returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return this.GetElementKey((T)element);
        }

        /// <summary>
        /// 構成要素の新規インスタンスを作成します。
        /// </summary>
        /// <returns></returns>
        protected override ConfigurationElement CreateNewElement() => new T();

        /// <summary>
        /// 構成要素コレクションの種別を取得します。
        /// </summary>
        public override ConfigurationElementCollectionType CollectionType { get; } = ConfigurationElementCollectionType.BasicMap;
    }
}

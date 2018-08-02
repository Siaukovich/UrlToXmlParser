namespace UrlToXml.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface that every data provider class must implement.
    /// </summary>
    /// <typeparam name="T">
    /// Type of provided data.
    /// </typeparam>
    public interface IDataProvider<out T>
    {
        /// <summary>
        /// Provides data from given source.
        /// </summary>
        /// <param name="source">
        /// Data source.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<T> ProvideData(string source);
    }
}

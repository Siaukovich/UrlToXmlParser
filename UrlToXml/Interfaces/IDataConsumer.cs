namespace UrlToXml.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface that every data consumer must implement.
    /// </summary>
    /// <typeparam name="T">
    /// Type of data.
    /// </typeparam>
    public interface IDataConsumer<in T>
    {
        /// <summary>
        /// Consume data to some destination.
        /// </summary>
        /// <param name="data">
        /// Data to consume.
        /// </param>
        /// <param name="destination">
        /// Data destination.
        /// </param>
        void Consume(IEnumerable<T> data, string destination);
    }
}
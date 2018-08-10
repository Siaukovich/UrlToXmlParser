namespace DataConverter.Base
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface that every data consumer must implement.
    /// </summary>
    /// <typeparam name="TInput">
    /// Type of data.
    /// </typeparam>
    public interface IDataConsumer<in TInput>
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
        void Consume(IEnumerable<TInput> data, string destination);
    }
}
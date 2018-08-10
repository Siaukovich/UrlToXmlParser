namespace DataConverter.Base
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface that every mapper must implement.
    /// </summary>
    /// <typeparam name="TSource">
    /// Type of source data.
    /// </typeparam>
    /// <typeparam name="TResult">
    /// Type of result data.
    /// </typeparam>
    public interface IMapper<in TSource, out TResult>
    {
        /// <summary>
        /// Parses all valid.
        /// </summary>
        /// <param name="source">
        /// Data source.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<TResult> Map(IEnumerable<TSource> source);
    }
}
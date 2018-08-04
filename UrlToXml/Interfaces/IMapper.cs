namespace UrlToXml.Interfaces
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
    public interface IMapper<TSource, out TResult>
    {
        /// <summary>
        /// Gets the data parser.
        /// </summary>
        IDataParser<TSource, TResult> Parser { get; }

        /// <summary>
        /// Gets the data validator.
        /// </summary>
        IGroupDataValidator<TSource> Validator { get; }

        /// <summary>
        /// Parses all valid.
        /// </summary>
        /// <param name="source">
        /// Data source.
        /// </param>
        /// <param name="logger">
        /// Logger.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<TResult> Map(IEnumerable<TSource> source, ILogger logger = null);
    }
}
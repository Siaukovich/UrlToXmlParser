namespace UrlToXml.Interfaces
{
    /// <summary>
    /// Interface that every data parser class must implement.
    /// </summary>
    /// <typeparam name="TInput">
    /// Type of input data.
    /// </typeparam>
    /// <typeparam name="TResult">
    /// Type of result data.
    /// </typeparam>
    public interface IDataParser<in TInput, out TResult>
    {
        /// <summary>
        /// The parse.
        /// </summary>
        /// <param name="input">
        /// The input data.
        /// </param>
        /// <returns>
        /// The <see cref="TResult"/>.
        /// Parsed data.
        /// </returns>
        TResult Parse(TInput input);
    }
}
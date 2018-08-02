namespace UrlToXml.Interfaces
{
    /// <summary>
    /// Interface that every data parser class must implement.
    /// </summary>
    /// <typeparam name="TInitial">
    /// Type of input data.
    /// </typeparam>
    /// <typeparam name="TResult">
    /// Type of result data.
    /// </typeparam>
    public interface IDataParser<TInitial, out TResult>
    {
        /// <summary>
        /// The parse.
        /// </summary>
        /// <param name="input">
        /// The input data.
        /// </param>
        /// <param name="groupDataValidator">
        /// Group of single data validators.
        /// </param>
        /// <returns>
        /// The <see cref="TResult"/>.
        /// Parsed data.
        /// </returns>
        TResult Parse(TInitial input, IGroupDataValidator<TInitial> groupDataValidator);
    }
}
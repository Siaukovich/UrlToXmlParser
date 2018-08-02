namespace UrlToXml.Interfaces
{
    /// <summary>
    /// Interface that every parser service must implement.
    /// </summary>
    /// <typeparam name="TInitial">
    /// Initial representation of target type.
    /// </typeparam>
    /// <typeparam name="TTarget">
    /// Target type.
    /// </typeparam>
    public interface IParserSevice<TInitial, TTarget>
    {
        /// <summary>
        /// Parses information from one format to another.
        /// </summary>
        /// <param name="provider">
        /// Data provider.
        /// </param>
        /// <param name="consumer">
        /// Data consumer.
        /// </param>
        /// <param name="validator">
        /// Data validator.
        /// </param>
        /// <param name="parser">
        /// Data parser.
        /// </param>
        void Parse(
            IDataProvider<TInitial> provider,
            IDataConsumer<TTarget> consumer,
            IGroupDataValidator<TInitial> validator,
            IDataParser<TInitial, TTarget> parser);
    }
}
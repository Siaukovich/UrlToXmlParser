namespace DataConverter.Base
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
    public interface IParserService<TInitial, TTarget>
    {
        /// <summary>
        /// Sets dependencies.
        /// </summary>
        /// <param name="provider">
        /// Data provider.
        /// </param>
        /// <param name="consumer">
        /// Data consumer.
        /// </param>
        /// <param name="mapper">
        /// Data mapper.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        void SetDependencies(
            IDataProvider<TInitial> provider,
            IDataConsumer<TTarget> consumer,
            IMapper<TInitial, TTarget> mapper);

        /// <summary>
        /// Parses information from one format to another.
        /// </summary>
        void Parse();
    }
}
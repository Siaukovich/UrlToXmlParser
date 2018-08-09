namespace UrlToXml.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using Ninject;

    /// <summary>
    /// The parser service.
    /// </summary>
    /// <typeparam name="TInitial">
    /// Initial representation of TTarget type object.
    /// </typeparam>
    /// <typeparam name="TTarget">
    /// Type of represented object.
    /// </typeparam>
    public class ParserService<TInitial, TTarget> : IParserSevice<TInitial, TTarget>
    {
        /// <summary>
        /// Parses data of type TTarget that given in TInitial type form.
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
        /// Logger.
        /// </param>
        [Inject]
        public void Parse(
            IDataProvider<TInitial> provider, 
            IDataConsumer<TTarget> consumer, 
            IMapper<TInitial, TTarget> mapper,
            ILogger logger = null)
        {
            logger?.Info("ParserService begun to work");

            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            if (consumer == null)
            {
                throw new ArgumentNullException(nameof(consumer));
            }

            if (mapper == null)
            {
                throw new ArgumentNullException(nameof(mapper));
            }

            string source = ConfigurationManager.AppSettings["source"];
            string destination = ConfigurationManager.AppSettings["destination"];

            IEnumerable<TInitial> data = provider.ProvideData(source);

            IEnumerable<TTarget> parsedData = mapper.Map(data, logger);

            consumer.Consume(parsedData, destination);
        }
    }
}
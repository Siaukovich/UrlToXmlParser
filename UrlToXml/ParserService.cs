namespace UrlToXml
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using DataConverter.Base;

    using Logger.Base;

    using Ninject;

    /// <summary>
    /// The parser service.
    /// </summary>
    /// <typeparam name="TSource">
    /// Initial representation of TTarget type object.
    /// </typeparam>
    /// <typeparam name="TTarget">
    /// Type of represented object.
    /// </typeparam>
    public class ParserService<TSource, TTarget> : IParserService<TSource, TTarget>
    {
        /// <summary>
        /// Data provider.
        /// </summary>
        private IDataProvider<TSource> provider;

        /// <summary>
        /// Data consumer.
        /// </summary>
        private IDataConsumer<TTarget> consumer;

        /// <summary>
        /// Data mapper.
        /// </summary>
        private IMapper<TSource, TTarget> mapper;

        /// <summary>
        /// The logger.
        /// </summary>
        [Inject]
        public ILogger Logger { get; set; }

        /// <summary>
        /// Sets dependencies.
        /// </summary>
        /// <param name="dataProvider">
        /// Data provider.
        /// </param>
        /// <param name="dataConsumer">
        /// Data consumer.
        /// </param>
        /// <param name="dataMapper">
        /// Data mapper.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        [Inject]
        public void SetDependencies(IDataProvider<TSource> dataProvider, IDataConsumer<TTarget> dataConsumer, IMapper<TSource, TTarget> dataMapper)
        {
            this.provider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));
            this.consumer = dataConsumer ?? throw new ArgumentNullException(nameof(dataConsumer));
            this.mapper   = dataMapper   ?? throw new ArgumentNullException(nameof(dataMapper));
        }

        /// <summary>
        /// Parses data of type TTarget that given in TInitial type form.
        /// </summary>
        public void Parse()
        {
            this.Logger?.Info("ParserService begun to work");

            string source = ConfigurationManager.AppSettings["source"];
            string destination = ConfigurationManager.AppSettings["destination"];

            IEnumerable<TSource> data = this.provider.ProvideData(source);

            IEnumerable<TTarget> parsedData = this.mapper.Map(data);

            this.consumer.Consume(parsedData, destination);

            this.Logger?.Info("ParserService stopped to work.");
        }
    }
}
namespace UriStringToXml.Console
{
    using System;
    using System.Collections.Generic;

    using UrlToXml.Interfaces;

    /// <summary>
    /// Converts passed data to.
    /// </summary>
    public class XmlDataConsumer : IDataConsumer<Url>
    {
        /// <summary>
        /// Lazy parser.
        /// </summary>
        private static readonly Lazy<XmlDataConsumer> LazyParser =
            new Lazy<XmlDataConsumer>(() => new XmlDataConsumer());

        /// <summary>
        /// Prevents a default instance of the <see cref="XmlDataConsumer"/> class from being created.
        /// </summary>
        private XmlDataConsumer()
        {
        }

        /// <summary>
        /// Singleton instance.
        /// </summary>
        public static XmlDataConsumer Instance => LazyParser.Value;

        public void Consume(IEnumerable<Url> data, string destination)
        {
            throw new NotImplementedException();
        }
    }
}
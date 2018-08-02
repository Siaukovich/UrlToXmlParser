namespace UrlToXml.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

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
        /// <param name="validator">
        /// Data validator.
        /// </param>
        /// <param name="parser">
        /// Data parser.
        /// </param>
        public void Parse(
            IDataProvider<TInitial> provider, 
            IDataConsumer<TTarget> consumer, 
            IGroupDataValidator<TInitial> validator, 
            IDataParser<TInitial, TTarget> parser)
        {
            string source = ConfigurationManager.AppSettings["source"];
            string destination = ConfigurationManager.AppSettings["destination"];

            IEnumerable<TInitial> data = provider.ProvideData(source);

            IEnumerable<TTarget> parsedData = ParseData(data, parser, validator);
            
            consumer.Consume(parsedData, destination);
        }

        private IEnumerable<TTarget> ParseData(IEnumerable<TInitial> data, IDataParser<TInitial, TTarget> parser, IGroupDataValidator<TInitial> groupValidator)
        {
            int elementNumber = 1;
            foreach (TInitial dataElement in data)
            {
                TTarget t;
                try
                {
                    t = parser.Parse(dataElement, groupValidator);
                }
                catch (ArgumentException ex)
                {
                    LoggerService.Instance.Logger.Warning($"Invalid data in line #{elementNumber}. {ex.Message}");
                    continue;
                }
                finally
                {
                    elementNumber++;
                }

                yield return t;
            }
        }
    }
}
namespace UriStringToXml.Console
{
    using System;
    using UrlToXml;
    using UrlToXml.Interfaces;

    class Program
    {
        static void Main(string[] args)
        {
            IDataProvider<string> provider = new FileDataProvider();
            IDataConsumer<Url> consumer = new XmlDataConsumer();

            IDataParser<string, Url> parser = new UrlDataParser();

            IGroupDataValidator<string> groupValidator = new UrlGroupValidator();
            groupValidator.AddValidator(new UrlSingleValidator());

            IMapper<string, Url> mapper = new StringToUrlMapper(parser, groupValidator);

            IParserSevice<string, Url> parserService = new ParserService<string, Url>();

            ILogger logger = NLogLogger.Instance;

            parserService.Parse(provider, consumer, mapper, logger);
        }
    }
}

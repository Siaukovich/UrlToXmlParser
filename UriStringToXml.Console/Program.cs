namespace UriStringToXml.Console
{
    using System;
    using UrlToXml;
    using UrlToXml.Interfaces;

    class Program
    {
        static void Main(string[] args)
        {
            IDataProvider<string> provider = FileDataProvider.Instance;
            IDataConsumer<Url> consumer = XmlDataConsumer.Instance;
            IDataParser<string, Url> parser = UrlDataParser.Instance;

            IGroupDataValidator<string> groupValidator = new UrlGroupValidator();
            groupValidator.AddValidator(new UrlSingleValidator());

            IParserSevice<string, Url> parserService = new ParserService<string, Url>();
            
            parserService.Parse(provider, consumer, groupValidator, parser);
        }
    }
}

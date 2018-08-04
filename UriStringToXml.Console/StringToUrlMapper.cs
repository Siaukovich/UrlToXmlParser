namespace UriStringToXml.Console
{
    using System;
    using System.Collections.Generic;

    using UrlToXml.Interfaces;

    /// <summary>
    /// Converts all valid .
    /// </summary>
    public class StringToUrlMapper : IMapper<string, Url>
    {
        public StringToUrlMapper(IDataParser<string, Url> parser, IGroupDataValidator<string> validator)
        {
            this.Parser = parser ?? throw new ArgumentNullException(nameof(parser));
            this.Validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        public IDataParser<string, Url> Parser { get; }

        public IGroupDataValidator<string> Validator { get; }

        public IEnumerable<Url> Map(IEnumerable<string> source, ILogger logger = null)
        {
            int lineCount = -1;
            int validLinesCounter = 0;
            foreach (string data in source)
            {
                lineCount++;

                (bool isValid, string errorMessage) validationResult = this.Validator.Validate(data);
                if (!validationResult.isValid)
                {
                    logger?.Warning($"Parsing error on line #{lineCount}: {validationResult.errorMessage}");
                    continue;
                }

                validLinesCounter++;
                yield return this.Parser.Parse(data);
            }

            logger?.Info($"Total parsed lines: {validLinesCounter}");
        }
    }
}
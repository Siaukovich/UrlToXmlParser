namespace UriStringToXml
{
    using System;
    using System.Collections.Generic;

    using DataConverter.Base;

    using Logger.Base;

    using Ninject;

    /// <summary>
    /// Converts all valid .
    /// </summary>
    public class StringToUrlMapper : IMapper<string, Url>
    {
        /// <summary>
        /// Injects dependencies.
        /// </summary>
        /// <param name="parser">
        /// The parser.
        /// </param>
        /// <param name="validator">
        /// The validator.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        [Inject]
        public void SetDependencies(IDataParser<string, Url> parser, IGroupDataValidator<string> validator, ILogger logger)
        {
            this.parser = parser ?? throw new ArgumentNullException(nameof(parser));
            this.validator = validator ?? throw new ArgumentNullException(nameof(validator));

            this.logger = logger;
        }

        /// <summary>
        /// Parses data.
        /// </summary>
        private IDataParser<string, Url> parser;

        /// <summary>
        /// Validates data.
        /// </summary>
        private IGroupDataValidator<string> validator;

        /// <summary>
        /// Logs events.
        /// </summary>
        private ILogger logger;

        public IEnumerable<Url> Map(IEnumerable<string> source)
        {
            int lineCount = -1;
            int validLinesCounter = 0;
            foreach (string data in source)
            {
                lineCount++;

                (bool isValid, string errorMessage) validationResult = this.validator.Validate(data);
                if (!validationResult.isValid)
                {
                    this.logger?.Warning($"Parsing error on line #{lineCount}: {validationResult.errorMessage}");
                    continue;
                }

                validLinesCounter++;
                yield return this.parser.Parse(data);
            }

            this.logger?.Info($"Total parsed lines: {validLinesCounter}");
        }
    }
}
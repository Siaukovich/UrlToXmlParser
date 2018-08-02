namespace UriStringToXml.Console
{
    using System;
    using System.Threading;

    using UrlToXml.Interfaces;

    /// <summary>
    /// Url data parser.
    /// </summary>
    public class UrlDataParser : IDataParser<string, Url>
    {
        /// <summary>
        /// Lazy parser.
        /// </summary>
        private static readonly Lazy<UrlDataParser> LazyParser =
            new Lazy<UrlDataParser>(() => new UrlDataParser());

        /// <summary>
        /// Prevents a default instance of the <see cref="UrlDataParser"/> class from being created.
        /// </summary>
        private UrlDataParser()
        {
        }

        /// <summary>
        /// Singleton instance.
        /// </summary>
        public static UrlDataParser Instance => LazyParser.Value;

        /// <summary>
        /// Parses from string to url.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <param name="groupValidator">
        /// Group of validators.
        /// </param>
        /// <returns>
        /// The <see cref="Url"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown if input has invalid format.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if input or groupValidator were null.
        /// </exception>
        public Url Parse(string input, IGroupDataValidator<string> groupValidator)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (groupValidator == null)
            {
                throw new ArgumentNullException(nameof(groupValidator));
            }

            foreach (ISingleDataValidator<string> validator in groupValidator.Validators)
            {
                (bool isValid, string errorMessage) result = validator.Validate(input);

                if (!result.isValid)
                {
                    throw new ArgumentException(result.errorMessage);
                }
            }

            return new Url(input);
        }
    }
}
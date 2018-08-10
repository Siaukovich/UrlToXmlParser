namespace UriStringToXml
{
    using System;
    using DataConverter.Base;

    /// <summary>
    /// Url data parser.
    /// </summary>
    public class UrlDataParser : IDataParser<string, Url>
    {
        /// <summary>
        /// Parses from string to url.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Url"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if input or groupValidator were null.
        /// </exception>
        public Url Parse(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            return new Url(input);
        }
    }
}
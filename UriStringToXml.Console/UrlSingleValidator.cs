namespace UriStringToXml.Console
{
    using System;

    using UrlToXml.Interfaces;

    /// <summary>
    /// Single validator for Url class.
    /// </summary>
    public class UrlSingleValidator : ISingleDataValidator<string>
    {
        /// <summary>
        /// The validate.
        /// </summary>
        /// <param name="uriString">
        /// The uri string.
        /// </param>
        /// <returns>
        /// The <see cref="(bool isValid, string errorMessage)"/>.
        /// </returns>
        public (bool isValid, string errorMessage) Validate(string uriString)
        {
            try
            {
                new Url(uriString);
                return (true, null);
            }
            catch (UriFormatException e)
            {
                return (false, e.Message);
            }
        }
    }
}
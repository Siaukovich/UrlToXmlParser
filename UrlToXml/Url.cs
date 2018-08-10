namespace UriStringToXml
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// URL class.
    /// </summary>
    public class Url
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Url"/> class.
        /// </summary>
        /// <param name="uriString">
        /// The uri string.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <see cref="uriString"/> is null.
        /// </exception>
        /// <exception cref="UriFormatException">
        /// Thrown if <see cref="uriString"/> have invalid format.
        /// </exception>
        public Url(string uriString)
        {
            if (uriString == null)
            {
                throw new ArgumentNullException(nameof(uriString));
            }

            var uri = new Uri(uriString);

            this.Scheme = uri.Scheme;
            this.Host = uri.Host;
            this.UrlPath = uri.AbsolutePath;

            if (uri.Query == string.Empty)
            {
                this.Parameters = new List<(string key, string value)>();
                return;
            }

            // Substring(1) to void first '?'.
            this.Parameters = uri.Query.Substring(1)
                                       .Split('&')
                                       .Select(SplitToPairs)
                                       .ToList();

            (string key, string value) SplitToPairs(string pair)
            {
                string[] parts = pair.Split('=');
                if (parts.Length != 2)
                {
                    throw new UriFormatException($"Parameters specified in {uriString} are not valid.");
                }

                return (parts[0], parts[1]);
            }
        }

        /// <summary>
        /// Gets scheme.
        /// </summary>
        public string Scheme { get; }

        /// <summary>
        /// Gets host.
        /// </summary>
        public string Host { get; }

        /// <summary>
        /// Gets path.
        /// </summary>
        public string UrlPath { get; }

        /// <summary>
        /// Gets parameters.
        /// </summary>
        public List<(string key, string value)> Parameters { get; }
    }
}
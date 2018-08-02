namespace UriStringToXml.Console
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
        /// List of parameters.
        /// </summary>
        private readonly List<(string key, string value)> parameters;

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

            // Substring(1) to void first '?'.
            this.parameters = uri.Query.Substring(1)
                                       .Split('$')
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
        public IEnumerable<(string key, string value)> Parameters => this.parameters.AsEnumerable();
    }
}
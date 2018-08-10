namespace UrlToXml
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using DataConverter.Base;

    /// <summary>
    /// Provides data from file.
    /// </summary>
    public class FileDataProvider : IDataProvider<string>
    {
        /// <summary>
        /// Provides data from given file.
        /// </summary>
        /// <param name="fileFullPath">
        /// Full path to data provider file.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <see cref="fileFullPath"/> is null.
        /// </exception>
        /// <exception cref="FileNotFoundException">
        /// Thrown if file with provided name does not exist.
        /// </exception>
        public IEnumerable<string> ProvideData(string fileFullPath)
        {
            if (fileFullPath == null)
            {
                throw new ArgumentNullException(nameof(fileFullPath));
            }

            if (!File.Exists(fileFullPath))
            {
                throw new FileNotFoundException($"File {fileFullPath} can not be found.", fileFullPath);
            }

            return InnerDataProvider();

            IEnumerable<string> InnerDataProvider()
            {
                using (var sr = new StreamReader(fileFullPath))
                {
                    while (true)
                    {
                        var line = sr.ReadLine();
                        if (line == null)
                        {
                            yield break;
                        }

                        yield return line;
                    }
                }
            }
        }
    }
}
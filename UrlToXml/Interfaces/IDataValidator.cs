namespace UrlToXml.Interfaces
{
    using System;

    /// <summary>
    /// Interface that every data validator class must implement.
    /// </summary>
    /// <typeparam name="T">
    /// Type of data.
    /// </typeparam>
    public interface IDataValidator<in T>
    {
        /// <summary>
        /// Validates data.
        /// </summary>
        /// <param name="data">
        /// Data to validate.
        /// </param>
        /// <returns>
        /// The <see cref="(bool isValid, string errorMessage)"/>.
        /// Bool value represents if data is valid and string contains 
        /// error message, or null if data is valid.
        /// </returns>
        (bool isValid, string errorMessage) Validate(T data);
    }
}
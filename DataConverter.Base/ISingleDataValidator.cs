namespace DataConverter.Base
{
    /// <summary>
    /// Interface that every single data validator must implement.
    /// </summary>
    /// <typeparam name="TData">
    /// Type of data.
    /// </typeparam>
    public interface ISingleDataValidator<in TData>
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
        (bool isValid, string errorMessage) Validate(TData data);
    }
}
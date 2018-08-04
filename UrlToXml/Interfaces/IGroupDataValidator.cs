namespace UrlToXml.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface that every group data validator class must implement.
    /// </summary>
    /// <typeparam name="TSource">
    /// Type of data.
    /// </typeparam>
    public interface IGroupDataValidator<TSource>
    {
        /// <summary>
        /// Gets the data validators.
        /// </summary>
        List<ISingleDataValidator<TSource>> Validators { get; }

        /// <summary>
        /// Adds validator.
        /// </summary>
        /// <param name="validator">
        /// New validator.
        /// </param>
        void AddValidator(ISingleDataValidator<TSource> validator);

        /// <summary>
        /// Validates all input using provided validators.
        /// </summary>
        /// <param name="value">
        /// Value that needs to be validated.
        /// </param>
        /// <returns>
        /// The <see cref="(bool isValid, string errorMessage)"/>.
        /// Bool value represents if data is valid and string contains 
        /// error message, or null if data is valid.
        /// </returns>
        (bool isValid, string errorMessage) Validate(TSource value);
    }
}
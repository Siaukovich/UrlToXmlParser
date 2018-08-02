namespace UrlToXml.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface that every group data validator class must implement.
    /// </summary>
    /// <typeparam name="T">
    /// Type of data.
    /// </typeparam>
    public interface IGroupDataValidator<T>
    {
        /// <summary>
        /// Gets the data validators.
        /// </summary>
        List<ISingleDataValidator<T>> Validators { get; }

        /// <summary>
        /// Adds validator.
        /// </summary>
        /// <param name="validator">
        /// New validator.
        /// </param>
        void AddValidator(ISingleDataValidator<T> validator);
    }
}
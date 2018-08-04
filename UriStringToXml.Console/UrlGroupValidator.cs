namespace UriStringToXml.Console
{
    using System.Collections.Generic;
    using System.Linq;

    using UrlToXml.Interfaces;

    /// <summary>
    /// The url group validator.
    /// </summary>
    public class UrlGroupValidator : IGroupDataValidator<string>
    {
        /// <summary>
        /// The validators list.
        /// </summary>
        private readonly List<ISingleDataValidator<string>> validators = new List<ISingleDataValidator<string>>();

        /// <summary>
        /// Gets the validators list.
        /// </summary>
        public List<ISingleDataValidator<string>> Validators => this.validators.ToList();

        /// <summary>
        /// Adds validator.
        /// </summary>
        /// <param name="validator">
        /// New validator.
        /// </param>
        public void AddValidator(ISingleDataValidator<string> validator) => this.validators.Add(validator);

        /// <summary>
        /// Validates data.
        /// </summary>
        /// <param name="value">
        /// Data to validate.
        /// </param>
        /// <returns>
        /// The <see cref="(bool isValid, string errorMessage)"/>.
        /// Bool value represents if data is valid and string contains 
        /// error message, or null if data is valid.
        /// </returns>
        public (bool isValid, string errorMessage) Validate(string value)
        {
            foreach (ISingleDataValidator<string> validator in this.validators)
            {
                (bool isValid, string errorMessage) validationResult = validator.Validate(value);
                if (!validationResult.isValid)
                {
                    return validationResult;
                }
            }

            return (true, null);
        }
    }
}
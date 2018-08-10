namespace UriStringToXml
{
    using System.Collections.Generic;
    using System.Linq;
    using DataConverter.Base;

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
        /// Initializes a new instance of the <see cref="UrlGroupValidator"/> class.
        /// </summary>
        /// <param name="validators">
        /// The validators.
        /// </param>
        public UrlGroupValidator(params ISingleDataValidator<string>[] validators)
        {
            this.validators.AddRange(validators);
        }

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
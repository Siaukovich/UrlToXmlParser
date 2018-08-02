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
    }
}
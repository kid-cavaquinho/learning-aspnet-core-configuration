using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WebApplication.Filters.Startup.Interfaces;

namespace WebApplication.Filters.Startup.Abstracts
{
    public abstract class DataAnnotationSettingValidation : IValidatable
    {
        /// <summary>
        /// Validates all properties of strongly typed objects with data annotation attributes
        /// </summary>
        /// <returns>A collection of validation results and a boolean representing sucess or not of the operation.</returns>
        public (IEnumerable<string> results, bool valid) Validate()
        {
            IList<ValidationResult> validationResults = new List<ValidationResult>();

            if (Validator.TryValidateObject(this, new ValidationContext(this, null, null), validationResults, validateAllProperties: true))
            {
                return (results: Enumerable.Empty<string>(), valid: true);
            }

            return (results: validationResults.Select(results => results.ErrorMessage), valid: false);
        }
    }
}

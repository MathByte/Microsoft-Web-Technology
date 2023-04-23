using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Registration.Models
{
    public class MinimumAgeAttribute : ValidationAttribute, IClientModelValidator
    {
        public MinimumAgeAttribute(int minAge)
        {
            _minAge = minAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // If value is a proper DateTome value, then we'll downcast to it
            // add _minAge years to the value and see if it's still less than
            // today - if so, then value is good, i.e. above min age.
            if (value is DateTime)
            {
                DateTime dateToCheck = (DateTime) value;

                // add minAge years:
                dateToCheck = dateToCheck.AddYears(_minAge);
                if (dateToCheck <= DateTime.Today)
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(GetMsg(validationContext.DisplayName));
        }
        public void AddValidation(ClientModelValidationContext context)
        {
            // Add the required "data-val-*" attributes:
            if (!context.Attributes.ContainsKey("data-val"))
                context.Attributes.Add("data-val", "true");

            context.Attributes.Add("data-val-minimumage-years", _minAge.ToString());
            context.Attributes.Add("data-val-minimumage", GetMsg(context.ModelMetadata.DisplayName ?? context.ModelMetadata.Name));
        }

        private string GetMsg(string propName) => base.ErrorMessage ?? $"{propName} must be at least {_minAge} years old.";

        private int _minAge;
    }
}

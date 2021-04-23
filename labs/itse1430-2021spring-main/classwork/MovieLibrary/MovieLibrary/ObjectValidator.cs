using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary
{
    /// <summary>Validates an object.</summary>
    public static class ObjectValidator
    {        
        public static List<ValidationResult> TryValidate ( IValidatableObject value )
        {
            var context = new ValidationContext(value);
            var errors = new List<ValidationResult>();

            Validator.TryValidateObject(value, context, errors, true);

            return errors;
        }

        public static void Validate ( IValidatableObject value )
        {
            var context = new ValidationContext(value);

            Validator.ValidateObject(value, context, true);
        }
    }
}

/*
 * Character Creator - Lab 5
 * ITSE 1430
 * Spring 2021
 * Stuart Beeby
 */

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CharacterCreator
{
    public class ObjectValidator
    {
        public static List<ValidationResult> TryValidate ( IValidatableObject value )
        {
            var context = new ValidationContext(value);
            var errors = new List<ValidationResult>();

            Validator.TryValidateObject(value, context, errors, true);

            return errors;
        }

        public static void Validate (IValidatableObject value)
        {
            var context = new ValidationContext(value);
            Validator.ValidateObject(value, context, true);
        }
    }
}

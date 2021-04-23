/*
 * Character Creator - Lab 4
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
        public List<ValidationResult> TryValidate ( IValidatableObject value )
        {
            var context = new ValidationContext(value);
            var errors = new List<ValidationResult>();

            Validator.TryValidateObject(value, context, errors, true);

            return errors;
        }
    }
}

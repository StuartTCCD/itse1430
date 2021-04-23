/*
 * Character Creator - Lab 4
 * ITSE 1430
 * Spring 2021
 * Stuart Beeby
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CharacterCreator
{
    public class Character : IValidatableObject
    {
        public const int MaxAttribute = 100;
        public const int MinAttribute = 1;
        private string _name;
        private string _biography;
        private string _race;
        private string _profession;


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Biography
        {
            get { return _biography; }
            set { _biography = value; }
        }

        public string Race
        {
            get { return _race; }
            set { _race = value; }
        }

        public string Profession
        {
            get { return _profession; }
            set { _profession = value; }
        }

        public int Id { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Agility { get; set; }
        public int Constitution { get; set; }
        public int Charisma { get; set; }

        private bool ValidateAttribute ( int value )
        {
            if (value <= MaxAttribute && value >= MinAttribute)
            {
                return true;
            }
            return false;
        }

        private bool ValidateRace ( string value )
        {
            string[] validRaces = new string[] { "Dwarf", "Elf", "Gnome", "Half Elf", "Human" };
            foreach (string race in validRaces)
            {
                if (String.Compare(value, race, true) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        private bool ValidateProfession ( string value )
        {
            string[] validProfessions = new string[] { "Fighter", "Hunter", "Priest", "Rogue", "Wizard" };
            foreach (string profession in validProfessions)
            {
                if (String.Compare(value, profession, true) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        {
            if (String.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Name is required");
            };
            if (!ValidateProfession(Profession))
            {
                yield return new ValidationResult("Valid profession is required");
            };
            if (!ValidateRace(Race))
            {
                yield return new ValidationResult("Valid race is required");
            };
            if (!ValidateAttribute(Strength))
            {
                yield return new ValidationResult($"Strength must be between {MinAttribute} and {MaxAttribute}");
            };
            if (!ValidateAttribute(Intelligence))
            {
                yield return new ValidationResult($"Intelligence must be between {MinAttribute} and {MaxAttribute}");
            };
            if (!ValidateAttribute(Agility))
            {
                yield return new ValidationResult($"Agility must be between {MinAttribute} and {MaxAttribute}");
            };
            if (!ValidateAttribute(Constitution))
            {
                yield return new ValidationResult($"Constitution must be between {MinAttribute} and {MaxAttribute}");
            };
            if (!ValidateAttribute(Charisma))
            {
                yield return new ValidationResult($"Charisma must be between {MinAttribute} and {MaxAttribute}");
            };
        }
    }
}

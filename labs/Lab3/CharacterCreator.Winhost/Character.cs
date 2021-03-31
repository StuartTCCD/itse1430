/*
 * Character Creator
 * ITSE 1430
 * Spring 2021
 * Stuart Beeby
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.Winhost
{
    public class Character
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

        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Agility { get; set; }
        public int Constitution { get; set; }
        public int Charisma { get; set; }

        public bool ValidateCharacter (out string errorMessage)
        {
            if (String.IsNullOrEmpty(Name))
            {
                errorMessage = "Name is required";
                return false;
            }
            if (Profession == null)
            {
                errorMessage = "Profession is required";
                return false;
            }
            if (!ValidateProfession(Profession))
            {
                errorMessage = "Select a valid Profession";
                return false;
            }
            if (!ValidateRace(Race))
            {
                errorMessage = "Select a valid Race";
                return false;
            }
            if (Race == null)
            {
                errorMessage = "Race is required";
                return false;
            }
            if (!ValidateAttribute(Strength))
            {
                errorMessage = $"Strength must be between {MinAttribute} and {MaxAttribute}";
                return false;
            }
            if (!ValidateAttribute(Intelligence))
            {
                errorMessage = $"Intelligence must be between {MinAttribute} and {MaxAttribute}";
                return false;
            }
            if (!ValidateAttribute(Agility))
            {
                errorMessage = $"Agility must be between {MinAttribute} and {MaxAttribute}";
                return false;
            }
            if (!ValidateAttribute(Constitution))
            {
                errorMessage = $"Constitution must be between {MinAttribute} and {MaxAttribute}";
                return false;
            }
            if (!ValidateAttribute(Charisma))
            {
                errorMessage = $"Charisma must be between {MinAttribute} and {MaxAttribute}";
                return false;
            }

            errorMessage = null;
            return true;
        }

        private bool ValidateAttribute ( int value )
        {
            return (value <= MaxAttribute) && (value <= MinAttribute);
        }

        private bool ValidateRace ( string value )
        {
            switch (value)
            {
                case "Dwarf": return true;
                case "Elf": return true;
                case "Gnome": return true;
                case "Half Elf": return true;
                case "Human": return true;
            }
            return false;
        }

        private bool ValidateProfession (string value)
        {
            switch (value)
            {
                case "Fighter": return true;
                case "Hunter": return true;
                case "Priest": return true;
                case "Rogue": return true;
                case "Wizard": return true;
            }
            return false;
        }
    }
}

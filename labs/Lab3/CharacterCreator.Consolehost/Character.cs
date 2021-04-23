using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.Consolehost
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

        public bool ValidateCharacter ( out string errorMessage )
        {
            if (String.IsNullOrEmpty(Name))
            {
                errorMessage = "Name is required";
                return false;
            }
            if (!ValidateProfession(Profession))
            {
                errorMessage = "Valid profession is required";
                return false;
            }
            if (!ValidateRace(Race))
            {
                errorMessage = "Valid race is required";
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
    }
}

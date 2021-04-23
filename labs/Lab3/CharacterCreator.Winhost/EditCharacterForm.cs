using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterCreator.Consolehost;

namespace CharacterCreator.Winhost
{
    public partial class EditCharacterForm : Form
    {
        public Character ReturnCharacter { get; set; }

        public int ReturnIndex { get; set; }

        public Character _theCharacter { get; private set; }


        private int _listPosition;

        public EditCharacterForm (Character theCharacter, int listPosition)
        {
            _theCharacter = theCharacter;
            _listPosition = listPosition;
            InitializeComponent();
        }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);
            tbName.Text = _theCharacter.Name;
            tbStrength.Text = _theCharacter.Strength.ToString();
            tbIntelligence.Text = _theCharacter.Intelligence.ToString();
            tbAgility.Text = _theCharacter.Agility.ToString();
            tbConstitution.Text = _theCharacter.Constitution.ToString();
            tbCharisma.Text = _theCharacter.Charisma.ToString();
            tbBiography.Text = _theCharacter.Biography;
            switch(_theCharacter.Profession)
            {
                case "Fighter": cbProfession.SelectedIndex = 0; break;
                case "Hunter": cbProfession.SelectedIndex = 1; break;
                case "Priest": cbProfession.SelectedIndex = 2; break;
                case "Rogue": cbProfession.SelectedIndex = 3; break;
                case "Wizard": cbProfession.SelectedIndex = 4; break;
            }
            switch(_theCharacter.Race)
            {
                case "Dwarf": cbRace.SelectedIndex = 0; break;
                case "Elf": cbRace.SelectedIndex = 1; break;
                case "Gnome": cbRace.SelectedIndex = 2; break;
                case "Half Elf": cbRace.SelectedIndex = 3; break;
                case "Human": cbRace.SelectedIndex = 4; break;
            }
        }

        private void OnSave ( object sender, EventArgs e )
        {
            bool isComplete = true;
            bool isValidStrength, isValidIntelligence, isValidAgility, isValidConstitution, isValidCharisma;
            int validStrength, validIntelligence, validAgility, validConstitution, validCharisma;
            string errorMessage = "Please make sure these fields are not blank.";
            if (tbName.Text.Length == 0)
            {
                isComplete = false;
                errorMessage += "\nName";
            }

            if (cbProfession.SelectedIndex < 0)
            {
                isComplete = false;
                errorMessage += "\nProfession";
            }

            if (cbRace.SelectedIndex < 0)
            {
                isComplete = false;
                errorMessage += "\nRace";
            }

            if (tbStrength.Text.Length == 0)
            {
                isComplete = false;
                errorMessage += "\nStrength";
            }

            if (tbIntelligence.Text.Length == 0)
            {
                isComplete = false;
                errorMessage += "\nIntelligence";
            }

            if (tbAgility.Text.Length == 0)
            {
                isComplete = false;
                errorMessage += "\nAgility";
            }

            if (tbConstitution.Text.Length == 0)
            {
                isComplete = false;
                errorMessage += "\nConstitution";
            }

            if (tbCharisma.Text.Length == 0)
            {
                isComplete = false;
                errorMessage += "\nCharisma";
            }

            if (!isComplete)
            {
                var error = MessageBox.Show(this, errorMessage);
                return;
            }

            ReturnCharacter = new Character();
            ReturnCharacter.Name = tbName.Text;
            isValidStrength = Int32.TryParse(tbStrength.Text, out validStrength);
            if (isValidStrength) { ReturnCharacter.Strength = validStrength; }
            isValidIntelligence = Int32.TryParse(tbIntelligence.Text, out validIntelligence);
            if (isValidIntelligence) { ReturnCharacter.Intelligence = validIntelligence; }
            isValidAgility = Int32.TryParse(tbAgility.Text, out validAgility);
            if (isValidAgility) { ReturnCharacter.Agility = validAgility; }
            isValidConstitution = Int32.TryParse(tbConstitution.Text, out validConstitution);
            if (isValidConstitution) { ReturnCharacter.Constitution = validConstitution; }
            isValidCharisma = Int32.TryParse(tbCharisma.Text, out validCharisma);
            if (isValidCharisma) { ReturnCharacter.Charisma = validCharisma; }
            ReturnCharacter.Race = cbRace.Text;
            ReturnCharacter.Profession = cbProfession.Text;
            if (tbBiography.Text.Length > 0)
            {
                ReturnCharacter.Biography = tbBiography.Text;
            }
            DialogResult = DialogResult.OK;
            ReturnIndex = _listPosition;
        }
        private void OntbStrengthUpdate ( object sender, EventArgs e )
        {
            AttributeChecker(tbStrength.Text, "strength");
        }

        private void OntbIntelligenceUpdate ( object sender, EventArgs e )
        {
            AttributeChecker(tbIntelligence.Text, "intelligence");
        }

        private void OntbAgilityUpdate ( object sender, EventArgs e )
        {
            AttributeChecker(tbAgility.Text, "agility");
        }

        private void AttributeChecker ( string userInput, string attribute )
        {
            int input;
            bool result;
            result = Int32.TryParse(userInput, out input);
            if (userInput == "")
            {
                return;
            }
            if (!result)
            {
                var errorMessage = MessageBox.Show(this, "You can only enter numbers into this field");
                switch (attribute)
                {
                    case "strength": tbStrength.Text = ""; return;
                    case "intelligence": tbIntelligence.Text = ""; return;
                    case "agility": tbAgility.Text = ""; return;
                    case "constitution": tbConstitution.Text = ""; return;
                    case "charisma": tbCharisma.Text = ""; return;
                }
                result=true;
            }
            if (input < 1 || input > 100)
            {
                var errorMessage = MessageBox.Show(this, "Attributes must be between 0 and 100");
                switch (attribute)
                {
                    case "strength": tbStrength.Text = ""; break;
                    case "intelligence": tbIntelligence.Text = ""; break;
                    case "agility": tbAgility.Text = ""; break;
                    case "constitution": tbConstitution.Text = ""; break;
                    case "charisma": tbCharisma.Text = ""; break;
                }
                result = true;
            }
        }

        private void OnBack ( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

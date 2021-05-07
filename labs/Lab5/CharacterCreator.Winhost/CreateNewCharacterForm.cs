/*
 * Character Creator - Lab 5
 * ITSE 1430
 * Spring 2021
 * Stuart Beeby
 */

using System;
using System.Windows.Forms;

namespace CharacterCreator.Winhost
{
    public partial class CreateNewCharacterForm : Form
    {
        public Character ReturnCharacter { get; set; }


        public CreateNewCharacterForm ()
        {
            InitializeComponent();
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
                MessageBox.Show(this, errorMessage);
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
            if (isValidConstitution) { ReturnCharacter.Constitution = validConstitution ; }
            isValidCharisma = Int32.TryParse(tbCharisma.Text, out validCharisma);
            if (isValidCharisma) { ReturnCharacter.Charisma = validCharisma; }
            ReturnCharacter.Race = cbRace.Text;
            ReturnCharacter.Profession = cbProfession.Text;
            if (tbBiography.Text.Length > 0)
            {
                ReturnCharacter.Biography = tbBiography.Text;
            }
            DialogResult = DialogResult.OK;
        }

        private void OntbStrengthUpdate ( object sender, EventArgs e )
        {
            AttributeChecker(tbStrength.Text, "strength");
        }

        private void OnIntelligenceUpdate ( object sender, EventArgs e )
        {
            AttributeChecker(tbIntelligence.Text, "intelligence");
        }
        private void OnAgilityUpdate ( object sender, EventArgs e )
        {
            AttributeChecker(tbAgility.Text, "agility");
        }

        private void OnConstitutionUpdate ( object sender, EventArgs e )
        {
            AttributeChecker(tbConstitution.Text, "constitution");
        }

        private void OnCharismaUpdate ( object sender, EventArgs e )
        {
            AttributeChecker(tbCharisma.Text, "charisma");
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

        private void OnClose ( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

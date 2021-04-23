using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterCreator.Winhost
{
    public partial class CreateNewCharacterForm : Form
    {
        public Character returnCharacter { get; private set; }

        private MainForm _mainForm;

        public CreateNewCharacterForm (MainForm main)
        {
            _mainForm = main;
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

            returnCharacter = new Character();
            returnCharacter.Name = tbName.Text;
            isValidStrength = Int32.TryParse(tbStrength.Text, out validStrength);
            if (isValidStrength) { returnCharacter.Strength = validStrength; }
            isValidIntelligence = Int32.TryParse(tbIntelligence.Text, out validIntelligence);
            if (isValidIntelligence) { returnCharacter.Intelligence = validIntelligence; }
            isValidAgility = Int32.TryParse(tbAgility.Text, out validAgility);
            if (isValidAgility) { returnCharacter.Agility = validAgility; }
            isValidConstitution = Int32.TryParse(tbConstitution.Text, out validConstitution);
            if (isValidConstitution) { returnCharacter.Constitution = validConstitution ; }
            isValidCharisma = Int32.TryParse(tbCharisma.Text, out validCharisma);
            if (isValidCharisma) { returnCharacter.Charisma = validCharisma; }
            returnCharacter.Race = cbRace.Text;
            returnCharacter.Profession = cbProfession.Text;
            if (tbBiography.Text.Length > 0)
            {
                returnCharacter.Biography = tbBiography.Text;
            }
            _mainForm.AddCharacter(returnCharacter);
            Close();
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
            if (userInput == "")
            {
                result = true;
            }
            result = Int32.TryParse(userInput, out input);
            if (!result)
            {
                var errorMessage = MessageBox.Show(this, "You can only enter numbers into this field");
                switch(attribute)
                {
                    case "strength": tbStrength.Text = ""; break;
                    case "intelligence": tbIntelligence.Text = ""; break;
                    case "agility": tbAgility.Text = ""; break;
                    case "constitution": tbConstitution.Text = ""; break;
                    case "charisma": tbCharisma.Text = ""; break;
                }
                result=true;
            }
            if (result)
            {
                if (input <= 1 || input >= 100)
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
        }

        private void OnClose ( object sender, EventArgs e )
        {
            Close();
        }
    }
}

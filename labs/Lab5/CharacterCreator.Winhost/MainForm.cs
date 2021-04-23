using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterCreator;

namespace CharacterCreator.Winhost
{
    public partial class MainForm : Form
    {
        private readonly ICharacterRoster _roster = new MemoryCharacterRoster();

        protected override void OnLoad ( EventArgs e )
        {
            var character = _roster.GetAll();
            if (character.Count() == 0)
            {
                if (MessageBox.Show(this, "Do you want to seed this database?", "Seed Database", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var seed = new SeedDatabase();
                    seed.Seed(_roster);
                }
            }
            UpdatelbCharacters();
        }

        public MainForm()
        {
            InitializeComponent();
        }

        public int CharacterID ()
        {
            int index = lbCharacters.Items.Count;
            return index;
        }

        public void AddCharacter ( Character theCharacter )
        {
            _roster.Add(theCharacter, out var error);
            if (!String.IsNullOrEmpty(error))
            {
                DisplayError("Add Failed", error);
            }
            UpdatelbCharacters();
        }

        public void EditCharacter ( Character theCharacter, int id )
        {
            _roster.Update(id, theCharacter, out var error);
            if (!String.IsNullOrEmpty(error))
            {
                DisplayError("Update Failed", error);
            }
            UpdatelbCharacters();
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var form = new AboutBox();

            form.ShowDialog();
        }

        private void OnFileExit ( object sender, EventArgs e )
        {
            var result = MessageBox.Show(this, "Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }
            Close();
        }

        private void OnCharacterNew ( object sender, EventArgs e )
        {
            CreateNewCharacterForm characterCreator = new CreateNewCharacterForm();
            characterCreator.StartPosition = FormStartPosition.CenterParent;
            DialogResult dr = characterCreator.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                characterCreator.Close();
            }
            else // dr == DialogResult.OK
            {
                AddCharacter(characterCreator.ReturnCharacter);
                characterCreator.Close();
            }
        }

        private void OnCharacterEdit ( object sender, EventArgs e )
        {
            if (lbCharacters.SelectedIndex == -1)
            {
                MessageBox.Show(this, "Please select a character first");
                return;
            }
            var theCharacter = GetSelectedCharacter();
            if (theCharacter == null)
            {
                return;
            }
            EditCharacterForm characterEditor = new EditCharacterForm(theCharacter);
            characterEditor.StartPosition = FormStartPosition.CenterParent;
            DialogResult dr = characterEditor.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                characterEditor.Close();
            } else // dr == DialogResult.OK
            {
                EditCharacter(characterEditor.ReturnCharacter, theCharacter.Id);
                characterEditor.Close();
            }
        }

        private void OnCharacterDelete ( object sender, EventArgs e )
        {
            if (lbCharacters.SelectedIndex == -1)
            {
                MessageBox.Show(this, "Please select a character first");
                return;
            }
            var theCharacter = GetSelectedCharacter();
            if (theCharacter == null)
            {
                return;
            }
            DialogResult result = MessageBox.Show($"Are you sure you want to delete {theCharacter.Name}?", "Delete Character", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                _roster.Delete(theCharacter.Id, out var error);
                UpdatelbCharacters();
            }
        }

        private void UpdatelbCharacters ()
        {
            var characters = _roster.GetAll();

            //lbCharacters.DataSource = characters;
            lbCharacters.DataSource = characters.ToArray();
            lbCharacters.DisplayMember = "Name";
        }

        private Character GetSelectedCharacter ()
        {
            return lbCharacters.SelectedItem as Character;
        }

        private void DisplayError (string title, string message)
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

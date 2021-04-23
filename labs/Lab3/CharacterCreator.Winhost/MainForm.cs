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
using CharacterCreator.Consolehost;

namespace CharacterCreator.Winhost
{
    public partial class MainForm : Form
    {
        List<Character> _characters = new List<Character>();

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
            _characters.Add(theCharacter);
            lbCharacters.Items.Add(theCharacter.Name);
        }

        public void EditCharacter ( Character theCharacter, int index )
        {
            _characters[index] = theCharacter;
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
            EditCharacterForm characterEditor = new EditCharacterForm(_characters[lbCharacters.SelectedIndex], lbCharacters.SelectedIndex);
            characterEditor.StartPosition = FormStartPosition.CenterParent;
            DialogResult dr = characterEditor.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                characterEditor.Close();
            } else // dr == DialogResult.OK
            {
                EditCharacter(characterEditor.ReturnCharacter, characterEditor.ReturnIndex);
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
            DialogResult result = MessageBox.Show($"Are you sure you want to delete {lbCharacters.SelectedItem}?", "Delete Character", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                _characters.RemoveAt(lbCharacters.SelectedIndex);
                UpdatelbCharacters();
            }
        }

        private void UpdatelbCharacters ()
        {
            lbCharacters.Items.Clear();
            foreach (Character ch in _characters)
            {
                lbCharacters.Items.Add(ch.Name);
            }
        }
    }
}

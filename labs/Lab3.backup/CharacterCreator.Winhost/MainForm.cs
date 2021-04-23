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
            Form characterCreator = new CreateNewCharacterForm(this);
            characterCreator.StartPosition = FormStartPosition.CenterParent;
            characterCreator.ShowDialog(this);
        }

        private void OnCharacterEdit ( object sender, EventArgs e )
        {
            if (lbCharacters.SelectedIndex == -1)
            {
                MessageBox.Show(this, "Please select a character first");
                return;
            }
            Form characterEditor = new EditCharacterForm(this, _characters[lbCharacters.SelectedIndex], lbCharacters.SelectedIndex);
            characterEditor.StartPosition = FormStartPosition.CenterParent;
            characterEditor.ShowDialog(this);
        }

        private void OnCharacterDelete ( object sender, EventArgs e )
        {
            if (lbCharacters.SelectedIndex == -1)
            {
                MessageBox.Show(this, "Please select a character first");
                return;
            }

            _characters.RemoveAt(lbCharacters.SelectedIndex);
            UpdatelbCharacters();
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

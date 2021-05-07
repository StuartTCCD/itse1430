/*
 * Character Creator - Lab 5
 * ITSE 1430
 * Spring 2021
 * Stuart Beeby
 */

using System;
using System.Linq;
using System.Windows.Forms;

namespace CharacterCreator.Winhost
{
    public partial class MainForm : Form
    {
        private readonly ICharacterRoster _roster = new SqlServer.SqlServerCharacterDatabase(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=CharacterDb;Integrated Security=True;");

        protected override void OnLoad ( EventArgs e )
        {
            var character = _roster.GetAll();
            if (character.Count() == 0)
            {
                if (MessageBox.Show(this, "Do you want to seed this database?", "Seed Database", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _roster.Seed();
                }
            }
            UpdatelbCharacters();
        }

        public MainForm()
        {
            InitializeComponent();
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
            do
            {
                CreateNewCharacterForm characterCreator = new CreateNewCharacterForm();
                characterCreator.StartPosition = FormStartPosition.CenterParent;
                DialogResult dr = characterCreator.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    characterCreator.Close();
                    break;
                } else // dr == DialogResult.OK
                {
                    try
                    {
                        _roster.Add(characterCreator.ReturnCharacter);
                    }
                    catch(Exception ex)
                    {
                        DisplayError("Add failed", ex.Message);
                    }
                        UpdatelbCharacters();
                        characterCreator.Close();
                        break;
                }
            } while (true);
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
            do
            {
                EditCharacterForm characterEditor = new EditCharacterForm(theCharacter);
                characterEditor.StartPosition = FormStartPosition.CenterParent;
                DialogResult dr = characterEditor.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    characterEditor.Close();
                    break;
                } else // dr == DialogResult.OK
                {
                    try
                    {
                        _roster.Update(theCharacter.Id, characterEditor.ReturnCharacter);
                    }
                    catch (Exception ex)
                    {
                        DisplayError("Edit Failed", ex.Message);
                    }
                    UpdatelbCharacters();
                    characterEditor.Close();
                    break;
                }
            } while (true);
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
                try
                {
                    _roster.Delete(theCharacter.Id);
                }
                catch (Exception ex)
                {
                    DisplayError("Delete Failed", ex.Message);
                }
                UpdatelbCharacters();
            }
        }

        private void UpdatelbCharacters ()
        {
            try
            {
                var characters = _roster.GetAll();
                lbCharacters.DataSource = characters.ToArray();
                lbCharacters.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                DisplayError("Error retrieving characters", ex.Message);
            }
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

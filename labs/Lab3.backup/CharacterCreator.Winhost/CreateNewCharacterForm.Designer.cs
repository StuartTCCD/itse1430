
namespace CharacterCreator.Winhost
{
    partial class CreateNewCharacterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbBiography = new System.Windows.Forms.TextBox();
            this.cbProfession = new System.Windows.Forms.ComboBox();
            this.cbRace = new System.Windows.Forms.ComboBox();
            this.tbStrength = new System.Windows.Forms.TextBox();
            this.tbIntelligence = new System.Windows.Forms.TextBox();
            this.tbAgility = new System.Windows.Forms.TextBox();
            this.tbConstitution = new System.Windows.Forms.TextBox();
            this.tbCharisma = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(80, 12);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(100, 23);
            this.tbName.TabIndex = 0;
            // 
            // tbBiography
            // 
            this.tbBiography.Location = new System.Drawing.Point(207, 27);
            this.tbBiography.Multiline = true;
            this.tbBiography.Name = "tbBiography";
            this.tbBiography.Size = new System.Drawing.Size(158, 211);
            this.tbBiography.TabIndex = 8;
            // 
            // cbProfession
            // 
            this.cbProfession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProfession.FormattingEnabled = true;
            this.cbProfession.Items.AddRange(new object[] {
            "Fighter",
            "Hunter",
            "Priest",
            "Rogue",
            "Wizard"});
            this.cbProfession.Location = new System.Drawing.Point(80, 41);
            this.cbProfession.Name = "cbProfession";
            this.cbProfession.Size = new System.Drawing.Size(121, 23);
            this.cbProfession.TabIndex = 1;
            // 
            // cbRace
            // 
            this.cbRace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRace.FormattingEnabled = true;
            this.cbRace.Items.AddRange(new object[] {
            "Dwarf",
            "Elf",
            "Gnome",
            "Half Elf",
            "Human"});
            this.cbRace.Location = new System.Drawing.Point(80, 70);
            this.cbRace.Name = "cbRace";
            this.cbRace.Size = new System.Drawing.Size(121, 23);
            this.cbRace.TabIndex = 2;
            // 
            // tbStrength
            // 
            this.tbStrength.Location = new System.Drawing.Point(80, 99);
            this.tbStrength.Name = "tbStrength";
            this.tbStrength.Size = new System.Drawing.Size(100, 23);
            this.tbStrength.TabIndex = 3;
            this.tbStrength.TextChanged += new System.EventHandler(this.OntbStrengthUpdate);
            // 
            // tbIntelligence
            // 
            this.tbIntelligence.Location = new System.Drawing.Point(80, 128);
            this.tbIntelligence.Name = "tbIntelligence";
            this.tbIntelligence.Size = new System.Drawing.Size(100, 23);
            this.tbIntelligence.TabIndex = 4;
            this.tbIntelligence.TextChanged += new System.EventHandler(this.OnIntelligenceUpdate);
            // 
            // tbAgility
            // 
            this.tbAgility.Location = new System.Drawing.Point(80, 157);
            this.tbAgility.Name = "tbAgility";
            this.tbAgility.Size = new System.Drawing.Size(100, 23);
            this.tbAgility.TabIndex = 5;
            this.tbAgility.TextChanged += new System.EventHandler(this.OnAgilityUpdate);
            // 
            // tbConstitution
            // 
            this.tbConstitution.Location = new System.Drawing.Point(80, 186);
            this.tbConstitution.Name = "tbConstitution";
            this.tbConstitution.Size = new System.Drawing.Size(100, 23);
            this.tbConstitution.TabIndex = 6;
            this.tbConstitution.TextChanged += new System.EventHandler(this.OnConstitutionUpdate);
            // 
            // tbCharisma
            // 
            this.tbCharisma.Location = new System.Drawing.Point(80, 215);
            this.tbCharisma.Name = "tbCharisma";
            this.tbCharisma.Size = new System.Drawing.Size(100, 23);
            this.tbCharisma.TabIndex = 7;
            this.tbCharisma.TextChanged += new System.EventHandler(this.OnCharismaUpdate);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Profession";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Race";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Strength";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Intelligence";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "Agility";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "Constitution";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 223);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "Charisma";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(255, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 15);
            this.label9.TabIndex = 17;
            this.label9.Text = "Biography";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 254);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.OnSave);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(290, 254);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.OnClose);
            // 
            // CreateNewCharacter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 281);
            this.ControlBox = false;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCharisma);
            this.Controls.Add(this.tbConstitution);
            this.Controls.Add(this.tbAgility);
            this.Controls.Add(this.tbIntelligence);
            this.Controls.Add(this.tbStrength);
            this.Controls.Add(this.cbRace);
            this.Controls.Add(this.cbProfession);
            this.Controls.Add(this.tbBiography);
            this.Controls.Add(this.tbName);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateNewCharacter";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create New Character";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbBiography;
        private System.Windows.Forms.ComboBox cbProfession;
        private System.Windows.Forms.ComboBox cbRace;
        private System.Windows.Forms.TextBox tbStrength;
        private System.Windows.Forms.TextBox tbIntelligence;
        private System.Windows.Forms.TextBox tbAgility;
        private System.Windows.Forms.TextBox tbConstitution;
        private System.Windows.Forms.TextBox tbCharisma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBack;
    }
}
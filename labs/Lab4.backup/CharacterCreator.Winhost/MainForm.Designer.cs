
namespace CharacterCreator.Winhost
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.miCharacter = new System.Windows.Forms.ToolStripMenuItem();
            this.miCharacterNew = new System.Windows.Forms.ToolStripMenuItem();
            this.miCharacterEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.miCharacterDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.miHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.lbCharacters = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.miCharacter,
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFileExit});
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(37, 20);
            this.miFile.Text = "&File";
            // 
            // miFileExit
            // 
            this.miFileExit.Name = "miFileExit";
            this.miFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.miFileExit.Size = new System.Drawing.Size(135, 22);
            this.miFileExit.Text = "Exit";
            this.miFileExit.Click += new System.EventHandler(this.OnFileExit);
            // 
            // miCharacter
            // 
            this.miCharacter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCharacterNew,
            this.miCharacterEdit,
            this.miCharacterDelete});
            this.miCharacter.Name = "miCharacter";
            this.miCharacter.Size = new System.Drawing.Size(70, 20);
            this.miCharacter.Text = "Character";
            // 
            // miCharacterNew
            // 
            this.miCharacterNew.Name = "miCharacterNew";
            this.miCharacterNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.miCharacterNew.Size = new System.Drawing.Size(141, 22);
            this.miCharacterNew.Text = "New";
            this.miCharacterNew.Click += new System.EventHandler(this.OnCharacterNew);
            // 
            // miCharacterEdit
            // 
            this.miCharacterEdit.Name = "miCharacterEdit";
            this.miCharacterEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.miCharacterEdit.Size = new System.Drawing.Size(141, 22);
            this.miCharacterEdit.Text = "Edit";
            this.miCharacterEdit.Click += new System.EventHandler(this.OnCharacterEdit);
            // 
            // miCharacterDelete
            // 
            this.miCharacterDelete.Name = "miCharacterDelete";
            this.miCharacterDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.miCharacterDelete.Size = new System.Drawing.Size(141, 22);
            this.miCharacterDelete.Text = "Delete";
            this.miCharacterDelete.Click += new System.EventHandler(this.OnCharacterDelete);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miHelpAbout});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItem2.Text = "&Help";
            // 
            // miHelpAbout
            // 
            this.miHelpAbout.Name = "miHelpAbout";
            this.miHelpAbout.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.miHelpAbout.Size = new System.Drawing.Size(126, 22);
            this.miHelpAbout.Text = "About";
            this.miHelpAbout.Click += new System.EventHandler(this.OnHelpAbout);
            // 
            // lbCharacters
            // 
            this.lbCharacters.FormattingEnabled = true;
            this.lbCharacters.ItemHeight = 15;
            this.lbCharacters.Location = new System.Drawing.Point(12, 27);
            this.lbCharacters.Name = "lbCharacters";
            this.lbCharacters.Size = new System.Drawing.Size(260, 379);
            this.lbCharacters.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 411);
            this.Controls.Add(this.lbCharacters);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(260, 420);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Character Creator";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miFileExit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem miHelpAbout;
        private System.Windows.Forms.ToolStripMenuItem miCharacter;
        private System.Windows.Forms.ToolStripMenuItem miCharacterNew;
        private System.Windows.Forms.ToolStripMenuItem miCharacterEdit;
        private System.Windows.Forms.ToolStripMenuItem miCharacterDelete;
        private System.Windows.Forms.ListBox lbCharacters;
    }
}


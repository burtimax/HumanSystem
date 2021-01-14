namespace DiaryWinFormsNetFramework.Plugins.SettingsForm
{
    partial class NoteFormView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BodyPanel = new System.Windows.Forms.Panel();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.RightPartPanel = new System.Windows.Forms.Panel();
            this.TextPanel = new System.Windows.Forms.Panel();
            this.NoteTextContainer = new DiaryWinFormsNetFramework.UserControls.TextContainer();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.TabFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnNewNote = new Bunifu.Framework.UI.BunifuImageButton();
            this.LeftPartPanel = new System.Windows.Forms.Panel();
            this.CategoriesPanelWithFilesList = new System.Windows.Forms.Panel();
            this.FilesPanel = new System.Windows.Forms.Panel();
            this.FilesListBox = new System.Windows.Forms.ListBox();
            this.FoldersTreeViewForShowNotes = new System.Windows.Forms.TreeView();
            this.CategoriesPanel = new System.Windows.Forms.Panel();
            this.FoldersTreeView = new System.Windows.Forms.TreeView();
            this.BodyPanel.SuspendLayout();
            this.ContentPanel.SuspendLayout();
            this.RightPartPanel.SuspendLayout();
            this.TextPanel.SuspendLayout();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnNewNote)).BeginInit();
            this.LeftPartPanel.SuspendLayout();
            this.CategoriesPanelWithFilesList.SuspendLayout();
            this.FilesPanel.SuspendLayout();
            this.CategoriesPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BodyPanel
            // 
            this.BodyPanel.Controls.Add(this.ContentPanel);
            this.BodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BodyPanel.Location = new System.Drawing.Point(0, 0);
            this.BodyPanel.Name = "BodyPanel";
            this.BodyPanel.Size = new System.Drawing.Size(1118, 690);
            this.BodyPanel.TabIndex = 0;
            // 
            // ContentPanel
            // 
            this.ContentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ContentPanel.Controls.Add(this.RightPartPanel);
            this.ContentPanel.Controls.Add(this.LeftPartPanel);
            this.ContentPanel.Location = new System.Drawing.Point(28, 23);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(1062, 643);
            this.ContentPanel.TabIndex = 4;
            // 
            // RightPartPanel
            // 
            this.RightPartPanel.Controls.Add(this.TextPanel);
            this.RightPartPanel.Controls.Add(this.TopPanel);
            this.RightPartPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightPartPanel.Location = new System.Drawing.Point(276, 0);
            this.RightPartPanel.Name = "RightPartPanel";
            this.RightPartPanel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.RightPartPanel.Size = new System.Drawing.Size(786, 643);
            this.RightPartPanel.TabIndex = 1;
            // 
            // TextPanel
            // 
            this.TextPanel.Controls.Add(this.NoteTextContainer);
            this.TextPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextPanel.Location = new System.Drawing.Point(10, 0);
            this.TextPanel.Name = "TextPanel";
            this.TextPanel.Size = new System.Drawing.Size(776, 643);
            this.TextPanel.TabIndex = 1;
            // 
            // NoteTextContainer
            // 
            this.NoteTextContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NoteTextContainer.BackColor = System.Drawing.Color.White;
            this.NoteTextContainer.ColorBorder = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.NoteTextContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NoteTextContainer.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoteTextContainer.Location = new System.Drawing.Point(0, 0);
            this.NoteTextContainer.Margin = new System.Windows.Forms.Padding(0);
            this.NoteTextContainer.Name = "NoteTextContainer";
            this.NoteTextContainer.Size = new System.Drawing.Size(776, 643);
            this.NoteTextContainer.TabIndex = 0;
            this.NoteTextContainer.Title = "Note";
            this.NoteTextContainer.TitleReadOnly = false;
            // 
            // TopPanel
            // 
            this.TopPanel.AutoSize = true;
            this.TopPanel.Controls.Add(this.TabFlowPanel);
            this.TopPanel.Controls.Add(this.BtnNewNote);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(10, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(776, 0);
            this.TopPanel.TabIndex = 1;
            // 
            // TabFlowPanel
            // 
            this.TabFlowPanel.AutoSize = true;
            this.TabFlowPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TabFlowPanel.Location = new System.Drawing.Point(29, 0);
            this.TabFlowPanel.Name = "TabFlowPanel";
            this.TabFlowPanel.Size = new System.Drawing.Size(747, 0);
            this.TabFlowPanel.TabIndex = 6;
            this.TabFlowPanel.WrapContents = false;
            // 
            // BtnNewNote
            // 
            this.BtnNewNote.BackColor = System.Drawing.Color.Transparent;
            this.BtnNewNote.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnNewNote.Image = global::DiaryWinFormsNetFramework.Properties.Resources.AddButton;
            this.BtnNewNote.ImageActive = null;
            this.BtnNewNote.InitialImage = global::DiaryWinFormsNetFramework.Properties.Resources.AddButton;
            this.BtnNewNote.Location = new System.Drawing.Point(0, 0);
            this.BtnNewNote.Name = "BtnNewNote";
            this.BtnNewNote.Size = new System.Drawing.Size(29, 0);
            this.BtnNewNote.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnNewNote.TabIndex = 2;
            this.BtnNewNote.TabStop = false;
            this.BtnNewNote.Zoom = 0;
            this.BtnNewNote.Click += new System.EventHandler(this.BtnNewNote_Click);
            // 
            // LeftPartPanel
            // 
            this.LeftPartPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LeftPartPanel.Controls.Add(this.CategoriesPanelWithFilesList);
            this.LeftPartPanel.Controls.Add(this.CategoriesPanel);
            this.LeftPartPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPartPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftPartPanel.Name = "LeftPartPanel";
            this.LeftPartPanel.Size = new System.Drawing.Size(276, 643);
            this.LeftPartPanel.TabIndex = 0;
            // 
            // CategoriesPanelWithFilesList
            // 
            this.CategoriesPanelWithFilesList.Controls.Add(this.FilesPanel);
            this.CategoriesPanelWithFilesList.Controls.Add(this.FoldersTreeViewForShowNotes);
            this.CategoriesPanelWithFilesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CategoriesPanelWithFilesList.Location = new System.Drawing.Point(0, 0);
            this.CategoriesPanelWithFilesList.Name = "CategoriesPanelWithFilesList";
            this.CategoriesPanelWithFilesList.Size = new System.Drawing.Size(274, 641);
            this.CategoriesPanelWithFilesList.TabIndex = 1;
            // 
            // FilesPanel
            // 
            this.FilesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FilesPanel.Controls.Add(this.FilesListBox);
            this.FilesPanel.Location = new System.Drawing.Point(0, 320);
            this.FilesPanel.Name = "FilesPanel";
            this.FilesPanel.Size = new System.Drawing.Size(274, 323);
            this.FilesPanel.TabIndex = 0;
            // 
            // FilesListBox
            // 
            this.FilesListBox.BackColor = System.Drawing.SystemColors.Control;
            this.FilesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilesListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FilesListBox.FormattingEnabled = true;
            this.FilesListBox.ItemHeight = 20;
            this.FilesListBox.Location = new System.Drawing.Point(0, 0);
            this.FilesListBox.Name = "FilesListBox";
            this.FilesListBox.Size = new System.Drawing.Size(272, 321);
            this.FilesListBox.TabIndex = 1;
            this.FilesListBox.DoubleClick += new System.EventHandler(this.FilesListBox_DoubleClick);
            // 
            // FoldersTreeViewForShowNotes
            // 
            this.FoldersTreeViewForShowNotes.BackColor = System.Drawing.SystemColors.Control;
            this.FoldersTreeViewForShowNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FoldersTreeViewForShowNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FoldersTreeViewForShowNotes.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FoldersTreeViewForShowNotes.FullRowSelect = true;
            this.FoldersTreeViewForShowNotes.Indent = 30;
            this.FoldersTreeViewForShowNotes.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.FoldersTreeViewForShowNotes.Location = new System.Drawing.Point(0, 0);
            this.FoldersTreeViewForShowNotes.Name = "FoldersTreeViewForShowNotes";
            this.FoldersTreeViewForShowNotes.Size = new System.Drawing.Size(274, 641);
            this.FoldersTreeViewForShowNotes.TabIndex = 0;
            this.FoldersTreeViewForShowNotes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.FoldersTreeViewForShowNotes_AfterSelect);
            // 
            // CategoriesPanel
            // 
            this.CategoriesPanel.Controls.Add(this.FoldersTreeView);
            this.CategoriesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CategoriesPanel.Location = new System.Drawing.Point(0, 0);
            this.CategoriesPanel.Name = "CategoriesPanel";
            this.CategoriesPanel.Size = new System.Drawing.Size(274, 641);
            this.CategoriesPanel.TabIndex = 0;
            // 
            // FoldersTreeView
            // 
            this.FoldersTreeView.BackColor = System.Drawing.SystemColors.Control;
            this.FoldersTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FoldersTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FoldersTreeView.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FoldersTreeView.FullRowSelect = true;
            this.FoldersTreeView.Indent = 30;
            this.FoldersTreeView.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.FoldersTreeView.Location = new System.Drawing.Point(0, 0);
            this.FoldersTreeView.Name = "FoldersTreeView";
            this.FoldersTreeView.Size = new System.Drawing.Size(274, 641);
            this.FoldersTreeView.TabIndex = 0;
            this.FoldersTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.FoldersTreeView_AfterSelect);
            // 
            // NoteFormView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1118, 690);
            this.Controls.Add(this.BodyPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NoteFormView";
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.NoteFormView_Load);
            this.BodyPanel.ResumeLayout(false);
            this.ContentPanel.ResumeLayout(false);
            this.RightPartPanel.ResumeLayout(false);
            this.RightPartPanel.PerformLayout();
            this.TextPanel.ResumeLayout(false);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnNewNote)).EndInit();
            this.LeftPartPanel.ResumeLayout(false);
            this.CategoriesPanelWithFilesList.ResumeLayout(false);
            this.FilesPanel.ResumeLayout(false);
            this.CategoriesPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BodyPanel;
        private System.Windows.Forms.Panel ContentPanel;
        private System.Windows.Forms.Panel RightPartPanel;
        private System.Windows.Forms.Panel LeftPartPanel;
        private System.Windows.Forms.Panel FilesPanel;
        private System.Windows.Forms.Panel CategoriesPanel;
        private System.Windows.Forms.TreeView FoldersTreeView;
        private System.Windows.Forms.Panel TextPanel;
        private UserControls.TextContainer NoteTextContainer;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.FlowLayoutPanel TabFlowPanel;
        private Bunifu.Framework.UI.BunifuImageButton BtnNewNote;
        private System.Windows.Forms.Panel CategoriesPanelWithFilesList;
        private System.Windows.Forms.TreeView FoldersTreeViewForShowNotes;
        private System.Windows.Forms.ListBox FilesListBox;
    }
}
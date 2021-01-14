using DiaryWinFormsNetFramework.Plugins.BaseForm;

namespace DiaryWinFormsNetFramework.View
{
    partial class DiaryForm
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
            this.components = new System.ComponentModel.Container();
            this.BodyPanel = new System.Windows.Forms.Panel();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.TabStory = new System.Windows.Forms.TabPage();
            this.TabWriterPanel = new System.Windows.Forms.Panel();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.StoryTextContainer = new DiaryWinFormsNetFramework.UserControls.TextContainer();
            this.TabHistory = new System.Windows.Forms.TabPage();
            this.TabReaderPanel = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.listBoxDocuments = new System.Windows.Forms.ListBox();
            this.TextContainerDocumentContent = new DiaryWinFormsNetFramework.UserControls.TextContainer();
            this.diaryFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BodyPanel.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.TabStory.SuspendLayout();
            this.TabWriterPanel.SuspendLayout();
            this.ContentPanel.SuspendLayout();
            this.TabHistory.SuspendLayout();
            this.TabReaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diaryFormBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // BodyPanel
            // 
            this.BodyPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BodyPanel.Controls.Add(this.TabControl);
            this.BodyPanel.Location = new System.Drawing.Point(0, 0);
            this.BodyPanel.Name = "BodyPanel";
            this.BodyPanel.Size = new System.Drawing.Size(1120, 690);
            this.BodyPanel.TabIndex = 0;
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabStory);
            this.TabControl.Controls.Add(this.TabHistory);
            this.TabControl.Font = new System.Drawing.Font("Nirmala UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabControl.Location = new System.Drawing.Point(35, 12);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(1050, 643);
            this.TabControl.TabIndex = 2;
            // 
            // TabStory
            // 
            this.TabStory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TabStory.Controls.Add(this.TabWriterPanel);
            this.TabStory.Location = new System.Drawing.Point(4, 37);
            this.TabStory.Name = "TabStory";
            this.TabStory.Padding = new System.Windows.Forms.Padding(3);
            this.TabStory.Size = new System.Drawing.Size(1042, 602);
            this.TabStory.TabIndex = 0;
            this.TabStory.Text = "Дневник";
            // 
            // TabWriterPanel
            // 
            this.TabWriterPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TabWriterPanel.Controls.Add(this.ContentPanel);
            this.TabWriterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabWriterPanel.Location = new System.Drawing.Point(3, 3);
            this.TabWriterPanel.Name = "TabWriterPanel";
            this.TabWriterPanel.Size = new System.Drawing.Size(1036, 596);
            this.TabWriterPanel.TabIndex = 2;
            // 
            // ContentPanel
            // 
            this.ContentPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ContentPanel.Controls.Add(this.StoryTextContainer);
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(0, 0);
            this.ContentPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(1036, 596);
            this.ContentPanel.TabIndex = 1;
            // 
            // StoryTextContainer
            // 
            this.StoryTextContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StoryTextContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.StoryTextContainer.BackColor = System.Drawing.Color.White;
            this.StoryTextContainer.ColorBorder = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.StoryTextContainer.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StoryTextContainer.Location = new System.Drawing.Point(0, 0);
            this.StoryTextContainer.Margin = new System.Windows.Forms.Padding(0);
            this.StoryTextContainer.Name = "StoryTextContainer";
            this.StoryTextContainer.Size = new System.Drawing.Size(1036, 596);
            this.StoryTextContainer.TabIndex = 1;
            this.StoryTextContainer.Title = "Story";
            this.StoryTextContainer.TitleReadOnly = false;
            // 
            // TabHistory
            // 
            this.TabHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TabHistory.Controls.Add(this.TabReaderPanel);
            this.TabHistory.Location = new System.Drawing.Point(4, 37);
            this.TabHistory.Name = "TabHistory";
            this.TabHistory.Padding = new System.Windows.Forms.Padding(3);
            this.TabHistory.Size = new System.Drawing.Size(1042, 602);
            this.TabHistory.TabIndex = 1;
            this.TabHistory.Text = "Все записи";
            this.TabHistory.Click += new System.EventHandler(this.btnOpenStoragePanel_Click);
            // 
            // TabReaderPanel
            // 
            this.TabReaderPanel.Controls.Add(this.splitContainer);
            this.TabReaderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabReaderPanel.Location = new System.Drawing.Point(3, 3);
            this.TabReaderPanel.Name = "TabReaderPanel";
            this.TabReaderPanel.Size = new System.Drawing.Size(1036, 596);
            this.TabReaderPanel.TabIndex = 4;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.listBoxDocuments);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.TextContainerDocumentContent);
            this.splitContainer.Size = new System.Drawing.Size(1036, 596);
            this.splitContainer.SplitterDistance = 277;
            this.splitContainer.TabIndex = 0;
            // 
            // listBoxDocuments
            // 
            this.listBoxDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxDocuments.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxDocuments.FormattingEnabled = true;
            this.listBoxDocuments.ItemHeight = 23;
            this.listBoxDocuments.Location = new System.Drawing.Point(0, 0);
            this.listBoxDocuments.Name = "listBoxDocuments";
            this.listBoxDocuments.Size = new System.Drawing.Size(277, 596);
            this.listBoxDocuments.TabIndex = 0;
            this.listBoxDocuments.SelectedIndexChanged += new System.EventHandler(this.listBoxDocuments_SelectedIndexChanged);
            // 
            // TextContainerDocumentContent
            // 
            this.TextContainerDocumentContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TextContainerDocumentContent.BackColor = System.Drawing.Color.White;
            this.TextContainerDocumentContent.ColorBorder = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TextContainerDocumentContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextContainerDocumentContent.Location = new System.Drawing.Point(0, 0);
            this.TextContainerDocumentContent.Margin = new System.Windows.Forms.Padding(0);
            this.TextContainerDocumentContent.Name = "TextContainerDocumentContent";
            this.TextContainerDocumentContent.Size = new System.Drawing.Size(755, 596);
            this.TextContainerDocumentContent.TabIndex = 0;
            this.TextContainerDocumentContent.Title = "Document content";
            this.TextContainerDocumentContent.TitleReadOnly = true;
            // 
            // diaryFormBindingSource
            // 
            this.diaryFormBindingSource.DataSource = typeof(DiaryWinFormsNetFramework.View.DiaryForm);
            // 
            // DiaryForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1120, 690);
            this.Controls.Add(this.BodyPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DiaryForm";
            this.Text = "DiaryForm";
            this.Load += new System.EventHandler(this.DiaryForm_Load);
            this.EnabledChanged += new System.EventHandler(this.DiaryForm_EnabledChanged);
            this.BodyPanel.ResumeLayout(false);
            this.TabControl.ResumeLayout(false);
            this.TabStory.ResumeLayout(false);
            this.TabWriterPanel.ResumeLayout(false);
            this.ContentPanel.ResumeLayout(false);
            this.TabHistory.ResumeLayout(false);
            this.TabReaderPanel.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.diaryFormBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BodyPanel;
        private System.Windows.Forms.Panel TabWriterPanel;
        private System.Windows.Forms.Panel ContentPanel;
        private UserControls.TextContainer StoryTextContainer;
        private System.Windows.Forms.Panel TabReaderPanel;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ListBox listBoxDocuments;
        private UserControls.TextContainer TextContainerDocumentContent;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage TabStory;
        private System.Windows.Forms.TabPage TabHistory;
        private System.Windows.Forms.BindingSource diaryFormBindingSource;
    }
}
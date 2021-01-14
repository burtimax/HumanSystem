namespace DiaryWinFormsNetFramework.Plugins.SettingsForm
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.BodyPanel = new System.Windows.Forms.Panel();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.panelMainDirectory = new System.Windows.Forms.Panel();
            this.btnOpenFolderDialogForMainDirectory = new System.Windows.Forms.Button();
            this.labelMainDirectory = new System.Windows.Forms.Label();
            this.MainDirectory = new System.Windows.Forms.Label();
            this.BottomCommandsPanel = new System.Windows.Forms.Panel();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.FolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.BodyPanel.SuspendLayout();
            this.ContentPanel.SuspendLayout();
            this.panelMainDirectory.SuspendLayout();
            this.BottomCommandsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BodyPanel
            // 
            this.BodyPanel.Controls.Add(this.ContentPanel);
            this.BodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BodyPanel.Location = new System.Drawing.Point(0, 0);
            this.BodyPanel.Name = "BodyPanel";
            this.BodyPanel.Size = new System.Drawing.Size(1120, 690);
            this.BodyPanel.TabIndex = 0;
            // 
            // ContentPanel
            // 
            this.ContentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ContentPanel.Controls.Add(this.panelMainDirectory);
            this.ContentPanel.Controls.Add(this.MainDirectory);
            this.ContentPanel.Controls.Add(this.BottomCommandsPanel);
            this.ContentPanel.Location = new System.Drawing.Point(28, 30);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(1064, 648);
            this.ContentPanel.TabIndex = 4;
            // 
            // panelMainDirectory
            // 
            this.panelMainDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMainDirectory.Controls.Add(this.btnOpenFolderDialogForMainDirectory);
            this.panelMainDirectory.Controls.Add(this.labelMainDirectory);
            this.panelMainDirectory.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMainDirectory.Location = new System.Drawing.Point(0, 17);
            this.panelMainDirectory.Name = "panelMainDirectory";
            this.panelMainDirectory.Size = new System.Drawing.Size(1064, 37);
            this.panelMainDirectory.TabIndex = 2;
            // 
            // btnOpenFolderDialogForMainDirectory
            // 
            this.btnOpenFolderDialogForMainDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFolderDialogForMainDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.btnOpenFolderDialogForMainDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFolderDialogForMainDirectory.Location = new System.Drawing.Point(1007, -1);
            this.btnOpenFolderDialogForMainDirectory.Name = "btnOpenFolderDialogForMainDirectory";
            this.btnOpenFolderDialogForMainDirectory.Size = new System.Drawing.Size(56, 37);
            this.btnOpenFolderDialogForMainDirectory.TabIndex = 1;
            this.btnOpenFolderDialogForMainDirectory.Text = "...";
            this.btnOpenFolderDialogForMainDirectory.UseVisualStyleBackColor = false;
            this.btnOpenFolderDialogForMainDirectory.Click += new System.EventHandler(this.btnOpenFolderDialogForMainDirectory_Click);
            // 
            // labelMainDirectory
            // 
            this.labelMainDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMainDirectory.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMainDirectory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.labelMainDirectory.Location = new System.Drawing.Point(0, 0);
            this.labelMainDirectory.Name = "labelMainDirectory";
            this.labelMainDirectory.Size = new System.Drawing.Size(1001, 35);
            this.labelMainDirectory.TabIndex = 0;
            this.labelMainDirectory.Text = "default directory";
            this.labelMainDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainDirectory
            // 
            this.MainDirectory.AutoSize = true;
            this.MainDirectory.Dock = System.Windows.Forms.DockStyle.Top;
            this.MainDirectory.Location = new System.Drawing.Point(0, 0);
            this.MainDirectory.Name = "MainDirectory";
            this.MainDirectory.Size = new System.Drawing.Size(97, 17);
            this.MainDirectory.TabIndex = 3;
            this.MainDirectory.Text = "Main directory";
            // 
            // BottomCommandsPanel
            // 
            this.BottomCommandsPanel.Controls.Add(this.btnChangePassword);
            this.BottomCommandsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomCommandsPanel.Location = new System.Drawing.Point(0, 595);
            this.BottomCommandsPanel.Name = "BottomCommandsPanel";
            this.BottomCommandsPanel.Size = new System.Drawing.Size(1064, 53);
            this.BottomCommandsPanel.TabIndex = 4;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnChangePassword.BackgroundImage")));
            this.btnChangePassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnChangePassword.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnChangePassword.FlatAppearance.BorderSize = 0;
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePassword.Location = new System.Drawing.Point(0, 0);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(61, 53);
            this.btnChangePassword.TabIndex = 6;
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1120, 690);
            this.Controls.Add(this.BodyPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.BodyPanel.ResumeLayout(false);
            this.ContentPanel.ResumeLayout(false);
            this.ContentPanel.PerformLayout();
            this.panelMainDirectory.ResumeLayout(false);
            this.BottomCommandsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BodyPanel;
        private System.Windows.Forms.FolderBrowserDialog FolderDialog;
        private System.Windows.Forms.Panel panelMainDirectory;
        private System.Windows.Forms.Button btnOpenFolderDialogForMainDirectory;
        private System.Windows.Forms.Label labelMainDirectory;
        private System.Windows.Forms.Label MainDirectory;
        private System.Windows.Forms.Panel ContentPanel;
        private System.Windows.Forms.Panel BottomCommandsPanel;
        private System.Windows.Forms.Button btnChangePassword;
    }
}
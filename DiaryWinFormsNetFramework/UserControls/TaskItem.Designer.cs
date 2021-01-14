using System.Windows.Forms;

namespace DiaryWinFormsNetFramework.UserControls
{
    partial class TaskItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.txtName = new System.Windows.Forms.Label();
            this.BottomColorPanel = new System.Windows.Forms.Panel();
            this.ContextMenuTaskItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxtStartTomato = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteTask = new Guna.UI.WinForms.GunaCircleButton();
            this.OpenCloseArrow = new Guna.UI.WinForms.GunaImageCheckBox();
            this.StatusCheckBox = new Guna.UI.WinForms.GunaImageCheckBox();
            this.AddSubtask = new Guna.UI.WinForms.GunaCircleButton();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.ContentPanel.SuspendLayout();
            this.ContextMenuTaskItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContentPanel
            // 
            this.ContentPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ContentPanel.BackColor = System.Drawing.Color.White;
            this.ContentPanel.Controls.Add(this.txtName);
            this.ContentPanel.Controls.Add(this.DeleteTask);
            this.ContentPanel.Controls.Add(this.StatusCheckBox);
            this.ContentPanel.Controls.Add(this.BottomColorPanel);
            this.ContentPanel.Controls.Add(this.AddSubtask);
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(35, 3);
            this.ContentPanel.MinimumSize = new System.Drawing.Size(100, 35);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(262, 39);
            this.ContentPanel.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.Transparent;
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(77, 0);
            this.txtName.Name = "txtName";
            this.txtName.Padding = new System.Windows.Forms.Padding(10, 0, 0, 2);
            this.txtName.Size = new System.Drawing.Size(143, 38);
            this.txtName.TabIndex = 3;
            this.txtName.Text = "name";
            this.txtName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BottomColorPanel
            // 
            this.BottomColorPanel.BackColor = System.Drawing.Color.LightGray;
            this.BottomColorPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomColorPanel.Location = new System.Drawing.Point(39, 38);
            this.BottomColorPanel.Name = "BottomColorPanel";
            this.BottomColorPanel.Size = new System.Drawing.Size(223, 1);
            this.BottomColorPanel.TabIndex = 3;
            // 
            // ContextMenuTaskItem
            // 
            this.ContextMenuTaskItem.DropShadowEnabled = false;
            this.ContextMenuTaskItem.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ContextMenuTaskItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxtStartTomato});
            this.ContextMenuTaskItem.Name = "ContextMenuTaskItem";
            this.ContextMenuTaskItem.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ContextMenuTaskItem.Size = new System.Drawing.Size(237, 28);
            // 
            // ctxtStartTomato
            // 
            this.ctxtStartTomato.BackColor = System.Drawing.SystemColors.Control;
            this.ctxtStartTomato.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ctxtStartTomato.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxtStartTomato.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ctxtStartTomato.Name = "ctxtStartTomato";
            this.ctxtStartTomato.Size = new System.Drawing.Size(236, 24);
            this.ctxtStartTomato.Text = "Запустить pomodoro";
            this.ctxtStartTomato.Click += new System.EventHandler(this.ctxtStartTomato_Click);
            // 
            // DeleteTask
            // 
            this.DeleteTask.AnimationHoverSpeed = 0.07F;
            this.DeleteTask.AnimationSpeed = 0.03F;
            this.DeleteTask.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DeleteTask.BaseColor = System.Drawing.Color.Transparent;
            this.DeleteTask.BorderColor = System.Drawing.Color.Black;
            this.DeleteTask.DialogResult = System.Windows.Forms.DialogResult.None;
            this.DeleteTask.Dock = System.Windows.Forms.DockStyle.Right;
            this.DeleteTask.FocusedColor = System.Drawing.Color.Empty;
            this.DeleteTask.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DeleteTask.ForeColor = System.Drawing.Color.White;
            this.DeleteTask.Image = global::DiaryWinFormsNetFramework.Properties.Resources.iconDeleteBig;
            this.DeleteTask.ImageSize = new System.Drawing.Size(32, 32);
            this.DeleteTask.Location = new System.Drawing.Point(220, 0);
            this.DeleteTask.Name = "DeleteTask";
            this.DeleteTask.OnHoverBaseColor = System.Drawing.Color.Transparent;
            this.DeleteTask.OnHoverBorderColor = System.Drawing.Color.Black;
            this.DeleteTask.OnHoverForeColor = System.Drawing.Color.White;
            this.DeleteTask.OnHoverImage = null;
            this.DeleteTask.OnPressedColor = System.Drawing.Color.Black;
            this.DeleteTask.Padding = new System.Windows.Forms.Padding(3);
            this.DeleteTask.Size = new System.Drawing.Size(42, 38);
            this.DeleteTask.TabIndex = 7;
            this.DeleteTask.Click += new System.EventHandler(this.DeleteTask_Click);
            // 
            // OpenCloseArrow
            // 
            this.OpenCloseArrow.Checked = true;
            this.OpenCloseArrow.Dock = System.Windows.Forms.DockStyle.Left;
            this.OpenCloseArrow.ImageCheckedOff = global::DiaryWinFormsNetFramework.Properties.Resources.rightArrow;
            this.OpenCloseArrow.ImageCheckedOn = global::DiaryWinFormsNetFramework.Properties.Resources.downArrow;
            this.OpenCloseArrow.ImageSize = new System.Drawing.Size(30, 30);
            this.OpenCloseArrow.Location = new System.Drawing.Point(3, 3);
            this.OpenCloseArrow.Name = "OpenCloseArrow";
            this.OpenCloseArrow.Size = new System.Drawing.Size(32, 39);
            this.OpenCloseArrow.TabIndex = 6;
            this.OpenCloseArrow.CheckedChanged += new System.EventHandler(this.OpenCloseArrow_CheckedChanged);
            // 
            // StatusCheckBox
            // 
            this.StatusCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.StatusCheckBox.ImageCheckedOff = global::DiaryWinFormsNetFramework.Properties.Resources._unchecked;
            this.StatusCheckBox.ImageCheckedOn = global::DiaryWinFormsNetFramework.Properties.Resources._checked;
            this.StatusCheckBox.ImageSize = new System.Drawing.Size(32, 32);
            this.StatusCheckBox.Location = new System.Drawing.Point(39, 0);
            this.StatusCheckBox.Name = "StatusCheckBox";
            this.StatusCheckBox.Size = new System.Drawing.Size(38, 38);
            this.StatusCheckBox.TabIndex = 7;
            this.StatusCheckBox.CheckedChanged += new System.EventHandler(this.StatusCheckBox_CheckedChanged);
            // 
            // AddSubtask
            // 
            this.AddSubtask.AnimationHoverSpeed = 0.07F;
            this.AddSubtask.AnimationSpeed = 0.03F;
            this.AddSubtask.BackColor = System.Drawing.Color.Transparent;
            this.AddSubtask.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AddSubtask.BaseColor = System.Drawing.Color.Transparent;
            this.AddSubtask.BorderColor = System.Drawing.Color.Black;
            this.AddSubtask.DialogResult = System.Windows.Forms.DialogResult.None;
            this.AddSubtask.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddSubtask.FocusedColor = System.Drawing.Color.Empty;
            this.AddSubtask.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.AddSubtask.ForeColor = System.Drawing.Color.White;
            this.AddSubtask.Image = global::DiaryWinFormsNetFramework.Properties.Resources.AddButton;
            this.AddSubtask.ImageSize = new System.Drawing.Size(32, 32);
            this.AddSubtask.Location = new System.Drawing.Point(0, 0);
            this.AddSubtask.Name = "AddSubtask";
            this.AddSubtask.OnHoverBaseColor = System.Drawing.Color.Transparent;
            this.AddSubtask.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.AddSubtask.OnHoverForeColor = System.Drawing.Color.White;
            this.AddSubtask.OnHoverImage = null;
            this.AddSubtask.OnPressedColor = System.Drawing.Color.Transparent;
            this.AddSubtask.Size = new System.Drawing.Size(39, 39);
            this.AddSubtask.TabIndex = 8;
            this.AddSubtask.Click += new System.EventHandler(this.AddSubTask_Click);
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 10;
            this.gunaElipse1.TargetControl = this.ContentPanel;
            // 
            // TaskItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.ContextMenuStrip = this.ContextMenuTaskItem;
            this.Controls.Add(this.ContentPanel);
            this.Controls.Add(this.OpenCloseArrow);
            this.MinimumSize = new System.Drawing.Size(300, 0);
            this.Name = "TaskItem";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(300, 45);
            this.ContentPanel.ResumeLayout(false);
            this.ContextMenuTaskItem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel ContentPanel;
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.Panel BottomColorPanel;
        private System.Windows.Forms.ContextMenuStrip ContextMenuTaskItem;
        private System.Windows.Forms.ToolStripMenuItem ctxtStartTomato;
        private Guna.UI.WinForms.GunaCircleButton DeleteTask;
        private Guna.UI.WinForms.GunaImageCheckBox OpenCloseArrow;
        private Guna.UI.WinForms.GunaImageCheckBox StatusCheckBox;
        private Guna.UI.WinForms.GunaCircleButton AddSubtask;
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
    }
}

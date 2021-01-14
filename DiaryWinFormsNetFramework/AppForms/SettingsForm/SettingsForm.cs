using DiaryClassLibStandart.Class;
using DiaryClassLibStandart.Helpers;
using DiaryWinFormsNetFramework.HelpersConstants;
using DiaryWinFormsNetFramework.Plugins.BaseForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiaryWinFormsNetFramework.Plugins.SettingsForm
{
    public partial class SettingsForm : BaseFormParent
    {
        public SettingsForm()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Chose Folder And Save Path To Stories Files
        /// </summary>
        private void btnOpenFolderDialogForMainDirectory_Click(object sender, EventArgs e)
        {          
            this.FolderDialog.ShowDialog();
            var res = FolderDialog.SelectedPath;
            if (string.IsNullOrEmpty(res) == false)
            {
                Settings.SetSetting(Settings.MainDirectory, res);
                this.labelMainDirectory.Text = res;
            }
        }


        private void SettingsForm_Load(object sender, EventArgs e)
        {
            FillElements();
        }


        private void FillElements()
        {
            this.labelMainDirectory.Text = Settings.GetSetting(Settings.MainDirectory);
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            var res = HelperDialog.ShowYesNoDialog("Вы действительно хотите поменять пароль?");
            if(res == DialogResult.Yes)
            {
                this.SendData(Constants.MESSAGE_CHANGE_PASSWORD,PerformOptions.SyncProcess);
            }
        }

        
    }
}

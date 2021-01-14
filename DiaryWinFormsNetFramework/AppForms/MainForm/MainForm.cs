﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiaryClassLib.Class;
using DiaryClassLibStandart;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using DiaryWinFormsNetFramework.Plugins.BaseForm;
using DiaryWinFormsNetFramework.View;
using DiaryWinFormsNetFramework.Plugins.SettingsForm;
using System.Windows;
using DiaryWinFormsNetFramework.HelpersConstants;
using DiaryWinFormsNetFramework.Plugins.IdeaForm;
using DiaryWinFormsNetFramework.Plugins.TaskForm;

namespace DiaryWinFormsNetFramework
{
    public partial class MainForm : BaseFormParent
    {
        delegate void EventGetAccessHandler();
        event EventGetAccessHandler OnGetUserAccess;

        private int WidthFormRatio = 1200;
        private int HeightFormRatio = 750;

        Panel formPanel;

        public MainForm() : base()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            formPanel = this.FormsPanel;
            this.OnGetUserAccess += OnGetUserAccess_EventHandler;
            AuthentificateUser();
        }

        protected override void ReceiveData(object data)
        {
            base.ReceiveData(data);

            if (data == null) return;
            
            if(data is string)
            {
                string strCmd = (string)data;
                if (string.Equals(strCmd, Constants.MESSAGE_CHANGE_PASSWORD)){
                    ChangePassword();
                }
            }
        }


        private void AuthentificateUser()
        {
            //Установим первоначальное состояние панелей
            HelperForm.ActivateControl(this.PasswordPanel);
            HelperForm.DeactivateControl(this.SetNewPasswordPanel);
            HelperForm.DeactivateControl(this.InputPasswordPanel);

            //Если нет пароля, то создадим его
            if (string.IsNullOrEmpty(AppVariables.PASSWORD_APP_SETTING))
            {
                //Активируем панель для создания пароля
                HelperForm.ActivateControl(this.SetNewPasswordPanel);
            }
            //Если пароль существует, то войдем в приложение
            else
            {
                //Активируем панель для ввода пароля
                HelperForm.ActivateControl(this.InputPasswordPanel);
            }

        }

        private void OnGetUserAccess_EventHandler()
        {
            //var form = new DiaryForm();
            this.OpenForm(InstanceOf<DiaryForm>());
        }


        /// <summary>
        /// Открыть форму (окно)
        /// </summary>
        /// <param name="form"></param>
        public void OpenForm(BaseFormParent form)
        {
            if (form.Enabled == true &&
                form.Visible == true)
            {
                form.RefreshData();
                form.Select();
                return;
            }

            //Ничего не открывать, пока не получили доступ
            if (Constants.ACCESS == false) return;

            var controls = formPanel.Controls;
            foreach(Control control in controls)
            {
                DisableControl(control);
            }
            if (controls.Contains(form))
            {
                EnableControl(controls[controls.IndexOf(form)]);
                //обновляем данные в форме.
                form.RefreshData();
                form.Select();
            }
            else
            {
                //reset topLevel (it needs for adding form to mainForm)
                form.TopLevel = false;
                controls.Add(form);           
                EnableControl(form);
                form.Dock = DockStyle.Fill;
                form.Select();
            }
            
        }


        void DisableControl(Control control)
        {
            control.Enabled = false;
            control.Visible = false;
            control.Hide();
        }

        void EnableControl(Control control)
        {
            control.Enabled = true;
            control.Visible = true;
            control.Show();
        }

        private void btnCloseCircle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNavItemSettings_Click(object sender, EventArgs e)
        {         
            OpenForm(InstanceOf<SettingsForm>());
        }

        private void btnNavItemDiary_Click(object sender, EventArgs e)
        {
            OpenForm(InstanceOf<DiaryForm>());
        }

        /// <summary>
        /// Нажатие кнопки (Идеи) на боковой панели
        /// </summary>
        private void btnNavItemNotes_Click(object sender, EventArgs e)
        {
            OpenForm(InstanceOf<NoteFormView>());
        }


        /// <summary>
        /// Нажатие кнопки на боковой панели. Откроем панель личных задач.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNavItemTasks_Click(object sender, EventArgs e)
        {
            OpenForm(InstanceOf<TaskForm>());
        }


        //Перед закрытием гланой формы, вызовем методы OnCloseForm для каждой активной формы.
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var form in BaseFormParent.ActiveForms)
            {             
                form.Value.OnCloseForm();
            }
        }

        /// <summary>
        /// Вызываем при загрузке окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            SetFormSize();

            //Сделаем поле для ввода пароля активным! Чтобы не наводить мышь!
            this.SetPasswordTextBox.Select();
        }


        /// <summary>
        /// Устанавливаем высоту и ширину главного окна приложения, чтобы красиво выглядело
        /// </summary>
        void SetFormSize()
        {

            int width = (int)SystemParameters.VirtualScreenWidth;
            int height = (int)SystemParameters.VirtualScreenHeight;
            this.WindowState = FormWindowState.Normal;
            double K = 1f;
            width = Convert.ToInt32(width * K);
            height = Convert.ToInt32(height * K);
            double k = Math.Min(width / WidthFormRatio, height / HeightFormRatio);
            this.Width = (int)(k * WidthFormRatio);
            this.Height = (int)(k * HeightFormRatio);
            this.CenterToScreen();
            //var width = (int)SystemParameters.VirtualScreenWidth;
            //var height = (int)SystemParameters.VirtualScreenHeight;
            //this.WindowState = FormWindowState.Normal;
            //double K = 0.9f;
            //var width = this.Width * K;
            //var height = this.Height * K;
            //double k = Math.Min(width / WidthFormRatio, height / HeightFormRatio);
            //this.Width = (int)(k * WidthFormRatio);
            //this.Height = (int)(k * HeightFormRatio);
            //this.CenterToScreen();
        }


        ///Событие изменения текста панели подтверждения пароля
        private void SecondPasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            //Установим пароль автоматически, если текст из второго поля совпал с текстом первого поля
            if(SecondPasswordTextBox.Text.Length>0 &&
               string.Equals(SecondPasswordTextBox.Text, FirstPasswordTextBox.Text,StringComparison.Ordinal) == true)
            {
                AppVariables.PASSWORD_APP_SETTING = FirstPasswordTextBox.Text;
                GiveAccess();
            }
            else
            {
                this.SecondPasswordTextBox.ForeColor = Color.Coral;
            }
        }

        //Событие изменения текста в поле для ввода пароля
        private void SetPassword_TextChanged(object sender, EventArgs e)
        {
            //Если пароль совпал, то дать 
            if(this.SetPasswordTextBox.Text == AppVariables.PASSWORD_APP_SETTING)
            {
                GiveAccess();
            }
        }

        /// <summary>
        /// Дать доступ к программе;
        /// </summary>
        private void GiveAccess()
        {
            Constants.ACCESS = true;
            HelperForm.DeactivateControl(this.PasswordPanel);
            //Событие получение доступа к программе
            OnGetUserAccess?.Invoke();
        }

        /// <summary>
        /// горячие клавиши
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //ctrl + shift + 0 (Дать внеочередной доступ к программе)
            if(keyData == (Keys.Control | Keys.Shift | Keys.D0))
            {
                GiveAccess();
            }

            //Hide/Show form
            if(keyData == (Keys.Control | Keys.H))
            {
                if (formPanel.Enabled)
                {
                    HelperForm.DeactivateControl(this.formPanel);
                }
                else
                {
                    HelperForm.ActivateControl(this.formPanel);
                }
            }

            //Горячие клавиши для перехода между вкладками. 
            OpenTabByHotKeys(ref msg, keyData);
            
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Поменять пароль
        /// </summary>
        private void ChangePassword()
        {
            //Деактивируем все элементы внутри основной панели
            foreach(var childControl in formPanel.Controls)
            {
                var c = (Control)childControl;
                HelperForm.DeactivateControl(c);
            }
            //Активируем панель смены пароля
            HelperForm.ActivateControl(PasswordPanel);
            HelperForm.DeactivateControl(InputPasswordPanel);
            HelperForm.ActivateControl(SetNewPasswordPanel);
        }

        private void btnWrapCircle_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnOpenCircle_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.SetFormSize();
                return;
            }

            this.WindowState = FormWindowState.Maximized;
        }

        /// <summary>
        /// Open program tab by hot keys command for quick opening
        /// </summary>
        private void OpenTabByHotKeys(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F1:
                    OpenForm(InstanceOf<SettingsForm>());
                    break;
                case Keys.F2:
                    OpenForm(InstanceOf<DiaryForm>());
                    break;
                case Keys.F3:
                    OpenForm(InstanceOf<NoteFormView>());
                    break;
                case Keys.F4:
                    OpenForm(InstanceOf<TaskForm>());
                    break;
            }
        }
    }
}

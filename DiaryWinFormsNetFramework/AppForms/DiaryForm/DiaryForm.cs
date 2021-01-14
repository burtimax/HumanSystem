
using DiaryClassLib.Class;
using DiaryClassLibStandart.Class;
using DiaryClassLibStandart.Class.Basic;
using DiaryClassLibStandart.Helpers;
using DiaryWinFormsNetFramework.HelpersConstants;
using DiaryWinFormsNetFramework.Plugins;
using DiaryWinFormsNetFramework.Plugins.BaseForm;
using DiaryWinFormsNetFramework.UserControls;
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
using LibForPersonalTool.Class.Basic;

namespace DiaryWinFormsNetFramework.View
{
    //ToDo Добавить отслеживание изменений текстовых полей, чтобы можно было предупреждать, что данные не сохранены.
    //ToDo Перед закрытием, изменением папки, предложить текущую запись.
    public partial class DiaryForm: BaseFormParent
    {
        int highFileNumber = 0;

        TextContainer activeTextContainer;

        DiaryDoc Diary;

        public DiaryForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            this.RefreshData();
            //Initialize tabs
            this.InitTabs();

            //Привяжем обработчики к событиям
            this.VisibleChanged -= DiaryForm_VisibleChanged;
            this.VisibleChanged += DiaryForm_VisibleChanged;

            //Активируем курсор в текстовом поле.
            StoryTextContainer.Select();
        }

        //Проинициализировать все табы (кнопки с поведением вкладок)
        private void InitTabs()
        {
            StoryTextContainer.TextChanged -= TextContainer_TextChanged;
            StoryTextContainer.TextChanged += TextContainer_TextChanged;

        }

        /// <summary>
        /// Обовить данные для актуализации.
        /// </summary>
        public override void RefreshData()
        {
            var strMainDir = DirConstants.GetDiaryDirectory();
            //Если директория поменялась, то обновим переменную записи.
            if (this.storyDirectory != strMainDir)
            {
                this.storyDirectory = strMainDir;
                //если поменяли путь к папке, то старые записи нам не нужны, очистим содержимое полей.\
                //ToDo (Добавить условие, что очищаем только если записи сохранены.)
                ClearAllVisibleFields();
                this.Diary = new DiaryDoc();
            }
            
            //вызываем обработчик загрузки окна
            this.DiaryForm_Load(this, new EventArgs());
            base.RefreshData();
        }


        


        /// <summary>
        /// Обрабатываем горячие клавиши
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //ctrl + s (Сохранить записи)
            if(keyData == (Keys.Control | Keys.S))
            {
                this.SaveDiaryData();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// 
        /// </summary>
        private void TextContainer_TextChanged(object sender, EventArgs e)
        {
            this.Diary.IsSaved = false;
        }


        /// <summary>
        /// Сохраняем записи дневника
        /// </summary>
        void SaveDiaryData()
        {
            string name = this.StoryTextContainer.Title;

            while(string.IsNullOrWhiteSpace(name))
            {
                var res = HelperDialog.ShowInputBox("Введите название записи!");
                if (res.Status != DialogResult.OK)
                {
                    name = Constants.DEFAULT_FILENAME;
                }
                else
                {
                    name = res.Value;
                }
            }

            this.StoryTextContainer.Title = name;


            string fileName;
            //Если есть файл с текущей датой
            if (HasFileForCurrentDate(out fileName))
            { 
                //удалим файл с текущей датой.
                File.Delete(fileName);
            }

            var fileTitle = this.StoryTextContainer.Title;
            fileName = GetFileNameForSaving(fileTitle);
            //Проверим, если директория не существует
            HelperFileName.ParsePath(fileName, out var dir, out var _, out var __);
            if(Directory.Exists(dir) == false)
            {
                HelperDialog.ShowWarningDialog("Укажите в настройках путь к папке записей", "Не найдена папка для записей!");
                return;
            }

            this.Diary.Open(fileName);
            FillTextFields();
            if (this.Diary.SaveInfo())
            {
                this.Diary.IsSaved = true;
            }         
        }

        /// <summary>
        /// Заполняем все поля данных (обновляем Diary Fields)
        /// </summary>
        void FillTextFields()
        {            
            this.Diary.SetText(this.Diary.Fields.Title, this.StoryTextContainer.Title);
            this.Diary.SetText(this.Diary.Fields.Story, this.StoryTextContainer.TextField.Text);
        }

        private void DiaryForm_Load(object sender, EventArgs e)
        {
            //Когда есть изменения, то не нужно перезагружать данные из файла, так как может утеряться написаный текст, но не сохраненный.
            //Поэтому, если текущий текст сохранен, то не нужно перезагружать.
            LoadExistingData();
            LoadListDocuments();            
        }

        /// <summary>
        /// Загрузить данные (текст) на текущий день.
        /// </summary>
        void LoadExistingData()
        {
            if (HasFileForCurrentDate(out var pathCurFile))
            {
                this.Diary.Open(pathCurFile);
                this.StoryTextContainer.Title = this.Diary.GetText(this.Diary.Fields.Title);
                this.StoryTextContainer.TextField.Text = this.Diary.GetText(this.Diary.Fields.Story);
                this.StoryTextContainer.TextField.Text += "\n"+this.Diary.GetText(this.Diary.Fields.Ideas);
                this.StoryTextContainer.TextField.Text += "\n"+this.Diary.GetText(this.Diary.Fields.Achievements);
            }
            //загрузили нужные данные, отметим, что текстовые поля не изменялись
            this.Diary.IsSaved = true;
        }

        /// <summary>
        /// Загружаем в список имена файлов существующих записей.
        /// </summary>
        void LoadListDocuments()
        {
            var docs = GetDiaryFilesNames();
            if (docs == null || docs.Count == 0) return;

            docs.Reverse();
            this.listBoxDocuments.DataSource = docs;
        }


        /// <summary>
        /// Обработчик события изменения элемента списка
        /// Считываем данные по файлу из списка.
        /// </summary>
        private void listBoxDocuments_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listBox = (ListBox)sender;
            //Проверяем, чтобы список был не пустой
            if (listBox.Items == null || listBox.Items.Count == 0 || listBox.SelectedItem == null) return;

            var value = listBox.SelectedItem.ToString();
            var path = GetFullPathStoryFileByFileName(value);

            //Получаем расширение из имени файла
            HelperFileName.ParsePath(path, out var _, out var __, out var ext);
            //Получаем нужный объект для считывания документа (зависит от расширения)
            IDocumentReader reader = HelperDocumentReader.CreateReader(ext);
            
            if(reader == null)
            {
                this.TextContainerDocumentContent.TextField.Text = "Не удалось считать данные из документа!";
                return;
            }

            reader.OpenDocument(path);
            if(reader.ReadAllTextData(out var data))
            {
                this.TextContainerDocumentContent.TextField.Text = data;
            }
            reader.CloseDocument();
        }


       

        //активация понели чтения существующих записей
        private void btnOpenStoragePanel_Click(object sender, EventArgs e)
        {
            HelperForm.DeactivateControl(this.TabWriterPanel);
            HelperForm.ActivateControl(this.TabReaderPanel);

            //Обновим список документов, может уже появился новый документ
            if(this.listBoxDocuments.Items == null ||
               this.listBoxDocuments.Items.Count == 0)
            {
                this.LoadListDocuments();
                return;
            }
            //здесь listBoxDocuments.Items != null;
            //если имя последнего файла не схоже с первой записью в дневнике
            if(this.GetDiaryFiles().Count != this.listBoxDocuments.Items.Count ||
               GetLastDiaryFilePath(this.storyDirectory).IndexOf(this.listBoxDocuments.Items[0].ToString()) < 0)
            {
                this.LoadListDocuments();
            }
        }


        /// <summary>
        /// Очищаем все текстовые поля, листбоксы и прочее, чтобы все стало чисто (нигде не было текста)
        /// </summary>
        void ClearAllVisibleFields()
        {
            this.StoryTextContainer.TextField.Text = null;
            this.StoryTextContainer.Title = "Story";
            this.listBoxDocuments.DataSource = null;
            this.listBoxDocuments.Items.Clear();
            this.TextContainerDocumentContent.TextField.Text = null;
        }



        public override void OnCloseForm()
        {
            this.AskSaveDiary();
            base.OnCloseForm();
        }

        /// <summary>
        /// Спросить о сохранении записи
        /// </summary>
        private void AskSaveDiary()
        {
            if (this.Diary.IsSaved == false)
            {
                var result = HelperDialog.ShowYesNoDialog("Сохранить запись дневника?", "Запись дневника изменена");
                if (result.Equals(DialogResult.Yes))
                {
                    SaveDiaryData();
                }
            }
        }

        /// <summary>
        /// Обработчик события изменения видимости окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DiaryForm_VisibleChanged(object sender, EventArgs e)
        {
            if(this.Visible == false)
            {
                this.AskSaveDiary();
            }
        }

        /// <summary>
        /// При открытии формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DiaryForm_EnabledChanged(object sender, EventArgs e)
        {
            if(this.Enabled == true)
            {
                StoryTextContainer.Select();
            }
        }

      
    }
}

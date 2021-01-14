using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using DiaryClassLibStandart.Helpers;
using LibForPersonalTool.Class.Notes;

namespace DiaryWinFormsNetFramework.AppForms.NoteForm
{
    class NoteFormController
    {
        Regex filenameRegex = new Regex(@"^[\w\-. ]+$");

        public Dictionary<Label, Note> LabelsNotes;

        private INoteFormView View;
        private NoteFormModel Model;
        private bool _showFilesList;
        public bool ShowFilesList
        {
            get { return _showFilesList; }
            set
            {
                _showFilesList = value;
                if (value == true)
                {
                    View.SetFilesPanel(true);
                }
                else
                {
                    View.SetFilesPanel(false);
                }
            }
        }

        public NoteFormController(INoteFormView view)
        {
            this.View = view;
            LabelsNotes = new Dictionary<Label, Note>();
            this.Model = new NoteFormModel();
        }

        public void OnLoad()
        {
            LoadFolderTree();
            this.ShowFilesList = false;
            //Устанавливаем обработчики на события
            this.Model.NotesManager.CurrentNoteChanged -= ChangeCurrentNote;
            this.Model.NotesManager.CurrentNoteChanged += ChangeCurrentNote;
            this.Model.NotesManager.NotesCollectionChangedHandler = NotesCollectionChanged;

            AddNote(new Note());
        }

        /// <summary>
        /// изменить текущую заметку
        /// </summary>
        /// <param name="prevNote"></param>
        /// <param name="curNote"></param>
        private void ChangeCurrentNote(Note prevNote, Note curNote)
        {
            View.SelectNote(prevNote, curNote);
        }

        /// <summary>
        /// Changed Notes Collection in Manager
        /// </summary>
        private void NotesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    View.AddNewNote(e.NewItems[0] as Note);
                    break;

                case NotifyCollectionChangedAction.Remove:
                    View.RemoveNote(e.OldItems[0] as Note);
                    break;
            }
        }

        public Note GetNextNote(Note note)
        {
            if (this.Model.NotesManager.Notes.Count == 0) return null;
            int curIndex = this.Model.NotesManager.Notes.IndexOf(note);
            int nextIndex = curIndex + 1 == this.Model.NotesManager.Notes.Count ? 0 : curIndex + 1;
            return this.Model.NotesManager.Notes.ElementAt(nextIndex);
        }

        public Note GetPreviousNote(Note note)
        {
            if (this.Model.NotesManager.Notes.Count == 0) return null;
            int curIndex = this.Model.NotesManager.Notes.IndexOf(note);
            int prevIndex = curIndex - 1 < 0 ? this.Model.NotesManager.Notes.Count-1 : curIndex - 1;
            return this.Model.NotesManager.Notes.ElementAt(prevIndex);
        }

        public void LoadFolderTree()
        {
            View.FillFolderTreeView(Model.GetFolderTree());
        }


        public void AddNote(Note note)
        {
            this.Model.NotesManager.AddNote(note);
        }

        public void RemoveNote(Note note)
        {
            this.Model.NotesManager.RemoveNote(note);
        }

        public void AddLinkNoteLabel(Note note, Label l)
        {
            this.LabelsNotes.Add(l, note);
        }

        public void SetCurrentNoteByLabelClick(Label l)
        {
            SetCurrentNote(LabelsNotes[l]);
        }

        public void SetCurrentNote(Note note)
        {
            this.Model.NotesManager.SetCurrentNote(note);
        }

        public Note GetCurrentNote()
        {
            return this.Model?.NotesManager?.CurrentNote;
        }

        public void SaveCurrentNote()
        {
            Note note = this.Model.NotesManager.CurrentNote;

            if (note == null) return;

            View.UpdateNoteData(note);

            if (CheckNoteDataBeforeSaving(note, out var warn) == false)
            {
                MessageBox.Show(warn);
                return;
            }

            File.WriteAllText(note.Path, note.Content);

            if (note.ExistedNoteFilePath != null && note.ExistedNoteFilePath != note.Path)
            {
                File.Delete(note.ExistedNoteFilePath);
            }

            note.Saved = true;
            note.ExistedNoteFilePath = note.Path;
        }

        public void CloseCurrentNote()
        {
            Note note = this.Model.NotesManager.CurrentNote;

            if (note == null) return;

            if(note.Saved == true)
            {
                RemoveNote(note);
                return;
            }

            View.UpdateNoteData(note);

            if (string.IsNullOrWhiteSpace(note?.Content?.Trim(' ', '\n')))
            {
                RemoveNote(note);
                return;
            }

            if (CheckNoteDataBeforeSaving(note, out var warn) == false)
            {
                MessageBox.Show(warn);
                return;
            }

            var res = MessageBox.Show("Сохранить перед закрытием?", "", MessageBoxButtons.YesNoCancel);
            switch (res)
            {
                case DialogResult.Yes:
                    SaveCurrentNote();
                    RemoveNote(note);
                    break;
                case DialogResult.No:
                    RemoveNote(note);
                    break;
                case DialogResult.Cancel:
                    return;
                    break;
            }

        }

        public Label GetSelectedNoteTabLabel()
        {
            Note note = this.Model.NotesManager.CurrentNote;

            if (note == null) return null;

            return LabelsNotes.Keys.Where(k => LabelsNotes[k] == note)?.FirstOrDefault();
        }

        public void SetSelectedNoteTitle(string title)
        {
            if(Model?.NotesManager?.CurrentNote != null)
            {
                this.Model.NotesManager.CurrentNote.Title = title;
            }
        }

        private bool CheckNoteDataBeforeSaving(Note note, out string warning)
        {
            bool res = true;
            warning = "";

            if (note == null)
            {
                throw new Exception("Note is null on checking!");
            }

            if (filenameRegex.Match(note.Title).Success == false)
            {
                warning += "Title has invalid symbols!\n";
                res = false;
            }

            if(string.IsNullOrWhiteSpace(note?.Content?.Trim(' ')))
            {
                warning += "Note text is null!\n";
                res = false;
            }

            if (string.IsNullOrWhiteSpace(note?.CategoryDir?.Trim(' ')))
            {
                warning += "Note category is null!\n";
                res = false;
            }

            if (string.IsNullOrWhiteSpace(note?.Path?.Trim(' ')))
            {
                warning += "Note file path is null!\n";
                res = false;
            }

            return res;
        }

        public void SetCurrentNoteCategory(string folderPath, string category)
        {
            Note note = this.Model.NotesManager.CurrentNote;
            note.CategoryDir = folderPath;
            View.SetNodeColor(note);
        }

        public List<(string fname, string fpath)> GetFilesForCategory(string categoryPath)
        {
            return this.Model.GetFiles(categoryPath);
        }

       
    }
}

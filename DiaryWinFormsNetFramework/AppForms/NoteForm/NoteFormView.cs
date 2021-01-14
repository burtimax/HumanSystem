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
using DiaryWinFormsNetFramework.AppForms.NoteForm;
using LibForPersonalTool.Class.Basic;
using LibForPersonalTool.Class.Notes;

namespace DiaryWinFormsNetFramework.Plugins.SettingsForm
{
    public partial class NoteFormView : BaseFormParent, INoteFormView
    {
        //Файлы, которые отображаются сейчас
        private List<(string fname, string fpath)> _currentFilesList;

        private TreeNode ColoredNode = null;
        private Label ColoredLabel = null;
        private NoteFormController Controller;
        TextListEditor EditProcessor;


        public NoteFormView()
        {
            InitializeComponent();
            _currentFilesList = new List<(string fname, string fpath)>();
            this.Controller = new NoteFormController(this);
            EditProcessor = new TextListEditor(NoteTextContainer.TextField);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Save Note
            if(keyData == (Keys.Control | Keys.S))
            {
                Controller.SaveCurrentNote();
                return true;
            }

            //Close Note
            if (keyData == (Keys.Control | Keys.W))
            {
                Controller.CloseCurrentNote();
                return true;
            }

            //Add new Note
            if (keyData == (Keys.Control | Keys.N))
            {
                Controller.AddNote(new Note());
                return true;
            }
            
            //Show/hide Files panel
            if (keyData == ((Keys.Control | Keys.Q)) || keyData == ((Keys.Control | Keys.O)))
            {
                Controller.ShowFilesList = !Controller.ShowFilesList;
                return true;
            }

            //Rename Title
            if (keyData == (Keys.Control | Keys.R))
            {
                NoteTextContainer.SelectTitleTextBox();
                return true;
            }


            //Select previous Note
            if (keyData == (Keys.Control | Keys.Oemcomma))
            {
                var prev = Controller.GetPreviousNote(Controller.LabelsNotes[ColoredLabel]);
                if (prev != null)
                {
                    Controller.SetCurrentNote(prev);
                }
                return true;
            }

            //Select next Note
            if (keyData == (Keys.Control | Keys.OemPeriod))
            {
                var next = Controller.GetNextNote(Controller.LabelsNotes[ColoredLabel]);
                if (next != null)
                {
                    Controller.SetCurrentNote(next);
                }
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);

        }

        private void NoteFormView_Load(object sender, EventArgs e)
        {
            NoteTextContainer.TitleChangeEventHandler = OnNoteTitleChange;
            Controller.OnLoad();
        }

        private void OnNoteTitleChange(object sender, EventArgs e)
        {
            //Костыль, ну ладно
            if (sender is TextBox == false) throw new Exception("Text container Title is TextBox type!");

            string title = (sender as TextBox).Text;
            Controller.SetSelectedNoteTitle(title);
            string titleForLabel = title.Substring(0, Math.Min(title.Length, 11));
            if(titleForLabel.Length == 11)
            {
                titleForLabel += "...";
            }

            if (string.IsNullOrWhiteSpace(titleForLabel))
            {
                titleForLabel = "___";
            }

            Controller.GetSelectedNoteTabLabel().Text = titleForLabel;
        }

        /// <summary>
        /// Fill Main Nodes in FolderTreeView
        /// </summary>
        /// <param name="folderTree"></param>
        public void FillFolderTreeView(Tree<string> folderTree)
        {
            foreach (var child in folderTree.Children)
            {
                string shortDir = child.Value.Substring(child.Value.LastIndexOf('\\')+1);
                FoldersTreeView.Nodes.Add(child.Value, shortDir);
                FillFolderTreeViewNode(FoldersTreeView.Nodes[FoldersTreeView.Nodes.Count - 1], child);

                FoldersTreeViewForShowNotes.Nodes.Add(child.Value, shortDir);
                FillFolderTreeViewNode(FoldersTreeViewForShowNotes.Nodes[FoldersTreeView.Nodes.Count - 1], child);
            }
        }



        public void AddNewNote(Note note)
        {
            Label l = new Label();
            l.TextAlign = ContentAlignment.BottomLeft;
            l.BackColor = Constants.COLOR_CONTROL;
            l.AutoSize = true;
            l.MaximumSize = new Size(150, 30);
            l.Text = note.Title;
            l.Click -= NoteTab_Click;
            l.Click += NoteTab_Click;

            TabFlowPanel.Controls.Add(l);
            Controller.AddLinkNoteLabel(note, l);
        }

        public void RemoveNote(Note note)
        {
            Label l = Controller.LabelsNotes.Keys.Where(k => Controller.LabelsNotes[k] == note)?.FirstOrDefault();
            Controller.LabelsNotes.Remove(l);
            this.TabFlowPanel.Controls.Remove(l);
            l = null;
        }

        public void SelectNote(Note prevNote, Note curNote)
        {
            UpdateNoteData(prevNote);
            ChangeSelectionLabelForNotes(prevNote, curNote);
            NoteTextContainer.Title = curNote.Title;
            NoteTextContainer.TextField.Text = curNote.Content;
            NoteTextContainer.Select();
            SetNodeColor(curNote);
        }

        private void ChangeSelectionLabelForNotes(Note prev, Note cur)
        {
            Label prevLabel = Controller.LabelsNotes.Keys.Where(k => Controller.LabelsNotes[k] == prev)?.FirstOrDefault();
            Label curLabel = Controller.LabelsNotes.Keys.Where(k => Controller.LabelsNotes[k] == cur)?.FirstOrDefault();

            if(prevLabel != null)
            {
                prevLabel.BackColor = Color.Transparent;
            }

            if (curLabel != null)
            {
                curLabel.BackColor = Constants.COLOR_GREY;
                ColoredLabel = curLabel;
            }
        }

       

        public void SetNodeColor(Note note, bool changeSelection = true)
        {
            if (note == null) return;

            if (ColoredNode != null)
            {
                ColoredNode.BackColor = Constants.COLOR_CONTROL;
            }

            var node = FoldersTreeView.Nodes?.Find(note.CategoryDir, true)?.FirstOrDefault();
            
            if (changeSelection)
            {
                FoldersTreeView.SelectedNode = node;
            }

            if (node != null)
            {
                node.BackColor = Constants.COLOR_GREY;
                ColoredNode = node;
            }
        }

        public void UpdateNoteData(Note note)
        {
            if (note == null) return;

            if (string.Equals(note.Title ?? "", NoteTextContainer.Title) == false)
            {
                note.Title = NoteTextContainer.Title;
            }

            if (string.Equals(note.Content ?? "", NoteTextContainer.TextField.Text) == false)
            {
                note.Content = NoteTextContainer.TextField.Text;
            }
            
            if (FoldersTreeView.SelectedNode != null && string.Equals(note.CategoryDir, FoldersTreeView.SelectedNode.Name) == false)
            {
                note.CategoryDir = FoldersTreeView.SelectedNode.Name;
            }

           
        }

        public void SetFilesPanel(bool showPanel)
        {
            if (showPanel)
            {
                CategoriesPanelWithFilesList.Enabled = true;
                CategoriesPanelWithFilesList.Visible = true;
                if (FoldersTreeViewForShowNotes?.SelectedNode != null)
                {
                    SetFilesList(Controller.GetFilesForCategory(FoldersTreeViewForShowNotes.SelectedNode.Name));
                }
            }
            else
            {
                CategoriesPanelWithFilesList.Enabled = false;
                CategoriesPanelWithFilesList.Visible = false;
            }
           
        }

        /// <summary>
        /// Fill FolderTreeView Nodes By Recursion
        /// </summary>
        /// <param name="tn"></param>
        /// <param name="fTree"></param>
        private void FillFolderTreeViewNode(TreeNode tn, Tree<string> fTree)
        {
            if (tn == null || fTree?.Children == null || fTree.Children.Count == 0) return;

            foreach (var fTreeChild in fTree.Children)
            {
                string shortDir = fTreeChild.Value.Substring(fTreeChild.Value.LastIndexOf('\\')+1);
                tn.Nodes.Add(fTreeChild.Value, shortDir);
                FillFolderTreeViewNode(tn.Nodes[tn.Nodes.Count-1], fTreeChild);
            }
        }


        public void NoteTab_Click(object sender, EventArgs e)
        {
            Controller.SetCurrentNoteByLabelClick(sender as Label);
        }

        private void FoldersTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            Controller.SetCurrentNoteCategory(FoldersTreeView.SelectedNode.Name, FoldersTreeView.SelectedNode.Text);
        }

        private void BtnNewNote_Click(object sender, EventArgs e)
        {
            Controller.AddNote(new Note());
        }

        private void FoldersTreeViewForShowNotes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SetFilesList(Controller.GetFilesForCategory(e.Node.Name));
        }

        private void SetFilesList(List<(string fname, string fpath)> files)
        {
            FilesListBox.Items.Clear();
            _currentFilesList = files;

            foreach (var f in files)
            {
                FilesListBox.Items.Add(f.fname);
            }
            
        }

        private void FilesListBox_DoubleClick(object sender, EventArgs e)
        {
            string path = _currentFilesList.Where(i => string.Equals(i.fname,FilesListBox.SelectedItem.ToString()))?.FirstOrDefault().fpath;
            if(Note.GetNoteFromFile(path, out var noteFromFile))
            {
                Controller.AddNote(noteFromFile);
            }
        }

        
    }
}

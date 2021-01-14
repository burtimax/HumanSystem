using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibForPersonalTool.Class.Notes;

namespace DiaryWinFormsNetFramework.AppForms.NoteForm
{
    public interface INoteFormView
    {
        void FillFolderTreeView(Tree<string> folderTree);
        void AddNewNote(Note note);
        void RemoveNote(Note note);
        void SelectNote(Note prevNote, Note curNote);
        //void ResetNodeColor(Note note, bool changeSelection = true);
        void UpdateNoteData(Note note);
        void SetNodeColor(Note note, bool changeSelection = true);
        void SetFilesPanel(bool showPanel);
    }
}

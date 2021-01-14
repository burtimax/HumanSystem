using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaryClassLibStandart.Helpers;
using LibForPersonalTool.Class.Basic;
using LibForPersonalTool.Class.Notes;

namespace DiaryWinFormsNetFramework.AppForms.NoteForm
{
    public class NoteFormModel
    {
        private string NotesDir = DirConstants.GetNotesDirectory();

        public NotesManager NotesManager;

        public NoteFormModel()
        {
            NotesManager = new NotesManager();
        }

        public Tree<string> GetFolderTree()
        {
            Tree<string> treeFolders = new Tree<string>(NotesDir);

            FillFoldersNode(ref treeFolders);

            return treeFolders;
        }

        private void FillFoldersNode(ref Tree<string> fTree)
        {
            if(fTree == null) return;

            List<string> subDir = Directory.GetDirectories(fTree.Value).ToList();
            
            if (subDir?.Count == 0)
            {
                return;
            }

            foreach (var dir in subDir)
            {
                var subTree = new Tree<string>(dir);
                fTree.Children.Add(subTree);
                FillFoldersNode(ref subTree);
            }
        }

        public List<(string fname, string fpath)> GetFiles(string folderPath)
        {
            var files = Directory.GetFiles(folderPath).ToList();
            List<(string fname, string fpath)> res = new List<(string fname, string fpath)>();
            foreach (var file in files)
            {
                HelperFileName.ParsePath(file, out var _, out var fn, out var __);
                res.Add((fn, file));
            }

            return res;
        }
    }
}

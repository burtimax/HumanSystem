using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using DiaryClassLibStandart.Helpers;
using LibForPersonalTool.Class.Basic;

namespace LibForPersonalTool.Class.Notes
{
    public class Note
    {
        private const string dtFormat = "yyyy.dd.MM HH.mm.ss";
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                if (value != _title)
                {
                    Saved = false;
                    _title = value;
                }
                
            }
        }

        private string _existedNoteFilePath = null;
        public string ExistedNoteFilePath
        {
            get { return _existedNoteFilePath; }
            set
            {
                _existedNoteFilePath = value;
            }
        }

        private string _categoryDir;
        public string CategoryDir
        {
            get { return _categoryDir; }
            set
            {
                if (value != _categoryDir)
                {
                    Saved = false;
                    _categoryDir = value;
                }
            }
        }

        public DateTime _createTime;
        public DateTime CreateTime {
            get { return _createTime; }
            private set { _createTime = value; }
        }
        private string _content;
        public string Content
        {
            get { return _content; }
            set
            {
                if (value != _content)
                {
                    Saved = false;
                    _content = value;
                }
            }
        }
        //public List<string> HashTags { get; set; }
        private string _path;
        public string Path
        {
            get
            {
                return CategoryDir +"\\" + CreateTime.ToString(dtFormat) + " {" + Title + "}.txt";
            }
            private set
            {
                if (value != _path)
                {
                    Saved = false;
                    _path = value;
                }
            }
        }
        //public bool Changed { get; set; }

        private bool _saved = false;
        public bool Saved
        {
            get { return _saved; }
            set { _saved = value; }
        }


        public Note()
        {
            Title = "note";
            Content = null;
            Saved = false;
            CreateTime = DateTime.Now;
        }

        public static bool GetNoteFromFile(string fPath, out Note note)
        {
            note = new Note();

            if (string.IsNullOrWhiteSpace(fPath)) return false;

            HelperFileName.ParsePath(fPath, out var dir, out var fname, out var ext);
            string time = fname.Remove(fname.IndexOf('{')).Trim(' ');
            note.CreateTime = DateTime.ParseExact(time, dtFormat, new NumberFormatInfo());
            note.Title = fname.Trim().Substring(fname.IndexOf('{')+1, fname.LastIndexOf('}')-fname.IndexOf('{')-1);
            note.ExistedNoteFilePath = fPath;
            note.CategoryDir = dir;
            note.Content = File.ReadAllText(fPath);
            note.Saved = true;
            return true;
        }

        
    }
}

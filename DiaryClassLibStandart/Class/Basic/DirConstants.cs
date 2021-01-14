using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DiaryClassLibStandart.Class;
using LibForPersonalTool.Class.Notes;

namespace LibForPersonalTool.Class.Basic
{
    public static class DirConstants
    {
        private static string DIARY_DIRECTORY = "\\DIARY";
        private static string PROJECT_DIRECTORY = "\\PROJECT";
        private static string IDEA_DIRECTORY = "\\IDEA";
        private static string NOTES_DIRECTORY = "\\NOTES";
        private static string NOTES_TEMP_DIRECTORY = "\\NOTES\\!TEMP";

        public static string GetMainAppDirectory()
        {
            return Settings.GetSetting(Settings.MainDirectory);
        }

        public static string GetDiaryDirectory()
        {
            CreateDirectoryIfNeed(GetMainAppDirectory() + DIARY_DIRECTORY);
            return GetMainAppDirectory() + DIARY_DIRECTORY;
        }

        public static string GetProjectDirectory()
        {
            CreateDirectoryIfNeed(GetMainAppDirectory() + PROJECT_DIRECTORY);
            return GetMainAppDirectory() + PROJECT_DIRECTORY;
        }

        public static string GetIdeaDirectory()
        {
            CreateDirectoryIfNeed(GetMainAppDirectory() + IDEA_DIRECTORY);
            return GetMainAppDirectory() + IDEA_DIRECTORY;
        }

        public static string GetNotesDirectory()
        {
            CreateDirectoryIfNeed(GetMainAppDirectory() + NOTES_DIRECTORY);
            return GetMainAppDirectory() + NOTES_DIRECTORY;
        }

        public static string GetNotesTempDirectory()
        {
            CreateDirectoryIfNeed(GetMainAppDirectory() + NOTES_TEMP_DIRECTORY);
            return GetMainAppDirectory() + NOTES_TEMP_DIRECTORY;
        }

        private static void CreateDirectoryIfNeed(string dir)
        {
            if(Directory.Exists(dir) == false)
            {
                Directory.CreateDirectory(dir);
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DiaryClassLibStandart.Helpers;
using LibForPersonalTool.Class.Basic;

namespace DiaryClassLibStandart.Class.TaskClass
{
    /// <summary>
    /// Class, which represents project entity for task manager
    /// </summary>
    public class MyProject
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public string Description { get; set; }
        public MyTask TaskRoot { get; set; }

        public string ProjectFilePath
        {
            get
            {
                if (string.IsNullOrEmpty(this.Name)) return null;
                return DirConstants.GetProjectDirectory() + "\\" + this.Name + ".xml";
            }
        }

        private MyProject()
        {
            this.CreateTime = DateTime.Now;
            this.Id = KeyGenerator.CreateIntegerKey(this).ToString();
        }

        public MyProject(string name):this()
        {
            this.Name = name;
        }
    }
}

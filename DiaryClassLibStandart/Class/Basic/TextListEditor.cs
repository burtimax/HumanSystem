using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using LibForPersonalTool.Abstract;

namespace LibForPersonalTool.Class.Basic
{
    public class TextListEditor:BaseTextEditor
    {
        Regex startSpaces = new Regex(@"^\s*");
        Regex listItem = new Regex(@"^(?<spaces>\s*)(((?<number>[\.\d]*\d+)(?<sign>[\.)\]\:\;\/ ]))|(?<signs>[#*@+-]*))(?<lastSpace>\s*)", RegexOptions.Singleline);

        public TextListEditor(TextBoxBase textBox) : base(textBox)
        {

        }

        protected override void ProcessTextChange(object sender, EventArgs e)
        {
            int index = TextBox.SelectionStart;
            if (KeysData == Keys.Tab)
            {
                Process_Key_Tab(ref index);
            }

            if(KeysData == Keys.Enter)
            {
                Process_Key_Enter(ref index);
            }

            if(KeysData == Keys.Back)
            {
                Process_Key_Backspace(ref index);
            }

            TextBox.SelectionStart = index;
            base.ProcessTextChange(sender, e);
        }

        private void Process_Key_Tab(ref int index)
        {
            Text = Text.Remove(index-1, 1);
            index--;
            var lineIndex = TextBox.GetLineFromCharIndex(index);
            //var prevLine = TextBox.Lines[lineIndex - 1];
            var curLine = TextBox.Lines.Length>0?TextBox?.Lines[lineIndex]:null;

            //If List Item Set Next Level
            if (curLine != null && SetNextLevelListItemIfNeed(ref index, curLine))
            {
                return;
            }

            //Insert Empty spaces
            Text = Text.Insert(index, "    ");
            index += 4;
        }

        private void Process_Key_Backspace(ref int index)
        {
            var lineIndex = TextBox.GetLineFromCharIndex(index);
            int firstIndexCurLine = TextBox.GetFirstCharIndexOfCurrentLine();
            string strLineBeforeCurIndex = Text.Substring(firstIndexCurLine, index - firstIndexCurLine);

            //Delete empty spaces
            if (strLineBeforeCurIndex.EndsWith(" "))
            {
                int countSpacesToRemove = Math.Min(3, strLineBeforeCurIndex.Length - strLineBeforeCurIndex.TrimEnd(' ').Length);
                Text = Text.Remove(index - countSpacesToRemove, countSpacesToRemove);
                index -= countSpacesToRemove;
            }

        }

        private void Process_Key_Enter(ref int index)
        {
            var lineIndex = TextBox.GetLineFromCharIndex(index);
            var prevLine = TextBox.Lines[lineIndex - 1];
            var curLine = TextBox.Lines[lineIndex];
            //AddStartSpacesToLine(prevLine, lineIndex, ref index);
            AddNewListItemIfNeed(ref index, curLine, prevLine);
            

        }


        private void AddNewListItemIfNeed(ref int index, string curLine, string prevLine)
        {

            var m = listItem.Match(prevLine);
            if (m.Groups["spaces"].Success == false &&
                m.Groups["sign"].Success == false 
                && (m.Groups["signs"].Success == false || string.IsNullOrWhiteSpace(m.Groups["signs"].Value))) return;

            string str = "";

            //Просто изменить глубину текущей строки
            if (string.IsNullOrWhiteSpace(prevLine)==false && m.Value?.Length>0 && string.IsNullOrWhiteSpace(prevLine.Replace(m.Value, "")))
            {
                if (m.Groups["spaces"].Success)
                {

                    string spaces = m.Groups["spaces"].Value;
                    int lenSpaces = Math.Max(0, spaces.Length - 4);
                    str += spaces.Substring(0, lenSpaces);
                }

                if (m.Groups["signs"].Success && m.Groups["signs"].Value.Length>0)
                {
                    var signs = m.Groups["signs"].Value;
                    str += signs.Remove(signs.Length - 1) + m.Groups["lastSpace"].Value;
                }

                
                if (m.Groups["sign"].Success)
                {
                    string prevNum = PreviousLevelListItem(m.Groups["number"].Value);

                    if (string.IsNullOrWhiteSpace(prevNum) == false)
                    {
                        str += prevNum;
                        str += m.Groups["sign"].Value;
                        if (m.Groups["lastSpace"].Success)
                        {
                            str += m.Groups["lastSpace"].Value;
                        }
                    }
                }

                
                index -= prevLine.Length+1;
                Text = Text.Remove(index, prevLine.Length+1);
                Text = Text.Insert(index, str);
                index += str.Length;
                return;
                
            }

            
            if (m.Groups["spaces"].Success)
            {
                str += m.Groups["spaces"].Value;
            }

            if (m.Groups["signs"].Success)
            {
                str+= m.Groups["signs"].Value + m.Groups["lastSpace"].Value;
            }

            if (m.Groups["sign"].Success)
            {
                str += NextNumberListItem(m.Groups["number"].Value);
                str += m.Groups["sign"].Value;
                if (m.Groups["lastSpace"].Success)
                {
                    str += m.Groups["lastSpace"].Value;
                }
            }

            Text = Text.Insert(index, str);
            index += str.Length;
        }

        private string NextNumberListItem(string number)
        {
            int lastPointIndex = Math.Max(0,number.LastIndexOf('.'));
            int nextInt = Convert.ToInt32(number.Substring(lastPointIndex>0?lastPointIndex+1:0))+1;
            string mainPartNumber = number.Substring(0, lastPointIndex);

            string str = "";
            if (string.IsNullOrWhiteSpace(mainPartNumber) == false)
            {
                str += mainPartNumber += ".";
            }

            str += nextInt.ToString();
            return str;
        }

        private string PreviousNumberListItem(string number)
        {
            int lastPointIndex = Math.Max(0, number.LastIndexOf('.'));
            int nextInt = Convert.ToInt32(number.Substring(lastPointIndex > 0 ? lastPointIndex + 1 : 0)) - 1;
            string mainPartNumber = number.Substring(0, lastPointIndex);

            string str = "";
            if (string.IsNullOrWhiteSpace(mainPartNumber) == false)
            {
                str += mainPartNumber += ".";
            }

            str += nextInt.ToString();
            return str;
        }

        private string PreviousLevelListItem(string number)
        {
            int lastPointIndex = Math.Max(0, number.LastIndexOf('.'));
            string mainPartNumber = number.Substring(0, lastPointIndex);

            if (lastPointIndex == 0) return "";

            return NextNumberListItem(mainPartNumber);
        }

        private string NextLevelListItem(string number)
        {
            return number += ".1";
        }

        private void AddStartSpacesToLine(string prevLine, int curLineIndex, ref int index)
        {
            var startSpaces = this.startSpaces.Match(prevLine);
            if (startSpaces.Success)
            {
                Text = Text.Insert(index, startSpaces.Value);
            }

            index += startSpaces.Value.Length;
        }


        private bool SetNextLevelListItemIfNeed(ref int index, string curLine)
        {
            var m = listItem.Match(curLine);
            string str = "";
            if (m.Value.Length == curLine.Length)
            {
                if (m.Groups["sign"].Value.Length > 0)
                {
                    str = "";
                    string number = NextLevelListItem(PreviousNumberListItem(m.Groups["number"].Value));
                    str += m.Groups["spaces"].Value + "    ";
                    str += number + m.Groups["sign"].Value + m.Groups["lastSpace"].Value;
                }

                if (m.Groups["signs"].Value.Length > 0)
                {
                    str = "";
                    str += m.Groups["spaces"].Value + "    ";
                    str += m.Groups["signs"].Value + m.Groups["signs"].Value.Last() + m.Groups["lastSpace"].Value;
                }

                var firstLineIndex = TextBox.GetFirstCharIndexFromLine(TextBox.GetLineFromCharIndex(index));
                Text = Text.Remove(firstLineIndex, curLine.Length);
                Text = Text.Insert(firstLineIndex, str);
                index = firstLineIndex + str.Length;
                return true;
            }

            return false;
        }
    }
}

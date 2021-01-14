using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LibForPersonalTool.Abstract
{
    public class BaseTextEditor
    {
        public delegate void TextChange(KeyEventArgs e);

        public event TextChange TextChangedForProcessor;

        protected TextBoxBase TextBox { get; set; }

        protected Keys KeysData;

        protected string Text
        {
            get { return TextBox.Text; }
            set { TextBox.Text = value; }
        }

        public BaseTextEditor(TextBoxBase textBox)
        {
            TextBox = textBox;
            TextBox.KeyDown -= OnKeyDown;
            TextBox.KeyDown += OnKeyDown;

            TextBox.TextChanged -= ProcessTextChange;
            TextBox.TextChanged += ProcessTextChange;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            KeysData = e.KeyData;
        }

        protected virtual void ProcessTextChange(object sender, EventArgs e)
        {

        }
    }
}

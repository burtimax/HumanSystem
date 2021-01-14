using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiaryWinFormsNetFramework.HelpersConstants;

namespace DiaryWinFormsNetFramework.UserControls
{
    public partial class TextContainer : UserControl, IDisposable
    {
        private string DefaultTitle = "";
        Color _colorBorder = Constants.COLOR_CONTROL;
        private EventHandler _titleChangeEventHandler;
        public EventHandler TitleChangeEventHandler
        {
            private get { return _titleChangeEventHandler; }
            set
            {
                this._titleChangeEventHandler = value;
                this.textBoxTitle.TextChanged -= _titleChangeEventHandler;
                this.textBoxTitle.TextChanged += _titleChangeEventHandler;
            }
        }

        public TextContainer()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            this.textBoxTitle.Text = this.DefaultTitle;
            this.TitleReadOnly = false;
        }

        public TextContainer(string defaultTitle):this()
        {
            this.DefaultTitle = defaultTitle;           
        }

        [Description("Test text displayed in the textbox"), Category("Data")]
        public string Title
        {
            get { return textBoxTitle.Text; }
            set 
            {               
                textBoxTitle.Text = value;

                if (string.IsNullOrEmpty(textBoxTitle.Text) == true)
                {
                    textBoxTitle.Text = this.DefaultTitle;
                }
            }
        }

        [Description("Can Edit Title"), Category("Data")]
        public bool TitleReadOnly
        {
            get { return textBoxTitle.ReadOnly; }
            set
            {
                textBoxTitle.ReadOnly = value;
            }
        }

        [Description("Border color"), Category("Data")]
        public Color ColorBorder
        {
            get
            {
                return _colorBorder;
            }
            set
            {
                _colorBorder = value;
            }
        }

        public RichTextBox TextField
        {
            get
            {
                return this.rtbField;
            }
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            //Set TitlePanel BackGround Color
            this.topPanel.BackColor = this.ColorBorder;
            this.textBoxTitle.BackColor = this.ColorBorder;
            //Set Border to Text Container
            using (Pen pen = new Pen(ColorBorder, 6))
            {
                Rectangle rect = this.mainPanel.ClientRectangle;
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                //ControlPaint.DrawBorder(pen, this.mainPanel.ClientRectangle, Color.FromArgb(219, 219, 219), ButtonBorderStyle.Solid);
                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        public void Select()
        {
            this.rtbField.Select();
            if(string.IsNullOrWhiteSpace(this.rtbField.Text) == false)
            {
                this.rtbField.Select(rtbField.Text.Length, 0);
            }
        }

        public void SelectTitleTextBox()
        {
            this.textBoxTitle.SelectionStart = this.textBoxTitle.Text.Length;
            this.textBoxTitle.SelectionLength = 0;
            this.textBoxTitle.Select();
        }

        public void Dispose()
        {
            textBoxTitle.TextChanged -= TitleChangeEventHandler;
            _titleChangeEventHandler = null;
            TitleChangeEventHandler = null;
        }

       
    }
}

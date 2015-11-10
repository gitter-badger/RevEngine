using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace RevEngine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.Transparent;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.None;
            this.TransparencyKey = Color.Black;
            this.BackColor = Color.Black;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowIcon = false;
            ShowInTaskbar = false;
            pictureBox1.Click += leShown;
            
        }
        private void leShown(Object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Load(object sender, EventArgs e)
        {
            BackColor = Color.Transparent;
        }
        //OnPaintBackground

    }
}

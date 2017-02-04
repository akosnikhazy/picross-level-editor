using System;
using System.Windows.Forms;

namespace PicrossEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tenten_Click(object sender, EventArgs e)
        {//open ten by ten editor and hide editor selector
            var editor = new Editor(10,10);
            editor.Show();
            this.Hide();
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {//so it closes properly
            Application.Exit();
        }
    }
}

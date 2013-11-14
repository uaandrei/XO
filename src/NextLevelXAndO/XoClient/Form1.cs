using System;
using System.Windows.Forms;
using Xo.Business;
using Xo.Gui;
using Xo.Model;

namespace XoClient
{
    public partial class Form1 : Form
    {
        private XoGameGui _xoGameGui;

        public Form1()
        {
            InitializeComponent();
            _xoGameGui = new XoGameGui(new XoGame(0))
            {
                Dock = DockStyle.Fill
            };
            panel1.Controls.Add(_xoGameGui);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _xoGameGui.UpdateGame();
        }
    }
}

using System;
using System.Windows.Forms;
using Xo.Business;
using Xo.Gui;
using Xo.Model;

namespace Xo.Client
{
    public partial class Form1 : Form
    {
        private readonly XoGameGui _xoGameGui;
        private XoGame _game;

        public Form1()
        {
            InitializeComponent();
            _game = new XoGame(new Player(XoValue.FirstPlayer));
            _xoGameGui = new XoGameGui
            {
                Dock = DockStyle.Fill
            };
            panel1.Controls.Add(_xoGameGui);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _xoGameGui.UpdateGame(_game);
        }
    }
}

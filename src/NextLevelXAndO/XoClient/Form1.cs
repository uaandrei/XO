using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xo.Business;
using Xo.Gui;
using Xo.Model;

namespace XoClient
{
    public partial class Form1 : Form
    {
        private XoGameGui _xoGameGui;
        private XoGame _xoGame;

        public Form1()
        {
            InitializeComponent();
            _xoGameGui = new XoGameGui
            {
                Dock = DockStyle.Fill
            };
            panel1.Controls.Add(_xoGameGui);
            _xoGame = new XoGame(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _xoGameGui.UpdateGame(_xoGame);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _xoGame.MarkCurrentTableOn(new XoPoint(int.Parse(textBox1.Text)-1, int.Parse(textBox2.Text)));
            _xoGameGui.UpdateGame(_xoGame);
        }
    }
}

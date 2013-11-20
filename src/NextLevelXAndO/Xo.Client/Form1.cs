﻿using System;
using System.Windows.Forms;
using Xo.Business;
using Xo.Gui;

namespace Xo.Client
{
    public partial class Form1 : Form
    {
        private readonly XoGameGui _xoGameGui;

        public Form1()
        {
            InitializeComponent();
            _xoGameGui = new XoGameGui(new XoGame())
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

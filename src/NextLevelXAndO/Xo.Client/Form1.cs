using System;
using System.Windows.Forms;
using Xo.Business;
using Xo.Client.ServiceReference1;
using Xo.Gui;
using Xo.Model;

namespace Xo.Client
{
    public partial class Form1 : Form
    {
        private readonly XoGameGui _xoGameGui;
        private XoGame _game = new XoGame();
        private XoGameServiceClient _client;

        public Form1()
        {
            InitializeComponent();
            _client = new XoGameServiceClient();
            _client.StartGame();
            _xoGameGui = new XoGameGui(new Player(XoValue.FirstPlayer), _game)
            {
                Dock = DockStyle.Fill
            };
            panel1.Controls.Add(_xoGameGui);
            _game.Spaces.ForEach(p => p.Marked += (s, e) =>
            {
                var space = (XoSpace)s;
                var data = _client.UpdateGame(new[] { _game.Spaces.IndexOf(space), (int)space.Value });
                _xoGameGui.UpdateGame(data[0], data[1]);
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _xoGameGui.UpdateGame(0, 0);
        }
    }
}

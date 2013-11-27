using System.Windows.Forms;
using Xo.Business;
using Xo.Gui;
using Xo.Model;

namespace Xo.Service
{
    public partial class XoGameForm : Form
    {
        private XoGameGui _xoGameGui;
        private XoGame _xoGame = new XoGame();
        private int[] _data;

        public int[] Data
        {
            get
            {
                return _data;
            }
        }

        public XoGameForm()
        {
            InitializeComponent();
            _xoGameGui = new XoGameGui(new Player(XoValue.SecondPlayer), _xoGame)
            {
                Dock = DockStyle.Fill
            };
            Controls.Add(_xoGameGui);
            _xoGame.Spaces.ForEach(p => p.Marked += (s, e) =>
            {
                var space = (XoSpace)s;
                _data = new[] { _xoGame.Spaces.IndexOf(space), (int)space.Value };
            });
        }

        public void UpdateGame(int spaceNo, int value)
        {
            _xoGameGui.UpdateGame(spaceNo, value);
        }
    }
}

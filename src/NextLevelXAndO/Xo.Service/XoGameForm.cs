using System.Windows.Forms;
using Xo.Business;
using Xo.Gui;

namespace Xo.Service
{
    public partial class XoGameForm : Form
    {
        private XoGameGui _xoGameGui;

        public XoGameForm()
        {
            InitializeComponent();
            _xoGameGui = new XoGameGui
            {
                Dock = DockStyle.Fill
            };
            Controls.Add(_xoGameGui);
        }

        public void UpdateGame(XoGame xoGame)
        {
            _xoGameGui.UpdateGame(xoGame);
        }
    }
}

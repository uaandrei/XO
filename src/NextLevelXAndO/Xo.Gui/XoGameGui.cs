using System.Drawing;
using System.Windows.Forms;
using Xo.Business;
using Xo.Model;

namespace Xo.Gui
{
    public partial class XoGameGui : UserControl
    {
        private readonly Player _player;

        private readonly XoGame _xoGame;

        public XoGameGui(Player player, XoGame xoGame)
        {
            _player = player;
            _xoGame = xoGame;
            InitializeComponent();
        }

        private void XoGameGui_Load(object sender, System.EventArgs e)
        {
        }

        public void UpdateGame(int spaceNo, int value)
        {
            _xoGame.Spaces[spaceNo].Value = (XoValue)value;
            Controls.Clear();
            var tableWidth = Width / 3;
            var tableHeight = Height / 3;
            foreach (var table in _xoGame.Tables)
            {
                var panel = new Panel
                {
                    Size = new Size(tableWidth, tableHeight),
                    Location = new Point(table.Position.Y * tableWidth, table.Position.X * tableHeight),
                    Tag = table
                };
                if (table.Position == _xoGame.Spaces[spaceNo].Position)
                {
                    panel.BackColor = Color.Black;
                }
                Controls.Add(panel);
                var buttonWidth = panel.Width / 3;
                var buttonHeight = panel.Height / 3;
                foreach (var space in table.XoSpaces)
                {
                    var button = new Button
                    {
                        Size = new Size(buttonWidth, buttonHeight),
                        Location = new Point(space.Position.Y * buttonWidth, space.Position.X * buttonHeight),
                        Tag = space,
                        BackColor = GetColorForValue(space.Value)
                    };
                    panel.Controls.Add(button);
                    button.Click += (s, e) =>
                    {
                        foreach (Control control in Controls)
                        {
                            control.BackColor = SystemColors.Control;
                        }
                        var btn = (Button)s;
                        var sp = (XoSpace)btn.Tag;
                        _xoGame.MarkSpace(sp, _player);
                        btn.BackColor = GetColorForValue(sp.Value);
                        btn.Parent.BackColor = Color.Black;
                    };
                }
            }
        }

        private Color GetColorForValue(XoValue xoValue)
        {
            switch (xoValue)
            {
                case XoValue.FirstPlayer:
                    return Color.Blue;
                case XoValue.SecondPlayer:
                    return Color.Red;
                default:
                    return Color.Gray;
            }
        }
    }
}

using System.Drawing;
using System.Windows.Forms;
using Xo.Business;
using Xo.Model;

namespace Xo.Gui
{
    public partial class XoGameGui : UserControl
    {
        private readonly XoGame _game;

        public XoGameGui(XoGame game)
        {
            _game = game;
            InitializeComponent();
        }

        private void XoGameGui_Load(object sender, System.EventArgs e)
        {
            UpdateGame();
        }

        public void UpdateGame()
        {
            Controls.Clear();
            var tableWidth = Width / 3;
            var tableHeight = Height / 3;
            foreach (var table in _game.Tables)
            {
                var panel = new Panel
                {
                    Size = new Size(tableWidth, tableHeight),
                    Location = new Point(table.Position.X * tableWidth, table.Position.Y * tableHeight),
                    Tag = table
                };
                Controls.Add(panel);
                var buttonWidth = panel.Width / 3;
                var buttonHeight = panel.Height / 3;
                foreach (var space in table.XoSpaces)
                {
                    var button = new Button
                    {
                        Size = new Size(buttonWidth, buttonHeight),
                        Location = new Point(space.Position.X * buttonWidth, space.Position.Y * buttonHeight),
                        Tag = space
                    };
                    panel.Controls.Add(button);
                    button.Click += (s, e) =>
                    {
                        foreach(Control control in Controls)
                        {
                            control.BackColor = SystemColors.Control;
                        }
                        var btn = (Button)s;
                        var sp = (XoSpace)btn.Tag;
                        sp.Mark(new Player(XoValue.OccupiedByFirstPlayer));
                        btn.BackColor = GetColorForValue(sp.Value);
                        var parentPanel = btn.Parent;
                        parentPanel.BackColor = Color.Black;
                    };
                }
            }
        }

        private Color GetColorForValue(XoValue xoValue)
        {
            switch (xoValue)
            {
                case XoValue.OccupiedByFirstPlayer:
                    return Color.Blue;
                case XoValue.OccupiedBySecondPlayer:
                    return Color.Red;
                default:
                    return Color.Gray;
            }
        }
    }
}

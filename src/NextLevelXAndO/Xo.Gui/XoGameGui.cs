using System.Drawing;
using System.Windows.Forms;
using Xo.Business;
using Xo.Model;

namespace Xo.Gui
{
    public partial class XoGameGui : UserControl
    {
        private readonly XoGame _game;
        private int _buttonWidth;
        private int _buttonHeight;

        public XoGameGui(XoGame game)
        {
            _game = game;
            InitializeComponent();
        }

        public void UpdateGame()
        {
            SetButtonDimensions();
            Controls.Clear();
            var tables = _game.Tables;
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    var table = tables[i, j];
                    for (var ii = 0; ii < table.Length; ii++)
                    {
                        for (var jj = 0; jj < table.Length; jj++)
                        {
                            AddNewButtonToWithValue(i, j, ii, jj, table[ii, jj]);
                        }
                    }
                }
            }
        }

        private void SetButtonDimensions()
        {
            _buttonWidth = Width / 12;
            _buttonHeight = Height / 12;
        }

        private void AddNewButtonToWithValue(int i, int j, int ii, int jj, XoValue xoValue)
        {
            var buttonXLocation = i * (3 * _buttonWidth) + ii * _buttonWidth;
            var buttonYLocation = j * (3 * _buttonHeight) + jj * _buttonHeight;

            var button = new Button
            {
                Size = new Size(_buttonWidth, _buttonHeight),
                Location = new Point(buttonXLocation, buttonYLocation),
                BackColor = GetColorForValue(xoValue),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                Tag = string.Format("{0}{1}{2}{3}", i, j, ii, jj)
            };
            button.Click += (s, e) =>
            {
                var btn = (Button)s;
                var text = btn.Tag.ToString();
                var coordX = int.Parse(text[2].ToString());
                var coordY = int.Parse(text[3].ToString());

                _game.MarkCurrentTableOn(new XoPoint(coordX, coordY));
                UpdateGame();
            };
            Controls.Add(button);
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

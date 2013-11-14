using System.Drawing;
using System.Windows.Forms;
using Xo.Business;
using Xo.Model;

namespace Xo.Gui
{
    public partial class XoGameGui : UserControl
    {
        private int _buttonWidth;
        private int _buttonHeight;

        public XoGameGui()
        {
            InitializeComponent();
        }

        public void UpdateGame(XoGame game)
        {
            SetButtonDimensions();
            Controls.Clear();
            var tables = game.Tables;
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    var table = tables[i, j];
                    for (var ii = 0; ii < table.Length; ii++)
                    {
                        for (var jj = 0; jj < table.Length; jj++)
                        {
                            var buttonXLocation = i * (3 * _buttonWidth) + ii * _buttonWidth;
                            var buttonYLocation = j * (3 * _buttonHeight) + jj * _buttonHeight;
                            AddNewButtonToWithValue(buttonXLocation, buttonYLocation, table[ii, jj]);
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

        private void AddNewButtonToWithValue(int pX, int pY, XoValue xoValue)
        {
            var button = new Button
            {
                Size = new Size(_buttonWidth, _buttonHeight),
                Location = new Point(pX, pY),
                BackColor = GetColorForValue(xoValue),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right
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

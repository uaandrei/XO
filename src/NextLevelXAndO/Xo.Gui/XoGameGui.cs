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
            foreach (var xoSpace in _game.Spaces)
            {
                AddNewButtonToWithValue(xoSpace, XoValue.FreeSpace);
            }
        }

        private void SetButtonDimensions()
        {
            _buttonWidth = Width / 12;
            _buttonHeight = Height / 12;
        }

        private void AddNewButtonToWithValue(XoSpace xoSpace, XoValue xoValue)
        {
            var buttonXLocation = xoSpace.Parent.Position.X * (3 * _buttonWidth) + xoSpace.Position.X * _buttonWidth;
            var buttonYLocation = xoSpace.Parent.Position.Y * (3 * _buttonHeight) + xoSpace.Position.Y * _buttonHeight;

            var button = new Button
            {
                Size = new Size(_buttonWidth, _buttonHeight),
                Location = new Point(buttonXLocation, buttonYLocation),
                BackColor = GetColorForValue(xoValue),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                Tag = xoSpace
            };
            button.Click += (s, e) =>
            {
                var btn = (Button)s;
                var space = (XoSpace)btn.Tag;
                var player = new Player(XoValue.OccupiedByFirstPlayer);
                space.Mark();
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

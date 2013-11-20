using Xo.Business;

namespace Xo.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class XoGameService : IXoGameService
    {
        private XoGameForm _xoGameForm;

        public XoGame UpdateGame(XoGame xoGame)
        {
            _xoGameForm.UpdateGame(xoGame);
            _xoGameForm.ShowDialog();
            return xoGame;
        }

        public void StartGame()
        {
            _xoGameForm = new XoGameForm();
        }
    }
}

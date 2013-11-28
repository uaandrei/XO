using System.ServiceModel;

namespace Xo.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single, AddressFilterMode = AddressFilterMode.Any)]
    public class XoGameService : IXoGameService
    {
        private XoGameForm _xoGameForm;

        public int[] UpdateGame(int[] data)
        {
            _xoGameForm.UpdateGame(data[0], data[1]);
            _xoGameForm.ShowDialog();
            return _xoGameForm.Data;
        }

        public void StartGame()
        {
            _xoGameForm = new XoGameForm();
        }
    }
}

using System.ServiceModel;

namespace Xo.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IXoGameService
    {
        [OperationContract]
        int[] UpdateGame(int[] data);

        [OperationContract]
        void StartGame();
    }
}

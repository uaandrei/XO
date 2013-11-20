﻿using System.ServiceModel;
using Xo.Business;

namespace Xo.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IXoGameService
    {
        [OperationContract]
        XoGame UpdateGame(XoGame value);

        [OperationContract]
        void  StartGame();
    }
}

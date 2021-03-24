using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTAICommunicationLib
{
    public interface IFFTAICommunicationNetworkOperationConnectionStatusObserver
    {
        int ConnectedHandle();
        int DisconnectedHandle();
    }
}

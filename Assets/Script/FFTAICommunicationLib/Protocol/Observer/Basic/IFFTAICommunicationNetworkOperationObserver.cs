﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTAICommunicationLib
{
    public interface IFFTAICommunicationNetworkOperationObserver
    {
        int ReceiveMessageHandle(byte[] message, int  messageLength);
    }
}

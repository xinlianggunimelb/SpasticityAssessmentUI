﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTAICommunicationLib
{
    public interface IFFTAICommunicationInterfaceObserver
    {
        int GetFunctionType();
        

        int ModelUpdateHandle(FFTAICommunicationInterfaceModelBasic model);
    }
}

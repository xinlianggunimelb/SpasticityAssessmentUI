using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FFTAICommunicationLib;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationInterfaceModelBasic
    {
        public FFTAICommunicationDataSectionModelSelected DataSectionModel;

        // model initilization
        public FFTAICommunicationInterfaceModelBasic()
        {
            DataSectionModel = new FFTAICommunicationDataSectionModelSelected();
        }
    
    }

}

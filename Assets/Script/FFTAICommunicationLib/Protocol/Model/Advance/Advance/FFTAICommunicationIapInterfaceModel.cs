using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FFTAICommunicationLib;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationIAPInterfaceModel
    {
        public FFTAICommunicationDataSectionModelSelected DataSectionModel;
        public FFTAICommunicationProtocolVersion  Version;
        // model initilization
        public FFTAICommunicationIAPInterfaceModel()
        {
            DataSectionModel = new FFTAICommunicationDataSectionModelSelected();
            Version = new FFTAICommunicationProtocolVersion();
        }
    
    }

}

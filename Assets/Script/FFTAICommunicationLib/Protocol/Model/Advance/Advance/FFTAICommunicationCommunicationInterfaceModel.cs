using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FFTAICommunicationLib;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationCommunicationInterfaceModel
    {
        public FFTAICommunicationDataSectionModelSelected DataSectionModel;

        // model initilization
        public FFTAICommunicationCommunicationInterfaceModel()
        {
            DataSectionModel = new FFTAICommunicationDataSectionModelSelected();
        }
    
    }

}

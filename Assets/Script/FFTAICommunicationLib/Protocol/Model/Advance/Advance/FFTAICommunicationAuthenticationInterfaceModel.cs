using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FFTAICommunicationLib;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationAuthenticationInterfaceModel
    {
        public FFTAICommunicationDataSectionModelSelected DataSectionModel;

        // model initilization
        public FFTAICommunicationAuthenticationInterfaceModel()
        {
            DataSectionModel = new FFTAICommunicationDataSectionModelSelected();
        }
    
    }

}

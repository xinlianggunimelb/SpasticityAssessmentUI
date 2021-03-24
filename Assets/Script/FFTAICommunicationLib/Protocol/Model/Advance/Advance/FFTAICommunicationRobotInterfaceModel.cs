using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FFTAICommunicationLib;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationRobotInterfaceModel
    {
        public FFTAICommunicationDataSectionModelSelected DataSectionModel;

        // model initilization
        public FFTAICommunicationRobotInterfaceModel()
        {
            DataSectionModel = new FFTAICommunicationDataSectionModelSelected();
        }
    
    }

}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationMotorInterfaceModel
    {
        public FFTAICommunicationDataSectionModelSelected DataSectionModel;

        // model initilization
        public FFTAICommunicationMotorInterfaceModel()
        {
            DataSectionModel = new FFTAICommunicationDataSectionModelSelected();
        }
    
    }

}

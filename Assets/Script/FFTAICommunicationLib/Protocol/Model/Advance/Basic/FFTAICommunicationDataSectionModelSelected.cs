using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FFTAICommunicationLib;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationDataSectionModelSelected
    {
        /// <summary>  only one v2 dataSection request model     /// </summary>
        private FFTAICommunicationV2DataSectionRequestModel v2DataSectionRequestModel;

        /// <summary>  only one v3 dataSection request model      /// </summary>
        private FFTAICommunicationV3DataSectionRequestModel v3DataSectionRequestModel;

        /// <summary>  only one v2 dataSection response model     /// </summary>
        private FFTAICommunicationV2DataSectionResponseModel v2DataSectionResponseModel;

        /// <summary>  only one v3 dataSection response model     /// </summary>
        private FFTAICommunicationV3DataSectionResponseModel v3DataSectionResponseModel;


        public FFTAICommunicationDataSectionRequestModel RequestModel
        {
            get
            {
                if (FFTAICommunicationProtocolVersion.CurrentVersion == FFTAICommunicationProtocolVersion.VERSION_2)
                {
                    if (v2DataSectionRequestModel == null)
                    {
                        v2DataSectionRequestModel = new FFTAICommunicationV2DataSectionRequestModel();
                    }
                    return v2DataSectionRequestModel;
                }
                else if (FFTAICommunicationProtocolVersion.CurrentVersion == FFTAICommunicationProtocolVersion.VERSION_3)
                {
                    if (v3DataSectionRequestModel == null)
                    {
                        v3DataSectionRequestModel = new FFTAICommunicationV3DataSectionRequestModel();
                    }
                    return v3DataSectionRequestModel;
                }
                else
                {
                    if (v2DataSectionRequestModel == null)
                    {
                        v2DataSectionRequestModel = new FFTAICommunicationV2DataSectionRequestModel();
                    }
                    return v2DataSectionRequestModel;
                }
            }
        }
        public FFTAICommunicationDataSectionResponseModel ResponseModel
        {
            get
            {
                if (FFTAICommunicationProtocolVersion.CurrentVersion == FFTAICommunicationProtocolVersion.VERSION_2)
                {
                    if (v2DataSectionResponseModel == null)
                    {
                        v2DataSectionResponseModel = new FFTAICommunicationV2DataSectionResponseModel();
                    }
                    return v2DataSectionResponseModel;
                }
                else if (FFTAICommunicationProtocolVersion.CurrentVersion == FFTAICommunicationProtocolVersion.VERSION_3)
                {
                    if (v3DataSectionResponseModel == null)
                    {
                        v3DataSectionResponseModel = new FFTAICommunicationV3DataSectionResponseModel();
                    }
                    return v3DataSectionResponseModel;
                }
                else
                {
                    if (v2DataSectionResponseModel == null)
                    {
                        v2DataSectionResponseModel = new FFTAICommunicationV2DataSectionResponseModel();
                    }
                    return v2DataSectionResponseModel;
                }
            }
        }
    }

}

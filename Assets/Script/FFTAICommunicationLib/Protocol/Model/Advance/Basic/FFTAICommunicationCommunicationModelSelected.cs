using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTAICommunicationLib
{
    /// <summary>
    /// Switch communication version(v2 or v3) in the class
    /// </summary>
    public class FFTAICommunicationCommunicationModelSelected
    {
        /// <summary>  only one v2 response model     /// </summary>
        private FFTAICommunicationV2InterfaceRequestModel V2RequestModel;

        /// <summary>  only one v3 response model     /// </summary>
        private FFTAICommunicationV3InterfaceRequestModel V3RequestModel;

        /// <summary>  only one v2 response model     /// </summary>
        private FFTAICommunicationV2InterfaceResponseModel V2ResponseModel;

        /// <summary>  only one v3 response model     /// </summary>
        private FFTAICommunicationV3InterfaceResponseModel V3ResponseModel;

        /// <summary>  Dynamic switch request model      /// </summary>
        public FFTAICommunicationInterfaceRequestModel RequestModel
        {
            get
            {
                if (FFTAICommunicationProtocolVersion.CurrentVersion == FFTAICommunicationProtocolVersion.VERSION_2)
                {
                    if (V2RequestModel == null)
                    {
                        V2RequestModel = new FFTAICommunicationV2InterfaceRequestModel();
                    }
                    return V2RequestModel;
                }
                else if (FFTAICommunicationProtocolVersion.CurrentVersion == FFTAICommunicationProtocolVersion.VERSION_3)
                {
                    if (V3RequestModel == null)
                    {
                        V3RequestModel = new FFTAICommunicationV3InterfaceRequestModel();
                    }
                    return V3RequestModel;
                }
                else
                {
                    if (V2RequestModel == null)
                    {
                        V2RequestModel = new FFTAICommunicationV2InterfaceRequestModel();
                    }
                    return V2RequestModel;
                }
            }
        }

        /// <summary>  Dynamic switch response model      /// </summary>
        public FFTAICommunicationInterfaceResponseModel ResponseModel
        {
            // in order to dynamic switch response version,I need the field "originVersion" and "currentVersion"
            get 
            {
                if (FFTAICommunicationProtocolVersion.CurrentVersion == FFTAICommunicationProtocolVersion.VERSION_2)
                {
                    if (V2ResponseModel == null)
                    {
                        V2ResponseModel = new FFTAICommunicationV2InterfaceResponseModel();
                    }
                    return V2ResponseModel;
                }
                else if (FFTAICommunicationProtocolVersion.CurrentVersion == FFTAICommunicationProtocolVersion.VERSION_3)
                {
                    if (V3ResponseModel == null)
                    {
                        V3ResponseModel = new FFTAICommunicationV3InterfaceResponseModel();
                    }
                    return V3ResponseModel;
                }
                else
                {
                    if (V2ResponseModel == null)
                    {
                        V2ResponseModel = new FFTAICommunicationV2InterfaceResponseModel();
                    }
                    return V2ResponseModel;
                }
            }
        }
    }
}

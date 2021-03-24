using System.Collections;
using System.Collections.Generic;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationInterfaceRequestModel
    {
        // whole message buffer
        public byte[] MessageBuf;
        public int MessageBufLength;

        // Header frame and end frame
        public static uint HEADER_OF_REQUEST_FRAME
        {
            get
            {
                //if protocol v2
                if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_2)
                {
                    return FFTAICommunicationV2InterfaceRequestModel.HEADER_OF_REQUEST_FRAME;
                }
                //if protocol v3
                else if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_3)
                {
                    return FFTAICommunicationV3InterfaceRequestModel.HEADER_OF_REQUEST_FRAME;
                }
                else
                {
                    // if not v2 or v3 return the header of v2
                    return FFTAICommunicationV2InterfaceRequestModel.HEADER_OF_REQUEST_FRAME;
                }
            }

        }
        public static uint END_OF_REQUEST_FRAME
        {
            get 
            {
                //if protocol v2
                if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_2)
                {
                    return FFTAICommunicationV2InterfaceRequestModel.END_OF_REQUEST_FRAME;
                }
                //if protocol v3
                else if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_3)
                {
                    return FFTAICommunicationV3InterfaceRequestModel.END_OF_REQUEST_FRAME;
                }
                else
                {
                    // if not v2 or v3 return the header of v2
                    return FFTAICommunicationV2InterfaceRequestModel.END_OF_REQUEST_FRAME;
                }
            }
        }

        public virtual int Update(byte[] message, int messageLength)
        {
            return 0;
        }

        public virtual int Update(
               byte[] frameHeaderBuf,
               byte[] communicationProtocolVersionBuf,
               byte[] robotTypeBuf,
               byte[] functionTypeBuf,
               byte[] dataSectionLengthBuf,
               byte[] dataSectionBuf,
               byte[] dataSectionParityBuf,
               byte[] endOfFrameBuf)
        {
            return 0;
        }

        public virtual int Update(
               uint frameHeader,
               uint communicationProtocolVersion,
               uint robotType,
               uint functionType,
               uint dataSectionLength,
               byte[] dataSection,
               uint dataSectionChecksum,
               uint endOfFrame)
        {
            return 0;
        }
    }
}

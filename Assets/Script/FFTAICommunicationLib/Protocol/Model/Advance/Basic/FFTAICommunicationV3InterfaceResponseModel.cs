using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationV3InterfaceResponseModel: FFTAICommunicationInterfaceResponseModel
    {
        public const int  LENGTH_OF_MESSAGE_BUF = 2048;

        public const int  LENGTH_OF_FRAME_BUF = 512;

        public const uint  HEADER_OF_RESPONSE_FRAME = 0x70717273;
        public const uint  END_OF_RESPONSE_FRAME = 0x7F;
        /*FRAME_HEADER||VERSION|DATA_SECTION_LENGTH|                DATA_SECTION                  |PARITY|END_OF_FRAME|*/
        /*70 71 72 73 ||  02  ||   00 00 00 0F    ||00 00 00 01 01 01 01 01 01 01 04 00 00 00 00 || 0B  ||     7F     |*/
        public const int  LENGTH_OF_FRAME_HEADER_BUF = 4;
        public const int  LENGTH_OF_VERSION_BUF = 1;
        public const int  LENGTH_OF_DATA_SECTION_LENGTH_BUF = 4;
        public const int  LENGTH_OF_DATA_SECTION_BUF = 500;
        public const int  LENGTH_OF_DATA_SECTION_PARITY_BUF = 1;
        public const int  LENGTH_OF_END_OF_FRAME_BUF = 1;

        // different part buffer
        public byte[] FrameHeaderBuf;
        public byte[] RobotTypeBuf;
      
        // different part variable
        public long FrameHeader;
        public byte[] DataSection;
        public long RobotType;
       
        public FFTAICommunicationV3InterfaceResponseModel()
        {
            MessageBuf = new byte[LENGTH_OF_MESSAGE_BUF];
            MessageBufLength = 0;
            MessageBufChecksum = 0;

            FrameBuf = new byte[LENGTH_OF_FRAME_BUF];
            FrameBufLength = 0;

            FrameHeaderBuf = new byte[LENGTH_OF_FRAME_HEADER_BUF];
            DataSectionLengthBuf = new byte[LENGTH_OF_DATA_SECTION_LENGTH_BUF];
            DataSectionBuf = new byte[LENGTH_OF_DATA_SECTION_BUF];
            DataSectionParityBuf = new byte[LENGTH_OF_DATA_SECTION_PARITY_BUF];
            EndOfFrameBuf = new byte[LENGTH_OF_END_OF_FRAME_BUF];

            FrameHeader = 0;
            CommunicationProtocolVersion = FFTAICommunicationProtocolVersion.VERSION_3;
            FunctionType = 0;
            DataSectionLength = 0;
            DataSection = new byte[LENGTH_OF_DATA_SECTION_BUF];
            DataSectionParity = 0;
            EndOfFrame = 0;
        }
    }
}

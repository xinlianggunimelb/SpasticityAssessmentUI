using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationV3InterfaceRequestModel: FFTAICommunicationInterfaceRequestModel
    {
        public const int  LENGTH_OF_MESSAGE_BUF = 2048;

        public const int  LENGTH_OF_FRAME_BUF = 512;

        public new const uint  HEADER_OF_REQUEST_FRAME = 0x70717273;
        public new const uint  END_OF_REQUEST_FRAME = 0x7F;

        public const int LENGTH_OF_FRAME_HEADER_BUF = 4;
        public const int LENGTH_OF_VERSION_BUF = 1;
        public const int LENGTH_OF_DATA_SECTION_LENGTH_BUF = 4;
        public const int LENGTH_OF_DATA_SECTION_BUF = 500;
        public const int LENGTH_OF_DATA_SECTION_PARITY_BUF = 1;
        public const int LENGTH_OF_END_OF_FRAME_BUF = 1;

        public const int LENGTH_OF_FUNCTION_TYPE_BUF = 4;

        // whole message buffer
        public int  MessageBufChecksum;

        // whole frame buffer
        public byte[] FrameBuf;
        public uint  FrameBufLength;

        // different part buffer
        public byte[] FrameHeaderBuf;
        public byte[] CommunicationProtocolVersionBuf;
        public byte[] RobotTypeBuf;
        public byte[] FunctionTypeBuf;
        public byte[] DataSectionLengthBuf;
        public byte[] DataSectionBuf;
        public byte[] DataSectionChecksumBuf;
        public byte[] EndOfFrameBuf;

        // different part variable
        public long FrameHeader;
        public long CommunicationProtocolVersion;
        public long RobotType;
        public long FunctionType;
        public long DataSectionLength;
        public byte[] DataSection;
        public long DataSectionChecksum;
        public long EndOfFrame;

        public FFTAICommunicationV3InterfaceRequestModel()
        {
            MessageBuf = new byte[LENGTH_OF_MESSAGE_BUF];
            MessageBufLength = 0;
            MessageBufChecksum = 0;

            FrameBuf = new byte[LENGTH_OF_FRAME_BUF];
            FrameBufLength = 0;

            FrameHeaderBuf = new byte[LENGTH_OF_FRAME_HEADER_BUF];
            CommunicationProtocolVersionBuf = new byte[LENGTH_OF_VERSION_BUF];
            FunctionTypeBuf = new byte[LENGTH_OF_FUNCTION_TYPE_BUF];
            DataSectionLengthBuf = new byte[LENGTH_OF_DATA_SECTION_LENGTH_BUF];
            DataSectionBuf = new byte[LENGTH_OF_DATA_SECTION_BUF];
            DataSectionChecksumBuf = new byte[LENGTH_OF_DATA_SECTION_PARITY_BUF];
            EndOfFrameBuf = new byte[LENGTH_OF_END_OF_FRAME_BUF];

            FrameHeader = 0;
            CommunicationProtocolVersion = FFTAICommunicationProtocolVersion.VERSION_3;
            FunctionType = 0;
            DataSectionLength = 0;
            DataSection = new byte[LENGTH_OF_DATA_SECTION_BUF];
            DataSectionChecksum = 0;
            EndOfFrame = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frameHeader"></param>
        /// <param name="communicationProtocolVersion"></param>
        /// <param name="robotType"></param>
        /// <param name="functionType"></param>
        /// <param name="dataSectionLength"></param>
        /// <param name="dataSection"></param>
        /// <param name="dataSectionParity"></param>
        /// <param name="endOfFrame"></param>
        /// <returns></returns>
        public override int Update(
            uint  frameHeader,
            uint  communicationProtocolVersion,
            uint  robotType,
            uint  functionType,
            uint  dataSectionLength,
            byte[] dataSection,
            uint  dataSectionChecksum,
            uint  endOfFrame)
        {
            // update different part buffer and variables
            FrameHeader = frameHeader;
            CommunicationProtocolVersion = communicationProtocolVersion;
            FunctionType = functionType;
            DataSectionLength = dataSectionLength;
            DataSection = dataSection;
            DataSectionChecksum = dataSectionChecksum;
            EndOfFrame = endOfFrame;

            for (int  i = 0; i < LENGTH_OF_FRAME_HEADER_BUF; i++)
            {
                FrameHeaderBuf[i] = (byte)((FrameHeader >> (8 * (LENGTH_OF_FRAME_HEADER_BUF - i - 1))) & 0xFF);
            }
            
            for (int  i = 0; i < LENGTH_OF_FUNCTION_TYPE_BUF; i++)
            {
                FunctionTypeBuf[i] = (byte)((FunctionType >> (8 * (LENGTH_OF_FUNCTION_TYPE_BUF - i - 1))) & 0xFF);
            }

            for (int i = 0; i < LENGTH_OF_VERSION_BUF; i++)
            {
                CommunicationProtocolVersionBuf[i] = (byte)((CommunicationProtocolVersion >> (8 * (LENGTH_OF_VERSION_BUF - i - 1))) & 0xFF);
            }

            for (int i = 0; i < DataSectionLength; i++)
            {
                DataSectionBuf[i] = DataSection[i];
            }

                         
            for (int  i = 0; i < LENGTH_OF_DATA_SECTION_LENGTH_BUF; i++)
            {    //for v3 ,include func type 4 bytes
                DataSectionLengthBuf[i] = (byte)((DataSectionLength +4 >> (8 * (LENGTH_OF_DATA_SECTION_LENGTH_BUF - i - 1))) & 0xFF);
            }

            for (int  i = 0; i < LENGTH_OF_DATA_SECTION_PARITY_BUF; i++)
            {
                DataSectionChecksumBuf[i] = (byte)((DataSectionChecksum >> (8 * (LENGTH_OF_DATA_SECTION_PARITY_BUF - i - 1))) & 0xFF);
            }

            for (int  i = 0; i < LENGTH_OF_END_OF_FRAME_BUF; i++)
            {
                EndOfFrameBuf[i] = (byte)((EndOfFrame >> (8 * (LENGTH_OF_END_OF_FRAME_BUF - i - 1))) & 0xFF);
            }

            // update whole message buffer
            Array.Copy(
                FrameHeaderBuf,
                0,
                MessageBuf,
                0,
                LENGTH_OF_FRAME_HEADER_BUF);

            Array.Copy(
                CommunicationProtocolVersionBuf,
                0,
                MessageBuf,
                0
                + LENGTH_OF_FRAME_HEADER_BUF,
                LENGTH_OF_VERSION_BUF);

            Array.Copy(
                DataSectionLengthBuf,
                0,
                MessageBuf,
                0
                    + LENGTH_OF_FRAME_HEADER_BUF
                    + LENGTH_OF_VERSION_BUF,
                LENGTH_OF_DATA_SECTION_LENGTH_BUF);

            Array.Copy(
               FunctionTypeBuf,
               0,
               MessageBuf,
               0
                   + LENGTH_OF_FRAME_HEADER_BUF
                   + LENGTH_OF_DATA_SECTION_LENGTH_BUF
                   + LENGTH_OF_VERSION_BUF,
               LENGTH_OF_FUNCTION_TYPE_BUF);

            Array.Copy(
                DataSectionBuf,
                0,
                MessageBuf,
                0
                   + LENGTH_OF_FRAME_HEADER_BUF
                   + LENGTH_OF_DATA_SECTION_LENGTH_BUF
                   + LENGTH_OF_FUNCTION_TYPE_BUF
                   + LENGTH_OF_VERSION_BUF,
                DataSectionLength);

            Array.Copy(
                DataSectionChecksumBuf,
                0,
                MessageBuf,
                0
                   + LENGTH_OF_FRAME_HEADER_BUF
                   + LENGTH_OF_DATA_SECTION_LENGTH_BUF
                   + LENGTH_OF_FUNCTION_TYPE_BUF
                   + LENGTH_OF_VERSION_BUF
                   + DataSectionLength,
                LENGTH_OF_DATA_SECTION_PARITY_BUF);

            Array.Copy(
                EndOfFrameBuf,
                0,
                MessageBuf,
                0
                   + LENGTH_OF_FRAME_HEADER_BUF
                   + LENGTH_OF_DATA_SECTION_LENGTH_BUF
                   + LENGTH_OF_FUNCTION_TYPE_BUF
                   + LENGTH_OF_VERSION_BUF
                   + DataSectionLength
                   + LENGTH_OF_DATA_SECTION_PARITY_BUF,
                LENGTH_OF_END_OF_FRAME_BUF);

            MessageBufLength =
                0
                + LENGTH_OF_FRAME_HEADER_BUF
                + LENGTH_OF_FUNCTION_TYPE_BUF
                + LENGTH_OF_DATA_SECTION_LENGTH_BUF
                + (int)DataSectionLength
                + LENGTH_OF_DATA_SECTION_PARITY_BUF
                + LENGTH_OF_END_OF_FRAME_BUF
                + LENGTH_OF_VERSION_BUF;

            return FunctionResult.SUCCESS;
        }
    }
}

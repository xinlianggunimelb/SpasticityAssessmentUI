﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationV2InterfaceRequestModel:FFTAICommunicationInterfaceRequestModel
    {
        public const int  LENGTH_OF_MESSAGE_BUF = 2048;

        public const int  LENGTH_OF_FRAME_BUF = 512;

        public new static uint  HEADER_OF_REQUEST_FRAME = 0xA0A1;
        public new static uint  END_OF_REQUEST_FRAME = 0xAA;

        public const int  LENGTH_OF_FRAME_HEADER_BUF = 2;
        public const int  LENGTH_OF_FUNCTION_TYPE_BUF = 4;
        public const int  LENGTH_OF_DATA_SECTION_LENGTH_BUF = 1;
        public const int  LENGTH_OF_DATA_SECTION_BUF = 500;
        public const int  LENGTH_OF_DATA_SECTION_PARITY_BUF = 1;
        public const int  LENGTH_OF_END_OF_FRAME_BUF = 1;

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

        public FFTAICommunicationV2InterfaceRequestModel()
        {
            MessageBuf = new byte[LENGTH_OF_MESSAGE_BUF];
            MessageBufLength = 0;
            MessageBufChecksum = 0;

            FrameBuf = new byte[LENGTH_OF_FRAME_BUF];
            FrameBufLength = 0;

            FrameHeaderBuf = new byte[LENGTH_OF_FRAME_HEADER_BUF];
            FunctionTypeBuf = new byte[LENGTH_OF_FUNCTION_TYPE_BUF];
            DataSectionLengthBuf = new byte[LENGTH_OF_DATA_SECTION_LENGTH_BUF];
            DataSectionBuf = new byte[LENGTH_OF_DATA_SECTION_BUF];
            DataSectionChecksumBuf = new byte[LENGTH_OF_DATA_SECTION_PARITY_BUF];
            EndOfFrameBuf = new byte[LENGTH_OF_END_OF_FRAME_BUF];

            FrameHeader = 0;
            CommunicationProtocolVersion = FFTAICommunicationProtocolVersion.VERSION_2;
            FunctionType = 0;
            DataSectionLength = 0;
            DataSection = new byte[LENGTH_OF_DATA_SECTION_BUF];
            DataSectionChecksum = 0;
            EndOfFrame = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="messageLength"></param>
        /// <returns></returns>
        public override int Update(byte[] message, int  messageLength)
        {
            // update whole message buffer
            Array.Copy(
                message,
                MessageBuf,
                messageLength);

            MessageBufLength = messageLength;

            // update different part buffer and variables
            // get frame header
            Array.Copy(
                MessageBuf,
                0,
                FrameHeaderBuf,
                0,
                LENGTH_OF_FRAME_HEADER_BUF);

            FrameHeader =
                (uint)(FrameHeaderBuf[0] << 8)
                + (uint)(FrameHeaderBuf[1] << 0);
            
            // get function type
            Array.Copy(
                MessageBuf,
                0
                    + LENGTH_OF_FRAME_HEADER_BUF,
                FunctionTypeBuf,
                0,
                LENGTH_OF_FUNCTION_TYPE_BUF);
            
            FunctionType =
                (uint)(FunctionTypeBuf[0] << 24)
                + (uint)(FunctionTypeBuf[1] << 16)
                + (uint)(FunctionTypeBuf[2] << 8)
                + (uint)(FunctionTypeBuf[3] << 0);

            // get data section length
            Array.Copy(
                MessageBuf,
                0
                    + LENGTH_OF_FRAME_HEADER_BUF
                    + LENGTH_OF_FUNCTION_TYPE_BUF,
                DataSectionLengthBuf,
                0,
                LENGTH_OF_DATA_SECTION_LENGTH_BUF);

            DataSectionLength =
                (uint)(DataSectionLengthBuf[0] << 0);

            // get data section
            Array.Copy(
                MessageBuf,
                0
                    + LENGTH_OF_FRAME_HEADER_BUF
                    + LENGTH_OF_FUNCTION_TYPE_BUF
                    + LENGTH_OF_DATA_SECTION_LENGTH_BUF,
                DataSectionBuf,
                0,
                DataSectionLength);

            DataSection = DataSectionBuf;

            // get data section parity
            Array.Copy(
                MessageBuf,
                0
                    + LENGTH_OF_FRAME_HEADER_BUF
                    + LENGTH_OF_FUNCTION_TYPE_BUF
                    + LENGTH_OF_DATA_SECTION_LENGTH_BUF
                    + DataSectionLength,
                DataSectionChecksumBuf,
                0,
                LENGTH_OF_DATA_SECTION_PARITY_BUF);

            DataSectionChecksum =
                (uint)(DataSectionChecksumBuf[0] << 0);

            // get end of frame
            Array.Copy(
                MessageBuf,
                0
                    + LENGTH_OF_FRAME_HEADER_BUF
                    + LENGTH_OF_FUNCTION_TYPE_BUF
                    + LENGTH_OF_DATA_SECTION_LENGTH_BUF
                    + DataSectionLength
                    + LENGTH_OF_DATA_SECTION_PARITY_BUF,
                EndOfFrameBuf,
                0,
                LENGTH_OF_END_OF_FRAME_BUF);

            EndOfFrame =
                (uint)(EndOfFrameBuf[0] << 0);

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frameHeaderBuf"></param>
        /// <param name="communicationProtocolVersionBuf"></param>
        /// <param name="robotTypeBuf"></param>
        /// <param name="functionTypeBuf"></param>
        /// <param name="dataSectionLengthBuf"></param>
        /// <param name="dataSectionBuf"></param>
        /// <param name="dataSectionParityBuf"></param>
        /// <param name="endOfFrameBuf"></param>
        /// <returns></returns>
        public override int Update(
            byte[] frameHeaderBuf,
            byte[] communicationProtocolVersionBuf,
            byte[] robotTypeBuf,
            byte[] functionTypeBuf,
            byte[] dataSectionLengthBuf,
            byte[] dataSectionBuf,
            byte[] dataSectionParityBuf,
            byte[] endOfFrameBuf)
        {
            // update different part buffer and variables
            // get frame header
            Array.Copy(
                frameHeaderBuf,
                0,
                FrameHeaderBuf,
                0,
                LENGTH_OF_FRAME_HEADER_BUF);

            FrameHeader =
                (uint)(FrameHeaderBuf[0] << 8)
                + (uint)(FrameHeaderBuf[1] << 0);
            
            // get function type
            Array.Copy(
                functionTypeBuf,
                0,
                FunctionTypeBuf,
                0,
                LENGTH_OF_FUNCTION_TYPE_BUF);

            FunctionType =
                (uint)(FunctionTypeBuf[0] << 24)
                + (uint)(FunctionTypeBuf[1] << 16)
                + (uint)(FunctionTypeBuf[2] << 8)
                + (uint)(FunctionTypeBuf[3] << 0);

            // get data section length
            Array.Copy(
                dataSectionLengthBuf,
                0,
                DataSectionLengthBuf,
                0,
                LENGTH_OF_DATA_SECTION_LENGTH_BUF);

            DataSectionLength =
                (uint)(DataSectionLengthBuf[0] << 0);

            // get data section
            Array.Copy(
                dataSectionBuf,
                0,
                DataSectionBuf,
                0,
                DataSectionLength);

            DataSection = DataSectionBuf;

            // get data section parity
            Array.Copy(
                dataSectionParityBuf,
                0,
                DataSectionChecksumBuf,
                0,
                LENGTH_OF_DATA_SECTION_PARITY_BUF);

            DataSectionChecksum =
                (uint)(DataSectionChecksumBuf[0] << 0);

            // get end of frame
            Array.Copy(
                endOfFrameBuf,
                0,
                EndOfFrameBuf,
                0,
                LENGTH_OF_END_OF_FRAME_BUF);

            EndOfFrame =
                (uint)(EndOfFrameBuf[0] << 0);

            // update whole message buffer
            Array.Copy(
                FrameHeaderBuf,
                0,
                MessageBuf,
                0,
                LENGTH_OF_FRAME_HEADER_BUF);
            
            Array.Copy(
                FunctionTypeBuf,
                0,
                MessageBuf,
                0
                    + LENGTH_OF_FRAME_HEADER_BUF,
                LENGTH_OF_FUNCTION_TYPE_BUF);

            Array.Copy(
                DataSectionLengthBuf,
                0,
                MessageBuf,
                0
                    + LENGTH_OF_FRAME_HEADER_BUF
                    + LENGTH_OF_FUNCTION_TYPE_BUF,
                LENGTH_OF_DATA_SECTION_LENGTH_BUF);

            Array.Copy(
                DataSectionBuf,
                0,
                MessageBuf,
                0
                    + LENGTH_OF_FRAME_HEADER_BUF
                    + LENGTH_OF_FUNCTION_TYPE_BUF
                    + LENGTH_OF_DATA_SECTION_LENGTH_BUF,
                DataSectionLength);

            Array.Copy(
                DataSectionChecksumBuf,
                0,
                MessageBuf,
                0
                    + LENGTH_OF_FRAME_HEADER_BUF
                    + LENGTH_OF_FUNCTION_TYPE_BUF
                    + LENGTH_OF_DATA_SECTION_LENGTH_BUF
                    + DataSectionLength,
                LENGTH_OF_DATA_SECTION_PARITY_BUF);

            Array.Copy(
                EndOfFrameBuf,
                0,
                MessageBuf,
                0
                    + LENGTH_OF_FRAME_HEADER_BUF
                    + LENGTH_OF_FUNCTION_TYPE_BUF
                    + LENGTH_OF_DATA_SECTION_LENGTH_BUF
                    + DataSectionLength
                    + LENGTH_OF_DATA_SECTION_PARITY_BUF,
                LENGTH_OF_END_OF_FRAME_BUF);

            MessageBufLength =
                0 
                + LENGTH_OF_FRAME_HEADER_BUF
                + LENGTH_OF_FUNCTION_TYPE_BUF
                + LENGTH_OF_DATA_SECTION_LENGTH_BUF
                + (int )DataSectionLength
                + LENGTH_OF_DATA_SECTION_PARITY_BUF
                + LENGTH_OF_END_OF_FRAME_BUF;

            return FunctionResult.SUCCESS;
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

            for (int  i = 0; i < LENGTH_OF_DATA_SECTION_LENGTH_BUF; i++)
            {
                DataSectionLengthBuf[i] = (byte)((DataSectionLength >> (8 * (LENGTH_OF_DATA_SECTION_LENGTH_BUF - i - 1))) & 0xFF);
            }

            for (int  i = 0; i < DataSectionLength; i++)
            {
                DataSectionBuf[i] = DataSection[i];
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
                FunctionTypeBuf,
                0,
                MessageBuf,
                0
                    + LENGTH_OF_FRAME_HEADER_BUF,
                LENGTH_OF_FUNCTION_TYPE_BUF);

            Array.Copy(
                DataSectionLengthBuf,
                0,
                MessageBuf,
                0
                    + LENGTH_OF_FRAME_HEADER_BUF
                    + LENGTH_OF_FUNCTION_TYPE_BUF,
                LENGTH_OF_DATA_SECTION_LENGTH_BUF);

            Array.Copy(
                DataSectionBuf,
                0,
                MessageBuf,
                0
                    + LENGTH_OF_FRAME_HEADER_BUF
                    + LENGTH_OF_FUNCTION_TYPE_BUF
                    + LENGTH_OF_DATA_SECTION_LENGTH_BUF,
                DataSectionLength);

            Array.Copy(
                DataSectionChecksumBuf,
                0,
                MessageBuf,
                0
                    + LENGTH_OF_FRAME_HEADER_BUF
                    + LENGTH_OF_FUNCTION_TYPE_BUF
                    + LENGTH_OF_DATA_SECTION_LENGTH_BUF
                    + DataSectionLength,
                LENGTH_OF_DATA_SECTION_PARITY_BUF);

            Array.Copy(
                EndOfFrameBuf,
                0,
                MessageBuf,
                0
                    + LENGTH_OF_FRAME_HEADER_BUF
                    + LENGTH_OF_FUNCTION_TYPE_BUF
                    + LENGTH_OF_DATA_SECTION_LENGTH_BUF
                    + DataSectionLength
                    + LENGTH_OF_DATA_SECTION_PARITY_BUF,
                LENGTH_OF_END_OF_FRAME_BUF);

            MessageBufLength =
                0
                + LENGTH_OF_FRAME_HEADER_BUF
                + LENGTH_OF_FUNCTION_TYPE_BUF
                + LENGTH_OF_DATA_SECTION_LENGTH_BUF
                + (int )DataSectionLength
                + LENGTH_OF_DATA_SECTION_PARITY_BUF
                + LENGTH_OF_END_OF_FRAME_BUF;

            return FunctionResult.SUCCESS;
        }
    }
}

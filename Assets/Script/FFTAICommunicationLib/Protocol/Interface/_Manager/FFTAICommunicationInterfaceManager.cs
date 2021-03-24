using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationInterfaceManager: IFFTAICommunicationNetworkOperationObserver
    {
        public FFTAICommunicationCommunicationModelSelected Model;

        public FFTAICommunicationInterfaceManager()
        {
            Model = new FFTAICommunicationCommunicationModelSelected();
        }

        /// <summary>
        ///  data parse for v2
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="bufferLength"></param>
        /// <returns></returns>
        public int ParseV2Data()
        {
            int i = 0;
            int temp = 0;
            int frameStartIndex = 0;
            int frameLength = 0;
            byte dataSectionParity = 0;
            byte dataSectionParityCalculated = 0;
            byte endOfFrame = 0;

            _parseStart: // Note : label cannot be used before variables definition

            // is the buffer has enough the minimum requested length ?
            if (Model.ResponseModel.MessageBufLength - frameStartIndex
                < FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_FRAME_HEADER_BUF
                    + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_FUNCTION_TYPE_BUF
                    + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_DATA_SECTION_LENGTH_BUF
                    + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_DATA_SECTION_PARITY_BUF
                    + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_END_OF_FRAME_BUF)
            {
                return FunctionResult.FAIL;
            }

            // is the buffer has the (0xA0 0xA1) frame header ?
            for (;
                i < Model.ResponseModel.MessageBufLength - 1;
                i++)
            {
                if (Model.ResponseModel.MessageBuf[i] == (byte)(FFTAICommunicationV2InterfaceResponseModel.HEADER_OF_RESPONSE_FRAME >> 8 & 0xFF)
                    && Model.ResponseModel.MessageBuf[i + 1] == (byte)(FFTAICommunicationV2InterfaceResponseModel.HEADER_OF_RESPONSE_FRAME >> 0 & 0xFF))
                {
                    temp = 1;
                    frameStartIndex = i;

                    break;
                }

                temp = 0;
            }

            if (temp == 0)
            {
                // no frame header
                return FunctionResult.FAIL;
            }

            // 2. the minimum data frame length request
            if (frameStartIndex
                + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_FRAME_HEADER_BUF
                + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_FUNCTION_TYPE_BUF
                + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_DATA_SECTION_LENGTH_BUF
                + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_DATA_SECTION_PARITY_BUF
                + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_END_OF_FRAME_BUF
                < Model.ResponseModel.MessageBufLength)
            {
                Model.ResponseModel.DataSectionLength =
                    Model.ResponseModel.MessageBuf[frameStartIndex
                        + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_FRAME_HEADER_BUF
                        + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_FUNCTION_TYPE_BUF];
            }
            else
            {
                // not enough data
                i = frameStartIndex + 1;
                temp = 0;

                goto _parseStart;
            }

            // 3. is the buffer has the whole frame ?
            frameLength =
                FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_FRAME_HEADER_BUF
                    + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_FUNCTION_TYPE_BUF
                    + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_DATA_SECTION_LENGTH_BUF
                    + (int)Model.ResponseModel.DataSectionLength
                    + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_DATA_SECTION_PARITY_BUF
                    + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_END_OF_FRAME_BUF;

            if (frameStartIndex + frameLength <= Model.ResponseModel.MessageBufLength)
            {
            }
            else
            {
                // not enough data
                i = frameStartIndex + 1;
                temp = 0;

                goto _parseStart;
            }

            // 4. data section parity check
            dataSectionParity =
                Model.ResponseModel.MessageBuf[
                    frameStartIndex
                    + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_FRAME_HEADER_BUF
                    + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_FUNCTION_TYPE_BUF
                    + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_DATA_SECTION_LENGTH_BUF
                    + Model.ResponseModel.DataSectionLength];

            dataSectionParityCalculated = 0;

            for (int j = 0; j < Model.ResponseModel.DataSectionLength; j++)
            {
                dataSectionParityCalculated =
                    (byte)(
                        dataSectionParityCalculated
                        + Model.ResponseModel.MessageBuf[
                            frameStartIndex
                            + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_FRAME_HEADER_BUF
                            + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_FUNCTION_TYPE_BUF
                            + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_DATA_SECTION_LENGTH_BUF
                            + j]);
            }

            if (dataSectionParity == dataSectionParityCalculated)
            {

            }
            else
            {
                // not match parity check
                i = frameStartIndex + 1;
                temp = 0;

                goto _parseStart;
            }

            // 5. end of frame check
            endOfFrame =
                Model.ResponseModel.MessageBuf[
                    frameStartIndex
                    + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_FRAME_HEADER_BUF
                    + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_FUNCTION_TYPE_BUF
                    + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_DATA_SECTION_LENGTH_BUF
                    + Model.ResponseModel.DataSectionLength
                    + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_DATA_SECTION_PARITY_BUF];

            if (endOfFrame == FFTAICommunicationV2InterfaceResponseModel.END_OF_RESPONSE_FRAME)
            {

            }
            else
            {
                // not match end of frame
                i = frameStartIndex + 1;
                temp = 0;

                goto _parseStart;
            }

            // get function type
            Array.Copy(
                Model.ResponseModel.MessageBuf,
                (int)(frameStartIndex
                    + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_FRAME_HEADER_BUF),
                Model.ResponseModel.FunctionTypeBuf,
                0,
                (int)(FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_FUNCTION_TYPE_BUF));

            Model.ResponseModel.FunctionType =
                ((uint)Model.ResponseModel.FunctionTypeBuf[0] << 24)
                + ((uint)Model.ResponseModel.FunctionTypeBuf[1] << 16)
                + ((uint)Model.ResponseModel.FunctionTypeBuf[2] << 8)
                + ((uint)Model.ResponseModel.FunctionTypeBuf[3] << 0);

            // get data section length buffer
            Array.Copy(
                Model.ResponseModel.MessageBuf,
                (int)(frameStartIndex
                    + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_FRAME_HEADER_BUF
                    + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_FUNCTION_TYPE_BUF),
                 Model.ResponseModel.DataSectionLengthBuf,
                 0,
                 (int)FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_DATA_SECTION_LENGTH_BUF);

            // get data section
            Array.Copy(
                Model.ResponseModel.MessageBuf,
                (int)(frameStartIndex
                    + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_FRAME_HEADER_BUF
                    + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_FUNCTION_TYPE_BUF
                    + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_DATA_SECTION_LENGTH_BUF),
                Model.ResponseModel.DataSectionBuf,
                0,
                (int)Model.ResponseModel.DataSectionLength);

            // get data section parity
            Array.Copy(
                Model.ResponseModel.MessageBuf,
                (int)(frameStartIndex
                    + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_FRAME_HEADER_BUF
                    + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_FUNCTION_TYPE_BUF
                    + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_DATA_SECTION_LENGTH_BUF
                    + Model.ResponseModel.DataSectionLength),
                Model.ResponseModel.DataSectionParityBuf,
                0,
                (int)(FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_DATA_SECTION_PARITY_BUF));

            Model.ResponseModel.DataSectionParity =
                ((uint)Model.ResponseModel.DataSectionParityBuf[0]);

            // get end of the frame
            Array.Copy(
                Model.ResponseModel.MessageBuf,
                (int)(frameStartIndex
                    + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_FRAME_HEADER_BUF
                    + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_FUNCTION_TYPE_BUF
                    + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_DATA_SECTION_LENGTH_BUF
                    + Model.ResponseModel.DataSectionLength
                    + FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_DATA_SECTION_PARITY_BUF),
                Model.ResponseModel.EndOfFrameBuf,
                0,
                (int)(FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_END_OF_FRAME_BUF));

            Model.ResponseModel.EndOfFrame =
                (uint)Model.ResponseModel.EndOfFrameBuf[0];

            // copy frame buffer
            Model.ResponseModel.FrameBuf = new byte[frameLength];
            Model.ResponseModel.FrameBufLength = frameLength;

            Array.Copy(
                Model.ResponseModel.MessageBuf,
                frameStartIndex,
                Model.ResponseModel.FrameBuf,
                0,
                Model.ResponseModel.FrameBufLength);

            // debug log
            // FFTAICommunicationManager.Instance.Logger.WriteLine("Success Parse Frame : " + BitConverter.ToString(Model.ResponseModel.FrameBuf));

            // remove the data ahead of this frame and the data of this frame in the buffer
            Array.Clear(
                Model.ResponseModel.MessageBuf,
                0,
                (int)(frameStartIndex + frameLength));

            Array.Copy(
                Model.ResponseModel.MessageBuf,
                (int)(frameStartIndex + frameLength),
                Model.ResponseModel.MessageBuf,
                0,
                (int)(Model.ResponseModel.MessageBufLength - (frameStartIndex + frameLength)));

            Model.ResponseModel.MessageBufLength
                = Model.ResponseModel.MessageBufLength - (frameStartIndex + frameLength);

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        /// data parse for v3
        /// </summary>
        /// <returns></returns>
        public int ParseV3Data()
        {
            int i = 0;
            int temp = 0;
            int frameStartIndex = 0;
            int frameLength = 0;
            byte dataSectionParity = 0;
            byte dataSectionParityCalculated = 0;
            byte endOfFrame = 0;

            _parseStart: // Note : label cannot be used before variables definition

            // is the buffer has enough the minimum requested length ?
            if (Model.ResponseModel.MessageBufLength - frameStartIndex
                < FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_FRAME_HEADER_BUF
                    + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_VERSION_BUF
                    + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_DATA_SECTION_LENGTH_BUF
                    + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_DATA_SECTION_PARITY_BUF
                    + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_END_OF_FRAME_BUF)
            {
                return FunctionResult.FAIL;
            }

            //1. is the buffer has the (0x70 0x71 0x72 0x73) frame header ?
            for (;
                i < Model.ResponseModel.MessageBufLength - 1;
                i++)
            {
                if (Model.ResponseModel.MessageBuf[i] == (byte)(FFTAICommunicationV3InterfaceResponseModel.HEADER_OF_RESPONSE_FRAME >> 24 & 0xFF)
                    && Model.ResponseModel.MessageBuf[i + 1] == (byte)(FFTAICommunicationV3InterfaceResponseModel.HEADER_OF_RESPONSE_FRAME >> 16 & 0xFF)
                     && Model.ResponseModel.MessageBuf[i + 2] == (byte)(FFTAICommunicationV3InterfaceResponseModel.HEADER_OF_RESPONSE_FRAME >> 8 & 0xFF)
                      && Model.ResponseModel.MessageBuf[i + 3] == (byte)(FFTAICommunicationV3InterfaceResponseModel.HEADER_OF_RESPONSE_FRAME >> 0 & 0xFF))
                {
                    temp = 1;
                    frameStartIndex = i;

                    break;
                }

                temp = 0;
            }

            if (temp == 0)
            {
                // no frame header
                return FunctionResult.FAIL;
            }


            // 2. the minimum data frame length request
            if (frameStartIndex
                + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_FRAME_HEADER_BUF
                + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_VERSION_BUF
                + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_DATA_SECTION_LENGTH_BUF
                + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_DATA_SECTION_PARITY_BUF
                + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_END_OF_FRAME_BUF
                < Model.ResponseModel.MessageBufLength)
            {
                Model.ResponseModel.DataSectionLength =
                    (int)(Model.ResponseModel.MessageBuf[frameStartIndex
                        + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_FRAME_HEADER_BUF
                        + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_VERSION_BUF + 0] << 24)
                  + (int)(Model.ResponseModel.MessageBuf[frameStartIndex
                        + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_FRAME_HEADER_BUF
                        + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_VERSION_BUF + 1] << 16)
                  + (int)(Model.ResponseModel.MessageBuf[frameStartIndex
                        + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_FRAME_HEADER_BUF
                        + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_VERSION_BUF + 2] << 8)
                  + (int)(Model.ResponseModel.MessageBuf[frameStartIndex
                        + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_FRAME_HEADER_BUF
                        + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_VERSION_BUF + 3] << 0);
            }
            else
            {
                // not enough data
                i = frameStartIndex + 1;
                temp = 0;

                goto _parseStart;
            }

            // 3. is the buffer has the whole frame ?
            frameLength =
                FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_FRAME_HEADER_BUF
                    + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_VERSION_BUF
                    + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_DATA_SECTION_LENGTH_BUF
                    + (int)Model.ResponseModel.DataSectionLength
                    + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_DATA_SECTION_PARITY_BUF
                    + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_END_OF_FRAME_BUF;

            if (frameStartIndex + frameLength <= Model.ResponseModel.MessageBufLength)
            {
            }
            else
            {
                // not enough data
                i = frameStartIndex + 1;
                temp = 0;

                goto _parseStart;
            }

            // 4. data section parity check (Parity verification)
            dataSectionParity =
                Model.ResponseModel.MessageBuf[
                    frameStartIndex
                    + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_FRAME_HEADER_BUF
                    + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_VERSION_BUF
                    + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_DATA_SECTION_LENGTH_BUF
                    + Model.ResponseModel.DataSectionLength];

            dataSectionParityCalculated = 0;

            for (int j = 0; j < Model.ResponseModel.DataSectionLength; j++)
            {
                dataSectionParityCalculated =
                    (byte)(
                        dataSectionParityCalculated
                        + Model.ResponseModel.MessageBuf[
                            frameStartIndex
                            + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_FRAME_HEADER_BUF
                            + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_VERSION_BUF
                            + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_DATA_SECTION_LENGTH_BUF
                            + j]);
            }

            if (dataSectionParity == dataSectionParityCalculated)
            {

            }
            else
            {
                // not match parity check
                i = frameStartIndex + 1;
                temp = 0;

                goto _parseStart;
            }

            // 5. end of frame check
            endOfFrame =
                Model.ResponseModel.MessageBuf[
                    frameStartIndex
                    + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_FRAME_HEADER_BUF
                    + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_VERSION_BUF
                    + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_DATA_SECTION_LENGTH_BUF
                    + Model.ResponseModel.DataSectionLength
                    + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_DATA_SECTION_PARITY_BUF];

            if (endOfFrame == FFTAICommunicationV3InterfaceResponseModel.END_OF_RESPONSE_FRAME)
            {

            }
            else
            {
                // not match end of frame
                i = frameStartIndex + 1;
                temp = 0;

                goto _parseStart;
            }

            // get data section length buffer
            Array.Copy(
                Model.ResponseModel.MessageBuf,
                (int)(frameStartIndex
                    + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_FRAME_HEADER_BUF
                    + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_VERSION_BUF),
                 Model.ResponseModel.DataSectionLengthBuf,
                 0,
                 (int)FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_DATA_SECTION_LENGTH_BUF);

            // get data section
            Array.Copy(
                Model.ResponseModel.MessageBuf,
                (int)(frameStartIndex
                    + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_FRAME_HEADER_BUF
                    + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_VERSION_BUF
                    + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_DATA_SECTION_LENGTH_BUF),
                Model.ResponseModel.DataSectionBuf,
                0,
                (int)Model.ResponseModel.DataSectionLength);

            // get data section parity
            Array.Copy(
                Model.ResponseModel.MessageBuf,
                (int)(frameStartIndex
                    + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_FRAME_HEADER_BUF
                    + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_VERSION_BUF
                    + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_DATA_SECTION_LENGTH_BUF
                    + Model.ResponseModel.DataSectionLength),
                Model.ResponseModel.DataSectionParityBuf,
                0,
                (int)(FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_DATA_SECTION_PARITY_BUF));

            Model.ResponseModel.DataSectionParity =
                ((uint)Model.ResponseModel.DataSectionParityBuf[0]);

            // get end of the frame
            Array.Copy(
                Model.ResponseModel.MessageBuf,
                (int)(frameStartIndex
                    + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_FRAME_HEADER_BUF
                    + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_VERSION_BUF
                    + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_DATA_SECTION_LENGTH_BUF
                    + Model.ResponseModel.DataSectionLength
                    + FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_DATA_SECTION_PARITY_BUF),
                Model.ResponseModel.EndOfFrameBuf,
                0,
                (int)(FFTAICommunicationV3InterfaceResponseModel.LENGTH_OF_END_OF_FRAME_BUF));

            Model.ResponseModel.EndOfFrame =
                (uint)Model.ResponseModel.EndOfFrameBuf[0];

            // copy frame buffer
            Model.ResponseModel.FrameBuf = new byte[frameLength];
            Model.ResponseModel.FrameBufLength = frameLength;

            Array.Copy(
                Model.ResponseModel.MessageBuf,
                frameStartIndex,
                Model.ResponseModel.FrameBuf,
                0,
                Model.ResponseModel.FrameBufLength);

            // debug log
            // FFTAICommunicationManager.Instance.Logger.WriteLine("Success Parse Frame : " + BitConverter.ToString(Model.ResponseModel.FrameBuf));

            // remove the data ahead of this frame and the data of this frame in the buffer
            Array.Clear(
                Model.ResponseModel.MessageBuf,
                0,
                (int)(frameStartIndex + frameLength));

            Array.Copy(
                Model.ResponseModel.MessageBuf,
                (int)(frameStartIndex + frameLength),
                Model.ResponseModel.MessageBuf,
                0,
                (int)(Model.ResponseModel.MessageBufLength - (frameStartIndex + frameLength)));

            Model.ResponseModel.MessageBufLength
                = Model.ResponseModel.MessageBufLength - (frameStartIndex + frameLength);

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="bufferLength"></param>
        /// <returns></returns>
        public int Receive(byte[] buffer, int bufferLength)
        {
            int functionResult;

            // check message length
            if (bufferLength == 0 || buffer == null)
            {
                return FunctionResult.FAIL;
            }

            // copy message to local buff
            //"Model.ResponseModel.MessageBuf" is a cache byte array,is used to store multiple byte data.
            if (bufferLength > (FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_MESSAGE_BUF - Model.ResponseModel.MessageBufLength))
            {
                Array.Copy(
                    buffer,
                    0,
                    Model.ResponseModel.MessageBuf,
                    Model.ResponseModel.MessageBufLength,
                    FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_MESSAGE_BUF - Model.ResponseModel.MessageBufLength);

                Model.ResponseModel.MessageBufLength = FFTAICommunicationV2InterfaceResponseModel.LENGTH_OF_MESSAGE_BUF;
            }
            else
            {
                Array.Copy(
                    buffer,
                    0,
                    Model.ResponseModel.MessageBuf,
                    Model.ResponseModel.MessageBufLength,
                    bufferLength);

                Model.ResponseModel.MessageBufLength = bufferLength;
            }

            // try to parse the message
            //if protocol v2
            if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_2)
            {
                functionResult = ParseV2Data();
            }
            //if protocol v3
            else if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_3)
            {
                functionResult = ParseV3Data();
            }
            else
            {
                functionResult = FunctionResult.FAIL;
            }

            if (functionResult == FunctionResult.SUCCESS)
            {
                // update request message and mesasgeLength
                UpdateResponseMessage(
                    Model.ResponseModel.MessageBuf,
                    Model.ResponseModel.MessageBufLength);

                functionResult = FFTAICommunicationManager.getInstance().iapInterface.Receive(Model.ResponseModel.DataSectionBuf, (int)Model.ResponseModel.DataSectionLength);

                if (functionResult == FunctionResult.SUCCESS)
                {

                }
                else
                {
                    return FunctionResult.FAIL;
                }
            }
            else
            {
                // reset receive message and mesasgeLength
                UpdateResponseMessage(null, 0);

                // clear response buffer
                Array.Clear(Model.ResponseModel.MessageBuf, 0, Model.ResponseModel.MessageBuf.Length);
                Model.ResponseModel.MessageBufLength = 0;
            }
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
        public int Send(
            uint frameHeader,
            uint communicationProtocolVersion,
            uint robotType,
            uint functionType,
            uint dataSectionLength,
            byte[] dataSection,
            uint dataSectionParity,
            uint endOfFrame)
        {
            int functionResult;

            uint dataSectionParityCalculated = 0;

            // calculate parity
            for (int i = 0; i < dataSectionLength; i++)
            {
                dataSectionParityCalculated =
                    (byte)(dataSectionParityCalculated + dataSection[i]);
            }

            //if protocol v2
            if (communicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_2)
            {

            }
            //if protocol v3
            else if (communicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_3)
            {
                dataSectionParityCalculated = (byte)(dataSectionParityCalculated + (byte)(functionType >> 24 & 0xFF)
                + (byte)(functionType >> 16 & 0xFF)
                + (byte)(functionType >> 8 & 0xFF)
                + (byte)(functionType >> 0 & 0xFF));
            }

            // check if it is a request message and parse it
            functionResult = Model.RequestModel.Update(
                                frameHeader,
                                communicationProtocolVersion,
                                robotType,
                                functionType,
                                dataSectionLength,
                                dataSection,
                                dataSectionParityCalculated,
                                endOfFrame);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            // send the frame
            byte[] frame = Model.RequestModel.MessageBuf;
            int frameLength = Model.RequestModel.MessageBufLength;

            functionResult = FFTAICommunicationManager.getInstance().networkOperation.SendMessage(frame, frameLength);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                return FunctionResult.SOCKET_EXCEPTION;
            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int UpdateResponseMessage(byte[] buffer, int bufferLength)
        {
            FFTAICommunicationInterfaceModel Model = FFTAICommunicationManager.getInstance().interfaceModel;
            if (buffer == null
                || bufferLength == 0)
            {
                Array.Clear(Model.ReceiveMessageBuf, 0, Model.ReceiveMessageBuf.Length);
                Model.ReceiveMessageBufLength = 0;

                return FunctionResult.SUCCESS;
            }

            // update model
            Array.Copy(
                buffer,
                0,
                Model.ReceiveMessageBuf,
                0,
                bufferLength);

            Model.ReceiveMessageBufLength = bufferLength;

            return FunctionResult.SUCCESS;
        }

        public int ReceiveMessageHandle(byte[] message, int messageLength)
        {
            FFTAICommunicationInterfaceModel Model = FFTAICommunicationManager.getInstance().interfaceModel;

            // copy buffer
            byte[] _message = new byte[messageLength];
            int _messageLength = messageLength;
            Array.Copy(message, _message, _messageLength);


            //the function is aim to update the field of "ReceiveMessageBuf"  in "FFTAICommunictionInterfaceModel"  .
            UpdateResponseMessage(_message, _messageLength);

            // receive message handle
            while (Receive(Model.ReceiveMessageBuf, Model.ReceiveMessageBufLength) == FunctionResult.SUCCESS)
            {
            }

            return FunctionResult.SUCCESS;
        }
    }
}

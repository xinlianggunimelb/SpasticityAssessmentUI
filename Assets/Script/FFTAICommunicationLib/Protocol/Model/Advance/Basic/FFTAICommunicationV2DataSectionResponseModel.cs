using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FFTAICommunicationLib;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationV2DataSectionResponseModel: FFTAICommunicationDataSectionResponseModel
    {
        public const int  LENGTH_OF_MESSAGE_BUF = 512;

        public const int  LENGTH_OF_OPERATION_MODE_BUF = 4;
        public const int  LENGTH_OF_NUMBER_OF_PARAMETER_BUF = 1;
        public const int  LENGTH_OF_READ_WRITE_OPERATION_BUF = 1;
        public const int  LENGTH_OF_OPERATION_RESULT_BUF = 1;
        public const int  LENGTH_OF_RESPONSE_SAVED_BUF = 1;
        public const int  LENGTH_OF_NUMBER_OF_RESPONSE_BUF = 1;
        public const int  LENGTH_OF_RESPONSE_PARAMETER_BUF = 4 * 100;

        // different part buffer
        public byte[] OperationModeBuf;
        public byte[] NumberOfParameterBuf;
        public byte[] ReadWriteOperationBuf;
        public byte[] SavedBuf;
        public byte[] OperationResultBuf;
        public byte[] ParameterBuf;

        // different part variable
        public long NumberOfParameter;
        public long Saved;
       

        /// <summary>
        /// 
        /// </summary>
        public FFTAICommunicationV2DataSectionResponseModel()
        {
            MessageBuf = new byte[LENGTH_OF_MESSAGE_BUF];
            MessageBufLength = 0;
            MessageBufParity = 0;

            OperationModeBuf = new byte[LENGTH_OF_OPERATION_MODE_BUF];
            NumberOfParameterBuf = new byte[LENGTH_OF_NUMBER_OF_PARAMETER_BUF];
            ReadWriteOperationBuf = new byte[LENGTH_OF_READ_WRITE_OPERATION_BUF];
            SavedBuf = new byte[LENGTH_OF_RESPONSE_SAVED_BUF];
            OperationResultBuf = new byte[LENGTH_OF_OPERATION_RESULT_BUF];
            ParameterBuf = new byte[LENGTH_OF_RESPONSE_PARAMETER_BUF];

            OperationMode = 0;
            NumberOfParameter = 0;
            ReadWriteOperation = 0;
            Saved = 0;
            OperationResult = 0;
            Parameter = new int[LENGTH_OF_RESPONSE_PARAMETER_BUF / 4];
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
            // get operation mode
            Array.Copy(
                MessageBuf,
                0,
                OperationModeBuf,
                0,
                LENGTH_OF_OPERATION_MODE_BUF);

            OperationMode =
                (uint)(OperationModeBuf[0] << 24)
                + (uint)(OperationModeBuf[1] << 16)
                + (uint)(OperationModeBuf[2] << 8)
                + (uint)(OperationModeBuf[3] << 0);

            // get number of parameter
            Array.Copy(
                MessageBuf,
                0
                    + LENGTH_OF_OPERATION_MODE_BUF,
                NumberOfParameterBuf,
                0,
                LENGTH_OF_NUMBER_OF_PARAMETER_BUF);

            NumberOfParameter =
                (uint)(NumberOfParameterBuf[0]);

            // get read/write operation
            Array.Copy(
                MessageBuf,
                0
                    + LENGTH_OF_OPERATION_MODE_BUF
                    + LENGTH_OF_NUMBER_OF_PARAMETER_BUF,
                ReadWriteOperationBuf,
                0,
                LENGTH_OF_READ_WRITE_OPERATION_BUF);

            ReadWriteOperation =
                (uint)(ReadWriteOperationBuf[0]);

            // get saved buffer
            Array.Copy(
                MessageBuf,
                0
                    + LENGTH_OF_OPERATION_MODE_BUF
                    + LENGTH_OF_NUMBER_OF_PARAMETER_BUF
                    + LENGTH_OF_READ_WRITE_OPERATION_BUF,
                SavedBuf,
                0,
                LENGTH_OF_RESPONSE_SAVED_BUF);

            // get operation result
            Array.Copy(
                MessageBuf,
                0
                    + LENGTH_OF_OPERATION_MODE_BUF
                    + LENGTH_OF_NUMBER_OF_PARAMETER_BUF
                    + LENGTH_OF_READ_WRITE_OPERATION_BUF
                    + LENGTH_OF_RESPONSE_SAVED_BUF,
                OperationResultBuf,
                0,
                LENGTH_OF_OPERATION_RESULT_BUF);

            OperationResult =
                (uint)(OperationResultBuf[0]);

            // get parameter
            Array.Copy(
                MessageBuf,
                0
                    + LENGTH_OF_OPERATION_MODE_BUF
                    + LENGTH_OF_NUMBER_OF_PARAMETER_BUF
                    + LENGTH_OF_READ_WRITE_OPERATION_BUF
                    + LENGTH_OF_RESPONSE_SAVED_BUF
                    + LENGTH_OF_OPERATION_RESULT_BUF,
                ParameterBuf,
                0,
                NumberOfParameter * 4);

            for (int  i = 0; i < NumberOfParameter; i++)
            {
                Parameter[i] =
                    (int)(ParameterBuf[i * 4 + 0] << 24)
                    + (int)(ParameterBuf[i * 4 + 1] << 16)
                    + (int)(ParameterBuf[i * 4 + 2] << 8)
                    + (int)(ParameterBuf[i * 4 + 3] << 0);
            }

            return FunctionResult.SUCCESS;
        }

    }
}

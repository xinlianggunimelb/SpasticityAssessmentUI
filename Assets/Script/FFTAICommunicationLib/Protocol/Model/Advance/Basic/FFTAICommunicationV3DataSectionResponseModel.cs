using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FFTAICommunicationLib;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationV3DataSectionResponseModel: FFTAICommunicationDataSectionResponseModel
    {
        public const int  LENGTH_OF_MESSAGE_BUF = 512;
        
        //different part length
        public const int  LENGTH_OF_FUNCTION_TYPE_BUF = 4;
        public const int  LENGTH_OF_OPERATION_MODE_BUF = 4;
        public const int  LENGTH_OF_READ_WRITE_OPERATION_BUF = 1;
        public const int  LENGTH_OF_OPERATION_RESULT_BUF = 1;
        public const int  LENGTH_OF_PARAMETER_TYPE_BUF = 1;
        public const int  LENGTH_OF_NUMBER_OF_PARAMETER_BUF = 4;
        public const int  LENGTH_OF_RESPONSE_PARAMETER_BUF = 4 * 100;

        // different part buffer
        public byte[] FunctionTypeBuf;
        public byte[] OperationModeBuf;
        public byte[] ReadWriteOperationBuf;
        public byte[] OperationResultBuf;
        public byte[] ParameterTypeBuf;
        public byte[] NumberOfParameterBuf;
        public byte[] ParameterBuf;

        // different part variable
        public long ParameterType;
        public long NumberOfParameter;

        /// <summary>
        /// 
        /// </summary>
        public FFTAICommunicationV3DataSectionResponseModel()
        {
            MessageBuf = new byte[LENGTH_OF_MESSAGE_BUF];
            MessageBufLength = 0;
            MessageBufParity = 0;

            FunctionTypeBuf = new byte[LENGTH_OF_FUNCTION_TYPE_BUF];
            OperationModeBuf = new byte[LENGTH_OF_OPERATION_MODE_BUF];
            NumberOfParameterBuf = new byte[LENGTH_OF_NUMBER_OF_PARAMETER_BUF];
            ReadWriteOperationBuf = new byte[LENGTH_OF_READ_WRITE_OPERATION_BUF];
            ParameterTypeBuf = new byte[LENGTH_OF_PARAMETER_TYPE_BUF];
            OperationResultBuf = new byte[LENGTH_OF_OPERATION_RESULT_BUF];
            ParameterBuf = new byte[LENGTH_OF_RESPONSE_PARAMETER_BUF];

            OperationMode = 0;
            NumberOfParameter = 0;
            ReadWriteOperation = 0;
            ParameterType = 0;
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
            //get function type
            Array.Copy(
                MessageBuf,
                0,
                FunctionTypeBuf,
                0,
                LENGTH_OF_FUNCTION_TYPE_BUF
                );
            FunctionType= 
                (uint)(FunctionTypeBuf[0] << 24)
                 + (uint)(FunctionTypeBuf[1] << 16)
                 + (uint)(FunctionTypeBuf[2] << 8)
                 + (uint)(FunctionTypeBuf[3] << 0);

            // get operation mode
            Array.Copy(
                MessageBuf,
                0
                    + LENGTH_OF_FUNCTION_TYPE_BUF,
                OperationModeBuf,
                0,
                LENGTH_OF_OPERATION_MODE_BUF);

            OperationMode =
                (uint)(OperationModeBuf[0] << 24)
                + (uint)(OperationModeBuf[1] << 16)
                + (uint)(OperationModeBuf[2] << 8)
                + (uint)(OperationModeBuf[3] << 0);

            // get read/write operation
            Array.Copy(
                MessageBuf,
                0
                    + LENGTH_OF_FUNCTION_TYPE_BUF
                    + LENGTH_OF_OPERATION_MODE_BUF,
                ReadWriteOperationBuf,
                0,
                LENGTH_OF_READ_WRITE_OPERATION_BUF);

            ReadWriteOperation =
                (uint)(ReadWriteOperationBuf[0]);

            // get operation result
            Array.Copy(
                MessageBuf,
                0
                    + LENGTH_OF_FUNCTION_TYPE_BUF
                    + LENGTH_OF_OPERATION_MODE_BUF
                    + LENGTH_OF_READ_WRITE_OPERATION_BUF ,
                OperationResultBuf,
                0,
                LENGTH_OF_OPERATION_RESULT_BUF);

            OperationResult =
                (uint)(OperationResultBuf[0]);

            // get Parameter Type
            Array.Copy(
                MessageBuf,
                0
                    + LENGTH_OF_FUNCTION_TYPE_BUF
                    + LENGTH_OF_OPERATION_MODE_BUF
                    + LENGTH_OF_OPERATION_RESULT_BUF
                    + LENGTH_OF_READ_WRITE_OPERATION_BUF,
                ParameterTypeBuf,
                0,
                LENGTH_OF_PARAMETER_TYPE_BUF);
            ParameterType = ParameterTypeBuf[0];

            // get number of parameter
            Array.Copy(
                MessageBuf,
                0
                    + LENGTH_OF_FUNCTION_TYPE_BUF
                    + LENGTH_OF_OPERATION_MODE_BUF
                    + LENGTH_OF_OPERATION_RESULT_BUF
                    + LENGTH_OF_READ_WRITE_OPERATION_BUF
                    + LENGTH_OF_PARAMETER_TYPE_BUF,
                NumberOfParameterBuf,
                0,
                LENGTH_OF_NUMBER_OF_PARAMETER_BUF);

            NumberOfParameter =
                (uint)(NumberOfParameterBuf[0] << 24 )
                + (uint)(NumberOfParameterBuf[1] << 16 )
                + (uint)(NumberOfParameterBuf[2] << 8 )
                + (uint)(NumberOfParameterBuf[3] << 0 );
            
            // get parameter
            Array.Copy(
                MessageBuf,
                0
                    + LENGTH_OF_FUNCTION_TYPE_BUF
                    + LENGTH_OF_OPERATION_MODE_BUF
                    + LENGTH_OF_NUMBER_OF_PARAMETER_BUF
                    + LENGTH_OF_READ_WRITE_OPERATION_BUF
                    + LENGTH_OF_PARAMETER_TYPE_BUF
                    + LENGTH_OF_OPERATION_RESULT_BUF,
                ParameterBuf,
                0,
                NumberOfParameter);
            switch (ParameterType)
            {
                case FFTAICommunicationFillingParameter.CHAR:
                {
                    for (int _i = 0; _i < NumberOfParameter; _i++)
                    {
                            Parameter[_i] = ParameterBuf[_i];
                    }
                    break;
                }
                case FFTAICommunicationFillingParameter.SHORT:
                {
                    for (int _i = 0,_j = 0; _i < NumberOfParameter; _i = _i+ 4,_j++)
                    {
                        Parameter[_j] = ParameterBuf[_i]<<8 &0xFF 
                                + ParameterBuf[_i+1] << 0 & 0xFF;
                    }
                    break;
                }
                case FFTAICommunicationFillingParameter.INT:
                {
                    for (int _i = 0,_j = 0; _i < NumberOfParameter; _i = _i+ 4,_j++)
                    { 
                            Parameter[_j] =  (int)((ParameterBuf[_i] << 24 & 0xFF000000)
                                         + (ParameterBuf[_i + 1] << 16 & 0x00FF0000)
                                         + (ParameterBuf[_i + 2] << 8 & 0x0000FF00)
                                         + (ParameterBuf[_i + 3] << 0 & 0x000000FF));
                            //Parameter[_i] = BitConverter.ToInt32(ParameterBuf, _i);
                    }
                    break;
                }
                case FFTAICommunicationFillingParameter.FLOAT:
                {
                    for (int _i = 0, _j = 0; _i < NumberOfParameter; _i = _i + 4, _j++)
                    {
                            // Parameter[_i] = BitConverter.ToInt32(ParameterBuf, _i);
                            Parameter[_j] = (ParameterBuf[_i] << 24 & 0xFF
                                     + ParameterBuf[_i + 1] << 16 & 0xFF
                                     + ParameterBuf[_i + 2] << 8 & 0xFF
                                     + ParameterBuf[_i + 3] << 0 & 0xFF);
                        }
                    break;
                }
            }
            return FunctionResult.SUCCESS;
        }
    }
}

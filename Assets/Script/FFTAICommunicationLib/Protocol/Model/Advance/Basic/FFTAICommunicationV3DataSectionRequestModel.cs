using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FFTAICommunicationLib;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationV3DataSectionRequestModel:FFTAICommunicationDataSectionRequestModel
    {
        public const int  LENGTH_OF_MESSAGE_BUF = 512;

        public const int  LENGTH_OF_OPERATION_MODE_BUF = 4;
        public const int  LENGTH_OF_READ_WRITE_OPERATION_BUF = 1;
        public const int  LENGTH_OF_OPERATION_RESULT_BUF = 1;
        public const int  LENGTH_OF_PARAMETER_TYPE_BUF = 1;  
        public const int  LENGTH_OF_NUMBER_OF_PARAMETER_BUF = 4;
        public const int  LENGTH_OF_REQUEST_PARAMETER_BUF = 4 * 100;


        // different part buffer
        public byte[] OperationModeBuf;
        public byte[] ReadWriteOperationBuf;
        public byte[] OperationResultBuf;
        public byte[] ParameterTypeBuf;
        public byte[] NumberOfParameterBuf;
        public byte[] ParameterBuf;

        // different part variable
        public uint  OperationMode;
        public uint  NumberOfParameter;
        public long OperationResult;
        public uint  ReadWriteOperation;
        public long ParameterType;


        public FFTAICommunicationV3DataSectionRequestModel()
        {
            MessageBuf = new byte[LENGTH_OF_MESSAGE_BUF];
            MessageBufLength = 0;
            MessageBufParity = 0;

            OperationModeBuf = new byte[LENGTH_OF_OPERATION_MODE_BUF];
            NumberOfParameterBuf = new byte[LENGTH_OF_NUMBER_OF_PARAMETER_BUF];
            ReadWriteOperationBuf = new byte[LENGTH_OF_READ_WRITE_OPERATION_BUF];
            ParameterTypeBuf = new byte[LENGTH_OF_PARAMETER_TYPE_BUF];
            OperationResultBuf = new byte[LENGTH_OF_OPERATION_RESULT_BUF];
            ParameterBuf = new byte[LENGTH_OF_REQUEST_PARAMETER_BUF];


            OperationMode = 0;
            NumberOfParameter = 0;
            ReadWriteOperation = 0;
            ParameterType = 0;
            OperationResult = 0;
            Parameter = new uint [LENGTH_OF_REQUEST_PARAMETER_BUF / 4];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operationMode"></param>
        /// <param name="numberOfParameter"></param>
        /// <param name="readWriteOperation"></param>
        /// <param name="parameterType"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override int Update(
            uint  operationMode,
            uint  numberOfParameter,
            uint  readWriteOperation,
            uint  parameterType,
            uint [] parameter)
        {
            // update different part buffer and variables
            OperationMode = operationMode;
            ReadWriteOperation = readWriteOperation;
            ParameterType = parameterType;
            NumberOfParameter = numberOfParameter;
            Array.Copy(parameter, Parameter, NumberOfParameter);

            for (int  i = 0; i < LENGTH_OF_OPERATION_MODE_BUF; i++)
            {
                OperationModeBuf[i] = (byte)((OperationMode >> (8 * (LENGTH_OF_OPERATION_MODE_BUF - i - 1))) & 0xFF);
            }



            OperationResult = FFTAICommunicationOperationResult.SUCCESS;

            for (int  i = 0; i < LENGTH_OF_READ_WRITE_OPERATION_BUF; i++)
            {
                ReadWriteOperationBuf[i] = (byte)((ReadWriteOperation >> (8 * (LENGTH_OF_READ_WRITE_OPERATION_BUF - i - 1))) & 0xFF);
            }

            for (int  i = 0; i < LENGTH_OF_PARAMETER_TYPE_BUF; i++)
            {
                ParameterTypeBuf[i] = (byte)((ParameterType >> (8 * (LENGTH_OF_PARAMETER_TYPE_BUF - i - 1))) & 0xFF);
            }

            switch (ParameterType)
            {
                case FFTAICommunicationFillingParameter.CHAR:
                    {
                        for (int _i = 0; _i < NumberOfParameter; _i++)
                        {
                            ParameterBuf[_i] = (byte)Parameter[_i];
                        }
                        break;
                    }
                case FFTAICommunicationFillingParameter.SHORT:
                    {
                        for (int _i = 0; _i < NumberOfParameter; _i ++)
                        {
                            ParameterBuf[_i * 2] = (byte)(Parameter[_i] >> 8 & 0xFF);

                            ParameterBuf[_i * 2 + 1] = (byte)(Parameter[_i + 1] >> 0 & 0xFF);
                        }
                        NumberOfParameter = NumberOfParameter * 2;
                        break;
                        
                    }
                case FFTAICommunicationFillingParameter.INT:
                case FFTAICommunicationFillingParameter.FLOAT:
                    {
                        for (int _i = 0; _i < NumberOfParameter; _i ++)
                        {
                            ParameterBuf[_i * 4 + 0] = (byte)((Parameter[_i] >> 24) & 0xFF);
                            ParameterBuf[_i * 4 + 1] = (byte)((Parameter[_i] >> 16) & 0xFF);
                            ParameterBuf[_i * 4 + 2] = (byte)((Parameter[_i] >> 8) & 0xFF);
                            ParameterBuf[_i * 4 + 3] = (byte)((Parameter[_i] >> 0) & 0xFF);
                        }
                        NumberOfParameter = NumberOfParameter * 4;
                        break;

                    }
            }
           
            for (int i = 0; i < LENGTH_OF_NUMBER_OF_PARAMETER_BUF; i++)
            {
                NumberOfParameterBuf[i] = (byte)((NumberOfParameter >> (8 * (LENGTH_OF_NUMBER_OF_PARAMETER_BUF - i - 1))) & 0xFF);
            }

            // update whole message buffer
            Array.Copy(
                   OperationModeBuf,
                   0,
                   MessageBuf,
                   0,
                   LENGTH_OF_OPERATION_MODE_BUF);

            Array.Copy(
                 ReadWriteOperationBuf,
                 0,
                 MessageBuf,
                 0
                     + LENGTH_OF_OPERATION_MODE_BUF,
                 LENGTH_OF_READ_WRITE_OPERATION_BUF);

            Array.Copy(
                OperationResultBuf,
                0,
                MessageBuf,
                0
                    + LENGTH_OF_OPERATION_MODE_BUF
                    + LENGTH_OF_READ_WRITE_OPERATION_BUF,
                LENGTH_OF_OPERATION_RESULT_BUF);

            Array.Copy(
               ParameterTypeBuf,
               0,
               MessageBuf,
               0
                   + LENGTH_OF_OPERATION_MODE_BUF
                   + LENGTH_OF_OPERATION_RESULT_BUF
                   + LENGTH_OF_READ_WRITE_OPERATION_BUF,
               LENGTH_OF_PARAMETER_TYPE_BUF);



            Array.Copy(
                NumberOfParameterBuf,
                0,
                MessageBuf,
                0
                   + LENGTH_OF_OPERATION_MODE_BUF
                   + LENGTH_OF_OPERATION_RESULT_BUF
                   + LENGTH_OF_READ_WRITE_OPERATION_BUF
                   + LENGTH_OF_PARAMETER_TYPE_BUF,
                LENGTH_OF_NUMBER_OF_PARAMETER_BUF);


            Array.Copy(
                ParameterBuf,
                0,
                MessageBuf,
                0
                    + LENGTH_OF_OPERATION_MODE_BUF
                    + LENGTH_OF_NUMBER_OF_PARAMETER_BUF
                    + LENGTH_OF_READ_WRITE_OPERATION_BUF
                    + LENGTH_OF_PARAMETER_TYPE_BUF
                    + LENGTH_OF_OPERATION_RESULT_BUF,
                NumberOfParameter);

            MessageBufLength =
                0
                + LENGTH_OF_OPERATION_MODE_BUF
                + LENGTH_OF_NUMBER_OF_PARAMETER_BUF
                + LENGTH_OF_READ_WRITE_OPERATION_BUF
                + LENGTH_OF_PARAMETER_TYPE_BUF
                + LENGTH_OF_OPERATION_RESULT_BUF
                + NumberOfParameter;

            return FunctionResult.SUCCESS;
        }
    }
}
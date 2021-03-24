using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static FFTAICommunicationLib.DynaLinkHS;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationCommunicationInterface:FFTAICommunicationInterfaceBasic, IFFTAICommunicationInterfaceObserver
    {
        public int RequestTestConnection()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationCommunicationInterfacePredefine.TEST_CONNECTION,
                                (uint)FFTAICommunicationNumberOfParameter.ZERO,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] { });

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            // build request frame
            functionResult = interfaceManager.Send(
                                FFTAICommunicationInterfaceRequestModel.HEADER_OF_REQUEST_FRAME,
                                (uint)FFTAICommunicationProtocolVersion.CurrentVersion,
                                (uint)FFTAICommunicationRobotType.All,
                                (uint)FFTAICommunicationFunctionType.COMMUNICATION_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

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

        public int ModelUpdateHandle(FFTAICommunicationInterfaceModelBasic model)
        {
            int operationMode = (int)model.DataSectionModel.ResponseModel.OperationMode;
            int readWriteOperation = (int)model.DataSectionModel.ResponseModel.ReadWriteOperation;
            int operationResult = (int)model.DataSectionModel.ResponseModel.OperationResult;

            switch (operationMode)
            {
                case FFTAICommunicationCommunicationInterfacePredefine.ERROR_REQUEST:
                    {
                        break;
                    }
                case FFTAICommunicationCommunicationInterfacePredefine.SYSTEM_ERROR:
                    {
                        break;
                    }
                case FFTAICommunicationCommunicationInterfacePredefine.TEST_CONNECTION:
                    {
                        ServerLinkMonitorCount = 0; // clear server socket count
                        StatusFlag.FlagServerLinkActive = 0x01;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        public int GetFunctionType()
        {
            return FFTAICommunicationFunctionType.COMMUNICATION_INTERFACE;
        }
    }
}

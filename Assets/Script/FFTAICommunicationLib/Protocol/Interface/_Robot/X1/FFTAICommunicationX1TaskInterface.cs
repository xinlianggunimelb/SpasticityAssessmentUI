using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationX1TaskInterface : FFTAICommunicationInterfaceBasic, IFFTAICommunicationInterfaceObserver
    {
        public int RequestSetWorkMode(int workMode)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationX1TaskInterfaceOperationMode.BasicWorkMode,
                                (uint)FFTAICommunicationNumberOfParameter.ONE,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] { (uint)workMode });

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
                                (uint)FFTAICommunicationRobotType.X1,
                                (uint)FFTAICommunicationFunctionType.X1_TASK_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestGetFlagTaskInProcess()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationX1TaskInterfaceOperationMode.BasicFlagTaskInProcess,
                                (uint)FFTAICommunicationNumberOfParameter.ZERO,
                                (uint)FFTAICommunicationReadWriteOperation.GET,
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
                                (uint)FFTAICommunicationRobotType.X1,
                                (uint)FFTAICommunicationFunctionType.X1_TASK_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        //-------------------------------------------- Function Definition (Request - Basic) -------------------------------------------------------------------

        //-------------------------------------------- Function Definition (Request - Debug) -------------------------------------------------------------------

        public int RequestSetDebugWorkMode(uint  workMode)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationX1TaskInterfaceOperationMode.DebugSetWorkMode,
                                (uint)FFTAICommunicationNumberOfParameter.ONE,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] { workMode });

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
                                (uint)FFTAICommunicationRobotType.X1,
                                (uint)FFTAICommunicationFunctionType.X1_TASK_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workMode"></param>
        /// <returns></returns>
        public int RequestSetMasterControlWorkMode(uint  workMode)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationX1TaskInterfaceOperationMode.MasterControlSetWorkMode,
                                (uint)FFTAICommunicationNumberOfParameter.ONE,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] { workMode });

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            functionResult = interfaceManager.Send(
                                FFTAICommunicationInterfaceRequestModel.HEADER_OF_REQUEST_FRAME,
                                (uint)FFTAICommunicationProtocolVersion.CurrentVersion,
                                (uint)FFTAICommunicationRobotType.X1,
                                (uint)FFTAICommunicationFunctionType.X1_TASK_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public int RequestSetMasterControlWalkPassive1(uint  command)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationX1TaskInterfaceOperationMode.MasterControlSetWalkPassive1Command,
                                (uint)FFTAICommunicationNumberOfParameter.ONE,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] { command });

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            functionResult = interfaceManager.Send(
                                FFTAICommunicationInterfaceRequestModel.HEADER_OF_REQUEST_FRAME,
                                (uint)FFTAICommunicationProtocolVersion.CurrentVersion,
                                (uint)FFTAICommunicationRobotType.X1,
                                (uint)FFTAICommunicationFunctionType.X1_TASK_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public int RequestSetMasterControlWalkPassive2(uint  command)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationX1TaskInterfaceOperationMode.MasterControlSetWalkPassive2Command,
                                (uint)FFTAICommunicationNumberOfParameter.ONE,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] { command });

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            functionResult = interfaceManager.Send(
                                FFTAICommunicationInterfaceRequestModel.HEADER_OF_REQUEST_FRAME,
                                (uint)FFTAICommunicationProtocolVersion.CurrentVersion,
                                (uint)FFTAICommunicationRobotType.X1,
                                (uint)FFTAICommunicationFunctionType.X1_TASK_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public int RequestSetMasterControlWalkPassive3(uint  command)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationX1TaskInterfaceOperationMode.MasterControlSetWalkPassive3Command,
                                (uint)FFTAICommunicationNumberOfParameter.ONE,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] { command });

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            functionResult = interfaceManager.Send(
                                FFTAICommunicationInterfaceRequestModel.HEADER_OF_REQUEST_FRAME,
                                (uint)FFTAICommunicationProtocolVersion.CurrentVersion,
                                (uint)FFTAICommunicationRobotType.X1,
                                (uint)FFTAICommunicationFunctionType.X1_TASK_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public int RequestSetMasterControlWalkPassive4(uint  command)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationX1TaskInterfaceOperationMode.MasterControlSetWalkPassive4Command,
                                (uint)FFTAICommunicationNumberOfParameter.ONE,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] { command });

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            functionResult = interfaceManager.Send(
                                FFTAICommunicationInterfaceRequestModel.HEADER_OF_REQUEST_FRAME,
                                (uint)FFTAICommunicationProtocolVersion.CurrentVersion,
                                (uint)FFTAICommunicationRobotType.X1,
                                (uint)FFTAICommunicationFunctionType.X1_TASK_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int ModelUpdateHandle(FFTAICommunicationInterfaceModelBasic model)
        {
            return FunctionResult.SUCCESS;
        }

        public int GetFunctionType()
        {
            return FFTAICommunicationFunctionType.X1_TASK_INTERFACE;
        }

    }
}

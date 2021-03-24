using System;
using static FFTAICommunicationLib.DynaLinkHS;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationM1TaskInterface : FFTAICommunicationInterfaceBasic, IFFTAICommunicationInterfaceObserver
    {
        public int RequestSetWorkMode(int workMode)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.BasicWorkMode,
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
                                (uint)FFTAICommunicationRobotType.M1,
                                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        public int RequestReadFlagTaskInProcess()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.BasicFlagTaskInProcess,
                                (uint)FFTAICommunicationNumberOfParameter.ZERO,
                                (uint)FFTAICommunicationReadWriteOperation.READ,
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
                                (uint)FFTAICommunicationRobotType.M1,
                                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        public int RequestReadFlagInformation()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.BasicFlagInformation,
                                (uint)FFTAICommunicationNumberOfParameter.ZERO,
                                (uint)FFTAICommunicationReadWriteOperation.READ,
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
                                (uint)FFTAICommunicationRobotType.M1,
                                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        public int RequestSetDebugWorkMode(int workMode)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.DebugSetWorkMode,
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
                                (uint)FFTAICommunicationRobotType.M1,
                                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Debug) -------------------------------------------------------------------

        //-------------------------------------------- Function Definition (Request - Relay) -------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workMode"></param>
        /// <returns></returns>
        public int RequestSetRelayWorkMode(int workMode)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.RelaySetWorkMode,
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
                                (uint)FFTAICommunicationRobotType.M1,
                                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);
            //UnityEngine.Debug.Log(functionResult);
            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        //-------------------------------------------- Function Definition (Request - Relay) -------------------------------------------------------------------

        //-------------------------------------------- Function Definition (Request - MasterControl) -----------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workMode"></param>
        /// <returns></returns>
        public int RequestSetMasterControlWorkMode(uint  workMode)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.MasterControlSetWorkMode,
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
                                (uint)FFTAICommunicationRobotType.M1,
                                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - MasterControl) -----------------------------------------------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic) ---------------------------------------------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Joint Kinetic Control) ---------------------------------

        public int RequestSetSubtaskBasicJointKineticControlKinetic(
            float kinetic)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetJointKineticControlKinetic,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(kinetic), 0) });

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
                (uint)FFTAICommunicationRobotType.M1,
                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Joint Kinetic Control) ---------------------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Joint Velocity Control) --------------------------------

        public int RequestSetSubtaskBasicJointVelocityControlAcceleration(
            float acceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetJointVelocityControlAcceleration,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(acceleration), 0) });

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
                (uint)FFTAICommunicationRobotType.M1,
                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicJointVelocityControlVelocity(
            float velocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetJointVelocityControlVelocity,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(velocity), 0) });

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
                (uint)FFTAICommunicationRobotType.M1,
                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Joint Velocity Control) --------------------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Joint Position Control) --------------------------------

        public int RequestSetSubtaskBasicJointPositionControlAcceleration(
            float acceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetJointPositionControlAcceleration,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(acceleration), 0) });

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
                (uint)FFTAICommunicationRobotType.M1,
                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicJointPositionControlVelocity(
            float velocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetJointPositionControlVelocity,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(velocity), 0) });

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
                (uint)FFTAICommunicationRobotType.M1,
                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicJointPositionControlPosition(
            float position)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetJointPositionControlPosition,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(position), 0) });

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
                (uint)FFTAICommunicationRobotType.M1,
                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Joint Velocity Control) --------------------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - End Effector Kinetic Control) --------------------------

        public int RequestSetSubtaskBasicEndEffectorKineticControlKinetic(
            float kinetic)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetEndEffectorKineticControlKinetic,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(kinetic), 0) });

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
                (uint)FFTAICommunicationRobotType.M1,
                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - End Effector Kinetic Control) --------------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - End Effector Velocity Control) -------------------------

        public int RequestSetSubtaskBasicEndEffectorVelocityControlAcceleration(
            float acceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetEndEffectorVelocityControlAcceleration,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(acceleration), 0) });

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
                (uint)FFTAICommunicationRobotType.M1,
                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicEndEffectorVelocityControlVelocity(
            float velocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetEndEffectorVelocityControlVelocity,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(velocity), 0) });

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
                (uint)FFTAICommunicationRobotType.M1,
                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - End Effector Velocity Control) -------------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - End Effector Position Control) -------------------------

        public int RequestSetSubtaskBasicEndEffectorPositionControlAcceleration(
            float acceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetEndEffectorPositionControlAcceleration,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(acceleration), 0) });

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
                (uint)FFTAICommunicationRobotType.M1,
                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicEndEffectorPositionControlVelocity(
            float velocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetEndEffectorPositionControlVelocity,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(velocity), 0) });

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
                (uint)FFTAICommunicationRobotType.M1,
                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicEndEffectorPositionControlPosition(
            float position)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetEndEffectorPositionControlPosition,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(position), 0) });

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
                (uint)FFTAICommunicationRobotType.M1,
                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - End Effector Velocity Control) -------------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - FInd Home) ---------------------------------------------

        public int RequestSetSubtaskBasicFindHomeRequestKinetic(
            float endEffectorKinetic)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetFindHomeRequestKinetic,
                                (uint)FFTAICommunicationNumberOfParameter.ONE,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorKinetic), 0) });

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
                                (uint)FFTAICommunicationRobotType.M1,
                                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - FInd Home) ---------------------------------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Linear Motion) ---------------------------------

        public int RequestSetSubtaskBasicPassiveLinearMotionAcceleration(
            float acceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetPassiveLinearMotionAcceleration,
                                (uint)FFTAICommunicationNumberOfParameter.ONE,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(acceleration), 0) });

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
                                (uint)FFTAICommunicationRobotType.M1,
                                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicPassiveLinearMotionVelocity(
            float velocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetPassiveLinearMotionVelocity,
                                (uint)FFTAICommunicationNumberOfParameter.ONE,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(velocity), 0) });

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
                                (uint)FFTAICommunicationRobotType.M1,
                                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicPassiveLinearMotionPosition(
            float endEffectorPosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetPassiveLinearMotionPosition,
                                (uint)FFTAICommunicationNumberOfParameter.ONE,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorPosition), 0) });

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
                                (uint)FFTAICommunicationRobotType.M1,
                                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Linear Motion) ---------------------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Mass Simulation) ---------------------------------------

        public int RequestSetSubtaskBasicMassSimulationMass(
            float xMass)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetMassSimulationMass,
                                (uint)FFTAICommunicationNumberOfParameter.TWO,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(xMass), 0) });

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
                                (uint)FFTAICommunicationRobotType.M1,
                                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicMassSimulationFriction(
            float xFriction)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetMassSimulationFrictionFactor,
                                (uint)FFTAICommunicationNumberOfParameter.TWO,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(xFriction), 0) });

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
                                (uint)FFTAICommunicationRobotType.M1,
                                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Mass Simulation) ---------------------------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Force Assist Without Sensor) ---------------------------

        public int RequestSetSubtaskBasicForceAssistWithoutSensorRatio(
float ratio)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetForceAssistWithoutSensorRatio,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(ratio), 0) });

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
                (uint)FFTAICommunicationRobotType.M1,
                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicForceAssistWithoutSensorMaxForce(
			float xForce)
		{
			int functionResult;

			functionResult = Model.DataSectionModel.RequestModel.Update(
				(uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetForceAssistWithoutSensorMaxForce,
				(uint)FFTAICommunicationNumberOfParameter.ONE,
				(uint)FFTAICommunicationReadWriteOperation.SET,
				(uint)FFTAICommunicationFillingParameter.PATCH,
				new uint [] {
					BitConverter.ToUInt32(BitConverter.GetBytes(xForce), 0) });

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
				(uint)FFTAICommunicationRobotType.M1,
				(uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

		//-------------------------------------------- Function Definition (Request - Subtask - Basic - Force Assist Without Sensor) ---------------------------

		//-------------------------------------------- Function Definition (Request - Subtask - Basic - Force Assist With Sensor) ------------------------------

		public int RequestSetSubtaskBasicForceAssistWithSensorForce(
			float xForce)
		{
			int functionResult;

			functionResult = Model.DataSectionModel.RequestModel.Update(
				(uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetForceAssistWithSensorForce,
				(uint)FFTAICommunicationNumberOfParameter.ONE,
				(uint)FFTAICommunicationReadWriteOperation.SET,
				(uint)FFTAICommunicationFillingParameter.PATCH,
				new uint [] {
					BitConverter.ToUInt32(BitConverter.GetBytes(xForce), 0) });

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
				(uint)FFTAICommunicationRobotType.M1,
				(uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

		//-------------------------------------------- Function Definition (Request - Subtask - Basic - Force Assist With Sensor) ------------------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Force Assist With Target Position) ---------------------

		public int RequestSetSubtaskBasicForceAssistWithTargetPositionForce(
			float force)
		{
			int functionResult;

			functionResult = Model.DataSectionModel.RequestModel.Update(
				(uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetForceAssistWithTargetPositionForce,
				(uint)FFTAICommunicationNumberOfParameter.ONE,
				(uint)FFTAICommunicationReadWriteOperation.SET,
				(uint)FFTAICommunicationFillingParameter.PATCH,
				new uint [] {
					BitConverter.ToUInt32(BitConverter.GetBytes(force), 0) });

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
				(uint)FFTAICommunicationRobotType.M1,
				(uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

		public int RequestSetSubtaskBasicForceAssistWithTargetPositionPosition(
			float xPosition)
		{
			int functionResult;

			functionResult = Model.DataSectionModel.RequestModel.Update(
				(uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetForceAssistWithTargetPositionPosition,
				(uint)FFTAICommunicationNumberOfParameter.ONE,
				(uint)FFTAICommunicationReadWriteOperation.SET,
				(uint)FFTAICommunicationFillingParameter.PATCH,
				new uint [] {
					BitConverter.ToUInt32(BitConverter.GetBytes(xPosition), 0) });

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
				(uint)FFTAICommunicationRobotType.M1,
				(uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Force Assist With Target Position) ---------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Force Resist Without Sensor) ---------------------------

        public int RequestSetSubtaskBasicForceResistWithoutSensorRatio(
        float ratio)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetForceResistWithoutSensorRatio,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(ratio), 0) });

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
                (uint)FFTAICommunicationRobotType.M1,
                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicForceResistWithoutSensorMaxForce(
			float xForce)
		{
			int functionResult;

			functionResult = Model.DataSectionModel.RequestModel.Update(
				(uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetForceResistWithoutSensorMaxForce,
				(uint)FFTAICommunicationNumberOfParameter.ONE,
				(uint)FFTAICommunicationReadWriteOperation.SET,
				(uint)FFTAICommunicationFillingParameter.PATCH,
				new uint [] {
					BitConverter.ToUInt32(BitConverter.GetBytes(xForce), 0) });

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
				(uint)FFTAICommunicationRobotType.M1,
				(uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

		//-------------------------------------------- Function Definition (Request - Subtask - Basic - Force Resist Without Sensor) ---------------------------

		//-------------------------------------------- Function Definition (Request - Subtask - Basic - Force Resist With Sensor) ------------------------------

		public int RequestSetSubtaskBasicForceResistWithSensorForce(
			float xForce)
		{
			int functionResult;

			functionResult = Model.DataSectionModel.RequestModel.Update(
				(uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetForceResistWithSensorForce,
				(uint)FFTAICommunicationNumberOfParameter.ONE,
				(uint)FFTAICommunicationReadWriteOperation.SET,
				(uint)FFTAICommunicationFillingParameter.PATCH,
				new uint [] {
					BitConverter.ToUInt32(BitConverter.GetBytes(xForce), 0) });

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
				(uint)FFTAICommunicationRobotType.M1,
				(uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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


		//-------------------------------------------- Function Definition (Request - Subtask - Basic - Force Resist With Sensor) ------------------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Transparent Control) -----------------------------------

        public int RequestSetSubtaskBasicTransparentControlOriginPosition(
            float xPosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetTransparentControlOriginPosition,
                                (uint)FFTAICommunicationNumberOfParameter.ONE,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(xPosition), 0) });

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
                                (uint)FFTAICommunicationRobotType.M1,
                                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicTransparentControlM(
            float xM)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetTransparentControlM,
                                (uint)FFTAICommunicationNumberOfParameter.ONE,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(xM), 0) });

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
                                (uint)FFTAICommunicationRobotType.M1,
                                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicTransparentControlB(
            float xB)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetTransparentControlB,
                                (uint)FFTAICommunicationNumberOfParameter.ONE,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(xB), 0) });

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
                                (uint)FFTAICommunicationRobotType.M1,
                                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicTransparentControlK(
            float xK)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetTransparentControlK,
                                (uint)FFTAICommunicationNumberOfParameter.ONE,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(xK), 0) });

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
                                (uint)FFTAICommunicationRobotType.M1,
                                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Transparent Control) -----------------------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Kinetic Control With Sensor) ---------------------------

        public int RequestSetSubtaskBasicKineticControlWithSensorForce(
            float xForce)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetKineticControlWithSensorForce,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(xForce), 0) });

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
                (uint)FFTAICommunicationRobotType.M1,
                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Kinetic Control With Sensor) ---------------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Transparent Control With Limit Spring Force) -----------

        public int RequestSetSubtaskBasicTransparentControlWithLimitSpringForceOriginPosition(
            float xPosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetTransparentControlWithLimitSpringForceOriginPoint ,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(xPosition), 0) });

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
                (uint)FFTAICommunicationRobotType.M1,
                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicTransparentControlWithLimitSpringForceM(
            float xM)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetTransparentControlWithLimitSpringForceM,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(xM), 0) });

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
                (uint)FFTAICommunicationRobotType.M1,
                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicTransparentControlWithLimitSpringForceB(
            float xB)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetTransparentControlWithLimitSpringForceB,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(xB), 0) });

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
                (uint)FFTAICommunicationRobotType.M1,
                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicTransparentControlWithLimitSpringForceK(
            float xK)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetTransparentControlWithLimitSpringForceK,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(xK), 0) });

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
                (uint)FFTAICommunicationRobotType.M1,
                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicTransparentControlWithLimitSpringForceLimitSpringForce(
            float xLimitSpringForce)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetTransparentControlWithLimitSpringForceLimitSpringForce,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(xLimitSpringForce), 0) });

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
                (uint)FFTAICommunicationRobotType.M1,
                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicGaitTarjectoryPeriodTimeControl(
            float periodTime)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetPassiveGaitTrajectoryPeriodTime,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                BitConverter.ToUInt32(BitConverter.GetBytes(periodTime), 0) });

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
                (uint)FFTAICommunicationRobotType.M1,
                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicSinFuctionKControl(
           float sinFunctionK)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetSinFunctionK,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                BitConverter.ToUInt32(BitConverter.GetBytes(sinFunctionK), 0) });

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
                (uint)FFTAICommunicationRobotType.M1,
                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicSinFuctionPeriodTimeControl(
           float periodTime)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM1TaskInterfaceOperationMode.SubtaskBasicSetSinfunctionPeriodTime,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                BitConverter.ToUInt32(BitConverter.GetBytes(periodTime), 0) });

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
                (uint)FFTAICommunicationRobotType.M1,
                (uint)FFTAICommunicationFunctionType.M1_TASK_INTERFACE,
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
            int operationMode = (int)model.DataSectionModel.ResponseModel.OperationMode;
            int readWriteOperation = (int)model.DataSectionModel.ResponseModel.ReadWriteOperation;

            switch (operationMode)
            {
                case FFTAICommunicationM1TaskInterfaceOperationMode.BasicFlagInformation:
                    {
                        switch (readWriteOperation)
                        {
                            case FFTAICommunicationReadWriteOperation.GET:
                            case FFTAICommunicationReadWriteOperation.READ:
                                StatusFlag.FlagTaskInProcess = BitConverter.ToUInt32(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[0]), 0);

                                break;
                            case FFTAICommunicationReadWriteOperation.SET:
                            case FFTAICommunicationReadWriteOperation.WRITE:
                                break;
                            default:
                                break;
                        }

                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        public int GetFunctionType()
        {
            return FFTAICommunicationFunctionType.M1_TASK_INTERFACE;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static FFTAICommunicationLib.DynaLinkHS;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationM2TaskInterface : FFTAICommunicationInterfaceBasic, IFFTAICommunicationInterfaceObserver
    {
        public int RequestSetWorkMode(int workMode)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.BasicWorkMode,
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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.BasicFlagTaskInProcess,
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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.BasicFlagInformation,
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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workMode"></param>
        /// <returns></returns>
        public int RequestSetDebugWorkMode(int workMode)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.DebugSetWorkMode,
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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.RelaySetWorkMode,
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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {

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
        public int RequestSetMasterControlWorkMode(int workMode)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.MasterControlSetWorkMode,
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

            functionResult = interfaceManager.Send(
                                FFTAICommunicationInterfaceRequestModel.HEADER_OF_REQUEST_FRAME,
                                (uint)FFTAICommunicationProtocolVersion.CurrentVersion,
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
            float horizontalJointKinetic, float verticalJointKinetic)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetJointKineticControlKinetic,
                (uint)FFTAICommunicationNumberOfParameter.TWO,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(horizontalJointKinetic), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(verticalJointKinetic), 0), });

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
                (uint)FFTAICommunicationRobotType.M2,
                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
            float horizontalJointAcceleration, float verticalJointAcceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetJointVelocityControlAcceleration,
                (uint)FFTAICommunicationNumberOfParameter.TWO,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(horizontalJointAcceleration), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(verticalJointAcceleration), 0), });

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
                (uint)FFTAICommunicationRobotType.M2,
                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
            float horizontalJointVelocity, float verticalJointVelocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetJointVelocityControlVelocity,
                (uint)FFTAICommunicationNumberOfParameter.TWO,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(horizontalJointVelocity), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(verticalJointVelocity), 0), });

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
                (uint)FFTAICommunicationRobotType.M2,
                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
            float horizontalJointAcceleration, float verticalJointAcceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetJointPositionControlAcceleration,
                (uint)FFTAICommunicationNumberOfParameter.TWO,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(horizontalJointAcceleration), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(verticalJointAcceleration), 0), });

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
                (uint)FFTAICommunicationRobotType.M2,
                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
            float horizontalJointVelocity, float verticalJointVelocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetJointPositionControlVelocity,
                (uint)FFTAICommunicationNumberOfParameter.TWO,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(horizontalJointVelocity), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(verticalJointVelocity), 0), });

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
                (uint)FFTAICommunicationRobotType.M2,
                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
            float horizontalJointPosition, float verticalJointPosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetJointPositionControlPosition,
                (uint)FFTAICommunicationNumberOfParameter.TWO,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(horizontalJointPosition), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(verticalJointPosition), 0), });

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
                (uint)FFTAICommunicationRobotType.M2,
                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
            float endEffectorXKinetic, float endEffectorYKinetic)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetEndEffectorKineticControlKinetic,
                (uint)FFTAICommunicationNumberOfParameter.TWO,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorXKinetic), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorYKinetic), 0), });

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
                (uint)FFTAICommunicationRobotType.M2,
                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
            float endEffectorXAcceleration, float endEffectorYAcceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetEndEffectorVelocityControlAcceleration,
                (uint)FFTAICommunicationNumberOfParameter.TWO,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorXAcceleration), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorYAcceleration), 0), });

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
                (uint)FFTAICommunicationRobotType.M2,
                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
            float endEffectorXVelocity, float endEffectorYVelocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetEndEffectorVelocityControlVelocity,
                (uint)FFTAICommunicationNumberOfParameter.TWO,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorXVelocity), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorYVelocity), 0), });

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
                (uint)FFTAICommunicationRobotType.M2,
                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
            float endEffectorXAcceleration, float endEffectorYAcceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetEndEffectorPositionControlAcceleration,
                (uint)FFTAICommunicationNumberOfParameter.TWO,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorXAcceleration), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorYAcceleration), 0), });

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
                (uint)FFTAICommunicationRobotType.M2,
                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
            float endEffectorXVelocity, float endEffectorYVelocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetEndEffectorPositionControlVelocity,
                (uint)FFTAICommunicationNumberOfParameter.TWO,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorXVelocity), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorYVelocity), 0), });

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
                (uint)FFTAICommunicationRobotType.M2,
                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
            float endEffectorXPosition, float endEffectorYPosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetEndEffectorPositionControlPosition,
                (uint)FFTAICommunicationNumberOfParameter.TWO,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorXPosition), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorYPosition), 0), });

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
                (uint)FFTAICommunicationRobotType.M2,
                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - End Effector Position Control) -------------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - FInd Home) ---------------------------------------------

        public int RequestSetSubtaskBasicFindHomeRequestKinetic(
            float endEffectorHorizontalKinetic, float endEffectorVerticalKinetic)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetFindHomeRequestKinetic,
                                (uint)FFTAICommunicationNumberOfParameter.TWO,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorHorizontalKinetic), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorVerticalKinetic), 0) });

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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetPassiveLinearMotionAcceleration,
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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetPassiveLinearMotionVelocity,
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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
            float endEffectorHorizontalPosition, float endEffectorVerticalPosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetPassiveLinearMotionPosition,
                                (uint)FFTAICommunicationNumberOfParameter.TWO,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorHorizontalPosition), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorVerticalPosition), 0), });

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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
            float xMass, float yMass)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetMassSimulationMass,
                                (uint)FFTAICommunicationNumberOfParameter.TWO,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(xMass), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(yMass), 0) });

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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicMassSimulationFrictionBc(
            float xFriction, float yFriction)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetMassSimulationFrictionBcFactor,
                                (uint)FFTAICommunicationNumberOfParameter.TWO,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(xFriction), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(yFriction), 0) });

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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicMassSimulationFrictionBv(
    float xFriction, float yFriction)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetMassSimulationFrictionBvFactor,
                                (uint)FFTAICommunicationNumberOfParameter.TWO,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint[] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(xFriction), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(yFriction), 0) });

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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
        float xRatio, float yRatio)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetForceAssistWithoutSensorRatio,
                                (uint)FFTAICommunicationNumberOfParameter.TWO,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint[] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(xRatio), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(yRatio), 0) });

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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
            float xForce, float yForce)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetForceAssistWithoutSensorMaxForce,
                                (uint)FFTAICommunicationNumberOfParameter.TWO,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(xForce), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(yForce), 0) });

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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
        public int RequestSetSubtaskBasicForceAssistWithoutSensorForce(
            float xForce, float yForce)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetForceAssistWithoutSensorForce,
                (uint)FFTAICommunicationNumberOfParameter.TWO,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(xForce), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(yForce), 0) });

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
                (uint)FFTAICommunicationRobotType.M2,
                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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


        public int RequestSetSubtaskBasicForceAssistWithSensorForce(
			float xForce, float yForce)
		{
			int functionResult;

			functionResult = Model.DataSectionModel.RequestModel.Update(
				(uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetForceAssistWithSensorForce,
				(uint)FFTAICommunicationNumberOfParameter.TWO,
				(uint)FFTAICommunicationReadWriteOperation.SET,
				(uint)FFTAICommunicationFillingParameter.PATCH,
				new uint [] {
					BitConverter.ToUInt32(BitConverter.GetBytes(xForce), 0),
					BitConverter.ToUInt32(BitConverter.GetBytes(yForce), 0) });

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
				(uint)FFTAICommunicationRobotType.M2,
				(uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetForceAssistWithTargetPositionForce,
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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
            float xPosition, float yPosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetForceAssistWithTargetPositionPosition,
                                (uint)FFTAICommunicationNumberOfParameter.TWO,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(xPosition), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(yPosition), 0) });

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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicForceAssistWithTargetPosition1Force(
    float force)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetForceAssistWithTargetPosition1Force,
                                (uint)FFTAICommunicationNumberOfParameter.ONE,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint[] {
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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicForceAssistWithTargetPosition1Position(
            float xPosition, float yPosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetForceAssistWithTargetPosition1Position,
                                (uint)FFTAICommunicationNumberOfParameter.TWO,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint[] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(xPosition), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(yPosition), 0) });

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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicForceAssistWithTargetPosition1MaxVeloctiy(
          float xMaxVelocity, float yMaxVelocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetForceAssistWithTargetPosition1MaxVelocity,
                                (uint)FFTAICommunicationNumberOfParameter.TWO,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint[] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(xMaxVelocity), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(yMaxVelocity), 0) });

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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicForceAssistWithTargetPosition1ChangeInStep(
          float xFactor, float yFactor)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetForceAssistWithTargetPosition1ChangeInStep,
                                (uint)FFTAICommunicationNumberOfParameter.TWO,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint[] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(xFactor), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(yFactor), 0) });

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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
            float xRatio, float yRatio)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
								(uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetForceResistWithoutSensorRatio,
                                (uint)FFTAICommunicationNumberOfParameter.TWO,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(xRatio), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(yRatio), 0) });

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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
           float xForce, float yForce)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetForceResistWithoutSensorMaxForce,
                                (uint)FFTAICommunicationNumberOfParameter.TWO,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint[] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(xForce), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(yForce), 0) });

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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
        public int RequestSetSubtaskBasicForceResistWithoutSensorForce(
          float xForce, float yForce)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetForceResistWithoutSensorForce,
                (uint)FFTAICommunicationNumberOfParameter.TWO,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(xForce), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(yForce), 0) });

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
                (uint)FFTAICommunicationRobotType.M2,
                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicForceResistWithSensorForce(
			float xForce, float yForce)
		{
			int functionResult;

			functionResult = Model.DataSectionModel.RequestModel.Update(
				(uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetForceResistWithSensorForce,
				(uint)FFTAICommunicationNumberOfParameter.TWO,
				(uint)FFTAICommunicationReadWriteOperation.SET,
				(uint)FFTAICommunicationFillingParameter.PATCH,
				new uint [] {
					BitConverter.ToUInt32(BitConverter.GetBytes(xForce), 0),
					BitConverter.ToUInt32(BitConverter.GetBytes(yForce), 0) });

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
				(uint)FFTAICommunicationRobotType.M2,
				(uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
            float xPosition, float yPosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetTransparentControlOriginPoint ,
                                (uint)FFTAICommunicationNumberOfParameter.TWO,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(xPosition), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(yPosition), 0) });

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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
            float xM, float yM)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetTransparentControlM,
                                (uint)FFTAICommunicationNumberOfParameter.TWO,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(xM), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(yM), 0) });

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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
            float xB, float yB)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetTransparentControlB,
                                (uint)FFTAICommunicationNumberOfParameter.TWO,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(xB), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(yB), 0) });

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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
            float xK, float yK)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetTransparentControlK,
                                (uint)FFTAICommunicationNumberOfParameter.TWO,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(xK), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(yK), 0) });

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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicTransparentControlLimitSpeed(
            float xSpeed, float ySpeed)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetTransparentControlLimitSpeed,
                                (uint)FFTAICommunicationNumberOfParameter.TWO,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(xSpeed), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(ySpeed), 0) });

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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicTransparentControl1OriginPosition(
            float xPosition, float yPosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetTransparentControl1OriginPoint,
                                (uint)FFTAICommunicationNumberOfParameter.TWO,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint[] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(xPosition), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(yPosition), 0) });

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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicTransparentControl1M(
            float xM, float yM)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetTransparentControl1M,
                                (uint)FFTAICommunicationNumberOfParameter.TWO,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint[] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(xM), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(yM), 0) });

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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicTransparentControl1B(
            float xB, float yB)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetTransparentControl1B,
                                (uint)FFTAICommunicationNumberOfParameter.TWO,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint[] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(xB), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(yB), 0) });

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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicTransparentControl1K(
            float xK, float yK)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetTransparentControl1K,
                                (uint)FFTAICommunicationNumberOfParameter.TWO,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint[] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(xK), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(yK), 0) });

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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicTransparentControl1Period(
            float period)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetTransparentControl1Period,
                                (uint)FFTAICommunicationNumberOfParameter.ONE,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint[] {BitConverter.ToUInt32(BitConverter.GetBytes(period), 0)});

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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicTransparentControl1ChangeOfK(
          float changeOfK)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetTransparentControl1ChangeOfK,
                                (uint)FFTAICommunicationNumberOfParameter.ONE,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint[] { BitConverter.ToUInt32(BitConverter.GetBytes(changeOfK), 0) });

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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicTransparentControl1LimitSpeed(
          float xSpeed, float ySpeed)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetTransparentControl1LimitSpeed,
                                (uint)FFTAICommunicationNumberOfParameter.TWO,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint[] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(xSpeed), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(ySpeed), 0) });

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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Tunnel Guidance Control) -------------------------------

        public int RequestSetSubtaskBasicTunnelGuidanceControlPointA(
            float xPosition, float yPosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetTunnelGuidanceControlPointA,
                                (uint)FFTAICommunicationNumberOfParameter.TWO,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(xPosition), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(yPosition), 0) });

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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicTunnelGuidanceControlPointB(
            float xPosition, float yPosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetTunnelGuidanceControlPointB,
                                (uint)FFTAICommunicationNumberOfParameter.TWO,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(xPosition), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(yPosition), 0) });

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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicTunnelGuidanceControlM(
            float xM, float yM)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetTunnelGuidanceControlM,
                (uint)FFTAICommunicationNumberOfParameter.TWO,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(xM), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(yM), 0) });

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
                (uint)FFTAICommunicationRobotType.M2,
                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicTunnelGuidanceControlB(
            float xB, float yB)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetTunnelGuidanceControlB,
                (uint)FFTAICommunicationNumberOfParameter.TWO,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(xB), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(yB), 0) });

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
                (uint)FFTAICommunicationRobotType.M2,
                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicTunnelGuidanceControlK(
            float xK, float yK)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetTunnelGuidanceControlK,
                (uint)FFTAICommunicationNumberOfParameter.TWO,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(xK), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(yK), 0) });

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
                (uint)FFTAICommunicationRobotType.M2,
                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Tunnel Guidance Control) -------------------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Draw Infinity Curve) -----------------------------------

        public int RequestSetSubtaskBasicDrawInfinityCurveOriginPoint (
            float xPosition, float yPosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetDrawInfinityCurveOriginPoint ,
                                (uint)FFTAICommunicationNumberOfParameter.TWO,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(xPosition), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(yPosition), 0) });

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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicDrawInfinityCurveTimePeriod(
            float timePeriod)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetDrawInfinityCurveTimePeriod,
                                (uint)FFTAICommunicationNumberOfParameter.ONE,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(timePeriod), 0) });

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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicDrawInfinityCurveScale(
            float xScale, float yScale)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetDrawInfinityCurveScale,
                                (uint)FFTAICommunicationNumberOfParameter.TWO,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(xScale), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(yScale), 0) });

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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Draw Infinity Curve) -----------------------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Draw Circle Curve) -------------------------------------

        public int RequestSetSubtaskBasicDrawCircleCurveOriginPoint (
            float xPosition, float yPosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetDrawCircleCurveOriginPoint ,
                                (uint)FFTAICommunicationNumberOfParameter.TWO,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(xPosition), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(yPosition), 0) });

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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicDrawCircleCurveTimePeriod(
            float timePeriod)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetDrawCircleCurveTimePeriod,
                                (uint)FFTAICommunicationNumberOfParameter.ONE,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(timePeriod), 0) });

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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicDrawCircleCurveScale(
            float xScale, float yScale)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetDrawCircleCurveScale,
                                (uint)FFTAICommunicationNumberOfParameter.TWO,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(xScale), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(yScale), 0) });

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
                                (uint)FFTAICommunicationRobotType.M2,
                                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Draw Circle Curve) -------------------------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Kinetic Control With Sensor) ---------------------------

        public int RequestSetSubtaskBasicKineticControlWithSensorForce(
            float xForce, float yForce)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetKineticControlWithSensorForce,
                (uint)FFTAICommunicationNumberOfParameter.TWO,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(xForce), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(yForce), 0) });

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
                (uint)FFTAICommunicationRobotType.M2,
                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
            float xPosition, float yPosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetTransparentControlWithLimitSpringForceOriginPoint ,
                (uint)FFTAICommunicationNumberOfParameter.TWO,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(xPosition), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(yPosition), 0) });

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
                (uint)FFTAICommunicationRobotType.M2,
                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
            float xM, float yM)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetTransparentControlWithLimitSpringForceM,
                (uint)FFTAICommunicationNumberOfParameter.TWO,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(xM), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(yM), 0) });

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
                (uint)FFTAICommunicationRobotType.M2,
                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
            float xB, float yB)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetTransparentControlWithLimitSpringForceB,
                (uint)FFTAICommunicationNumberOfParameter.TWO,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(xB), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(yB), 0) });

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
                (uint)FFTAICommunicationRobotType.M2,
                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
            float xK, float yK)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetTransparentControlWithLimitSpringForceK,
                (uint)FFTAICommunicationNumberOfParameter.TWO,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(xK), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(yK), 0) });

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
                (uint)FFTAICommunicationRobotType.M2,
                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
            float xLimitSpringForce, float yLimitSpringForce)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetTransparentControlWithLimitSpringForceLimitSpringForce,
                (uint)FFTAICommunicationNumberOfParameter.TWO,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(xLimitSpringForce), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(yLimitSpringForce), 0) });

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
                (uint)FFTAICommunicationRobotType.M2,
                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Transparent Control With Limit Spring Force) -----------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Minimum Jerk Trajectory Control) -----------------------

        public int RequestSetSubtaskBasicMinimumJerkTrajectoryControlPointA(
            float xPointA, 
            float yPointA)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicMinimumJerkTrajectoryControlPointA,
                (uint)FFTAICommunicationNumberOfParameter.TWO,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(xPointA), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(yPointA), 0) });

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
                (uint)FFTAICommunicationRobotType.M2,
                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicMinimumJerkTrajectoryControlPointB(
            float xPointB, 
            float yPointB)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicMinimumJerkTrajectoryControlPointB,
                (uint)FFTAICommunicationNumberOfParameter.TWO,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(xPointB), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(yPointB), 0) });

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
                (uint)FFTAICommunicationRobotType.M2,
                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicMinimumJerkTrajectoryControlInitialTime()
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicMinimumJerkTrajectoryControlInitialTime,
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

            functionResult = interfaceManager.Send(
                FFTAICommunicationInterfaceRequestModel.HEADER_OF_REQUEST_FRAME,
                (uint)FFTAICommunicationProtocolVersion.CurrentVersion,
                (uint)FFTAICommunicationRobotType.M2,
                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicMinimumJerkTrajectoryControlTotalTime(
            float totalTime)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicMinimumJerkTrajectoryControlTotalTime,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] { 
                BitConverter.ToUInt32(BitConverter.GetBytes(totalTime), 0)});

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
                (uint)FFTAICommunicationRobotType.M2,
                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Minimum Jerk Trajectory Control) -----------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Mass Simulation Without Sensor) -----------------------

        public int RequestSetSubtaskBasicMassSimulationWithoutSensor(
            float massX,
            float frictionBcX,
            float frictionBvX,
            float massY,
            float frictionBcY,
            float frictionBvY)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetMassSimulationWithoutSensor,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                BitConverter.ToUInt32(BitConverter.GetBytes(massX), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(frictionBcX), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(frictionBvX), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(massY), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(frictionBcY), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(frictionBvY), 0),});

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
                (uint)FFTAICommunicationRobotType.M2,
                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicMassSimulationWithoutSensorMass(
           float massX,
           float massY)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetMassSimulationWithoutSensorMass,
                (uint)FFTAICommunicationNumberOfParameter.TWO,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                BitConverter.ToUInt32(BitConverter.GetBytes(massX), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(massY), 0)});

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
                (uint)FFTAICommunicationRobotType.M2,
                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicMassSimulationWithoutSensorFrictionBc(
          float frictionBcX,
          float frictionBcY)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetMassSimulationWithoutSensorFrictionBc,
                (uint)FFTAICommunicationNumberOfParameter.TWO,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                BitConverter.ToUInt32(BitConverter.GetBytes(frictionBcX), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(frictionBcY), 0)});

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
                (uint)FFTAICommunicationRobotType.M2,
                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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

        public int RequestSetSubtaskBasicMassSimulationWithoutSensorFrictionBv(
            float frictionBvX,
            float frictionBvY)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM2TaskInterfaceOperationMode.SubtaskBasicSetMassSimulationWithoutSensorFrictionBv,
                (uint)FFTAICommunicationNumberOfParameter.TWO,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                BitConverter.ToUInt32(BitConverter.GetBytes(frictionBvX), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(frictionBvY), 0)});

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
                (uint)FFTAICommunicationRobotType.M2,
                (uint)FFTAICommunicationFunctionType.M2_TASK_INTERFACE,
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
                case FFTAICommunicationM2TaskInterfaceOperationMode.BasicFlagInformation:
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
            return FFTAICommunicationFunctionType.M2_TASK_INTERFACE;
        }
    }
}

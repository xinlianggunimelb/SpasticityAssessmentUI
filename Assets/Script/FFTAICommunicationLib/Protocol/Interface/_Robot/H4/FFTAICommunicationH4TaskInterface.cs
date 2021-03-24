using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static FFTAICommunicationLib.DynaLinkHS;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationH4TaskInterface : FFTAICommunicationInterfaceBasic, IFFTAICommunicationInterfaceObserver
    {
        public int RequestSetWorkMode(int workMode)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.BASIC_WORK_MODE,
                                (uint)FFTAICommunicationNumberOfParameter.ONE,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint[] { (uint)workMode });

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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.BASIC_FLAG_TASK_IN_PROCESS,
                (uint)FFTAICommunicationNumberOfParameter.ZERO,
                (uint)FFTAICommunicationReadWriteOperation.READ,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] { });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.BASIC_FLAG_INFORMATION,
                (uint)FFTAICommunicationNumberOfParameter.ZERO,
                (uint)FFTAICommunicationReadWriteOperation.READ,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] { });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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

        public int RequestReadSubtasWalkPassiveState()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_WALK_PASSIVE_1_STATE,
                (uint)FFTAICommunicationNumberOfParameter.ZERO,
                (uint)FFTAICommunicationReadWriteOperation.READ,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] { });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Joint Kinetic Control) ---------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leftLegHipJointKinetic"></param>
        /// <param name="leftLegKneeJointKinetic"></param>
        /// <param name="rightLegHipJointKinetic"></param>
        /// <param name="rightLegKneeJointKinetic"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicJointKineticControlKinetic(
            float leftLegHipJointKinetic,
            float leftLegKneeJointKinetic,
            float rightLegHipJointKinetic,
            float rightLegKneeJointKinetic)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_JOINT_KINETIC_CONTROL_KINETIC,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipJointKinetic), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeJointKinetic), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipJointKinetic), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeJointKinetic), 0), });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leftLegHipJointAcceleration"></param>
        /// <param name="leftLegKneeJointAcceleration"></param>
        /// <param name="rightLegHipJointAcceleration"></param>
        /// <param name="rightLegKneeJointAcceleration"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicJointVelocityControlAcceleration(
            float leftLegHipJointAcceleration,
            float leftLegKneeJointAcceleration,
            float rightLegHipJointAcceleration,
            float rightLegKneeJointAcceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_JOINT_VELOCITY_CONTROL_ACCELERATION,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipJointAcceleration), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeJointAcceleration), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipJointAcceleration), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeJointAcceleration), 0), });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="leftLegHipJointVelocity"></param>
        /// <param name="leftLegKneeJointVelocity"></param>
        /// <param name="rightLegHipJointVelocity"></param>
        /// <param name="rightLegKneeJointVelocity"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicJointVelocityControlVelocity(
            float leftLegHipJointVelocity,
            float leftLegKneeJointVelocity,
            float rightLegHipJointVelocity,
            float rightLegKneeJointVelocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_JOINT_VELOCITY_CONTROL_VELOCITY,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipJointVelocity), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeJointVelocity), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipJointVelocity), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeJointVelocity), 0), });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leftLegHipJointAcceleration"></param>
        /// <param name="leftLegKneeJointAcceleration"></param>
        /// <param name="rightLegHipJointAcceleration"></param>
        /// <param name="rightLegKneeJointAcceleration"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicJointPositionControlAcceleration(
            float leftLegHipJointAcceleration,
            float leftLegKneeJointAcceleration,
            float rightLegHipJointAcceleration,
            float rightLegKneeJointAcceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_JOINT_POSITION_CONTROL_ACCELERATION,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipJointAcceleration), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeJointAcceleration), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipJointAcceleration), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeJointAcceleration), 0), });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="leftLegHipJointVelocity"></param>
        /// <param name="leftLegKneeJointVelocity"></param>
        /// <param name="rightLegHipJointVelocity"></param>
        /// <param name="rightLegKneeJointVelocity"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicJointPositionControlVelocity(
            float leftLegHipJointVelocity,
            float leftLegKneeJointVelocity,
            float rightLegHipJointVelocity,
            float rightLegKneeJointVelocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_JOINT_POSITION_CONTROL_VELOCITY,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipJointVelocity), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeJointVelocity), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipJointVelocity), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeJointVelocity), 0), });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="leftLegHipJointPosition"></param>
        /// <param name="leftLegKneeJointPosition"></param>
        /// <param name="rightLegHipJointPosition"></param>
        /// <param name="rightLegKneeJointPosition"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicJointPositionControlPosition(
            float leftLegHipJointPosition,
            float leftLegKneeJointPosition,
            float rightLegHipJointPosition,
            float rightLegKneeJointPosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_JOINT_POSITION_CONTROL_POSITION,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipJointPosition), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeJointPosition), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipJointPosition), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeJointPosition), 0), });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endEffectorX1Kinetic"></param>
        /// <param name="endEffectorY1Kinetic"></param>
        /// <param name="endEffectorX2Kinetic"></param>
        /// <param name="endEffectorY2Kinetic"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicEndEffectorKineticControlKinetic(
            float endEffectorX1Kinetic,
            float endEffectorY1Kinetic,
            float endEffectorX2Kinetic,
            float endEffectorY2Kinetic)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_END_EFFECTOR_KINETIC_CONTROL_KINETIC,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorX1Kinetic), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorY1Kinetic), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorX2Kinetic), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorY2Kinetic), 0), });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endEffectorX1Acceleration"></param>
        /// <param name="endEffectorY1Acceleration"></param>
        /// <param name="endEffectorH4Acceleration"></param>
        /// <param name="endEffectorY2Acceleration"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicEndEffectorVelocityControlAcceleration(
            float endEffectorX1Acceleration,
            float endEffectorY1Acceleration,
            float endEffectorH4Acceleration,
            float endEffectorY2Acceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_END_EFFECTOR_VELOCITY_CONTROL_ACCELERATION,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorX1Acceleration), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorY1Acceleration), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorH4Acceleration), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorY2Acceleration), 0), });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="endEffectorX1Velocity"></param>
        /// <param name="endEffectorY1Velocity"></param>
        /// <param name="endEffectorH4Velocity"></param>
        /// <param name="endEffectorY2Velocity"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicEndEffectorVelocityControlVelocity(
            float endEffectorX1Velocity,
            float endEffectorY1Velocity,
            float endEffectorH4Velocity,
            float endEffectorY2Velocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_END_EFFECTOR_VELOCITY_CONTROL_VELOCITY,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorX1Velocity), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorY1Velocity), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorH4Velocity), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorY2Velocity), 0), });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endEffectorX1Acceleration"></param>
        /// <param name="endEffectorY1Acceleration"></param>
        /// <param name="endEffectorH4Acceleration"></param>
        /// <param name="endEffectorY2Acceleration"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicEndEffectorPositionControlAcceleration(
            float endEffectorX1Acceleration,
            float endEffectorY1Acceleration,
            float endEffectorH4Acceleration,
            float endEffectorY2Acceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_END_EFFECTOR_POSITION_CONTROL_ACCELERATION,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorX1Acceleration), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorY1Acceleration), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorH4Acceleration), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorY2Acceleration), 0), });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="endEffectorX1Velocity"></param>
        /// <param name="endEffectorY1Velocity"></param>
        /// <param name="endEffectorH4Velocity"></param>
        /// <param name="endEffectorY2Velocity"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicEndEffectorPositionControlVelocity(
            float endEffectorX1Velocity,
            float endEffectorY1Velocity,
            float endEffectorH4Velocity,
            float endEffectorY2Velocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_END_EFFECTOR_POSITION_CONTROL_VELOCITY,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorX1Velocity), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorY1Velocity), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorH4Velocity), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorY2Velocity), 0), });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="endEffectorX1Position"></param>
        /// <param name="endEffectorY1Position"></param>
        /// <param name="endEffectorH4Position"></param>
        /// <param name="endEffectorY2Position"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicEndEffectorPositionControlPosition(
            float endEffectorX1Position,
            float endEffectorY1Position,
            float endEffectorH4Position,
            float endEffectorY2Position)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_END_EFFECTOR_POSITION_CONTROL_POSITION,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorX1Position), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorY1Position), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorH4Position), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorY2Position), 0), });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Move) ------------------------------------------

        /// <summary>
        /// Requests the set subtask basic passive move acceleration.
        /// </summary>
        /// <returns>The set subtask basic passive move acceleration.</returns>
        /// <param name="leftLegHipAcceleration">Left leg hip acceleration.</param>
        /// <param name="leftLegKneeAcceleration">Left leg knee acceleration.</param>
        /// <param name="rightLegHipAcceleration">Right leg hip acceleration.</param>
        /// <param name="rightLegKneeAcceleration">Right leg knee acceleration.</param>
        public int RequestSetSubtaskBasicPassiveMoveAcceleration(
            float leftLegHipAcceleration,
            float leftLegKneeAcceleration,
            float rightLegHipAcceleration,
            float rightLegKneeAcceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_MOVE_ACCELERATION,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeAcceleration), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// Requests the set subtask basic passive move velocity.
        /// </summary>
        /// <returns>The set subtask basic passive move velocity.</returns>
        /// <param name="leftLegHipVelocity">Left leg hip velocity.</param>
        /// <param name="leftLegKneeVelocity">Left leg knee velocity.</param>
        /// <param name="rightLegHipVelocity">Right leg hip velocity.</param>
        /// <param name="rightLegKneeVelocity">Right leg knee velocity.</param>
        public int RequestSetSubtaskBasicPassiveMoveVelocity(
            float leftLegHipVelocity,
            float leftLegKneeVelocity,
            float rightLegHipVelocity,
            float rightLegKneeVelocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_MOVE_VELOCITY,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeVelocity), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// Requests the set subtask basic passive move position.
        /// </summary>
        /// <returns>The set subtask basic passive move position.</returns>
        /// <param name="leftLegHipPosition">Left leg hip position.</param>
        /// <param name="leftLegKneePosition">Left leg knee position.</param>
        /// <param name="rightLegHipPosition">Right leg hip position.</param>
        /// <param name="rightLegKneePosition">Right leg knee position.</param>
        public int RequestSetSubtaskBasicPassiveMovePosition(
            float leftLegHipPosition,
            float leftLegKneePosition,
            float rightLegHipPosition,
            float rightLegKneePosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_MOVE_POSITION,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePosition), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Move) ------------------------------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Assist Move) -------------------------------------------

        /// <summary>
        /// Requests the set subtask basic assist move kinetic.
        /// </summary>
        /// <returns>The set subtask basic assist move kinetic.</returns>
        /// <param name="leftLegHipKinetic">Left leg hip kinetic.</param>
        /// <param name="leftLegKneeKinetic">Left leg knee kinetic.</param>
        /// <param name="rightLegHipKinetic">Right leg hip kinetic.</param>
        /// <param name="rightLegKneeKinetic">Right leg knee kinetic.</param>
        public int RequestSetSubtaskBasicAssistMoveKinetic(
            float leftLegHipKinetic,
            float leftLegKneeKinetic,
            float rightLegHipKinetic,
            float rightLegKneeKinetic)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_ASSIST_MOVE_KINETIC,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipKinetic), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeKinetic), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipKinetic), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeKinetic), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// Requests the set subtask basic assist move position.
        /// </summary>
        /// <returns>The set subtask basic assist move position.</returns>
        /// <param name="leftLegHipPosition">Left leg hip position.</param>
        /// <param name="leftLegKneePosition">Left leg knee position.</param>
        /// <param name="rightLegHipPosition">Right leg hip position.</param>
        /// <param name="rightLegKneePosition">Right leg knee position.</param>
        public int RequestSetSubtaskBasicAssistMovePosition(
            float leftLegHipPosition,
            float leftLegKneePosition,
            float rightLegHipPosition,
            float rightLegKneePosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_ASSIST_MOVE_POSITION,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePosition), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Assist Move) -------------------------------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Active Move) -------------------------------------------

        /// <summary>
        /// Requests the set subtask basic active move kinetic.
        /// </summary>
        /// <returns>The set subtask basic active move kinetic.</returns>
        /// <param name="leftLegHipKinetic">Left leg hip kinetic.</param>
        /// <param name="leftLegKneeKinetic">Left leg knee kinetic.</param>
        /// <param name="rightLegHipKinetic">Right leg hip kinetic.</param>
        /// <param name="rightLegKneeKinetic">Right leg knee kinetic.</param>
        public int RequestSetSubtaskBasicActiveMoveKinetic(
            float leftLegHipKinetic,
            float leftLegKneeKinetic,
            float rightLegHipKinetic,
            float rightLegKneeKinetic)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_ACTIVE_MOVE_KINETIC,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipKinetic), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeKinetic), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipKinetic), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeKinetic), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Active Move) -------------------------------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Transparent Control Move) ------------------------------

        /// <summary>
        /// Requests the set subtask basic transparent control move origin position.
        /// </summary>
        /// <returns>The set subtask basic transparent control move origin position.</returns>
        /// <param name="leftLegHipOriginPosition">Left leg hip origin position.</param>
        /// <param name="leftLegKneeOriginPosition">Left leg knee origin position.</param>
        /// <param name="rightLegHipOriginPosition">Right leg hip origin position.</param>
        /// <param name="rightLegKneeOriginPosition">Right leg knee origin position.</param>
        public int RequestSetSubtaskBasicTransparentControlMoveOriginPosition(
            float leftLegHipOriginPosition,
            float leftLegKneeOriginPosition,
            float rightLegHipOriginPosition,
            float rightLegKneeOriginPosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_TRANSPARENT_CONTROL_MOVE_ORIGIN_POINT,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipOriginPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeOriginPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipOriginPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeOriginPosition), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// Requests the set subtask basic transparent control move m.
        /// </summary>
        /// <returns>The set subtask basic transparent control move m.</returns>
        /// <param name="leftLegHipM">Left leg hip m.</param>
        /// <param name="leftLegKneeM">Left leg knee m.</param>
        /// <param name="rightLegHipM">Right leg hip m.</param>
        /// <param name="rightLegKneeM">Right leg knee m.</param>
        public int RequestSetSubtaskBasicTransparentControlMoveM(
            float leftLegHipM,
            float leftLegKneeM,
            float rightLegHipM,
            float rightLegKneeM)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_TRANSPARENT_CONTROL_MOVE_M,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipM), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeM), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipM), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeM), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// Requests the set subtask basic transparent control move b.
        /// </summary>
        /// <returns>The set subtask basic transparent control move b.</returns>
        /// <param name="leftLegHipB">Left leg hip b.</param>
        /// <param name="leftLegKneeB">Left leg knee b.</param>
        /// <param name="rightLegHipB">Right leg hip b.</param>
        /// <param name="rightLegKneeB">Right leg knee b.</param>
        public int RequestSetSubtaskBasicTransparentControlMoveB(
            float leftLegHipB,
            float leftLegKneeB,
            float rightLegHipB,
            float rightLegKneeB)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_TRANSPARENT_CONTROL_MOVE_B,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipB), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeB), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipB), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeB), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// Requests the set subtask basic transparent control move k.
        /// </summary>
        /// <returns>The set subtask basic transparent control move k.</returns>
        /// <param name="leftLegHipK">Left leg hip k.</param>
        /// <param name="leftLegKneeK">Left leg knee k.</param>
        /// <param name="rightLegHipK">Right leg hip k.</param>
        /// <param name="rightLegKneeK">Right leg knee k.</param>
        public int RequestSetSubtaskBasicTransparentControlMoveK(
            float leftLegHipK,
            float leftLegKneeK,
            float rightLegHipK,
            float rightLegKneeK)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_TRANSPARENT_CONTROL_MOVE_K,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipK), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeK), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipK), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeK), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Transparent Control Move) ------------------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Sit) -------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leftLegHipAcceleration"></param>
        /// <param name="leftLegKneeAcceleration"></param>
        /// <param name="rightLegHipAcceleration"></param>
        /// <param name="rightLegKneeAcceleration"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveSitAcceleration(
            float leftLegHipAcceleration,
            float leftLegKneeAcceleration,
            float rightLegHipAcceleration,
            float rightLegKneeAcceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_SIT_ACCELERATION,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeAcceleration), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="leftLegHipVelocity"></param>
        /// <param name="leftLegKneeVelocity"></param>
        /// <param name="rightLegHipVelocity"></param>
        /// <param name="rightLegKneeVelocity"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveSitVelocity(
            float leftLegHipVelocity,
            float leftLegKneeVelocity,
            float rightLegHipVelocity,
            float rightLegKneeVelocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_SIT_VELOCITY,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeVelocity), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="leftLegHipPosition"></param>
        /// <param name="leftLegKneePosition"></param>
        /// <param name="rightLegHipPosition"></param>
        /// <param name="rightLegKneePosition"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveSitPosition(
            float leftLegHipPosition,
            float leftLegKneePosition,
            float rightLegHipPosition,
            float rightLegKneePosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_SIT_POSITION,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePosition), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="leftLegHipPositionOffset"></param>
        /// <param name="leftLegKneePositionOffset"></param>
        /// <param name="rightLegHipPositionOffset"></param>
        /// <param name="rightLegKneePositionOffset"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveSitPositionOffset(
           float leftLegHipPositionOffset,
           float leftLegKneePositionOffset,
           float rightLegHipPositionOffset,
           float rightLegKneePositionOffset)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_SIT_POSITION_OFFSET,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePositionOffset), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="runSpeedTimes"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveSitRunSpeedTimes(
           float runSpeedTimes)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_SIT_RUN_SPEED_TIMES,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(runSpeedTimes), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Sit) -------------------------------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Stand) -----------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leftLegHipAcceleration"></param>
        /// <param name="leftLegKneeAcceleration"></param>
        /// <param name="rightLegHipAcceleration"></param>
        /// <param name="rightLegKneeAcceleration"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveStandAcceleration(
            float leftLegHipAcceleration,
            float leftLegKneeAcceleration,
            float rightLegHipAcceleration,
            float rightLegKneeAcceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_STAND_ACCELERATION,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeAcceleration), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="leftLegHipVelocity"></param>
        /// <param name="leftLegKneeVelocity"></param>
        /// <param name="rightLegHipVelocity"></param>
        /// <param name="rightLegKneeVelocity"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveStandVelocity(
            float leftLegHipVelocity,
            float leftLegKneeVelocity,
            float rightLegHipVelocity,
            float rightLegKneeVelocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_STAND_VELOCITY,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeVelocity), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="leftLegHipPosition"></param>
        /// <param name="leftLegKneePosition"></param>
        /// <param name="rightLegHipPosition"></param>
        /// <param name="rightLegKneePosition"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveStandPosition(
            float leftLegHipPosition,
            float leftLegKneePosition,
            float rightLegHipPosition,
            float rightLegKneePosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_STAND_POSITION,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePosition), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="leftLegHipPositionOffset"></param>
        /// <param name="leftLegKneePositionOffset"></param>
        /// <param name="rightLegHipPositionOffset"></param>
        /// <param name="rightLegKneePositionOffset"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveStandPositionOffset(
           float leftLegHipPositionOffset,
           float leftLegKneePositionOffset,
           float rightLegHipPositionOffset,
           float rightLegKneePositionOffset)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_STAND_POSITION_OFFSET,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePositionOffset), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="runSpeedTimes"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveStandRunSpeedTimes(
           float runSpeedTimes)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_STAND_RUN_SPEED_TIMES,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(runSpeedTimes), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Stand) -----------------------------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Body Ahead Sit) --------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leftLegHipAcceleration"></param>
        /// <param name="leftLegKneeAcceleration"></param>
        /// <param name="rightLegHipAcceleration"></param>
        /// <param name="rightLegKneeAcceleration"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveBASitAcceleration(
            float leftLegHipAcceleration,
            float leftLegKneeAcceleration,
            float rightLegHipAcceleration,
            float rightLegKneeAcceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_BASIT_ACCELERATION,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeAcceleration), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="leftLegHipVelocity"></param>
        /// <param name="leftLegKneeVelocity"></param>
        /// <param name="rightLegHipVelocity"></param>
        /// <param name="rightLegKneeVelocity"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveBASitVelocity(
            float leftLegHipVelocity,
            float leftLegKneeVelocity,
            float rightLegHipVelocity,
            float rightLegKneeVelocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_BASIT_VELOCITY,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeVelocity), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="leftLegHipPosition"></param>
        /// <param name="leftLegKneePosition"></param>
        /// <param name="rightLegHipPosition"></param>
        /// <param name="rightLegKneePosition"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveBASitPosition(
            float leftLegHipPosition,
            float leftLegKneePosition,
            float rightLegHipPosition,
            float rightLegKneePosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_BASIT_POSITION,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePosition), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="leftLegHipPositionOffset"></param>
        /// <param name="leftLegKneePositionOffset"></param>
        /// <param name="rightLegHipPositionOffset"></param>
        /// <param name="rightLegKneePositionOffset"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveBASitPositionOffset(
           float leftLegHipPositionOffset,
           float leftLegKneePositionOffset,
           float rightLegHipPositionOffset,
           float rightLegKneePositionOffset)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_BASIT_POSITION_OFFSET,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePositionOffset), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="runSpeedTimes"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveBASitRunSpeedTimes(
           float runSpeedTimes)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_BASIT_RUN_SPEED_TIMES,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(runSpeedTimes), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Body Ahead Sit) --------------------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Body Ahead Stand) ------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leftLegHipAcceleration"></param>
        /// <param name="leftLegKneeAcceleration"></param>
        /// <param name="rightLegHipAcceleration"></param>
        /// <param name="rightLegKneeAcceleration"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveBAStandAcceleration(
            float leftLegHipAcceleration,
            float leftLegKneeAcceleration,
            float rightLegHipAcceleration,
            float rightLegKneeAcceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_BASTAND_ACCELERATION,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeAcceleration), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="leftLegHipVelocity"></param>
        /// <param name="leftLegKneeVelocity"></param>
        /// <param name="rightLegHipVelocity"></param>
        /// <param name="rightLegKneeVelocity"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveBAStandVelocity(
            float leftLegHipVelocity,
            float leftLegKneeVelocity,
            float rightLegHipVelocity,
            float rightLegKneeVelocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_BASTAND_VELOCITY,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeVelocity), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="leftLegHipPosition"></param>
        /// <param name="leftLegKneePosition"></param>
        /// <param name="rightLegHipPosition"></param>
        /// <param name="rightLegKneePosition"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveBAStandPosition(
            float leftLegHipPosition,
            float leftLegKneePosition,
            float rightLegHipPosition,
            float rightLegKneePosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_BASTAND_POSITION,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePosition), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="leftLegHipPositionOffset"></param>
        /// <param name="leftLegKneePositionOffset"></param>
        /// <param name="rightLegHipPositionOffset"></param>
        /// <param name="rightLegKneePositionOffset"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveBAStandPositionOffset(
           float leftLegHipPositionOffset,
           float leftLegKneePositionOffset,
           float rightLegHipPositionOffset,
           float rightLegKneePositionOffset)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_BASTAND_POSITION_OFFSET,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePositionOffset), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="runSpeedTimes"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveBAStandRunSpeedTimes(
           float runSpeedTimes)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_BASTAND_RUN_SPEED_TIMES,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(runSpeedTimes), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Body Ahead Stand) ------------------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Left Leg Stand) --------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leftLegHipAcceleration"></param>
        /// <param name="leftLegKneeAcceleration"></param>
        /// <param name="rightLegHipAcceleration"></param>
        /// <param name="rightLegKneeAcceleration"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveLLSAcceleration(
            float leftLegHipAcceleration,
            float leftLegKneeAcceleration,
            float rightLegHipAcceleration,
            float rightLegKneeAcceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_LLS_ACCELERATION,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeAcceleration), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="leftLegHipVelocity"></param>
        /// <param name="leftLegKneeVelocity"></param>
        /// <param name="rightLegHipVelocity"></param>
        /// <param name="rightLegKneeVelocity"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveLLSVelocity(
            float leftLegHipVelocity,
            float leftLegKneeVelocity,
            float rightLegHipVelocity,
            float rightLegKneeVelocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_LLS_VELOCITY,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeVelocity), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="leftLegHipPosition"></param>
        /// <param name="leftLegKneePosition"></param>
        /// <param name="rightLegHipPosition"></param>
        /// <param name="rightLegKneePosition"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveLLSPosition(
            float leftLegHipPosition,
            float leftLegKneePosition,
            float rightLegHipPosition,
            float rightLegKneePosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_LLS_POSITION,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePosition), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="leftLegHipPositionOffset"></param>
        /// <param name="leftLegKneePositionOffset"></param>
        /// <param name="rightLegHipPositionOffset"></param>
        /// <param name="rightLegKneePositionOffset"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveLLSPositionOffset(
           float leftLegHipPositionOffset,
           float leftLegKneePositionOffset,
           float rightLegHipPositionOffset,
           float rightLegKneePositionOffset)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_LLS_POSITION_OFFSET,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePositionOffset), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="runSpeedTimes"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveLLSRunSpeedTimes(
           float runSpeedTimes)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_LLS_RUN_SPEED_TIMES,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(runSpeedTimes), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Left Leg Stand) --------------------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Right Leg Stand) -------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leftLegHipAcceleration"></param>
        /// <param name="leftLegKneeAcceleration"></param>
        /// <param name="rightLegHipAcceleration"></param>
        /// <param name="rightLegKneeAcceleration"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveRLSAcceleration(
            float leftLegHipAcceleration,
            float leftLegKneeAcceleration,
            float rightLegHipAcceleration,
            float rightLegKneeAcceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_RLS_ACCELERATION,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeAcceleration), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="leftLegHipVelocity"></param>
        /// <param name="leftLegKneeVelocity"></param>
        /// <param name="rightLegHipVelocity"></param>
        /// <param name="rightLegKneeVelocity"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveRLSVelocity(
            float leftLegHipVelocity,
            float leftLegKneeVelocity,
            float rightLegHipVelocity,
            float rightLegKneeVelocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_RLS_VELOCITY,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeVelocity), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="leftLegHipPosition"></param>
        /// <param name="leftLegKneePosition"></param>
        /// <param name="rightLegHipPosition"></param>
        /// <param name="rightLegKneePosition"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveRLSPosition(
            float leftLegHipPosition,
            float leftLegKneePosition,
            float rightLegHipPosition,
            float rightLegKneePosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_RLS_POSITION,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePosition), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="leftLegHipPositionOffset"></param>
        /// <param name="leftLegKneePositionOffset"></param>
        /// <param name="rightLegHipPositionOffset"></param>
        /// <param name="rightLegKneePositionOffset"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveRLSPositionOffset(
           float leftLegHipPositionOffset,
           float leftLegKneePositionOffset,
           float rightLegHipPositionOffset,
           float rightLegKneePositionOffset)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_RLS_POSITION_OFFSET,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePositionOffset), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="runSpeedTimes"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveRLSRunSpeedTimes(
           float runSpeedTimes)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_RLS_RUN_SPEED_TIMES,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(runSpeedTimes), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Right Leg Stand) -------------------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Left Leg Front) --------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leftLegHipAcceleration"></param>
        /// <param name="leftLegKneeAcceleration"></param>
        /// <param name="rightLegHipAcceleration"></param>
        /// <param name="rightLegKneeAcceleration"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveLLFAcceleration(
            float leftLegHipAcceleration,
            float leftLegKneeAcceleration,
            float rightLegHipAcceleration,
            float rightLegKneeAcceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_LLF_ACCELERATION,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeAcceleration), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="leftLegHipVelocity"></param>
        /// <param name="leftLegKneeVelocity"></param>
        /// <param name="rightLegHipVelocity"></param>
        /// <param name="rightLegKneeVelocity"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveLLFVelocity(
            float leftLegHipVelocity,
            float leftLegKneeVelocity,
            float rightLegHipVelocity,
            float rightLegKneeVelocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_LLF_VELOCITY,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeVelocity), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="leftLegHipPosition"></param>
        /// <param name="leftLegKneePosition"></param>
        /// <param name="rightLegHipPosition"></param>
        /// <param name="rightLegKneePosition"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveLLFPosition(
            float leftLegHipPosition,
            float leftLegKneePosition,
            float rightLegHipPosition,
            float rightLegKneePosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_LLF_POSITION,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePosition), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="leftLegHipPositionOffset"></param>
        /// <param name="leftLegKneePositionOffset"></param>
        /// <param name="rightLegHipPositionOffset"></param>
        /// <param name="rightLegKneePositionOffset"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveLLFPositionOffset(
           float leftLegHipPositionOffset,
           float leftLegKneePositionOffset,
           float rightLegHipPositionOffset,
           float rightLegKneePositionOffset)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_LLF_POSITION_OFFSET,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePositionOffset), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="runSpeedTimes"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveLLFRunSpeedTimes(
           float runSpeedTimes)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_LLF_RUN_SPEED_TIMES,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(runSpeedTimes), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Left Leg Front) --------------------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Right Leg Front) -------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leftLegHipAcceleration"></param>
        /// <param name="leftLegKneeAcceleration"></param>
        /// <param name="rightLegHipAcceleration"></param>
        /// <param name="rightLegKneeAcceleration"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveRLFAcceleration(
            float leftLegHipAcceleration,
            float leftLegKneeAcceleration,
            float rightLegHipAcceleration,
            float rightLegKneeAcceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_RLF_ACCELERATION,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeAcceleration), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="leftLegHipVelocity"></param>
        /// <param name="leftLegKneeVelocity"></param>
        /// <param name="rightLegHipVelocity"></param>
        /// <param name="rightLegKneeVelocity"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveRLFVelocity(
            float leftLegHipVelocity,
            float leftLegKneeVelocity,
            float rightLegHipVelocity,
            float rightLegKneeVelocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_RLF_VELOCITY,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeVelocity), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="leftLegHipPosition"></param>
        /// <param name="leftLegKneePosition"></param>
        /// <param name="rightLegHipPosition"></param>
        /// <param name="rightLegKneePosition"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveRLFPosition(
            float leftLegHipPosition,
            float leftLegKneePosition,
            float rightLegHipPosition,
            float rightLegKneePosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_RLF_POSITION,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePosition), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="leftLegHipPositionOffset"></param>
        /// <param name="leftLegKneePositionOffset"></param>
        /// <param name="rightLegHipPositionOffset"></param>
        /// <param name="rightLegKneePositionOffset"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveRLFPositionOffset(
           float leftLegHipPositionOffset,
           float leftLegKneePositionOffset,
           float rightLegHipPositionOffset,
           float rightLegKneePositionOffset)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_RLF_POSITION_OFFSET,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePositionOffset), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="runSpeedTimes"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveRLFRunSpeedTimes(
           float runSpeedTimes)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_RLF_RUN_SPEED_TIMES,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(runSpeedTimes), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Right Leg Front) -------------------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Right Leg Front To Stand) ----------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leftLegHipAcceleration"></param>
        /// <param name="leftLegKneeAcceleration"></param>
        /// <param name="rightLegHipAcceleration"></param>
        /// <param name="rightLegKneeAcceleration"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveRLSToStandAcceleration(
            float leftLegHipAcceleration,
            float leftLegKneeAcceleration,
            float rightLegHipAcceleration,
            float rightLegKneeAcceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_RLSTOSTAND_ACCELERATION,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeAcceleration), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="leftLegHipVelocity"></param>
        /// <param name="leftLegKneeVelocity"></param>
        /// <param name="rightLegHipVelocity"></param>
        /// <param name="rightLegKneeVelocity"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveRLSToStandVelocity(
            float leftLegHipVelocity,
            float leftLegKneeVelocity,
            float rightLegHipVelocity,
            float rightLegKneeVelocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_RLSTOSTAND_VELOCITY,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeVelocity), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="leftLegHipPosition"></param>
        /// <param name="leftLegKneePosition"></param>
        /// <param name="rightLegHipPosition"></param>
        /// <param name="rightLegKneePosition"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveRLSToStandPosition(
            float leftLegHipPosition,
            float leftLegKneePosition,
            float rightLegHipPosition,
            float rightLegKneePosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_RLSTOSTAND_POSITION,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePosition), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="leftLegHipPositionOffset"></param>
        /// <param name="leftLegKneePositionOffset"></param>
        /// <param name="rightLegHipPositionOffset"></param>
        /// <param name="rightLegKneePositionOffset"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveRLSToStandPositionOffset(
           float leftLegHipPositionOffset,
           float leftLegKneePositionOffset,
           float rightLegHipPositionOffset,
           float rightLegKneePositionOffset)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_RLSTOSTAND_POSITION_OFFSET,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePositionOffset), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="runSpeedTimes"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveRLSToStandRunSpeedTimes(
           float runSpeedTimes)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_RLSTOSTAND_RUN_SPEED_TIMES,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(runSpeedTimes), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Right Leg Front To Stand) ----------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Left Leg Stand To Stand) -----------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leftLegHipAcceleration"></param>
        /// <param name="leftLegKneeAcceleration"></param>
        /// <param name="rightLegHipAcceleration"></param>
        /// <param name="rightLegKneeAcceleration"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveLLSToStandAcceleration(
            float leftLegHipAcceleration,
            float leftLegKneeAcceleration,
            float rightLegHipAcceleration,
            float rightLegKneeAcceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_LLSTOSTAND_ACCELERATION,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeAcceleration), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="leftLegHipVelocity"></param>
        /// <param name="leftLegKneeVelocity"></param>
        /// <param name="rightLegHipVelocity"></param>
        /// <param name="rightLegKneeVelocity"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveLLSToStandVelocity(
            float leftLegHipVelocity,
            float leftLegKneeVelocity,
            float rightLegHipVelocity,
            float rightLegKneeVelocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_LLSTOSTAND_VELOCITY,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeVelocity), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="leftLegHipPosition"></param>
        /// <param name="leftLegKneePosition"></param>
        /// <param name="rightLegHipPosition"></param>
        /// <param name="rightLegKneePosition"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveLLSToStandPosition(
            float leftLegHipPosition,
            float leftLegKneePosition,
            float rightLegHipPosition,
            float rightLegKneePosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_LLSTOSTAND_POSITION,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePosition), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="leftLegHipPositionOffset"></param>
        /// <param name="leftLegKneePositionOffset"></param>
        /// <param name="rightLegHipPositionOffset"></param>
        /// <param name="rightLegKneePositionOffset"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveLLSToStandPositionOffset(
           float leftLegHipPositionOffset,
           float leftLegKneePositionOffset,
           float rightLegHipPositionOffset,
           float rightLegKneePositionOffset)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_LLSTOSTAND_POSITION_OFFSET,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePositionOffset), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="runSpeedTimes"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveLLSToStandRunSpeedTimes(
           float runSpeedTimes)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_LLSTOSTAND_RUN_SPEED_TIMES,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(runSpeedTimes), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Left Leg Stand To Stand) -----------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Left Leg Stand To Right Leg Front) -------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="runSpeedTimes"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveLLSToRLFRunSpeedTimes(
           float runSpeedTimes)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_LLSTORLF_RUN_SPEED_TIMES,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(runSpeedTimes), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Left Leg Stand To Right Leg Front) -------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Right Leg Stand To Left Leg Front) -------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="runSpeedTimes"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveRLSToLLFRunSpeedTimes(
           float runSpeedTimes)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_RLSTOLLF_RUN_SPEED_TIMES,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(runSpeedTimes), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Right Leg Stand To Left Leg Front) -------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Left Leg Front To Right Leg Front) -------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="runSpeedTimes"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveLLFToRLFRunSpeedTimes(
           float runSpeedTimes)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_LLFTORLF_RUN_SPEED_TIMES,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(runSpeedTimes), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Left Leg Front To Right Leg Front) -------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Right Leg Front To Left Leg Front) -------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="runSpeedTimes"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveRLFToLLFRunSpeedTimes(
           float runSpeedTimes)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_RLFTOLLF_RUN_SPEED_TIMES,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(runSpeedTimes), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Right Leg Front To Left Leg Front) -------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Walk With Left Leg Front) ----------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="runSpeedTimes"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveWalkWithLLFRunSpeedTimes(
           float runSpeedTimes)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_WALKWITHLLF_RUN_SPEED_TIMES,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(runSpeedTimes), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Walk With Left Leg Front) ----------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Walk With Right Leg Front) ---------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="runSpeedTimes"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicPassiveWalkWithRLFRunSpeedTimes(
           float runSpeedTimes)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_WALKWITHRLF_RUN_SPEED_TIMES,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(runSpeedTimes), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Basic - Passive Walk With Left Leg Front) ----------------------

        //-------------------------------------------- Function Definition (Request - Subtask - Passive Walk) --------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int RequestGetSubtaskWalkPassiveProcess()
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_WALK_PASSIVE_1_PROCESS,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.GET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] { });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="process"></param>
        /// <returns></returns>
        public int RequestSetSubtaskWalkPassiveProcess(
            float process)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_WALK_PASSIVE_1_PROCESS,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(process), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <returns></returns>
        public int RequestGetSubtaskWalkPassiveCommand()
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_WALK_PASSIVE_1_COMMAND,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.GET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] { });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        public int RequestSetSubtaskWalkPassiveCommand(
            int command)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_WALK_PASSIVE_1_COMMAND,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(command), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <returns></returns>
        public int RequestGetSubtaskWalkPassiveState()
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_WALK_PASSIVE_1_STATE,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.GET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] { });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="state"></param>
        /// <returns></returns>
        public int RequestSetSubtaskWalkPassiveState(
            float state)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_WALK_PASSIVE_1_STATE,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(state), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="length"></param>
        /// <returns></returns>
        public int RequestSetSubtaskWalkPassiveParameterThighLength(
            float length)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_WALK_PASSIVE_COMMAND_PARAMETER_THIGH_LENGTH,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(length), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="length"></param>
        /// <returns></returns>
        public int RequestSetSubtaskWalkPassiveParameterShankLength(
           float length)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_WALK_PASSIVE_COMMAND_PARAMETER_SHANK_LENGTH,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(length), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="length"></param>
        /// <returns></returns>
        public int RequestSetSubtaskWalkPassiveParameterStepLength(
            float length)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_WALK_PASSIVE_COMMAND_PARAMETER_STEP_LENGTH,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(length), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="length"></param>
        /// <returns></returns>
        public int RequestSetSubtaskWalkPassiveParameterStepHeight(
            float length)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_WALK_PASSIVE_COMMAND_PARAMETER_STEP_HEIGHT,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(length), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="times"></param>
        /// <returns></returns>
        public int RequestSetSubtaskWalkPassiveParameterStepTime(
            float times)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_WALK_PASSIVE_COMMAND_PARAMETER_STEP_TIME,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(times), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="times"></param>
        /// <returns></returns>
        public int RequestSetSubtaskWalkPassiveParameterSitTime(
            float times)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_WALK_PASSIVE_COMMAND_PARAMETER_SIT_TIME,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(times), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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
        /// <param name="times"></param>
        /// <returns></returns>
        public int RequestSetSubtaskWalkPassiveParameterStandTime(
            float times)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_WALK_PASSIVE_COMMAND_PARAMETER_STAND_TIME,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(times), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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

        public int RequestSetSubtaskWalkPassiveParameterTimeProportion(
            float times)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_WALK_PASSIVE_COMMAND_PARAMETER_TIME_PROPORTION,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint[] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(times), 0) });

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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Subtask - Passive Walk) --------------------------------------------------

        public int ModelUpdateHandle(FFTAICommunicationInterfaceModelBasic model)
        {
            int operationMode = (int)model.DataSectionModel.ResponseModel.OperationMode;
            int readWriteOperation = (int)model.DataSectionModel.ResponseModel.ReadWriteOperation;
            int operationResult = (int)model.DataSectionModel.ResponseModel.OperationResult;

            switch (operationMode)
            {
                case FFTAICommunicationH4TaskInterfaceOperationMode.BASIC_FLAG_TASK_IN_PROCESS:
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
                case FFTAICommunicationH4TaskInterfaceOperationMode.SUBTASK_WALK_PASSIVE_1_STATE:
                    {
                        uint state = BitConverter.ToUInt32(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[0]), 0);
                        switch (state)
                        {
                            case FFTAICommunicationH4TaskInterfaceMasterControlWalkPassive1State.NONE:
                                StatusState.exoMotusState =ExoMotusState.NONE ;
                                break;
                            case FFTAICommunicationH4TaskInterfaceMasterControlWalkPassive1State.STOP:
                                StatusState.exoMotusState = ExoMotusState.STOP;
                                break;

                            case FFTAICommunicationH4TaskInterfaceMasterControlWalkPassive1State.PAUSE:
                                StatusState.exoMotusState = ExoMotusState.PAUSE;
                                break;
                            case FFTAICommunicationH4TaskInterfaceMasterControlWalkPassive1State.JOG:
                                StatusState.exoMotusState = ExoMotusState.JOG;
                                break;
                            case FFTAICommunicationH4TaskInterfaceMasterControlWalkPassive1State.TO_SIT:
                                StatusState.exoMotusState = ExoMotusState.SIT;
                                break;
                            case FFTAICommunicationH4TaskInterfaceMasterControlWalkPassive1State.TO_STAND:
                                StatusState.exoMotusState = ExoMotusState.STAND;
                                break;
                            case FFTAICommunicationH4TaskInterfaceMasterControlWalkPassive1State.CALIBRATESIT:
                                StatusState.exoMotusState = ExoMotusState.CALIBRATESIT;
                                break;
                            case FFTAICommunicationH4TaskInterfaceMasterControlWalkPassive1State.CALIBRATESIT_TO_CALIBRATESTAND:
                                StatusState.exoMotusState = ExoMotusState.CALIBRATESIT;
                                break;
                            case FFTAICommunicationH4TaskInterfaceMasterControlWalkPassive1State.CALIBRATESTAND:
                                StatusState.exoMotusState = ExoMotusState.CALIBRATESIT;
                                break;
                            case FFTAICommunicationH4TaskInterfaceMasterControlWalkPassive1State.SIT:
                                StatusState.exoMotusState = ExoMotusState.SIT;
                                break;
                            case FFTAICommunicationH4TaskInterfaceMasterControlWalkPassive1State.SIT_TO_STAND:
                                StatusState.exoMotusState = ExoMotusState.STAND;
                                break;
                            case FFTAICommunicationH4TaskInterfaceMasterControlWalkPassive1State.STAND:
                                StatusState.exoMotusState = ExoMotusState.STAND;
                                break;
                            case FFTAICommunicationH4TaskInterfaceMasterControlWalkPassive1State.STAND_TO_SIT:
                                StatusState.exoMotusState = ExoMotusState.SIT;
                                break;
                            case FFTAICommunicationH4TaskInterfaceMasterControlWalkPassive1State.STAND_TO_WALK:
                                StatusState.exoMotusState = ExoMotusState.WALK;
                                break;
                            case FFTAICommunicationH4TaskInterfaceMasterControlWalkPassive1State.WALK:
                                StatusState.exoMotusState = ExoMotusState.WALK;
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
            return FFTAICommunicationFunctionType.H4_TASK_INTERFACE;
        }
    }
}

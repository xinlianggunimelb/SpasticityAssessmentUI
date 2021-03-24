using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static FFTAICommunicationLib.DynaLinkHS;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationM6TaskInterface : FFTAICommunicationInterfaceBasic, IFFTAICommunicationInterfaceObserver
    {

        public int RequestSetWorkMode(int workMode)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.BASIC_WORK_MODE,
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
                                (uint)FFTAICommunicationRobotType.M6,
                                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.BASIC_FLAG_TASK_IN_PROCESS,
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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.BASIC_FLAG_INFORMATION,
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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
                                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.DEBUG_WORK_MODE,
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
                                (uint)FFTAICommunicationRobotType.M6,
                                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
        /// Requests the set relay work mode.
        /// </summary>
        /// <returns>The set relay work mode.</returns>
        /// <param name="workMode">Work mode.</param>
        public int RequestSetRelayWorkMode(int workMode)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.RELAY_WORK_MODE,
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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Relay) -------------------------------------------------------------------

        //-------------------------------------------- Function Definition (Request - Master Control) ----------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workMode"></param>
        /// <returns></returns>
        public int RequestSetMasterControlWorkMode(int workMode)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.MASTER_CONTROL_WORK_MODE,
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
                                (uint)FFTAICommunicationRobotType.M6,
                                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Master Control) ----------------------------------------------------------

        //-------------------------------------------- Function Definition (Request - Master Control - Basic) --------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public int RequestSetMasterControlWalkPassive1Command(uint  command)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.MASTER_CONTROL_WALK_PASSIVE_1_COMMAND,
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
                                (uint)FFTAICommunicationRobotType.M6,
                                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
        public int RequestSetMasterControlWalkPassive2Command(uint  command)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.MASTER_CONTROL_WALK_PASSIVE_2_COMMAND,
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
                                (uint)FFTAICommunicationRobotType.M6,
                                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
        public int RequestSetMasterControlWalkAssist1Command(uint  command)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.MASTER_CONTROL_WALK_ASSIST_1_COMMAND,
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
                                (uint)FFTAICommunicationRobotType.M6,
                                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
        public int RequestSetMasterControlWalkAssist2Command(uint  command)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.MASTER_CONTROL_WALK_ASSIST_2_COMMAND,
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
                                (uint)FFTAICommunicationRobotType.M6,
                                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
        public int RequestSetMasterControlWalkActive1Command(uint  command)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.MASTER_CONTROL_WALK_ACTIVE_1_COMMAND,
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
                                (uint)FFTAICommunicationRobotType.M6,
                                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
        public int RequestSetMasterControlWalkActive2Command(uint  command)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.MASTER_CONTROL_WALK_ACTIVE_2_COMMAND,
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
                                (uint)FFTAICommunicationRobotType.M6,
                                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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

        //-------------------------------------------- Function Definition (Request - Master Control - Basic) --------------------------------------------------

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
            float leftLegAnkleJointKinetic,
            float rightLegHipJointKinetic, 
            float rightLegKneeJointKinetic,
            float rightLegAnkleJointKinetic)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_JOINT_KINETIC_CONTROL_KINETIC,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipJointKinetic), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeJointKinetic), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnkleJointKinetic), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipJointKinetic), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeJointKinetic), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnkleJointKinetic), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnkleJointAcceleration,
            float rightLegHipJointAcceleration, 
            float rightLegKneeJointAcceleration,
            float rightLegAnkleJointAcceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_JOINT_VELOCITY_CONTROL_ACCELERATION,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipJointAcceleration), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeJointAcceleration), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnkleJointAcceleration), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipJointAcceleration), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeJointAcceleration), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnkleJointAcceleration), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnkleJointVelocity,
            float rightLegHipJointVelocity, 
            float rightLegKneeJointVelocity,
            float rightLegAnkleJointVelocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_JOINT_VELOCITY_CONTROL_VELOCITY,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipJointVelocity), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeJointVelocity), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnkleJointVelocity), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipJointVelocity), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeJointVelocity), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnkleJointVelocity), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnkleJointAcceleration,
            float rightLegHipJointAcceleration, 
            float rightLegKneeJointAcceleration,
            float rightLegAnkleJointAcceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_JOINT_POSITION_CONTROL_ACCELERATION,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipJointAcceleration), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeJointAcceleration), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnkleJointAcceleration), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipJointAcceleration), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeJointAcceleration), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnkleJointAcceleration), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnkleJointVelocity,
            float rightLegHipJointVelocity, 
            float rightLegKneeJointVelocity,
            float rightLegAnkleJointVelocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_JOINT_POSITION_CONTROL_VELOCITY,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipJointVelocity), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeJointVelocity), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnkleJointVelocity), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipJointVelocity), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeJointVelocity), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnkleJointVelocity), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnkleJointPosition,
            float rightLegHipJointPosition, 
            float rightLegKneeJointPosition,
            float rightLegAnkleJointPosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_JOINT_POSITION_CONTROL_POSITION,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipJointPosition), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeJointPosition), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnkleJointPosition), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipJointPosition), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeJointPosition), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnkleJointPosition), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
        /// <param name="endEffectorM6Kinetic"></param>
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
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_END_EFFECTOR_KINETIC_CONTROL_KINETIC,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
        /// <param name="endEffectorM6Acceleration"></param>
        /// <param name="endEffectorY2Acceleration"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicEndEffectorVelocityControlAcceleration(
            float endEffectorX1Acceleration, 
            float endEffectorY1Acceleration,
            float endEffectorX2Acceleration, 
            float endEffectorY2Acceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_END_EFFECTOR_VELOCITY_CONTROL_ACCELERATION,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorX1Acceleration), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorY1Acceleration), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorX2Acceleration), 0),
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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
        /// <param name="endEffectorM6Velocity"></param>
        /// <param name="endEffectorY2Velocity"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicEndEffectorVelocityControlVelocity(
            float endEffectorX1Velocity, 
            float endEffectorY1Velocity,
            float endEffectorX2Velocity, 
            float endEffectorY2Velocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_END_EFFECTOR_VELOCITY_CONTROL_VELOCITY,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorX1Velocity), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorY1Velocity), 0), 
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorX2Velocity), 0),
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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
        /// <param name="endEffectorM6Acceleration"></param>
        /// <param name="endEffectorY2Acceleration"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicEndEffectorPositionControlAcceleration(
            float endEffectorX1Acceleration, 
            float endEffectorY1Acceleration,
            float endEffectorX2Acceleration, 
            float endEffectorY2Acceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_END_EFFECTOR_POSITION_CONTROL_ACCELERATION,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorX1Acceleration), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorY1Acceleration), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorX2Acceleration), 0),
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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
        /// <param name="endEffectorM6Velocity"></param>
        /// <param name="endEffectorY2Velocity"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicEndEffectorPositionControlVelocity(
            float endEffectorX1Velocity, 
            float endEffectorY1Velocity,
            float endEffectorX2Velocity, 
            float endEffectorY2Velocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_END_EFFECTOR_POSITION_CONTROL_VELOCITY,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorX1Velocity), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorY1Velocity), 0), 
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorX2Velocity), 0),
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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
        /// <param name="endEffectorM6Position"></param>
        /// <param name="endEffectorY2Position"></param>
        /// <returns></returns>
        public int RequestSetSubtaskBasicEndEffectorPositionControlPosition(
            float endEffectorX1Position, 
            float endEffectorY1Position,
            float endEffectorX2Position, 
            float endEffectorY2Position)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_END_EFFECTOR_POSITION_CONTROL_POSITION,
                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorX1Position), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorY1Position), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(endEffectorX2Position), 0),
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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnkleAcceleration,
            float rightLegHipAcceleration, 
            float rightLegKneeAcceleration,
            float rightLegAnkleAcceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_MOVE_ACCELERATION,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] { 
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnkleAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnkleAcceleration), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnkleVelocity,
            float rightLegHipVelocity,
            float rightLegKneeVelocity,
            float rightLegAnkleVelocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_MOVE_VELOCITY,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] { 
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnkleVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnkleVelocity), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnklePosition,
            float rightLegHipPosition, 
            float rightLegKneePosition,
            float rightLegAnklePosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_MOVE_POSITION,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] { 
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnklePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnklePosition), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnkleKinetic,
            float rightLegHipKinetic, 
            float rightLegKneeKinetic,
            float rightLegAnkleKinetic)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_ASSIST_MOVE_KINETIC,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] { 
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipKinetic), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeKinetic), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnkleKinetic), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipKinetic), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeKinetic), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnkleKinetic), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnklePosition,
            float rightLegHipPosition,
            float rightLegKneePosition,
            float rightLegAnklePosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_ASSIST_MOVE_POSITION,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] { 
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnklePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnklePosition), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnkleKinetic,
            float rightLegHipKinetic, 
            float rightLegKneeKinetic,
            float rightLegAnkleKinetic)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_ACTIVE_MOVE_KINETIC,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] { 
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipKinetic), 0), 
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeKinetic), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnkleKinetic), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipKinetic), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeKinetic), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnkleKinetic), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnkleOriginPosition,
            float rightLegHipOriginPosition, 
            float rightLegKneeOriginPosition,
            float rightLegAnkleOriginPosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_TRANSPARENT_CONTROL_MOVE_ORIGIN_POINT,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] { 
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipOriginPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeOriginPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnkleOriginPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipOriginPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeOriginPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnkleOriginPosition), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnkleM,
            float rightLegHipM, 
            float rightLegKneeM,
            float rightLegAnkleM)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_TRANSPARENT_CONTROL_MOVE_M,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] { 
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipM), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeM), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnkleM), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipM), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeM), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnkleM), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnkleB,
            float rightLegHipB, 
            float rightLegKneeB,
            float rightLegAnkleB)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_TRANSPARENT_CONTROL_MOVE_B,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] { 
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipB), 0), 
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeB), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnkleB), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipB), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeB), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnkleB), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnkleK,
            float rightLegHipK,
            float rightLegKneeK,
            float rightLegAnkleK)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_TRANSPARENT_CONTROL_MOVE_K,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] { 
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipK), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeK), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnkleK), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipK), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeK), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnkleK), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnkleAcceleration,
            float rightLegHipAcceleration,
            float rightLegKneeAcceleration,
            float rightLegAnkleAcceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_SIT_ACCELERATION,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnkleAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnkleAcceleration), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnkleVelocity,
            float rightLegHipVelocity,
            float rightLegKneeVelocity,
            float rightLegAnkleVelocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_SIT_VELOCITY,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnkleVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnkleVelocity), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnklePosition,
            float rightLegHipPosition,
            float rightLegKneePosition,
            float rightLegAnklePosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_SIT_POSITION,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnklePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnklePosition), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
           float leftLegAnklePositionOffset,
           float rightLegHipPositionOffset,
           float rightLegKneePositionOffset,
           float rightLegAnklePositionOffset)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_SIT_POSITION_OFFSET,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnklePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnklePositionOffset), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_SIT_RUN_SPEED_TIMES,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnkleAcceleration,
            float rightLegHipAcceleration,
            float rightLegKneeAcceleration,
            float rightLegAnkleAcceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_STAND_ACCELERATION,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnkleAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnkleAcceleration), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnkleVelocity,
            float rightLegHipVelocity,
            float rightLegKneeVelocity,
            float rightLegAnkleVelocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_STAND_VELOCITY,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnkleVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnkleVelocity), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnklePosition,
            float rightLegHipPosition,
            float rightLegKneePosition,
            float rightLegAnklePosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_STAND_POSITION,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnklePosition), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
           float leftLegAnklePositionOffset,
           float rightLegHipPositionOffset,
           float rightLegKneePositionOffset,
           float rightLegAnklePositionOffset)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_STAND_POSITION_OFFSET,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnklePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnklePositionOffset), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_STAND_RUN_SPEED_TIMES,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnkleAcceleration,
            float rightLegHipAcceleration,
            float rightLegKneeAcceleration,
            float rightLegAnkleAcceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_BASIT_ACCELERATION,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnkleAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnkleAcceleration), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnkleVelocity,
            float rightLegHipVelocity,
            float rightLegKneeVelocity,
            float rightLegAnkleVelocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_BASIT_VELOCITY,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnkleVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnkleVelocity), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnklePosition,
            float rightLegHipPosition,
            float rightLegKneePosition,
            float rightLegAnklePosition
            )
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_BASIT_POSITION,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnklePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnklePosition), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
           float leftLegAnklePositionOffset,
           float rightLegHipPositionOffset,
           float rightLegKneePositionOffset,
           float rightLegAnklePositionOffset)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_BASIT_POSITION_OFFSET,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnklePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnklePositionOffset), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_BASIT_RUN_SPEED_TIMES,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnkleAcceleration,
            float rightLegHipAcceleration,
            float rightLegKneeAcceleration,
            float rightLegAnkleAcceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_BASTAND_ACCELERATION,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnkleAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnkleAcceleration), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnkleVelocity,
            float rightLegHipVelocity,
            float rightLegKneeVelocity,
            float rightLegAnkleVelocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_BASTAND_VELOCITY,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnkleVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnkleVelocity), 0)
                });

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnklePosition,
            float rightLegHipPosition,
            float rightLegKneePosition,
            float rightLegAnklePosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_BASTAND_POSITION,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnklePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnklePosition), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
           float leftLegAnklePositionOffset,
           float rightLegHipPositionOffset,
           float rightLegKneePositionOffset,
           float rightLegAnklePositionOffset)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_BASTAND_POSITION_OFFSET,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnklePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnklePositionOffset), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_BASTAND_RUN_SPEED_TIMES,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnkleAcceleration,
            float rightLegHipAcceleration,
            float rightLegKneeAcceleration,
            float rightLegAnkleAcceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_LLS_ACCELERATION,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnkleAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnkleAcceleration), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnkleVelocity,
            float rightLegHipVelocity,
            float rightLegKneeVelocity,
            float rightLegAnkleVelocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_LLS_VELOCITY,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnkleVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnkleVelocity), 0),});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnklePosition,
            float rightLegHipPosition,
            float rightLegKneePosition,
            float rightLegAnklePosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_LLS_POSITION,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnklePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnklePosition), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
           float leftLegAnklePositionOffset,
           float rightLegHipPositionOffset,
           float rightLegKneePositionOffset,
           float rightLegAnklePositionOffset)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_LLS_POSITION_OFFSET,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnklePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePositionOffset), 0),
                BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnklePositionOffset), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_LLS_RUN_SPEED_TIMES,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnkleAcceleration,
            float rightLegHipAcceleration,
            float rightLegKneeAcceleration,
            float rightLegAnkleAcceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_RLS_ACCELERATION,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnkleAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnkleAcceleration), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnkleVelocity,
            float rightLegHipVelocity,
            float rightLegKneeVelocity,
            float rightLegAnkleVelocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_RLS_VELOCITY,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnkleVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnkleVelocity), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnklePosition,
            float rightLegHipPosition,
            float rightLegKneePosition,
            float rightLegAnklePosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_RLS_POSITION,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnklePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnklePosition), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
           float leftLegAnklePositionOffset,
           float rightLegHipPositionOffset,
           float rightLegKneePositionOffset,
           float rightLegAnklePositionOffset)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_RLS_POSITION_OFFSET,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnklePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnklePositionOffset), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_RLS_RUN_SPEED_TIMES,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnkleAcceleration,
            float rightLegHipAcceleration,
            float rightLegKneeAcceleration,
            float rightLegAnkleAcceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_LLF_ACCELERATION,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnkleAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnkleAcceleration), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnkleVelocity,
            float rightLegHipVelocity,
            float rightLegKneeVelocity,
            float rightLegAnkleVelocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_LLF_VELOCITY,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnkleVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnkleVelocity), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnklePosition,
            float rightLegHipPosition,
            float rightLegKneePosition,
            float rightLegAnklePosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_LLF_POSITION,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnklePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnklePosition), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
           float leftLegAnklePositionOffset,
           float rightLegHipPositionOffset,
           float rightLegKneePositionOffset,
           float rightLegAnklePositionOffset)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_LLF_POSITION_OFFSET,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnklePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnklePositionOffset), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_LLF_RUN_SPEED_TIMES,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnkleAcceleration,
            float rightLegHipAcceleration,
            float rightLegKneeAcceleration,
            float rightLegAnkleAcceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_RLF_ACCELERATION,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnkleAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnkleAcceleration), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnkleVelocity,
            float rightLegHipVelocity,
            float rightLegKneeVelocity,
            float rightLegAnkleVelocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_RLF_VELOCITY,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnkleVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnkleVelocity), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnklePosition,
            float rightLegHipPosition,
            float rightLegKneePosition,
            float rightLegAnklePosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_RLF_POSITION,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnklePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnklePosition), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
           float leftLegAnklePositionOffset,
           float rightLegHipPositionOffset,
           float rightLegKneePositionOffset,
           float rightLegAnklePositionOffset)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_RLF_POSITION_OFFSET,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnklePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnklePositionOffset), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_RLF_RUN_SPEED_TIMES,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnkleAcceleration,
            float rightLegHipAcceleration,
            float rightLegKneeAcceleration,
            float rightLegAnkleAcceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_RLSTOSTAND_ACCELERATION,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnkleAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnkleAcceleration), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnkleVelocity,
            float rightLegHipVelocity,
            float rightLegKneeVelocity,
            float rightLegAnkleVelocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_RLSTOSTAND_VELOCITY,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnkleVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnkleVelocity), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnklePosition,
            float rightLegHipPosition,
            float rightLegKneePosition,
            float rightLegAnklePosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_RLSTOSTAND_POSITION,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnklePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnklePosition), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
           float leftLegAnklePositionOffset,
           float rightLegHipPositionOffset,
           float rightLegKneePositionOffset,
           float rightLegAnklePositionOffset)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_RLSTOSTAND_POSITION_OFFSET,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnklePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnklePositionOffset), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_RLSTOSTAND_RUN_SPEED_TIMES,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnkleAcceleration,
            float rightLegHipAcceleration,
            float rightLegKneeAcceleration,
            float rightLegAnkleAcceleration)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_LLSTOSTAND_ACCELERATION,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnkleAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeAcceleration), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnkleAcceleration), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnkleVelocity,
            float rightLegHipVelocity,
            float rightLegKneeVelocity,
            float rightLegAnkleVelocity)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_LLSTOSTAND_VELOCITY,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneeVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnkleVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneeVelocity), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnkleVelocity), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
            float leftLegAnklePosition,
            float rightLegHipPosition,
            float rightLegKneePosition,
            float rightLegAnklePosition)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_LLSTOSTAND_POSITION,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnklePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePosition), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnklePosition), 0)});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
           float leftLegAnklePositionOffset,
           float rightLegHipPositionOffset,
           float rightLegKneePositionOffset,
           float rightLegAnklePositionOffset)
        {
            int functionResult;

            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_LLSTOSTAND_POSITION_OFFSET,
                (uint)FFTAICommunicationNumberOfParameter.SIX,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegKneePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(leftLegAnklePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegHipPositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegKneePositionOffset), 0),
                    BitConverter.ToUInt32(BitConverter.GetBytes(rightLegAnklePositionOffset), 0),});

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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_LLSTOSTAND_RUN_SPEED_TIMES,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_LLSTORLF_RUN_SPEED_TIMES,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_RLSTOLLF_RUN_SPEED_TIMES,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_LLFTORLF_RUN_SPEED_TIMES,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_RLFTOLLF_RUN_SPEED_TIMES,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_WALKWITHLLF_RUN_SPEED_TIMES,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
                (uint)FFTAICommunicationM6TaskInterfaceOperationMode.SUBTASK_BASIC_PASSIVE_WALKWITHRLF_RUN_SPEED_TIMES,
                (uint)FFTAICommunicationNumberOfParameter.ONE,
                (uint)FFTAICommunicationReadWriteOperation.SET,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                new uint [] {
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
                (uint)FFTAICommunicationRobotType.M6,
                (uint)FFTAICommunicationFunctionType.M6_TASK_INTERFACE,
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
                case FFTAICommunicationM6TaskInterfaceOperationMode.BASIC_FLAG_TASK_IN_PROCESS:
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
            return FFTAICommunicationFunctionType.M6_TASK_INTERFACE;
        }
    }
}

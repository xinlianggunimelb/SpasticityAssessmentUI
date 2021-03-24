using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static FFTAICommunicationLib.DynaLinkHS;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationH4RobotInterface:FFTAICommunicationInterfaceBasic, IFFTAICommunicationInterfaceObserver
    {
        public int RequestReadFlagCalibration()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.FLAG_CALIBRATION,
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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                Model.DataSectionModel.RequestModel.MessageBufLength,
                Model.DataSectionModel.RequestModel.MessageBuf,
                Model.DataSectionModel.RequestModel.MessageBufParity,
                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestReadFlagServoOn()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.FLAG_SERVO_ON,
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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                Model.DataSectionModel.RequestModel.MessageBufLength,
                Model.DataSectionModel.RequestModel.MessageBuf,
                Model.DataSectionModel.RequestModel.MessageBufParity,
                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestReadFlagEmergentStop()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.FLAG_EMERGENT_STOP,
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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                Model.DataSectionModel.RequestModel.MessageBufLength,
                Model.DataSectionModel.RequestModel.MessageBuf,
                Model.DataSectionModel.RequestModel.MessageBufParity,
                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestReadFlagFault()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.FLAG_FAULT,
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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                Model.DataSectionModel.RequestModel.MessageBufLength,
                Model.DataSectionModel.RequestModel.MessageBuf,
                Model.DataSectionModel.RequestModel.MessageBufParity,
                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

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
                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.FLAG_INFORMATION,
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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                Model.DataSectionModel.RequestModel.MessageBufLength,
                Model.DataSectionModel.RequestModel.MessageBuf,
                Model.DataSectionModel.RequestModel.MessageBufParity,
                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestReadFlagOutOfJointLimitInformation()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.FLAG_OUT_OF_JOINT_LIMIT_INFORMATION,
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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                Model.DataSectionModel.RequestModel.MessageBufLength,
                Model.DataSectionModel.RequestModel.MessageBuf,
                Model.DataSectionModel.RequestModel.MessageBufParity,
                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestReadFlagOutOfEndEffectorLimitInformation()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.FLAG_OUT_OF_END_EFFECTOR_LIMIT_INFORMATION,
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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                Model.DataSectionModel.RequestModel.MessageBufLength,
                Model.DataSectionModel.RequestModel.MessageBuf,
                Model.DataSectionModel.RequestModel.MessageBufParity,
                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        //-------------------------------------------- Function Definition (Request - Flag) ---------------------------------------------------------

        //-------------------------------------------- Function Definition (Request - Sensor) -------------------------------------------------------

        //--------------------------------------------- Function Definition (Request - Sensor - Button) ---------------------------------------------
        
        public int RequestReadRedButtonValue()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.RED_BUTTON_VALUE,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestReadYellowButtonValue()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.YELLOW_BUTTON_VALUE,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestReadGreenButtonValue()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.GREEN_BUTTON_VALUE,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestReadBlueButtonValue()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.BLUE_BUTTON_VALUE,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestReadButtonSensorInformation()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.BUTTON_SENSOR_INFORMATION,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestReadButtonSensorInstalled()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.BUTTON_SENSOR_INSTALLED,
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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                Model.DataSectionModel.RequestModel.MessageBufLength,
                Model.DataSectionModel.RequestModel.MessageBuf,
                Model.DataSectionModel.RequestModel.MessageBufParity,
                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestReadButtonSensorAccessible()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.BUTTON_SENSOR_ACCESSIBLE,
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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                Model.DataSectionModel.RequestModel.MessageBufLength,
                Model.DataSectionModel.RequestModel.MessageBuf,
                Model.DataSectionModel.RequestModel.MessageBufParity,
                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestSetButtonSensorCalibrate()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.BUTTON_SENSOR_CALIBRATE,
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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                Model.DataSectionModel.RequestModel.MessageBufLength,
                Model.DataSectionModel.RequestModel.MessageBuf,
                Model.DataSectionModel.RequestModel.MessageBufParity,
                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        //--------------------------------------------- Function Definition (Request - Sensor - Button) ---------------------------------------------
        
        //-------------------------------------------- Function Definition (Request - Sensor - IMU Sensor) ------------------------------------------
        
        public int RequestReadBodyIMUSensorValue()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.BODY_IMU_SENSOR_VALUE,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestReadIMUSensorInformation()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.IMU_SENSOR_INFORMATION,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestReadIMUSensorInstalled()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.IMU_SENSOR_INSTALLED,
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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                Model.DataSectionModel.RequestModel.MessageBufLength,
                Model.DataSectionModel.RequestModel.MessageBuf,
                Model.DataSectionModel.RequestModel.MessageBufParity,
                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestReadIMUSensorAccessible()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.IMU_SENSOR_ACCESSIBLE,
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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                Model.DataSectionModel.RequestModel.MessageBufLength,
                Model.DataSectionModel.RequestModel.MessageBuf,
                Model.DataSectionModel.RequestModel.MessageBufParity,
                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestSetIMUSensorCalibrate()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.IMU_SENSOR_CALIBRATE,
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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                Model.DataSectionModel.RequestModel.MessageBufLength,
                Model.DataSectionModel.RequestModel.MessageBuf,
                Model.DataSectionModel.RequestModel.MessageBufParity,
                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        //-------------------------------------------- Function Definition (Request - Sensor - IMU Sensor) ------------------------------------------

        //-------------------------------------------- Function Definition (Request - Driver) -------------------------------------------------------

        public int RequestReadDriverInformation()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.DRIVER_INFORMATION,
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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                Model.DataSectionModel.RequestModel.MessageBufLength,
                Model.DataSectionModel.RequestModel.MessageBuf,
                Model.DataSectionModel.RequestModel.MessageBufParity,
                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestReadDriverInstalled()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.DRIVER_INSTALLED,
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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                Model.DataSectionModel.RequestModel.MessageBufLength,
                Model.DataSectionModel.RequestModel.MessageBuf,
                Model.DataSectionModel.RequestModel.MessageBufParity,
                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestReadDriverAccessible()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.DRIVER_ACCESSIBLE,
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
                (uint)FFTAICommunicationRobotType.H4,
                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                Model.DataSectionModel.RequestModel.MessageBufLength,
                Model.DataSectionModel.RequestModel.MessageBuf,
                Model.DataSectionModel.RequestModel.MessageBufParity,
                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        //-------------------------------------------- Function Definition (Request - Driver) -------------------------------------------------------

        //-------------------------------------------- Function Definition (Request - Basic Motor Control) ------------------------------------------

        public int RequestReadModeOfOperation()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.MODE_OF_OPERATION,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }
        
        public int RequestWriteModeOfOperation(uint  modeOfOperation)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.MODE_OF_OPERATION,
                                (uint)FFTAICommunicationNumberOfParameter.ONE,
                                (uint)FFTAICommunicationReadWriteOperation.WRITE,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] { modeOfOperation, modeOfOperation, modeOfOperation, modeOfOperation });

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestReadControlWord()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.CONTROL_WORD,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestWriteControlWord(uint  controlWord)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.CONTROL_WORD,
                                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                                (uint)FFTAICommunicationReadWriteOperation.WRITE,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] { controlWord, controlWord, controlWord, controlWord });

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestReadStatusWord()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.STATUS_WORD,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }
        
        public int RequestWriteFaultClear()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.CLEAR_FAULT,
                                (uint)FFTAICommunicationNumberOfParameter.ZERO,
                                (uint)FFTAICommunicationReadWriteOperation.WRITE,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestWriteMotorEnable()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.MOTOR_ENABLE,
                                (uint)FFTAICommunicationNumberOfParameter.ZERO,
                                (uint)FFTAICommunicationReadWriteOperation.WRITE,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestWriteMotorDisable()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.MOTOR_DISABLE,
                                (uint)FFTAICommunicationNumberOfParameter.ZERO,
                                (uint)FFTAICommunicationReadWriteOperation.WRITE,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        //-------------------------------------------- Function Definition (Request - Basic Motor Configuration) ------------------------------------

        //-------------------------------------------- Function Definition (Request - Motor Information) --------------------------------------------

        public int RequestReadMotorCurrent()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.MOTOR_CURRENT,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestReadMotorInformation()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.MOTOR_INFORMATION,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        //-------------------------------------------- Function Definition (Request - Motor Information) --------------------------------------------

        //-------------------------------------------- Function Definition (Request - Joint Information) --------------------------------------------

        public int RequestReadJointTorque()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.JOINT_KINETIC,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestReadJointVelocity()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.JOINT_VELOCITY,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestReadJointPosition()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.JOINT_POSITION,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestReadJointInformation()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.JOINT_INFORMATION,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        //-------------------------------------------- Function Definition (Request - Joint Information) --------------------------------------------

        //-------------------------------------------- Function Definition (Request - End Effector Information) -------------------------------------

        public int RequestReadEndEffectorTorque()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.END_EFFECTOR_KINETIC,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestReadEndEffectorVelocity()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.END_EFFECTOR_VELOCITY,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestReadEndEffectorPosition()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.END_EFFECTOR_POSITION,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestReadEndEffectorInformation()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.END_EFFECTOR_INFORMATION,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        //-------------------------------------------- Function Definition (Request - End Effector Information) -------------------------------------

        //-------------------------------------------- Function Definition (Request - Protection) ---------------------------------------------------

        public int RequestGetJointLimitKinetic()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.JOINT_LIMIT_KINETIC,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestGetJointLimitAcceleration()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.JOINT_LIMIT_ACCELERATION,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestGetJointLimitVelocity()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.JOINT_LIMIT_VELOCITY,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestGetJointLimitPosition()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.JOINT_LIMIT_POSITION,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }


        public int RequestGetEndEffectorLimitKinetic()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.END_EFFECTOR_LIMIT_KINETIC,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestGetEndEffectorLimitAcceleration()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.END_EFFECTOR_LIMIT_ACCELERATION,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestGetEndEffectorLimitVelocity()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.END_EFFECTOR_LIMIT_VELOCITY,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestGetEndEffectorLimitPosition()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.END_EFFECTOR_LIMIT_POSITION,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestSetJointLimitKinetic(
            float horizontalJointLimitMinKinetic, 
            float horizontalJointLimitMaxKinetic,
            float verticalJointLimitMinKinetic, 
            float verticalJointLimitMaxKinetic)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.JOINT_LIMIT_KINETIC,
                                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(horizontalJointLimitMinKinetic), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(horizontalJointLimitMaxKinetic), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(verticalJointLimitMinKinetic), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(verticalJointLimitMaxKinetic), 0), });

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestSetJointLimitAcceleration(
            float horizontalJointLimitMinAcceleration, 
            float horizontalJointLimitMaxAcceleration,
            float verticalJointLimitMinAcceleration,
            float verticalJointLimitMaxAcceleration)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.JOINT_LIMIT_ACCELERATION,
                                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(horizontalJointLimitMinAcceleration), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(horizontalJointLimitMaxAcceleration), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(verticalJointLimitMinAcceleration), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(verticalJointLimitMaxAcceleration), 0), });

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestSetJointLimitVelocity(
            float horizontalJointLimitMinVelocity,
            float horizontalJointLimitMaxVelocity,
            float verticalJointLimitMinVelocity, 
            float verticalJointLimitMaxVelocity)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.JOINT_LIMIT_VELOCITY,
                                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(horizontalJointLimitMinVelocity), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(horizontalJointLimitMaxVelocity), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(verticalJointLimitMinVelocity), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(verticalJointLimitMaxVelocity), 0), });

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestSetJointLimitPosition(
            float horizontalJointLimitMinPosition, 
            float horizontalJointLimitMaxPosition,
            float verticalJointLimitMinPosition,
            float verticalJointLimitMaxPosition)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.JOINT_LIMIT_POSITION,
                                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(horizontalJointLimitMinPosition), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(horizontalJointLimitMaxPosition), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(verticalJointLimitMinPosition), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(verticalJointLimitMaxPosition), 0), });

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestSetCurrentValueAsJointLimitKinetic(
            uint  horizontalJointLimitMinSetFlag, 
            uint  horizontalJointLimitMaxSetFlag,
            uint  verticalJointLimitMinSetFlag, 
            uint  verticalJointLimitMaxSetFlag)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.CURRENT_VALUE_AS_JOINT_LIMIT_KINETIC,
                                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(horizontalJointLimitMinSetFlag), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(horizontalJointLimitMaxSetFlag), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(verticalJointLimitMinSetFlag), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(verticalJointLimitMaxSetFlag), 0), });

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestSetCurrentValueAsJointLimitAcceleration(
            uint  horizontalJointLimitMinSetFlag, 
            uint  horizontalJointLimitMaxSetFlag,
            uint  verticalJointLimitMinSetFlag,
            uint  verticalJointLimitMaxSetFlag)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.CURRENT_VALUE_AS_JOINT_LIMIT_ACCELERATION,
                                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(horizontalJointLimitMinSetFlag), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(horizontalJointLimitMaxSetFlag), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(verticalJointLimitMinSetFlag), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(verticalJointLimitMaxSetFlag), 0), });

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestSetCurrentValueAsJointLimitVelocity(
            uint  horizontalJointLimitMinSetFlag, 
            uint  horizontalJointLimitMaxSetFlag,
            uint  verticalJointLimitMinSetFlag,
            uint  verticalJointLimitMaxSetFlag)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.CURRENT_VALUE_AS_JOINT_LIMIT_VELOCITY,
                                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(horizontalJointLimitMinSetFlag), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(horizontalJointLimitMaxSetFlag), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(verticalJointLimitMinSetFlag), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(verticalJointLimitMaxSetFlag), 0), });

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestSetCurrentValueAsJointLimitPosition(
            uint  horizontalJointLimitMinSetFlag, 
            uint  horizontalJointLimitMaxSetFlag,
            uint  verticalJointLimitMinSetFlag,
            uint  verticalJointLimitMaxSetFlag)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.CURRENT_VALUE_AS_JOINT_LIMIT_POSITION,
                                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(horizontalJointLimitMinSetFlag), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(horizontalJointLimitMaxSetFlag), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(verticalJointLimitMinSetFlag), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(verticalJointLimitMaxSetFlag), 0), });

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestSetEndEffectorLimitKinetic(
            float horizontalEndEffectorLimitMinKinetic, 
            float horizontalEndEffectorLimitMaxKinetic,
            float verticalEndEffectorLimitMinKinetic,
            float verticalEndEffectorLimitMaxKinetic)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.END_EFFECTOR_LIMIT_KINETIC,
                                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(horizontalEndEffectorLimitMinKinetic), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(horizontalEndEffectorLimitMaxKinetic), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(verticalEndEffectorLimitMinKinetic), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(verticalEndEffectorLimitMaxKinetic), 0), });

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestSetEndEffectorLimitAcceleration(
            float horizontalEndEffectorLimitMinAcceleration,
            float horizontalEndEffectorLimitMaxAcceleration,
            float verticalEndEffectorLimitMinAcceleration, 
            float verticalEndEffectorLimitMaxAcceleration)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.END_EFFECTOR_LIMIT_ACCELERATION,
                                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(horizontalEndEffectorLimitMinAcceleration), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(horizontalEndEffectorLimitMaxAcceleration), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(verticalEndEffectorLimitMinAcceleration), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(verticalEndEffectorLimitMaxAcceleration), 0), });

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestSetEndEffectorLimitVelocity(
            float horizontalEndEffectorLimitMinVelocity, 
            float horizontalEndEffectorLimitMaxVelocity,
            float verticalEndEffectorLimitMinVelocity, 
            float verticalEndEffectorLimitMaxVelocity)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.END_EFFECTOR_LIMIT_VELOCITY,
                                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(horizontalEndEffectorLimitMinVelocity), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(horizontalEndEffectorLimitMaxVelocity), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(verticalEndEffectorLimitMinVelocity), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(verticalEndEffectorLimitMaxVelocity), 0), });

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestSetEndEffectorLimitPosition(
            float horizontalEndEffectorLimitMinPosition, 
            float horizontalEndEffectorLimitMaxPosition,
            float verticalEndEffectorLimitMinPosition,
            float verticalEndEffectorLimitMaxPosition)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.END_EFFECTOR_LIMIT_POSITION,
                                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(horizontalEndEffectorLimitMinPosition), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(horizontalEndEffectorLimitMaxPosition), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(verticalEndEffectorLimitMinPosition), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(verticalEndEffectorLimitMaxPosition), 0), });

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestSetCurrentValueAsEndEffectorLimitKinetic(
            uint  horizontalEndEffectorLimitMinSetFlag, 
            uint  horizontalEndEffectorLimitMaxSetFlag,
            uint  verticalEndEffectorLimitMinSetFlag, 
            uint  verticalEndEffectorLimitMaxSetFlag)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.CURRENT_VALUE_AS_END_EFFECTOR_LIMIT_KINETIC,
                                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(horizontalEndEffectorLimitMinSetFlag), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(horizontalEndEffectorLimitMaxSetFlag), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(verticalEndEffectorLimitMinSetFlag), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(verticalEndEffectorLimitMaxSetFlag), 0), });

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestSetCurrentValueAsEndEffectorLimitAcceleration(
            uint  horizontalEndEffectorLimitMinSetFlag, 
            uint  horizontalEndEffectorLimitMaxSetFlag,
            uint  verticalEndEffectorLimitMinSetFlag, 
            uint  verticalEndEffectorLimitMaxSetFlag)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.CURRENT_VALUE_AS_END_EFFECTOR_LIMIT_ACCELERATION,
                                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(horizontalEndEffectorLimitMinSetFlag), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(horizontalEndEffectorLimitMaxSetFlag), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(verticalEndEffectorLimitMinSetFlag), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(verticalEndEffectorLimitMaxSetFlag), 0), });

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestSetCurrentValueAsEndEffectorLimitVelocity(
            uint  horizontalEndEffectorLimitMinSetFlag, 
            uint  horizontalEndEffectorLimitMaxSetFlag,
            uint  verticalEndEffectorLimitMinSetFlag, 
            uint  verticalEndEffectorLimitMaxSetFlag)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.CURRENT_VALUE_AS_END_EFFECTOR_LIMIT_VELOCITY,
                                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(horizontalEndEffectorLimitMinSetFlag), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(horizontalEndEffectorLimitMaxSetFlag), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(verticalEndEffectorLimitMinSetFlag), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(verticalEndEffectorLimitMaxSetFlag), 0), });

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestSetCurrentValueAsEndEffectorLimitPosition(
            uint  horizontalEndEffectorLimitMinSetFlag, 
            uint  horizontalEndEffectorLimitMaxSetFlag,
            uint  verticalEndEffectorLimitMinSetFlag, 
            uint  verticalEndEffectorLimitMaxSetFlag)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.CURRENT_VALUE_AS_END_EFFECTOR_LIMIT_POSITION,
                                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                                (uint)FFTAICommunicationReadWriteOperation.SET,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(horizontalEndEffectorLimitMinSetFlag), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(horizontalEndEffectorLimitMaxSetFlag), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(verticalEndEffectorLimitMinSetFlag), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(verticalEndEffectorLimitMaxSetFlag), 0), });

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        //-------------------------------------------- Function Definition (Request - Protection) ---------------------------------------------------

        //-------------------------------------------- Function Definition (Request - Home Control) -------------------------------------------------
        
        public int RequestWriteHomeControlZeroHomePosition()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.HOME_CONTROL_ZERO_HOME_POSITION,
                                (uint)FFTAICommunicationNumberOfParameter.ZERO,
                                (uint)FFTAICommunicationReadWriteOperation.WRITE,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        //-------------------------------------------- Function Definition (Request - Home Control) -------------------------------------------------

        //-------------------------------------------- Function Definition (Request - Joint Torque Control) -----------------------------------------
        
        public int RequestReadJointTorqueControlTorque(
            float torque1, float torque2, float torque3, float torque4)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.JOINT_TORQUE_CONTROL_TORQUE,
                                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                                (uint)FFTAICommunicationReadWriteOperation.WRITE,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(torque1), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(torque2), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(torque3), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(torque4), 0)});

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestWriteJointTorqueControlTorque(
            float torque1, float torque2, float torque3, float torque4)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.JOINT_TORQUE_CONTROL_TORQUE,
                                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                                (uint)FFTAICommunicationReadWriteOperation.WRITE,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(torque1), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(torque2), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(torque3), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(torque4), 0)});

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        //-------------------------------------------- Function Definition (Request - Joint Torque Control) -----------------------------------------

        //-------------------------------------------- Function Definition (Request - Joint Velocity Control) ---------------------------------------

        public int RequestReadJointVelocityControlAcceleration()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.JOINT_VELOCITY_CONTROL_ACCELERATION,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestWriteJointVelocityControlAcceleration(
            float acceleration1, float acceleration2, float acceleration3, float acceleration4)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.JOINT_VELOCITY_CONTROL_ACCELERATION,
                                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                                (uint)FFTAICommunicationReadWriteOperation.WRITE,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(acceleration1), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(acceleration2), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(acceleration3), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(acceleration4), 0)});

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestReadJointVelocityControlDeceleration()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.JOINT_VELOCITY_CONTROL_DECELERATION,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestWriteJointVelocityControlDeceleration(
            float deceleration1, float deceleration2, float deceleration3, float deceleration4)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.JOINT_VELOCITY_CONTROL_DECELERATION,
                                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                                (uint)FFTAICommunicationReadWriteOperation.WRITE,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(deceleration1), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(deceleration2), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(deceleration3), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(deceleration4), 0)});

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestReadJointVelocityControlVelocity()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.JOINT_VELOCITY_CONTROL_VELOCITY,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestWriteJointVelocityControlVelocity(
            float velocity1, float velocity2, float velocity3, float velocity4)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.JOINT_VELOCITY_CONTROL_VELOCITY,
                                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                                (uint)FFTAICommunicationReadWriteOperation.WRITE,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(velocity1), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(velocity2), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(velocity3), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(velocity4), 0)});

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        //-------------------------------------------- Function Definition (Request - Joint Velocity Control) ---------------------------------------

        //-------------------------------------------- Function Definition (Request - Joint Position Control) ---------------------------------------
        
        public int RequestReadJointPositionControlAcceleration()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.JOINT_POSITION_CONTROL_ACCELERATION,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestWriteJointPositionControlAcceleration(
            float acceleration1, float acceleration2, float acceleration3, float acceleration4)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.JOINT_POSITION_CONTROL_ACCELERATION,
                                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                                (uint)FFTAICommunicationReadWriteOperation.WRITE,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(acceleration1), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(acceleration2), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(acceleration3), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(acceleration4), 0)});

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }
        
        public int RequestReadJointPositionControlDeceleration()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.JOINT_POSITION_CONTROL_DECELERATION,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestWriteJointPositionControlDeceleration(
            float deceleration1, float deceleration2, float deceleration3, float deceleration4)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.JOINT_POSITION_CONTROL_DECELERATION,
                                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                                (uint)FFTAICommunicationReadWriteOperation.WRITE,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(deceleration1), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(deceleration2), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(deceleration3), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(deceleration4), 0)});

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestReadJointPositionControlVelocity()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.JOINT_POSITION_CONTROL_VELOCITY,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestWriteJointPositionControlVelocity(
            float velocity1, float velocity2, float velocity3, float velocity4)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.JOINT_POSITION_CONTROL_VELOCITY,
                                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                                (uint)FFTAICommunicationReadWriteOperation.WRITE,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(velocity1), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(velocity2), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(velocity3), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(velocity4), 0)});

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestReadJointPositionControlPosition()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.JOINT_POSITION_CONTROL_POSITION,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestWriteJointPositionControlPosition(
            float position1, float position2, float position3, float position4)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.JOINT_POSITION_CONTROL_POSITION,
                                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                                (uint)FFTAICommunicationReadWriteOperation.WRITE,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(position1), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(position2), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(position3), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(position4), 0)});

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        //-------------------------------------------- Function Definition (Request - Joint Position Control) ---------------------------------------

        //-------------------------------------------- Function Definition (Request - End Effector Torque Control) ----------------------------------

        public int RequestReadEndEffectorTorqueControlTorque(
            float torque1, float torque2, float torque3, float torque4)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.END_EFFECTOR_TORQUE_CONTROL_TORQUE,
                                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                                (uint)FFTAICommunicationReadWriteOperation.WRITE,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(torque1), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(torque2), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(torque3), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(torque4), 0)});

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestWriteEndEffectorTorqueControlTorque(
            float torque1, float torque2, float torque3, float torque4)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.END_EFFECTOR_TORQUE_CONTROL_TORQUE,
                                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                                (uint)FFTAICommunicationReadWriteOperation.WRITE,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(torque1), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(torque2), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(torque3), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(torque4), 0)});

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        //-------------------------------------------- Function Definition (Request - End Effector Torque Control) ----------------------------------

        //-------------------------------------------- Function Definition (Request - End Effector Velocity Control) --------------------------------
        
        public int RequestReadEndEffectorVelocityControlAcceleration()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.END_EFFECTOR_VELOCITY_CONTROL_ACCELERATION,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestWriteEndEffectorVelocityControlAcceleration(
            float acceleration1, float acceleration2, float acceleration3, float acceleration4)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.END_EFFECTOR_VELOCITY_CONTROL_ACCELERATION,
                                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                                (uint)FFTAICommunicationReadWriteOperation.WRITE,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(acceleration1), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(acceleration2), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(acceleration3), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(acceleration4), 0)});

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestReadEndEffectorVelocityControlDeceleration()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.END_EFFECTOR_VELOCITY_CONTROL_DECELERATION,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestWriteEndEffectorVelocityControlDeceleration(
            float deceleration1, float deceleration2, float deceleration3, float deceleration4)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.END_EFFECTOR_VELOCITY_CONTROL_DECELERATION,
                                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                                (uint)FFTAICommunicationReadWriteOperation.WRITE,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(deceleration1), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(deceleration2), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(deceleration3), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(deceleration4), 0)});

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestReadEndEffectorVelocityControlVelocity()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.END_EFFECTOR_VELOCITY_CONTROL_VELOCITY,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestWriteEndEffectorVelocityControlVelocity(
            float velocity1, float velocity2, float velocity3, float velocity4)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.END_EFFECTOR_VELOCITY_CONTROL_VELOCITY,
                                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                                (uint)FFTAICommunicationReadWriteOperation.WRITE,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(velocity1), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(velocity2), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(velocity3), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(velocity4), 0)});

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        //-------------------------------------------- Function Definition (Request - End Effector Velocity Control) --------------------------------

        //-------------------------------------------- Function Definition (Request - End Effector Position Control) --------------------------------

        public int RequestReadEndEffectorPositionControlAcceleration()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.END_EFFECTOR_POSITION_CONTROL_ACCELERATION,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestWriteEndEffectorPositionControlAcceleration(
            float acceleration1, float acceleration2, float acceleration3, float acceleration4)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.END_EFFECTOR_POSITION_CONTROL_ACCELERATION,
                                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                                (uint)FFTAICommunicationReadWriteOperation.WRITE,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(acceleration1), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(acceleration2), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(acceleration3), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(acceleration4), 0)});

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestReadEndEffectorPositionControlDeceleration()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.END_EFFECTOR_POSITION_CONTROL_DECELERATION,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestWriteEndEffectorPositionControlDeceleration(
            float deceleration1, float deceleration2, float deceleration3, float deceleration4)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.END_EFFECTOR_POSITION_CONTROL_DECELERATION,
                                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                                (uint)FFTAICommunicationReadWriteOperation.WRITE,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(deceleration1), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(deceleration2), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(deceleration3), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(deceleration4), 0)});

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestReadEndEffectorPositionControlVelocity()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.END_EFFECTOR_POSITION_CONTROL_VELOCITY,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestWriteEndEffectorPositionControlVelocity(
            float velocity1, float velocity2, float velocity3, float velocity4)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.END_EFFECTOR_POSITION_CONTROL_VELOCITY,
                                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                                (uint)FFTAICommunicationReadWriteOperation.WRITE,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(velocity1), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(velocity2), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(velocity3), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(velocity4), 0)});

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestReadEndEffectorPositionControlPosition()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.END_EFFECTOR_POSITION_CONTROL_POSITION,
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
                                (uint)FFTAICommunicationRobotType.H4,
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestWriteEndEffectorPositionControlPosition(
            float position1, float position2, float position3, float position4)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationH4RobotInterfaceOperationMode.END_EFFECTOR_POSITION_CONTROL_POSITION,
                                (uint)FFTAICommunicationNumberOfParameter.FOUR,
                                (uint)FFTAICommunicationReadWriteOperation.WRITE,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] {
                                    BitConverter.ToUInt32(BitConverter.GetBytes(position1), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(position2), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(position3), 0),
                                    BitConverter.ToUInt32(BitConverter.GetBytes(position4), 0)});

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
                                (uint)FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

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
            int operationResult = (int)model.DataSectionModel.ResponseModel.OperationResult;


            switch (operationMode)
            {
                case FFTAICommunicationH4RobotInterfaceOperationMode.FLAG_INFORMATION:
                    {
                        switch (readWriteOperation)
                        {
                            case FFTAICommunicationReadWriteOperation.GET:
                            case FFTAICommunicationReadWriteOperation.READ:
                                StatusFlag.FlagCalibration = BitConverter.ToUInt32(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[0]), 0);
                                StatusFlag.FlagEmergentStop = BitConverter.ToUInt32(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[1]), 0);
                                StatusFlag.FlagFault = BitConverter.ToUInt32(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[2]), 0);
                                StatusFlag.FlagServoOn = BitConverter.ToUInt32(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[3]), 0);
                                break;
                            case FFTAICommunicationReadWriteOperation.SET:
                            case FFTAICommunicationReadWriteOperation.WRITE:
                                break;
                            default:
                                break;
                        }

                        break;
                    }
                case FFTAICommunicationH4RobotInterfaceOperationMode.FLAG_OUT_OF_JOINT_LIMIT_INFORMATION:
                    {
                        switch (readWriteOperation)
                        {
                            case FFTAICommunicationReadWriteOperation.GET:
                            case FFTAICommunicationReadWriteOperation.READ:
                                {
                                    StatusFlag.FlagOutOfJointKineticLimit = BitConverter.ToUInt32(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[0]), 0);
                                    StatusFlag.FlagOutOfJointAccelerationLimit = BitConverter.ToUInt32(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[1]), 0);
                                    StatusFlag.FlagOutOfJointVelocityLimit = BitConverter.ToUInt32(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[2]), 0);
                                    StatusFlag.FlagOutOfJointPositionLimit = BitConverter.ToUInt32(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[3]), 0);
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }

                        break;
                    }
                case FFTAICommunicationH4RobotInterfaceOperationMode.FLAG_OUT_OF_END_EFFECTOR_LIMIT_INFORMATION:
                    {
                        switch (readWriteOperation)
                        {
                            case FFTAICommunicationReadWriteOperation.GET:
                            case FFTAICommunicationReadWriteOperation.READ:
                                {
                                    StatusFlag.FlagOutOfEndEffectorKineticLimit = BitConverter.ToUInt32(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[0]), 0);
                                    StatusFlag.FlagOutOfEndEffectorAccelerationLimit = BitConverter.ToUInt32(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[1]), 0);
                                    StatusFlag.FlagOutOfEndEffectorVelocityLimit = BitConverter.ToUInt32(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[2]), 0);
                                    StatusFlag.FlagOutOfEndEffectorPositionLimit = BitConverter.ToUInt32(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[3]), 0);
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }

                        break;
                    }
                case FFTAICommunicationH4RobotInterfaceOperationMode.BUTTON_SENSOR_INFORMATION:
                    {
                        switch (readWriteOperation)
                        {
                            case FFTAICommunicationReadWriteOperation.GET:
                            case FFTAICommunicationReadWriteOperation.READ:
                                StatusDigiInput.IDL[0] = (uint)BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[0]), 0);
                                break;
                            case FFTAICommunicationReadWriteOperation.SET:
                            case FFTAICommunicationReadWriteOperation.WRITE:
                                break;
                            default:
                                break;
                        }

                        break;
                    }
                case FFTAICommunicationH4RobotInterfaceOperationMode.BUTTON_SENSOR_ACCESSIBLE:
                    {
                        switch (readWriteOperation)
                        {

                            case FFTAICommunicationReadWriteOperation.GET:
                            case FFTAICommunicationReadWriteOperation.READ:
                                StatusSensor.ButtonSensor1.Accessible = (uint)BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[0]), 0);
                                StatusSensor.ButtonSensor2.Accessible = (uint)BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[1]), 0);
                                StatusSensor.ButtonSensor3.Accessible = (uint)BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[2]), 0);
                                StatusSensor.ButtonSensor4.Accessible = (uint)BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[3]), 0);
                                break;
                            case FFTAICommunicationReadWriteOperation.SET:
                            case FFTAICommunicationReadWriteOperation.WRITE:
                                break;
                            default:
                                break;
                        }

                        break;
                    }
                case FFTAICommunicationH4RobotInterfaceOperationMode.IMU_SENSOR_INFORMATION:
                    {
                        switch (readWriteOperation)
                        {
                            case FFTAICommunicationReadWriteOperation.GET:
                            case FFTAICommunicationReadWriteOperation.READ:
                                StatusSensor.IMUSensor1.AccelerationValue[0] = BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[0]), 0);
                                StatusSensor.IMUSensor1.AccelerationValue[1] = BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[1]), 0);
                                StatusSensor.IMUSensor1.AccelerationValue[2] = BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[2]), 0);

                                StatusSensor.IMUSensor1.AngularVelocityValue[0] = BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[3]), 0);
                                StatusSensor.IMUSensor1.AngularVelocityValue[1] = BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[4]), 0);
                                StatusSensor.IMUSensor1.AngularVelocityValue[2] = BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[5]), 0);

                                StatusSensor.IMUSensor1.EulerAngleValue[0] = BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[6]), 0);
                                StatusSensor.IMUSensor1.EulerAngleValue[1] = BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[7]), 0);
                                StatusSensor.IMUSensor1.EulerAngleValue[2] = BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[8]), 0);

                                break;
                            default:
                                break;
                        }

                        break;
                    }
                case FFTAICommunicationH4RobotInterfaceOperationMode.IMU_SENSOR_ACCESSIBLE:
                    {
                        switch (readWriteOperation)
                        {
                            case FFTAICommunicationReadWriteOperation.GET:
                            case FFTAICommunicationReadWriteOperation.READ:
                                StatusSensor.ADCSensor5.Accessible = (uint)BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[0]), 0);
                                break;
                            default:
                                break;
                        }

                        break;
                    }
                case FFTAICommunicationH4RobotInterfaceOperationMode.DRIVER_ACCESSIBLE:
                    {
                        switch (readWriteOperation)
                        {
                            case FFTAICommunicationReadWriteOperation.GET:
                            case FFTAICommunicationReadWriteOperation.READ:
                                StatusRobot.Driver1.Accessible = (uint)BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[0]), 0);
                                StatusRobot.Driver2.Accessible = (uint)BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[1]), 0);
                                StatusRobot.Driver3.Accessible = (uint)BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[2]), 0);
                                StatusRobot.Driver4.Accessible = (uint)BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[3]), 0);
                                break;
                            default:
                                break;
                        }

                        break;
                    }
                case FFTAICommunicationH4RobotInterfaceOperationMode.JOINT_INFORMATION:
                    {
                        switch (readWriteOperation)
                        {
                            case FFTAICommunicationReadWriteOperation.GET:
                            case FFTAICommunicationReadWriteOperation.READ:

                                StatusRobot.KineticDataJoint1 = BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[0]), 0);
                                StatusRobot.KineticDataJoint2 = BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[1]), 0);
                                StatusRobot.KineticDataJoint3 = BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[2]), 0);
                                StatusRobot.KineticDataJoint4 = BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[3]), 0);
                                StatusRobot.VelocityDataJoint1 = BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[4]), 0);
                                StatusRobot.VelocityDataJoint2 = BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[5]), 0);
                                StatusRobot.VelocityDataJoint3 = BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[6]), 0);
                                StatusRobot.VelocityDataJoint4 = BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[7]), 0);
                                StatusRobot.PositionDataJoint1 = BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[8]), 0);
                                StatusRobot.PositionDataJoint2 = BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[9]), 0);
                                StatusRobot.PositionDataJoint3 = BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[10]), 0);
                                StatusRobot.PositionDataJoint4 = BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[11]), 0);

                                //StatusRobot.PositionDataJoint1 = StatusRobot.PositionDataJoint1 < 0 ? 0 : StatusRobot.PositionDataJoint1;
                                //StatusRobot.PositionDataJoint2 = StatusRobot.PositionDataJoint1 < 0 ? 0 : StatusRobot.PositionDataJoint2;
                                //StatusRobot.PositionDataJoint3 = StatusRobot.PositionDataJoint1 < 0 ? 0 : StatusRobot.PositionDataJoint3;
                                //StatusRobot.PositionDataJoint4 = StatusRobot.PositionDataJoint1 < 0 ? 0 : StatusRobot.PositionDataJoint4;
                                break;
                            case FFTAICommunicationReadWriteOperation.SET:
                            case FFTAICommunicationReadWriteOperation.WRITE:
                                break;
                            default:
                                break;
                        }

                        StatusRobotUpdateNotification();

                        break;
                    }
                case FFTAICommunicationH4RobotInterfaceOperationMode.END_EFFECTOR_INFORMATION:
                    {
                        switch (readWriteOperation)
                        {
                            case FFTAICommunicationReadWriteOperation.GET:
                            case FFTAICommunicationReadWriteOperation.READ:

                                StatusRobot.KineticDataEndEffectorX1 = BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[0]), 0);
                                StatusRobot.KineticDataEndEffectorY1 = BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[1]), 0);
                                StatusRobot.VelocityDataEndEffectorX1 = BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[2]), 0);
                                StatusRobot.VelocityDataEndEffectorY1 = BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[3]), 0);
                                StatusRobot.PositionDataEndEffectorX1 = BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[4]), 0);
                                StatusRobot.PositionDataEndEffectorY1 = BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[5]), 0);

                                //StatusRobot.PositionDataEndEffectorX1 = StatusRobot.PositionDataEndEffectorX1 < 0 ? 0 : StatusRobot.PositionDataEndEffectorX1;
                                //StatusRobot.PositionDataEndEffectorY1 = StatusRobot.PositionDataEndEffectorY1 < 0 ? 0 : StatusRobot.PositionDataEndEffectorY1;

                                StatusRobot.KineticDataEndEffectorX2 = BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[6]), 0);
                                StatusRobot.KineticDataEndEffectorY2 = BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[7]), 0);
                                StatusRobot.VelocityDataEndEffectorX2 = BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[8]), 0);
                                StatusRobot.VelocityDataEndEffectorY2 = BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[9]), 0);
                                StatusRobot.PositionDataEndEffectorX2 = BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[10]), 0);
                                StatusRobot.PositionDataEndEffectorY2 = BitConverter.ToSingle(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[11]), 0);

                                //StatusRobot.PositionDataEndEffectorX2 = StatusRobot.PositionDataEndEffectorX2 < 0 ? 0 : StatusRobot.PositionDataEndEffectorX2;
                                //StatusRobot.PositionDataEndEffectorY2 = StatusRobot.PositionDataEndEffectorY2 < 0 ? 0 : StatusRobot.PositionDataEndEffectorY2;
                                break;
                            case FFTAICommunicationReadWriteOperation.SET:
                            case FFTAICommunicationReadWriteOperation.WRITE:
                                break;
                            default:
                                break;
                        }

                        StatusRobotUpdateNotification();

                        break;
                    }
                default:
                    break;
            }

            return FunctionResult.SUCCESS;
        }

        public int GetFunctionType()
        {
            return FFTAICommunicationFunctionType.H4_ROBOT_INTERFACE;
        }
    }
}

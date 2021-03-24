using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static FFTAICommunicationLib.DynaLinkHS;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationIAPInterface : FFTAICommunicationInterfaceBasic,IFFTAICommunicationInterfaceObserver
    {
        public int RequestGetInitedFlag()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationIAPInterfacePredefine.INITED_FLAG,
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
                (uint)FFTAICommunicationRobotType.All,
                (uint)FFTAICommunicationFunctionType.IAP_INTERFACE,
                Model.DataSectionModel.RequestModel.MessageBufLength,
                Model.DataSectionModel.RequestModel.MessageBuf,
                Model.DataSectionModel.RequestModel.MessageBufParity,
                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestGetSoftwareVersion()
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationIAPInterfacePredefine.SOFTWARE_VERSION,
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
                (uint)FFTAICommunicationRobotType.All,
                (uint)FFTAICommunicationFunctionType.IAP_INTERFACE,
                Model.DataSectionModel.RequestModel.MessageBufLength,
                Model.DataSectionModel.RequestModel.MessageBuf,
                Model.DataSectionModel.RequestModel.MessageBufParity,
                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

		public int RequestGetBootMode()
		{
			int functionResult;

			// build request model
			functionResult = Model.DataSectionModel.RequestModel.Update(
				(uint)FFTAICommunicationIAPInterfacePredefine.BOOT_MODE,
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
				(uint)FFTAICommunicationRobotType.All,
				(uint)FFTAICommunicationFunctionType.IAP_INTERFACE,
				Model.DataSectionModel.RequestModel.MessageBufLength,
				Model.DataSectionModel.RequestModel.MessageBuf,
				Model.DataSectionModel.RequestModel.MessageBufParity,
				FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

			if (functionResult == FunctionResult.SUCCESS)
			{

			}
			else
			{
				return FunctionResult.FAIL;
			}

			return FunctionResult.SUCCESS;
		}

        public int RequestSetBootMode(
            uint  bootMode)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationIAPInterfacePredefine.BOOT_MODE,
                                (uint)FFTAICommunicationNumberOfParameter.ONE,
                                (uint)FFTAICommunicationReadWriteOperation.WRITE,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] { bootMode });

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
                                (uint)FFTAICommunicationFunctionType.IAP_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }
        
		public int RequestGetWorkStatus()
		{
			int functionResult;

			// build request model
			functionResult = Model.DataSectionModel.RequestModel.Update(
				(uint)FFTAICommunicationIAPInterfacePredefine.WORK_STATUS,
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
				(uint)FFTAICommunicationRobotType.All,
				(uint)FFTAICommunicationFunctionType.IAP_INTERFACE,
				Model.DataSectionModel.RequestModel.MessageBufLength,
				Model.DataSectionModel.RequestModel.MessageBuf,
				Model.DataSectionModel.RequestModel.MessageBufParity,
				FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

			if (functionResult == FunctionResult.SUCCESS)
			{

			}
			else
			{
				return FunctionResult.FAIL;
			}

			return FunctionResult.SUCCESS;
		}

        public int RequestSetIAPStartAddress(
            uint  iapStartAddress)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationIAPInterfacePredefine.IAP_START_ADDRESS,
                                (uint)FFTAICommunicationNumberOfParameter.ONE,
                                (uint)FFTAICommunicationReadWriteOperation.WRITE,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] { iapStartAddress });

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
                                (uint)FFTAICommunicationFunctionType.IAP_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestSetIAPSize(
            uint  iapSize)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationIAPInterfacePredefine.IAP_SIZE,
                                (uint)FFTAICommunicationNumberOfParameter.ONE,
                                (uint)FFTAICommunicationReadWriteOperation.WRITE,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] { iapSize });

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
                                (uint)FFTAICommunicationFunctionType.IAP_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestSetAPPStartAddress(
            uint  appStartAddress)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationIAPInterfacePredefine.APP_START_ADDRESS,
                                (uint)FFTAICommunicationNumberOfParameter.ONE,
                                (uint)FFTAICommunicationReadWriteOperation.WRITE,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] { appStartAddress });

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
                                (uint)FFTAICommunicationFunctionType.IAP_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestSetAPPSize(
            uint  appSize)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
								(uint)FFTAICommunicationIAPInterfacePredefine.APP_SIZE,
                                (uint)FFTAICommunicationNumberOfParameter.ONE,
                                (uint)FFTAICommunicationReadWriteOperation.WRITE,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] { appSize });

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
                                (uint)FFTAICommunicationFunctionType.IAP_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestSetUpgradeIAP(
            uint  addressOffset, uint  value)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationIAPInterfacePredefine.UPGRADE_IAP,
                                (uint)FFTAICommunicationNumberOfParameter.TWO,
                                (uint)FFTAICommunicationReadWriteOperation.WRITE,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
                                new uint [] { addressOffset, value });

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
                                (uint)FFTAICommunicationFunctionType.IAP_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

		public int RequestSetUpgradeIAPFast(
			uint  addressOffset, byte[] buffer, uint  bufferSize)
		{
			int functionResult;

			// set parameters
			uint  parameterSize = 1 + (bufferSize / 4);
			uint [] parameters = new uint [parameterSize];

			parameters [0] = addressOffset;

			for (uint  i = 0; i < (parameterSize - 1); i++) {
				parameters [i + 1] = 
					((uint)buffer [i * 4 + 0] << 24) 
					+ ((uint)buffer [i * 4 + 1] << 16)
					+ ((uint)buffer [i * 4 + 2] << 8)
					+ ((uint)buffer [i * 4 + 3] << 0);
			}

			// build request model
			functionResult = Model.DataSectionModel.RequestModel.Update(
				(uint)FFTAICommunicationIAPInterfacePredefine.UPGRADE_IAP_FAST,
				(uint)parameterSize,
				(uint)FFTAICommunicationReadWriteOperation.WRITE,
				(uint)FFTAICommunicationFillingParameter.PATCH,
				parameters);

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
				(uint)FFTAICommunicationFunctionType.IAP_INTERFACE,
				Model.DataSectionModel.RequestModel.MessageBufLength,
				Model.DataSectionModel.RequestModel.MessageBuf,
				Model.DataSectionModel.RequestModel.MessageBufParity,
				FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

			if (functionResult == FunctionResult.SUCCESS)
			{

			}
			else
			{
				return FunctionResult.FAIL;
			}

			return FunctionResult.SUCCESS;
		}

        public int RequestSetUpgradeIAMiddle(
            uint addressOffset, byte[] buffer, uint bufferSize)
        {
            int functionResult;

            // set parameters
            uint parameterSize = 1 + (bufferSize / 4);
            uint[] parameters = new uint[parameterSize];

            parameters[0] = addressOffset;

            for (uint i = 0; i < (parameterSize - 1); i++)
            {
                parameters[i + 1] =
                    ((uint)buffer[i * 4 + 0] << 24)
                    + ((uint)buffer[i * 4 + 1] << 16)
                    + ((uint)buffer[i * 4 + 2] << 8)
                    + ((uint)buffer[i * 4 + 3] << 0);
            }

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationIAPInterfacePredefine.UPGRADE_IAP_MIDDLE,
                (uint)parameterSize,
                (uint)FFTAICommunicationReadWriteOperation.WRITE,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                parameters);

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
                (uint)FFTAICommunicationFunctionType.IAP_INTERFACE,
                Model.DataSectionModel.RequestModel.MessageBufLength,
                Model.DataSectionModel.RequestModel.MessageBuf,
                Model.DataSectionModel.RequestModel.MessageBufParity,
                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestSetUpgradeIAPSlow(
            uint  addressOffset, byte[] buffer, uint  bufferSize)
        {
            int functionResult;

            // set parameters
            uint  parameterSize = 1 + (bufferSize / 4);
            uint [] parameters = new uint [parameterSize];

            parameters[0] = addressOffset;

            for (uint  i = 0; i < (parameterSize - 1); i++)
            {
                parameters[i + 1] =
                    ((uint)buffer[i * 4 + 0] << 24)
                    + ((uint)buffer[i * 4 + 1] << 16)
                    + ((uint)buffer[i * 4 + 2] << 8)
                    + ((uint)buffer[i * 4 + 3] << 0);
            }

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationIAPInterfacePredefine.UPGRADE_IAP_SLOW,
                (uint)parameterSize,
                (uint)FFTAICommunicationReadWriteOperation.WRITE,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                parameters);

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
                (uint)FFTAICommunicationFunctionType.IAP_INTERFACE,
                Model.DataSectionModel.RequestModel.MessageBufLength,
                Model.DataSectionModel.RequestModel.MessageBuf,
                Model.DataSectionModel.RequestModel.MessageBufParity,
                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestSetUpgradeAPP(
            uint  addressOffset, byte value)
        {
            int functionResult;

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                                (uint)FFTAICommunicationIAPInterfacePredefine.UPGRADE_APP,
                                (uint)FFTAICommunicationNumberOfParameter.TWO,
                                (uint)FFTAICommunicationReadWriteOperation.WRITE,
                                (uint)FFTAICommunicationFillingParameter.PATCH,
				new uint [] { addressOffset, (uint)value });

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
                                (uint)FFTAICommunicationFunctionType.IAP_INTERFACE,
                                Model.DataSectionModel.RequestModel.MessageBufLength,
                                Model.DataSectionModel.RequestModel.MessageBuf,
                                Model.DataSectionModel.RequestModel.MessageBufParity,
                                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

		public int RequestSetUpgradeAPPFast(
			uint  addressOffset, byte[] buffer, uint  bufferSize)
		{
			int functionResult;

			// set parameters
			uint  parameterSize = 1 + (bufferSize / 4);
			uint [] parameters = new uint [parameterSize];

			parameters [0] = addressOffset;

			for (uint  i = 0; i < (parameterSize - 1); i++) {
				parameters [i + 1] = 
					((uint)buffer [i * 4 + 0] << 24) 
					+ ((uint)buffer [i * 4 + 1] << 16)
					+ ((uint)buffer [i * 4 + 2] << 8)
					+ ((uint)buffer [i * 4 + 3] << 0);
			}

			// build request model
			functionResult = Model.DataSectionModel.RequestModel.Update(
				(uint)FFTAICommunicationIAPInterfacePredefine.UPGRADE_APP_FAST,
				(uint)parameterSize,
				(uint)FFTAICommunicationReadWriteOperation.WRITE,
				(uint)FFTAICommunicationFillingParameter.PATCH,
				parameters);

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
				(uint)FFTAICommunicationFunctionType.IAP_INTERFACE,
				Model.DataSectionModel.RequestModel.MessageBufLength,
				Model.DataSectionModel.RequestModel.MessageBuf,
				Model.DataSectionModel.RequestModel.MessageBufParity,
				FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

			if (functionResult == FunctionResult.SUCCESS)
			{

			}
			else
			{
				return FunctionResult.FAIL;
			}

			return FunctionResult.SUCCESS;
		}

        public int RequestSetUpgradeAPPMiddle(
            uint addressOffset, byte[] buffer, uint bufferSize)
        {
            int functionResult;

            // set parameters
            uint parameterSize = 1 + (bufferSize / 4);
            uint[] parameters = new uint[parameterSize];

            parameters[0] = addressOffset;

            for (uint i = 0; i < (parameterSize - 1); i++)
            {
                parameters[i + 1] =
                    ((uint)buffer[i * 4 + 0] << 24)
                    + ((uint)buffer[i * 4 + 1] << 16)
                    + ((uint)buffer[i * 4 + 2] << 8)
                    + ((uint)buffer[i * 4 + 3] << 0);
            }

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationIAPInterfacePredefine.UPGRADE_APP_MIDDLE,
                (uint)parameterSize,
                (uint)FFTAICommunicationReadWriteOperation.WRITE,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                parameters);

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
                (uint)FFTAICommunicationFunctionType.IAP_INTERFACE,
                Model.DataSectionModel.RequestModel.MessageBufLength,
                Model.DataSectionModel.RequestModel.MessageBuf,
                Model.DataSectionModel.RequestModel.MessageBufParity,
                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestSetUpgradeAPPSlow(
            uint  addressOffset, byte[] buffer, uint  bufferSize)
        {
            int functionResult;

            // set parameters
            uint  parameterSize = 1 + (bufferSize / 4);
            uint [] parameters = new uint [parameterSize];

            parameters[0] = addressOffset;

            for (uint  i = 0; i < (parameterSize - 1); i++)
            {
                parameters[i + 1] =
                    ((uint)buffer[i * 4 + 0] << 24)
                    + ((uint)buffer[i * 4 + 1] << 16)
                    + ((uint)buffer[i * 4 + 2] << 8)
                    + ((uint)buffer[i * 4 + 3] << 0);
            }

            // build request model
            functionResult = Model.DataSectionModel.RequestModel.Update(
                (uint)FFTAICommunicationIAPInterfacePredefine.UPGRADE_APP_SLOW,
                (uint)parameterSize,
                (uint)FFTAICommunicationReadWriteOperation.WRITE,
                (uint)FFTAICommunicationFillingParameter.PATCH,
                parameters);

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
                (uint)FFTAICommunicationFunctionType.IAP_INTERFACE,
                Model.DataSectionModel.RequestModel.MessageBufLength,
                Model.DataSectionModel.RequestModel.MessageBuf,
                Model.DataSectionModel.RequestModel.MessageBufParity,
                FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            return FunctionResult.SUCCESS;
        }

        public int RequestSetEraseIAP()
		{
			int functionResult;

			// build request model
			functionResult = Model.DataSectionModel.RequestModel.Update(
				(uint)FFTAICommunicationIAPInterfacePredefine.ERASE_IAP,
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
				(uint)FFTAICommunicationRobotType.All,
				(uint)FFTAICommunicationFunctionType.IAP_INTERFACE,
				Model.DataSectionModel.RequestModel.MessageBufLength,
				Model.DataSectionModel.RequestModel.MessageBuf,
				Model.DataSectionModel.RequestModel.MessageBufParity,
				FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

			if (functionResult == FunctionResult.SUCCESS)
			{

			}
			else
			{
				return FunctionResult.FAIL;
			}

			return FunctionResult.SUCCESS;
		}

		public int RequestSetEraseAPP()
		{
			int functionResult;

			// build request model
			functionResult = Model.DataSectionModel.RequestModel.Update(
				(uint)FFTAICommunicationIAPInterfacePredefine.ERASE_APP,
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
				(uint)FFTAICommunicationRobotType.All,
				(uint)FFTAICommunicationFunctionType.IAP_INTERFACE,
				Model.DataSectionModel.RequestModel.MessageBufLength,
				Model.DataSectionModel.RequestModel.MessageBuf,
				Model.DataSectionModel.RequestModel.MessageBufParity,
				FFTAICommunicationInterfaceRequestModel.END_OF_REQUEST_FRAME);

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

            StatusIAP.ProtocolVersion = FFTAICommunicationProtocolVersion.CurrentVersion;
            StatusIAP.ProtocolVersionString = (StatusIAP.ProtocolVersion >> 24 & 0xFF).ToString() + "." +
                            (StatusIAP.ProtocolVersion >> 16 & 0xFF).ToString() + "." +
                            (StatusIAP.ProtocolVersion >> 8 & 0xFF).ToString() + "." +
                            (StatusIAP.ProtocolVersion >> 0 & 0xFF).ToString();


            if (operationMode == FFTAICommunicationIAPInterfacePredefine.SOFTWARE_VERSION)
            {
                StatusIAP.SoftwareVersion =
                    BitConverter.ToUInt32(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[0]), 0);
                StatusIAP.SoftwareVersionString =
                    (StatusIAP.SoftwareVersion >> 24 & 0xFF).ToString() + "." +
                    (StatusIAP.SoftwareVersion >> 16 & 0xFF).ToString() + "." +
                    (StatusIAP.SoftwareVersion >> 8 & 0xFF).ToString() + "." +
                    (StatusIAP.SoftwareVersion >> 0 & 0xFF).ToString();

            }
            else if (operationMode == FFTAICommunicationIAPInterfacePredefine.BOOT_MODE)
            {
                StatusIAP.IAPBootMode =
                    (DynaLinkHS.IAPBootMode)BitConverter.ToUInt32(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[0]), 0);

            }
            else if (operationMode == FFTAICommunicationIAPInterfacePredefine.WORK_STATUS)
            {
                StatusIAP.IAPWorkStatus =
                    (DynaLinkHS.IAPWorkStatus)BitConverter.ToUInt32(BitConverter.GetBytes(model.DataSectionModel.ResponseModel.Parameter[0]), 0);

            }
            //case FFTAICommunicationIAPInterfacePredefine.UPGRADE_IAP:
            else if (operationMode == FFTAICommunicationIAPInterfacePredefine.UPGRADE_IAP_FAST || operationMode == FFTAICommunicationIAPInterfacePredefine.UPGRADE_IAP_SLOW)
            {
                if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_2)
                {
                    switch (operationResult)
                    {
                        //  由于新老版本通信  标识数值的不同，所以在这里需要减去1,因为0表示的是v2版本的通信成功常量
                        case FFTAICommunicationOperationResult.SUCCESS - 1:

                            Debugs.Log("IAP Interface Receive Upgrade IAP Response : SUCCESS.", FFTAIRobotCommLogType.DEBUG);

                            IAPUpgradeIapTransmitLocker = false;

                            break;
                        //  由于新老版本通信  标识数值的不同，所以在这里需要减去1,因为1表示的是v2版本的通信失败的常量
                        case FFTAICommunicationOperationResult.FAIL - 1:

                            Debugs.Log("IAP Interface Receive Upgrade IAP Response : FAIL.", FFTAIRobotCommLogType.DEBUG);

                            IAPUpgradeIapResendRequestFlag = true;
                            IAPUpgradeIapTransmitLocker = false;

                            break;
                        default:
                            break;
                    }
                }
                else if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_3)
                {
                    switch (operationResult)
                    {
                        case FFTAICommunicationOperationResult.SUCCESS:

                            Debugs.Log("IAP Interface Receive Upgrade IAP Response : SUCCESS.", FFTAIRobotCommLogType.DEBUG);

                            IAPUpgradeIapTransmitLocker = false;

                            break;
                        case FFTAICommunicationOperationResult.FAIL:

                            Debugs.Log("IAP Interface Receive Upgrade IAP Response : FAIL.", FFTAIRobotCommLogType.DEBUG);

                            IAPUpgradeIapResendRequestFlag = true;
                            IAPUpgradeIapTransmitLocker = false;

                            break;
                        default:
                            break;
                    }
                }
            }
            //case FFTAICommunicationIAPInterfacePredefine.UPGRADE_APP:
            else if (operationMode == FFTAICommunicationIAPInterfacePredefine.UPGRADE_APP_FAST || operationMode == FFTAICommunicationIAPInterfacePredefine.UPGRADE_APP_SLOW)
            {
                if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_2)
                {
                    switch (operationResult)
                    {
                        //由于新老版本通信  标识数值的不同，所以在这里需要减去1,因为0表示的是v2版本的通信成功常量
                        case FFTAICommunicationOperationResult.SUCCESS - 1:

                            Debugs.Log("IAP Interface Receive Upgrade APP Response : SUCCESS.", FFTAIRobotCommLogType.DEBUG);

                            IAPUpgradeAppTransmitLocker = false;

                            break;
                        //由于新老版本通信  标识数值的不同，所以在这里需要减去1,因为1表示的是v2版本的通信失败的常量
                        case FFTAICommunicationOperationResult.FAIL - 1:

                            Debugs.Log("IAP Interface Receive Upgrade APP Response : FAIL.", FFTAIRobotCommLogType.DEBUG);

                            IAPUpgradeAppResendRequestFlag = true;
                            IAPUpgradeAppTransmitLocker = false;

                            break;
                        default:
                            break;
                    }
                }
                else if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_3)
                {
                    switch (operationResult)
                    {
                        case FFTAICommunicationOperationResult.SUCCESS:

                            Debugs.Log("IAP Interface Receive Upgrade APP Response : SUCCESS.", FFTAIRobotCommLogType.DEBUG);

                            IAPUpgradeAppTransmitLocker = false;

                            break;
                        case FFTAICommunicationOperationResult.FAIL:

                            Debugs.Log("IAP Interface Receive Upgrade APP Response : FAIL.", FFTAIRobotCommLogType.DEBUG);

                            IAPUpgradeAppResendRequestFlag = true;
                            IAPUpgradeAppTransmitLocker = false;

                            break;
                        default:
                            break;
                    }
                }
            }

            return FunctionResult.SUCCESS;
        }

        public int GetFunctionType()
        {
            return FFTAICommunicationFunctionType.IAP_INTERFACE;
        }
    }
}

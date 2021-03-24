/**
* @file DynalinkHS.cs
* @brief Unity Communication Interface with MMU
* @details 
* @mainpage 
* @author Jason(Chen Xin)
* @email xin.chen@fftai.com
* @version 1.0.0
* @date 2019-01-24
* @license Private
*/

using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Reflection;
using System.Net.NetworkInformation;

namespace FFTAICommunicationLib
{
    public partial class DynaLinkHS
    {
        //-------------------------------------------- Variable Definition (Singleton) -------------------------------------------------------------------------

        private static volatile DynaLinkHS instance;

        /// <summary>
        /// @brief The singleton instance of DynalinkHS class [DynalinkHS 的单例]
        /// </summary>
        public static DynaLinkHS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DynaLinkHS();
                }
                return instance;
            }
        }

        #region Timer Function
        private static void UpdateTimerCallbackFunction(object state)
        {
            UpdateTimerActiveFlag = true;

            // update count
            UpdateTimerPeriodCount++;

            // server link monitor
            if (UpdateTimerPeriodCount % ServerLinkMonitorTimerPeriodCount == 0
                && ServerLinkMonitorTimerLocker == false)
            {
                ServerLinkMonitorTimerFunction();
            }

            // iap information
            if (UpdateTimerPeriodCount % IAPTimerPeriodCount == 0
                && IAPTimerLocker == false)
            {
                // if work in iap or app upgrade, then sleep
                if (IAPUpgradeIapLocker == true || IAPUpgradeAppLocker == true)
                {
                }
                else
                {
                    IAPTimerFunction();
                }
            }

            // system periodic
            if (UpdateTimerPeriodCount % APPPeriodicFunctionTimerPeriodCount == 0
                && APPPeriodicFunctionTimerLocker == false)
            {
                // if work in iap or app upgrade, then sleep
                if (IAPUpgradeIapLocker == true || IAPUpgradeAppLocker == true)
                {
                }
                else
                {
                    APPTimerFunction();
                }
            }

            // hardware periodic
            if (UpdateTimerPeriodCount % HardwareStatusPeriodicFunctionTimerPeriodCount == 0
                && HardwareStatusPeriodicFunctionTimerLocker == false
                && StatusIAP.IAPWorkStatus != DynaLinkHS.IAPWorkStatus.IAP)
            {
                // if work in iap or app upgrade, then sleep
                if (IAPUpgradeIapLocker == true || IAPUpgradeAppLocker == true)
                {
                }
                else
                {
                    HardwareStatusPeriodicTimerFunction();
                }
            }

            // flag periodic
            if (UpdateTimerPeriodCount % FlagPeriodicFunctionTimerPeriodCount == 0
                && FlagPeriodicFunctionTimerLocker == false
                && StatusIAP.IAPWorkStatus != DynaLinkHS.IAPWorkStatus.IAP)
            {
                // if work in iap or app upgrade, then sleep
                if (IAPUpgradeIapLocker == true || IAPUpgradeAppLocker == true)
                {
                }
                else
                {
                    FlagPeriodicTimerFunction();
                }
            }

            // robot status
            if (UpdateTimerPeriodCount % RobotDriverStatusPeriodicFunctionTimerPeriodCount == 0
                && RobotStatusPeriodicFunctionTimerLocker == false
                && StatusIAP.IAPWorkStatus != DynaLinkHS.IAPWorkStatus.IAP)
            {
                // if work in iap or app upgrade, then sleep
                if (IAPUpgradeIapLocker == true || IAPUpgradeAppLocker == true)
                {
                }
                else
                {
                    RobotStatusPeriodicTimerFunction();
                }
            }

            // robot sensor
            if (UpdateTimerPeriodCount % RobotSensorStatusPeriodicFunctionTimerPeriodCount == 0
                && RobotSensorStatusPeriodicFunctionTimerLocker == false
                && StatusIAP.IAPWorkStatus != DynaLinkHS.IAPWorkStatus.IAP)
            {
                // if work in iap or app upgrade, then sleep
                if (IAPUpgradeIapLocker == true || IAPUpgradeAppLocker == true)
                {
                }
                else
                {
                    RobotSensorStatusPeriodicTimerFunction();
                }
            }

            // robot parameters
            if (UpdateTimerPeriodCount % RobotParameterStatusPeriodicFunctionTimerPeriodCount == 0
                && RobotParameterStatusPeriodicFunctionTimerLocker == false
                && StatusIAP.IAPWorkStatus != DynaLinkHS.IAPWorkStatus.IAP)
            {
                // if work in iap or app upgrade, then sleep
                if (IAPUpgradeIapLocker == true || IAPUpgradeAppLocker == true)
                {

                }
                else
                {
                    RobotParameterStatusPeriodicTimerFunction();
                }
            }

            //recording data to the parameter List if connected.
            if (UpdateTimerPeriodCount%RobotParametersRequestTimerPeriodCount==0
                && RobotParametersRequestPeriodicTimerLocker == false)
            {
                RobotParametersRequestTimerFunction();
            }

            // clear count
            if (ServerLinkMonitorCount > UpdateTimerPeriodMaximumCount)
            {
                UpdateTimerPeriodCount = 0;
            }
        }

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int connectionDescription, int reservedValue);

        private static void ServerLinkMonitorTimerFunction()
        {
            // lock server monitor timer
            ServerLinkMonitorTimerLocker = true;

            //check network is ok 
            int i = 0;
            if(InternetGetConnectedState(out i, 0))
            {

            }
            else
            {
                Disconnect();
            }

            int functionResult = FunctionResult.NONE;

            try
            {
                /**
                 *  Note :  The link act judegement must before the RequestTestConnection(), 
                 *          because once the connection is broken, the exception will be throw out, 
                 *          and the rest code will not be execute.
                 */
                // monitor count add 1
                if (StatusFlag.FlagServerLinkActive == 0x01)
                {
                    /**
                     *  Note : In case of iap or app update, do not add server link monitor count !!!
                     */
                    if (IAPUpgradeIapLocker == true || IAPUpgradeAppLocker == true)
                    {

                    }
                    else
                    {
                        ServerLinkMonitorCount++;
                    }
                }

                if (ServerLinkMonitorCount > ServerLinkMonitorMaximumCount)
                {
                    Disconnect(); // the server is down, close socket

                    // Thread.CurrentThread.Abort(); // kill current thread
                }

                // send connection test request
                functionResult = FFTAICommunicationManager.getInstance().communicationInterface.RequestTestConnection();

                // detect socket exception
                if (functionResult == FunctionResult.SOCKET_EXCEPTION||functionResult == FunctionResult.FAIL)
                {
                    Disconnect(); // the server is down, close socket
                }
            }
            catch (Exception exception)
            {
                //if power off or  cable cutted will throw this exception
                Debugs.Log("ServerLinkMonitorTimerFunction() catch exception : " + exception, FFTAIRobotCommLogType.WARNING);
                Disconnect();
            }

            //-------------------------------------------------------------------

            // unlock server monitor timer
            ServerLinkMonitorTimerLocker = false;
        }
        
        private static void IAPTimerFunction()
        {
            // lock server monitor timer
            IAPTimerLocker = true;

            //-------------------------------------------------------------------

            int functionResult = FunctionResult.NONE;

            try
            {
                // send iap request
                functionResult = FFTAICommunicationManager.getInstance().iapInterface.RequestGetSoftwareVersion();

                // detect socket exception
                if (functionResult == FunctionResult.SOCKET_EXCEPTION)
                {
                    Disconnect(); // the server is down, close socket
                }

                // send iap request
                functionResult = FFTAICommunicationManager.getInstance().iapInterface.RequestGetBootMode();

                // detect socket exception
                if (functionResult == FunctionResult.SOCKET_EXCEPTION)
                {
                    Disconnect(); // the server is down, close socket
                }

                // send iap request
                functionResult = FFTAICommunicationManager.getInstance().iapInterface.RequestGetWorkStatus();

                // detect socket exception
                if (functionResult == FunctionResult.SOCKET_EXCEPTION)
                {
                    Disconnect(); // the server is down, close socket
                }
            }
            catch (Exception exception)
            {
                Debugs.Log("ServerLinkMonitorTimerFunction() catch exception : " + exception, FFTAIRobotCommLogType.WARNING);
            }

            //-------------------------------------------------------------------

            // unlock server monitor timer
            IAPTimerLocker = false;
        }

        private static void APPTimerFunction()
        {
            // lock
            APPPeriodicFunctionTimerLocker = true;

            //-------------------------------------------------------------------

            int functionResult = FunctionResult.NONE;

            try
            {
                // send system request
                functionResult = FFTAICommunicationManager.getInstance().appInterface.RequestGetHardwareVersion();

                // detect socket exception
                if (functionResult == FunctionResult.SOCKET_EXCEPTION)
                {
                    Disconnect(); // the server is down, close socket
                }

                // send system request
                functionResult = FFTAICommunicationManager.getInstance().appInterface.RequestGetSoftwareVersion();

                // detect socket exception
                if (functionResult == FunctionResult.SOCKET_EXCEPTION)
                {
                    Disconnect(); // the server is down, close socket
                }

                // send system request
                functionResult = FFTAICommunicationManager.getInstance().appInterface.RequestGetSerialNumber();

                // detect socket exception
                if (functionResult == FunctionResult.SOCKET_EXCEPTION)
                {
                    Disconnect(); // the server is down, close socket
                }

                // send system request
                functionResult = FFTAICommunicationManager.getInstance().appInterface.RequestGetRobotType();

                // detect socket exception
                if (functionResult == FunctionResult.SOCKET_EXCEPTION)
                {
                    Disconnect(); // the server is down, close socket
                }

                // send system request
                functionResult = FFTAICommunicationManager.getInstance().appInterface.RequestGetMechanismVersion();

                // detect socket exception
                if (functionResult == FunctionResult.SOCKET_EXCEPTION)
                {
                    Disconnect(); // the server is down, close socket
                }

                // send system request
                functionResult = FFTAICommunicationManager.getInstance().appInterface.RequestGetRobotSerialNumber();

                // detect socket exception
                if (functionResult == FunctionResult.SOCKET_EXCEPTION)
                {
                    Disconnect(); // the server is down, close socket
                }
            }
            catch (Exception exception)
            {
                Debugs.Log("ServerLinkMonitorTimerFunction() catch exception : " + exception, FFTAIRobotCommLogType.WARNING);
            }

            //-------------------------------------------------------------------

            // unlock
            APPPeriodicFunctionTimerLocker = false;
        }

        private static void FlagPeriodicTimerFunction()
        {
            // lock periodic timer
            FlagPeriodicFunctionTimerLocker = true;

            //-------------------------------------------------------------------

            try
            {
                switch (DynaLinkHS.StatusApp.RobotType)
                {
                    case DynaLinkHS.RobotType.H4:
                        {
                            CommunicationV2H4FlagPeriodicFunction();
                            break;
                        }
                    case DynaLinkHS.RobotType.M1:
                        {
                            CommunicationV2M1FlagPeriodicFunction();
                            break;
                        }
                    case DynaLinkHS.RobotType.M1_L:
                        {
                            CommunicationV2M1_LFlagPeriodicFunction();
                            break;
                        }
                    case DynaLinkHS.RobotType.M2:
                        {
                            CommunicationV2M2FlagPeriodicFunction();
                            break;
                        }
                    case DynaLinkHS.RobotType.M3:
                        {
                            CommunicationV2M3FlagPeriodicFunction();
                            break;
                        }
                    case DynaLinkHS.RobotType.M6:
                        {
                            CommunicationV2M6FlagPeriodicFunction();
                            break;
                        }
                    case DynaLinkHS.RobotType.X1:
                        {
                            CommunicationV2X1FlagPeriodicFunction();
                            break;
                        }
                    case DynaLinkHS.RobotType.X2:
                        {
                            CommunicationV2X2FlagPeriodicFunction();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            catch (Exception exception)
            {
                Debugs.Log("PeriodicTimerFunction() catch exception : " + exception, FFTAIRobotCommLogType.WARNING);
            }

            //-------------------------------------------------------------------

            // unlock periodic timer
            FlagPeriodicFunctionTimerLocker = false;
        }

        private static void HardwareStatusPeriodicTimerFunction()
        {
            // lock periodic timer
            HardwareStatusPeriodicFunctionTimerLocker = true;

            //-------------------------------------------------------------------

            try
            {
                switch (DynaLinkHS.StatusApp.HardwareVersion)
                {
                    case 0x01:
                        {
                            break;
                        }
                    case 0x02:
                        {
                            CommunicationV2M2HardwareStatusPeriodicFunction();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            catch (Exception exception)
            {
                Debugs.Log("PeriodicTimerFunction() catch exception : " + exception, FFTAIRobotCommLogType.WARNING);
            }

            //-------------------------------------------------------------------

            // unlock periodic timer
            HardwareStatusPeriodicFunctionTimerLocker = false;
        }

        private static void RobotStatusPeriodicTimerFunction()
        {
            // lock periodic timer
            RobotStatusPeriodicFunctionTimerLocker = true;

            //-------------------------------------------------------------------

            try
            {
                switch (DynaLinkHS.StatusApp.RobotType)
                {
                    case DynaLinkHS.RobotType.H4:
                        {
                            CommunicationV2H4RobotStatusPeriodicFunction();
                            break;
                        }
                    case DynaLinkHS.RobotType.M1:
                        {
                            CommunicationV2M1RobotStatusPeriodicFunction();
                            break;
                        }
                    case DynaLinkHS.RobotType.M1_L:
                        {
                            CommunicationV2M1_LRobotStatusPeriodicFunction();
                            break;
                        }
                    case DynaLinkHS.RobotType.M2:
                        {
                            CommunicationV2M2RobotStatusPeriodicFunction();
                            break;
                        }
                    case DynaLinkHS.RobotType.M3:
                        {
                            CommunicationV2M3RobotStatusPeriodicFunction();
                            break;
                        }
                    case DynaLinkHS.RobotType.M6:
                        {
                            CommunicationV2M6RobotStatusPeriodicFunction();
                            break;
                        }
                    case DynaLinkHS.RobotType.X1:
                        {
                            CommunicationV2X1RobotStatusPeriodicFunction();
                            break;
                        }
                    case DynaLinkHS.RobotType.X2:
                        {
                            CommunicationV2X2RobotStatusPeriodicFunction();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            catch (Exception exception)
            {
                Debugs.Log("PeriodicTimerFunction() catch exception : " + exception, FFTAIRobotCommLogType.WARNING);
            }

            //-------------------------------------------------------------------

            // unlock periodic timer
            RobotStatusPeriodicFunctionTimerLocker = false;
        }

        private static void RobotSensorStatusPeriodicTimerFunction()
        {
            // lock periodic timer
            RobotSensorStatusPeriodicFunctionTimerLocker = true;

            //-------------------------------------------------------------------

            try
            {
                switch (DynaLinkHS.StatusApp.RobotType)
                {
                    case DynaLinkHS.RobotType.H4:
                        {
                            CommunicationV2H4RobotSensorStatusPeriodicFunction();
                            break;
                        }
                    case DynaLinkHS.RobotType.M1:
                        {
                            CommunicationV2M1RobotSensorStatusPeriodicFunction();
                            break;
                        }
                    case DynaLinkHS.RobotType.M1_L:
                        {
                            CommunicationV2M1_LRobotSensorStatusPeriodicFunction();
                            break;
                        }
                    case DynaLinkHS.RobotType.M2:
                        {
                            CommunicationV2M2RobotSensorStatusPeriodicFunction();
                            break;
                        }
                    case DynaLinkHS.RobotType.M3:
                        {
                            CommunicationV2M3RobotSensorStatusPeriodicFunction();
                            break;
                        }
                    case DynaLinkHS.RobotType.M6:
                        {
                            CommunicationV2M6RobotSensorStatusPeriodicFunction();
                            break;
                        }
                    case DynaLinkHS.RobotType.X1:
                        {
                            CommunicationV2X1RobotSensorStatusPeriodicFunction();
                            break;
                        }
                    case DynaLinkHS.RobotType.X2:
                        {
                            CommunicationV2X2RobotSensorStatusPeriodicFunction();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            catch (Exception exception)
            {
                Debugs.Log("PeriodicTimerFunction() catch exception : " + exception, FFTAIRobotCommLogType.WARNING);
            }

            //-------------------------------------------------------------------

            // unlock periodic timer
            RobotSensorStatusPeriodicFunctionTimerLocker = false;
        }

        private static void RobotParameterStatusPeriodicTimerFunction()
        {
            // lock periodic timer
            RobotParameterStatusPeriodicFunctionTimerLocker = true;

            //-------------------------------------------------------------------

            try
            {
                switch (DynaLinkHS.StatusApp.RobotType)
                {
                    case DynaLinkHS.RobotType.H4:
                        {
                            CommunicationV2H4RobotParameterStatusPeriodicFunction();
                            break;
                        }
                    case DynaLinkHS.RobotType.M1:
                        {
                            CommunicationV2M1RobotParameterStatusPeriodicFunction();
                            break;
                        }
                    case DynaLinkHS.RobotType.M1_L:
                        {
                            CommunicationV2M1_LRobotParameterStatusPeriodicFunction();
                            break;
                        }
                    case DynaLinkHS.RobotType.M2:
                        {
                            CommunicationV2M2RobotParameterStatusPeriodicFunction();
                            break;
                        }
                    case DynaLinkHS.RobotType.M3:
                        {
                            CommunicationV2M3RobotParameterStatusPeriodicFunction();
                            break;
                        }
                    case DynaLinkHS.RobotType.M6:
                        {
                            CommunicationV2M6RobotParameterStatusPeriodicFunction();
                            break;
                        }
                    case DynaLinkHS.RobotType.X1:
                        {
                            CommunicationV2X1RobotParameterStatusPeriodicFunction();
                            break;
                        }
                    case DynaLinkHS.RobotType.X2:
                        {
                            CommunicationV2X2RobotParameterStatusPeriodicFunction();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            catch (Exception exception)
            {
                Debugs.Log("PeriodicTimerFunction() catch exception : " + exception, FFTAIRobotCommLogType.WARNING);
            }

            //-------------------------------------------------------------------

            // unlock periodic timer
            RobotParameterStatusPeriodicFunctionTimerLocker = false;
        }

        private static void RobotParametersRequestTimerFunction()
        {
            for (int i = 0; i < RobotDataFieldInfoList.Count; i++)
            {
                FieldInfo fieldInfo = RobotDataFieldInfoList[i];
                float value = float.Parse(fieldInfo.GetValue(null).ToString());
                string fieldInfoName = fieldInfo.Name;
                if (!AllRobotDataDic.ContainsKey(fieldInfoName))
                {
                    List<float> valueList = new List<float>();
                    valueList.Add(value);
                    AllRobotDataDic.Add(fieldInfoName, valueList);
                }
                else
                {
                    List<float> valueList = AllRobotDataDic[fieldInfoName];
                    valueList.Add(value);
                }
            }
            TimestampsList.Add(DateTime.Now);
        }

        #endregion

        #region Period Function Definition (V2 H4)
        private static int CommunicationV2H4FlagPeriodicFunction()
        {
            int functionResult;

            // request for robot information ------------------------------------------------

            functionResult = FFTAICommunicationManager.getInstance().H4RobotInterface.RequestReadFlagInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().H4RobotInterface.RequestReadFlagOutOfJointLimitInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().H4RobotInterface.RequestReadFlagOutOfEndEffectorLimitInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            // request for robot information ------------------------------------------------

            // request for task information -------------------------------------------------

            functionResult = FFTAICommunicationManager.getInstance().H4TaskInterface.RequestReadFlagInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().H4TaskInterface.RequestReadSubtasWalkPassiveState();

            if (functionResult==FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect();
                return FunctionResult.FAIL;
            }

            // request for task information -------------------------------------------------

            return FunctionResult.SUCCESS;
        }

        private static int CommunicationV2H4RobotStatusPeriodicFunction()
        {
            int functionResult;

            // request for hardware information ---------------------------------------------

            //functionResult = FFTAICommunicationManager.getInstance().FFTAICommunicationV2HardwareInterface.RequestReadGpioIoStatus();

            //if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            //{
            //            FFTAIRobotCommLog.getInstance().WriteLine("Socket Exception, Server is Down.", FFTAIRobotCommLogType.DEBUG);
            //            ServerLinkMonitorCount = 0;
            //            Disconnect(); // the server is down, close socket
            //            return FunctionResult.FAIL;
            //}

            // request for hardware information ---------------------------------------------

            // request for robot information ------------------------------------------------

            functionResult = FFTAICommunicationManager.getInstance().H4RobotInterface.RequestReadDriverAccessible();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().H4RobotInterface.RequestReadJointInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().H4RobotInterface.RequestReadEndEffectorInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            // request for robot information ------------------------------------------------

            return FunctionResult.SUCCESS;
        }

        private static int CommunicationV2H4RobotSensorStatusPeriodicFunction()
        {
            int functionResult;

            // request for robot sensor information -----------------------------------------

            functionResult = FFTAICommunicationManager.getInstance().H4RobotInterface.RequestReadButtonSensorAccessible();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().H4RobotInterface.RequestReadIMUSensorAccessible();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().H4RobotInterface.RequestReadButtonSensorInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }
         
            functionResult = FFTAICommunicationManager.getInstance().H4RobotInterface.RequestReadIMUSensorInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            // request for robot sensor information -----------------------------------------

            return FunctionResult.SUCCESS;
        }

        private static int CommunicationV2H4RobotParameterStatusPeriodicFunction()
        {
            int functionResult;

            // request for robot sensor information -----------------------------------------

            functionResult = FFTAICommunicationManager.getInstance().H4RobotInterface.RequestGetJointLimitKinetic();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().H4RobotInterface.RequestGetJointLimitVelocity();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().H4RobotInterface.RequestGetJointLimitPosition();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().H4RobotInterface.RequestGetEndEffectorLimitKinetic();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().H4RobotInterface.RequestGetEndEffectorLimitVelocity();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().H4RobotInterface.RequestGetEndEffectorLimitPosition();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            // request for robot sensor information -----------------------------------------

            return FunctionResult.SUCCESS;
        }

        #endregion

        #region  Period Function Definition (V2 M1)
        private static int CommunicationV2M1FlagPeriodicFunction()
        {
            int functionResult;

            // request for robot information ------------------------------------------------
            functionResult = FFTAICommunicationManager.getInstance().M1RobotInterface.RequestReadFlagCalibration();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M1RobotInterface.RequestReadFlagServoOn();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M1RobotInterface.RequestReadFlagEmergentStop();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M1RobotInterface.RequestReadFlagFault();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M1RobotInterface.RequestReadEmergentButtonStopValue();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M1RobotInterface.RequestReadButtonSensorInstalled();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M1RobotInterface.RequestReadFlagInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M1RobotInterface.RequestReadFlagOutOfJointLimitInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M1RobotInterface.RequestReadFlagOutOfEndEffectorLimitInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            // request for robot information ------------------------------------------------

            // request for task information -------------------------------------------------

            functionResult = FFTAICommunicationManager.getInstance().M1TaskInterface.RequestReadFlagInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            // request for task information -------------------------------------------------

            return FunctionResult.SUCCESS;
        }

        private static int CommunicationV2M1RobotStatusPeriodicFunction()
        {
            int functionResult;

            // request for hardware information ---------------------------------------------

            //functionResult = FFTAICommunicationManager.getInstance().FFTAICommunicationV2HardwareInterface.RequestReadGpioIoStatus();

            //if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            //{
            //            FFTAIRobotCommLog.getInstance().WriteLine("Socket Exception, Server is Down.", FFTAIRobotCommLogType.DEBUG);
            //            ServerLinkMonitorCount = 0;
            //            Disconnect(); // the server is down, close socket
            //            return FunctionResult.FAIL;
            //}

            // request for hardware information ---------------------------------------------

            // request for robot information ------------------------------------------------

            functionResult = FFTAICommunicationManager.getInstance().M1RobotInterface.RequestReadJointInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M1RobotInterface.RequestReadEndEffectorInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            // request for robot information ------------------------------------------------

            return FunctionResult.SUCCESS;
        }

        private static int CommunicationV2M1RobotSensorStatusPeriodicFunction()
        {
            int functionResult;

            // request for robot sensor information -----------------------------------------

            functionResult = FFTAICommunicationManager.getInstance().M1RobotInterface.RequestReadButtonSensorAccessible();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M1RobotInterface.RequestReadTorqueSensorAccessible();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M1RobotInterface.RequestReadButtonSensorInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M1RobotInterface.RequestReadTorqueSensorInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M1RobotInterface.RequestReadTorqueSensorRawInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            // request for robot sensor information -----------------------------------------

            return FunctionResult.SUCCESS;
        }

        private static int CommunicationV2M1RobotParameterStatusPeriodicFunction()
        {
            int functionResult;

            // request for robot sensor information -----------------------------------------

            functionResult = FFTAICommunicationManager.getInstance().M1RobotInterface.RequestGetJointLimitKinetic();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M1RobotInterface.RequestGetJointLimitVelocity();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M1RobotInterface.RequestGetJointLimitPosition();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M1RobotInterface.RequestGetEndEffectorLimitKinetic();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M1RobotInterface.RequestGetEndEffectorLimitVelocity();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M1RobotInterface.RequestGetEndEffectorLimitPosition();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            // request for robot sensor information -----------------------------------------

            return FunctionResult.SUCCESS;
        }

        #endregion
        
        #region  Period Function Definition (V2 M1_L)
        private static int CommunicationV2M1_LFlagPeriodicFunction()
        {
            int functionResult;

            // request for robot information ------------------------------------------------

            functionResult = FFTAICommunicationManager.getInstance().M1_LRobotInterface.RequestReadFlagInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M1_LRobotInterface.RequestReadFlagOutOfJointLimitInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M1_LRobotInterface.RequestReadFlagOutOfEndEffectorLimitInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            // request for robot information ------------------------------------------------

            // request for task information -------------------------------------------------

            functionResult = FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestReadFlagInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            // request for task information -------------------------------------------------

            return FunctionResult.SUCCESS;
        }

        private static int CommunicationV2M1_LRobotStatusPeriodicFunction()
        {
            int functionResult;

            // request for hardware information ---------------------------------------------

            //functionResult = FFTAICommunicationManager.getInstance().FFTAICommunicationV2HardwareInterface.RequestReadGpioIoStatus();

            //if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            //{
            //            FFTAIRobotCommLog.getInstance().WriteLine("Socket Exception, Server is Down.", FFTAIRobotCommLogType.DEBUG);
            //            ServerLinkMonitorCount = 0;
            //            Disconnect(); // the server is down, close socket
            //            return FunctionResult.FAIL;
            //}

            // request for hardware information ---------------------------------------------

            // request for robot information ------------------------------------------------

            functionResult = FFTAICommunicationManager.getInstance().M1_LRobotInterface.RequestReadJointInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M1_LRobotInterface.RequestReadEndEffectorInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            // request for robot information ------------------------------------------------

            return FunctionResult.SUCCESS;
        }

        private static int CommunicationV2M1_LRobotSensorStatusPeriodicFunction()
        {
            int functionResult;

            // request for robot sensor information -----------------------------------------

            functionResult = FFTAICommunicationManager.getInstance().M1_LRobotInterface.RequestReadButtonSensorAccessible();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M1_LRobotInterface.RequestReadTorqueSensorAccessible();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M1_LRobotInterface.RequestReadButtonSensorInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M1_LRobotInterface.RequestReadTorqueSensorInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M1_LRobotInterface.RequestReadTorqueSensorRawInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            // request for robot sensor information -----------------------------------------

            return FunctionResult.SUCCESS;
        }

        private static int CommunicationV2M1_LRobotParameterStatusPeriodicFunction()
        {
            int functionResult;

            // request for robot sensor information -----------------------------------------

            functionResult = FFTAICommunicationManager.getInstance().M1_LRobotInterface.RequestGetJointLimitKinetic();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M1_LRobotInterface.RequestGetJointLimitVelocity();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M1_LRobotInterface.RequestGetJointLimitPosition();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M1_LRobotInterface.RequestGetEndEffectorLimitKinetic();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M1_LRobotInterface.RequestGetEndEffectorLimitVelocity();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M1_LRobotInterface.RequestGetEndEffectorLimitPosition();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            // request for robot sensor information -----------------------------------------

            return FunctionResult.SUCCESS;
        }

        #endregion

        #region Period Function Definition (V2 M2)
        private static int CommunicationV2M2FlagPeriodicFunction()
        {
            int functionResult;

            // request for robot information ------------------------------------------------

            functionResult = FFTAICommunicationManager.getInstance().M2RobotInterface.RequestReadFlagCalibration();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M2RobotInterface.RequestReadFlagServoOn();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M2RobotInterface.RequestReadFlagEmergentStop();
           
            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M2RobotInterface.RequestReadEmergentButtonStopValue();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }


            functionResult = FFTAICommunicationManager.getInstance().M2RobotInterface.RequestReadFlagFault();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M2RobotInterface.RequestReadFlagInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M2RobotInterface.RequestReadFlagOutOfJointLimitInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M2RobotInterface.RequestReadFlagOutOfEndEffectorLimitInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M2RobotInterface.RequestReadFlagPinched();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }


            // request for robot information ------------------------------------------------

            // request for task information -------------------------------------------------

            functionResult = FFTAICommunicationManager.getInstance().M2TaskInterface.RequestReadFlagInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }



            // request for task information -------------------------------------------------

            return FunctionResult.SUCCESS;
        }

        private static int CommunicationV2M2RobotStatusPeriodicFunction()
        {
            int functionResult;

            // request for hardware information ---------------------------------------------

            //functionResult = FFTAICommunicationManager.getInstance().FFTAICommunicationV2HardwareInterface.RequestReadGpioIoStatus();

            //if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            //{
            //            FFTAIRobotCommLog.getInstance().WriteLine("Socket Exception, Server is Down.", FFTAIRobotCommLogType.DEBUG);
            //            ServerLinkMonitorCount = 0;
            //            Disconnect(); // the server is down, close socket
            //            return FunctionResult.FAIL;
            //}

            // request for hardware information ---------------------------------------------

            // request for robot information ------------------------------------------------

            functionResult = FFTAICommunicationManager.getInstance().M2RobotInterface.RequestReadJointInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M2RobotInterface.RequestReadEndEffectorInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            // request for robot information ------------------------------------------------

            return FunctionResult.SUCCESS;
        }

        private static int CommunicationV2M2RobotSensorStatusPeriodicFunction()
        {
            int functionResult;

            // request for robot sensor information -----------------------------------------

            functionResult = FFTAICommunicationManager.getInstance().M2RobotInterface.RequestReadButtonSensorAccessible();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M2RobotInterface.RequestReadForceSensorAccessible();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M2RobotInterface.RequestReadButtonSensorInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M2RobotInterface.RequestReadForceSensorInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M2RobotInterface.RequestReadForceSensorRawInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            //functionResult = FFTAICommunicationManager.getInstance().M2RobotInterface.RequestReadLEDStatus();

            //if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            //{
            //    Disconnect(); // the server is down, close socket
            //    return FunctionResult.FAIL;
            //}

            // request for robot sensor information -----------------------------------------

            return FunctionResult.SUCCESS;
        }

        private static int CommunicationV2M2RobotParameterStatusPeriodicFunction()
        {
            int functionResult;

            // request for robot sensor information -----------------------------------------

            functionResult = FFTAICommunicationManager.getInstance().M2RobotInterface.RequestGetJointLimitKinetic();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M2RobotInterface.RequestGetJointLimitVelocity();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M2RobotInterface.RequestGetJointLimitPosition();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M2RobotInterface.RequestGetEndEffectorLimitKinetic();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M2RobotInterface.RequestGetEndEffectorLimitVelocity();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M2RobotInterface.RequestGetEndEffectorLimitPosition();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M2RobotInterface.RequestReadActualManchineRangeOfMotion();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            // request for robot sensor information -----------------------------------------

            return FunctionResult.SUCCESS;
        }

        private static int CommunicationV2M2HardwareStatusPeriodicFunction()
        {
            int functionResult;

            // request for hardware information ------------------------------------------------

            functionResult = FFTAICommunicationManager.getInstance().hardwareInterface.RequestGetGpioIoStatus();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            // request for hardware information ---------------------------------------------

            return FunctionResult.SUCCESS;
        }

        private static int CommunicationV2M3FlagPeriodicFunction()
        {
            int functionResult;

            // request for robot information ------------------------------------------------

            functionResult = FFTAICommunicationManager.getInstance().M3RobotInterface.RequestReadFlagInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M3RobotInterface.RequestReadFlagOutOfJointLimitInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M3RobotInterface.RequestReadFlagOutOfEndEffectorLimitInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            // request for robot information ------------------------------------------------

            // request for task information -------------------------------------------------

            functionResult = FFTAICommunicationManager.getInstance().M3TaskInterface.RequestReadFlagInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            // request for task information -------------------------------------------------

            return FunctionResult.SUCCESS;
        }
        #endregion

        #region Period Function Definition (V2 M3)
        private static int CommunicationV2M3RobotStatusPeriodicFunction()
        {
            int functionResult;

            // request for hardware information ---------------------------------------------

            //functionResult = FFTAICommunicationManager.getInstance().FFTAICommunicationV2HardwareInterface.RequestReadGpioIoStatus();

            //if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            //{
            //            FFTAIRobotCommLog.getInstance().WriteLine("Socket Exception, Server is Down.", FFTAIRobotCommLogType.DEBUG);
            //            ServerLinkMonitorCount = 0;
            //            Disconnect(); // the server is down, close socket
            //            return FunctionResult.FAIL;
            //}

            // request for hardware information ---------------------------------------------

            // request for robot information ------------------------------------------------

            functionResult = FFTAICommunicationManager.getInstance().M3RobotInterface.RequestReadJointInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M3RobotInterface.RequestReadEndEffectorInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            // request for robot information ------------------------------------------------

            return FunctionResult.SUCCESS;
        }

        private static int CommunicationV2M3RobotSensorStatusPeriodicFunction()
        {
            int functionResult;

            // request for robot sensor information -----------------------------------------

            functionResult = FFTAICommunicationManager.getInstance().M3RobotInterface.RequestReadButtonSensorAccessible();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M3RobotInterface.RequestReadForceSensorAccessible();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M3RobotInterface.RequestReadButtonSensorInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M3RobotInterface.RequestReadForceSensorInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M3RobotInterface.RequestReadForceSensorRawInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            // request for robot sensor information -----------------------------------------

            return FunctionResult.SUCCESS;
        }

        private static int CommunicationV2M3RobotParameterStatusPeriodicFunction()
        {
            int functionResult;

            // request for robot sensor information -----------------------------------------

            functionResult = FFTAICommunicationManager.getInstance().M3RobotInterface.RequestGetJointLimitKinetic();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M3RobotInterface.RequestGetJointLimitVelocity();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M3RobotInterface.RequestGetJointLimitPosition();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M3RobotInterface.RequestGetEndEffectorLimitKinetic();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M3RobotInterface.RequestGetEndEffectorLimitVelocity();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M3RobotInterface.RequestGetEndEffectorLimitPosition();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            // request for robot sensor information -----------------------------------------

            return FunctionResult.SUCCESS;
        }

        #endregion

        #region Period Function Definition (V2 X1)
        private static int CommunicationV2X1FlagPeriodicFunction()
        {
            return FunctionResult.SUCCESS;
        }

        private static int CommunicationV2X1RobotStatusPeriodicFunction()
        {
            return FunctionResult.SUCCESS;
        }

        private static int CommunicationV2X1RobotSensorStatusPeriodicFunction()
        {
            return FunctionResult.SUCCESS;
        }

        private static int CommunicationV2X1RobotParameterStatusPeriodicFunction()
        {
            return FunctionResult.SUCCESS;
        }

        #endregion

        #region Period Function Definition (V2 X2)
        private static int CommunicationV2X2FlagPeriodicFunction()
        {
            int functionResult;

            // request for robot information ------------------------------------------------

            functionResult = FFTAICommunicationManager.getInstance().X2RobotInterface.RequestReadFlagInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().X2RobotInterface.RequestReadFlagOutOfJointLimitInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().X2RobotInterface.RequestReadFlagOutOfEndEffectorLimitInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            // request for robot information ------------------------------------------------

            // request for task information -------------------------------------------------

            functionResult = FFTAICommunicationManager.getInstance().X2TaskInterface.RequestReadFlagInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            // request for task information -------------------------------------------------

            return FunctionResult.SUCCESS;
        }

        private static int CommunicationV2X2RobotStatusPeriodicFunction()
        {
            int functionResult;

            // request for hardware information ---------------------------------------------

            //functionResult = FFTAICommunicationManager.getInstance().FFTAICommunicationV2HardwareInterface.RequestReadGpioIoStatus();

            //if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            //{
            //            FFTAIRobotCommLog.getInstance().WriteLine("Socket Exception, Server is Down.", FFTAIRobotCommLogType.DEBUG);
            //            ServerLinkMonitorCount = 0;
            //            Disconnect(); // the server is down, close socket
            //            return FunctionResult.FAIL;
            //}

            // request for hardware information ---------------------------------------------

            // request for robot information ------------------------------------------------

            functionResult = FFTAICommunicationManager.getInstance().X2RobotInterface.RequestReadDriverAccessible();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().X2RobotInterface.RequestReadJointInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().X2RobotInterface.RequestReadEndEffectorInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            // request for robot information ------------------------------------------------

            return FunctionResult.SUCCESS;
        }

        private static int CommunicationV2X2RobotSensorStatusPeriodicFunction()
        {
            int functionResult;

            // request for robot sensor information -----------------------------------------

            functionResult = FFTAICommunicationManager.getInstance().X2RobotInterface.RequestReadButtonSensorAccessible();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().X2RobotInterface.RequestReadForceSensorAccessible();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().X2RobotInterface.RequestReadFootPressureSensorAccessible();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().X2RobotInterface.RequestReadButtonSensorInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().X2RobotInterface.RequestReadForceSensorInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().X2RobotInterface.RequestReadFootPressureSensorInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            // request for robot sensor information -----------------------------------------

            return FunctionResult.SUCCESS;
        }

        private static int CommunicationV2X2RobotParameterStatusPeriodicFunction()
        {
            int functionResult;

            // request for robot sensor information -----------------------------------------

            functionResult = FFTAICommunicationManager.getInstance().X2RobotInterface.RequestGetJointLimitKinetic();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().X2RobotInterface.RequestGetJointLimitVelocity();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().X2RobotInterface.RequestGetJointLimitPosition();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().X2RobotInterface.RequestGetEndEffectorLimitKinetic();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().X2RobotInterface.RequestGetEndEffectorLimitVelocity();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().X2RobotInterface.RequestGetEndEffectorLimitPosition();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            // request for robot sensor information -----------------------------------------

            return FunctionResult.SUCCESS;
        }

        #endregion

        #region Period Function Definition (V2 M6)
        private static int CommunicationV2M6FlagPeriodicFunction()
        {
            int functionResult;

            // request for robot information ------------------------------------------------

            functionResult = FFTAICommunicationManager.getInstance().M6RobotInterface.RequestReadFlagInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M6RobotInterface.RequestReadFlagOutOfJointLimitInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M6RobotInterface.RequestReadFlagOutOfEndEffectorLimitInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            // request for robot information ------------------------------------------------

            // request for task information -------------------------------------------------

            functionResult = FFTAICommunicationManager.getInstance().M6TaskInterface.RequestReadFlagInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            // request for task information -------------------------------------------------

            return FunctionResult.SUCCESS;
        }

        private static int CommunicationV2M6RobotStatusPeriodicFunction()
        {
            int functionResult;

            // request for hardware information ---------------------------------------------

            //functionResult = FFTAICommunicationManager.getInstance().FFTAICommunicationV2HardwareInterface.RequestReadGpioIoStatus();

            //if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            //{
            //            FFTAIRobotCommLog.getInstance().WriteLine("Socket Exception, Server is Down.", FFTAIRobotCommLogType.DEBUG);
            //            ServerLinkMonitorCount = 0;
            //            Disconnect(); // the server is down, close socket
            //            return FunctionResult.FAIL;
            //}

            // request for hardware information ---------------------------------------------

            // request for robot information ------------------------------------------------

            functionResult = FFTAICommunicationManager.getInstance().M6RobotInterface.RequestReadDriverAccessible();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M6RobotInterface.RequestReadJointInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M6RobotInterface.RequestReadEndEffectorInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            // request for robot information ------------------------------------------------

            return FunctionResult.SUCCESS;
        }

        private static int CommunicationV2M6RobotSensorStatusPeriodicFunction()
        {
            int functionResult;

            // request for robot sensor information -----------------------------------------

            functionResult = FFTAICommunicationManager.getInstance().M6RobotInterface.RequestReadButtonSensorAccessible();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M6RobotInterface.RequestReadForceSensorAccessible();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M6RobotInterface.RequestReadFootPressureSensorAccessible();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M6RobotInterface.RequestReadButtonSensorInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M6RobotInterface.RequestReadForceSensorInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M6RobotInterface.RequestReadFootPressureSensorInformation();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            // request for robot sensor information -----------------------------------------

            return FunctionResult.SUCCESS;
        }

        private static int CommunicationV2M6RobotParameterStatusPeriodicFunction()
        {
            int functionResult;

            // request for robot sensor information -----------------------------------------

            functionResult = FFTAICommunicationManager.getInstance().M6RobotInterface.RequestGetJointLimitKinetic();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M6RobotInterface.RequestGetJointLimitVelocity();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M6RobotInterface.RequestGetJointLimitPosition();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M6RobotInterface.RequestGetEndEffectorLimitKinetic();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M6RobotInterface.RequestGetEndEffectorLimitVelocity();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            functionResult = FFTAICommunicationManager.getInstance().M6RobotInterface.RequestGetEndEffectorLimitPosition();

            if (functionResult == FunctionResult.SOCKET_EXCEPTION)
            {
                Disconnect(); // the server is down, close socket
                return FunctionResult.FAIL;
            }

            // request for robot sensor information -----------------------------------------

            return FunctionResult.SUCCESS;
        }

        #endregion
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace FFTAICommunicationLib
{
    public partial class DynaLinkHS
    {
        #region Reset Function
        private static int ResetModelParameters()
        {
            // System
            StatusApp.HardwareVersion = 0;
            StatusApp.SoftwareVersion = 0;
            StatusApp.SerialNumber = 0;
            StatusApp.RobotType = DynaLinkHS.RobotType.NONE;
            StatusApp.MechanismType = DynaLinkHS.MechanismType.NONE;
            StatusApp.MechanismTypeString = null;
            StatusApp.RobotSerialNumber = DynaLinkHS.RobotSerialNumber.NONE;

            // Flag
            StatusFlag.FlagCalibration = 0;
            StatusFlag.FlagEmergentStop = 0;
            StatusFlag.FlagFault = 0;
            StatusFlag.FlagRobotMoving = 0;
            StatusFlag.FlagServerLinkActive = 0;
            StatusFlag.FlagServoOn = 0;
            StatusFlag.FlagTaskInProcess = 0;

            // Motor Error Code
            StatusMotorErrorCode.Motor1 = 0;
            StatusMotorErrorCode.Motor2 = 0;
            StatusMotorErrorCode.Motor3 = 0;
            StatusMotorErrorCode.Motor4 = 0;
            StatusMotorErrorCode.Motor5 = 0;
            StatusMotorErrorCode.Motor6 = 0;

            for (int i = 0; i < RobotDataList.Count; i++)
            {
                Type type = Type.GetType("FFTAICommunicationLib.DynaLinkHS");
                var statusRobot = (Type)type.GetMember("StatusRobot")[0];
                var field = statusRobot.GetField(RobotDataList[i]);
                RobotDataFieldInfoList.Add(field);
            }
            return FunctionResult.SUCCESS;
        }

        public static int StatusRobotUpdateNotification()
        {
            // set flag
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.NONE:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.H4:
                    {
                        if (StatusRobot.VelocityDataJoint1 == 0
                            && StatusRobot.VelocityDataJoint2 == 0
                            && StatusRobot.VelocityDataJoint3 == 0
                            && StatusRobot.VelocityDataJoint4 == 0)
                        {
                            StatusFlag.FlagRobotMoving = 0;
                        }
                        else
                        {
                            StatusFlag.FlagRobotMoving = 1;
                        }

                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        if (StatusRobot.VelocityDataJoint1 == 0)
                        {
                            StatusFlag.FlagRobotMoving = 0;
                        }
                        else
                        {
                            StatusFlag.FlagRobotMoving = 1;
                        }

                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        if (StatusRobot.VelocityDataJoint1 == 0)
                        {
                            StatusFlag.FlagRobotMoving = 0;
                        }
                        else
                        {
                            StatusFlag.FlagRobotMoving = 1;
                        }

                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        if (StatusRobot.VelocityDataJoint1 == 0
                            && StatusRobot.VelocityDataJoint2 == 0)
                        {
                            StatusFlag.FlagRobotMoving = 0;
                        }
                        else
                        {
                            StatusFlag.FlagRobotMoving = 1;
                        }

                        break;
                    }
                case DynaLinkHS.RobotType.M3:
                    {
                        if (StatusRobot.VelocityDataJoint1 == 0
                            && StatusRobot.VelocityDataJoint2 == 0
                            && StatusRobot.VelocityDataJoint3 == 0)
                        {
                            StatusFlag.FlagRobotMoving = 0;
                        }
                        else
                        {
                            StatusFlag.FlagRobotMoving = 1;
                        }

                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        if (StatusRobot.VelocityDataJoint1 == 0
                            && StatusRobot.VelocityDataJoint2 == 0
                            && StatusRobot.VelocityDataJoint3 == 0
                            && StatusRobot.VelocityDataJoint4 == 0)
                        {
                            StatusFlag.FlagRobotMoving = 0;
                        }
                        else
                        {
                            StatusFlag.FlagRobotMoving = 1;
                        }

                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        if (StatusRobot.VelocityDataJoint1 == 0
                          && StatusRobot.VelocityDataJoint2 == 0
                          && StatusRobot.VelocityDataJoint3 == 0
                          && StatusRobot.VelocityDataJoint4 == 0
                          && StatusRobot.VelocityDataJoint5 == 0
                          && StatusRobot.VelocityDataJoint6 == 0)
                        {
                            StatusFlag.FlagRobotMoving = 0;
                        }
                        else
                        {
                            StatusFlag.FlagRobotMoving = 1;
                        }

                        break;
                    }
                case DynaLinkHS.RobotType.All:
                    {
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        #endregion

        #region Simple Function

        /// <summary>
        ///<para>  @brief Connect to the MMU [连接 MMU 服务器]                             </para>
        ///<para>                                                                         </para>
        ///<para>  @return Function result [方法执行结果]                                  </para>
        ///<para>  @retval FunctionResult.SUCCESS SUCCESS [成功]                          </para>
        ///<para>  @retval FunctionResult.FAIL FAIL [失败]                                </para>
        /// </summary>
        /// <returns></returns>
        public static int Connect()
        {
            // print  log message
            Debugs.Log("Connect.", FFTAIRobotCommLogType.DEBUG);

            int functionResult;

            // reset model parameters
            ResetModelParameters();

            FFTAICommunicationManager managerInstance = FFTAICommunicationManager.getInstance();
            // add observer
            managerInstance.networkOperation.AddObserver(managerInstance.networkOperation);

            // connect
            functionResult =
                FFTAICommunicationManager.getInstance().networkOperation.Connect(
                    StatusNetwork.ServerAddressIp,
                    StatusNetwork.ServerAddressPort,
                    NetworkConnectionType.TCP);

            if (functionResult == FunctionResult.SUCCESS)
            {

            }
            else
            {
                // remove observer
                managerInstance.networkOperation.RemoveObserver(managerInstance.networkOperation);

                return FunctionResult.FAIL;
            }

            // add observer
            managerInstance.iapInterface.AddObserver(managerInstance.iapInterface);

            managerInstance.appInterface.AddObserver(managerInstance.appInterface);
            managerInstance.communicationInterface.AddObserver(managerInstance.communicationInterface);
            managerInstance.hardwareInterface.AddObserver(managerInstance.hardwareInterface);
            managerInstance.robotInterface.AddObserver(managerInstance.robotInterface);

            managerInstance.H4RobotInterface.AddObserver(managerInstance.H4RobotInterface);
            managerInstance.H4TaskInterface.AddObserver(managerInstance.H4TaskInterface);

            managerInstance.M1RobotInterface.AddObserver(managerInstance.M1RobotInterface);
            managerInstance.M1TaskInterface.AddObserver(managerInstance.M1TaskInterface);

            managerInstance.M1_LRobotInterface.AddObserver(managerInstance.M1_LRobotInterface);
            managerInstance.M1_LTaskInterface.AddObserver(managerInstance.M1_LTaskInterface);

            managerInstance.M2RobotInterface.AddObserver(managerInstance.M2RobotInterface);
            managerInstance.M2TaskInterface.AddObserver(managerInstance.M2TaskInterface);

            managerInstance.M3RobotInterface.AddObserver(managerInstance.M3RobotInterface);
            managerInstance.M3TaskInterface.AddObserver(managerInstance.M3TaskInterface);

            managerInstance.M6RobotInterface.AddObserver(managerInstance.M6RobotInterface);
            managerInstance.M6TaskInterface.AddObserver(managerInstance.M6TaskInterface);

            managerInstance.X2RobotInterface.AddObserver(managerInstance.X2RobotInterface);
            managerInstance.X2TaskInterface.AddObserver(managerInstance.X2TaskInterface);

            // start periodic sending
            CmdInitPeriodicFunction();

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para> @brief Disconnect to the MMU [断开 MMU 服务器]                                              </para>
        ///<para> @return Function result [方法执行结果]                                                      </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]                                              </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]                                                    </para>
        /// </summary>
        /// <returns></returns>
        public static int Disconnect()
        {
            // print  log message
            Debugs.Log("Disconnect.", FFTAIRobotCommLogType.DEBUG);
            // stop periodic sending
            CmdDeInitPeriodicFunction();
            // reset connect count
            ServerLinkMonitorCount = 0;

            FFTAICommunicationManager managerInstance = FFTAICommunicationManager.getInstance();
            // disconnect

            FFTAICommunicationManager.getInstance().networkOperation.Disconnect();
            // remove observer
            managerInstance.networkOperation.RemoveObserver(managerInstance.networkOperation);

            // remove observer
            managerInstance.iapInterface.RemoveObserver(managerInstance.iapInterface);

            managerInstance.appInterface.RemoveObserver(managerInstance.appInterface);
            managerInstance.communicationInterface.RemoveObserver(managerInstance.communicationInterface);
            managerInstance.hardwareInterface.RemoveObserver(managerInstance.hardwareInterface);
            managerInstance.robotInterface.RemoveObserver(managerInstance.robotInterface);

            managerInstance.H4RobotInterface.RemoveObserver(managerInstance.H4RobotInterface);
            managerInstance.H4TaskInterface.RemoveObserver(managerInstance.H4TaskInterface);

            managerInstance.M1RobotInterface.RemoveObserver(managerInstance.M1RobotInterface);
            managerInstance.M1TaskInterface.RemoveObserver(managerInstance.M1TaskInterface);

            managerInstance.M1_LRobotInterface.RemoveObserver(managerInstance.M1_LRobotInterface);
            managerInstance.M1_LTaskInterface.RemoveObserver(managerInstance.M1_LTaskInterface);

            managerInstance.M2RobotInterface.RemoveObserver(managerInstance.M2RobotInterface);
            managerInstance.M2TaskInterface.RemoveObserver(managerInstance.M2TaskInterface);

            managerInstance.M6RobotInterface.RemoveObserver(managerInstance.M6RobotInterface);
            managerInstance.M6TaskInterface.RemoveObserver(managerInstance.M6TaskInterface);

            managerInstance.M3RobotInterface.RemoveObserver(managerInstance.M3RobotInterface);
            managerInstance.M3TaskInterface.RemoveObserver(managerInstance.M3TaskInterface);

            managerInstance.X2RobotInterface.RemoveObserver(managerInstance.X2RobotInterface);
            managerInstance.X2TaskInterface.RemoveObserver(managerInstance.X2TaskInterface);

            // reset connection flag
            StatusFlag.FlagServerLinkActive = 0x00;

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para> @brief Init periodic function [初始化周期性请求线程方法]                                     </para>
        ///<para>                                                                                            </para>
        ///<para> @return Function result [方法执行结果]                                                      </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]                                              </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]                                                    </para>
        /// </summary>
        /// <returns></returns>
        private static int CmdInitPeriodicFunction()
        {
            if (UpdateTimer == null)
            {

                // clear server monitor count
                ServerLinkMonitorCount = 0;

                // clear all the locker
                IAPTimerLocker = false;
                IAPUpgradeIapLocker = false;
                IAPUpgradeAppLocker = false;
                APPPeriodicFunctionTimerLocker = false;
                FlagPeriodicFunctionTimerLocker = false;
                RobotStatusPeriodicFunctionTimerLocker = false;
                RobotSensorStatusPeriodicFunctionTimerLocker = false;

                // clear active flag
                UpdateTimerActiveFlag = false;

                // create timer
                UpdateTimer =
                    new Timer(UpdateTimerCallback, null, 0, UpdateTimerPeriodTime);

                // sleep to let main thread give time to create children thread.
                while (UpdateTimerActiveFlag == false)
                {
                    Thread.Sleep(10);
                }

            }
            else
            {
                // clear server monitor count
                ServerLinkMonitorCount = 0;

                // clear active flag
                UpdateTimerActiveFlag = false;

                // ceate timer
                UpdateTimer.Change(0, UpdateTimerPeriodTime);
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para> @brief DeInit periodic function [释放周期性请求线程方法]                                     </para>
        ///<para>                                                                                            </para>
        ///<para> @return Function result [方法执行结果]                                                      </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]                                              </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]                                                    </para>
        /// <returns></returns>
        public static int CmdDeInitPeriodicFunction()
        {
            // heart beat
            if (UpdateTimer != null)
            {
                UpdateTimer.Dispose();
            }
            UpdateTimer = null;
            UpdateTimerActiveFlag = false;

            return FunctionResult.SUCCESS;
        }
//-------------------------------------------- Function Definition (Network) ---------------------------------------------------------------------------

        //-------------------------------------------- Function Definition (IAP) -------------------------------------------------------------------------------
        /// <summary>
        ///<para>  @brief Upgrade MMU Iap (bootloader) [更新 MMU Bootloader 程序]                              </para>
        ///<para>                                                                                             </para>
        ///<para>  @param filePath The file path of the bootloader .bin file [.bin 文件的路径]                 </para>
        ///<para>                                                                                             </para>
        ///<para>  @return Function result [方法执行结果]                                                      </para>
        ///<para>  @retval FunctionResult.SUCCESS SUCCESS [成功]                                               </para>
        ///<para>  @retval FunctionResult.FAIL FAIL [失败]                                                     </para>
        /// </summary>                                                                                            
        /// <param name="filePath"></param>                                                                       
        /// <returns></returns>                                                                                   
        public static int UpgradeMMUIap(string filePath)
        {
            // read all the buffer from the file
            FileStream fileStream = new FileStream(filePath.ToString(), FileMode.Open, FileAccess.Read);

            byte[] fileBuffer = new byte[fileStream.Length];

            fileStream.Read(fileBuffer, 0, (int)fileStream.Length);

            UpgradeMMUIap(fileBuffer);

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para> @brief Upgrade MMU Iap (bootloader) [更新 MMU Bootloader 程序]                               </para>
        ///<para>                                                                                             </para>
        ///<para> @param fileBuffer The file buffer of the bootloader .bin file [.bin 文件的数据]              </para>
        ///<para>                                                                                             </para>
        ///<para> @return Function result [方法执行结果]                                                       </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]                                                </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]                                                      </para>
        /// </summary>
        /// <param name="fileBuffer"></param>
        /// <returns></returns>
        public static int UpgradeMMUIap(byte[] fileBuffer)
        {
            // check the upgrade process is locked or not
            if (IAPUpgradeIapLocker == true)
            {
                return FunctionResult.FAIL;
            }

            Thread upgradeMMUIapThread = new Thread(new ParameterizedThreadStart(UpgradeMMUIapFastThreadUsingBuffer));
            upgradeMMUIapThread.Start(fileBuffer);

            // sleep to let main thread give time to create children thread.
            Thread.Sleep(100);

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        /// @brief Upgrade MMU Iap (bootloader) [更新 MMU Bootloader 子线程程序]
        /// </summary>
        /// <param name="inputParameter"></param>
        private static void UpgradeMMUIapFastThreadUsingBuffer(object inputParameter)
        {
            Debugs.Log("UpgradeMMUIapFastThread Start Running ...", FFTAIRobotCommLogType.DEBUG);

            // set locker
            IAPUpgradeIapLocker = true;

            // convert input parameter
            byte[] fileBuffer = (byte[])inputParameter;

            // set status
            StatusIAP.IAPUpgradeIapStatus = DynaLinkHS.IAPUpgradeStatus.READY;

            // open file

            // set progress to 0
            StatusIAP.IAPUpgradeIapProgress = 0;

            // set size
            IAPUpgradeIapSize = (uint)fileBuffer.Length;

            FFTAICommunicationManager.getInstance().iapInterface.RequestSetIAPSize(IAPUpgradeIapSize);

            // erase flash
            FFTAICommunicationManager.getInstance().iapInterface.RequestSetEraseIAP();

            Thread.Sleep((int)IAPUpgradeIapEraseWaitTime); // sleep 20s for flash erase

            // set each message contain byte count
            uint IAPUpgradeIapEachRequestSendByte = FFTAICommunicationIAPInterfacePredefine.UPGRADE_IAP_FAST_AMOUNT;
            int fileData = 0;
            byte[] byteData = new byte[IAPUpgradeIapEachRequestSendByte];

            // clear locker
            IAPUpgradeIapTransmitLocker = false;

            // set status
            StatusIAP.IAPUpgradeIapStatus = DynaLinkHS.IAPUpgradeStatus.RUNNING;

            for (uint i = 0; i < fileBuffer.Length; i = i + IAPUpgradeIapEachRequestSendByte)
            {
                uint j = i;

                while (IAPUpgradeIapTransmitLocker == true)
                {
                    Thread.Sleep(10);

                    IAPUpgradeIapMonitorCount++;

                    if (IAPUpgradeIapMonitorCount > IAPUpgradeIapMonitorMaximumCount)
                    {
                        IAPUpgradeIapMonitorCount = 0;

                        // request resend
                        IAPUpgradeIapResendRequestFlag = true;

                        Debugs.Log("UpgradeMMUIapFastThread End Running (Not Receive Response) ...", FFTAIRobotCommLogType.DEBUG);

                        break;
                    }
                }

                // resend request ?
                if (IAPUpgradeIapResendRequestFlag == true)
                {
                    IAPUpgradeIapResendCount++;

                    if (IAPUpgradeIapResendCount > IAPUpgradeIapResendMaximumCount)
                    {
                        IAPUpgradeIapMonitorCount = 0;

                        IAPUpgradeIapResendCount = 0;

                        // update progress
                        StatusIAP.IAPUpgradeIapProgress = 0;

                        // close file

                        // set status
                        StatusIAP.IAPUpgradeIapStatus = DynaLinkHS.IAPUpgradeStatus.FAIL;

                        // clear locker
                        IAPUpgradeIapLocker = false;

                        Debugs.Log("UpgradeMMUIapFastThread End Running (Resent Exceed Maximum Count) ...", FFTAIRobotCommLogType.DEBUG);

                        return;
                    }

                    i = i - IAPUpgradeIapEachRequestSendByte;

                    IAPUpgradeIapResendRequestFlag = false;
                }
                else
                {
                    IAPUpgradeIapResendCount = 0;

                    // read new data
                    for (uint ii = 0; ii < IAPUpgradeIapEachRequestSendByte; ii++)
                    {
                        if (j < fileBuffer.Length)
                        {
                            fileData = fileBuffer[j];
                        }
                        else
                        {
                            fileData = 0xFF; // when greater the file size, it will return 0xFF
                        }

                        j++;

                        byteData[ii] = (byte)fileData;
                    }
                }

                // send data
                Debugs.Log("UpgradeMMUIapFastThread Running (Send Data) ...", FFTAIRobotCommLogType.DEBUG);

                FFTAICommunicationManager.getInstance().iapInterface.RequestSetUpgradeIAPFast(i, byteData, IAPUpgradeIapEachRequestSendByte);

                IAPUpgradeIapMonitorCount = 0;

                // update progress
                StatusIAP.IAPUpgradeIapProgress = 100 * i / IAPUpgradeIapSize;

                // set locker
                IAPUpgradeIapTransmitLocker = true;
            }

            // close file

            // set status
            StatusIAP.IAPUpgradeIapStatus = DynaLinkHS.IAPUpgradeStatus.SUCCESS;

            // update progress
            StatusIAP.IAPUpgradeIapProgress = 100;

            // clear locker
            IAPUpgradeIapLocker = false;

            Debugs.Log("UpgradeMMUIapFastThread End Running (SUCCESS) ...", FFTAIRobotCommLogType.DEBUG);

            return;
        }

        /// <summary>
        ///<para> @brief Upgrade MMU App (application) [更新 MMU Application 程序]                            </para>
        ///<para>                                                                                            </para>
        ///<para> @param filePath The file path of the application .bin file [.bin 文件的路径]                </para>
        ///<para>                                                                                            </para>
        ///<para> @return Function result [方法执行结果]                                                      </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]                                               </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]                                                     </para>
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static int UpgradeMMUApp(string filePath)
        {
            // read all the buffer from the file
            FileStream fileStream = new FileStream(filePath.ToString(), FileMode.Open, FileAccess.Read);

            byte[] fileBuffer = new byte[fileStream.Length];

            fileStream.Read(fileBuffer, 0, (int)fileStream.Length);

            UpgradeMMUApp(fileBuffer);

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para> @brief Upgrade MMU App (application) [更新 MMU Application 程序]                           </para>
        ///<para>                                                                                            </para>
        ///<para> @param fileBuffer The file buffer of the application .bin file [.bin 文件的数据]            </para>
        ///<para>                                                                                            </para>
        ///<para> @return Function result [方法执行结果]                                                      </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]                                              </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]                                                    </para>
        /// </summary>
        /// <param name="fileBuffer"></param>
        /// <returns></returns>
        public static int UpgradeMMUApp(byte[] fileBuffer)
        {
            // check the upgrade process is locked or not
            if (IAPUpgradeAppLocker == true)
            {
                return FunctionResult.FAIL;
            }

            Thread upgradeMMUAppThread = new Thread(new ParameterizedThreadStart(UpgradeMMUAppFastThreadUsingBuffer));
            upgradeMMUAppThread.Start(fileBuffer);

            // sleep to let main thread give time to create children thread.
            Thread.Sleep(100);

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        /// @brief Upgrade MMU App (application) [更新 MMU Application 子线程程序]
        /// </summary>
        /// <param name="inputParameter"></param>
        private static void UpgradeMMUAppFastThreadUsingBuffer(object inputParameter)
        {
            Debugs.Log("UpgradeMMUAppFastThread Start Running ...", FFTAIRobotCommLogType.DEBUG);

            // set locker
            IAPUpgradeAppLocker = true;

            // convert input parameter
            byte[] fileBuffer = (byte[])inputParameter;

            // set status
            StatusIAP.IAPUpgradeAppStatus = DynaLinkHS.IAPUpgradeStatus.READY;

            // open file

            // set progress to 0
            StatusIAP.IAPUpgradeAppProgress = 0;

            // set size
            IAPUpgradeAppSize = (uint)fileBuffer.Length;

            FFTAICommunicationManager.getInstance().iapInterface.RequestSetAPPSize(IAPUpgradeAppSize);

            // erase flash
            FFTAICommunicationManager.getInstance().iapInterface.RequestSetEraseAPP();

            Thread.Sleep((int)IAPUpgradeAppEraseWaitTime); // sleep 20s for flash erase

            // set each message contain byte count
            uint IAPUpgradeAppEachRequestSendByte = FFTAICommunicationIAPInterfacePredefine.UPGRADE_APP_FAST_AMOUNT;
            int fileData = 0;
            byte[] byteData = new byte[IAPUpgradeAppEachRequestSendByte];

            // clear locker
            IAPUpgradeAppTransmitLocker = false;

            // set status
            StatusIAP.IAPUpgradeAppStatus = DynaLinkHS.IAPUpgradeStatus.RUNNING;

            for (uint i = 0; i < fileBuffer.Length; i = i + IAPUpgradeAppEachRequestSendByte)
            {
                uint j = i;

                while (IAPUpgradeAppTransmitLocker == true)
                {
                    Thread.Sleep(10);

                    IAPUpgradeAppMonitorCount++;

                    if (IAPUpgradeAppMonitorCount > IAPUpgradeAppMonitorMaximumCount)
                    {
                        IAPUpgradeAppMonitorCount = 0;

                        // request resend
                        IAPUpgradeAppResendRequestFlag = true;

                        Debugs.Log("UpgradeMMUAppFastThread End Running (Not Receive Response) ...", FFTAIRobotCommLogType.DEBUG);

                        break;
                    }
                }

                // resend request ?
                if (IAPUpgradeAppResendRequestFlag == true)
                {
                    IAPUpgradeAppResendCount++;

                    if (IAPUpgradeAppResendCount > IAPUpgradeAppResendMaximumCount)
                    {
                        IAPUpgradeAppMonitorCount = 0;

                        IAPUpgradeAppResendCount = 0;

                        // update progress
                        StatusIAP.IAPUpgradeAppProgress = 0;

                        // close file

                        // set status
                        StatusIAP.IAPUpgradeAppStatus = DynaLinkHS.IAPUpgradeStatus.FAIL;

                        // clear locker
                        IAPUpgradeAppLocker = false;

                        Debugs.Log("UpgradeMMUAppFastThread End Running (Resent Exceed Maximum Count) ...", FFTAIRobotCommLogType.DEBUG);

                        return;
                    }

                    i = i - IAPUpgradeAppEachRequestSendByte;

                    // clear resend flag
                    IAPUpgradeAppResendRequestFlag = false;
                }
                else
                {
                    IAPUpgradeAppResendCount = 0;

                    // read new data
                    for (uint ii = 0; ii < IAPUpgradeAppEachRequestSendByte; ii++)
                    {
                        if (j < fileBuffer.Length)
                        {
                            fileData = fileBuffer[j];
                        }
                        else
                        {
                            fileData = 0xFF; // when greater the file size, it will return 0xFF
                        }

                        j++;

                        byteData[ii] = (byte)fileData;
                    }
                }

                // send data
                Debugs.Log("UpgradeMMUAppFastThread Running (Send Data) ...", FFTAIRobotCommLogType.DEBUG);

                FFTAICommunicationManager.getInstance().iapInterface.RequestSetUpgradeAPPFast(i, byteData, IAPUpgradeAppEachRequestSendByte);

                IAPUpgradeAppMonitorCount = 0;

                // update progress
                StatusIAP.IAPUpgradeAppProgress = 100 * i / IAPUpgradeAppSize;

                // set locker
                IAPUpgradeAppTransmitLocker = true;
            }

            // close file

            // set status
            StatusIAP.IAPUpgradeAppStatus = DynaLinkHS.IAPUpgradeStatus.SUCCESS;

            // update progress
            StatusIAP.IAPUpgradeAppProgress = 100;

            // clear locker
            IAPUpgradeAppLocker = false;

            Debugs.Log("UpgradeMMUAppFastThread End Running (SUCCESS) ...", FFTAIRobotCommLogType.DEBUG);

            return;
        }

        /// <summary>
        ///<para> @brief Set MMU boot mode [设置 MMU Boot 模式]                                             </para>
        ///<para>                                                                                          </para>
        ///<para> @param The boot mode to be set to the MMU [Boot 模式]                                     </para>
        ///<para>                                                                                          </para>
        ///<para> @return Function result [方法执行结果]                                                    </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]                                             </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]                                                   </para>
        /// </summary>                                                                                    
        /// <param name="bootMode"></param>
        /// <returns></returns>
        public static int CmdSetBootMode(
            DynaLinkHS.IAPBootMode bootMode)
        {
           return  FFTAICommunicationManager.getInstance().iapInterface.RequestSetBootMode((uint)bootMode);
        }

        /// <summary>
        ///<para>  @brief Erase IAP [删除 IAP 程序]                                                       </para>
        ///<para>                                                                                        </para>
        ///<para>  @return Function result [方法执行结果]                                                 </para>
        ///<para>  @retval FunctionResult.SUCCESS SUCCESS [成功]                                          </para>
        ///<para>  @retval FunctionResult.FAIL FAIL [失败]                                                </para>
        /// </summary>
        /// <returns></returns>
        public static int CmdEraseIap()
        {
            return FFTAICommunicationManager.getInstance().iapInterface.RequestSetEraseIAP();
        }

        /// <summary>
        /// <para> @brief Erase APP [删除 APP 程序]                                                       </para>
        /// <para>                                                                                       </para>
        /// <para> @return Function result [方法执行结果]                                                 </para>
        /// <para> @retval FunctionResult.SUCCESS SUCCESS [成功]                                          </para>
        /// <para> @retval FunctionResult.FAIL FAIL [失败]                                                </para>
        /// </summary>
        /// <returns></returns>
        public static int CmdEraseApp()
        {
            return FFTAICommunicationManager.getInstance().iapInterface.RequestSetEraseAPP();
        }

        //-------------------------------------------- Function Definition (IAP) -------------------------------------------------------------------------------

        //-------------------------------------------- Function Definition (V1) --------------------------------------------------------------------------------

        //-------------------------------------------- Function Definition (V1) --------------------------------------------------------------------------------

        //-------------------------------------------- Function Definition (V2) --------------------------------------------------------------------------------

        //-------------------------------------------- Function Definition (V2 - System) -----------------------------------------------------------------------

        /// <summary>
        ///<para> @brief Set robot type [设置机器人类型]                                                                                                   </para>
        ///<para> @details Set the robot model calculated in the MMU, after set, must reboot the MMU [设置 MMu 的机器人类型，设置完成后，必须重启机器]        </para>
        ///<para>                                                                                                                                         </para>
        ///<para> @param robotType The robot type [机器人类型]                                                                                             </para>
        ///<para>                                                                                                                                         </para>
        ///<para> @return Function result [方法执行结果]                                                                                                   </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]                                                                                           </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]                                                                                                 </para>
        /// </summary>
        /// <param name="robotType"></param>
        /// <returns></returns>
        public static int CmdSetRobotType(
            DynaLinkHS.RobotType robotType)
        {
            return FFTAICommunicationManager.getInstance().appInterface.RequestSetRobotType((uint)robotType);
        }

        /// <summary>
        ///<para> @brief Set mechanism type [设置机械类型]                                                                                                </para>
        ///<para> @details Set the mechanism type in the MMU, after set, must reboot the MMU [设置 MMu 的机械类型，设置完成后，必须重启机器]                 </para>
        ///<para>                                                                                                                                        </para>
        ///<para> @param mechanism The robot mechanism version [机械类型]                                                                                 </para>
        ///<para>                                                                                                                                        </para>
        ///<para> @return Function result [方法执行结果]                                                                                                  </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]                                                                                          </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]                                                                                                </para>
        /// </summary>
        /// <param name="mechanismType"></param>
        /// <returns></returns>
        public static int CmdSetMechanismType(
            DynaLinkHS.MechanismType mechanismType)
        {
            int result = FFTAICommunicationManager.getInstance().appInterface.RequestSetMechanismVersion((uint)mechanismType);
            if (result== FunctionResult.SUCCESS)
            {
                // set mechanism number, request to set robot serial number to zero (not need)
                return FFTAICommunicationManager.getInstance().appInterface.RequestSetRobotSerialNumber((ulong)DynaLinkHS.RobotSerialNumber.NONE);
            }
            else
            {
                return FunctionResult.FAIL;
            }

        }

        /// <summary>
        ///<para>  @brief Set robot type [设置机器人 Serial Number]                                                                                       </para>
        ///<para>  @details Set the robot model calculated in the MMU, after set, must reboot the MMU [设置 MMu 的机器人类型，设置完成后，必须重启机器]      </para>
        ///<para>                                                                                                                                        </para>
        ///<para>  @param robotSerialNumber The robot serial number [机器人类型序列号]                                                                     </para>
        ///<para>                                                                                                                                        </para>
        ///<para>  @return Function result [方法执行结果]                                                                                                 </para>
        ///<para>  @retval FunctionResult.SUCCESS SUCCESS [成功]                                                                                         </para>
        ///<para>  @retval FunctionResult.FAIL FAIL [失败]                                                                                               </para>
        /// </summary>
        /// <param name="robotSerialNumber"></param>
        /// <returns></returns>
        public static int CmdSetRobotSerialNumber(
            DynaLinkHS.RobotSerialNumber robotSerialNumber)
        {
            int result = FFTAICommunicationManager.getInstance().appInterface.RequestSetRobotSerialNumber((ulong)robotSerialNumber);
            if (result == FunctionResult.SUCCESS)
            {
                // set robot serial number, request to set mechanism number to zero
                return FFTAICommunicationManager.getInstance().appInterface.RequestSetMechanismVersion((uint)DynaLinkHS.MechanismType.NONE);
            }
           else
            {
                return FunctionResult.FAIL;
            }
        }
        //-------------------------------------------- Function Definition (V2 - System) -----------------------------------------------------------------------

        //-------------------------------------------- Function Definition (V2 - Basic) ------------------------------------------------------------------------

        /// <summary>
        ///<para> @brief Set MMU work mode [设置 MMU 工作模式]                                                                                                             </para>
        ///<para> @details There are several work modes set in the MMU, the Unity use Relay mode as default. [在底层存在多种工作模式，Unity 默认使用 Relay 工作模式即可]      </para>
        ///<para>                                                                                                                                                         </para>
        ///<para> @param workMode The work mode of MMU [MMU 工作模式]                                                                                                     </para>
        ///<para>                                                                                                                                                         </para>
        ///<para> @return Function result [方法执行结果]                                                                                                                   </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]                                                                                                           </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]                                                                                                                 </para>
        /// </summary>
        /// <param name="workMode"></param>
        /// <returns></returns>
        public static int CmdSetWorkMode(
            DynaLinkHS.WorkMode workMode)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetWorkMode(
                            (int)workMode);

                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetWorkMode(
                            (int)workMode);

                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetWorkMode(
                            (int)workMode);

                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetWorkMode(
                            (int)workMode);

                        break;
                    }
                case DynaLinkHS.RobotType.M3:
                    {
                        FFTAICommunicationManager.getInstance().M3TaskInterface.RequestSetWorkMode(
                            (int)workMode);

                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetWorkMode(
                            (int)workMode);

                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        FFTAICommunicationManager.getInstance().X1TaskInterface.RequestSetWorkMode(
                            (int)workMode);

                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetWorkMode(
                            (int)workMode);

                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }
        
        //-------------------------------------------- Function Definition (V2 - Basic) ------------------------------------------------------------------------

        //-------------------------------------------- Function Definition (V2 - Hardware) ---------------------------------------------------------------------

        /// <summary>
        ///<para> @brief Set digit output of the circuit board [设置数字端口输出]     </para>
        ///<para>                                                                    </para>
        ///<para> @note Not used right now [暂未使用]                                </para>
        ///<para>                                                                    </para>
        ///<para> @return Function result [方法执行结果]                              </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]                      </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]                            </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdSetDigitOutput(
            params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                case DynaLinkHS.RobotType.M1:
                case DynaLinkHS.RobotType.M1_L:
                case DynaLinkHS.RobotType.M2:
                case DynaLinkHS.RobotType.M3:
                case DynaLinkHS.RobotType.X1:
                case DynaLinkHS.RobotType.X2:
                    {
                        if (parameters.Length != 4)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().hardwareInterface.RequestSetGpioIoStatus(
                            (uint)parameters[0], (uint)parameters[1], (uint)parameters[2], (uint)parameters[3]);

                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        ///// <summary>
        /////<para> @brief Set led color [设置Led灯的状态]     </para>
        /////<para>                                                                  </para>
        /////<para> @retval 1 close [关闭][LEDColor.Off]    </para>
        /////<para> @retval 2 blue [蓝色][LEDColor.Blue]    </para>
        /////<para> @retval 3 pink [粉色][LEDColor.Pink]    </para>
        /////<para> @retval 4 green [绿色][LEDColor.Green]   </para>
        /////<para> @retval 5 white [白色][LEDColor.White]   </para>
        ///// </summary>
        ///// <param name="parameters"></param>
        ///// <returns></returns>
        //public static int CmdSetLEDColor(LEDColor ledColor)
        //{
        //    switch (DynaLinkHS.StatusApp.RobotType)
        //    {
        //        case DynaLinkHS.RobotType.M2:
        //            {
        //                int result = FFTAICommunicationManager.getInstance().M2RobotInterface.RequestSetLEDStatus((uint)ledColor);
        //                break;
        //            }
        //        default:
        //            {
        //                return FunctionResult.FAIL;
        //            }
        //    }
        //    return FunctionResult.SUCCESS;
        //}

        /// <summary>
        ///<para> @brief Set led color [设置Led灯的状态]     </para>
        ///<para>                                                                  </para>
        ///<para> @retval LEDColor.Off     [关闭]    </para>
        ///<para> @retval LEDColor.White   [白色]    </para>
        ///<para> @retval LEDColor.Cyan    [青色]    </para>
        ///<para> @retval LEDColor.Yellow  [黄色]    </para>
        ///<para> @retval LEDColor.Magenta [品红]    </para>
        ///<para> @retval LEDColor.Red     [红色]    </para>
        ///<para> @retval LEDColor.Green   [绿色]    </para>
        ///<para> @retval LEDColor.Blue    [蓝色]    </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdSetLEDColor(LEDColor ledColor)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.M2:
                    {
                        int result = FFTAICommunicationManager.getInstance().M2RobotInterface.RequestSetBreatheLEDStatus((int)LEDCMD.SingleColorMode, (int)ledColor);
                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }
            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para> @brief Set led any color  [设置Led灯的任意颜色，通过rgb三个数值来设定]     </para>
        ///<para> @retval r: R channel in color [颜色中的r通道,范围0-255之间]  </para>
        ///<para> @retval g: G channel in color [颜色中的g通道,范围0-255之间]  </para>
        ///<para> @retval b: B channel in color [颜色中的b通道,范围0-255之间]  </para>
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int CmdSetLEDAnyColor(int r,int g,int b)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.M2:
                    {
                        return FFTAICommunicationManager.getInstance().M2RobotInterface.RequestSetBreatheLEDStatus((int)LEDCMD.RGBColorMode, r, g, b);
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }
        }

        /// <summary>
        ///<para> @brief Breathing light with seven colors of LED lights  [设置Led灯七种颜色循环的呼吸灯]     </para>
        ///<para> @retval time: he time of each breathing light[每种颜色呼吸灯的显示时间]  </para>
        /// </summary>
        /// <returns></returns>
        public static int CmdSetLEDMultipleBreatheColor(int time)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.M2:
                    {
                        return FFTAICommunicationManager.getInstance().M2RobotInterface.RequestSetBreatheLEDStatus((int)LEDCMD.MultipleBreatheColorMode, time);
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }
        }

        /// <summary>
        ///<para> @brief Set Led light single color breathing light  [设置Led灯单一颜色的呼吸灯]     </para>
        ///<para> @retval time: the time of  breathing light[呼吸灯的显示时间]  </para>
        /// </summary>
        /// <returns></returns>
        public static int CmdSetLEDSingleBreatheColor(LEDColor ledColor,int time=4)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.M2:
                    {
                        return FFTAICommunicationManager.getInstance().M2RobotInterface.RequestSetBreatheLEDStatus((int)LEDCMD.SingleBreatheColorMode,(int)ledColor, time);
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }
        }

        /// <summary>
        ///<para> @brief Set seven colors of LED lights to cycle through the gradient glow  [设置Led灯七种颜色循环的渐变发光]     </para>
        ///<para> @retval time: the time of gradient glow[呼吸灯的显示时间]  </para>
        /// </summary>
        /// <returns></returns>
        public static int CmdSetLEDMultipleGradientColor(int time=4)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.M2:
                    {
                        return FFTAICommunicationManager.getInstance().M2RobotInterface.RequestSetBreatheLEDStatus((int)LEDCMD.MultipleGradientColorMode, time);
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }
        }

        /// <summary>
        ///<para> @brief Set led close [设置Led灯关闭]     </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdSetLEDClose()
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.M2:
                    {
                        return FFTAICommunicationManager.getInstance().M2RobotInterface.RequestSetBreatheLEDStatus((int)LEDCMD.Close);
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }
        }
        #endregion

        #region Difficult Function

        /// <summary>
        /// <para> @brief Set joint kinetic limit [设置关节力/力矩限制]                                                                      </para>
        /// <para>                                                                                                                          </para>
        /// <para> @details                                                                                                                 </para>
        /// <para> for M1, the parameters are                                                                                               </para>
        /// <para>     - end effector minimum kinetic [关节最小力矩限制] (type : float, unit : Nm, range : < 0)                              </para>
        /// <para>     - end effector maximum kinetic [关节最大力矩限制] (type : float, unit : Nm, range : > 0)                              </para>
        /// <para>                                                                                                                          </para>
        /// <para> for M2, the parameters are                                                                                               </para>
        /// <para>     - end effector horizontal minimum kinetic [x 轴方向关节最小力限制] (type : float, unit : N, range : < 0)              </para>
        /// <para>     - end effector horizontal maximum kinetic [x 轴方向关节最大力限制] (type : float, unit : N, range : > 0)              </para>
        /// <para>     - end effector vertical minimum kinetic [y 轴方向关节最小力限制] (type : float, unit : N, range : < 0)                </para>
        /// <para>     - end effector vertical maximum kinetic [y 轴方向关节最大力限制] (type : float, unit : N, range : > 0)                </para>
        /// <para>                                                                                                                          </para>
        /// <para> @return Function result [方法执行结果]                                                                                    </para>
        /// <para> @retval FunctionResult.SUCCESS SUCCESS [成功]                                                                            </para>
        /// <para> @retval FunctionResult.FAIL FAIL [失败]                                                                                  </para> 
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdSetJointLimitKinetic(
            params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        if (parameters.Length != 2)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1RobotInterface.RequestSetJointLimitKinetic(
                            parameters[0], parameters[1]);

                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        if (parameters.Length != 2)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1_LRobotInterface.RequestSetJointLimitKinetic(
                            parameters[0], parameters[1]);

                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        if (parameters.Length != 4)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M2RobotInterface.RequestSetJointLimitKinetic(
                            parameters[0], parameters[1], parameters[2], parameters[3]);

                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        /// <para> @brief Set end effector kinetic limit [设置末端力/力矩限制]                                                             </para>
        /// <para>                                                                                                                       </para>
        /// <para> @details                                                                                                              </para>
        /// <para> for M1, the parameters are                                                                                            </para>
        /// <para>     - end effector minimum kinetic [最小力矩限制] (type : float, unit : N, range : < 0)                                </para>
        /// <para>     - end effector maximum kinetic [最大力矩限制] (type : float, unit : N, range : > 0)                                </para>
        /// <para>                                                                                                                       </para>
        /// <para> for M2, the parameters are                                                                                            </para>
        /// <para>     - end effector horizontal minimum kinetic [x 轴方向最小力限制] (type : float, unit : N, range : < 0)                </para>
        /// <para>     - end effector horizontal maximum kinetic [x 轴方向最大力限制] (type : float, unit : N, range : > 0)                </para>
        /// <para>     - end effector vertical minimum kinetic [y 轴方向最小力限制] (type : float, unit : N, range : < 0)                  </para>
        /// <para>     - end effector vertical maximum kinetic [y 轴方向最大力限制] (type : float, unit : N, range : > 0)                  </para>
        /// <para>                                                                                                                       </para>
        /// <para> @return Function result [方法执行结果]                                                                                 </para>
        /// <para> @retval FunctionResult.SUCCESS SUCCESS [成功]                                                                          </para>
        /// <para> @retval FunctionResult.FAIL FAIL [失败]                                                                                </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdSetEndEffectorLimitKinetic(
            params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        if (parameters.Length != 2)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1RobotInterface.RequestSetEndEffectorLimitKinetic(
                            parameters[0], parameters[1]);

                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        if (parameters.Length != 2)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1_LRobotInterface.RequestSetEndEffectorLimitKinetic(
                            parameters[0], parameters[1]);

                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        if (parameters.Length != 4)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M2RobotInterface.RequestSetEndEffectorLimitKinetic(
                            parameters[0], parameters[1], parameters[2], parameters[3]);

                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para> @brief Set end effector position limit [机器人末端位置限制]                                                                                  </para>
        ///<para>       </para>
        ///<para> @details              </para>
        ///<para> for M1, the parameters are           </para>
        ///<para>     - end effector minimum position [最小位置限制] (type : float, unit : deg, range : )                                                      </para>
        ///<para>     - end effector maximum position [最大位置限制] (type : float, unit : deg, range : )                                                      </para>
        ///<para>                                                                                                                                             </para>
        ///<para> for M2, the parameters are                                                                                                                  </para>
        ///<para>     - end effector horizontal minimum position [x 轴最小位置限制] (type : float, unit : N, range : )                                         </para>
        ///<para>     - end effector horizontal maximum position [x 轴最大位置限制] (type : float, unit : N, range : )                                         </para>
        ///<para>     - end effector vertical minimum position [y 轴最小位置限制] (type : float, unit : N, range : )                                           </para>
        ///<para>     - end effector vertical maximum position [y 轴最大位置限制] (type : float, unit : N, range : )                                           </para>
        ///<para>                                                                                                                                             </para>
        ///<para> @return Function result [方法执行结果]                                                                                                       </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]                                                                                              </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]                                                                                                     </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdSetEndEffectorLimitPosition(
            params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        if (parameters.Length != 2)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1RobotInterface.RequestSetEndEffectorLimitPosition(
                            parameters[0], parameters[1]);

                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        if (parameters.Length != 2)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1_LRobotInterface.RequestSetEndEffectorLimitPosition(
                            parameters[0], parameters[1]);

                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        if (parameters.Length != 4)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M2RobotInterface.RequestSetEndEffectorLimitPosition(
                            parameters[0], parameters[1], parameters[2], parameters[3]);

                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para> @brief Set current position as the end effector position limit [设置当前位置为机器人位置限制]                            </para>
        ///<para>                                                                                                                       </para>
        ///<para> @details                                                                                                              </para>
        ///<para> for M1, the parameters are                                                                                            </para>
        ///<para>     - end effector minimum position flag [末端最小位置设置标志] (type : float, unit : , range : 0 or 1)                 </para>
        ///<para>     - end effector maximum position flag [末端最大位置设置标志] (type : float, unit : , range : 0 or 1)                 </para>
        ///<para>                                                                                                                       </para>
        ///<para> for M2, the parameters are                                                                                            </para>
        ///<para>     - end effector horizontal minimum position flag [末端 x 轴最小位置设置标志] (type : float, unit : , range : 0 or 1) </para>
        ///<para>     - end effector horizontal maximum position flag [末端 x 轴最大位置设置标志] (type : float, unit : , range : 0 or 1) </para>
        ///<para>     - end effector vertical minimum position flag [末端 y 轴最小位置设置标志] (type : float, unit : , range : 0 or 1)   </para>
        ///<para>     - end effector vertical maximum position flag [末端 y 轴最大位置设置标志] (type : float, unit : , range : 0 or 1)   </para>
        ///<para>                                                                                                                       </para>
        ///<para> @return Function result [方法执行结果]                                                                                  </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]                                                                          </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]                                                                                </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdSetCurrentPositionAsEndEffectorLimitPosition(
            params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        if (parameters.Length != 2)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1RobotInterface.RequestSetCurrentValueAsEndEffectorLimitPosition(
                            (uint)parameters[0], (uint)parameters[1]);

                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        if (parameters.Length != 2)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1_LRobotInterface.RequestSetCurrentValueAsEndEffectorLimitPosition(
                            (uint)parameters[0], (uint)parameters[1]);

                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        if (parameters.Length != 4)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M2RobotInterface.RequestSetCurrentValueAsEndEffectorLimitPosition(
                            (uint)parameters[0], (uint)parameters[1], (uint)parameters[2], (uint)parameters[3]);

                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        //-------------------------------------------- Function Definition (V2 - Protection) -------------------------------------------------------------------

        //-------------------------------------------- Function Definition (V2 - Robot Control) ----------------------------------------------------------------

        /// <summary>
        ///<para> @brief Set joint kinetic control [设置机器关节力/力矩控制]                                                               </para>
        ///<para>                                                                                                                        </para>
        ///<para> @details                                                                                                               </para>
        ///<para> for M1, the parameters are                                                                                             </para>
        ///<para>     - joint kinetic [关节 力矩] (type : float, unit : deg, range : )                                                    </para>
        ///<para>                                                                                                                        </para>
        ///<para> for M2, the parameters are                                                                                             </para>
        ///<para>     - horizontal joint kinetic [横向关节 力] (type : float, unit : m, range : )                                         </para>
        ///<para>     - vertical joint kinetic [纵向关节 力] (type : float, unit : m, range : )                                           </para>
        ///<para>                                                                                                                        </para>
        ///<para> for X2, the parameters are                                                                                             </para>
        ///<para>     - left leg hip joint kinetic [左腿髋关节 力矩] (type : float, unit : m, range : )                                   </para>
        ///<para>     - left leg knee joint kinetic [左腿膝关节 力矩] (type : float, unit : m, range : )                                  </para>
        ///<para>     - right leg hip joint kinetic [右腿髋关节 力矩] (type : float, unit : m, range : )                                  </para>
        ///<para>     - right leg knee joint kinetic [左腿膝关节 力矩] (type : float, unit : m, range : )                                 </para>
        ///<para> for M6, the parameters are                                                                                             </para>
        ///<para>     - left leg hip joint kinetic [左腿髋关节 力矩] (type : float, unit : m, range : )                                   </para>
        ///<para>     - left leg knee joint kinetic [左腿膝关节 力矩] (type : float, unit : m, range : )                                  </para>
        ///<para>     - left leg Ankle joint kinetic [左腿踝关节 力矩] (type : float, unit : m, range : )                                 </para>
        ///<para>     - right leg hip joint kinetic [右腿髋关节 力矩] (type : float, unit : m, range : )                                  </para>
        ///<para>     - right leg knee joint kinetic [左腿膝关节 力矩] (type : float, unit : m, range : )                                 </para>
        ///<para>     - right leg Ankle joint kinetic [左腿踝关节 力矩] (type : float, unit : m, range : )                                </para>
        ///<para>                                                                                                                        </para>
        ///<para> @return Function result [方法执行结果]                                                                                   </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]                                                                           </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]                                                                                 </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdJointKineticControl(
            params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        if (parameters.Length != 4)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetSubtaskBasicJointKineticControlKinetic(
                            parameters[0], parameters[1], parameters[2], parameters[3]);

                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationH4TaskInterfaceWorkMode.JOINT_KINETIC_CONTROL);

                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        if (parameters.Length != 1)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicJointKineticControlKinetic(
                            parameters[0]);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1TaskInterfaceWorkMode.DEBUG);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetDebugWorkMode(
                            FFTAICommunicationM1TaskInterfaceDebugWorkMode.JOINT_KINETIC_CONTROL);

                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        if (parameters.Length != 1)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetSubtaskBasicJointKineticControlKinetic(
                            parameters[0]);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceWorkMode.DEBUG);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetDebugWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceDebugWorkMode.JOINT_KINETIC_CONTROL);

                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        if (parameters.Length != 2)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicJointKineticControlKinetic(
                            parameters[0], parameters[1]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM2TaskInterfaceWorkMode.DEBUG);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetDebugWorkMode(
                            FFTAICommunicationM2TaskInterfaceDebugWorkMode.JOINT_KINETIC_CONTROL);

                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        if (parameters.Length != 6)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetSubtaskBasicJointKineticControlKinetic(
                            parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], parameters[5]);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM6TaskInterfaceWorkMode.DEBUG);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetDebugWorkMode(
                            FFTAICommunicationM6TaskInterfaceDebugWorkMode.JOINT_KINETIC_CONTROL);

                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        if (parameters.Length != 4)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetSubtaskBasicJointKineticControlKinetic(
                            parameters[0], parameters[1], parameters[2], parameters[3]);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationX2TaskInterfaceWorkMode.DEBUG);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetDebugWorkMode(
                            FFTAICommunicationX2TaskInterfaceDebugWorkMode.JOINT_KINETIC_CONTROL);

                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para> @brief Set joint velocity control [设置机器关节速度控制]                                                                </para>
        ///<para>                                                                                                                       </para>
        ///<para> @details                                                                                                              </para>
        ///<para> for M1, the parameters are                                                                                            </para>
        ///<para>     - joint acceleration [关节 加速度] (type : float, unit : deg, range : )                                            </para>
        ///<para>     - joint velocity [关节 速度] (type : float, unit : deg, range : )                                                  </para>
        ///<para>                                                                                                                       </para>
        ///<para> for M2, the parameters are                                                                                            </para>
        ///<para>     - horizontal joint acceleration [横向关节 加速度] (type : float, unit : m/s2, range : )                            </para>
        ///<para>     - vertical joint acceleration [纵向关节 加速度] (type : float, unit : m/s2, range : )                              </para>
        ///<para>     - horizontal joint velocity [横向关节 速度] (type : float, unit : m/s, range : )                                   </para>
        ///<para>     - vertical joint velocity [纵向关节 速度] (type : float, unit : m/s, range : )                                     </para>
        ///<para>                                                                                                                       </para>
        ///<para> for M6, the parameters are                                                                                            </para>
        ///<para>     - left leg hip joint acceleration [左腿髋关节 加速度] (type : float, unit : m, range : )                            </para>
        ///<para>     - left leg knee joint acceleration [左腿膝关节 加速度] (type : float, unit : m, range : )                           </para>
        ///<para>     - left leg Ankle joint acceleration [左腿踝关节 加速度] (type : float, unit : m, range : )                          </para>
        ///<para>     - right leg hip joint acceleration [右腿髋关节 加速度] (type : float, unit : m, range : )                           </para>
        ///<para>     - right leg knee joint acceleration [左腿膝关节 加速度] (type : float, unit : m, range : )                          </para>
        ///<para>     - right leg Ankle joint acceleration [左腿踝关节 加速度] (type : float, unit : m, range : )                         </para>
        ///<para>     - left leg hip joint velocity [左腿髋关节 速度] (type : float, unit : m, range : )                                 </para>
        ///<para>     - left leg knee joint velocity [左腿膝关节 速度] (type : float, unit : m, range : )                                </para>
        ///<para>     - left leg Ankle joint velocity [左腿踝关节 速度] (type : float, unit : m, range : )                               </para>
        ///<para>     - right leg hip joint velocity [右腿髋关节 速度] (type : float, unit : m, range : )                                </para>
        ///<para>     - right leg knee joint velocity [左腿膝关节 速度] (type : float, unit : m, range : )                               </para>
        ///<para>     - right leg Ankle joint velocity [左腿踝关节 速度] (type : float, unit : m, range : )                              </para>
        ///<para>                                                                                                                       </para>
        ///<para> for X2, the parameters are                                                                                            </para>
        ///<para>     - left leg hip joint acceleration [左腿髋关节 加速度] (type : float, unit : m, range : )                            </para>
        ///<para>     - left leg knee joint acceleration [左腿膝关节 加速度] (type : float, unit : m, range : )                           </para>
        ///<para>     - right leg hip joint acceleration [右腿髋关节 加速度] (type : float, unit : m, range : )                           </para>
        ///<para>     - right leg knee joint acceleration [左腿膝关节 加速度] (type : float, unit : m, range : )                          </para>
        ///<para>     - left leg hip joint velocity [左腿髋关节 速度] (type : float, unit : m, range : )                                 </para>
        ///<para>     - left leg knee joint velocity [左腿膝关节 速度] (type : float, unit : m, range : )                                </para>
        ///<para>     - right leg hip joint velocity [右腿髋关节 速度] (type : float, unit : m, range : )                                </para>
        ///<para>     - right leg knee joint velocity [左腿膝关节 速度] (type : float, unit : m, range : )                               </para>
        ///<para>                                                                                                                       </para>
        ///<para> @return Function result [方法执行结果]                                                                                 </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]                                                                         </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]                                                                               </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdJointVelocityControl(
            params float[] parameters)
        {
            //string aa = null;
            //for (int i = 0; i < parameters.Length; i++)
            //{
            //    aa +=" "+ parameters[i].ToString();
            //}
            //UnityEngine.Debug.Log(aa);
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        if (parameters.Length != 8)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetSubtaskBasicJointVelocityControlAcceleration(
                            parameters[0], parameters[1], parameters[2], parameters[3]);

                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetSubtaskBasicJointVelocityControlVelocity(
                            parameters[4], parameters[5], parameters[6], parameters[7]);

                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationH4TaskInterfaceWorkMode.JOINT_VELOCITY_CONTROL);

                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        if (parameters.Length != 2)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicJointVelocityControlAcceleration(
                            parameters[0]);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicJointVelocityControlVelocity(
                            parameters[1]);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1TaskInterfaceWorkMode.DEBUG);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetDebugWorkMode(
                            FFTAICommunicationM1TaskInterfaceDebugWorkMode.JOINT_VELOCITY_CONTROL);

                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        if (parameters.Length != 2)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetSubtaskBasicJointVelocityControlAcceleration(
                            parameters[0]);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetSubtaskBasicJointVelocityControlVelocity(
                            parameters[1]);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceWorkMode.DEBUG);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetDebugWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceDebugWorkMode.JOINT_VELOCITY_CONTROL);

                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        if (parameters.Length != 4)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicJointVelocityControlAcceleration(
                            parameters[0], parameters[1]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicJointVelocityControlVelocity(
                            parameters[2], parameters[3]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM2TaskInterfaceWorkMode.DEBUG);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetDebugWorkMode(
                            FFTAICommunicationM2TaskInterfaceDebugWorkMode.JOINT_VELOCITY_CONTROL);

                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        if (parameters.Length != 12)
                        {
                            return FunctionResult.FAIL;
                        }
                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetSubtaskBasicJointVelocityControlAcceleration(
                            parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], parameters[5]);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetSubtaskBasicJointVelocityControlVelocity(
                             parameters[6], parameters[7], parameters[8], parameters[9], parameters[10], parameters[11]);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM6TaskInterfaceWorkMode.DEBUG);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetDebugWorkMode(
                            FFTAICommunicationM6TaskInterfaceDebugWorkMode.JOINT_VELOCITY_CONTROL);

                        break;
                    }
                case DynaLinkHS.RobotType.M3:
                    {
                        if (parameters.Length != 6)
                        {
                            return FunctionResult.FAIL;
                        }
                        FFTAICommunicationManager.getInstance().M3TaskInterface.RequestSetSubtaskBasicJointVelocityControlAcceleration(
                            parameters[0], parameters[1], parameters[2]);

                        FFTAICommunicationManager.getInstance().M3TaskInterface.RequestSetSubtaskBasicJointVelocityControlVelocity(
                             parameters[3], parameters[4], parameters[5]);

                        FFTAICommunicationManager.getInstance().M3TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM3TaskInterfaceWorkMode.DEBUG);

                        FFTAICommunicationManager.getInstance().M3TaskInterface.RequestSetDebugWorkMode(
                            FFTAICommunicationM3TaskInterfaceDebugWorkMode.JointVelocityControl);

                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        if (parameters.Length != 8)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetSubtaskBasicJointVelocityControlAcceleration(
                            parameters[0], parameters[1], parameters[2], parameters[3]);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetSubtaskBasicJointVelocityControlVelocity(
                            parameters[4], parameters[5], parameters[6], parameters[7]);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationX2TaskInterfaceWorkMode.DEBUG);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetDebugWorkMode(
                            FFTAICommunicationX2TaskInterfaceDebugWorkMode.JOINT_VELOCITY_CONTROL);

                        break;
                    }

                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para>  @brief Set joint position control [设置机器关节位置控制]                                                          </para>
        ///<para>                                                                                                                  </para>
        ///<para>  @details                                                                                                        </para>
        ///<para>  for M1, the parameters are                                                                                      </para>
        ///<para>      - joint acceleration [关节 加速度] (type : float, unit : deg, range : )                                      </para>
        ///<para>      - joint velocity [关节 速度] (type : float, unit : deg, range : )                                            </para>
        ///<para>      - joint position [关节 位置] (type : float, unit : deg, range : )                                            </para>
        ///<para>                                                                                                                  </para>
        ///<para>  for M2, the parameters are                                                                                      </para>
        ///<para>      - horizontal joint acceleration [横向关节 加速度] (type : float, unit : m, range : )                         </para>
        ///<para>      - vertical joint acceleration [纵向关节 加速度] (type : float, unit : m, range : )                           </para>
        ///<para>      - horizontal joint velocity [横向关节 速度] (type : float, unit : m, range : )                               </para>
        ///<para>      - vertical joint velocity [纵向关节 速度] (type : float, unit : m, range : )                                 </para>
        ///<para>      - horizontal joint position [横向关节 位置] (type : float, unit : m, range : )                               </para>
        ///<para>      - vertical joint position [纵向关节 位置] (type : float, unit : m, range : )                                 </para>
        ///<para>                                                                                                                  </para>
        ///<para>  for M6, the parameters are                                                                                      </para>
        ///<para>      - left leg hip joint acceleration [左腿髋关节 加速度] (type : float, unit : m, range : )                     </para>
        ///<para>      - left leg knee joint acceleration [左腿膝关节 加速度] (type : float, unit : m, range : )                    </para>
        ///<para>      - left leg Ankel joint acceleration [左腿踝关节 加速度] (type : float, unit : m, range : )                   </para>
        ///<para>      - right leg hip joint acceleration [右腿髋关节 加速度] (type : float, unit : m, range : )                    </para>
        ///<para>      - right leg knee joint acceleration [右腿膝关节 加速度] (type : float, unit : m, range : )                   </para>
        ///<para>      - right leg Ankle joint acceleration [右腿踝关节 加速度] (type : float, unit : m, range : )                  </para>
        ///<para>      - left leg hip joint velocity [左腿髋关节 速度] (type : float, unit : m, range : )                           </para>
        ///<para>      - left leg knee joint velocity [左腿膝关节 速度] (type : float, unit : m, range : )                          </para>
        ///<para>      - left leg Ankle joint velocity [左腿踝关节 速度] (type : float, unit : m, range : )                         </para>
        ///<para>      - right leg hip joint velocity [右腿髋关节 速度] (type : float, unit : m, range : )                          </para>
        ///<para>      - right leg knee joint velocity [右腿膝关节 速度] (type : float, unit : m, range : )                         </para>
        ///<para>      - right leg Ankle joint velocity [右腿踝关节 速度] (type : float, unit : m, range : )                        </para>
        ///<para>      - left leg hip joint position [左腿髋关节 位置] (type : float, unit : m, range : )                           </para>
        ///<para>      - left leg knee joint position [左腿膝关节 位置] (type : float, unit : m, range : )                          </para>
        ///<para>      - left leg Ankle joint position [左腿踝关节 位置] (type : float, unit : m, range : )                         </para>
        ///<para>      - right leg hip joint position [右腿髋关节 位置] (type : float, unit : m, range : )                          </para>
        ///<para>      - right leg knee joint position [右腿膝关节 位置] (type : float, unit : m, range : )                         </para>
        ///<para>      - right leg Ankle joint position [右腿踝关节 位置] (type : float, unit : m, range : )                        </para>
        ///<para>                                                                                                                  </para>
        ///<para>  for X2, the parameters are                                                                                      </para>
        ///<para>      - left leg hip joint acceleration [左腿髋关节 加速度] (type : float, unit : m, range : )                     </para>
        ///<para>      - left leg knee joint acceleration [左腿膝关节 加速度] (type : float, unit : m, range : )                    </para>
        ///<para>      - right leg hip joint acceleration [右腿髋关节 加速度] (type : float, unit : m, range : )                    </para>
        ///<para>      - right leg knee joint acceleration [右腿膝关节 加速度] (type : float, unit : m, range : )                   </para>
        ///<para>      - left leg hip joint velocity [左腿髋关节 速度] (type : float, unit : m, range : )                           </para>
        ///<para>      - left leg knee joint velocity [左腿膝关节 速度] (type : float, unit : m, range : )                          </para>
        ///<para>      - right leg hip joint velocity [右腿髋关节 速度] (type : float, unit : m, range : )                          </para>
        ///<para>      - right leg knee joint velocity [右腿膝关节 速度] (type : float, unit : m, range : )                         </para>
        ///<para>      - left leg hip joint position [左腿髋关节 位置] (type : float, unit : m, range : )                           </para>
        ///<para>      - left leg knee joint position [左腿膝关节 位置] (type : float, unit : m, range : )                          </para>
        ///<para>      - right leg hip joint position [右腿髋关节 位置] (type : float, unit : m, range : )                          </para>
        ///<para>      - right leg knee joint position [右腿膝关节 位置] (type : float, unit : m, range : )                         </para>
        ///<para>                                                                                                                  </para>
        ///<para>  @return Function result [方法执行结果]                                                                           </para>
        ///<para>  @retval FunctionResult.SUCCESS SUCCESS [成功]                                                                   </para>
        ///<para>  @retval FunctionResult.FAIL FAIL [失败]                                                                         </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdJointPositionControl(
            params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        if (parameters.Length != 12)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetSubtaskBasicJointPositionControlAcceleration(
                            parameters[0], parameters[1], parameters[2], parameters[3]);

                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetSubtaskBasicJointPositionControlVelocity(
                            parameters[4], parameters[5], parameters[6], parameters[7]);

                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetSubtaskBasicJointPositionControlPosition(
                            parameters[8], parameters[9], parameters[10], parameters[11]);

                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationH4TaskInterfaceWorkMode.JOINT_POSITION_CONTROL);

                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        if (parameters.Length != 3)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicJointPositionControlAcceleration(
                            parameters[0]);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicJointPositionControlVelocity(
                            parameters[1]);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicJointPositionControlPosition(
                            parameters[2]);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1TaskInterfaceWorkMode.DEBUG);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetDebugWorkMode(
                            FFTAICommunicationM1TaskInterfaceDebugWorkMode.JOINT_POSITION_CONTROL);

                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        if (parameters.Length != 3)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetSubtaskBasicJointPositionControlAcceleration(
                            parameters[0]);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetSubtaskBasicJointPositionControlVelocity(
                            parameters[1]);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetSubtaskBasicJointPositionControlPosition(
                            parameters[2]);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceWorkMode.DEBUG);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetDebugWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceDebugWorkMode.JOINT_POSITION_CONTROL);

                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        if (parameters.Length != 6)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicJointPositionControlAcceleration(
                            parameters[0], parameters[1]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicJointPositionControlVelocity(
                            parameters[2], parameters[3]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicJointPositionControlPosition(
                            parameters[4], parameters[5]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM2TaskInterfaceWorkMode.DEBUG);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetDebugWorkMode(
                            FFTAICommunicationM2TaskInterfaceDebugWorkMode.JOINT_POSITION_CONTROL);

                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        if (parameters.Length != 18)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetSubtaskBasicJointPositionControlAcceleration(
                            parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], parameters[5]);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetSubtaskBasicJointPositionControlVelocity(
                            parameters[6], parameters[7], parameters[8], parameters[9], parameters[10], parameters[11]);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetSubtaskBasicJointPositionControlPosition(
                            parameters[12], parameters[13], parameters[14], parameters[15], parameters[16], parameters[17]);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM6TaskInterfaceWorkMode.DEBUG);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetDebugWorkMode(
                            FFTAICommunicationM6TaskInterfaceDebugWorkMode.JOINT_POSITION_CONTROL);

                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        if (parameters.Length != 12)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetSubtaskBasicJointPositionControlAcceleration(
                            parameters[0], parameters[1], parameters[2], parameters[3]);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetSubtaskBasicJointPositionControlVelocity(
                            parameters[4], parameters[5], parameters[6], parameters[7]);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetSubtaskBasicJointPositionControlPosition(
                            parameters[8], parameters[9], parameters[10], parameters[11]);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationX2TaskInterfaceWorkMode.DEBUG);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetDebugWorkMode(
                            FFTAICommunicationX2TaskInterfaceDebugWorkMode.JOINT_POSITION_CONTROL);

                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        /// <para> @brief Set end effector kinetic control [设置机器末端力/力矩控制]
        /// <para>                                                                                                            </para>
        /// <para> @details                                                                                                   </para>
        /// <para> for M1, the parameters are                                                                                 </para>
        /// <para>     - end effector kinetic [末端 力矩] (type : float, unit : deg, range : )                                 </para>
        /// <para>                                                                                                            </para>
        /// <para> for M2, the parameters are                                                                                 </para>
        /// <para>     - end effector x kinetic [末端横向 力] (type : float, unit : m, range : )                               </para>
        /// <para>     - end effector y kinetic [末端纵向 力] (type : float, unit : m, range : )                               </para>
        /// <para>                                                                                                            </para>
        /// <para> for M6, the parameters are                                                                                 </para>
        /// <para>     - end effector x1 kinetic [末端1 x方向 力矩] (type : float, unit : m, range : )                         </para>
        /// <para>     - end effector y1 kinetic [末端1 y方向 力矩] (type : float, unit : m, range : )                         </para>
        /// <para>     - end effector x2 kinetic [末端2 x方向 力矩] (type : float, unit : m, range : )                         </para>
        /// <para>     - end effector y2 kinetic [末端2 y方向 力矩] (type : float, unit : m, range : )                         </para>
        /// <para>                                                                                                            </para>
        /// <para> for X2, the parameters are                                                                                 </para>
        /// <para>     - end effector x1 kinetic [末端1 x方向 力矩] (type : float, unit : m, range : )                         </para>
        /// <para>     - end effector y1 kinetic [末端1 y方向 力矩] (type : float, unit : m, range : )                         </para>
        /// <para>     - end effector x2 kinetic [末端2 x方向 力矩] (type : float, unit : m, range : )                         </para>
        /// <para>     - end effector y2 kinetic [末端1 y方向 力矩] (type : float, unit : m, range : )                         </para>
        /// <para>                                                                                                            </para>
        /// <para> @return Function result [方法执行结果]                                                                      </para>
        /// <para> @retval FunctionResult.SUCCESS SUCCESS [成功]                                                              </para>
        /// <para> @retval FunctionResult.FAIL FAIL [失败]                                                                    </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdEndEffectorKineticControl(
            params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        if (parameters.Length != 4)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetSubtaskBasicEndEffectorKineticControlKinetic(
                            parameters[0], parameters[1], parameters[2], parameters[3]);

                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationH4TaskInterfaceWorkMode.END_EFFECTOR_KINETIC_CONTROL);

                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        if (parameters.Length != 1)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicEndEffectorKineticControlKinetic(
                            parameters[0]);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1TaskInterfaceWorkMode.DEBUG);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetDebugWorkMode(
                            FFTAICommunicationM1TaskInterfaceDebugWorkMode.END_EFFECTOR_KINETIC_CONTROL);

                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        if (parameters.Length != 1)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetSubtaskBasicEndEffectorKineticControlKinetic(
                            parameters[0]);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceWorkMode.DEBUG);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetDebugWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceDebugWorkMode.END_EFFECTOR_KINETIC_CONTROL);

                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        if (parameters.Length != 2)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicEndEffectorKineticControlKinetic(
                            parameters[0], parameters[1]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM2TaskInterfaceWorkMode.DEBUG);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetDebugWorkMode(
                            FFTAICommunicationM2TaskInterfaceDebugWorkMode.END_EFFECTOR_KINETIC_CONTROL);

                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        if (parameters.Length != 4)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetSubtaskBasicEndEffectorKineticControlKinetic(
                            parameters[0], parameters[1], parameters[2], parameters[3]);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM6TaskInterfaceWorkMode.DEBUG);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetDebugWorkMode(
                            FFTAICommunicationM6TaskInterfaceDebugWorkMode.END_EFFECTOR_KINETIC_CONTROL);

                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        if (parameters.Length != 4)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetSubtaskBasicEndEffectorKineticControlKinetic(
                            parameters[0], parameters[1], parameters[2], parameters[3]);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationX2TaskInterfaceWorkMode.DEBUG);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetDebugWorkMode(
                            FFTAICommunicationX2TaskInterfaceDebugWorkMode.END_EFFECTOR_KINETIC_CONTROL);

                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para> @brief Set end effector velocity control [设置机器末端速度控制]                                            </para>
        ///<para>                                                                                                          </para>
        ///<para> @details                                                                                                 </para>
        ///<para> for M1, the parameters are                                                                               </para>
        ///<para>     - end effector acceleration [关节 加速度] (type : float, unit : deg, range : )                        </para>
        ///<para>     - end effector velocity [关节 速度] (type : float, unit : deg, range : )                              </para>
        ///<para>                                                                                                          </para>
        ///<para> for M2, the parameters are                                                                               </para>
        ///<para>     - end effector x acceleration [横向关节 加速度] (type : float, unit : m, range : )                    </para>
        ///<para>     - end effector y acceleration [纵向关节 加速度] (type : float, unit : m, range : )                    </para>
        ///<para>     - end effector x velocity [横向关节 速度] (type : float, unit : m, range : )                          </para>
        ///<para>     - end effector y velocity [纵向关节 速度] (type : float, unit : m, range : )                          </para>
        ///<para>                                                                                                          </para>
        ///<para> for M6, the parameters are                                                                               </para>
        ///<para>     - end effector x1 acceleration [末端1 x方向 加速度] (type : float, unit : m, range : )                </para>
        ///<para>     - end effector y1 acceleration [末端1 y方向 加速度] (type : float, unit : m, range : )                </para>
        ///<para>     - end effector x2 acceleration [末端2 x方向 加速度] (type : float, unit : m, range : )                </para>
        ///<para>     - end effector y2 acceleration [末端2 y方向 加速度] (type : float, unit : m, range : )                </para>
        ///<para>     - end effector x1 velocity [末端1 x方向 速度] (type : float, unit : m, range : )                      </para>
        ///<para>     - end effector y1 velocity [末端1 y方向 速度] (type : float, unit : m, range : )                      </para>
        ///<para>     - end effector x2 velocity [末端2 x方向 速度] (type : float, unit : m, range : )                      </para>
        ///<para>     - end effector y2 velocity [末端2 y方向 速度] (type : float, unit : m, range : )                      </para>
        ///<para>                                                                                                          </para>
        ///<para> for X2, the parameters are                                                                               </para>
        ///<para>     - end effector x1 acceleration [末端1 x方向 加速度] (type : float, unit : m, range : )                </para>
        ///<para>     - end effector y1 acceleration [末端1 y方向 加速度] (type : float, unit : m, range : )                </para>
        ///<para>     - end effector x2 acceleration [末端2 x方向 加速度] (type : float, unit : m, range : )                </para>
        ///<para>     - end effector y2 acceleration [末端2 y方向 加速度] (type : float, unit : m, range : )                </para>
        ///<para>     - end effector x1 velocity [末端1 x方向 速度] (type : float, unit : m, range : )                      </para>
        ///<para>     - end effector y1 velocity [末端1 y方向 速度] (type : float, unit : m, range : )                      </para>
        ///<para>     - end effector x2 velocity [末端2 x方向 速度] (type : float, unit : m, range : )                      </para>
        ///<para>     - end effector y2 velocity [末端2 y方向 速度] (type : float, unit : m, range : )                      </para>
        ///<para>                                                                                                          </para>
        ///<para> @return Function result [方法执行结果]                                                                     </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]                                                             </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]                                                                   </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdEndEffectorVelocityControl(
            params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        if (parameters.Length != 8)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetSubtaskBasicEndEffectorVelocityControlAcceleration(
                            parameters[0], parameters[1], parameters[2], parameters[3]);

                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetSubtaskBasicEndEffectorVelocityControlVelocity(
                            parameters[4], parameters[5], parameters[6], parameters[7]);

                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationH4TaskInterfaceWorkMode.END_EFFECTOR_VELOCITY_CONTROL);

                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        if (parameters.Length != 2)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicEndEffectorVelocityControlAcceleration(
                            parameters[0]);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicEndEffectorVelocityControlVelocity(
                            parameters[1]);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1TaskInterfaceWorkMode.DEBUG);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetDebugWorkMode(
                            FFTAICommunicationM1TaskInterfaceDebugWorkMode.END_EFFECTOR_VELOCITY_CONTROL);

                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        if (parameters.Length != 2)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetSubtaskBasicEndEffectorVelocityControlAcceleration(
                            parameters[0]);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetSubtaskBasicEndEffectorVelocityControlVelocity(
                            parameters[1]);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceWorkMode.DEBUG);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetDebugWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceDebugWorkMode.END_EFFECTOR_VELOCITY_CONTROL);

                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        if (parameters.Length != 4)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicEndEffectorVelocityControlAcceleration(
                            parameters[0], parameters[1]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicEndEffectorVelocityControlVelocity(
                            parameters[2], parameters[3]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM2TaskInterfaceWorkMode.DEBUG);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetDebugWorkMode(
                            FFTAICommunicationM2TaskInterfaceDebugWorkMode.END_EFFECTOR_VELOCITY_CONTROL);

                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        if (parameters.Length != 8)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetSubtaskBasicEndEffectorVelocityControlAcceleration(
                            parameters[0], parameters[1], parameters[2], parameters[3]);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetSubtaskBasicEndEffectorVelocityControlVelocity(
                            parameters[4], parameters[5], parameters[6], parameters[7]);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM6TaskInterfaceWorkMode.DEBUG);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetDebugWorkMode(
                            FFTAICommunicationM6TaskInterfaceDebugWorkMode.END_EFFECTOR_VELOCITY_CONTROL);

                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        if (parameters.Length != 8)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetSubtaskBasicEndEffectorVelocityControlAcceleration(
                            parameters[0], parameters[1], parameters[2], parameters[3]);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetSubtaskBasicEndEffectorVelocityControlVelocity(
                            parameters[4], parameters[5], parameters[6], parameters[7]);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationX2TaskInterfaceWorkMode.DEBUG);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetDebugWorkMode(
                            FFTAICommunicationX2TaskInterfaceDebugWorkMode.END_EFFECTOR_VELOCITY_CONTROL);

                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para>  @brief Set end effector position control [设置机器末端位置控制]                                          </para>
        ///<para>                                                                                                         </para>
        ///<para>  @details                                                                                               </para>
        ///<para>  for M1, the parameters are                                                                             </para>
        ///<para>      - end effector acceleration [关节 加速度] (type : float, unit : deg, range : )                      </para>
        ///<para>      - end effector velocity [关节 速度] (type : float, unit : deg, range : )                            </para>
        ///<para>      - end effector position [关节 位置] (type : float, unit : deg, range : )                            </para>
        ///<para>                                                                                                         </para>
        ///<para>  for M2, the parameters are                                                                             </para>
        ///<para>      - end effector x acceleration [横向关节 加速度] (type : float, unit : m, range : )                  </para>
        ///<para>      - end effector y acceleration [纵向关节 加速度] (type : float, unit : m, range : )                  </para>
        ///<para>      - end effector x velocity [横向关节 速度] (type : float, unit : m, range : )                        </para>
        ///<para>      - end effector y velocity [纵向关节 速度] (type : float, unit : m, range : )                        </para>
        ///<para>      - end effector x position [横向关节 位置] (type : float, unit : m, range : )                        </para>
        ///<para>      - end effector y position [纵向关节 位置] (type : float, unit : m, range : )                        </para>
        ///<para>                                                                                                         </para>
        ///<para>  for M6, the parameters are                                                                             </para>
        ///<para>      - end effector x1 acceleration [末端1 x方向 加速度] (type : float, unit : m, range : )              </para>
        ///<para>      - end effector y1 acceleration [末端1 y方向 加速度] (type : float, unit : m, range : )              </para>
        ///<para>      - end effector x2 acceleration [末端2 x方向 加速度] (type : float, unit : m, range : )              </para>
        ///<para>      - end effector y2 acceleration [末端2 y方向 加速度] (type : float, unit : m, range : )              </para>
        ///<para>      - end effector x1 velocity [末端1 x方向 速度] (type : float, unit : m, range : )                    </para>
        ///<para>      - end effector y1 velocity [末端1 y方向 速度] (type : float, unit : m, range : )                    </para>
        ///<para>      - end effector x2 velocity [末端2 x方向 速度] (type : float, unit : m, range : )                    </para>
        ///<para>      - end effector y2 velocity [末端2 y方向 速度] (type : float, unit : m, range : )                    </para>
        ///<para>      - end effector x1 position [末端1 x方向 位置] (type : float, unit : m, range : )                    </para>
        ///<para>      - end effector y1 position [末端1 y方向 位置] (type : float, unit : m, range : )                    </para>
        ///<para>      - end effector x2 position [末端2 x方向 位置] (type : float, unit : m, range : )                    </para>
        ///<para>      - end effector y2 position [末端2 y方向 位置] (type : float, unit : m, range : )                    </para>
        ///<para>                                                                                                         </para>
        ///<para>  for X2, the parameters are                                                                             </para>
        ///<para>      - end effector x1 acceleration [末端1 x方向 加速度] (type : float, unit : m, range : )              </para>
        ///<para>      - end effector y1 acceleration [末端1 y方向 加速度] (type : float, unit : m, range : )              </para>
        ///<para>      - end effector x2 acceleration [末端2 x方向 加速度] (type : float, unit : m, range : )              </para>
        ///<para>      - end effector y2 acceleration [末端2 y方向 加速度] (type : float, unit : m, range : )              </para>
        ///<para>      - end effector x1 velocity [末端1 x方向 速度] (type : float, unit : m, range : )                    </para>
        ///<para>      - end effector y1 velocity [末端1 y方向 速度] (type : float, unit : m, range : )                    </para>
        ///<para>      - end effector x2 velocity [末端2 x方向 速度] (type : float, unit : m, range : )                    </para>
        ///<para>      - end effector y2 velocity [末端2 y方向 速度] (type : float, unit : m, range : )                    </para>
        ///<para>      - end effector x1 position [末端1 x方向 位置] (type : float, unit : m, range : )                    </para>
        ///<para>      - end effector y1 position [末端1 y方向 位置] (type : float, unit : m, range : )                    </para>
        ///<para>      - end effector x2 position [末端2 x方向 位置] (type : float, unit : m, range : )                    </para>
        ///<para>      - end effector y2 position [末端2 y方向 位置] (type : float, unit : m, range : )                    </para>
        ///<para>                                                                                                         </para>
        ///<para>  @return Function result [方法执行结果]                                                                  </para>
        ///<para>  @retval FunctionResult.SUCCESS SUCCESS [成功]                                                          </para>
        ///<para>  @retval FunctionResult.FAIL FAIL [失败]                                                                </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdEndEffectorPositionControl(
            params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        if (parameters.Length != 12)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetSubtaskBasicEndEffectorPositionControlAcceleration(
                            parameters[0], parameters[1], parameters[2], parameters[3]);

                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetSubtaskBasicEndEffectorPositionControlVelocity(
                            parameters[4], parameters[5], parameters[6], parameters[7]);

                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetSubtaskBasicEndEffectorPositionControlPosition(
                            parameters[8], parameters[9], parameters[10], parameters[11]);

                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationH4TaskInterfaceWorkMode.END_EFFECTOR_POSITION_CONTROL);

                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        if (parameters.Length != 3)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicEndEffectorPositionControlAcceleration(
                            parameters[0]);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicEndEffectorPositionControlVelocity(
                            parameters[1]);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicEndEffectorPositionControlPosition(
                            parameters[2]);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1TaskInterfaceWorkMode.DEBUG);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetDebugWorkMode(
                            FFTAICommunicationM1TaskInterfaceDebugWorkMode.END_EFFECTOR_POSITION_CONTROL);

                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        if (parameters.Length != 3)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetSubtaskBasicEndEffectorPositionControlAcceleration(
                            parameters[0]);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetSubtaskBasicEndEffectorPositionControlVelocity(
                            parameters[1]);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetSubtaskBasicEndEffectorPositionControlPosition(
                            parameters[2]);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceWorkMode.DEBUG);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetDebugWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceDebugWorkMode.END_EFFECTOR_POSITION_CONTROL);

                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        if (parameters.Length != 6)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicEndEffectorPositionControlAcceleration(
                            parameters[0], parameters[1]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicEndEffectorPositionControlVelocity(
                            parameters[2], parameters[3]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicEndEffectorPositionControlPosition(
                            parameters[4], parameters[5]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM2TaskInterfaceWorkMode.DEBUG);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetDebugWorkMode(
                            FFTAICommunicationM2TaskInterfaceDebugWorkMode.END_EFFECTOR_POSITION_CONTROL);

                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        if (parameters.Length != 12)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetSubtaskBasicEndEffectorPositionControlAcceleration(
                            parameters[0], parameters[1], parameters[2], parameters[3]);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetSubtaskBasicEndEffectorPositionControlVelocity(
                            parameters[4], parameters[5], parameters[6], parameters[7]);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetSubtaskBasicEndEffectorPositionControlPosition(
                            parameters[8], parameters[9], parameters[10], parameters[11]);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM6TaskInterfaceWorkMode.DEBUG);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetDebugWorkMode(
                            FFTAICommunicationM6TaskInterfaceDebugWorkMode.END_EFFECTOR_POSITION_CONTROL);

                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        if (parameters.Length != 12)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetSubtaskBasicEndEffectorPositionControlAcceleration(
                            parameters[0], parameters[1], parameters[2], parameters[3]);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetSubtaskBasicEndEffectorPositionControlVelocity(
                            parameters[4], parameters[5], parameters[6], parameters[7]);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetSubtaskBasicEndEffectorPositionControlPosition(
                            parameters[8], parameters[9], parameters[10], parameters[11]);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationX2TaskInterfaceWorkMode.DEBUG);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetDebugWorkMode(
                            FFTAICommunicationX2TaskInterfaceDebugWorkMode.END_EFFECTOR_POSITION_CONTROL);

                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        //public static int CmdTest()
        //{
        //    FFTAICommunicationManager.getInstance().FFTAICommunicationV2M2TaskInterface.RequestSetWorkMode(
        //        FFTAICommunicationV2M2TaskInterfaceWorkMode.RELAY);

        //    FFTAICommunicationManager.getInstance().FFTAICommunicationV2M2TaskInterface.RequestSetRelayWorkMode(
        //        FFTAICommunicationV2M2TaskInterfaceRelayWorkMode.Test);

        //    return FunctionResult.SUCCESS;
        //}

        /// <summary>
        ///<para> @brief Set passive movement control [设置被动运动控制]                            </para>
        ///<para>                                                                                  </para>
        ///<para> @details                                                                         </para>
        ///<para> for M1, the parameters are                                                       </para>
        ///<para>     - target position [目标位置] (type : float, unit : deg, range : )             </para>
        ///<para>     - angular velocity [移动速度] (type : float, unit : deg/s, range : )          </para>
        ///<para>                                                                                  </para>
        ///<para> for M2, the parameters are                                                       </para>
        ///<para>     - target position x [目标位置 x 轴] (type : float, unit : m, range : )        </para>
        ///<para>     - target position y [目标位置 y 轴] (type : float, unit : m, range : )        </para>
        ///<para>     - velocity [移动速度] (type : float, unit : m/s, range : )                    </para>
        ///<para>                                                                                  </para>
        ///<para> for M3, the parameters are                                                       </para>
        ///<para>     - target position x [目标位置 x 轴] (type : float, unit : m, range : )        </para>
        ///<para>     - target position y [目标位置 y 轴] (type : float, unit : m, range : )        </para>
        ///<para>     - target position z [目标位置 z 轴] (type : float, unit : m, range : )        </para>
        ///<para>     - velocity [移动速度] (type : float, unit : m/s, range : )                    </para>
        ///<para>                                                                                  </para>
        ///<para> @return Function result [方法执行结果]                                            </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]                                    </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]                                          </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdPassiveMovementControl(
            params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        if (parameters.Length != 8)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetSubtaskBasicPassiveMovePosition(
                            parameters[0], parameters[1], parameters[2], parameters[3]);

                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetSubtaskBasicPassiveMoveVelocity(
                            parameters[4], parameters[5], parameters[6], parameters[7]);

                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationH4TaskInterfaceWorkMode.PASSIVE_MOVE);

                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        if (parameters.Length != 2)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicPassiveLinearMotionPosition(
                            parameters[0]);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicPassiveLinearMotionVelocity(
                            parameters[1]);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM1TaskInterfaceRelayWorkMode.PassiveLinearMotion);

                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        if (parameters.Length != 2)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetSubtaskBasicPassiveLinearMotionPosition(
                            parameters[0]);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetSubtaskBasicPassiveLinearMotionVelocity(
                            parameters[1]);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceRelayWorkMode.PassiveLinearMotion);

                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        if (parameters.Length != 3)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicPassiveLinearMotionPosition(
                            parameters[0], parameters[1]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicPassiveLinearMotionVelocity(
                            parameters[2]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM2TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM2TaskInterfaceRelayWorkMode.PassiveLinearMotion);

                        break;
                    }
                case DynaLinkHS.RobotType.M3:
                    {
                        if (parameters.Length != 4)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M3TaskInterface.RequestSetSubtaskBasicPassiveLinearMotionPosition(
                            parameters[0], parameters[1], parameters[2]);

                        FFTAICommunicationManager.getInstance().M3TaskInterface.RequestSetSubtaskBasicPassiveLinearMotionVelocity(
                            parameters[3]);

                        FFTAICommunicationManager.getInstance().M3TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM3TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M3TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM3TaskInterfaceRelayWorkMode.PassiveLinearMotion);

                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        if (parameters.Length != 12)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetSubtaskBasicPassiveMovePosition(
                            parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], parameters[5]);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetSubtaskBasicPassiveMoveVelocity(
                            parameters[6], parameters[7], parameters[8], parameters[9], parameters[10], parameters[11]);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM6TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM6TaskInterfaceRelayWorkMode.PASSIVE_MOVE);

                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        if (parameters.Length != 8)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetSubtaskBasicPassiveMovePosition(
                            parameters[0], parameters[1], parameters[2], parameters[3]);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetSubtaskBasicPassiveMoveVelocity(
                            parameters[4], parameters[5], parameters[6], parameters[7]);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationX2TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationX2TaskInterfaceRelayWorkMode.PASSIVE_MOVE);

                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }
        /// <summary>
        ///<para> @brief Set passive movement control 1 [设置被动运动控制]                       </para>
        ///<para>                                                                               </para>
        ///<para> @details                                                                      </para>
        ///<para> for M1, the parameters are                                                    </para>
        ///<para>     - target position [目标位置] (type : float, unit : deg, range : )          </para>
        ///<para>     - angular velocity [移动速度] (type : float, unit : deg/s, range : )       </para>
        ///<para>     - angular velocity [移动加速度] (type : float, unit : deg/s, range : )     </para>
        ///<para>                                                                               </para>
        ///<para> for M2, the parameters are                                                    </para>
        ///<para>     - target position x [目标位置 x 轴] (type : float, unit : m, range : )     </para>
        ///<para>     - target position y [目标位置 y 轴] (type : float, unit : m, range : )     </para>
        ///<para>     - velocity [移动速度] (type : float, unit : m/s, range : )                 </para>
        ///<para>     - velocity [移动加速度] (type : float, unit : m/s, range : )               </para>
        ///<para>                                                                               </para>
        ///<para> for M3, the parameters are                                                    </para>
        ///<para>     - target position x [目标位置 x 轴] (type : float, unit : m, range : )     </para>
        ///<para>     - target position y [目标位置 y 轴] (type : float, unit : m, range : )     </para>
        ///<para>     - target position z [目标位置 z 轴] (type : float, unit : m, range : )     </para>
        ///<para>     - velocity [移动速度] (type : float, unit : m/s, range : )                 </para>
        ///<para>     - velocity [移动加速度] (type : float, unit : m/s, range : )               </para>
        ///<para>                                                                               </para>
        ///<para> @return Function result [方法执行结果]                                          </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]                                  </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]                                        </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdPassiveMovementControl1(
            params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        if (parameters.Length != 12)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetSubtaskBasicPassiveMovePosition(
                            parameters[0], parameters[1], parameters[2], parameters[3]);

                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetSubtaskBasicPassiveMoveVelocity(
                            parameters[4], parameters[5], parameters[6], parameters[7]);

                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetSubtaskBasicPassiveMoveVelocity(
                            parameters[8], parameters[9], parameters[10], parameters[11]);

                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationH4TaskInterfaceWorkMode.PASSIVE_MOVE);

                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        if (parameters.Length != 3)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicPassiveLinearMotionPosition(
                            parameters[0]);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicPassiveLinearMotionVelocity(
                            parameters[1]);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicPassiveLinearMotionAcceleration(
                            parameters[2]);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM1TaskInterfaceRelayWorkMode.PassiveLinearMotion);

                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        if (parameters.Length != 2)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetSubtaskBasicPassiveLinearMotionPosition(
                            parameters[0]);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetSubtaskBasicPassiveLinearMotionVelocity(
                            parameters[1]);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetSubtaskBasicPassiveLinearMotionAcceleration(
                            parameters[2]);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceRelayWorkMode.PassiveLinearMotion);

                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        if (parameters.Length != 4)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicPassiveLinearMotionPosition(
                            parameters[0], parameters[1]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicPassiveLinearMotionVelocity(
                            parameters[2]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicPassiveLinearMotionAcceleration(
                            parameters[3]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM2TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM2TaskInterfaceRelayWorkMode.PassiveLinearMotion);

                        break;
                    }
                case DynaLinkHS.RobotType.M3:
                    {
                        if (parameters.Length != 5)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M3TaskInterface.RequestSetSubtaskBasicPassiveLinearMotionPosition(
                            parameters[0], parameters[1], parameters[2]);

                        FFTAICommunicationManager.getInstance().M3TaskInterface.RequestSetSubtaskBasicPassiveLinearMotionVelocity(
                            parameters[3]);

                        FFTAICommunicationManager.getInstance().M3TaskInterface.RequestSetSubtaskBasicPassiveLinearMotionAcceleration(
                            parameters[4]);

                        FFTAICommunicationManager.getInstance().M3TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM3TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M3TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM3TaskInterfaceRelayWorkMode.PassiveLinearMotion);

                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        if (parameters.Length != 18)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetSubtaskBasicPassiveMovePosition(
                            parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], parameters[5]);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetSubtaskBasicPassiveMoveVelocity(
                             parameters[6], parameters[7], parameters[8], parameters[9], parameters[10], parameters[11]);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetSubtaskBasicPassiveMoveAcceleration(
                             parameters[12], parameters[13], parameters[14], parameters[15], parameters[16], parameters[17]);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM6TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM6TaskInterfaceRelayWorkMode.PASSIVE_MOVE);

                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        if (parameters.Length != 12)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetSubtaskBasicPassiveMovePosition(
                            parameters[0], parameters[1], parameters[2], parameters[3]);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetSubtaskBasicPassiveMoveVelocity(
                            parameters[4], parameters[5], parameters[6], parameters[7]);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetSubtaskBasicPassiveMoveAcceleration(
                            parameters[8], parameters[9], parameters[10], parameters[11]);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationX2TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationX2TaskInterfaceRelayWorkMode.PASSIVE_MOVE);

                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para> @brief Set mass simulation control [设置质量仿真运动控制]                             </para>
        ///<para>                                                                                     </para>
        ///<para> @details                                                                            </para>
        ///<para> for M1, the parameters are                                                          </para>
        ///<para>     - mass [质量] (type : float, unit : deg, range : > 0)                           </para>
        ///<para>     - friction bc [动态摩擦系数] (type : float, unit :null, range : >= 0)            </para>
        ///<para>     - friction bv [静态摩擦系数] (type : float, unit : null, range : >= 0)           </para>
        ///<para>                                                                                     </para>
        ///<para> for M2, the parameters are                                                          </para>
        ///<para>     - mass x [质量 x 轴] (type : float, unit : kg, range : > 0)                      </para>
        ///<para>     - friction bc x [摩擦系数 x 轴] (type : float, unit :null , range : > 0)         </para>
        ///<para>     - friction bv y [摩擦系数 y 轴] (type : float, unit :null , range : > 0)         </para>
        ///<para>     - mass y [质量 y 轴] (type : float, unit : kg, range : > 0)                      </para>
        ///<para>     - friction bc x [摩擦系数 x 轴] (type : float, unit :null , range : > 0)         </para>
        ///<para>     - friction bv y [摩擦系数 y 轴] (type : float, unit :null , range : > 0)         </para>
        ///<para>                                                                                     </para>
        ///<para> @return Function result [方法执行结果]                                               </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]                                       </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]                                             </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdMassSimulationControl(
            params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        //if (parameters.Length != 2)
                        //{
                        //    return FunctionResult.FAIL;
                        //}

                        //FFTAICommunicationManager.getInstance().FFTAICommunicationV2M1TaskInterface.RequestSetSubtaskBasicMassSimulationMass(
                        //    parameters[0]);

                        //FFTAICommunicationManager.getInstance().FFTAICommunicationV2M1TaskInterface.RequestSetSubtaskBasicMassSimulationFriction(
                        //    parameters[1]);

                        //FFTAICommunicationManager.getInstance().FFTAICommunicationV2M1TaskInterface.RequestSetWorkMode(
                        //    FFTAICommunicationV2M1TaskInterfaceWorkMode.RELAY);

                        //FFTAICommunicationManager.getInstance().FFTAICommunicationV2M1TaskInterface.RequestSetRelayWorkMode(
                        //    FFTAICommunicationV2M1TaskInterfaceRelayWorkMode.MassSimulation);

                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        if (parameters.Length != 2)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetSubtaskBasicMassSimulationMass(
                            parameters[0]);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetSubtaskBasicMassSimulationFriction(
                            parameters[1]);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceRelayWorkMode.MassSimulation);

                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        if (parameters.Length != 6)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicMassSimulationMass(
                            parameters[0], parameters[1]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicMassSimulationFrictionBc(
                            parameters[2], parameters[3]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicMassSimulationFrictionBv(
                            parameters[4], parameters[5]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM2TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM2TaskInterfaceRelayWorkMode.MassSimulation);

                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para>  @brief Set mass simulation control [设置质量仿真运动控制]                          </para>
        ///<para>                                                                                   </para>
        ///<para> @details                                                                          </para>
        ///<para> for M1, the parameters are                                                        </para>
        ///<para>     - mass [质量] (type : float, unit : deg, range : > 0)                         </para>
        ///<para>     - friction bc [动态摩擦系数] (type : float, unit :null, range : >= 0)          </para>
        ///<para>     - friction bv [静态摩擦系数] (type : float, unit : null, range : >= 0)         </para>
        ///<para>                                                                                   </para>
        ///<para> for M2, the parameters are                                                        </para>
        ///<para>     - mass x [质量 x 轴] (type : float, unit : kg, range : > 0)                    </para>
        ///<para>     - friction bc x [摩擦系数 x 轴] (type : float, unit :null , range : > 0)       </para>
        ///<para>     - friction bv y [摩擦系数 y 轴] (type : float, unit :null , range : > 0)       </para>
        ///<para>     - mass y [质量 y 轴] (type : float, unit : kg, range : > 0)                    </para>
        ///<para>     - friction bc x [摩擦系数 x 轴] (type : float, unit :null , range : > 0)       </para>
        ///<para>     - friction bv y [摩擦系数 y 轴] (type : float, unit :null , range : > 0)       </para>
        ///<para>                                                                                   </para>
        ///<para> @return Function result [方法执行结果]                                             </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]                                     </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]                                           </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdMassSimulationControlWithoutSensor(params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        //if (parameters.Length != 2)
                        //{
                        //    return FunctionResult.FAIL;
                        //}

                        //FFTAICommunicationManager.getInstance().FFTAICommunicationV2M1_LTaskInterface.RequestSetSubtaskBasicMassSimulationMass(
                        //    parameters[0]);

                        //FFTAICommunicationManager.getInstance().FFTAICommunicationV2M1_LTaskInterface.RequestSetSubtaskBasicMassSimulationFriction(
                        //    parameters[1]);

                        //FFTAICommunicationManager.getInstance().FFTAICommunicationV2M1_LTaskInterface.RequestSetWorkMode(
                        //    FFTAICommunicationV2M1_LTaskInterfaceWorkMode.RELAY);

                        //FFTAICommunicationManager.getInstance().FFTAICommunicationV2M1_LTaskInterface.RequestSetRelayWorkMode(
                        //    FFTAICommunicationV2M1_LTaskInterfaceRelayWorkMode.MassSimulation);

                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        if (parameters.Length != 6)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicMassSimulationWithoutSensorMass(
                          parameters[0], parameters[3]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicMassSimulationWithoutSensorFrictionBc(
                            parameters[1], parameters[4]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicMassSimulationWithoutSensorFrictionBv(
                            parameters[2], parameters[5]);

                        //FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicMassSimulationWithoutSensor(
                        //    parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], parameters[5]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM2TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM2TaskInterfaceRelayWorkMode.MassSimulationWithoutSensor);

                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para>  @brief Set assist control without sensor [设置无传感器助力运动控制]                 </para>
        ///<para>                                                                                    </para>
        ///<para>  @details                                                                          </para>
        ///<para>  for M1, the parameters are                                                        </para>
        ///<para>      - ratio [比率] (type : float, unit : N, range : > 0)                          </para>
        ///<para>      - resist torque [阻力力矩] (type : float, unit : Nm, range : )                 </para>
        ///<para>                                                                                    </para>
        ///<para>  for M2, the parameters are                                                        </para>
        ///<para>      - ratio x [比率 x 轴] (type : float, unit : N, range : > 0)                    </para>
        ///<para>      - ratio y [比率 y 轴] (type : float, unit : N, range : > 0)                    </para>
        ///<para>      - resist force x [阻力力量 x 轴] (type : float, unit : N, range : > 0)         </para>
        ///<para>      - resist force y [阻力力量 y 轴] (type : float, unit : N, range : > 0)         </para>
        ///<para>                                                                                    </para>
        ///<para>  @return Function result [方法执行结果]                                              </para>
        ///<para>  @retval FunctionResult.SUCCESS SUCCESS [成功]                                      </para>
        ///<para>  @retval FunctionResult.FAIL FAIL [失败]                                            </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdAssistControlWithoutSensor(
            params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        if (parameters.Length != 2)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicForceAssistWithoutSensorRatio(parameters[0]);
                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicForceAssistWithoutSensorMaxForce(
                            parameters[1]);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM1TaskInterfaceRelayWorkMode.ForceAssistWithoutSensor);

                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        if (parameters.Length != 1)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetSubtaskBasicForceAssistWithoutSensorForce(
                            parameters[0]);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceRelayWorkMode.ForceAssistWithoutSensor);

                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        if (parameters.Length != 4)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicForceAssistWithoutSensorRatio(
                            parameters[0], parameters[1]);


                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicForceAssistWithoutSensorMaxForce(
                            parameters[2], parameters[3]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM2TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM2TaskInterfaceRelayWorkMode.ForceAssistWithoutSensor);

                        break;
                    }
                case DynaLinkHS.RobotType.M3:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para>  @brief Set assist control with sensor [设置有传感器助力运动控制]                  </para>
        ///<para>                                                                                  </para>
        ///<para>  @details                                                                        </para>
        ///<para>  for M1, the parameters are                                                      </para>
        ///<para>      - assist torque [助力力矩] (type : float, unit : Nm, range : )               </para>
        ///<para>                                                                                  </para>
        ///<para>  for M2, the parameters are                                                      </para>
        ///<para>      - assist force x [助力力量 x 轴] (type : float, unit : N, range : > 0)       </para>
        ///<para>      - assist force y [助力力量 y 轴] (type : float, unit : N, range : > 0)       </para>
        ///<para>                                                                                  </para>
        ///<para>  @return Function result [方法执行结果]                                           </para>
        ///<para>  @retval FunctionResult.SUCCESS SUCCESS [成功]                                   </para>
        ///<para>  @retval FunctionResult.FAIL FAIL [失败]                                         </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdAssistControlWithSensor(
            params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        if (parameters.Length != 1)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicForceAssistWithSensorForce(
                            parameters[0]);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM1TaskInterfaceRelayWorkMode.ForceAssistWithSensor);

                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        if (parameters.Length != 1)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetSubtaskBasicForceAssistWithSensorForce(
                            parameters[0]);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceRelayWorkMode.ForceAssistWithSensor);

                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        if (parameters.Length != 2)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicForceAssistWithSensorForce(
                            parameters[0], parameters[1]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM2TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM2TaskInterfaceRelayWorkMode.ForceAssistWithSensor);

                        break;
                    }
                case DynaLinkHS.RobotType.M3:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para> @brief Set assist control with target position [设置有目标点的传感器助力运动控制]     </para>
        ///<para>                                                                                    </para>
        ///<para> @details                                                                           </para>
        ///<para> for M1, the parameters are                                                         </para>
        ///<para>     - assist torque [助力力矩] (type : float, unit : Nm, range : )                  </para>
        ///<para>     - target position [目标角度] (type : float, unit : deg, range : )               </para>
        ///<para>                                                                                    </para>
        ///<para> for M2, the parameters are                                                         </para>
        ///<para>     - assist force x [助力力量 合力] (type : float, unit : N, range : > 0)          </para>
        ///<para>     - target position x [目标位置 x 轴] (type : float, unit : m, range : )          </para>
        ///<para>     - target position y [目标位置 y 轴] (type : float, unit : m, range : )          </para>
        ///<para>                                                                                    </para>
        ///<para> @return Function result [方法执行结果]                                              </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]                                      </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]                                            </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdAssistControlWithTargetPosition(
            params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        if (parameters.Length != 2)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM1TaskInterfaceRelayWorkMode.ForceAssistWithTargetPosition);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicForceAssistWithTargetPositionForce(
                            parameters[0]);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicForceAssistWithTargetPositionPosition(
                            parameters[1]);

                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        if (parameters.Length != 2)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceRelayWorkMode.ForceAssistWithTargetPosition);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetSubtaskBasicForceAssistWithTargetPositionForce(
                            parameters[0]);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetSubtaskBasicForceAssistWithTargetPositionPosition(
                            parameters[1]);

                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        if (parameters.Length != 3)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicForceAssistWithTargetPositionForce(
                            parameters[0]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicForceAssistWithTargetPositionPosition(
                            parameters[1], parameters[2]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM2TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM2TaskInterfaceRelayWorkMode.ForceAssistWithTargetPosition);

                        break;
                    }
                case DynaLinkHS.RobotType.M3:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para> @brief Set assist control with target position [设置k值逐渐增加的有目标点的传感器助力运动控制]     </para>
        ///<para>                                                                                    </para>
        ///<para> for M2, the parameters are                                                         </para>
        ///<para>     - assist force x [助力力量 合力] (type : float, unit : N, range : > 0)          </para>
        ///<para>     - target position x [目标位置 x 轴] (type : float, unit : m, range : )          </para>
        ///<para>     - target position y [目标位置 y 轴] (type : float, unit : m, range : )          </para>
        ///<para>                                                                                    </para>
        ///<para> @return Function result [方法执行结果]                                              </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]                                      </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]                                            </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdAssistControlWithTargetPosition1(
           params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.M2:
                    {
                        if (parameters.Length != 7)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicForceAssistWithTargetPosition1Force(
                            parameters[0]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicForceAssistWithTargetPosition1Position(
                            parameters[1], parameters[2]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicForceAssistWithTargetPosition1MaxVeloctiy(
                            parameters[3], parameters[4]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicForceAssistWithTargetPosition1ChangeInStep(
                            parameters[5], parameters[6]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM2TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM2TaskInterfaceRelayWorkMode.ForceAssistWithTargetPosition);

                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para> @brief Set resist control without sensor [设置无传感器阻力运动控制]                 </para>
        ///<para>                                                                                   </para>
        ///<para> @details                                                                          </para>
        ///<para> for M1, the parameters are                                                        </para>
        ///<para>     - ratio [比率] (type : float, unit : N, range : > 0)                          </para>
        ///<para>     - resist torque [阻力力矩] (type : float, unit : Nm, range : )                 </para>
        ///<para>                                                                                   </para>
        ///<para> for M2, the parameters are                                                        </para>
        ///<para>     - ratio x [比率 x 轴] (type : float, unit : N, range : > 0)                    </para>
        ///<para>     - ratio y [比率 y 轴] (type : float, unit : N, range : > 0)                    </para>
        ///<para>     - resist force x [阻力力量 x 轴] (type : float, unit : N, range : > 0)         </para>
        ///<para>     - resist force y [阻力力量 y 轴] (type : float, unit : N, range : > 0)         </para>
        ///<para>                                                                                   </para>
        ///<para> @return Function result [方法执行结果]                                              </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]                                      </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]                                            </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdResistControlWithoutSensor(
            params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        if (parameters.Length != 2)
                        {
                            return FunctionResult.FAIL;
                        }
                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicForceResistWithoutSensorRatio(
                           parameters[0]);
                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicForceResistWithoutSensorMaxForce(
                            parameters[1]);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM1TaskInterfaceRelayWorkMode.ForceResistWithoutSensor);

                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        if (parameters.Length != 1)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetSubtaskBasicForceResistWithoutSensorForce(
                            parameters[0]);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceRelayWorkMode.ForceResistWithoutSensor);

                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        if (parameters.Length != 4)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicForceResistWithoutSensorRatio(
                            parameters[0], parameters[1]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicForceResistWithoutSensorMaxForce(
                            parameters[2], parameters[3]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM2TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM2TaskInterfaceRelayWorkMode.ForceResistWithoutSensor);

                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para>  @brief Set resist control with sensor [设置有传感器阻力运动控制]                </para>
        ///<para>                                                                                </para>
        ///<para>  @details                                                                      </para>
        ///<para>  for M1, the parameters are                                                    </para>
        ///<para>      - resist torque [阻力力矩] (type : float, unit : Nm, range : )             </para>
        ///<para>                                                                                </para>
        ///<para>  for M2, the parameters are                                                    </para>
        ///<para>      - resist force x [阻力力量 x 轴] (type : float, unit : N, range : > 0)     </para>
        ///<para>      - resist force y [阻力力量 y 轴] (type : float, unit : N, range : > 0)     </para>
        ///<para>                                                                                </para>
        ///<para>  @return Function result [方法执行结果]                                         </para>
        ///<para>  @retval FunctionResult.SUCCESS SUCCESS [成功]                                 </para>
        ///<para>  @retval FunctionResult.FAIL FAIL [失败]                                       </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdResistControlWithSensor(
            params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        if (parameters.Length != 1)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicForceResistWithSensorForce(
                            parameters[0]);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM1TaskInterfaceRelayWorkMode.ForceResistWithSensor);

                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        if (parameters.Length != 1)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetSubtaskBasicForceResistWithSensorForce(
                            parameters[0]);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceRelayWorkMode.ForceResistWithSensor);

                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        if (parameters.Length != 2)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicForceResistWithSensorForce(
                            parameters[0], parameters[1]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM2TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM2TaskInterfaceRelayWorkMode.ForceResistWithSensor);

                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para> @brief Set transparent control [设置透明运动控制]                                                                      </para>
        ///<para>                                                                                                                       </para>
        ///<para> @details                                                                                                              </para>
        ///<para> for M1, the parameters are                                                                                            </para>
        ///<para>     - origin/target position [原始/目标位置] (type : float, unit : m, range : )                                        </para>
        ///<para>     - M (mass) [模拟质量] (type : float, unit : kg, range : )                                                          </para>
        ///<para>     - B (damping) [模拟阻尼] (type : float, unit : N/(m/s), range : )                                                  </para>
        ///<para>     - K (spring) [模拟弹簧] (type : float, unit : N/m, range : )                                                       </para>
        ///<para>     - limitSpeed (limitSpeed) x [x 轴方向限制速度] (type : float, unit : m/s, range : )                                 </para>
        ///<para>                                                                                                                       </para>
        ///<para> for M2, the parameters are                                                                                            </para>
        ///<para>     - origin/target position x [原始/目标位置 x 轴] (type : float, unit : m, range : )                                 </para>
        ///<para>     - origin/target position y [原始/目标位置 y 轴] (type : float, unit : m, range : )                                 </para>
        ///<para>     - M (mass) x [模拟质量 x 轴] (type : float, unit : kg, range : )                                                   </para>
        ///<para>     - M (mass) y [模拟质量 y 轴] (type : float, unit : kg, range : )                                                   </para>
        ///<para>     - B (damping) x [模拟阻尼 x 轴] (type : float, unit : N/(m/s), range : )                                           </para>
        ///<para>     - B (damping) y [模拟阻尼 y 轴] (type : float, unit : N/(m/s), range : )                                           </para>
        ///<para>     - K (spring) x [模拟弹簧 x 轴] (type : float, unit : N/m, range : )                                                </para>
        ///<para>     - K (spring) y [模拟弹簧 y 轴] (type : float, unit : N/m, range : )                                                </para>
        ///<para>     - limitSpeed (limitSpeed) x [x 轴方向限制速度] (type : float, unit : m/s, range : )                                                </para>
        ///<para>     - limitSpeed (limitSpeed) y [y 轴方向限制速度] (type : float, unit : m/s, range : )                                                </para> 
        /// 
        ///<para>                                                                                                                       </para>
        ///<para> for M6, the parameters are                                                                                            </para>
        ///<para>     - origin/target position left leg hip joint [原始/目标位置 左腿髋关节] (type : float, unit : m, range : )           </para>
        ///<para>     - origin/target position left leg knee joint [原始/目标位置 左腿膝关节] (type : float, unit : m, range : )          </para>
        ///<para>     - origin/target position left leg Ankle joint [原始/目标位置 左腿踝关节] (type : float, unit : m, range : )         </para>
        ///<para>     - origin/target position right leg hip joint [原始/目标位置 右腿髋关节] (type : float, unit : m, range : )          </para>
        ///<para>     - origin/target position right leg knee joint [原始/目标位置 右腿膝关节] (type : float, unit : m, range : )         </para>
        ///<para>     - origin/target position right leg Ankle joint [原始/目标位置 右腿踝关节] (type : float, unit : m, range : )        </para>
        ///<para>     - M (mass) left leg hip joint [模拟质量 左腿髋关节] (type : float, unit : kg, range : )                             </para>
        ///<para>     - M (mass) left leg knee joint [模拟质量 左腿膝关节] (type : float, unit : kg, range : )                            </para>
        ///<para>     - M (mass) left leg Ankle joint [模拟质量 左腿踝关节] (type : float, unit : kg, range : )                           </para>
        ///<para>     - M (mass) right leg hip joint [模拟质量 右腿髋关节] (type : float, unit : kg, range : )                            </para>
        ///<para>     - M (mass) right leg knee joint [模拟质量 右腿膝关节] (type : float, unit : kg, range : )                           </para>
        ///<para>     - M (mass) right leg Ankle joint [模拟质量 右腿踝关节] (type : float, unit : kg, range : )                          </para>
        ///<para>     - B (damping) left leg hip joint [模拟阻尼 左腿髋关节] (type : float, unit : N/(m/s), range : )                     </para>
        ///<para>     - B (damping) left leg knee joint [模拟阻尼 左腿膝关节] (type : float, unit : N/(m/s), range : )                    </para>
        ///<para>     - B (damping) left leg Ankle joint [模拟阻尼 左腿踝关节] (type : float, unit : N/(m/s), range : )                   </para>
        ///<para>     - B (damping) right leg hip joint [模拟阻尼 右腿髋关节] (type : float, unit : N/(m/s), range : )                    </para>
        ///<para>     - B (damping) right leg knee joint [模拟阻尼 右腿膝关节] (type : float, unit : N/(m/s), range : )                   </para>
        ///<para>     - B (damping) right leg Ankle joint [模拟阻尼 右腿踝关节] (type : float, unit : N/(m/s), range : )                  </para>
        ///<para>     - K (spring) left leg hip joint [模拟弹簧 左腿髋关节] (type : float, unit : N/m, range : )                          </para>
        ///<para>     - K (spring) left leg knee joint [模拟弹簧 左腿膝关节] (type : float, unit : N/m, range : )                         </para>
        ///<para>     - K (spring) left leg Ankle joint [模拟弹簧 左腿踝关节] (type : float, unit : N/m, range : )                        </para>
        ///<para>     - K (spring) right leg hip joint [模拟弹簧 右腿髋关节] (type : float, unit : N/m, range : )                         </para>
        ///<para>     - K (spring) right leg knee joint [模拟弹簧 右腿膝关节] (type : float, unit : N/m, range : )                        </para>
        ///<para>     - K (spring) right leg Ankle joint [模拟弹簧 右腿踝关节] (type : float, unit : N/m, range : )                       </para>
        ///<para>                                                                                                                       </para>
        ///
        ///<para> for X2, the parameters are                                                                                            </para>
        ///<para>     - origin/target position left leg hip joint [原始/目标位置 左腿髋关节] (type : float, unit : m, range : )           </para>
        ///<para>     - origin/target position left leg knee joint [原始/目标位置 左腿膝关节] (type : float, unit : m, range : )          </para>
        ///<para>     - origin/target position right leg hip joint [原始/目标位置 右腿髋关节] (type : float, unit : m, range : )          </para>
        ///<para>     - origin/target position right leg hip joint [原始/目标位置 右腿膝关节] (type : float, unit : m, range : )          </para>
        ///<para>     - M (mass) left leg hip joint [模拟质量 左腿髋关节] (type : float, unit : kg, range : )                             </para>
        ///<para>     - M (mass) left leg knee joint [模拟质量 左腿膝关节] (type : float, unit : kg, range : )                            </para>
        ///<para>     - M (mass) right leg hip joint [模拟质量 右腿髋关节] (type : float, unit : kg, range : )                            </para>
        ///<para>     - M (mass) right leg knee joint [模拟质量 右腿膝关节] (type : float, unit : kg, range : )                           </para>
        ///<para>     - B (damping) left leg hip joint [模拟阻尼 左腿髋关节] (type : float, unit : N/(m/s), range : )                     </para>
        ///<para>     - B (damping) left leg knee joint [模拟阻尼 左腿膝关节] (type : float, unit : N/(m/s), range : )                    </para>
        ///<para>     - B (damping) right leg hip joint [模拟阻尼 右腿髋关节] (type : float, unit : N/(m/s), range : )                    </para>
        ///<para>     - B (damping) right leg knee joint [模拟阻尼 右腿膝关节] (type : float, unit : N/(m/s), range : )                   </para>
        ///<para>     - K (spring) left leg hip joint [模拟弹簧 左腿髋关节] (type : float, unit : N/m, range : )                          </para>
        ///<para>     - K (spring) left leg knee joint [模拟弹簧 左腿膝关节] (type : float, unit : N/m, range : )                         </para>
        ///<para>     - K (spring) right leg hip joint [模拟弹簧 右腿髋关节] (type : float, unit : N/m, range : )                         </para>
        ///<para>     - K (spring) right leg knee joint [模拟弹簧 右腿膝关节] (type : float, unit : N/m, range : )                        </para>
        ///<para>                                                                                                                       </para>
        ///<para> @return Function result [方法执行结果]                                                                                 </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]                                                                         </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]                                                                               </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdTransparentControl(
            params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        if (parameters.Length == 4|| parameters.Length == 5)
                        {
                            FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicTransparentControlOriginPosition(
                           parameters[0]);

                            FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicTransparentControlM(
                                parameters[1]);

                            FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicTransparentControlB(
                                parameters[2]);

                            FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicTransparentControlK(
                                parameters[3]);

                            //limit command 
                            if (parameters.Length == 5)
                            {

                            }
                            else if (parameters.Length == 4)
                            {

                            }

                            FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetWorkMode(
                                FFTAICommunicationM1TaskInterfaceWorkMode.RELAY);

                            FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetRelayWorkMode(
                                FFTAICommunicationM1TaskInterfaceRelayWorkMode.TransparentControl);
                        }
                        else
                        {
                            return FunctionResult.FAIL;
                        }
                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        if (parameters.Length == 4|| parameters.Length == 5)
                        {
                            FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetSubtaskBasicTransparentControlOriginPosition(
                           parameters[0]);

                            FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetSubtaskBasicTransparentControlM(
                                parameters[1]);

                            FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetSubtaskBasicTransparentControlB(
                                parameters[2]);

                            FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetSubtaskBasicTransparentControlK(
                                parameters[3]);

                            //limit command 
                            if (parameters.Length == 5)
                            {

                            }
                            else if (parameters.Length == 4)
                            {

                            }

                            FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetWorkMode(
                                FFTAICommunicationM1_LTaskInterfaceWorkMode.RELAY);

                            FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetRelayWorkMode(
                                FFTAICommunicationM1_LTaskInterfaceRelayWorkMode.TransparentControl);
                        }
                        else
                        {
                            return FunctionResult.FAIL;
                        }
                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        if (parameters.Length == 8|| parameters.Length == 10)
                        {
                            FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicTransparentControlOriginPosition(
                            parameters[0], parameters[1]);

                            FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicTransparentControlM(
                            parameters[2], parameters[3]);

                            FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicTransparentControlB(
                            parameters[4], parameters[5]);

                            FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicTransparentControlK(
                            parameters[6], parameters[7]);

                            //limit command
                            if (parameters.Length == 10)
                            {
                                FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicTransparentControlLimitSpeed(
                                 parameters[8], parameters[9]);
                            }
                            else if (parameters.Length == 8)
                            {
                                FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicTransparentControlLimitSpeed(
                               0, 0);
                                
                            }

                            FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetWorkMode(
                           FFTAICommunicationM2TaskInterfaceWorkMode.RELAY);

                            FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetRelayWorkMode(
                             FFTAICommunicationM2TaskInterfaceRelayWorkMode.TransparentControl);
                        }
                        else
                        {
                            return FunctionResult.FAIL;
                        }

                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        if (parameters.Length == 24|| parameters.Length == 30)
                        {
                            FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetSubtaskBasicTransparentControlMoveOriginPosition(
                            parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], parameters[5]);

                            FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetSubtaskBasicTransparentControlMoveM(
                                parameters[6], parameters[7], parameters[8], parameters[9], parameters[10], parameters[11]);

                            FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetSubtaskBasicTransparentControlMoveB(
                                parameters[12], parameters[13], parameters[14], parameters[15], parameters[16], parameters[17]);

                            FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetSubtaskBasicTransparentControlMoveK(
                                parameters[18], parameters[19], parameters[20], parameters[21], parameters[22], parameters[23]);

                            //limit command
                            if (parameters.Length == 30)
                            {

                            }
                            else if(parameters.Length == 24)
                            {

                            }

                            FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetWorkMode(
                                FFTAICommunicationM6TaskInterfaceWorkMode.RELAY);

                            FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetRelayWorkMode(
                                FFTAICommunicationM6TaskInterfaceRelayWorkMode.TRANSPARENT_MOVE);
                        }
                        else
                        {
                            return FunctionResult.FAIL;
                        }

                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        if (parameters.Length == 16|| parameters.Length == 20)
                        {
                            FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetSubtaskBasicTransparentControlMoveOriginPosition(
                            parameters[0], parameters[1], parameters[2], parameters[3]);

                            FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetSubtaskBasicTransparentControlMoveM(
                                parameters[4], parameters[5], parameters[6], parameters[7]);

                            FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetSubtaskBasicTransparentControlMoveB(
                                parameters[8], parameters[9], parameters[10], parameters[11]);

                            FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetSubtaskBasicTransparentControlMoveK(
                                parameters[12], parameters[13], parameters[14], parameters[15]);

                            //limit command
                            if (parameters.Length == 20)
                            {

                            }
                            else if (parameters.Length == 16)
                            {

                            }

                            FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetWorkMode(
                                FFTAICommunicationX2TaskInterfaceWorkMode.RELAY);

                            FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetRelayWorkMode(
                                FFTAICommunicationX2TaskInterfaceRelayWorkMode.TRANSPARENT_MOVE);
                        }
                        else
                        {
                            return FunctionResult.FAIL;
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

        /// <summary>
        ///<para> @brief Set transparent control1 [设置k值缓慢增加的透明运动控制]                                                          </para>
        ///<para>                                                                                                                       </para>
        ///<para> for M2, the parameters are                                                                                            </para>
        ///<para>     - origin/target position x [原始/目标位置 x 轴] (type : float, unit : m, range : )                                 </para>
        ///<para>     - origin/target position y [原始/目标位置 y 轴] (type : float, unit : m, range : )                                 </para>
        ///<para>     - M (mass) x [模拟质量 x 轴] (type : float, unit : kg, range : )                                                   </para>
        ///<para>     - M (mass) y [模拟质量 y 轴] (type : float, unit : kg, range : )                                                   </para>
        ///<para>     - B (damping) x [模拟阻尼 x 轴] (type : float, unit : N/(m/s), range : )                                           </para>
        ///<para>     - B (damping) y [模拟阻尼 y 轴] (type : float, unit : N/(m/s), range : )                                           </para>
        ///<para>     - K (spring) x [模拟弹簧 x 轴] (type : float, unit : N/m, range : )                                                </para>
        ///<para>     - K (spring) y [模拟弹簧 y 轴] (type : float, unit : N/m, range : )                                                </para>
        ///<para>     - K (spring) y [模拟弹簧 y 轴] (type : float, unit : N/m, range : )                                                </para>
        ///<para>     - K (spring) y [模拟弹簧 y 轴] (type : float, unit : N/m, range : )                                                </para>
        ///<para>     - limitSpeed (limitSpeed) x [模拟弹簧 x 轴] (type : float, unit : m/s, range : )                                   </para>
        ///<para>     - limitSpeed (limitSpeed) x [模拟弹簧 x 轴] (type : float, unit : m/s, range : )                                   </para>
        ///<para>     - Period (interval)  [时间间隔] (type : float, unit : , range : )                                                  </para>
        ///<para>     - ChangeOfK (factor)  [每次逐渐增加的量] (type : float, unit : none, range : )                                     </para>
        ///<para> @return Function result [方法执行结果]                                                                                 </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]                                                                         </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]                                                                               </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdTransparentControl1(
           params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                         break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        if (parameters.Length==10|| parameters.Length == 12)
                        {
                            FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicTransparentControl1OriginPosition(
                          parameters[0], parameters[1]);

                            FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicTransparentControl1M(
                                parameters[2], parameters[3]);

                            FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicTransparentControl1B(
                                parameters[4], parameters[5]);

                            FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicTransparentControl1K(
                                parameters[6], parameters[7]);

                          
                            if (parameters.Length == 12)
                            {
                                FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicTransparentControl1LimitSpeed(
                                parameters[8], parameters[9]);

                                FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicTransparentControl1Period(
                                parameters[10]);

                                FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicTransparentControl1ChangeOfK(
                                parameters[11]);
                            }
                            else if(parameters.Length == 10)
                            {
                                FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicTransparentControl1LimitSpeed(
                                0, 0);

                                FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicTransparentControl1Period(
                                parameters[8]);

                                FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicTransparentControl1ChangeOfK(
                                parameters[9]);
                            }

                            FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetWorkMode(
                          FFTAICommunicationM2TaskInterfaceWorkMode.RELAY);

                            FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetRelayWorkMode(
                                FFTAICommunicationM2TaskInterfaceRelayWorkMode.TransparentControl1);
                        }
                        else
                        {
                            return FunctionResult.FAIL;
                        }
                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }
            return FunctionResult.SUCCESS;
        }


        /// <summary>
        ///<para>  @brief Set tunnel guidance control [通道引导控制]                                                        </para>
        ///<para>                                                                                                          </para>
        ///<para>  @details                                                                                                </para>
        ///<para>  for M1, the parameters are                                                                              </para>
        ///<para>      - Inapplicable [不适用]                                                                              </para>
        ///<para>                                                                                                          </para>
        ///<para>  for M2, the parameters are                                                                              </para>
        ///<para>      - Point  A position x [A点位置 x 坐标] (type : float, unit : m, range : )                            </para>
        ///<para>      - Point  A position y [A点位置 y 坐标] (type : float, unit : m, range : )                            </para>
        ///<para>      - Point  B position x [B点位置 x 坐标] (type : float, unit : m, range : )                            </para>
        ///<para>      - Point  B position y [B点位置 y 坐标] (type : float, unit : m, range : )                            </para>
        ///<para>      - M (mass) AB direction [模拟质量 AB 横轴] (type : float, unit : kg, range : )                       </para>
        ///<para>      - M (mass) AB vertical direction [模拟质量 AB 纵轴] (type : float, unit : kg, range : )              </para>
        ///<para>      - B (damping) AB direction [模拟阻尼 AB 横轴] (type : float, unit : N/(m/s), range : )               </para>
        ///<para>      - B (damping) AB vertical direction [模拟阻尼 AB 纵轴] (type : float, unit : N/(m/s), range : )      </para>
        ///<para>      - K (spring) AB direction [模拟弹簧 AB 横轴] (type : float, unit : N/m, range : )                    </para>
        ///<para>      - K (spring) AB vertical direction [模拟阻尼 AB 纵轴] (type : float, unit : N/m, range : )           </para>
        ///<para>                                                                                                          </para>
        ///<para>  @return Function result [方法执行结果]                                                                   </para>
        ///<para>  @retval FunctionResult.SUCCESS SUCCESS [成功]                                                           </para>
        ///<para>  @retval FunctionResult.FAIL FAIL [失败]                                                                 </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdTunnelGuidanceControl(
            params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        if (parameters.Length != 10)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicTunnelGuidanceControlPointA(
                            parameters[0], parameters[1]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicTunnelGuidanceControlPointB(
                            parameters[2], parameters[3]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicTunnelGuidanceControlM(
                            parameters[4], parameters[5]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicTunnelGuidanceControlB(
                            parameters[6], parameters[7]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicTunnelGuidanceControlK(
                            parameters[8], parameters[9]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM2TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM2TaskInterfaceRelayWorkMode.TunnelGuidanceControl);

                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para> @brief Set draw infinity curve control [画"无穷"符号]                  </para>
        ///<para>                                                                       </para>
        ///<para> @details                                                              </para>
        ///<para> for M1, the parameters are                                            </para>
        ///<para>     - Inapplicable [不适用]                                            </para>
        ///<para>                                                                       </para>
        ///<para> for M2, the parameters are                                            </para>
        ///<para>     - origin position x [原点 x 轴] (type : float, unit : m, range : ) </para>
        ///<para>     - origin position y [原点 y 轴] (type : float, unit : m, range : ) </para>
        ///<para>     - time period [周期] (type : float, unit : s, range : )           </para>
        ///<para>     - scale x [运动范围 x 轴] (type : float, unit : m, range : )       </para>
        ///<para>     - scale y [运动范围 y 轴] (type : float, unit : m, range : )       </para>
        ///<para>                                                                       </para>
        ///<para> @return Function result [方法执行结果]                                  </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]                          </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]                                </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdDrawInfinityCurveControl(
            params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        // check parameter length match
                        if (parameters.Length != 5)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicDrawInfinityCurveOriginPoint(
                            parameters[0], parameters[1]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicDrawInfinityCurveTimePeriod(
                            parameters[2]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicDrawInfinityCurveScale(
                            parameters[3], parameters[4]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM2TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM2TaskInterfaceRelayWorkMode.DrawInfinityCurve);

                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para> @brief Set draw infinity curve control [画椭圆/圆]                         </para>
        ///<para>                                                                           </para>
        ///<para> @details                                                                  </para>
        ///<para> for M1, the parameters are                                                </para>
        ///<para>     - Inapplicable [不适用]                                                </para>
        ///<para>                                                                           </para>
        ///<para> for M2, MODIFIED BY VINCENT for circle arc, the parameters are            </para>
        ///<para>     - circle center x [原点 x 轴] (type : float, unit : m, range : )       </para>
        ///<para>     - circle center y [原点 y 轴] (type : float, unit : m, range : )       </para>
        ///<para>     - speed [周期] (type : float, unit : in deg/s, range : )               </para>
        ///<para>     - start angle [运动范围 x 轴] (type : float, unit : degree, range : )  </para>
        ///<para>     - radius [运动范围 y 轴] (type : float, unit : m, range : )            </para>
        ///<para>                                                                           </para>
        ///<para> @return Function result [方法执行结果]                                     </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]                             </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]                                   </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdDrawCircleCurveControl(
            params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        // check parameter length match
                        if (parameters.Length != 5)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicDrawCircleCurveOriginPoint(
                            parameters[0], parameters[1]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicDrawCircleCurveTimePeriod(
                            parameters[2]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicDrawCircleCurveScale(
                            parameters[3], parameters[4]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM2TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM2TaskInterfaceRelayWorkMode.DrawCircleCurve);

                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para>  @brief Set kinetic control with sensor [设置有传感器动力运动控制(合并AssistControl和ResistControl)]      </para>
        ///<para>                                                                                                        </para>
        ///<para>  @details                                                                                              </para>
        ///<para>  for M1, the parameters are                                                                            </para>
        ///<para>      - assist torque [动力力矩] (type : float, unit : Nm, range : )                                     </para>
        ///<para>                                                                                                        </para>
        ///<para>  for M2, the parameters are                                                                            </para>
        ///<para>      - assist force x [动力力量 x 轴] (type : float, unit : N, range : )                                </para>
        ///<para>      - assist force y [动力力量 y 轴] (type : float, unit : N, range : )                                </para>
        ///<para>                                                                                                        </para>
        ///<para>  @return Function result [方法执行结果]                                                                 </para>
        ///<para>  @retval FunctionResult.SUCCESS SUCCESS [成功]                                                         </para>
        ///<para>  @retval FunctionResult.FAIL FAIL [失败]                                                               </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdKineticControlWithSensor(
            params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        if (parameters.Length != 4)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetSubtaskBasicActiveMoveKinetic(
                            parameters[0], parameters[1], parameters[2], parameters[3]);

                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationH4TaskInterfaceWorkMode.ACTIVE_MOVE);

                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        if (parameters.Length != 1)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicKineticControlWithSensorForce(
                            parameters[0]);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM1TaskInterfaceRelayWorkMode.KineticControlWithSensor);

                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        if (parameters.Length != 1)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetSubtaskBasicKineticControlWithSensorForce(
                            parameters[0]);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceRelayWorkMode.KineticControlWithSensor);

                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        if (parameters.Length != 2)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicKineticControlWithSensorForce(
                            parameters[0], parameters[1]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM2TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM2TaskInterfaceRelayWorkMode.KineticControlWithSensor);

                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        if (parameters.Length != 6)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetSubtaskBasicActiveMoveKinetic(
                            parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], parameters[5]);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM6TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM6TaskInterfaceRelayWorkMode.ACTIVE_MOVE);

                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        if (parameters.Length != 4)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetSubtaskBasicActiveMoveKinetic(
                            parameters[0], parameters[1], parameters[2], parameters[3]);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationX2TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationX2TaskInterfaceRelayWorkMode.ACTIVE_MOVE);

                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para> @brief Set transparent control With Limit Spring Force [设置带弹簧弹力限制的透明运动控制]        </para>
        ///<para>                                                                                               </para>
        ///<para> @details                                                                                      </para>
        ///<para> for M1, the parameters are                                                                    </para>
        ///<para>     - origin/target position [原始/目标位置] (type : float, unit : m, range : )                </para>
        ///<para>     - M (mass) [模拟质量] (type : float, unit : kg, range : )                                  </para>
        ///<para>     - B (damping) [模拟阻尼] (type : float, unit : N/(m/s), range : )                          </para>
        ///<para>     - K (spring) [模拟弹簧] (type : float, unit : N/m, range : )                               </para>
        ///<para>     - Limit Spring Force [弹簧弹力限制] (type : float, unit : N, range : )                     </para>
        ///<para>                                                                                               </para>
        ///<para> for M2, the parameters are                                                                    </para>
        ///<para>     - origin/target position x [原始/目标位置 x 轴] (type : float, unit : m, range : )         </para>
        ///<para>     - origin/target position y [原始/目标位置 y 轴] (type : float, unit : m, range : )         </para>
        ///<para>     - M (mass) x [模拟质量 x 轴] (type : float, unit : kg, range : )                           </para>
        ///<para>     - M (mass) y [模拟质量 y 轴] (type : float, unit : kg, range : )                           </para>
        ///<para>     - B (damping) x [模拟阻尼 x 轴] (type : float, unit : N/(m/s), range : )                   </para>
        ///<para>     - B (damping) y [模拟阻尼 y 轴] (type : float, unit : N/(m/s), range : )                   </para>
        ///<para>     - K (spring) x [模拟弹簧 x 轴] (type : float, unit : N/m, range : )                        </para>
        ///<para>     - K (spring) y [模拟阻尼 y 轴] (type : float, unit : N/m, range : )                        </para>
        ///<para>     - Limit Spring Force x [弹簧弹力限制 x 轴] (type : float, unit : N, range : )              </para>
        ///<para>     - Limit Spring Force y [弹簧弹力限制 x 轴] (type : float, unit : N, range : )              </para>
        ///<para>                                                                                               </para>
        ///<para> @return Function result [方法执行结果]                                                         </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]                                                 </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]                                                       </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdTransparentControlWithLimitSpringForce(
            params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        if (parameters.Length != 5)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicTransparentControlWithLimitSpringForceOriginPosition(
                            parameters[0]);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicTransparentControlWithLimitSpringForceM(
                            parameters[1]);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicTransparentControlWithLimitSpringForceB(
                            parameters[2]);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicTransparentControlWithLimitSpringForceK(
                            parameters[3]);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicTransparentControlWithLimitSpringForceLimitSpringForce(
                            parameters[4]);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM1TaskInterfaceRelayWorkMode.TransparentControlWithLimitSpringForce);

                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        if (parameters.Length != 5)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetSubtaskBasicTransparentControlWithLimitSpringForceOriginPosition(
                            parameters[0]);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetSubtaskBasicTransparentControlWithLimitSpringForceM(
                            parameters[1]);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetSubtaskBasicTransparentControlWithLimitSpringForceB(
                            parameters[2]);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetSubtaskBasicTransparentControlWithLimitSpringForceK(
                            parameters[3]);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetSubtaskBasicTransparentControlWithLimitSpringForceLimitSpringForce(
                            parameters[4]);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceRelayWorkMode.TransparentControlWithLimitSpringForce);

                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        if (parameters.Length != 10)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicTransparentControlWithLimitSpringForceOriginPosition(
                            parameters[0], parameters[1]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicTransparentControlWithLimitSpringForceM(
                            parameters[2], parameters[3]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicTransparentControlWithLimitSpringForceB(
                            parameters[4], parameters[5]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicTransparentControlWithLimitSpringForceK(
                            parameters[6], parameters[7]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicTransparentControlWithLimitSpringForceLimitSpringForce(
                            parameters[8], parameters[9]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM2TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM2TaskInterfaceRelayWorkMode.TransparentControlWithLimitSpringForce);

                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para> @brief Set minimum jerk trajectory control [设置最小 jerk 运动控制]      </para>
        ///<para>                                                                         </para>
        ///<para> @details                                                                </para>
        ///<para> for M1, the parameters are                                              </para>
        ///<para>                                                                         </para>
        ///<para> for M2, the parameters are                                              </para>
        ///<para>     - point  A x [点A位置 x 轴] (type : float, unit : m, range : )       </para>
        ///<para>     - point  A y [点A位置 y 轴] (type : float, unit : m, range : )       </para>
        ///<para>     - point  B x [点A位置 x 轴] (type : float, unit : m, range : )       </para>
        ///<para>     - point  B y [点A位置 y 轴] (type : float, unit : m, range : )       </para>
        ///<para>     - total time [规划总时间] (type : float, unit : m, range : )         </para>
        ///<para>                                                                         </para>
        ///<para> @return Function result [方法执行结果]                                    </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]                            </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]                                  </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdMinimumJerkTrajectoryControl(
            params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        if (parameters.Length != 5)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicMinimumJerkTrajectoryControlPointA(
                            parameters[0], parameters[1]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicMinimumJerkTrajectoryControlPointB(
                            parameters[2], parameters[3]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicMinimumJerkTrajectoryControlInitialTime();

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicMinimumJerkTrajectoryControlTotalTime(
                            parameters[4]);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM2TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM2TaskInterfaceRelayWorkMode.MinimumJerkTrajectoryControl);

                        break;
                    }
                case DynaLinkHS.RobotType.M3:
                    {

                        if (parameters.Length != 7)
                        {
                            return FunctionResult.FAIL;
                        }

                        FFTAICommunicationManager.getInstance().M3TaskInterface.RequestSetSubtaskBasicMinimumJerkTrajectoryControlPointA(
                            parameters[0], parameters[1], parameters[2]);

                        FFTAICommunicationManager.getInstance().M3TaskInterface.RequestSetSubtaskBasicMinimumJerkTrajectoryControlPointB(
                            parameters[3], parameters[4], parameters[5]);

                        FFTAICommunicationManager.getInstance().M3TaskInterface.RequestSetSubtaskBasicMinimumJerkTrajectoryControlInitialTime();

                        FFTAICommunicationManager.getInstance().M3TaskInterface.RequestSetSubtaskBasicMinimumJerkTrajectoryControlTotalTime(
                            parameters[6]);

                        FFTAICommunicationManager.getInstance().M3TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM2TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M3TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM2TaskInterfaceRelayWorkMode.MinimumJerkTrajectoryControl);

                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para> @brief Set passive Gait trajectory  control [步态跟踪]                </para>
        ///<para>                                                                      </para>
        ///<para> @details                                                             </para>
        ///<para>only for M1, the parameters are                                       </para>
        ///<para>                                                                      </para>
        ///<para>                                                                      </para>
        ///<para>     - point  A x [点A位置 x 轴] (type : float, unit : m, range : )    </para>
        ///<para>     - point  A y [点A位置 y 轴] (type : float, unit : m, range : )    </para>
        ///<para>     - point  B x [点A位置 x 轴] (type : float, unit : m, range : )    </para>
        ///<para>     - point  B y [点A位置 y 轴] (type : float, unit : m, range : )    </para>
        ///<para>     - total time [规划总时间] (type : float, unit : m, range : )      </para>
        ///<para>                                                                      </para>
        ///<para> @return Function result [方法执行结果]                                </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]                        </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]                              </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdPassiveGaitTrajectoryControl(
              params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicGaitTarjectoryPeriodTimeControl(
                            parameters[0]);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetWorkMode(
                          FFTAICommunicationM1TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM1TaskInterfaceRelayWorkMode.PassiveGaitTrajectory);
                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para>  @brief Set sin function control [步态跟踪]                           </para>
        ///<para>                                                                      </para>
        ///<para>  @details                                                            </para>
        ///<para> only for M1, the parameters are                                      </para>
        ///<para>                                                                      </para>
        ///<para>                                                                      </para>
        ///<para>      - point  A x [点A位置 x 轴] (type : float, unit : m, range : )   </para>
        ///<para>      - point  A y [点A位置 y 轴] (type : float, unit : m, range : )   </para>
        ///<para>      - point  B x [点A位置 x 轴] (type : float, unit : m, range : )   </para>
        ///<para>      - point  B y [点A位置 y 轴] (type : float, unit : m, range : )   </para>
        ///<para>      - total time [规划总时间] (type : float, unit : m, range : )     </para>
        ///<para>                                                                      </para>
        ///<para>  @return Function result [方法执行结果]                               </para>
        ///<para>  @retval FunctionResult.SUCCESS SUCCESS [成功]                       </para>
        ///<para>  @retval FunctionResult.FAIL FAIL [失败]                             </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdSinFunctionControl(
              params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicSinFuctionKControl(
                            parameters[0]);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetSubtaskBasicSinFuctionPeriodTimeControl(
                            parameters[1]);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetWorkMode(
                          FFTAICommunicationM1TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM1TaskInterfaceRelayWorkMode.SinFunctionControl);
                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        public static int CmdPassiveExoMotusControl(
            params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        if (parameters.Length != 7)
                        {
                            return FunctionResult.FAIL;
                        }
                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetSubtaskWalkPassiveParameterThighLength(parameters[0]);
                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetSubtaskWalkPassiveParameterShankLength(parameters[1]);
                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetSubtaskWalkPassiveParameterStepLength(parameters[2]);
                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetSubtaskWalkPassiveParameterStepHeight(parameters[3]);

                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetSubtaskWalkPassiveParameterStepTime(parameters[4]);
                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetSubtaskWalkPassiveParameterSitTime(parameters[5]);
                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetSubtaskWalkPassiveParameterStandTime(parameters[6]);
                        //FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetSubtaskWalkPassiveParameterTimeProportion(parameters[7]);
                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetWorkMode(FFTAICommunicationH4TaskInterfaceWorkMode.WALK_PASSIVE_1);
                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }
            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para> @brief Set servo on [设置机器电机使能]                </para>
        ///<para>                                                      </para>
        ///<para> @return Function result [方法执行结果]                </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]        </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]              </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdServoOn(
            params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationH4TaskInterfaceWorkMode.SERVO_ON);

                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM1TaskInterfaceRelayWorkMode.ServoOn);

                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceRelayWorkMode.ServoOn);

                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM2TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM2TaskInterfaceRelayWorkMode.ServoOn);

                        break;
                    }
                case DynaLinkHS.RobotType.M3:
                    {
                        FFTAICommunicationManager.getInstance().M3TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM3TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M3TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM3TaskInterfaceRelayWorkMode.ServoOn);

                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM6TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM6TaskInterfaceRelayWorkMode.SERVO_ON);

                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationX2TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationX2TaskInterfaceRelayWorkMode.SERVO_ON);

                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para> @brief Set servo off [设置机器电机失能]            </para>
        ///<para>                                                   </para>
        ///<para> @return Function result [方法执行结果]             </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]     </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]           </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdServoOff(
            params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationH4TaskInterfaceWorkMode.SERVO_OFF);

                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM1TaskInterfaceRelayWorkMode.ServoOff);

                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceRelayWorkMode.ServoOff);

                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM2TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM2TaskInterfaceRelayWorkMode.ServoOff);

                        break;
                    }
                case DynaLinkHS.RobotType.M3:
                    {
                        FFTAICommunicationManager.getInstance().M3TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM3TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M3TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM3TaskInterfaceRelayWorkMode.ServoOff);

                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM6TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM6TaskInterfaceRelayWorkMode.SERVO_OFF);

                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationX2TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationX2TaskInterfaceRelayWorkMode.SERVO_OFF);

                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para>  @brief Set pause motion [设置机器电机锁住]       </para>
        ///<para>                                                  </para>
        ///<para>  @return Function result [方法执行结果]           </para>
        ///<para>  @retval FunctionResult.SUCCESS SUCCESS [成功]   </para>
        ///<para>  @retval FunctionResult.FAIL FAIL [失败]         </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdPauseMotion(
            params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.M1:
                    {
                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM1TaskInterfaceRelayWorkMode.PauseMotion);

                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceRelayWorkMode.PauseMotion);

                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM2TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM2TaskInterfaceRelayWorkMode.PauseMotion);

                        break;
                    }
                case DynaLinkHS.RobotType.M3:
                    {
                        FFTAICommunicationManager.getInstance().M3TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM3TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M3TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM3TaskInterfaceRelayWorkMode.PauseMotion);

                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetWorkMode(
                         FFTAICommunicationM6TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM6TaskInterfaceRelayWorkMode.PAUSE_MOTION);
                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetWorkMode(
                          FFTAICommunicationX2TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationX2TaskInterfaceRelayWorkMode.PAUSE_MOTION);

                        break;
                    }
                case DynaLinkHS.RobotType.H4:
                    {
                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetWorkMode(
                       FFTAICommunicationH4TaskInterfaceWorkMode.PAUSE_MOTION);
                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para> @brief Set clear alarm [设置清楚警告]           </para>
        ///<para>                                                </para>
        ///<para> @note Not used right now [暂未使用]            </para>
        ///<para>                                                </para>
        ///<para> @return Function result [方法执行结果]          </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]  </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]        </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdClearAlarm(
            params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationH4TaskInterfaceWorkMode.CLEAR_ALARM);

                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM1TaskInterfaceRelayWorkMode.ClearAlarm);

                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceRelayWorkMode.ClearAlarm);

                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM2TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM2TaskInterfaceRelayWorkMode.ClearAlarm);

                        break;
                    }
                case DynaLinkHS.RobotType.M3:
                    {
                        FFTAICommunicationManager.getInstance().M3TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM3TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M3TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM3TaskInterfaceRelayWorkMode.ClearAlarm);

                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM6TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM6TaskInterfaceRelayWorkMode.CLEAR_ALARM);

                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationX2TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationX2TaskInterfaceRelayWorkMode.CLEAR_ALARM);

                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para>  @brief Set clear fault [设置清除驱动器错误]     </para>
        ///<para>                                                 </para>
        ///<para>  @return Function result [方法执行结果]          </para>
        ///<para>  @retval FunctionResult.SUCCESS SUCCESS [成功]  </para>
        ///<para>  @retval FunctionResult.FAIL FAIL [失败]        </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdClearFault(
            params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationH4TaskInterfaceWorkMode.CLEAR_FAULT);

                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM1TaskInterfaceRelayWorkMode.ClearFault);

                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceRelayWorkMode.ClearFault);

                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM2TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM2TaskInterfaceRelayWorkMode.ClearFault);

                        break;
                    }
                case DynaLinkHS.RobotType.M3:
                    {
                        FFTAICommunicationManager.getInstance().M3TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM3TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M3TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM3TaskInterfaceRelayWorkMode.ClearFault);

                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM6TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM6TaskInterfaceRelayWorkMode.CLEAR_FAULT);

                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationX2TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationX2TaskInterfaceRelayWorkMode.CLEAR_FAULT);

                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para>  @brief Set clear pinched [清除夹手的标志位]     </para>
        ///<para>                                                 </para>
        ///<para>  @return Function result [方法执行结果]          </para>
        ///<para>  @retval FunctionResult.SUCCESS SUCCESS [成功]  </para>
        ///<para>  @retval FunctionResult.FAIL FAIL [失败]        </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdClearPinched()
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.M2:
                    {
                        FFTAICommunicationManager.getInstance().M2RobotInterface.RequestSetFlagPinched();

                    }
                    break;
                default:
                    {
                        return FunctionResult.SUCCESS;
                    }
            }
            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para> @brief Set calibrate sensors [设置校准传感器]    </para>
        ///<para>                                                 </para>
        ///<para> @return Function result [方法执行结果]           </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]   </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]         </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdCalibrateSensor(
            params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        FFTAICommunicationManager.getInstance().H4RobotInterface.RequestSetButtonSensorCalibrate();

                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        FFTAICommunicationManager.getInstance().M1RobotInterface.RequestSetButtonSensorCalibrate();

                        FFTAICommunicationManager.getInstance().M1RobotInterface.RequestSetTorqueSensorCalibrate();

                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        FFTAICommunicationManager.getInstance().M1_LRobotInterface.RequestSetButtonSensorCalibrate();

                        FFTAICommunicationManager.getInstance().M1_LRobotInterface.RequestSetTorqueSensorCalibrate();

                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        FFTAICommunicationManager.getInstance().M2RobotInterface.RequestSetButtonSensorCalibrate();

                        FFTAICommunicationManager.getInstance().M2RobotInterface.RequestSetForceSensorCalibrate();

                        break;
                    }
                case DynaLinkHS.RobotType.M3:
                    {
                        FFTAICommunicationManager.getInstance().M3RobotInterface.RequestSetButtonSensorCalibrate();

                        FFTAICommunicationManager.getInstance().M3RobotInterface.RequestSetForceSensorCalibrate();

                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        FFTAICommunicationManager.getInstance().M6RobotInterface.RequestSetButtonSensorCalibrate();

                        FFTAICommunicationManager.getInstance().M6RobotInterface.RequestSetForceSensorCalibrate();

                        FFTAICommunicationManager.getInstance().M6RobotInterface.RequestSetFootPressureSensorCalibrate();

                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        FFTAICommunicationManager.getInstance().X2RobotInterface.RequestSetButtonSensorCalibrate();

                        FFTAICommunicationManager.getInstance().X2RobotInterface.RequestSetForceSensorCalibrate();

                        FFTAICommunicationManager.getInstance().X2RobotInterface.RequestSetFootPressureSensorCalibrate();

                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para> @brief Set find home position [设置寻找零点位置]  </para>
        ///<para>                                                  </para>
        ///<para> @return Function result [方法执行结果]            </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]    </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]          </para>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int CmdFindHomePosition(
            params float[] parameters)
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.H4:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.M1:
                    {
                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M1TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM1TaskInterfaceRelayWorkMode.FindHome);
                        break;
                    }
                case DynaLinkHS.RobotType.M1_L:
                    {
                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M1_LTaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM1_LTaskInterfaceRelayWorkMode.FindHome);

                        break;
                    }
                case DynaLinkHS.RobotType.M2:
                    {
                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetSubtaskBasicFindHomeRequestKinetic(
                            50 /* unit : N */,
                            50 /* unit : N */);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM2TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M2TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM2TaskInterfaceRelayWorkMode.FindHome);

                        break;
                    }
                case DynaLinkHS.RobotType.M3:
                    {
                        FFTAICommunicationManager.getInstance().M3TaskInterface.RequestSetSubtaskBasicFindHomeRequestKinetic(
                            0.5f /* unit : Nm */,
                            0.5f /* unit : Nm */,
                            0.5f /* unit : Nm */);

                        FFTAICommunicationManager.getInstance().M3TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM3TaskInterfaceWorkMode.RELAY);

                        FFTAICommunicationManager.getInstance().M3TaskInterface.RequestSetRelayWorkMode(
                            FFTAICommunicationM3TaskInterfaceRelayWorkMode.FindHome);

                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X1:
                    {
                        break;
                    }
                case DynaLinkHS.RobotType.X2:
                    {
                        break;
                    }
                default:
                    {
                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para> @brief SET command sit [坐下指令]                         </para>
        ///<para>                                                           </para>
        ///<para> @return Function result [方法执行结果]                     </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]             </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]                    </para>
        /// </summary>
        /// <returns></returns>
        public static int CmdSit()
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.X2:
                    {
                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationX2TaskInterfaceWorkMode.MASTER_CONTROL);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetMasterControlWorkMode(
                            FFTAICommunicationX2TaskInterfaceMasterControlWorkMode.WALK_PASSIVE_1);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetMasterControlWalkPassive1Command(
                            FFTAICommunicationX2TaskInterfaceMasterControlWalkPassive1Command.SIT);

                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM6TaskInterfaceWorkMode.MASTER_CONTROL);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetMasterControlWorkMode(
                            FFTAICommunicationM6TaskInterfaceMasterControlWorkMode.WALK_PASSIVE_1);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetMasterControlWalkPassive1Command(
                            FFTAICommunicationM6TaskInterfaceMasterControlWalkPassive1Command.SIT);

                        break;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para>  @brief SET commnad stand [站立指令]               </para>
        ///<para>                                                   </para>
        ///<para>  @return Function result [方法执行结果]            </para>
        ///<para>  @retval FunctionResult.SUCCESS SUCCESS [成功]     </para>
        ///<para>  @retval FunctionResult.FAIL FAIL [失败]           </para>
        /// </summary>
        /// <returns></returns>
        public static int CmdStand()
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.X2:
                    {
                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationX2TaskInterfaceWorkMode.MASTER_CONTROL);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetMasterControlWorkMode(
                            FFTAICommunicationX2TaskInterfaceMasterControlWorkMode.WALK_PASSIVE_1);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetMasterControlWalkPassive1Command(
                            FFTAICommunicationX2TaskInterfaceMasterControlWalkPassive1Command.STAND);

                        break;
                    }
                case DynaLinkHS.RobotType.H4:
                    {
                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationH4TaskInterfaceWorkMode.PASSIVE_STAND);
                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM6TaskInterfaceWorkMode.MASTER_CONTROL);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetMasterControlWorkMode(
                            FFTAICommunicationM6TaskInterfaceMasterControlWorkMode.WALK_PASSIVE_1);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetMasterControlWalkPassive1Command(
                            FFTAICommunicationM6TaskInterfaceMasterControlWalkPassive1Command.STAND);

                        break;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para>  @brief SET commnad stop [停止指令]               </para>
        ///<para>                                                  </para>
        ///<para>  @return Function result [方法执行结果]           </para>
        ///<para>  @retval FunctionResult.SUCCESS SUCCESS [成功]    </para>
        ///<para>  @retval FunctionResult.FAIL FAIL [失败]          </para>
        /// </summary>
        /// <returns></returns>
        public static int CmdStop()
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.X2:
                    {
                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationX2TaskInterfaceWorkMode.MASTER_CONTROL);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetMasterControlWorkMode(
                            FFTAICommunicationX2TaskInterfaceMasterControlWorkMode.WALK_PASSIVE_1);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetMasterControlWalkPassive1Command(
                            FFTAICommunicationX2TaskInterfaceMasterControlWalkPassive1Command.STOP);

                        break;
                    }
                case DynaLinkHS.RobotType.H4:
                    {
                        FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetWorkMode(
                       FFTAICommunicationH4TaskInterfaceWorkMode.SERVO_OFF);
                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM6TaskInterfaceWorkMode.MASTER_CONTROL);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetMasterControlWorkMode(
                            FFTAICommunicationM6TaskInterfaceMasterControlWorkMode.WALK_PASSIVE_1);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetMasterControlWalkPassive1Command(
                            FFTAICommunicationM6TaskInterfaceMasterControlWalkPassive1Command.STOP);

                        break;
                    }
            }

            return FunctionResult.SUCCESS;
        }


        /// <summary>
        ///<para> @brief SET commnad walk [行走指令]              </para>
        ///<para>                                                 </para>
        ///<para> @return Function result [方法执行结果]           </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]   </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]         </para>
        /// </summary>
        /// <returns></returns>
        public static int CmdWalk()
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case DynaLinkHS.RobotType.X2:
                    {
                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationX2TaskInterfaceWorkMode.MASTER_CONTROL);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetMasterControlWorkMode(
                            FFTAICommunicationX2TaskInterfaceMasterControlWorkMode.WALK_PASSIVE_1);

                        FFTAICommunicationManager.getInstance().X2TaskInterface.RequestSetMasterControlWalkPassive1Command(
                            FFTAICommunicationX2TaskInterfaceMasterControlWalkPassive1Command.WALK);

                        break;
                    }
                case DynaLinkHS.RobotType.M6:
                    {
                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetWorkMode(
                            FFTAICommunicationM6TaskInterfaceWorkMode.MASTER_CONTROL);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetMasterControlWorkMode(
                            FFTAICommunicationM6TaskInterfaceMasterControlWorkMode.WALK_PASSIVE_1);

                        FFTAICommunicationManager.getInstance().M6TaskInterface.RequestSetMasterControlWalkPassive1Command(
                            FFTAICommunicationM6TaskInterfaceMasterControlWalkPassive1Command.WALK);

                        break;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para> @brief SET commnad walk [行走指令]              </para>
        ///<para>                                                 </para>
        ///<para> @return Function result [方法执行结果]           </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]   </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]         </para>
        /// </summary>
        /// <returns></returns>
        public static int CmdExoStart()
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case RobotType.NONE:
                    break;
                case RobotType.H1:
                    break;
                case RobotType.H4:
                    FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetWorkMode(
                           FFTAICommunicationH4TaskInterfaceWorkMode.WALK_PASSIVE_1);
                    break;
                case RobotType.M1:
                    break;
                case RobotType.M1_L:
                    break;
                case RobotType.M2:
                    break;
                case RobotType.M3:
                    break;
                case RobotType.M4:
                    break;
                case RobotType.M6:
                    break;
                case RobotType.X1:
                    break;
                case RobotType.X2:
                    break;
                case RobotType.All:
                    break;
                default:
                    break;
            }
            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para> @brief set commnad sit of exoskeleton [执行外骨骼子循环里面的“坐”指令]              </para>
        ///<para>                                                 </para>
        ///<para> @return Function result [方法执行结果]           </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]   </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]         </para>
        /// </summary>
        /// <returns></returns>
        public static int CmdExoSit()
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case RobotType.NONE:
                    break;
                case RobotType.H1:
                    break;
                case RobotType.H4:

                    FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetSubtaskWalkPassiveCommand(
                        FFTAICommunicationH4TaskInterfaceMasterControlWalkPassive1Command.SIT);
                    break;
                case RobotType.M1:
                    break;
                case RobotType.M1_L:
                    break;
                case RobotType.M2:
                    break;
                case RobotType.M3:
                    break;
                case RobotType.M4:
                    break;
                case RobotType.M6:
                    break;
                case RobotType.X1:
                    break;
                case RobotType.X2:
                    break;
                case RobotType.All:
                    break;
                default:
                    break;
            }
            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para> @brief set commnad stand of exoskeleton [执行外骨骼子循环里面的“站”指令]              </para>
        ///<para>                                                 </para>
        ///<para> @return Function result [方法执行结果]           </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]   </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]         </para>
        /// </summary>
        /// <returns></returns>
        public static int CmdExoStand()
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case RobotType.NONE:
                    break;
                case RobotType.H1:
                    break;
                case RobotType.H4:

                    FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetSubtaskWalkPassiveCommand(
                        FFTAICommunicationH4TaskInterfaceMasterControlWalkPassive1Command.STAND);
                    break;
                case RobotType.M1:
                    break;
                case RobotType.M1_L:
                    break;
                case RobotType.M2:
                    break;
                case RobotType.M3:
                    break;
                case RobotType.M4:
                    break;
                case RobotType.M6:
                    break;
                case RobotType.X1:
                    break;
                case RobotType.X2:
                    break;
                case RobotType.All:
                    break;
                default:
                    break;
            }
            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para> @brief set commnad walk of exoskeleton [执行外骨骼子循环里面的“走”指令]              </para>
        ///<para>                                                 </para>
        ///<para> @return Function result [方法执行结果]           </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]   </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]         </para>
        /// </summary>
        /// <returns></returns>
        public static int CmdExoWalk()
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case RobotType.NONE:
                    break;
                case RobotType.H1:
                    break;
                case RobotType.H4:

                    FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetSubtaskWalkPassiveCommand(
                        FFTAICommunicationH4TaskInterfaceMasterControlWalkPassive1Command.WALK);
                    break;
                case RobotType.M1:
                    break;
                case RobotType.M1_L:
                    break;
                case RobotType.M2:
                    break;
                case RobotType.M3:
                    break;
                case RobotType.M4:
                    break;
                case RobotType.M6:
                    break;
                case RobotType.X1:
                    break;
                case RobotType.X2:
                    break;
                case RobotType.All:
                    break;
                default:
                    break;
            }
            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para> @brief set commnad pause of exoskeleton [执行外骨骼子循环里面的“暂停”指令]              </para>
        ///<para>                                                 </para>
        ///<para> @return Function result [方法执行结果]           </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]   </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]         </para>
        /// </summary>
        /// <returns></returns>
        public static int CmdExoPause()
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case RobotType.NONE:
                    break;
                case RobotType.H1:
                    break;
                case RobotType.H4:
                    FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetSubtaskWalkPassiveCommand(
                        FFTAICommunicationH4TaskInterfaceMasterControlWalkPassive1Command.PAUSE);
                    break;
                case RobotType.M1:
                    break;
                case RobotType.M1_L:
                    break;
                case RobotType.M2:
                    break;
                case RobotType.M3:
                    break;
                case RobotType.M4:
                    break;
                case RobotType.M6:
                    break;
                case RobotType.X1:
                    break;
                case RobotType.X2:
                    break;
                case RobotType.All:
                    break;
                default:
                    break;
            }
            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///<para> @brief set commnad stop of exoskeleton [执行外骨骼子循环里面的“停止”指令]              </para>
        ///<para>                                                 </para>
        ///<para> @return Function result [方法执行结果]           </para>
        ///<para> @retval FunctionResult.SUCCESS SUCCESS [成功]   </para>
        ///<para> @retval FunctionResult.FAIL FAIL [失败]         </para>
        /// </summary>
        /// <returns></returns>
        public static int CmdExoStop()
        {
            switch (DynaLinkHS.StatusApp.RobotType)
            {
                case RobotType.NONE:
                    break;
                case RobotType.H1:
                    break;
                case RobotType.H4:
                    FFTAICommunicationManager.getInstance().H4TaskInterface.RequestSetSubtaskWalkPassiveCommand(
                        FFTAICommunicationH4TaskInterfaceMasterControlWalkPassive1Command.STOP);
                    break;
                case RobotType.M1:
                    break;
                case RobotType.M1_L:
                    break;
                case RobotType.M2:
                    break;
                case RobotType.M3:
                    break;
                case RobotType.M4:
                    break;
                case RobotType.M6:
                    break;
                case RobotType.X1:
                    break;
                case RobotType.X2:
                    break;
                case RobotType.All:
                    break;
                default:
                    break;
            }
            return FunctionResult.SUCCESS;
        }


        /// <summary>
        /// 设置底层IP地址,只提供最后一位的数值修改。例：192.168.102.200  本方法只修改最后一位的数值，如果输入88，就变更为192.168.102.88
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        public static int CmdSetIPAddress(string ipAddress)
        {
            float ip = float.Parse(ipAddress);
            FFTAICommunicationManager.getInstance().appInterface.RequestSetIPAddress(ip);
            return FunctionResult.SUCCESS;
        }

        /// <summary>
        /// 设置通信协议的版本
        /// </summary>
        /// <param name="protocolVersion"></param>
        /// <returns></returns>
        public static int CmdSetProtocolVersion(ProtocolVersion protocolVersion)
        {
            switch (protocolVersion)
            {
                case ProtocolVersion.Version2:
                    FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion = FFTAICommunicationProtocolVersion.VERSION_2;
                    break;
                case ProtocolVersion.Version3:
                    FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion = FFTAICommunicationProtocolVersion.VERSION_3;
                    break;
                default:
                   return FFTAICommunicationOperationResult.FAIL;
            }
           return FFTAICommunicationOperationResult.SUCCESS;
        }
        #endregion
    }
}

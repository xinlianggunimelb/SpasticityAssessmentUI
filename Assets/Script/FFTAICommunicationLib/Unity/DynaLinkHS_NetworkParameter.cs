using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace FFTAICommunicationLib
{
    public partial class DynaLinkHS
    {
        #region Network
        /// <summary>
        /// Status Network Patamater
        /// </summary>
        public class StatusNetwork
        {
            /// <summary>
            ///  @brief Server address IP [服务器IP地址]
            /// </summary>
            public static string ServerAddressIp = "192.168.102.200";

            /// <summary>
            ///  @brief Server address port [服务器端口]
            /// </summary>
            public static int ServerAddressPort = 4196;
        }
        #endregion

        #region IAP
        /// <summary>
        /// @brief The status of In-Application-Programming(IAP) process ["在线编程(IAP)"状态结构体]
        /// </summary>
        public class StatusIAP
        {
            /// <summary>
            /// @brief Hardware version [IAP 硬件版本]
            /// </summary>
            public static uint HardwareVersion = 0;

            /// <summary>
            /// @brief Hardware version [IAP 硬件版本]
            /// </summary>
            public static string HardwareVersionString = "0.0.0.0";

            /// <summary>
            /// @brief Software version [IAP 软件版本]
            /// </summary>
            public static uint SoftwareVersion = 0;

            /// <summary>
            /// @brief Software version [IAP 软件版本]
            /// </summary>
            public static string SoftwareVersionString = "0.0.0.0";

            /// <summary>
            /// @brief Software version [通信协议版本]
            /// </summary>
            public static int ProtocolVersion = 0;

            /// <summary>
            /// @brief Software version [通信协议版本]
            /// </summary>
            public static string ProtocolVersionString = "0.0.0.0";

            /// <summary>
            /// <para>@brief The current boot mode of the MMU [当前启动模式]                                                               </para>
            /// <para>@details                                                                                                            </para>
            /// <para>   - DynaLinkHSPara.IAPBootMode.IAP The system will run in IAP mode next time [表示下一次启动程序将运行在 IAP 模式下]  </para>
            /// <para>    - DynaLinkHSPara.IAPBootMode.APP The system will run in APP mode next time [表示下一次启动程序将运行在 APP 模式下] </para>
            /// </summary>
            public static DynaLinkHS.IAPBootMode IAPBootMode = DynaLinkHS.IAPBootMode.NONE;

            /// <summary>
            ///<para>@brief The current work status of the MMU [当前运行状态]                                            </para>
            ///<para>@details                                                                                           </para>
            ///<para>    - DynaLinkHSPara.IAPWorkStatus.IAP The system is now in IAP mode [表示当前程序运行在 IAP 模式下] </para>
            ///<para>    - DynaLinkHSPara.IAPWorkStatus.APP The system is now in APP mode [表示当前程序运行在 APP 模式下] </para>
            /// </summary>
            public static DynaLinkHS.IAPWorkStatus IAPWorkStatus = DynaLinkHS.IAPWorkStatus.NONE;

            /// <summary>
            ///<para>@brief The progress of upgrade Iap (bootloader) [Bootloader 的下载进度]</para>
            ///<para>@details The range in between 0-100. [值范围 0 - 100]                  </para>
            /// </summary>
            public static uint IAPUpgradeIapProgress = 0;

            /// <summary>
            ///<para> @brief The progress of upgrade Iap (bootloader) [Application 的下载进度]</para>
            ///<para> @details The range in between 0-100. [值范围 0 - 100]                   </para>
            /// </summary>
            public static uint IAPUpgradeAppProgress = 0;

            /// <summary>
            ///<para>@brief The status of the Iap (bootloader) upgrade [Bootloader 的下载状态]</para>
            ///<para>@details                                                                </para>
            ///<para>    - DynaLinkHSPara.IAPUpgradeStatus.READY [准备状态]                   </para>
            ///<para>    - DynaLinkHSPara.IAPUpgradeStatus.Running [执行状态]                 </para>
            ///<para>    - DynaLinkHSPara.IAPUpgradeStatus.SUCCESS [成功状态]                 </para>
            ///<para>    - DynaLinkHSPara.IAPUpgradeStatus.FAIL [失败状态]                    </para>
            /// </summary>
            public static DynaLinkHS.IAPUpgradeStatus IAPUpgradeIapStatus = DynaLinkHS.IAPUpgradeStatus.READY;

            /// <summary>
            ///<para> @brief The status of the App (Application) upgrade [Application 的下载状态]</para>
            ///<para> @details                                                                  </para>
            ///<para>     - DynaLinkHSPara.IAPUpgradeStatus.READY [准备状态]                     </para>
            ///<para>     - DynaLinkHSPara.IAPUpgradeStatus.Running [执行状态]                   </para>
            ///<para>     - DynaLinkHSPara.IAPUpgradeStatus.SUCCESS [成功状态]                   </para>
            ///<para>     - DynaLinkHSPara.IAPUpgradeStatus.FAIL [失败状态]                      </para>
            /// </summary>
            public static DynaLinkHS.IAPUpgradeStatus IAPUpgradeAppStatus = DynaLinkHS.IAPUpgradeStatus.READY;
        }

        public static bool IAPUpgradeIapLocker = false;
        public static bool IAPUpgradeIapTransmitLocker = false;
        public static uint IAPUpgradeIapEraseWaitTime = 10 * 1000 /* unit : ms */;
        public static uint IAPUpgradeIapSize = 0;
        public static uint IAPUpgradeIapMonitorCount = 0;
        public static uint IAPUpgradeIapMonitorMaximumCount = 100 * 2 /* 2s */;
        public static bool IAPUpgradeIapResendRequestFlag = false;
        public static uint IAPUpgradeIapResendCount = 0;
        public static uint IAPUpgradeIapResendMaximumCount = 10;

        public static bool IAPUpgradeAppLocker = false;
        public static bool IAPUpgradeAppTransmitLocker = false;
        public static uint IAPUpgradeAppEraseWaitTime = 10 * 1000 /* unit : ms */;
        public static uint IAPUpgradeAppSize = 0;
        public static uint IAPUpgradeAppMonitorCount = 0;
        public static uint IAPUpgradeAppMonitorMaximumCount = 100 * 2 /* 2s */;
        public static bool IAPUpgradeAppResendRequestFlag = false;
        public static uint IAPUpgradeAppResendCount = 0;
        public static uint IAPUpgradeAppResendMaximumCount = 10;

        #endregion

        #region App
        /// <summary>
        /// @brief The status of Application(APP) process ["应用程序(APP)"状态结构体]
        /// </summary>
        public class StatusApp
        {
            /// <summary>
            /// @brief Hardware version [硬件版本]
            /// </summary>
            public static uint HardwareVersion = 0;

            /// <summary>
            /// @brief Hardware version [硬件版本字符串]
            /// </summary>
            public static string HardwareVersionString = "0.0.0.0";

            /// <summary>
            ///  @brief Software version [软件版本]
            /// </summary>
            public static uint SoftwareVersion = 0;

            /// <summary>
            /// @brief Software version [软件版本字符串]
            /// </summary>
            public static string SoftwareVersionString = "0.0.0.0";

            /// <summary>
            /// @brief Software version [软件版本]
            /// </summary>
            //public static string TrueSoftwareVersionString = "0.0.0.0";

            /// <summary>
            /// @brief SN number [SN 号]
            /// 
            /// @note 该 SN 号为 STM32 的 SN 号，并非公司自定值
            /// </summary>
            public static uint SerialNumber = 0;

            /// <summary>
            ///  @brief Robot type [机器人类型]
            /// </summary>
            public static DynaLinkHS.RobotType RobotType = DynaLinkHS.RobotType.NONE;

            /// <summary>
            /// @brief Mechanism type [机械类型]
            /// </summary>
            public static DynaLinkHS.MechanismType MechanismType = DynaLinkHS.MechanismType.NONE;

            /// <summary>
            /// @brief Mechanism type [机械类型字符串]
            /// </summary>
            public static string MechanismTypeString;

            /// <summary>
            /// @brief Robot SN [机器人序列号]
            /// </summary>
            public static DynaLinkHS.RobotSerialNumber RobotSerialNumber = 0;

            /// <summary>
            /// @brief Device name [设备名称符串]
            /// </summary>
            public static string DeviceNameString="None";

            /// <summary>
            /// @brief Device name [设备机械类型名称符串]
            /// </summary>
            public static string DeviecTypeString = "None";
        }

        #endregion

        #region State
        public class StatusState
        {
            /// <summary>
            /// 外骨骼机器人的状态
            /// </summary>
            public static ExoMotusState exoMotusState = ExoMotusState.NONE;
        }

        #endregion

        #region Flag
        /// <summary>
        ///  @brief The flag of different status [不同状态的标志位]
        /// </summary>
        public class StatusFlag
        {
            /// <summary>
            ///<para> @brief The flag of server link active [MMU 服务器连接状态标志位]             </para>
            ///<para> @retval 1 The server is active [服务器已连接]                               </para>
            ///<para> @retval 0 The server is down [服务器未连接]                                 </para>
            /// </summary>
            public static uint FlagServerLinkActive = 0;

            /// <summary>
            ///<para> @brief The flag of calibration [机器校准标志位]                              </para>
            ///<para> @retval 1 The calibration finished [机器已完成校准]                          </para>
            ///<para> @retval 0 The calibration is undone [机器未完成校准]                         </para>
            /// </summary>
            public static uint FlagCalibration = 0;

            /// <summary>
            ///<para> @brief The flag of servo on [电机使能标志位]                                 </para>
            ///<para> @retval 1 The servo is on [电机使能]                                        </para>
            ///<para> @retval 0 The servo is off [电机失能]                                       </para>
            /// </summary>
            public static uint FlagServoOn = 0;

            /// <summary>
            ///<para> @brief The flag of emergent stop [急停标志位]                               </para>
            ///<para> @retval 1 The emergent stop button is pressed [急停开关按下]                </para>
            ///<para> @retval 0 The emergent stop button is not pressed [急停开关未按下]          </para>
            /// </summary>
            public static uint FlagEmergentStop = 0;

            /// <summary>
            ///<para> @brief The flag of fault [错误标志位]                                       </para>
            ///<para> @retval 1 The driver is in fault status [驱动器处于错误状态]                 </para>
            ///<para> @retval 0 The driver is not in fault status [驱动器处于正常状态]             </para>
            /// </summary>
            public static uint FlagFault = 0;

            /// <summary>
            ///<para> @brief The flag of task in process [任务执行中标志位]                       </para>
            ///<para> @retval 1 The task is in process [任务执行中]                              </para>
            ///<para> @retval 0 The task is not in process [未执行任务]                          </para>
            /// </summary>
            public static uint FlagTaskInProcess = 0;

            /// <summary>
            ///<para> @brief The flag of robot moving [机器人运动标志位]                          </para>
            ///<para> @retval 1 The robot is moving [机器人在运动]                                </para>
            ///<para> @retval 0 The robot is not moving [机器人未运动]                            </para>
            /// </summary>
            public static uint FlagRobotMoving = 0;

            /// <summary>
            ///<para> @brief The flag of robot moving [机器人关节超过动力限制标志位]                </para>
            ///<para> @retval 1 The robot is moving [超过限制]                                    </para>
            ///<para> @retval 0 The robot is not moving [未超过限制]                              </para>
            /// </summary>
            public static uint FlagOutOfJointKineticLimit = 0;

            /// <summary>
            ///<para>@brief The flag of robot moving [机器人关节超过加速度限制标志位]               </para>
            ///<para>@retval 1 The robot is moving [超过限制]                                     </para>
            ///<para>@retval 0 The robot is not moving [未超过限制]                               </para>
            /// </summary>
            public static uint FlagOutOfJointAccelerationLimit = 0;

            /// <summary>
            ///<para> @brief The flag of robot moving [机器人关节超过速度限制标志位]               </para>
            ///<para> @retval 1 The robot is moving [超过限制]                                   </para>
            ///<para> @retval 0 The robot is not moving [未超过限制]                             </para>
            /// </summary>
            public static uint FlagOutOfJointVelocityLimit = 0;

            /// <summary>
            ///<para> @brief The flag of robot moving [机器人关节超过位置限制标志位]               </para>
            ///<para> @retval 1 The robot is moving [超过限制]                                   </para>
            ///<para> @retval 0 The robot is not moving [未超过限制]                             </para>
            /// </summary>
            public static uint FlagOutOfJointPositionLimit = 0;

            /// <summary>
            ///<para> @brief The flag of robot moving [机器人末端超过动力限制标志位]               </para>
            ///<para> @retval 1 The robot is moving [超过限制]                                   </para>
            ///<para> @retval 0 The robot is not moving [未超过限制]                             </para>
            /// </summary>
            public static uint FlagOutOfEndEffectorKineticLimit = 0;

            /// <summary>
            ///<para> @brief The flag of robot moving [机器人末端超过加速度限制标志位]             </para>
            ///<para> @retval 1 The robot is moving [超过限制]                                   </para>
            ///<para> @retval 0 The robot is not moving [未超过限制]                             </para>
            /// </summary>
            public static uint FlagOutOfEndEffectorAccelerationLimit = 0;

            /// <summary>
            ///<para> @brief The flag of robot moving [机器人末端超过速度限制标志位]               </para>
            ///<para> @retval 1 The robot is moving [超过限制]                                   </para>
            ///<para> @retval 0 The robot is not moving [未超过限制]                             </para>
            /// </summary>
            public static uint FlagOutOfEndEffectorVelocityLimit = 0;

            /// <summary>
            ///<para> @brief The flag of robot moving [机器人末端超过位置限制标志位]              </para>
            ///<para> @retval 1 The robot is moving [超过限制]                                  </para>
            ///<para> @retval 0 The robot is not moving [未超过限制]                            </para>
            /// </summary>
            public static uint FlagOutOfEndEffectorPositionLimit = 0;

            /// <summary>
            ///<para> @brief The flag of robot moving [机器人超过力矩保护限制标志位]              </para>
            ///<para> @retval 1 Out of limit [超过限制]                                         </para>
            ///<para> @retval 0 Not out of limit [未超过限制]                                   </para>
            /// </summary>
            public static uint FlagOutOfKineticProtectionLimit = 0;

            /// <summary>
            /// <para> @Judge whether to pinch hands [检测是否夹手的标志位]              </para>
            /// <para> @retval 1 pinched [夹手]                                         </para>
            /// <para> @retval 0 not pinched [未夹手]                                   </para>
            /// </summary>
            public static uint FlagPinched = 0;
        }

        #endregion

        #region Digi
        /// <summary>
        ///<para>  @brief The status of circuit board digit input [电路板数字输入口的状态]                   </para>
        ///<para>                                                                                          </para>
        ///<para>  @note Not used right now [暂未使用]                                                      </para>
        /// </summary>
        public class StatusDigiInput
        {
            public static uint[] IDL = new uint[4] { 0, 0, 0, 0 };
        }

        /// <summary>
        ///<para>  @brief The status of circuit board digit output [电路板数字输出口的状态]                  </para>
        ///<para>                                                                                          </para>
        ///<para>  @note Not used right now [暂未使用]                                                      </para>
        /// </summary>
        public class StatusDigiOutput
        {
            public static uint[] ODL = new uint[4] { 0, 0, 0, 0 };
        }

        #endregion

        #region Robot
        /// <summary>
        ///  @brief The status of the robot [机器人的状态]
        /// </summary>
        public class StatusRobot
        {
            #region driver
            /// <summary>
            ///  accessible of driver
            /// </summary>
            public struct Driver1
            {
                /// <summary>
                /// The installed state of the robot driver 1 [驱动器 1 安装状态]
                /// </summary>
                public static uint Installed = 0;
                /// <summary>
                /// The access state of the robot driver 1 [驱动器 1 通信状态]
                /// </summary>
                public static uint Accessible = 0;
            }

            /// <summary>
            /// accessible of driver
            /// </summary>
            public struct Driver2
            {
                /// <summary>
                /// The installed state of the robot driver 2 [驱动器 2 安装状态]
                /// </summary>
                public static uint Installed = 0;
                /// <summary>
                /// The access state of the robot driver 2 [驱动器 2 通信状态]
                /// </summary>
                public static uint Accessible = 0;
            }

            public struct Driver3
            {
                /// <summary>
                /// The installed state of the robot driver 3 [驱动器 3 安装状态]
                /// </summary>
                public static uint Installed = 0;
                /// <summary>
                /// The access state of the robot driver 3 [驱动器 3 通信状态]
                /// </summary>
                public static uint Accessible = 0;
            }

            public struct Driver4
            {
                /// <summary>
                ///  The installed state of the robot driver 4 [驱动器 4 安装状态]
                /// </summary>
                public static uint Installed = 0;
                /// <summary>
                /// The access state of the robot driver 4 [驱动器 4 通信状态]
                /// </summary>
                public static uint Accessible = 0;
            }

            public struct Driver5
            {
                /// <summary>
                /// The installed state of the robot driver 5 [驱动器 5 安装状态]
                /// </summary>
                public static uint Installed = 0;
                /// <summary>
                /// The access state of the robot driver 5 [驱动器 5 通信状态]
                /// </summary>
                public static uint Accessible = 0;
            }

            public struct Driver6
            {
                /// <summary>
                /// The installed state of the robot driver 6 [驱动器 6 安装状态]
                /// </summary>
                public static uint Installed = 0;
                /// <summary>
                /// The access state of the robot driver 6 [驱动器 6 通信状态]
                /// </summary>
                public static uint Accessible = 0;
            }

            #endregion

            #region position/velocity/acceleration/kinetic  Joint
            // inforamtion of joint
            /// <summary>
            /// The position value of the robot joint 1 [关节 1 位置]
            /// </summary>
            public static float PositionDataJoint1 = 0;
            /// <summary>
            /// The position value of the robot joint 2 [关节 2 位置]
            /// </summary>
            public static float PositionDataJoint2 = 0;
            /// <summary>
            /// The position value of the robot joint 3 [关节 3 位置]
            /// </summary>
            public static float PositionDataJoint3 = 0;
            /// <summary>
            /// The position value of the robot joint 4 [关节 4 位置]
            /// </summary>
            public static float PositionDataJoint4 = 0;
            /// <summary>
            ///  The position value of the robot joint 5 [关节 5 位置]
            /// </summary>
            public static float PositionDataJoint5 = 0;
            /// <summary>
            /// The position value of the robot joint 6 [关节 6 位置]
            /// </summary>
            public static float PositionDataJoint6 = 0;
            /// <summary>
            ///  The velocity value of the robot joint 1 [关节 1 速度]
            /// </summary>
            public static float VelocityDataJoint1 = 0;
            /// <summary>
            /// The velocity value of the robot joint 2 [关节 2 速度]
            /// </summary>
            public static float VelocityDataJoint2 = 0;
            /// <summary>
            /// The velocity value of the robot joint 3 [关节 3 速度]
            /// </summary>
            public static float VelocityDataJoint3 = 0;
            /// <summary>
            /// The velocity value of the robot joint 4 [关节 4 速度]
            /// </summary>
            public static float VelocityDataJoint4 = 0;
            /// <summary>
            ///  The velocity value of the robot joint 5 [关节 5 速度]
            /// </summary>
            public static float VelocityDataJoint5 = 0;
            /// <summary>
            /// The velocity value of the robot joint 6 [关节 6 速度]
            /// </summary>
            public static float VelocityDataJoint6 = 0;
            /// <summary>
            /// The acceleration value of the robot joint 1 [关节 1 加速度]
            /// </summary>
            public static float AccelerationDataJoint1 = 0;
            /// <summary>
            /// The acceleration value of the robot joint 2 [关节 2 加速度]
            /// </summary>
            public static float AccelerationDataJoint2 = 0;
            /// <summary>
            /// The acceleration value of the robot joint 3 [关节 3 加速度]
            /// </summary>
            public static float AccelerationDataJoint3 = 0;
            /// <summary>
            /// The acceleration value of the robot joint 4 [关节 4 加速度]
            /// </summary>
            public static float AccelerationDataJoint4 = 0;
            /// <summary>
            /// The acceleration value of the robot joint 5 [关节 5 加速度]
            /// </summary>
            public static float AccelerationDataJoint5 = 0;
            /// <summary>
            /// The acceleration value of the robot joint 6 [关节 6 加速度]
            /// </summary>
            public static float AccelerationDataJoint6 = 0;
            /// <summary>
            /// The kinetic value of the robot joint 1 [关节 1 力/力矩]
            /// </summary>
            public static float KineticDataJoint1 = 0;
            /// <summary>
            ///  The kinetic value of the robot joint 2 [关节 2 力/力矩]
            /// </summary>
            public static float KineticDataJoint2 = 0;
            /// <summary>
            ///  The kinetic value of the robot joint 3 [关节 3 力/力矩]
            /// </summary>
            public static float KineticDataJoint3 = 0;
            /// <summary>
            /// The kinetic value of the robot joint 4 [关节 4 力/力矩]
            /// </summary>
            public static float KineticDataJoint4 = 0;
            /// <summary>
            /// The kinetic value of the robot joint 5 [关节 5 力/力矩]
            /// </summary>
            public static float KineticDataJoint5 = 0;
            /// <summary>
            ///  The kinetic value of the robot joint 6 [关节 6 力/力矩]
            /// </summary>
            public static float KineticDataJoint6 = 0;

            #endregion

            #region  position/velocity/acceleration/kinetic end effector
            // information of end effector
            /// <summary>
            /// The position value of the robot end effector x 1 [末端 1 位姿 position x]
            /// </summary>
            public static float PositionDataEndEffectorX1 = 0;
            /// <summary>
            ///  The position value of the robot end effector y 1 [末端 1 位姿 position y]
            /// </summary>
            public static float PositionDataEndEffectorY1 = 0;
            /// <summary>
            ///  The position value of the robot end effector z 1 [末端 1 位姿 position z]
            /// </summary>
            public static float PositionDataEndEffectorZ1 = 0;
            /// <summary>
            /// The position value of the robot end effector alpha 1 [末端 1 位姿 position alpha]
            /// </summary>
            public static float PositionDataEndEffectorAlpha1 = 0;
            /// <summary>
            /// The position value of the robot end effector beta 1 [末端 1 位姿 position beta]
            /// </summary>
            public static float PositionDataEndEffectorBeta1 = 0;
            /// <summary>
            ///  The position value of the robot end effector gamma 1 [末端 1 位姿 position gamma]
            /// </summary>
            public static float PositionDataEndEffectorGamma1 = 0;

            /// <summary>
            /// The velocity value of the robot end effector x 1 [末端 1 位姿 velocity x]
            /// </summary>
            public static float VelocityDataEndEffectorX1 = 0;
            /// <summary>
            /// The velocity value of the robot end effector y 1 [末端 1 位姿 velocity y]
            /// </summary>
            public static float VelocityDataEndEffectorY1 = 0;
            /// <summary>
            /// The velocity value of the robot end effector z 1 [末端 1 位姿 velocity z]
            /// </summary>
            public static float VelocityDataEndEffectorZ1 = 0;
            /// <summary>
            /// The velocity value of the robot end effector alpha 1 [末端 1 位姿 velocity alpha]
            /// </summary>
            public static float VelocityDataEndEffectorAlpha1 = 0;
            /// <summary>
            /// The velocity value of the robot end effector beta 1 [末端 1 位姿 velocity beta]
            /// </summary>
            public static float VelocityDataEndEffectorBeta1 = 0;
            /// <summary>
            /// The velocity value of the robot end effector gamma 1 [末端 1 位姿 velocity gamma]
            /// </summary>
            public static float VelocityDataEndEffectorGamma1 = 0;

            /// <summary>
            ///  The acceleration value of the robot end effector x 1 [末端 1 位姿 acceleration x]
            /// </summary>
            public static float AccelerationDataEndEffectorX1 = 0;
            /// <summary>
            /// The acceleration value of the robot end effector y 1 [末端 1 位姿 acceleration y]
            /// </summary>
            public static float AccelerationDataEndEffectorY1 = 0;
            /// <summary>
            ///  The acceleration value of the robot end effector z 1 [末端 1 位姿 acceleration z]
            /// </summary>
            public static float AccelerationDataEndEffectorZ1 = 0;
            /// <summary>
            /// The acceleration value of the robot end effector alpha 1 [末端 1 位姿 acceleration alpha]
            /// </summary>
            public static float AccelerationDataEndEffectorAlpha1 = 0;
            /// <summary>
            /// The acceleration value of the robot end effector beta 1 [末端 1 位姿 acceleration beta]
            /// </summary>
            public static float AccelerationDataEndEffectorBeta1 = 0;
            /// <summary>
            ///  The acceleration value of the robot end effector gamma 1 [末端 1 位姿 acceleration gamma]
            /// </summary>
            public static float AccelerationDataEndEffectorGamma1 = 0;

            /// <summary>
            ///  The kinetic value of the robot end effector x 1 [末端 1 位姿 kinetic x]
            /// </summary>
            public static float KineticDataEndEffectorX1 = 0;
            /// <summary>
            /// The kinetic value of the robot end effector y 1 [末端 1 位姿 kinetic y]
            /// </summary>
            public static float KineticDataEndEffectorY1 = 0;
            /// <summary>
            ///  The kinetic value of the robot end effector z 1 [末端 1 位姿 kinetic z]
            /// </summary>
            public static float KineticDataEndEffectorZ1 = 0;
            /// <summary>
            /// The kinetic value of the robot end effector alpha 1 [末端 1 位姿 kinetic alpha]
            /// </summary>
            public static float KineticDataEndEffectorAlpha1 = 0;
            /// <summary>
            /// The kinetic value of the robot end effector beta 1 [末端 1 位姿 kinetic beta]
            /// </summary>
            public static float KineticDataEndEffectorBeta1 = 0;
            /// <summary>
            /// The kinetic value of the robot end effector gamma 1 [末端 1 位姿 kinetic gamma]
            /// </summary>
            public static float KineticDataEndEffectorGamma1 = 0;

            /// <summary>
            /// The position value of the robot end effector x 2 [末端 2 位姿 position x]
            /// </summary>
            public static float PositionDataEndEffectorX2 = 0;
            /// <summary>
            ///  The position value of the robot end effector y 2 [末端 2 位姿 position y]
            /// </summary>
            public static float PositionDataEndEffectorY2 = 0;
            /// <summary>
            ///  The position value of the robot end effector z 2 [末端 2 位姿 position z]
            /// </summary>
            public static float PositionDataEndEffectorZ2 = 0;
            /// <summary>
            /// The position value of the robot end effector alpha 2 [末端 2 位姿 position alpha]
            /// </summary>
            public static float PositionDataEndEffectorAlpha2 = 0;
            /// <summary>
            /// The position value of the robot end effector beta 2 [末端 2 位姿 position beta]
            /// </summary>
            public static float PositionDataEndEffectorBeta2 = 0;
            /// <summary>
            /// The position value of the robot end effector gamma 2 [末端 2 位姿 position gamma]
            /// </summary>
            public static float PositionDataEndEffectorGamma2 = 0;


            /// <summary>
            /// The velocity value of the robot end effector x 2 [末端 2 位姿 velocity x]
            /// </summary>
            public static float VelocityDataEndEffectorX2 = 0;
            /// <summary>
            /// The velocity value of the robot end effector y 2 [末端 2 位姿 velocity y]
            /// </summary>
            public static float VelocityDataEndEffectorY2 = 0;
            /// <summary>
            ///  The velocity value of the robot end effector z 2 [末端 2 位姿 velocity z]
            /// </summary>
            public static float VelocityDataEndEffectorZ2 = 0;
            /// <summary>
            /// The velocity value of the robot end effector alpha 2 [末端 2 位姿 velocity alpha]
            /// </summary>
            public static float VelocityDataEndEffectorAlpha2 = 0;
            /// <summary>
            /// The velocity value of the robot end effector beta 2 [末端 2 位姿 velocity beta]
            /// </summary>
            public static float VelocityDataEndEffectorBeta2 = 0;
            /// <summary>
            /// The velocity value of the robot end effector gamma 2 [末端 2 位姿 velocity gamma]
            /// </summary>
            public static float VelocityDataEndEffectorGamma2 = 0;

            /// <summary>
            /// The acceleration value of the robot end effector x 2 [末端 2 位姿 acceleration x]
            /// </summary>
            public static float AccelerationDataEndEffectorX2 = 0;
            /// <summary>
            /// The acceleration value of the robot end effector y 2 [末端 2 位姿 acceleration y]
            /// </summary>
            public static float AccelerationDataEndEffectorY2 = 0;
            /// <summary>
            /// The acceleration value of the robot end effector z 2 [末端 2 位姿 acceleration z]
            /// </summary>
            public static float AccelerationDataEndEffectorZ2 = 0;
            /// <summary>
            /// The acceleration value of the robot end effector alpha 2 [末端 2 位姿 acceleration alpha]
            /// </summary>
            public static float AccelerationDataEndEffectorAlpha2 = 0;
            /// <summary>
            /// The acceleration value of the robot end effector beta 2 [末端 2 位姿 acceleration beta]
            /// </summary>
            public static float AccelerationDataEndEffectorBeta2 = 0;
            /// <summary>
            /// The acceleration value of the robot end effector gamma 2 [末端 2 位姿 acceleration gamma]
            /// </summary>
            public static float AccelerationDataEndEffectorGamma2 = 0;

            /// <summary>
            /// The kinetic value of the robot end effector x 2 [末端 2 位姿 kinetic x]
            /// </summary>
            public static float KineticDataEndEffectorX2 = 0;
            /// <summary>
            ///  The kinetic value of the robot end effector y 2 [末端 2 位姿 kinetic y]
            /// </summary>
            public static float KineticDataEndEffectorY2 = 0;
            /// <summary>
            /// The kinetic value of the robot end effector z 2 [末端 2 位姿 kinetic z]
            /// </summary>
            public static float KineticDataEndEffectorZ2 = 0;
            /// <summary>
            /// The kinetic value of the robot end effector alpha 2 [末端 2 位姿 kinetic alpha]
            /// </summary>
            public static float KineticDataEndEffectorAlpha2 = 0;
            /// <summary>
            /// The kinetic value of the robot end effector beta 2 [末端 2 位姿 kinetic beta]
            /// </summary>
            public static float KineticDataEndEffectorBeta2 = 0;
            /// <summary>
            /// The kinetic value of the robot end effector gamma 2 [末端 2 位姿 kinetic gamma]
            /// </summary>
            public static float KineticDataEndEffectorGamma2 = 0;

            #endregion

            #region joint poistion Limitation
            public struct PositionLimitationDataJoint1
            {
                /// <summary>
                /// The minimum position value of the robot joint 1 [关节 1 允许的最小位置]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximum position value of the robot joint 1 [关节 1 允许的最大位置]
                /// </summary>
                public static float Max = 0;
            }
            public struct PositionLimitationDataJoint2
            {
                /// <summary>
                ///  The minimum position value of the robot joint 2 [关节 2 允许的最小位置]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximum position value of the robot joint 2 [关节 2 允许的最大位置]
                /// </summary>
                public static float Max = 0;
            }
            public struct PositionLimitationDataJoint3
            {
                /// <summary>
                /// The minimum position value of the robot joint 3 [关节 3 允许的最小位置]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximum position value of the robot joint 3 [关节 3 允许的最大位置]
                /// </summary>
                public static float Max = 0;
            }
            public struct PositionLimitationDataJoint4
            {
                /// <summary>
                /// The minimum position value of the robot joint 4 [关节 4 允许的最小位置]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                ///  The maximum position value of the robot joint 4 [关节 4 允许的最大位置]
                /// </summary>
                public static float Max = 0;
            }
            public struct PositionLimitationDataJoint5
            {
                /// <summary>
                /// The minimum position value of the robot joint 5 [关节 5 允许的最小位置]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximum position value of the robot joint 5 [关节 5 允许的最大位置]
                /// </summary>
                public static float Max = 0;
            }
            public struct PositionLimitationDataJoint6
            {
                /// <summary>
                /// The minimum position value of the robot joint 6 [关节 6 允许的最小位置]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximum position value of the robot joint 6 [关节 6 允许的最大位置]
                /// </summary>
                public static float Max = 0;
            }

            #endregion

            #region joint kinetic Limitation
            //
            public struct KineticLimitationDataJoint1
            {
                /// <summary>
                /// The minimum kinetic value of the robot joint 1 [关节 1 允许的最小扭矩/力]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximum kinetic value of the robot joint 1 [关节 1 允许的最大扭矩/力]
                /// </summary>
                public static float Max = 0;
            }

            public struct KineticLimitationDataJoint2
            {
                /// <summary>
                /// The minimum kinetic value of the robot joint 2 [关节 2 允许的最小扭矩/力]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximum kinetic value of the robot joint 2 [关节 2 允许的最大扭矩/力]
                /// </summary>
                public static float Max = 0;
            }

            public struct KineticLimitationDataJoint3
            {
                /// <summary>
                /// The minimum kinetic value of the robot joint 3 [关节 3 允许的最小扭矩/力]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximum kinetic value of the robot joint 3 [关节 3 允许的最大扭矩/力]
                /// </summary>
                public static float Max = 0;
            }

            public struct KineticLimitationDataJoint4
            {
                /// <summary>
                /// The minimum kinetic value of the robot joint 4 [关节 4 允许的最小扭矩/力]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximum kinetic value of the robot joint 4 [关节 4 允许的最大扭矩/力]
                /// </summary>
                public static float Max = 0;
            }

            public struct KineticLimitationDataJoint5
            {
                /// <summary>
                /// The minimum kinetic value of the robot joint 5 [关节 5 允许的最小扭矩/力]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximum kinetic value of the robot joint 5 [关节 5 允许的最大扭矩/力]
                /// </summary>
                public static float Max = 0;
            }

            public struct KineticLimitationDataJoint6
            {
                /// <summary>
                /// The minimum kinetic value of the robot joint 6 [关节 6 允许的最小扭矩/力]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximum kinetic value of the robot joint 6 [关节 6 允许的最大扭矩/力]
                /// </summary>
                public static float Max = 0;
            }

            #endregion

            #region joint velocity Limitation
            public struct VelocityLimitationDataJoint1
            {
                /// <summary>
                /// The minimum velocity value of the robot joint 1 [关节 1 允许的最小速度]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximum velocity value of the robot joint 1 [关节 1 允许的最大速度]
                /// </summary>
                public static float Max = 0;
            }

            public struct VelocityLimitationDataJoint2
            {
                /// <summary>
                /// The minimum velocity value of the robot joint 2 [关节 2 允许的最小速度]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximum velocity value of the robot joint 2 [关节 2 允许的最大速度]
                /// </summary>
                public static float Max = 0;
            }

            public struct VelocityLimitationDataJoint3
            {
                /// <summary>
                /// The minimum velocity value of the robot joint 3 [关节 3 允许的最小速度]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximum velocity value of the robot joint 3 [关节 3 允许的最大速度]
                /// </summary>
                public static float Max = 0;
            }

            public struct VelocityLimitationDataJoint4
            {
                /// <summary>
                /// The minimum velocity value of the robot joint 4 [关节 4 允许的最小速度]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximum velocity value of the robot joint 4 [关节 4 允许的最大速度]
                /// </summary>
                public static float Max = 0;
            }

            public struct VelocityLimitationDataJoint5
            {
                /// <summary>
                /// The minimum velocity value of the robot joint 5 [关节 5 允许的最小速度]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximum velocity value of the robot joint 5 [关节 5 允许的最大速度]
                /// </summary>
                public static float Max = 0;
            }

            public struct VelocityLimitationDataJoint6
            {
                /// <summary>
                /// The minimum velocity value of the robot joint 6 [关节 6 允许的最小速度]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximum velocity value of the robot joint 6 [关节 6 允许的最大速度]
                /// </summary>
                public static float Max = 0;
            }

            #endregion

            #region joint acceleration Limitation
            public struct AccelerationLimitationDataJoint1
            {
                /// <summary>
                /// The minimum acceleration value of the robot joint 1 [关节 1 允许的最小加速度]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximum acceleration value of the robot joint 1 [关节 1 允许的最大加速度]
                /// </summary>
                public static float Max = 0;
            }

            public struct AccelerationLimitationDataJoint2
            {
                /// <summary>
                /// The minimum acceleration value of the robot joint 2 [关节 2 允许的最小加速度]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximum acceleration value of the robot joint 2 [关节 2 允许的最大加速度]
                /// </summary>
                public static float Max = 0;
            }

            public struct AccelerationLimitationDataJoint3
            {
                /// <summary>
                /// The minimum acceleration value of the robot joint 3 [关节 3 允许的最小加速度]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximum acceleration value of the robot joint 3 [关节 3 允许的最大加速度]
                /// </summary>
                public static float Max = 0;
            }

            public struct AccelerationLimitationDataJoint4
            {
                /// <summary>
                /// The minimum acceleration value of the robot joint 4 [关节 4 允许的最小加速度]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximum acceleration value of the robot joint 4 [关节 4 允许的最大加速度]
                /// </summary>
                public static float Max = 0;
            }

            public struct AccelerationLimitationDataJoint5
            {
                /// <summary>
                /// The minimum acceleration value of the robot joint 5 [关节 5 允许的最小加速度]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximum acceleration value of the robot joint 5 [关节 5 允许的最大加速度]
                /// </summary>
                public static float Max = 0;
            }

            public struct AccelerationLimitationDataJoint6
            {
                /// <summary>
                /// The minimum acceleration value of the robot joint 6 [关节 6 允许的最小加速度]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximum acceleration value of the robot joint 6 [关节 6 允许的最大加速度]
                /// </summary>
                public static float Max = 0;
            }

            #endregion

            #region end effector position limitation
            public struct PositionLimitationDataEndEffectorX1
            {
                /// <summary>
                ///  The minimum position value of the robot end effector x1 [末端 x1 允许的最小位置]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximun position value of the robot end effector x1 [末端 x1 允许的最大位置]
                /// </summary>
                public static float Max = 0;
            }
            public struct PositionLimitationDataEndEffectorY1
            {
                /// <summary>
                /// The minimum position value of the robot end effector y1 [末端 y1 允许的最小位置]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximun position value of the robot end effector y1 [末端 y1 允许的最大位置]
                /// </summary>
                public static float Max = 0;
            }
            public struct PositionLimitationDataEndEffectorZ1
            {
                /// <summary>
                ///  The minimum position value of the robot end effector z1 [末端 z1 允许的最小位置]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximun position value of the robot end effector z1 [末端 z1 允许的最大位置]
                /// </summary>
                public static float Max = 0;
            }
            public struct PositionLimitationDataEndEffectorAlpha1
            {
                /// <summary>
                /// The minimum position value of the robot end effector alpha1 [末端 alpha1 允许的最小位置]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximun position value of the robot end effector alpha1 [末端 alpha1 允许的最大位置]
                /// </summary>
                public static float Max = 0;
            }
            public struct PositionLimitationDataEndEffectorBeta1
            {
                /// <summary>
                /// The minimum position value of the robot end effector beta1 [末端 beta1 允许的最小位置]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                ///  The maximun position value of the robot end effector beta1 [末端 beta1 允许的最大位置]
                /// </summary>
                public static float Max = 0;
            }
            public struct PositionLimitationDataEndEffectorGamma1
            {
                /// <summary>
                /// The minimum position value of the robot end effector gamma1 [末端 gamma1 允许的最小位置]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                ///  The maximun position value of the robot end effector gamma1 [末端 gamma1 允许的最大位置]
                /// </summary>
                public static float Max = 0;
            }

            #endregion

            #region end effector kinetic limitation
            public struct KineticLimitationDataEndEffectorX1
            {
                /// <summary>
                ///  The minimum kinetic value of the robot end effector x1 [末端 x1 允许的最小扭矩/力矩]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximun kinetic value of the robot end effector x1 [末端 x1 允许的最大扭矩/力矩]
                /// </summary>
                public static float Max = 0;
            }
            public struct KineticLimitationDataEndEffectorY1
            {
                /// <summary>
                /// The minimum kinetic value of the robot end effector y1 [末端 y1 允许的最小扭矩/力矩]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximun kinetic value of the robot end effector y1 [末端 y1 允许的最大扭矩/力矩]
                /// </summary>
                public static float Max = 0;
            }
            public struct KineticLimitationDataEndEffectorZ1
            {
                /// <summary>
                ///  The minimum kinetic value of the robot end effector z1 [末端 z1 允许的最小扭矩/力矩]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximun kinetic value of the robot end effector z1 [末端 z1 允许的最大扭矩/力矩]
                /// </summary>
                public static float Max = 0;
            }
            public struct KineticLimitationDataEndEffectorAlpha1
            {
                /// <summary>
                /// The minimum kinetic value of the robot end effector alpha1 [末端 alpha1 允许的最小扭矩/力矩]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximun kinetic value of the robot end effector alpha1 [末端 alpha1 允许的最大扭矩/力矩]
                /// </summary>
                public static float Max = 0;
            }
            public struct KineticLimitationDataEndEffectorBeta1
            {
                /// <summary>
                /// The minimum kinetic value of the robot end effector beta1 [末端 beta1 允许的最小扭矩/力矩]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                ///  The maximun kinetic value of the robot end effector beta1 [末端 beta1 允许的最大扭矩/力矩]
                /// </summary>
                public static float Max = 0;
            }
            public struct KineticLimitationDataEndEffectorGamma1
            {
                /// <summary>
                /// The minimum kinetic value of the robot end effector gamma1 [末端 gamma1 允许的最小扭矩/力矩]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                ///  The maximun kinetic value of the robot end effector gamma1 [末端 gamma1 允许的最大扭矩/力矩]
                /// </summary>
                public static float Max = 0;
            }

            #endregion

            #region end effector velocity limitation
            public struct VelocityLimitationDataEndEffectorX1
            {
                /// <summary>
                ///  The minimum velocity value of the robot end effector x1 [末端 x1 允许的最小速度]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximun velocity value of the robot end effector x1 [末端 x1 允许的最大速度]
                /// </summary>
                public static float Max = 0;
            }
            public struct VelocityLimitationDataEndEffectorY1
            {
                /// <summary>
                /// The minimum velocity value of the robot end effector y1 [末端 y1 允许的最小速度]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximun velocity value of the robot end effector y1 [末端 y1 允许的最大速度]
                /// </summary>
                public static float Max = 0;
            }
            public struct VelocityLimitationDataEndEffectorZ1
            {
                /// <summary>
                ///  The minimum velocity value of the robot end effector z1 [末端 z1 允许的最小速度]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximun velocity value of the robot end effector z1 [末端 z1 允许的最大速度]
                /// </summary>
                public static float Max = 0;
            }
            public struct VelocityLimitationDataEndEffectorAlpha1
            {
                /// <summary>
                /// The minimum velocity value of the robot end effector alpha1 [末端 alpha1 允许的最小速度]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximun velocity value of the robot end effector alpha1 [末端 alpha1 允许的最大速度]
                /// </summary>
                public static float Max = 0;
            }
            public struct VelocityLimitationDataEndEffectorBeta1
            {
                /// <summary>
                /// The minimum velocity value of the robot end effector beta1 [末端 beta1 允许的最小速度]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                ///  The maximun velocity value of the robot end effector beta1 [末端 beta1 允许的最大速度]
                /// </summary>
                public static float Max = 0;
            }
            public struct VelocityLimitationDataEndEffectorGamma1
            {
                /// <summary>
                /// The minimum velocity value of the robot end effector gamma1 [末端 gamma1 允许的最小速度]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                ///  The maximun velocity value of the robot end effector gamma1 [末端 gamma1 允许的最大速度]
                /// </summary>
                public static float Max = 0;
            }

            #endregion

            #region end effector acceleration limitation
            public struct AccelerationLimitationDataEndEffectorX1
            {
                /// <summary>
                ///  The minimum acceleration value of the robot end effector x1 [末端 x1 允许的最小加速度]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximun acceleration value of the robot end effector x1 [末端 x1 允许的最大加速度]
                /// </summary>
                public static float Max = 0;
            }
            public struct AccelerationLimitationDataEndEffectorY1
            {
                /// <summary>
                /// The minimum acceleration value of the robot end effector y1 [末端 y1 允许的最小加速度]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximun acceleration value of the robot end effector y1 [末端 y1 允许的最大加速度]
                /// </summary>
                public static float Max = 0;
            }
            public struct AccelerationLimitationDataEndEffectorZ1
            {
                /// <summary>
                ///  The minimum acceleration value of the robot end effector z1 [末端 z1 允许的最小加速度]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximun acceleration value of the robot end effector z1 [末端 z1 允许的最大加速度]
                /// </summary>
                public static float Max = 0;
            }
            public struct AccelerationLimitationDataEndEffectorAlpha1
            {
                /// <summary>
                /// The minimum acceleration value of the robot end effector alpha1 [末端 alpha1 允许的最小加速度]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                /// The maximun acceleration value of the robot end effector alpha1 [末端 alpha1 允许的最大加速度]
                /// </summary>
                public static float Max = 0;
            }
            public struct AccelerationLimitationDataEndEffectorBeta1
            {
                /// <summary>
                /// The minimum acceleration value of the robot end effector beta1 [末端 beta1 允许的最小加速度]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                ///  The maximun acceleration value of the robot end effector beta1 [末端 beta1 允许的最大加速度]
                /// </summary>
                public static float Max = 0;
            }
            public struct AccelerationLimitationDataEndEffectorGamma1
            {
                /// <summary>
                /// The minimum acceleration value of the robot end effector gamma1 [末端 gamma1 允许的最小加速度]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                ///  The maximun acceleration value of the robot end effector gamma1 [末端 gamma1 允许的最大加速度]
                /// </summary>
                public static float Max = 0;
            }

            #endregion

            #region end effector mass limitation

            public struct MassLimitationDataEndEffectorX1
            {
                /// <summary>
                ///  The minimum mass value of the robot end effector x1 [末端 x1 允许的最小质量]
                /// </summary>
                public static float Min = 1;
                /// <summary>
                /// The maximun mass value of the robot end effector x1 [末端 x1 允许的最大质量]
                /// </summary>
                public static float Max = 200;
            }
            public struct MassLimitationDataEndEffectorY1
            {
                /// <summary>
                /// The minimum mass value of the robot end effector y1 [末端 y1 允许的最小质量]
                /// </summary>
                public static float Min =1;
                /// <summary>
                /// The maximun mass value of the robot end effector y1 [末端 y1 允许的最大质量]
                /// </summary>
                public static float Max = 200;
            }
            public struct MassLimitationDataEndEffectorZ1
            {
                /// <summary>
                ///  The minimum mass value of the robot end effector z1 [末端 z1 允许的最小质量]
                /// </summary>
                public static float Min = 1;
                /// <summary>
                /// The maximun mass value of the robot end effector z1 [末端 z1 允许的最大质量]
                /// </summary>
                public static float Max = 200;
            }
            public struct MassLimitationDataEndEffectorAlpha1
            {
                /// <summary>
                /// The minimum mass value of the robot end effector alpha1 [末端 alpha1 允许的最小质量]
                /// </summary>
                public static float Min = 1;
                /// <summary>
                /// The maximun mass value of the robot end effector alpha1 [末端 alpha1 允许的最大质量]
                /// </summary>
                public static float Max = 200;
            }
            public struct MassLimitationDataEndEffectorBeta1
            {
                /// <summary>
                /// The minimum mass value of the robot end effector beta1 [末端 beta1 允许的最小质量]
                /// </summary>
                public static float Min = 1;
                /// <summary>
                ///  The maximun mass value of the robot end effector beta1 [末端 beta1 允许的最大质量]
                /// </summary>
                public static float Max = 200;
            }
            public struct MassLimitationDataEndEffectorGamma1
            {
                /// <summary>
                /// The minimum mass value of the robot end effector gamma1 [末端 gamma1 允许的最小质量]
                /// </summary>
                public static float Min = 1;
                /// <summary>
                ///  The maximun mass value of the robot end effector gamma1 [末端 gamma1 允许的最大质量]
                /// </summary>
                public static float Max = 200;
            }

            #endregion

            #region end effector damping limitation

            public struct DampingLimitationDataEndEffectorX1
            {
                /// <summary>
                ///  The minimum damping value of the robot end effector x1 [末端 x1 允许的最小阻尼]
                /// </summary>
                public static float Min = 1;
                /// <summary>
                /// The maximun damping value of the robot end effector x1 [末端 x1 允许的最大阻尼]
                /// </summary>
                public static float Max = 200;
            }
            public struct DampingLimitationDataEndEffectorY1
            {
                /// <summary>
                /// The minimum damping value of the robot end effector y1 [末端 y1 允许的最小阻尼]
                /// </summary>
                public static float Min = 1;
                /// <summary>
                /// The maximun damping value of the robot end effector y1 [末端 y1 允许的最大阻尼]
                /// </summary>
                public static float Max = 200;
            }
            public struct DampingLimitationDataEndEffectorZ1
            {
                /// <summary>
                ///  The minimum damping value of the robot end effector z1 [末端 z1 允许的最小阻尼]
                /// </summary>
                public static float Min = 1;
                /// <summary>
                /// The maximun damping value of the robot end effector z1 [末端 z1 允许的最大阻尼]
                /// </summary>
                public static float Max = 200;
            }
            public struct DampingLimitationDataEndEffectorAlpha1
            {
                /// <summary>
                /// The minimum damping value of the robot end effector alpha1 [末端 alpha1 允许的最小阻尼]
                /// </summary>
                public static float Min = 1;
                /// <summary>
                /// The maximun damping value of the robot end effector alpha1 [末端 alpha1 允许的最大阻尼]
                /// </summary>
                public static float Max = 200;
            }
            public struct DampingLimitationDataEndEffectorBeta1
            {
                /// <summary>
                /// The minimum damping value of the robot end effector beta1 [末端 beta1 允许的最小阻尼]
                /// </summary>
                public static float Min = 1;
                /// <summary>
                ///  The maximun damping value of the robot end effector beta1 [末端 beta1 允许的最大阻尼]
                /// </summary>
                public static float Max = 200;
            }
            public struct DampingLimitationDataEndEffectorGamma1
            {
                /// <summary>
                /// The minimum damping value of the robot end effector gamma1 [末端 gamma1 允许的最小阻尼]
                /// </summary>
                public static float Min = 1;
                /// <summary>
                ///  The maximun damping value of the robot end effector gamma1 [末端 gamma1 允许的最大阻尼]
                /// </summary>
                public static float Max = 200;
            }

            #endregion

            #region end effector spring limitation

            public struct SpringLimitationDataEndEffectorX1
            {
                /// <summary>
                ///  The minimum spring value of the robot end effector x1 [末端 x1 允许的最小拉力]
                /// </summary>
                public static float Min = 1;
                /// <summary>
                /// The maximun spring value of the robot end effector x1 [末端 x1 允许的最大拉力]
                /// </summary>
                public static float Max = 200;
            }
            public struct SpringLimitationDataEndEffectorY1
            {
                /// <summary>
                /// The minimum spring value of the robot end effector y1 [末端 y1 允许的最小拉力]
                /// </summary>
                public static float Min = 1;
                /// <summary>
                /// The maximun spring value of the robot end effector y1 [末端 y1 允许的最大拉力]
                /// </summary>
                public static float Max = 200;
            }
            public struct SpringLimitationDataEndEffectorZ1
            {
                /// <summary>
                ///  The minimum spring value of the robot end effector z1 [末端 z1 允许的最小拉力]
                /// </summary>
                public static float Min = 1;
                /// <summary>
                /// The maximun spring value of the robot end effector z1 [末端 z1 允许的最大拉力]
                /// </summary>
                public static float Max = 200;
            }
            public struct SpringLimitationDataEndEffectorAlpha1
            {
                /// <summary>
                /// The minimum spring value of the robot end effector alpha1 [末端 alpha1 允许的最小拉力]
                /// </summary>
                public static float Min = 1;
                /// <summary>
                /// The maximun spring value of the robot end effector alpha1 [末端 alpha1 允许的最大拉力]
                /// </summary>
                public static float Max = 200;
            }
            public struct SpringLimitationDataEndEffectorBeta1
            {
                /// <summary>
                /// The minimum spring value of the robot end effector beta1 [末端 beta1 允许的最小拉力]
                /// </summary>
                public static float Min = 1;
                /// <summary>
                ///  The maximun spring value of the robot end effector beta1 [末端 beta1 允许的最大拉力]
                /// </summary>
                public static float Max = 200;
            }
            public struct SpringLimitationDataEndEffectorGamma1
            {
                /// <summary>
                /// The minimum spring value of the robot end effector gamma1 [末端 gamma1 允许的最小拉力]
                /// </summary>
                public static float Min = 1;
                /// <summary>
                ///  The maximun spring value of the robot end effector gamma1 [末端 gamma1 允许的最大拉力]
                /// </summary>
                public static float Max = 200;
            }

            #endregion

            //#region difficult function  limitation
            //public struct CmdJointKineticControlLimitation
            //{
            //    public struct KineticLimitationDataJoint1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入力的最大值
            //        /// </summary>
            //        public static float max=200;

            //        /// <summary>
            //        /// 控制方法中，输入力的最小值
            //        /// </summary>
            //        public static float min=0;
            //    }

            //    public struct KineticLimitationDataJoint2
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入力的最大值
            //        /// </summary>
            //        public static float max=200;

            //        /// <summary>
            //        /// 控制方法中，输入力的最小值
            //        /// </summary>
            //        public static float min=0;
            //    }
            //}

            //public struct CmdJointVelocityControlLimitation
            //{
            //    public struct AccelerationLimitationDataJoint1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入加速度的最大值
            //        /// </summary>
            //        public static float max=2;

            //        /// <summary>
            //        /// 控制方法中，输入加速度的最小值
            //        /// </summary>
            //        public static float min=0.0001f;
            //    }

            //    public struct AccelerationLimitationDataJoint2
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入加速度的最大值
            //        /// </summary>
            //        public static float max=2;

            //        /// <summary>
            //        /// 控制方法中，输入加速度的最小值
            //        /// </summary>
            //        public static float min=0.0001f;
            //    }

            //    public struct VelocityLimitationDataJoint1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入速度的最大值
            //        /// </summary>
            //        public static float max = 1;

            //        /// <summary>
            //        /// 控制方法中，输入速度的最小值
            //        /// </summary>
            //        public static float min=-1;
            //    }

            //    public struct VelocityLimitationDataJoint2
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入速度的最大值
            //        /// </summary>
            //        public static float max=1;

            //        /// <summary>
            //        /// 控制方法中，输入速度的最小值
            //        /// </summary>
            //        public static float min=-1;
            //    }
            //}

            //public struct CmdJointPositionControlLimitation
            //{
            //    public struct AccelerationLimitationDataJoint1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入加速度的最大值
            //        /// </summary>
            //        public static float max=2;

            //        /// <summary>
            //        /// 控制方法中，输入加速度的最小值
            //        /// </summary>
            //        public static float min=0.0001f;
            //    }

            //    public struct AccelerationLimitationDataJoint2
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入加速度的最大值
            //        /// </summary>
            //        public static float max=2;

            //        /// <summary>
            //        /// 控制方法中，输入加速度的最小值
            //        /// </summary>
            //        public static float min=0.0001f;
            //    }

            //    public struct VelocityLimitationDataJoint1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入速度的最大值
            //        /// </summary>
            //        public static float max=1;

            //        /// <summary>
            //        /// 控制方法中，输入速度的最小值
            //        /// </summary>
            //        public static float min=-1;
            //    }

            //    public struct VelocityLimitationDataJoint2
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入速度的最大值
            //        /// </summary>
            //        public static float max=1;

            //        /// <summary>
            //        /// 控制方法中，输入速度的最小值
            //        /// </summary>
            //        public static float min=-1;
            //    }

            //    public struct PositionLimitationDataJoint1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入位置的最大值
            //        /// </summary>
            //        public static float max = 0.6f;

            //        /// <summary>
            //        /// 控制方法中，输入位置的最小值
            //        /// </summary>
            //        public static float min=0;
            //    }

            //    public struct PositionLimitationDataJoint2
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入速度的最大值
            //        /// </summary>
            //        public static float max=0.5f;

            //        /// <summary>
            //        /// 控制方法中，输入速度的最小值
            //        /// </summary>
            //        public static float min=0;
            //    }
            //}

            //public struct CmdPassiveMovementControl1Limitation
            //{
            //    public struct PositionLimitationEndEffectorX1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入位置的最大值
            //        /// </summary>
            //        public static float max=0.6f;

            //        /// <summary>
            //        /// 控制方法中，输入位置的最小值
            //        /// </summary>
            //        public static float min=0f;
            //    }

            //    public struct PositionLimitationEndEffectorY1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入位置的最大值
            //        /// </summary>
            //        public static float max = 0.5f;

            //        /// <summary>
            //        /// 控制方法中，输入位置的最小值
            //        /// </summary>
            //        public static float min = 0f;
            //    }

            //    public struct VelocityLimitationEndEffector
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入速度的最大值
            //        /// </summary>
            //        public static float max=1;

            //        /// <summary>
            //        /// 控制方法中，输入速度的最小值
            //        /// </summary>
            //        public static float min=-1;
            //    }

            //    public struct AccelerationLimitationEndEffector
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入加速度的最大值
            //        /// </summary>
            //        public static float max=2;

            //        /// <summary>
            //        /// 控制方法中，输入加速度的最小值
            //        /// </summary>
            //        public static float min=0.0001f;
            //    }
            //}

            //public struct CmdDrawInfinityCurveControlLimitation
            //{
            //    public struct PositionLimitationEndEffectorX1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入位置的最大值
            //        /// </summary>
            //        public static float max = 0.6f;

            //        /// <summary>
            //        /// 控制方法中，输入位置的最小值
            //        /// </summary>
            //        public static float min = 0f;
            //    }

            //    public struct PositionLimitationEndEffectorY1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入位置的最大值
            //        /// </summary>
            //        public static float max = 0.5f;

            //        /// <summary>
            //        /// 控制方法中，输入位置的最小值
            //        /// </summary>
            //        public static float min = 0f;
            //    }

            //    public struct AixLengthLimitationEndEffectorX1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入轴长的最大值
            //        /// </summary>
            //        public static float max=0.3f;

            //        /// <summary>
            //        /// 控制方法中，输入轴长的最小值
            //        /// </summary>
            //        public static float min=0.01f;
            //    }

            //    public struct AixLengthLimitationEndEffectorY1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入加速度的最大值
            //        /// </summary>
            //        public static float max=0.25f;

            //        /// <summary>
            //        /// 控制方法中，输入加速度的最小值
            //        /// </summary>
            //        public static float min=0.01f;
            //    }

            //    public struct TimeLimitationEndEffector
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入时间的最大值
            //        /// </summary>
            //        public static float max=60;

            //        /// <summary>
            //        /// 控制方法中，输入时间的最小值
            //        /// </summary>
            //        public static float min=1;
            //    }
            //}

            //public struct CmdDrawCircleCurveControlLimitation
            //{
            //    public struct PositionLimitationEndEffectorX1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入位置的最大值
            //        /// </summary>
            //        public static float max = 0.6f;

            //        /// <summary>
            //        /// 控制方法中，输入位置的最小值
            //        /// </summary>
            //        public static float min = 0f;
            //    }

            //    public struct PositionLimitationEndEffectorY1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入位置的最大值
            //        /// </summary>
            //        public static float max = 0.5f;

            //        /// <summary>
            //        /// 控制方法中，输入位置的最小值
            //        /// </summary>
            //        public static float min = 0f;
            //    }

            //    public struct AixLengthLimitationEndEffectorX1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入轴长的最大值
            //        /// </summary>
            //        public static float max=0.3f;

            //        /// <summary>
            //        /// 控制方法中，输入轴长的最小值
            //        /// </summary>
            //        public static float min=0.01f;
            //    }

            //    public struct AixLengthLimitationEndEffectorY1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入加速度的最大值
            //        /// </summary>
            //        public static float max=0.25f;

            //        /// <summary>
            //        /// 控制方法中，输入加速度的最小值
            //        /// </summary>
            //        public static float min=0.01f;
            //    }

            //    public struct TimeLimitationEndEffector
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入时间的最大值
            //        /// </summary>
            //        public static float max=60;

            //        /// <summary>
            //        /// 控制方法中，输入时间的最小值
            //        /// </summary>
            //        public static float min=1;
            //    }
            //}

            //public struct CmdTransparentControlLimitation
            //{
            //    public struct PositionLimitationEndEffectorX1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入位置的最大值
            //        /// </summary>
            //        public static float max = 0.6f;

            //        /// <summary>
            //        /// 控制方法中，输入位置的最小值
            //        /// </summary>
            //        public static float min = 0f;
            //    }

            //    public struct PositionLimitationEndEffectorY1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入位置的最大值
            //        /// </summary>
            //        public static float max = 0.5f;

            //        /// <summary>
            //        /// 控制方法中，输入位置的最小值
            //        /// </summary>
            //        public static float min = 0f;
            //    }

            //    public struct MassLimitationEndEffectorX1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入质量的最大值
            //        /// </summary>
            //        public static float max=200;

            //        /// <summary>
            //        /// 控制方法中，输入质量的最小值
            //        /// </summary>
            //        public static float min=1;
            //    }

            //    public struct MassLimitationEndEffectorY1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入质量的最大值
            //        /// </summary>
            //        public static float max=200;

            //        /// <summary>
            //        /// 控制方法中，输入质量的最小值
            //        /// </summary>
            //        public static float min=1;
            //    }

            //    public struct DampingLimitationEndEffectorX1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入阻力的最大值
            //        /// </summary>
            //        public static float max=200;

            //        /// <summary>
            //        /// 控制方法中，输入阻力的最小值
            //        /// </summary>
            //        public static float min=1;
            //    }

            //    public struct DampingLimitationEndEffectorY1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入质量的最大值
            //        /// </summary>
            //        public static float max=200;

            //        /// <summary>
            //        /// 控制方法中，输入质量的最小值
            //        /// </summary>
            //        public static float min=1;
            //    }

            //    public struct SpringLimitationEndEffectorX1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入弹簧拉力的最大值
            //        /// </summary>
            //        public static float max=200;

            //        /// <summary>
            //        /// 控制方法中，输入弹簧拉力的最小值
            //        /// </summary>
            //        public static float min=1;
            //    }

            //    public struct SpringLimitationEndEffectorY1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入弹簧拉力的最大值
            //        /// </summary>
            //        public static float max=200;

            //        /// <summary>
            //        /// 控制方法中，输入弹簧拉力的最小值
            //        /// </summary>
            //        public static float min=1;
            //    }
            //}

            //public struct CmdTransparentControl1Limitation
            //{
            //    public struct PositionLimitationEndEffectorX1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入位置的最大值
            //        /// </summary>
            //        public static float max = 0.6f;

            //        /// <summary>
            //        /// 控制方法中，输入位置的最小值
            //        /// </summary>
            //        public static float min = 0f;
            //    }

            //    public struct PositionLimitationEndEffectorY1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入位置的最大值
            //        /// </summary>
            //        public static float max = 0.5f;

            //        /// <summary>
            //        /// 控制方法中，输入位置的最小值
            //        /// </summary>
            //        public static float min = 0f;
            //    }

            //    public struct MassLimitationEndEffectorX1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入质量的最大值
            //        /// </summary>
            //        public static float max = 200;

            //        /// <summary>
            //        /// 控制方法中，输入质量的最小值
            //        /// </summary>
            //        public static float min = 1;
            //    }

            //    public struct MassLimitationEndEffectorY1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入质量的最大值
            //        /// </summary>
            //        public static float max = 200;

            //        /// <summary>
            //        /// 控制方法中，输入质量的最小值
            //        /// </summary>
            //        public static float min = 1;
            //    }

            //    public struct DampingLimitationEndEffectorX1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入阻力的最大值
            //        /// </summary>
            //        public static float max = 200;

            //        /// <summary>
            //        /// 控制方法中，输入阻力的最小值
            //        /// </summary>
            //        public static float min = 1;
            //    }

            //    public struct DampingLimitationEndEffectorY1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入质量的最大值
            //        /// </summary>
            //        public static float max = 200;

            //        /// <summary>
            //        /// 控制方法中，输入质量的最小值
            //        /// </summary>
            //        public static float min = 1;
            //    }

            //    public struct SpringLimitationEndEffectorX1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入弹簧拉力的最大值
            //        /// </summary>
            //        public static float max = 200;

            //        /// <summary>
            //        /// 控制方法中，输入弹簧拉力的最小值
            //        /// </summary>
            //        public static float min = 1;
            //    }

            //    public struct SpringLimitationEndEffectorY1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入弹簧拉力的最大值
            //        /// </summary>
            //        public static float max = 200;

            //        /// <summary>
            //        /// 控制方法中，输入弹簧拉力的最小值
            //        /// </summary>
            //        public static float min = 1;
            //    }

            //    public struct TimeLimitationEndEffector
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入时间的最大值
            //        /// </summary>
            //        public static float max = 10;

            //        /// <summary>
            //        /// 控制方法中，输入时间的最小值
            //        /// </summary>
            //        public static float min = 0.1f;
            //    }

            //    public struct FactorLimitationEndEffector
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入变化系数的最大值
            //        /// </summary>
            //        public static float max = 10;

            //        /// <summary>
            //        /// 控制方法中，输入变化系数的最小值
            //        /// </summary>
            //        public static float min = 0.01f;
            //    }
            //}

            //public struct CmdAssistControlWithTargetPositionLimitation
            //{
            //    public struct PositionLimitationEndEffectorX1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入位置的最大值
            //        /// </summary>
            //        public static float max = 0.6f;

            //        /// <summary>
            //        /// 控制方法中，输入位置的最小值
            //        /// </summary>
            //        public static float min = 0f;
            //    }

            //    public struct PositionLimitationEndEffectorY1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入位置的最大值
            //        /// </summary>
            //        public static float max = 0.5f;

            //        /// <summary>
            //        /// 控制方法中，输入位置的最小值
            //        /// </summary>
            //        public static float min = 0f;
            //    }

            //    public struct KineticLimitationEndEffector
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入力矩的最大值
            //        /// </summary>
            //        public static float max = 200;

            //        /// <summary>
            //        /// 控制方法中，输入力矩的最小值
            //        /// </summary>
            //        public static float min = 1;
            //    }
            //}

            //public struct CmdAssistControlWithTargetPosition1Limitation
            //{
            //    public struct PositionLimitationEndEffectorX1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入位置的最大值
            //        /// </summary>
            //        public static float max = 0.6f;

            //        /// <summary>
            //        /// 控制方法中，输入位置的最小值
            //        /// </summary>
            //        public static float min = 0f;
            //    }

            //    public struct PositionLimitationEndEffectorY1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入位置的最大值
            //        /// </summary>
            //        public static float max = 0.5f;

            //        /// <summary>
            //        /// 控制方法中，输入位置的最小值
            //        /// </summary>
            //        public static float min = 0f;
            //    }

            //    public struct VelocityLimitationEndEffectorX1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入速度的最大值
            //        /// </summary>
            //        public static float max = 1;

            //        /// <summary>
            //        /// 控制方法中，输入速度的最小值
            //        /// </summary>
            //        public static float min =-1;
            //    }

            //    public struct VelocityLimitationEndEffectorY1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入速度的最大值
            //        /// </summary>
            //        public static float max = 1;

            //        /// <summary>
            //        /// 控制方法中，输入速度的最小值
            //        /// </summary>
            //        public static float min = -1;
            //    }

            //    public struct FactorLimitationEndEffectorX1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入系数的最大值
            //        /// </summary>
            //        public static float max =10;

            //        /// <summary>
            //        /// 控制方法中，输入系数的最小值
            //        /// </summary>
            //        public static float min = 0.01f;
            //    }

            //    public struct FactorLimitationEndEffectorY1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入系数的最大值
            //        /// </summary>
            //        public static float max = 10;

            //        /// <summary>
            //        /// 控制方法中，输入系数的最小值
            //        /// </summary>
            //        public static float min = 0.01f;
            //    }

            //    public struct KineticLimitationEndEffector
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入力矩的最大值
            //        /// </summary>
            //        public static float max = 200;

            //        /// <summary>
            //        /// 控制方法中，输入力矩的最小值
            //        /// </summary>
            //        public static float min = 0f;
            //    }
            //}

            //public struct CmdKineticControlWithSensorLimitation
            //{
            //    public struct KineticLimitationEndEffectorX1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入力矩的最大值
            //        /// </summary>
            //        public static float max = 200;

            //        /// <summary>
            //        /// 控制方法中，输入力矩的最小值
            //        /// </summary>
            //        public static float min = 1f;
            //    }

            //    public struct KineticLimitationEndEffectorY1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入力矩的最大值
            //        /// </summary>
            //        public static float max = 200;

            //        /// <summary>
            //        /// 控制方法中，输入力矩的最小值
            //        /// </summary>
            //        public static float min = 1f;
            //    }
            //}

            //public struct CmdAssistControlWithoutSensorLimitation
            //{
            //    public struct FactorLimitationEndEffectorX1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入系数的最大值
            //        /// </summary>
            //        public static float max = 10;

            //        /// <summary>
            //        /// 控制方法中，输入系数的最小值
            //        /// </summary>
            //        public static float min = 0.001f;
            //    }

            //    public struct FactorLimitationEndEffectorY1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入系数的最大值
            //        /// </summary>
            //        public static float max = 10;

            //        /// <summary>
            //        /// 控制方法中，输入系数的最小值
            //        /// </summary>
            //        public static float min = 0.001f;
            //    }

            //    public struct KineticLimitationEndEffectorX1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入最大力矩的最大值
            //        /// </summary>
            //        public static float max = 200;

            //        /// <summary>
            //        /// 控制方法中，输入最大力矩的最小值
            //        /// </summary>
            //        public static float min = 0f;
            //    }

            //    public struct KineticLimitationEndEffectorY1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入最大力矩的最大值
            //        /// </summary>
            //        public static float max = 200;

            //        /// <summary>
            //        /// 控制方法中，输入最大力矩的最小值
            //        /// </summary>
            //        public static float min = 0f;
            //    }
            //}

            //public struct CmdMassSimulationControlLimitation
            //{
            //    public struct MassLimitationEndEffectorX1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入质量的最大值
            //        /// </summary>
            //        public static float max =200;

            //        /// <summary>
            //        /// 控制方法中，输入质量的最小值
            //        /// </summary>
            //        public static float min = 1;
            //    }

            //    public struct MassLimitationEndEffectorY1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入质量的最大值
            //        /// </summary>
            //        public static float max = 200;

            //        /// <summary>
            //        /// 控制方法中，输入质量的最小值
            //        /// </summary>
            //        public static float min = 1;
            //    }

            //    public struct StaticFrictionLimitationEndEffectorX1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入静态摩擦系数的最大值
            //        /// </summary>
            //        public static float max = 200;

            //        /// <summary>
            //        /// 控制方法中，输入静态摩擦系数的最小值
            //        /// </summary>
            //        public static float min = 1;
            //    }

            //    public struct StaticFrictionFLimitationEndEffectorY1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入静态摩擦系数的最大值
            //        /// </summary>
            //        public static float max = 200;

            //        /// <summary>
            //        /// 控制方法中，输入静态摩擦系数的最小值
            //        /// </summary>
            //        public static float min = 1;
            //    }

            //    public struct DynamicFrictionLimitationEndEffectorX1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入动态摩擦系数的最大值
            //        /// </summary>
            //        public static float max = 200;

            //        /// <summary>
            //        /// 控制方法中，输入动态摩擦系数的最小值
            //        /// </summary>
            //        public static float min = 1;
            //    }

            //    public struct DynamicFrictionFLimitationEndEffectorY1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入动态摩擦系数的最大值
            //        /// </summary>
            //        public static float max = 200;

            //        /// <summary>
            //        /// 控制方法中，输入动态摩擦系数的最小值
            //        /// </summary>
            //        public static float min = 1;
            //    }
            //}

            //public struct CmdMassSimulationControlWithoutSensorLimitation
            //{
            //    public struct MassLimitationEndEffectorX1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入质量的最大值
            //        /// </summary>
            //        public static float max = 200;

            //        /// <summary>
            //        /// 控制方法中，输入质量的最小值
            //        /// </summary>
            //        public static float min = 1;
            //    }

            //    public struct MassLimitationEndEffectorY1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入质量的最大值
            //        /// </summary>
            //        public static float max = 200;

            //        /// <summary>
            //        /// 控制方法中，输入质量的最小值
            //        /// </summary>
            //        public static float min = 1;
            //    }

            //    public struct StaticFrictionLimitationEndEffectorX1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入静态摩擦系数的最大值
            //        /// </summary>
            //        public static float max = 200;

            //        /// <summary>
            //        /// 控制方法中，输入静态摩擦系数的最小值
            //        /// </summary>
            //        public static float min = 1;
            //    }

            //    public struct StaticFrictionFLimitationEndEffectorY1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入静态摩擦系数的最大值
            //        /// </summary>
            //        public static float max = 200;

            //        /// <summary>
            //        /// 控制方法中，输入静态摩擦系数的最小值
            //        /// </summary>
            //        public static float min = 1;
            //    }

            //    public struct DynamicFrictionLimitationEndEffectorX1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入动态摩擦系数的最大值
            //        /// </summary>
            //        public static float max = 200;

            //        /// <summary>
            //        /// 控制方法中，输入动态摩擦系数的最小值
            //        /// </summary>
            //        public static float min = 1;
            //    }

            //    public struct DynamicFrictionFLimitationEndEffectorY1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入动态摩擦系数的最大值
            //        /// </summary>
            //        public static float max = 200;

            //        /// <summary>
            //        /// 控制方法中，输入动态摩擦系数的最小值
            //        /// </summary>
            //        public static float min = 1;
            //    }
            //}

            //public struct CmdResistControlWithoutSensorLimitation
            //{
            //    public struct FactorLimitationEndEffectorX1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入系数的最大值
            //        /// </summary>
            //        public static float max = 2;

            //        /// <summary>
            //        /// 控制方法中，输入系数的最小值
            //        /// </summary>
            //        public static float min = 0.001f;
            //    }

            //    public struct FactorLimitationEndEffectorY1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入系数的最大值
            //        /// </summary>
            //        public static float max = 2f;

            //        /// <summary>
            //        /// 控制方法中，输入系数的最小值
            //        /// </summary>
            //        public static float min = 0.001f;
            //    }

            //    public struct KineticLimitationEndEffectorX1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入最大力矩的最大值
            //        /// </summary>
            //        public static float max = 200;

            //        /// <summary>
            //        /// 控制方法中，输入最大力矩的最小值
            //        /// </summary>
            //        public static float min = 0;
            //    }

            //    public struct KineticLimitationEndEffectorY1
            //    {
            //        /// <summary>
            //        /// 控制方法中，输入最大力矩的最大值
            //        /// </summary>
            //        public static float max = 200;

            //        /// <summary>
            //        /// 控制方法中，输入最大力矩的最小值
            //        /// </summary>
            //        public static float min = 0f;
            //    }
            //}

            //#endregion

            #region end effector range of motion
            public struct PositionRangeOfMotionEndEffectorX1
            {
                /// <summary>
                /// The motion range of the robot end effector x1 [末端 x1 实际运动范围的最小位置]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                ///  The motion range of the robot end effector x1 [末端 x1 实际运动范围的最大位置]
                /// </summary>
                public static float Max = 0;
            }

            public struct PositionRangeOfMotionEndEffectorY1
            {
                /// <summary>
                /// The motion range of the robot end effector y1 [末端 y1 实际运动范围的最小位置]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                ///  The motion range of the robot end effector y1 [末端 y1 实际运动范围的最大位置]
                /// </summary>
                public static float Max = 0;
            }

            public struct PositionRangeOfMotionEndEffectorZ1
            {
                /// <summary>
                /// The motion range of the robot end effector z1 [末端 z1 实际运动范围的最小位置]
                /// </summary>
                public static float Min = 0;
                /// <summary>
                ///  The motion range of the robot end effector z1 [末端 z1 实际运动范围的最大位置]
                /// </summary>
                public static float Max = 0;
            }

            #endregion
            /// <summary>
            /// <para> @LED light color [LED灯的颜色]              </para>
            /// <para> @retval 1 close [关闭]                     </para>
            /// <para> @retval 2 blue [蓝色]                      </para>
            /// <para> @retval 3 pink [粉色]                      </para>
            /// <para> @retval 4 green [绿色]                     </para>
            /// <para> @retval 5 white [白色]                     </para>
            /// </summary>
            public static LEDColor ledColor = LEDColor.Off;
        }

        #endregion

        #region Sensor
        /// <summary>
        ///  @brief The sensor value [传感器状态]
        /// </summary>
        public class StatusSensor
        {
            /// <summary>
            ///  @brief The value of button sensor 1 [按钮传感器1的数值]
            /// </summary>
            public struct ButtonSensor1
            {
                /// <summary>
                /// The installed state of the button sensor 1 [按钮传感器 1 安装状态]
                /// </summary>
                public static uint Installed = 0;
                /// <summary>
                ///  The access state of the button sensor 1 [按钮传感器 1 通信状态]
                /// </summary>
                public static uint Accessible = 0;
                /// <summary>
                /// The value of the button sensor 1 [按钮传感器 1 值]
                /// </summary>
                public static float Value = 0;
            }

            /// <summary>
            /// @brief The value of button sensor 2 [按钮传感器2的数值]
            /// </summary>
            public struct ButtonSensor2
            {
                /// <summary>
                ///  The installed state of the button sensor 2 [按钮传感器 2 安装状态]
                /// </summary>
                public static uint Installed = 0;
                /// <summary>
                ///  The access state of the button sensor 2 [按钮传感器 2 通信状态]
                /// </summary>
                public static uint Accessible = 0;
                /// <summary>
                ///  The value of the button sensor 2 [按钮传感器 2 值]
                /// </summary>
                public static float Value = 0;
            }


            /// <summary>
            /// @brief The value of button sensor 3 [按钮传感器3的数值]
            /// </summary>
            public struct ButtonSensor3
            {
                /// <summary>
                /// The installed state of the button sensor 3 [按钮传感器 3 安装状态]
                /// </summary>
                public static uint Installed = 0;
                /// <summary>
                /// The access state of the button sensor 3 [按钮传感器 3 通信状态]
                /// </summary>
                public static uint Accessible = 0;
                /// <summary>
                /// The value of the button sensor 3 [按钮传感器 3 值]
                /// </summary>
                public static float Value = 0;
            }

            /// <summary>
            /// @brief The value of button sensor 4 [按钮传感器4的数值]
            /// </summary>
            public struct ButtonSensor4
            {
                /// <summary>
                /// The installed state of the button sensor 4 [按钮传感器 4 安装状态]
                /// </summary>
                public static uint Installed = 0;
                /// <summary>
                /// The access state of the button sensor 4 [按钮传感器 4 通信状态]
                /// </summary>
                public static uint Accessible = 0;
                /// <summary>
                /// The value of the button sensor 4 [按钮传感器 4 值]
                /// </summary>
                public static float Value = 0;
            }

            /// <summary>
            /// @brief The value of button sensor 5 [按钮传感器5的数值]
            /// </summary>
            public struct ButtonSensor5
            {
                /// <summary>
                /// The installed state of the button sensor 5 [按钮传感器 5 安装状态]
                /// </summary>
                public static uint Installed = 0;
                /// <summary>
                /// The access state of the button sensor 5 [按钮传感器 5 通信状态]
                /// </summary>
                public static uint Accessible = 0;
                /// <summary>
                /// The value of the button sensor 5 [按钮传感器 5 值]
                /// </summary>
                public static float Value = 0;
            }

            /// <summary>
            /// @brief The value of button sensor 6 [按钮传感器6的数值]
            /// </summary>
            public struct ButtonSensor6
            {
                /// <summary>
                /// The installed state of the button sensor 6 [按钮传感器 6 安装状态]
                /// </summary>
                public static uint Installed = 0;
                /// <summary>
                /// The access state of the button sensor 6 [按钮传感器 6 通信状态]
                /// </summary>
                public static uint Accessible = 0;
                /// <summary>
                /// The value of the button sensor 6 [按钮传感器 6 值]
                /// </summary>
                public static float Value = 0;
            }

            /// <summary>
            ///  @brief The value of adc sensor 1 [模拟-数字传感器1的数值]
            /// </summary>
            public struct ADCSensor1
            {
                /// <summary>
                /// The installed state of the adc sensor 1 [ADC传感器 1 安装状态]
                /// </summary>
                public static uint Installed = 0;
                /// <summary>
                /// The access state of the adc sensor 1 [ADC传感器 1 通信状态]
                /// </summary>
                public static uint Accessible = 0;
                /// <summary>
                /// The raw value of the adc sensor 1 [按钮传感器 1 原始值]
                /// </summary>
                public static float RawValue = 0;
                /// <summary>
                ///  The calculate value of the adc sensor 1 [按钮传感器 1 校准值]
                /// </summary>
                public static float CalculateValue = 0;
            }

            /// <summary>
            /// @brief The value of adc sensor 2 [模拟-数字传感器2的数值]
            /// </summary>
            public struct ADCSensor2
            {
                /// <summary>
                /// The installed state of the adc sensor 2 [ADC传感器 2 安装状态]
                /// </summary>
                public static uint Installed = 0;
                /// <summary>
                /// The access state of the adc sensor 2 [ADC传感器 2 通信状态]
                /// </summary>
                public static uint Accessible = 0;
                /// <summary>
                /// The raw value of the adc sensor 2 [按钮传感器 2 原始值]
                /// </summary>
                public static float RawValue = 0;
                /// <summary>
                /// The calculate value of the adc sensor 2 [按钮传感器 2 校准值]
                /// </summary>
                public static float CalculateValue = 0;
            }

            /// <summary>
            ///  @brief The value of adc sensor 3 [模拟-数字传感器3的数值]
            /// </summary>
            public struct ADCSensor3
            {
                /// <summary>
                /// The installed state of the adc sensor 3 [ADC传感器 3 安装状态]
                /// </summary>
                public static uint Installed = 0;
                /// <summary>
                /// The access state of the adc sensor 3 [ADC传感器 3 通信状态]
                /// </summary>
                public static uint Accessible = 0;
                /// <summary>
                /// The raw value of the adc sensor 3 [按钮传感器 3 原始值]
                /// </summary>
                public static float RawValue = 0;
                /// <summary>
                /// The calculate value of the adc sensor 3 [按钮传感器 3 校准值]
                /// </summary>
                public static float CalculateValue = 0;
            }

            /// <summary>
            ///  @brief The value of adc sensor 4 [模拟-数字传感器4的数值]
            /// </summary>
            public struct ADCSensor4
            {
                /// <summary>
                /// The installed state of the adc sensor 4 [ADC传感器 4 安装状态]
                /// </summary>
                public static uint Installed = 0;
                /// <summary>
                /// The access state of the adc sensor 4 [ADC传感器 4 通信状态]
                /// </summary>
                public static uint Accessible = 0;
                /// <summary>
                /// The raw value of the adc sensor 4 [按钮传感器 4 原始值]
                /// </summary>
                public static float RawValue = 0;
                /// <summary>
                /// The calculate value of the adc sensor 4 [按钮传感器 4 校准值]
                /// </summary>
                public static float CalculateValue = 0;
            }

            /// <summary>
            /// @brief The value of adc sensor 5 [模拟-数字传感器5的数值]
            /// </summary>
            public struct ADCSensor5
            {
                /// <summary>
                /// The installed state of the adc sensor 5 [ADC传感器 5 安装状态]
                /// </summary>
                public static uint Installed = 0;
                /// <summary>
                /// The access state of the adc sensor 5 [ADC传感器 5 通信状态]
                /// </summary>
                public static uint Accessible = 0;
                /// <summary>
                /// The raw value of the adc sensor 1 [按钮传感器 5 原始值]
                /// </summary>
                public static float RawValue = 0;
                /// <summary>
                ///  The calculate value of the adc sensor 5 [按钮传感器 5 校准值]
                /// </summary>
                public static float CalculateValue = 0;
            }

            /// <summary>
            /// @brief The value of adc sensor 6 [模拟-数字传感器6的数值]
            /// </summary>
            public struct ADCSensor6
            {
                /// <summary>
                ///  The installed state of the adc sensor 6 [ADC传感器 6 安装状态]
                /// </summary>
                public static uint Installed = 0;
                /// <summary>
                ///  The access state of the adc sensor 6 [ADC传感器 6 通信状态]
                /// </summary>
                public static uint Accessible = 0;
                /// <summary>
                /// The raw value of the adc sensor 6 [按钮传感器 6 原始值]
                /// </summary>
                public static float RawValue = 0;
                /// <summary>
                /// The calculate value of the adc sensor 6 [按钮传感器 6 校准值]
                /// </summary>
                public static float CalculateValue = 0;
            }

            /// <summary>
            ///  @brief The value of imu sensor 1 [惯导传感器1的数值]
            /// </summary>
            public struct IMUSensor1
            {
                /// <summary>
                /// The installed state of the imu sensor [IMU 传感器 安装状态]
                /// </summary>
                public static uint Installed = 0;
                /// <summary>
                /// The access state of the imu sensor [IMU 传感器 通信状态]
                /// </summary>
                public static uint Accessible = 0;
                /// <summary>
                ///  The raw value of the imu sensor [IMU 传感器 原始 加速度值]
                /// </summary>
                public static float[] RawAccelerationValue = new float[3] { 0, 0, 0 };
                /// <summary>
                /// The raw value of the imu sensor [IMU 传感器 原始 角速度值]
                /// </summary>
                public static float[] RawAngularVelocityValue = new float[3] { 0, 0, 0 };
                /// <summary>
                /// The raw value of the imu sensor [IMU 传感器 原始 欧拉角值]
                /// </summary>
                public static float[] RawEulerAngleValue = new float[3] { 0, 0, 0 };
                /// <summary>
                /// The calculate value of the imu sensor [IMU 传感器 加速度值]
                /// </summary>
                public static float[] AccelerationValue = new float[3] { 0, 0, 0 };
                /// <summary>
                /// The calculate value of the imu sensor [IMU 传感器 角速度值]
                /// </summary>
                public static float[] AngularVelocityValue = new float[3] { 0, 0, 0 };
                /// <summary>
                /// The calculate value of the imu sensor [IMU 传感器 欧拉角值]
                /// </summary>
                public static float[] EulerAngleValue = new float[3] { 0, 0, 0 };
            }
        }

        #endregion

        #region Timmer
        public static uint ServerLinkMonitorCount = 0;
        private static uint ServerLinkMonitorMaximumCount = 10;

        private static Timer UpdateTimer;
        private static TimerCallback UpdateTimerCallback = new TimerCallback(UpdateTimerCallbackFunction);
        private static uint UpdateTimerPeriodTime = 50;   //函数的时间间隔
        private static uint UpdateTimerPeriodCount = 0;
        private static uint UpdateTimerPeriodMaximumCount = 1000;
        private static bool UpdateTimerActiveFlag = false;

        private static uint ServerLinkMonitorTimerPeriodCount =5;
        private static bool ServerLinkMonitorTimerLocker = false;

        private static uint IAPTimerPeriodCount = 5;
        private static bool IAPTimerLocker = false;

        private static uint APPPeriodicFunctionTimerPeriodCount = 20;
        private static bool APPPeriodicFunctionTimerLocker = false;

        private static uint HardwareStatusPeriodicFunctionTimerPeriodCount = 20;
        private static bool HardwareStatusPeriodicFunctionTimerLocker = false;

        private static uint FlagPeriodicFunctionTimerPeriodCount = 1;
        private static bool FlagPeriodicFunctionTimerLocker = false;

        private static uint RobotDriverStatusPeriodicFunctionTimerPeriodCount = 1;
        private static bool RobotStatusPeriodicFunctionTimerLocker = false;

        private static uint RobotSensorStatusPeriodicFunctionTimerPeriodCount = 1;
        private static bool RobotSensorStatusPeriodicFunctionTimerLocker = false;

        private static uint RobotParameterStatusPeriodicFunctionTimerPeriodCount = 23;
        private static bool RobotParameterStatusPeriodicFunctionTimerLocker = false;

        public static uint RobotParametersRequestTimerPeriodCount = 5;
        private static bool RobotParametersRequestPeriodicTimerLocker = false;
        public static int RobotParametersRecordingMaxCount = 500;

        #endregion

        #region  CurveData
        private static List<string> RobotDataList = new List<string>()
        {
             "PositionDataJoint1",
             "PositionDataJoint2",
             "PositionDataJoint3",
             "PositionDataJoint4",
             "PositionDataJoint5",
             "PositionDataJoint6",
             "VelocityDataJoint1",
             "VelocityDataJoint2",
             "VelocityDataJoint3",
             "VelocityDataJoint4",
             "VelocityDataJoint5",
             "VelocityDataJoint6",
             "KineticDataJoint1",
             "KineticDataJoint2",
             "KineticDataJoint3",
             "KineticDataJoint4",
             "KineticDataJoint5",
             "KineticDataJoint6",
             "PositionDataEndEffectorX1",
             "PositionDataEndEffectorY1",
             "PositionDataEndEffectorZ1",
             "PositionDataEndEffectorAlpha1",
             "PositionDataEndEffectorBeta1",
             "PositionDataEndEffectorGamma1",
             "VelocityDataEndEffectorX1",
             "VelocityDataEndEffectorY1",
             "VelocityDataEndEffectorZ1",
             "VelocityDataEndEffectorAlpha1",
             "VelocityDataEndEffectorBeta1",
             "VelocityDataEndEffectorGamma1",
             "KineticDataEndEffectorX1",
             "KineticDataEndEffectorY1",
             "KineticDataEndEffectorZ1",
             "KineticDataEndEffectorAlpha1",
             "KineticDataEndEffectorBeta1",
             "KineticDataEndEffectorGamma1",
             "PositionDataEndEffectorX2",
             "PositionDataEndEffectorY2",
             "PositionDataEndEffectorZ2",
             "PositionDataEndEffectorAlpha2",
             "PositionDataEndEffectorBeta2",
             "PositionDataEndEffectorGamma2",
             "VelocityDataEndEffectorX2",
             "VelocityDataEndEffectorY2",
             "VelocityDataEndEffectorZ2",
             "VelocityDataEndEffectorAlpha2",
             "VelocityDataEndEffectorBeta2",
             "VelocityDataEndEffectorGamma2",
             "KineticDataEndEffectorX2",
             "KineticDataEndEffectorY2",
             "KineticDataEndEffectorZ2",
             "KineticDataEndEffectorAlpha2",
             "KineticDataEndEffectorBeta2",
             "KineticDataEndEffectorGamma2",
        };

        private static List<FieldInfo> RobotDataFieldInfoList = new List<FieldInfo>();

        /// <summary>
        /// 所有机器数据的字典集合，键：字段的字符串名称；值：对应字段的所有数据 
        /// </summary>
        public static Dictionary<string, List<float>> AllRobotDataDic = new Dictionary<string, List<float>>();

        /// <summary>
        /// 截取的机器数据的字典集合，键：字段的字符串名称；值：对应字段的数据
        /// </summary>
        public static Dictionary<string, List<float>> PartRobotDataDic = new Dictionary<string, List<float>>();

        public static List<System.DateTime> TimestampsList = new List<System.DateTime>();

        #endregion

        #region dic
        /// <summary>
        /// 根据机器类型对应到产品信息的字典，键：机械的SN号，值：对应产品的信息
        /// </summary>
        public static Dictionary<RobotSerialNumber, ProductInfo> mechanismTypeToInfoDic = new Dictionary<RobotSerialNumber, ProductInfo>()
        {
            {RobotSerialNumber.M1_A_S_F_100_01_S_CN,new ProductInfo("AnkleMotus","STANDARD") },
            {RobotSerialNumber.M1_A_S_M_100_01_P_CN,new ProductInfo("AnkleMotus","STANDARD") },
            {RobotSerialNumber.M1_W_S_F_100_01_S_CN,new ProductInfo("AnkleMotus","STANDARD") },
            {RobotSerialNumber.M1_S_1_M_100_01_S_CN,new ProductInfo("AnkleMotus","R&D1") },
            {RobotSerialNumber.M1_S_2_M_100_01_S_CN,new ProductInfo("AnkleMotus","R&D2") },
            {RobotSerialNumber.M1_S_3_M_100_01_S_CN,new ProductInfo("AnkleMotus","R&D3") },
            {RobotSerialNumber.M2_O_S_F_02_01_S_CN ,new ProductInfo("Fourier M2","STANDARD") },
            {RobotSerialNumber.M2_O_K_F_02_01_S_CN ,new ProductInfo("Fourier M2","KIDS") },
            {RobotSerialNumber.M2_O_P_F_02_01_S_CN ,new ProductInfo("Fourier M2","PLUS") },
            {RobotSerialNumber.M2_O_S_F_03_01_S_CN ,new ProductInfo("Fourier M2","STANDARD") },
            {RobotSerialNumber.M2_O_K_F_03_01_S_CN ,new ProductInfo("Fourier M2","KIDS") },
            {RobotSerialNumber.M2_O_P_F_03_01_S_CN ,new ProductInfo("Fourier M2","PLUS") },
            {RobotSerialNumber.M2_O_S_F_04_01_S_CN ,new ProductInfo("Fourier M2","STANDARD") },
            {RobotSerialNumber.M2_O_K_F_04_01_S_CN ,new ProductInfo("Fourier M2","KIDS") },
            {RobotSerialNumber.M2_O_S_F_05_01_S_CN ,new ProductInfo("Fourier M2","STANDARD") },
            {RobotSerialNumber.M2_O_S_M_05_02_S_CN ,new ProductInfo("Fourier M2","STANDARD") },
            {RobotSerialNumber.M2_O_K_F_05_01_S_CN ,new ProductInfo("Fourier M2","KIDS") },
            {RobotSerialNumber.M2_P_S_M_100_01_S_CN,new ProductInfo("ArmMotus M2 Pro","STANDARD") },
            {RobotSerialNumber.M4_T_S_M_100_01_S_CN ,new ProductInfo("","STANDARD") },
            {RobotSerialNumber.M4_O_S_F_100_01_S_CN,new ProductInfo("","STANDARD") },
        };

        public  class ProductInfo 
        {
            public  ProductInfo(string deviceName,string subDeviceName)
            {
                this.deviceName = deviceName;
                this.subDeviceName = subDeviceName;
            }
            public string deviceName;
            public string subDeviceName;
        }
        #endregion 

        #region MotorErrorCode
        /// <summary>
        ///<para> @brief The error code of the motor [机器人电机的错误码]                       </para>
        ///<para>                                                                             </para>
        ///<para> @note Not used right now [暂未使用]                                          </para>
        /// </summary>
        public class StatusMotorErrorCode
        {
            public static uint Motor1 = 0;
            public static uint Motor2 = 0;
            public static uint Motor3 = 0;
            public static uint Motor4 = 0;
            public static uint Motor5 = 0;
            public static uint Motor6 = 0;
        }

        #endregion

        #region DebugTool
        public class DebugTool
        {
            public static string DebugToolVersion="2.0.0.18";
        }
        #endregion 
    }
}

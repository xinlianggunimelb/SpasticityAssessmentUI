/**
* @file DynalinkHSPara.cs
* @brief Unity Communication Interface Parameter with MMU
* @details 
* @mainpage 
* @author Jason(Chen Xin)
* @email xin.chen@fftai.com
* @version 1.0.0
* @date 2019-01-24
* @license Private
*/

using System;

namespace FFTAICommunicationLib
{
    public partial class DynaLinkHS
    {

        /// @brief IAP boot mode [启动模式]
		public enum IAPBootMode : uint
        {
            NONE = 0x00, ///< default [默认，进入 bootloader 模式]
            IAP = 0x01, ///< bootloader [进入 bootloader 模式]
            APP = 0x02, ///< application [进入 application 模式]
		}

        /// @brief IAP work status [运行状态]
		public enum IAPWorkStatus : uint
        {
            NONE = 0x00, ///< default [默认，无意义]
            IAP = 0x01, ///< bootloader [当前为 bootloader 模式]
            APP = 0x02, ///< application [当前为 application 模式]
		}

        /// @brief IAP upgrade status [底层程序升级状态]
		public enum IAPUpgradeStatus : uint
        {
            READY = 0x00, ///< ready [准备]
            RUNNING = 0x01, ///< running [运行中]
            SUCCESS = 0xAA, ///< success [成功]
            FAIL = 0xFF, ///< fail [失败]
		}

        /// @brief robot type [机器人类型]
        public enum RobotType : uint
        {
            NONE = 0x00000000, ///< none [无类型，接口层使用无意义]

            H1 = 0x48310000, ///< H1 [H1 机器人]
            H4 = 0x48340000, ///< H1 [H4 机器人]
            M1 = 0x4D310000, ///< M1 [M1 机器人]
            M1_L = 0X4D311675, ///<M1_L[M1_机器人]
            M2 = 0x4D320000, ///< M2 [M2 机器人]
            M3 = 0x4D330000, ///< M3 [M3 机器人]
            M4 = 0x4D340000, ///< M4 [M4 机器人]
            M6 = 0x4D360000, ///< M6 [M6 机器人]
            X1 = 0x58310000, ///< X1 [X1 机器人]
            X2 = 0x58320000, ///< X2 [X2 机器人]

            All = 0x7FFFFFFF, ///< All [所有机器人，接口层使用无意义]
        }

        /// @brief mechanism type [机器人类型]
        public enum MechanismType : uint
        {
            NONE = 0x00000000, ///< none [无类型，接口层使用无意义]

            V1 = 0x010101, ///< Verion1 [机械结构 第1版]
            V2 = 0x010102, ///< Verion2 [机械结构 第2版]
            V3 = 0x010103, ///< Verion3 [机械结构 第3版]
            V4 = 0x010104, ///< Verion4 [机械结构 第4版]
            V5 = 0x010105, ///< Verion5 [机械结构 第5版]
            V6 = 0x010106,
            V7 = 0x010107,
            V8 = 0x010108,
            V9 = 0x010109,

            M1_AF1001_SY_CN_01 = 0x01010101,
            M1_AF1001_SX_CN_01 = 0x01020101,
            M1_AF1001_KX_CN_01 = 0x01040101,
            M1_AF1001_PX_CN_01 = 0x01060101,
            M1_AF1001_MX_CN_01 = 0x01080101,
            M1_AF1001_GX_CN_01 = 0x01010102,
            M1_WF1001_SY_CN_01 = 0x02010101,
            M1_WF1001_SX_CN_01 = 0X02020101,
            M1_WF1001_GX_CN_01 = 0x02010102,
            M1_WF1001_PX_CN_01 = 0X02060101,
            M1_WF1001_KX_CN_01 = 0X02040101,
            M1_WF1001_MX_CN_01 = 0X02080101,
            M1_WF1002_SY_CN_01 = 0x02010103,


            M1_L_TEXT = 0x03333333,

            M2_D02_SY_CN_01 = 0x02010101,
            M2_D02_KY_CN_01 = 0x02030101,
            M2_D02_PY_CN_01 = 0x02050101,
            M2_D03_SY_CN_01 = 0x03010101,
            M2_D03_KY_CN_01 = 0x03030101,
            M2_D03_PY_CN_01 = 0x03050101,
            M2_D04_SY_CN_01 = 0x04010101,
            M2_D04_KY_CN_01 = 0x04030101,
            M2_D05_SY_CN_01 = 0x05010101,
            M2_D05_SY_CN_02 = 0x05010102,
            M2_D05_KY_CN_01 = 0x05030101,
            M2_PRI_SY_CN_01 = 0x01010101,
        }

        /// @brief robot serial number [机器人SN号]
        public enum RobotSerialNumber : ulong
        {
            NONE = 0x0000000000000000,

            // M1
            //M1_A_S_S_100_01_S_CN = 0x0101010101010101,
            //M1_A_S_M_100_01_P_CN = 0x0101010201010201,
            //M1_W_S_S_100_01_S_CN = 0x0102010101010101,
            //M1_A_K_M_100_01_P_CN = 0x0101020201010201,
            //M1_A_P_M_100_01_P_CN = 0x0101030201010201,
            //M1_A_M_M_100_01_P_CN = 0x0101040201010201,
            //M1_A_S_S_100_02_S_CN = 0x0101010101020101,
            //M1_W_S_S_100_02_S_CN = 0x0102010101020101,
            //M1_W_S_S_100_03_S_CN = 0x0102010101030101,
            M1_A_S_F_100_01_S_CN= 0x0101010106010101,
            M1_A_S_M_100_01_P_CN =0x0101010206010201,
            M1_W_S_F_100_01_S_CN =0x0102010106010101,
            
            //M1_L
            M1_S_1_M_100_01_S_CN =0x0103F00206010101,
            M1_S_2_M_100_01_S_CN =0x0103F10206010101,
            M1_S_3_M_100_01_S_CN =0x0103F20206010101,

            // M2
            M2_O_S_F_02_01_S_CN = 0x0201010102010101,
            M2_O_K_F_02_01_S_CN = 0x0201020102010101,
            M2_O_P_F_02_01_S_CN = 0x0201030102010101,
            M2_O_S_F_03_01_S_CN = 0x0201010103010101,
            M2_O_K_F_03_01_S_CN = 0x0201020103010101,
            M2_O_P_F_03_01_S_CN = 0x0201030103010101,
            M2_O_S_F_04_01_S_CN = 0x0201010104010101,
            M2_O_K_F_04_01_S_CN = 0x0201020104010101,
            M2_O_S_F_05_01_S_CN = 0x0201010105010101,
            M2_O_S_M_05_02_S_CN = 0x0201010205020101,
            M2_O_K_F_05_01_S_CN = 0x0201020105010101,
            M2_P_S_M_100_01_S_CN = 0x0202010206010101,

            // M4
            M4_T_S_M_100_01_S_CN = 0x0402010206010101,
            M4_O_S_F_100_01_S_CN = 0x0401010106010101,
        }

        /// @brief work mode [工作模式]
        public enum WorkMode : uint
        {
            DEBUG = 0x01, ///< Debug mode [调试模式]
            RELAY = 0x02, ///< Relay mode [中继模式]
            MASTER_CONTROL = 0x03, ///< Master control mode [主控模式]
        }

        public enum ExoMotusState
        {
            NONE = 0x00,

            STOP = 0x01,
            PAUSE = 0x02,
            JOG = 0x03,

            SIT = 0x04,
            STAND = 0x05,

            CALIBRATESIT = 0x06,
        
            WALK = 0x07,
    }

        /// <summary>
        /// 关节类型
        /// </summary>
        public enum JointType
        {
            JOINT1,    //关节1
            JOINT2,    //关节2
            JOINT3,    //关节3
            JOINT4,    //关节4
            JOINT5,    //关节5
            JOINT6,    //关节6
            JOINT7     //关节7
        }


        /// <summary>
        /// LED灯的颜色
        /// </summary>
        public enum LEDColor:uint
        {
            //Off = 0x01,
            //Blue = 0x02,
            //Pink = 0x03,
            //Green = 0x04,
            //White = 0x05,

            Off = 0x01,
            White = 0x02,
            Cyan = 0x03,
            Yellow = 0x04,
            Magenta = 0x05,
            Red = 0x06,
            Green = 0x07,
            Blue = 0x08,
        }

        /// <summary>
        /// 一共有六种种模式：
        /// Close ： 关灯
        /// BrightColorMode ：调整三个颜色的亮度
        /// SingleColorMode ：单个颜色常亮
        /// BreatheColorMode ：七色循环呼吸
        /// MultipleBreatheColorMode ：单色呼吸
        /// MultipleGradientColorMode ：七色渐变
        /// </summary>
        public enum LEDCMD:uint
        {
            Close = 0x00,
            RGBColorMode = 0x01,
            SingleColorMode = 0x02,
            MultipleBreatheColorMode = 0x03,
            SingleBreatheColorMode = 0x04,
            MultipleGradientColorMode = 0x05,
        }

        /// <summary>
        /// 通信协议版本
        /// </summary>
        public enum ProtocolVersion
        {
            Version2,
            Version3,
        }
    }
}

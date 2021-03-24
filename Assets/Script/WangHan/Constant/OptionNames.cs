using FFTAICommunicationLib;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 下拉列表中列表元素的配置类
/// </summary>
public class OptionList
{
    /// <summary> 曲线类型名称集合 /// </summary>
    public static List<string> curveList = new List<string>()
    {
        CurveNames.none,
        CurveNames.positionDataJoint1,
        CurveNames.positionDataJoint2,
        CurveNames.positionDataJoint3,
        CurveNames.positionDataJoint4,
        CurveNames.positionDataJoint5,
        CurveNames.positionDataJoint6,
        CurveNames.velocityDataJoint1,
        CurveNames.velocityDataJoint2,
        CurveNames.velocityDataJoint3,
        CurveNames.velocityDataJoint4,
        CurveNames.velocityDataJoint5,
        CurveNames.velocityDataJoint6,
        CurveNames.kineticDataJoint1,
        CurveNames.kineticDataJoint2,
        CurveNames.kineticDataJoint3,
        CurveNames.kineticDataJoint6,
        CurveNames.kineticDataJoint4,
        CurveNames.kineticDataJoint5,
        CurveNames.positionDataEndEffectorX1,
        CurveNames.positionDataEndEffectorY1,
        CurveNames.positionDataEndEffectorZ1,
        CurveNames.positionDataEndEffectorAlpha1,
        CurveNames.positionDataEndEffectorBeta1,
        CurveNames.positionDataEndEffectorGamma1,
        CurveNames.velocityDataEndEffectorX1,
        CurveNames.velocityDataEndEffectorY1,
        CurveNames.velocityDataEndEffectorZ1,
        CurveNames.velocityDataEndEffectorAlpha1,
        CurveNames.velocityDataEndEffectorBeta1,
        CurveNames.velocityDataEndEffectorGamma1,
        CurveNames.kineticDataEndEffectorX1,
        CurveNames.kineticDataEndEffectorY1,
        CurveNames.kineticDataEndEffectorZ1,
        CurveNames.kineticDataEndEffectorAlpha1,
        CurveNames.kineticDataEndEffectorBeta1,
        CurveNames.kineticDataEndEffectorGamma1,
        CurveNames.positionDataEndEffectorX2,
        CurveNames.positionDataEndEffectorY2,
        CurveNames.positionDataEndEffectorZ2,
        CurveNames.positionDataEndEffectorAlpha2,
        CurveNames.positionDataEndEffectorBeta2,
        CurveNames.positionDataEndEffectorGamma2,
        CurveNames.velocityDataEndEffectorX2,
        CurveNames.velocityDataEndEffectorY2,
        CurveNames.velocityDataEndEffectorZ2,
        CurveNames.velocityDataEndEffectorAlpha2,
        CurveNames.velocityDataEndEffectorBeta2,
        CurveNames.velocityDataEndEffectorGamma2,
        CurveNames.kineticDataEndEffectorX2,
        CurveNames.kineticDataEndEffectorY2,
        CurveNames.kineticDataEndEffectorZ2,
        CurveNames.kineticDataEndEffectorAlpha2,
        CurveNames.kineticDataEndEffectorBeta2,
        CurveNames.kineticDataEndEffectorGamma2,
    };

    /// <summary> 基础方法名称集合 /// </summary>
    public static List<string> basicNamesList = new List<string>()
    {
        BasicFunctionNames.jog,
        BasicFunctionNames.jointTorque,
        BasicFunctionNames.jointVelocity,
        BasicFunctionNames.jointPosition,
        BasicFunctionNames.endEffectorTorque,
        BasicFunctionNames.endEffectorVelocity,
        BasicFunctionNames.endEffectorPosition,
    };

    /// <summary> 高等方法名称集合 /// </summary>
    public static List<string> advanceNamesList = new List<string>()
    {
        AdvanceFunctionNames.passiveDriver,
        AdvanceFunctionNames.passiveTCurve,
        AdvanceFunctionNames.passiveSCurve,
        AdvanceFunctionNames.passiveMJCurve,
        AdvanceFunctionNames.passiveTransparent,
        AdvanceFunctionNames.passiveInfinity,
        AdvanceFunctionNames.passiveCircleCurve,
        AdvanceFunctionNames.passiveExoMotusPassive,
        AdvanceFunctionNames.assistTransparent,
        AdvanceFunctionNames.assistTransparent_1,
        AdvanceFunctionNames.assistKineticTarget,
        AdvanceFunctionNames.assistKineticTarget1,
        AdvanceFunctionNames.activeTransparent,
        AdvanceFunctionNames.activeTunnelGuidance,
        AdvanceFunctionNames.activeKinetic,
        AdvanceFunctionNames.activeAssistKineticNoSensor,
        AdvanceFunctionNames.activeMassSimulation,
        AdvanceFunctionNames.activeMassSimulationNoSensor,
        AdvanceFunctionNames.resistKinetic,
        AdvanceFunctionNames.resistKinecticResistNoSensor
    };

    /// <summary> 设置方法名称集合 /// </summary>
    public static List<string> settingNamesList = new List<string>()
    {
        SettinFunctionNames.robot,
        SettinFunctionNames.network,
        SettinFunctionNames.sensor,
        SettinFunctionNames.update,
        SettinFunctionNames.ambientLight,
    };

    /// <summary> 机器类型/// </summary>
    public static List<string> robotType = new List<string>()
    {
        DynaLinkHS.RobotType.H1.ToString(),
        DynaLinkHS.RobotType.H4.ToString(),
        DynaLinkHS.RobotType.M1.ToString(),
        DynaLinkHS.RobotType.M1_L.ToString(),
        DynaLinkHS.RobotType.M2.ToString(),
        DynaLinkHS.RobotType.M3.ToString(),
        DynaLinkHS.RobotType.M4.ToString(),
        DynaLinkHS.RobotType.M6.ToString(),
        DynaLinkHS.RobotType.X1.ToString(),
        DynaLinkHS.RobotType.X2.ToString()
    };
}

public static class OptionDictionary
{
    /// <summary>根据机器类型来选择机器的版本号 /// </summary>
    public static Dictionary<string, List<string>> robotVersionDic = new Dictionary<string, List<string>>()
    {
        { DynaLinkHS.RobotType.H1.ToString(),new List<string>() },
        { DynaLinkHS.RobotType.H4.ToString(),new List<string>()},
        { DynaLinkHS.RobotType.M1.ToString(),new List<string>()
            {
               "M1_AF1001_SY_CN_01",
               "M1_AF1001_SX_CN_01",
               "M1_AF1001_KX_CN_01",
               "M1_AF1001_PX_CN_01",
               "M1_AF1001_MX_CN_01",
               "M1_AF1001_GX_CN_01",
               "M1_WF1001_SY_CN_01",
               "M1_WF1001_SX_CN_01",
               "M1_WF1001_GX_CN_01",
               "M1_WF1001_PX_CN_01",
               "M1_WF1001_KX_CN_01",
               "M1_WF1001_MX_CN_01",
               "M1_WF1002_SY_CN_01",
            }
        },
        { DynaLinkHS.RobotType.M1_L.ToString(),new List<string>()
            {
                DynaLinkHS.MechanismType.M1_L_TEXT.ToString()
            }
        },
        { DynaLinkHS.RobotType.M2.ToString(), new List<string>()
            {
                "M2_D02_SY_CN_01",
                "M2_D02_KY_CN_01",
                "M2_D02_PY_CN_01",
                "M2_D03_SY_CN_01",
                "M2_D03_KY_CN_01",
                "M2_D03_PY_CN_01",
                "M2_D04_SY_CN_01",
                "M2_D04_KY_CN_01",
                "M2_D05_SY_CN_01",
                "M2_D05_SY_CN_02",
                "M2_D05_KY_CN_01",
                "M2_PRI_SY_CN_01"
            }
        },
        { DynaLinkHS.RobotType.M3.ToString(), new List<string>() },
        { DynaLinkHS.RobotType.M4.ToString(), new List<string>() },
        { DynaLinkHS.RobotType.M6.ToString(), new List<string>() },
        { DynaLinkHS.RobotType.X1.ToString(), new List<string>() },
        { DynaLinkHS.RobotType.X2.ToString(), new List<string>() },
    };

    /// <summary>根据机器类型来选择机器的序列号/// </summary>
    public static Dictionary<string, List<string>> robotSerialNumberDic = new Dictionary<string, List<string>>()
    {
        { DynaLinkHS.RobotType.H1.ToString(),new List<string>() },
        { DynaLinkHS.RobotType.H4.ToString(),new List<string>()},
        { DynaLinkHS.RobotType.M1.ToString(),new List<string>()
            {
                DynaLinkHS.RobotSerialNumber.M1_A_S_F_100_01_S_CN.ToString(),
                DynaLinkHS.RobotSerialNumber.M1_A_S_M_100_01_P_CN.ToString(),
                DynaLinkHS.RobotSerialNumber.M1_W_S_F_100_01_S_CN.ToString(),
            }
        },
        { DynaLinkHS.RobotType.M1_L.ToString(),new List<string>()
            {
               DynaLinkHS.RobotSerialNumber.M1_S_1_M_100_01_S_CN.ToString(),
               DynaLinkHS.RobotSerialNumber.M1_S_2_M_100_01_S_CN.ToString(),
               DynaLinkHS.RobotSerialNumber.M1_S_3_M_100_01_S_CN.ToString(),
            }
        },
        { DynaLinkHS.RobotType.M2.ToString(), new List<string>()
            {
                DynaLinkHS.RobotSerialNumber.M2_O_S_F_02_01_S_CN.ToString(),
                DynaLinkHS.RobotSerialNumber.M2_O_K_F_02_01_S_CN.ToString(),
                DynaLinkHS.RobotSerialNumber.M2_O_P_F_02_01_S_CN.ToString(),
                DynaLinkHS.RobotSerialNumber.M2_O_S_F_03_01_S_CN.ToString(),
                DynaLinkHS.RobotSerialNumber.M2_O_K_F_03_01_S_CN.ToString(),
                DynaLinkHS.RobotSerialNumber.M2_O_P_F_03_01_S_CN.ToString(),
                DynaLinkHS.RobotSerialNumber.M2_O_S_F_04_01_S_CN.ToString(),
                DynaLinkHS.RobotSerialNumber.M2_O_K_F_04_01_S_CN.ToString(),
                DynaLinkHS.RobotSerialNumber.M2_O_S_F_05_01_S_CN.ToString(),
                DynaLinkHS.RobotSerialNumber.M2_O_S_M_05_02_S_CN.ToString(),
                DynaLinkHS.RobotSerialNumber.M2_O_K_F_05_01_S_CN.ToString(),
                DynaLinkHS.RobotSerialNumber.M2_P_S_M_100_01_S_CN.ToString()
            }
        },
        { DynaLinkHS.RobotType.M3.ToString(), new List<string>() },
        { DynaLinkHS.RobotType.M4.ToString(), new List<string>()
            {
                DynaLinkHS.RobotSerialNumber.M4_T_S_M_100_01_S_CN.ToString(),
                DynaLinkHS.RobotSerialNumber.M4_O_S_F_100_01_S_CN.ToString()
            }
        },
        { DynaLinkHS.RobotType.M6.ToString(), new List<string>() },
        { DynaLinkHS.RobotType.X1.ToString(), new List<string>() },
        { DynaLinkHS.RobotType.X2.ToString(), new List<string>() },
    };

    /// <summary>根据机器类型和机器的版本号枚举数值来选择机器版本字符串 /// </summary>
    public static Dictionary<string, Dictionary<DynaLinkHS.MechanismType,string>> robotVersionValueDic = new Dictionary<string, Dictionary<DynaLinkHS.MechanismType,string>>()
    {
         { DynaLinkHS.RobotType.H1.ToString(),new Dictionary<DynaLinkHS.MechanismType,string>() },
        { DynaLinkHS.RobotType.H4.ToString(),new Dictionary<DynaLinkHS.MechanismType,string>()},
        { DynaLinkHS.RobotType.M1.ToString(),new Dictionary<DynaLinkHS.MechanismType,string>()
            {
             {DynaLinkHS.MechanismType.M1_AF1001_SY_CN_01,"M1_AF1001_SY_CN_01"},
             {DynaLinkHS.MechanismType.M1_AF1001_SX_CN_01,"M1_AF1001_SX_CN_01"},
             {DynaLinkHS.MechanismType.M1_AF1001_KX_CN_01,"M1_AF1001_KX_CN_01"},
             {DynaLinkHS.MechanismType.M1_AF1001_PX_CN_01,"M1_AF1001_PX_CN_01"},
             {DynaLinkHS.MechanismType.M1_AF1001_MX_CN_01,"M1_AF1001_MX_CN_01"},
             {DynaLinkHS.MechanismType.M1_AF1001_GX_CN_01,"M1_AF1001_GX_CN_01"},
             {DynaLinkHS.MechanismType.M1_WF1001_SY_CN_01,"M1_WF1001_SY_CN_01"},
             {DynaLinkHS.MechanismType.M1_WF1001_SX_CN_01,"M1_WF1001_SX_CN_01"},
             {DynaLinkHS.MechanismType.M1_WF1001_GX_CN_01,"M1_WF1001_GX_CN_01"},
             {DynaLinkHS.MechanismType.M1_WF1001_PX_CN_01,"M1_WF1001_PX_CN_01"},
             {DynaLinkHS.MechanismType.M1_WF1001_KX_CN_01,"M1_WF1001_KX_CN_01"},
             {DynaLinkHS.MechanismType.M1_WF1001_MX_CN_01,"M1_WF1001_MX_CN_01"},
             {DynaLinkHS.MechanismType.M1_WF1002_SY_CN_01,"M1_WF1002_SY_CN_01"},
            }
        },
        { DynaLinkHS.RobotType.M1_L.ToString(),new Dictionary<DynaLinkHS.MechanismType,string>()
            {
                { DynaLinkHS.MechanismType.M1_L_TEXT,"M1_L_TEXT" },
            }
        },
        { DynaLinkHS.RobotType.M2.ToString(), new Dictionary<DynaLinkHS.MechanismType,string>()
            {
               {DynaLinkHS.MechanismType.M2_D02_SY_CN_01,"M2_D02_SY_CN_01"},
               {DynaLinkHS.MechanismType.M2_D02_KY_CN_01,"M2_D02_KY_CN_01"},
               {DynaLinkHS.MechanismType.M2_D02_PY_CN_01,"M2_D02_PY_CN_01"},
               {DynaLinkHS.MechanismType.M2_D03_SY_CN_01,"M2_D03_SY_CN_01"},
               {DynaLinkHS.MechanismType.M2_D03_KY_CN_01,"M2_D03_KY_CN_01"},
               {DynaLinkHS.MechanismType.M2_D03_PY_CN_01,"M2_D03_PY_CN_01"},
               {DynaLinkHS.MechanismType.M2_D04_SY_CN_01,"M2_D04_SY_CN_01"},
               {DynaLinkHS.MechanismType.M2_D04_KY_CN_01,"M2_D04_KY_CN_01"},
               {DynaLinkHS.MechanismType.M2_D05_SY_CN_01,"M2_D05_SY_CN_01"},
               {DynaLinkHS.MechanismType.M2_D05_SY_CN_02,"M2_D05_SY_CN_02"},
               {DynaLinkHS.MechanismType.M2_D05_KY_CN_01,"M2_D05_KY_CN_01"},
               {DynaLinkHS.MechanismType.M2_PRI_SY_CN_01,"M2_PRI_SY_CN_01"},
            }
        },
        { DynaLinkHS.RobotType.M3.ToString(), new Dictionary<DynaLinkHS.MechanismType,string>() },
        { DynaLinkHS.RobotType.M4.ToString(), new Dictionary<DynaLinkHS.MechanismType,string>() },
        { DynaLinkHS.RobotType.M6.ToString(), new Dictionary<DynaLinkHS.MechanismType,string>() },
        { DynaLinkHS.RobotType.X1.ToString(), new Dictionary<DynaLinkHS.MechanismType,string>() },
        { DynaLinkHS.RobotType.X2.ToString(), new Dictionary<DynaLinkHS.MechanismType,string>() },
    };

    /// <summary>机器人类型和对应关节数量的字典 /// </summary>
    public static Dictionary<DynaLinkHS.RobotType, int> jointAmountDic = new Dictionary<DynaLinkHS.RobotType, int>()
    {
        {DynaLinkHS.RobotType.H1, 1},
        {DynaLinkHS.RobotType.M1, 1},
        {DynaLinkHS.RobotType.M1_L, 1},
        {DynaLinkHS.RobotType.M2, 2},
        {DynaLinkHS.RobotType.M3, 3},
        {DynaLinkHS.RobotType.X2, 4},
        {DynaLinkHS.RobotType.H4, 4},
        {DynaLinkHS.RobotType.M4, 4},
        {DynaLinkHS.RobotType.M6, 6}
    };

    /// <summary>不同机器对应运动类型/// </summary>
    public static Dictionary<DynaLinkHS.RobotType, MoveType> moveTypeDic = new Dictionary<DynaLinkHS.RobotType, MoveType>()
    {
        { DynaLinkHS.RobotType.H1, MoveType.Line},
        { DynaLinkHS.RobotType.H4, MoveType.Line},
        { DynaLinkHS.RobotType.M1, MoveType.Rotate},
        { DynaLinkHS.RobotType.M1_L,MoveType.Line},
        { DynaLinkHS.RobotType.M2,MoveType.Line},
        { DynaLinkHS.RobotType.M3,MoveType.Rotate},
        { DynaLinkHS.RobotType.M4,MoveType.Rotate},
        { DynaLinkHS.RobotType.M6,MoveType.Rotate},
        { DynaLinkHS.RobotType.X1,MoveType.Rotate},
        { DynaLinkHS.RobotType.X2,MoveType.Rotate}
    };

    /// <summary>数值单位的字符串字典/// </summary>
    public static Dictionary<InputFieldPara, Dictionary<MoveType, string>> unitStrDic = new Dictionary<InputFieldPara, Dictionary<MoveType, string>>()
    {
        {InputFieldPara.Position,new Dictionary<MoveType,string>(){ { MoveType.Line, "m" },{ MoveType.Rotate, "deg" } } },
        {InputFieldPara.Velocity,new Dictionary<MoveType,string>(){ { MoveType.Line, "m/s" },{ MoveType.Rotate, "deg/s" } } },
        {InputFieldPara.Acceleration,new Dictionary<MoveType,string>(){ { MoveType.Line, "m/s2" },{ MoveType.Rotate, "deg/s2" } } },
        {InputFieldPara.AxiLength,new Dictionary<MoveType,string>(){ { MoveType.Line, "m" },{ MoveType.Rotate, "deg" } } },
        {InputFieldPara.Torque,new Dictionary<MoveType,string>(){ { MoveType.Line, "N" }, { MoveType.Rotate, "Nm" } } },
        {InputFieldPara.Quality,new Dictionary<MoveType,string>(){ { MoveType.Line, "kg" }, { MoveType.Rotate, "kg" } } },
        {InputFieldPara.Damping,new Dictionary<MoveType,string>(){ { MoveType.Line, "N/(m/s)" }, { MoveType.Rotate, "N/(m/s)" } } },
        {InputFieldPara.Spring,new Dictionary<MoveType,string>(){ { MoveType.Line, "N/m" }, { MoveType.Rotate, "N/m" } } },
        {InputFieldPara.Time,new Dictionary<MoveType,string>(){ { MoveType.Line, "s" }, { MoveType.Rotate, "s" } } },
        {InputFieldPara.A_position,new Dictionary<MoveType,string>(){ { MoveType.Line, "m" }, { MoveType.Rotate, "deg" } } },
        {InputFieldPara.B_position,new Dictionary<MoveType,string>(){ { MoveType.Line, "m" }, { MoveType.Rotate, "deg" } } },
        {InputFieldPara.Ratio,new Dictionary<MoveType,string>(){ { MoveType.Line, " " }, { MoveType.Rotate, " " } } },
        {InputFieldPara.MaxTorque,new Dictionary<MoveType,string>(){ { MoveType.Line, "N" }, { MoveType.Rotate, "Nm" } } }

    };

    /// <summary> 每种机器类型的运动标尺 /// </summary>
    public static Dictionary<DynaLinkHS.RobotType, float> robotRuler = new Dictionary<DynaLinkHS.RobotType, float>()
    {
        { DynaLinkHS.RobotType.H1, 0.1f},
        { DynaLinkHS.RobotType.H4, 0.1f},
        { DynaLinkHS.RobotType.M1, 1f},
        { DynaLinkHS.RobotType.M1_L,0.1f},
        { DynaLinkHS.RobotType.M2,0.1f},
        { DynaLinkHS.RobotType.M3,1f},
        { DynaLinkHS.RobotType.M4,1f},
        { DynaLinkHS.RobotType.M6,1f},
        { DynaLinkHS.RobotType.X1,1f},
        { DynaLinkHS.RobotType.X2,1f}
    };

    /// <summary> 根据机器的维度来判别机器需要激活的末端类型  /// </summary>
    public static Dictionary<int, List<InputFieldMachine>> machineInputDic = new Dictionary<int, List<InputFieldMachine>>()
    {
        {1,new List<InputFieldMachine>(){ InputFieldMachine.EE_X } },
        {2,new List<InputFieldMachine>(){ InputFieldMachine.EE_X, InputFieldMachine.EE_Y } },
        {3,new List<InputFieldMachine>(){ InputFieldMachine.EE_X, InputFieldMachine.EE_Y, InputFieldMachine.EE_Z } },
        {4,new List<InputFieldMachine>(){ InputFieldMachine.EE_X, InputFieldMachine.EE_Y, InputFieldMachine.EE_RX, InputFieldMachine.EE_RY} },
        {6,new List<InputFieldMachine>(){ InputFieldMachine.EE_X, InputFieldMachine.EE_Y, InputFieldMachine.EE_Z,InputFieldMachine.EE_RX, InputFieldMachine.EE_RY, InputFieldMachine.EE_RZ} },
    };


    /// <summary> 每种机器人不能使用的方法 /// </summary>
    public static Dictionary<DynaLinkHS.RobotType, List<string>> robotCanNotUse = new Dictionary<DynaLinkHS.RobotType, List<string>>()
    {
        { DynaLinkHS.RobotType.H1, new List<string>
          {
            BasicFunctionNames.endEffectorPosition,
            BasicFunctionNames.endEffectorVelocity,
            BasicFunctionNames.endEffectorTorque,
            BasicFunctionNames.jointPosition,
            BasicFunctionNames.jointTorque,
            BasicFunctionNames.jointVelocity,
            AdvanceFunctionNames.passiveDriver,
            AdvanceFunctionNames.passiveTransparent,
            AdvanceFunctionNames.activeTransparent,
            AdvanceFunctionNames.assistTransparent,
            AdvanceFunctionNames.passiveInfinity,
            AdvanceFunctionNames.passiveCircleCurve,
            AdvanceFunctionNames.activeKinetic,
            AdvanceFunctionNames.activeTunnelGuidance,
            AdvanceFunctionNames.activeAssistKineticNoSensor,
            AdvanceFunctionNames.activeMassSimulation,
            AdvanceFunctionNames.activeMassSimulationNoSensor,
            AdvanceFunctionNames.resistKinecticResistNoSensor,
            AdvanceFunctionNames.assistKineticTarget,
            AdvanceFunctionNames.passiveExoMotusPassive,
            AdvanceFunctionNames.assistTransparent_1,
            AdvanceFunctionNames.assistKineticTarget1,
          } },
        { DynaLinkHS.RobotType.H4, new List<string>
          {
            BasicFunctionNames.endEffectorPosition,
            BasicFunctionNames.endEffectorVelocity,
            BasicFunctionNames.endEffectorTorque,
            AdvanceFunctionNames.passiveTCurve,
            AdvanceFunctionNames.passiveSCurve,
            AdvanceFunctionNames.passiveTransparent,
            AdvanceFunctionNames.activeTransparent,
            AdvanceFunctionNames.assistTransparent,
            AdvanceFunctionNames.passiveInfinity,
            AdvanceFunctionNames.passiveCircleCurve,
            AdvanceFunctionNames.activeTunnelGuidance,
            AdvanceFunctionNames.activeAssistKineticNoSensor,
            AdvanceFunctionNames.activeMassSimulation,
            AdvanceFunctionNames.activeMassSimulationNoSensor,
            AdvanceFunctionNames.resistKinecticResistNoSensor,
            AdvanceFunctionNames.assistKineticTarget,
            AdvanceFunctionNames.assistTransparent_1,
            AdvanceFunctionNames.assistKineticTarget1,
          } },
        { DynaLinkHS.RobotType.M1, new List<string>
          {
            BasicFunctionNames.endEffectorPosition,
            BasicFunctionNames.endEffectorVelocity,
            BasicFunctionNames.endEffectorTorque,
            AdvanceFunctionNames.passiveInfinity,
            AdvanceFunctionNames.passiveTCurve,
            AdvanceFunctionNames.passiveSCurve,
            AdvanceFunctionNames.passiveCircleCurve,
            AdvanceFunctionNames.activeTunnelGuidance,
            AdvanceFunctionNames.passiveExoMotusPassive,
            AdvanceFunctionNames.assistTransparent_1,
            AdvanceFunctionNames.assistKineticTarget1,
          } },
        { DynaLinkHS.RobotType.M1_L,new List<string>
          {
            BasicFunctionNames.endEffectorPosition,
            BasicFunctionNames.endEffectorVelocity,
            BasicFunctionNames.endEffectorTorque,
            AdvanceFunctionNames.passiveInfinity,
            AdvanceFunctionNames.passiveTCurve,
            AdvanceFunctionNames.passiveSCurve,
            AdvanceFunctionNames.passiveCircleCurve,
            AdvanceFunctionNames.activeTunnelGuidance,
            AdvanceFunctionNames.passiveExoMotusPassive,
            AdvanceFunctionNames.assistTransparent_1,
            AdvanceFunctionNames.assistKineticTarget1,
          } },
        { DynaLinkHS.RobotType.M2,new List<string>
          {
            AdvanceFunctionNames.passiveTCurve,
            AdvanceFunctionNames.passiveSCurve,
            AdvanceFunctionNames.passiveExoMotusPassive,
          }
        },
        { DynaLinkHS.RobotType.M3,new List<string>
          {
            BasicFunctionNames.endEffectorPosition,
            BasicFunctionNames.endEffectorVelocity,
            BasicFunctionNames.endEffectorTorque,
            BasicFunctionNames.jointPosition,
            BasicFunctionNames.jointTorque,
            BasicFunctionNames.jointVelocity,
            AdvanceFunctionNames.passiveTransparent,
            AdvanceFunctionNames.activeTransparent,
            AdvanceFunctionNames.assistTransparent,
            AdvanceFunctionNames.passiveInfinity,
            AdvanceFunctionNames.passiveCircleCurve,
            AdvanceFunctionNames.activeKinetic,
            AdvanceFunctionNames.activeTunnelGuidance,
            AdvanceFunctionNames.activeAssistKineticNoSensor,
            AdvanceFunctionNames.activeMassSimulation,
            AdvanceFunctionNames.activeMassSimulationNoSensor,
            AdvanceFunctionNames.resistKinecticResistNoSensor,
            AdvanceFunctionNames.assistKineticTarget,
            AdvanceFunctionNames.passiveExoMotusPassive,
            AdvanceFunctionNames.assistTransparent_1,
            AdvanceFunctionNames.assistKineticTarget1,
          } },
        { DynaLinkHS.RobotType.M4,new List<string>
          {
            BasicFunctionNames.endEffectorPosition,
            BasicFunctionNames.endEffectorVelocity,
            BasicFunctionNames.endEffectorTorque,
            AdvanceFunctionNames.passiveDriver,
            AdvanceFunctionNames.passiveTransparent,
            AdvanceFunctionNames.activeTransparent,
            AdvanceFunctionNames.assistTransparent,
            AdvanceFunctionNames.passiveInfinity,
            AdvanceFunctionNames.passiveCircleCurve,
            AdvanceFunctionNames.activeKinetic,
            AdvanceFunctionNames.activeTunnelGuidance,
            AdvanceFunctionNames.activeAssistKineticNoSensor,
            AdvanceFunctionNames.activeMassSimulation,
            AdvanceFunctionNames.activeMassSimulationNoSensor,
            AdvanceFunctionNames.resistKinecticResistNoSensor,
            AdvanceFunctionNames.assistKineticTarget,
            AdvanceFunctionNames.passiveExoMotusPassive,
            AdvanceFunctionNames.assistTransparent_1,
            AdvanceFunctionNames.assistKineticTarget1,
          } },
        { DynaLinkHS.RobotType.M6,new List<string>
          {
            BasicFunctionNames.endEffectorPosition,
            BasicFunctionNames.endEffectorVelocity,
            BasicFunctionNames.endEffectorTorque,
            AdvanceFunctionNames.passiveDriver,
            AdvanceFunctionNames.passiveTCurve,
            AdvanceFunctionNames.passiveSCurve,
            AdvanceFunctionNames.passiveMJCurve,
            AdvanceFunctionNames.passiveTransparent,
            AdvanceFunctionNames.passiveInfinity,
            AdvanceFunctionNames.passiveCircleCurve,
            AdvanceFunctionNames.assistTransparent,
            AdvanceFunctionNames.activeTransparent,
            AdvanceFunctionNames.activeKinetic,
            AdvanceFunctionNames.resistKinetic,
            AdvanceFunctionNames.passiveInfinity,
            AdvanceFunctionNames.passiveCircleCurve,
            AdvanceFunctionNames.activeTunnelGuidance,
            AdvanceFunctionNames.activeAssistKineticNoSensor,
            AdvanceFunctionNames.activeMassSimulation,
            AdvanceFunctionNames.activeMassSimulationNoSensor,
            AdvanceFunctionNames.resistKinecticResistNoSensor,
            AdvanceFunctionNames.assistKineticTarget,
            AdvanceFunctionNames.assistTransparent_1,
            AdvanceFunctionNames.assistKineticTarget1,
          } },
        { DynaLinkHS.RobotType.X1,new List<string>
          {
            BasicFunctionNames.endEffectorPosition,
            BasicFunctionNames.endEffectorVelocity,
            BasicFunctionNames.endEffectorTorque,
            BasicFunctionNames.endEffectorPosition,
            BasicFunctionNames.endEffectorVelocity,
            BasicFunctionNames.endEffectorTorque,
            BasicFunctionNames.jointPosition,
            BasicFunctionNames.jointTorque,
            BasicFunctionNames.jointVelocity,
            AdvanceFunctionNames.passiveDriver,
            AdvanceFunctionNames.passiveTransparent,
            AdvanceFunctionNames.activeTransparent,
            AdvanceFunctionNames.assistTransparent,
            AdvanceFunctionNames.passiveInfinity,
            AdvanceFunctionNames.passiveCircleCurve,
            AdvanceFunctionNames.activeKinetic,
            AdvanceFunctionNames.activeTunnelGuidance,
            AdvanceFunctionNames.activeAssistKineticNoSensor,
            AdvanceFunctionNames.activeMassSimulation,
            AdvanceFunctionNames.activeMassSimulationNoSensor,
            AdvanceFunctionNames.resistKinecticResistNoSensor,
            AdvanceFunctionNames.assistKineticTarget,
            AdvanceFunctionNames.passiveExoMotusPassive,
            AdvanceFunctionNames.assistTransparent_1,
            AdvanceFunctionNames.assistKineticTarget1,
          } },
        { DynaLinkHS.RobotType.X2,new List<string>
          {
            BasicFunctionNames.endEffectorPosition,
            BasicFunctionNames.endEffectorVelocity,
            BasicFunctionNames.endEffectorTorque,
            AdvanceFunctionNames.passiveInfinity,
            AdvanceFunctionNames.passiveCircleCurve,
            AdvanceFunctionNames.activeTunnelGuidance,
            AdvanceFunctionNames.activeAssistKineticNoSensor,
            AdvanceFunctionNames.activeMassSimulation,
            AdvanceFunctionNames.activeMassSimulationNoSensor,
            AdvanceFunctionNames.resistKinecticResistNoSensor,
            AdvanceFunctionNames.assistKineticTarget,
            AdvanceFunctionNames.assistTransparent_1,
            AdvanceFunctionNames.assistKineticTarget1,
          } }
    };

    /// <summary> 方法对应的描述  /// </summary>
    public static Dictionary<string, string> functionIntroductionDic = new Dictionary<string, string>()
    {
         {BasicFunctionNames.jog,
            "<color>---------</color><b>控制机器人关节电机以较小的运动速度朝指定的方向进行移动</b>。鼠标单击“+”，可以使机器人关节朝指定正方向运动。鼠标单击“-”，可使机器人关节朝指定负方向运动。松开鼠标按键，则会使关节运动停止。\n<color>---------</color><b>The motor of the joint of the robot is controlled to move in a specified direction at a low speed</b>. When the mouse click \"+\", the joint motor will generate slow movement in the positive direction. When the mouse click \"-\", the joint motor will generate slow move in the negative direction. Loosening the mouse button will stop the joint movement." },
         {BasicFunctionNames.jointTorque,"<color>---------</color><b>机器人关节力/力矩控制</b>。根据机器人关节种类的不同，关节的动力输出可以表现为力/力矩。直线关节的输出为力，单位为N。旋转关节的输出为力矩，单位为Nm。通过输入希望关节输出的力/力矩值，点击“Start”，可以使机器人在关节上输出对应的力/力矩。\n<b>Robot joint force/moment control</b>. According to the different types of robot joints, the dynamic output of joints can be expressed as force/moment. The output of the linear joint is force, in N. The output of the rotating joint is torque, in Nm. By inputting the desired joint output force/torque value and clicking \"Start\", the robot can output the corresponding force/torque on the joint." },
        {BasicFunctionNames.jointVelocity,"<color>---------</color><b>机器人关节/速度控制</b>。根据机器人关节种类的不同，关节的速度输出可以表现为直线运动或旋转运动。直线关节的输出为直线运动，单位为m/s，旋转关节的输出为旋转运动，单位为deg/s。通过输入希望关节输出的速度值、加速度值，点击“Start”，可以使机器人在关节上按照指定的加速度输出对应的速度。\n<b>Robot joint/ speed control.</b>.ii.According to the different types of robot joints, the joint velocity output can be expressed as linear or rotational motion. The output of the linear joint is linear motion, in m/s, and the output of the rotary joint is rotary motion, in deg/s. By inputting the velocity and acceleration value of the desired joint output and clicking on \"Start\", the robot can output the corresponding speed according to the specified acceleration and velocity on the joint." },
        {BasicFunctionNames.jointPosition,"<color>---------</color><b>机器人关节位置控制</b>。根据机器人关节种类的不同，关节的位置输出可以表现为直线运动或旋转运动。直线关节的输出为直线运动，单位为m，旋转关节的输出为旋转运动，单位为deg。通过输入希望关节输出的位置、速度值、加速度值，点击“Start”，可以使机器人在关节上按照指定的加速度、速度运动到指定的位置。\n<color>---------</color><b>Robot joint position control</b>. According to the different types of robot joints, the output of joint position can be expressed as linear or rotational motion. The output of the linear joint is linear motion in m, and the output of the rotary joint is rotary motion in deg. By inputting the position, velocity and acceleration of the desired joint output and clicking \"Start\", the robot can move to the specified position according to the specified acceleration, velocity and position on the joint." },
        {BasicFunctionNames.endEffectorTorque,"<color>---------</color><b>机器人末端力/力矩控制</b>。根据机器人末端种类的不同，末端的动力输出可以表现为力/力矩。直线末端的输出为力，单位为N。旋转末端的输出为力矩，单位为Nm。通过输入希望末端输出的力/力矩值，点击“Start”，可以使机器人在末端上输出对应的力/力矩。\n<b>Robot end effector force/moment control</b>. According to the different types of robot end effector, the dynamic output of end effector can be expressed as force/moment. The output of the linear end effector is force, in N. The output of the rotating end effector is torque, in Nm. By inputting the desired end effector output force/torque value and clicking \"Start\", the robot can output the corresponding force/torque on the joint." },
        {BasicFunctionNames.endEffectorVelocity,"<color>---------</color><b>机器人末端/速度控制</b>。根据机器人末端种类的不同，关节的速度输出可以表现为直线运动或旋转运动。直线末端的输出为直线运动，单位为m/s，旋转末端的输出为旋转运动，单位为deg/s。通过输入希望末端输出的速度值、加速度值，点击“Start”，可以使机器人在末端上按照指定的加速度输出对应的速度。\n<b>Robot joint/ speed control.</b>.ii.According to the different types of robot end effector, the end effector velocity output can be expressed as linear or rotational motion. The output of the linear end effector is linear motion, in m/s, and the output of the rotary end effector is rotary motion, in deg/s. By inputting the velocity and acceleration value of the desired end effector output and clicking on \"Start\", the robot can output the corresponding speed according to the specified acceleration and velocity on the end effector." },
        {BasicFunctionNames.endEffectorPosition,"<color>---------</color><b>机器人末端位置控制</b>。根据机器人末端种类的不同，末端的位置输出可以表现为直线运动或旋转运动。直线关节的输出为直线运动，单位为m，旋转末端的输出为旋转运动，单位为deg。通过输入希望末端输出的位置、速度值、加速度值，点击“Start”，可以使机器人在末端上按照指定的加速度、速度运动到指定的位置。\n<color>---------</color><b>Robot joint position control</b>. According to the different types of robot end effector, the output of end effector position can be expressed as linear or rotational motion. The output of the linear end effector is linear motion in m, and the output of the rotary end effector is rotary motion in deg. By inputting the position, velocity and acceleration of the desired end effector output and clicking \"Start\", the robot can move to the specified position according to the specified acceleration, velocity and position on the end effector." },
        {AdvanceFunctionNames.passiveDriver,"<color>---------</color><b>机器人被动-基于驱动器的末端位置控制</b>。机器人的末端会根据基于关节空间的运动进行运动，确保达到最终指定的位置，但是中间不一定是以直线形式移动过去。根据机器人末端自由度种类和数量的不同，可以输入的参数的数量和单位也会不同。对于线性自由度，可以输入位置（单位为m），速度（单位为m/s），加速度（单位为m/s2）。对于旋转自由度，可以输入位置（单位为deg），速度（单位为deg/s），加速度（单位为deg/s2）。点击“Start”，可以使机器人在末端上按照指定的加速度、速度运动到指定的位置。\n<color>---------</color><b>Robot passive-driver-based terminal position control</b>. The end-effector of the robot will move according to the motion based on joint space to ensure that it reaches the final designated position, but the movement does not necessarily in a straight line. Depending on the type and number of degrees of freedom at the end of the robot, the number and unit of parameters that can be input will also be different. For linear degrees of freedom, position (in m), velocity (in m/s) and acceleration (in m/s2) can be input. For rotational degrees of freedom, position (deg in units), velocity (deg/s in units) and acceleration (deg/s2 in units) can be input. Click \"Start\" to make the robot move to the designated position at the end according to the specified acceleration and speed." },
        {AdvanceFunctionNames.passiveTCurve,"<color>---------</color><b>机器人被动-T曲线的末端位置控制</b>。机器人末端以直线形式运动到目标点，在直线轨迹上，速度-时间曲线为梯形。根据机器人末端自由度种类和数量的不同，可以输入的参数的数量和单位也会不同。对于线性自由度，可以输入位置（m），速度（m/s），加速度（m/s2）。对于旋转自由度，可以输入位置（deg），速度（deg/s），加速度（deg/s2）。点击“Start”，可以使机器人在末端上按照指定的加速度、速度运动到指定的位置。\n<color>---------</color><b>Robot end-effector passive-T curve position control</b>. The end-effector of the robot moves to the target point in a straight line. On the straight-line trajectory, the velocity-time curve is trapezoidal. Depending on the type and number of degrees of freedom at the end-effector of the robot, the number and unit of parameters that can be input will also be different. For linear degrees of freedom, position (m), velocity (m/s) and acceleration (m/s2) can be input. For rotational degrees of freedom, position (deg), velocity (deg/s) and acceleration (deg/s2) can be input. Click \"Start\" to make the robot move to the designated position at the end according to the specified acceleration and speed." },
        {AdvanceFunctionNames.passiveSCurve,"<color>---------</color><b>机器人被动-S曲线的末端位置控制</b>。机器人末端以直线形式运动到目标点，在直线轨迹上，速度-时间曲线为S形。根据机器人末端自由度种类和数量的不同，可以输入的参数的数量和单位也会不同。对于线性自由度，可以输入位置（m），速度（m/s），加速度（m/s2）。对于旋转自由度，可以输入位置（deg），速度（deg/s），加速度（deg/s2）。点击“Start”，可以使机器人在末端上按照指定的加速度、速度运动到指定的位置。\n<color>---------</color><b>Robot end-effector passive-S curve position control</b>. The end-effector of the robot moves to the target point in a straight line. On the straight-line trajectory, the velocity-time curve is S-shape. Depending on the type and number of degrees of freedom at the end-effector of the robot, the number and unit of parameters that can be input will also be different. For linear degrees of freedom, position (m), velocity (m/s) and acceleration (m/s2) can be input. For rotational degrees of freedom, position (deg), velocity (deg/s) and acceleration (deg/s2) can be input. Click \"Start\" to make the robot move to the designated position at the end according to the specified acceleration and speed." },
        {AdvanceFunctionNames.passiveMJCurve,"<color>---------</color><b>机器人被动-MJ曲线的末端位置控制</b>。机器人末端以直线形式运动到目标点，在直线轨迹上，速度-时间曲线为Minimum-Jerk。根据机器人末端自由度种类和数量的不同，可以输入的参数的数量和单位也会不同。对于线性自由度，可以输入位置（m），速度（m/s），加速度（m/s2）。对于旋转自由度，可以输入位置（deg），速度（deg/s），加速度（deg/s2）。点击“Start”，可以使机器人在末端上按照指定的加速度、速度运动到指定的位置。\n<color>---------</color><b>Robot end-effector passive-MJ curve position control</b>. The end-effector of the robot moves to the target point in a straight line. On the straight-line trajectory, the velocity-time curve has Minimum Jerk. Depending on the type and number of degrees of freedom at the end-effector of the robot, the number and unit of parameters that can be input will also be different. For linear degrees of freedom, position (m), velocity (m/s) and acceleration (m/s2) can be input. For rotational degrees of freedom, position (deg), velocity (deg/s) and acceleration (deg/s2) can be input. Click \"Start\" to make the robot move to the designated position at the end according to the specified acceleration and speed." },
        {AdvanceFunctionNames.passiveTransparent,"<color>---------</color><b>机器人被动-透明控制</b>。透明控制本质为通过算法实现机器人对物理系统性能的仿真。在此处，“透明控制”指的是“导纳控制”，在其他机器人中，“透明控制”也可能是指“阻抗控制”。在导纳控制系统中，模拟的是 质量-阻尼-弹簧 系统。共有3个参数供我们设置，分别为质量，阻尼系数，弹簧刚度系数。\n<color>---------</color><b>Robot Passive - transparent control</b>. The essence of transparent control is to simulate the performance of physical system by algorithm. Here, \"transparent control\" refers to \"admittance control\", and in other robots, \"transparent control\" may also refer to \"impedance control\". In admittance control system, mass-damp-spring system is simulated. There are three parameters for us to set: mass, damping coefficient and spring stiffness coefficient." },
        {AdvanceFunctionNames.passiveInfinity,"<color>---------</color><b>机器人被动-无穷曲线控制</b>。透明控制本质为通过算法实现机器人呈现无穷曲线运动轨迹。可调节参数为无穷曲线的中心原点位置和无穷曲线的轴长。\n<color>---------</color><b>Robot passive-infinite curve control</b>. The essence of transparent control is to realize the robot's infinite curve trajectory through algorithm. The adjustable parameters are the central origin position of the infinite curve and the axis length of the infinite curve." },
        {AdvanceFunctionNames.passiveCircleCurve,"<color>---------</color><b>机器人被动-圆形曲线控制</b>。被动圆形曲线控制本质为通过算法实现机器人呈现无穷曲线运动轨迹。可调节参数为无穷曲线的中心原点位置和无穷曲线的轴长。\n<color>---------</color><b>Robot passive-circular curve control</b>. The essence of passive circular curve control is that the robot presents an infinite curve trajectory through algorithm. The adjustable parameters are the central origin position of the infinite curve and the axis length of the infinite curve." },
        {AdvanceFunctionNames.passiveExoMotusPassive,"<color>---------</color><b>外骨骼机器人 H4 控制。</b>通过设置机器人的大腿长度、小腿长度、步长、步高和相对应的时间参数来配置机器人的步态，从而适配不同的使用人群。\n<color>---------</color><b>ExoMotus H4 Control.</b>The robot's gait is configured by setting the robot's thigh length, calf length, step length, step height, and corresponding time parameters to adapt to different user groups." },
        {AdvanceFunctionNames.assistTransparent,"<color>---------</color><b>机器人助力-透明控制</b>。透明控制本质为通过算法实现机器人对物理系统性能的仿真。在此处，“透明控制”指的是“导纳控制”，在其他机器人中，“透明控制”也可能是指“阻抗控制”。在导纳控制系统中，模拟的是 质量-阻尼-弹簧 系统。共有3个参数供我们设置，分别为质量，阻尼系数，弹簧刚度系数。\n<color>---------</color><b>Robot Assist - transparent control</b>. The essence of transparent control is to simulate the performance of physical system by algorithm. Here, \"transparent control\" refers to \"admittance control\", and in other robots, \"transparent control\" may also refer to \"impedance control\". In admittance control system, mass-damp-spring system is simulated. There are three parameters for us to set: mass, damping coefficient and spring stiffness coefficient." },
         {AdvanceFunctionNames.assistTransparent_1,"<color>---------</color><b>机器人助力-透明控制</b>。该方法为透明控制的改良版，主要体现在，助力的k值会按照设定的变化量，逐渐变化，从而拥有更好的阻力手感。\n<color>---------</color><b>Robot Assist - transparent control</b>. This method is an improved version of transparent control, which is mainly reflected in the fact that the k value of the assistance will gradually change according to the set amount of change, so that it has a better resistance feel" },
        { AdvanceFunctionNames.assistKineticTarget,"<color>---------</color><b>机器人助力-有目标点的力控制</b>。有目标点的力控制为通过迭代不断累积增加， 直到达到让机器运动，并抵达目标点位置为止。\n<color>---------</color><b>Robot Assist - Kinetic Control with Target Points</b>. Force control with target points is to accumulate and increase through iteration until the machine moves and reaches the target point."},
        {AdvanceFunctionNames.activeTransparent,"<color>---------</color><b>机器人主动-透明控制</b>。透明控制本质为通过算法实现机器人对物理系统性能的仿真。在此处，“透明控制”指的是“导纳控制”，在其他机器人中，“透明控制”也可能是指“阻抗控制”。在导纳控制系统中，模拟的是 质量-阻尼-弹簧 系统。共有3个参数供我们设置，分别为质量，阻尼系数，弹簧刚度系数。\n<color>---------</color><b>Robot Active - transparent control</b>. The essence of transparent control is to simulate the performance of physical system by algorithm. Here, \"transparent control\" refers to \"admittance control\", and in other robots, \"transparent control\" may also refer to \"impedance control\". In admittance control system, mass-damp-spring system is simulated. There are three parameters for us to set: mass, damping coefficient and spring stiffness coefficient." },
        {AdvanceFunctionNames.activeTunnelGuidance,"<color>---------</color><b>机器人主动-轨道引导控制</b>。轨道引导控制为通过算法实现机器人末端沿指定轨迹进行运动的控制算法。在轨道上的时候，人能够很轻易地推动机器人运动，但是当机器人末端偏离指定的轨道，则会受到较大的阻力，防止机器人末端偏离预定的轨迹。在轨道上和轨道两侧通过模拟 质量-阻尼-弹簧 系统，来实现控制效果。每个自由度上有3个参数供我们设置，分别为质量，阻尼系数，弹簧刚度系数。\n<color>---------</color><b>Robot active-orbit guidance control</b>. The trajectory guidance control is a control algorithm which realizes the movement of the robot's end-effector along the specified trajectory using the algorithm. In orbit, human can easily push the robot to move, but when the end of the robot deviates from the specified orbit, it will be subject to greater resistance to prevent the end of the robot from deviating from the predetermined trajectory. The mass-damp-spring system is simulated on the track and on both sides of the track to achieve the control effect. Each degree of freedom has three parameters for us to set, namely mass, damping coefficient and spring stiffness coefficient." },
        {AdvanceFunctionNames.activeKinetic,"<color>---------</color><b>机器人主动-力辅助控制</b>。主动-力辅助控制通过传感器和算法实现机器人在检测到人体的运动意图后，给予相应的运动以辅助力，减少摩擦阻力，提高机器的透明度，从而实现病人能够轻易的主动运动的效果。\n<color>---------</color><b>Robot Active - Kinetic assisted control without sensor</b>. Kinetic assisted control with sensor realizes that the robot, after detecting the motion intention of the human body, gives the corresponding motion to assist the force, reduces friction resistance, and improves the transparency of the machine, thus realizing the effect that the patient can easily move actively." },
        {AdvanceFunctionNames.activeAssistKineticNoSensor,"<color>---------</color><b>机器人主动-无传感器力辅助控制</b>。主动-无传感器力辅助控制通过算法实现机器人在检测到人体的运动意图后，给予相应的运动以辅助力，减少摩擦阻力，提高机器的透明度，从而实现病人能够轻易的主动运动的效果。\n<color>---------</color><b>Robot Active - Kinetic assisted control without sensor</b>. Kinetic assisted control without sensor realizes that the robot, after detecting the motion intention of the human body, gives the corresponding motion to assist the force, reduces friction resistance, and improves the transparency of the machine, thus realizing the effect that the patient can easily move actively." },
         {AdvanceFunctionNames.activeMassSimulation,"<color>---------</color><b>机器人主动-质量模拟控制</b>。机器人主动-质量模拟控制通过算法和传感器来 模拟质量块的运动过程，实现推动真实物块的感觉。\n<color>---------</color><b>Active - Quality Simulation Control for Robots</b>. The active-mass simulation control of the robot simulates the motion process of the mass block through algorithms and sensors to achieve the feeling of pushing the real block." },
         {AdvanceFunctionNames.activeMassSimulationNoSensor,"<color>---------</color><b>机器人主动-无传感器质量模拟控制</b>。机器人主动-无传感器质量模拟控制通过算法来模拟质量块的运动过程，实现推动真实物块的感觉。\n<color>---------</color><b>Active-Sensorless Mass Simulation Control for Robots</b>.The robot's active-sensorless mass simulation control simulates the motion process of the mass block through algorithms to achieve the feeling of pushing the real block." },
        {AdvanceFunctionNames.resistKinetic,"<color>---------</color><b>机器人主动-力阻碍控制</b>。主动-力阻碍控制通过传感器和算法实现机器人在检测到人体的运动意图后，给予相应的运动以阻碍力，降低机器的透明度，从而达到病人必须用力才能使机器运动的效果。\n<color>---------</color><b>Robot active-Kinetic resist control</b>. Active-Force Barrier Control (APFC) realizes that the robot, after detecting the motion intention of the human body, gives the corresponding motion to obstruct the force and reduces the transparency of the machine, so as to achieve the effect that the patient must exert himself to make the machine move." },
        {AdvanceFunctionNames.resistKinecticResistNoSensor,"<color>---------</color><b>机器人主动-无传感器力阻碍控制</b>。主动-无传感器力阻碍控制通过算法实现机器人在检测到人体的运动意图后，给予相应的运动以阻碍力，降低机器的透明度，从而使病人不能够轻易的主动运动的效果。\n<color>---------</color><b>Robot Active - Kinetic resist control without sensor</b>. Kinetic resist control without sensor realizes that the robot, after detecting the motion intention of the human body, gives the corresponding motion to resist the force, reduces friction resistance, and improves the transparency of the machine, thus realizing the effect that the patient can easily move actively." },
    };
}

/// <summary>
/// 曲线名称
/// </summary>
public class CurveNames
{
    public static string none = "None";

    public static string positionDataJoint1 = "PositionDataJoint1";

    public static string positionDataJoint2 = "PositionDataJoint2";

    public static string positionDataJoint3 = "PositionDataJoint3";

    public static string positionDataJoint4 = "PositionDataJoint4";

    public static string positionDataJoint5 = "PositionDataJoint5";

    public static string positionDataJoint6 = "PositionDataJoint6";


    public static string velocityDataJoint1 = "VelocityDataJoint1";

    public static string velocityDataJoint2 = "VelocityDataJoint2";

    public static string velocityDataJoint3 = "VelocityDataJoint3";

    public static string velocityDataJoint4 = "VelocityDataJoint4";

    public static string velocityDataJoint5 = "VelocityDataJoint5";

    public static string velocityDataJoint6 = "VelocityDataJoint6";


    public static string kineticDataJoint1 = "KineticDataJoint1";

    public static string kineticDataJoint2 = "KineticDataJoint2";

    public static string kineticDataJoint3 = "KineticDataJoint3";

    public static string kineticDataJoint4 = "KineticDataJoint4";

    public static string kineticDataJoint5 = "KineticDataJoint5";

    public static string kineticDataJoint6 = "KineticDataJoint6";


    public static string positionDataEndEffectorX1 = "PositionDataEndEffectorX1";

    public static string positionDataEndEffectorY1 = "PositionDataEndEffectorY1";

    public static string positionDataEndEffectorZ1 = "PositionDataEndEffectorZ1";

    public static string positionDataEndEffectorAlpha1 = "PositionDataEndEffectorAlpha1";

    public static string positionDataEndEffectorBeta1 = "PositionDataEndEffectorBeta1";

    public static string positionDataEndEffectorGamma1 = "PositionDataEndEffectorGamma1";


    public static string velocityDataEndEffectorX1 = "VelocityDataEndEffectorX1";

    public static string velocityDataEndEffectorY1 = "VelocityDataEndEffectorY1";

    public static string velocityDataEndEffectorZ1 = "VelocityDataEndEffectorZ1";

    public static string velocityDataEndEffectorAlpha1 = "VelocityDataEndEffectorAlpha1";

    public static string velocityDataEndEffectorBeta1 = "VelocityDataEndEffectorBeta1";

    public static string velocityDataEndEffectorGamma1 = "VelocityDataEndEffectorGamma1";


    public static string kineticDataEndEffectorX1 = "KineticDataEndEffectorX1";

    public static string kineticDataEndEffectorY1 = "KineticDataEndEffectorY1";

    public static string kineticDataEndEffectorZ1 = "KineticDataEndEffectorZ1";

    public static string kineticDataEndEffectorAlpha1 = "KineticDataEndEffectorAlpha1";

    public static string kineticDataEndEffectorBeta1 = "KineticDataEndEffectorBeta1";

    public static string kineticDataEndEffectorGamma1 = "KineticDataEndEffectorGamma1";


    public static string positionDataEndEffectorX2 = "PositionDataEndEffectorX2";

    public static string positionDataEndEffectorY2 = "PositionDataEndEffectorY2";

    public static string positionDataEndEffectorZ2 = "PositionDataEndEffectorZ2";

    public static string positionDataEndEffectorAlpha2 = "PositionDataEndEffectorAlpha2";

    public static string positionDataEndEffectorBeta2 = "PositionDataEndEffectorBeta2";

    public static string positionDataEndEffectorGamma2 = "PositionDataEndEffectorGamma2";

    public static string velocityDataEndEffectorX2 = "VelocityDataEndEffectorX2";

    public static string velocityDataEndEffectorY2 = "VelocityDataEndEffectorY2";

    public static string velocityDataEndEffectorZ2 = "VelocityDataEndEffectorZ2";

    public static string velocityDataEndEffectorAlpha2 = "VelocityDataEndEffectorAlpha2";

    public static string velocityDataEndEffectorBeta2 = "VelocityDataEndEffectorBeta2";

    public static string velocityDataEndEffectorGamma2 = "VelocityDataEndEffectorGamma2";


    public static string kineticDataEndEffectorX2 = "KineticDataEndEffectorX2";

    public static string kineticDataEndEffectorY2 = "KineticDataEndEffectorY2";

    public static string kineticDataEndEffectorZ2 = "KineticDataEndEffectorZ2";

    public static string kineticDataEndEffectorAlpha2 = "KineticDataEndEffectorAlpha2";

    public static string kineticDataEndEffectorBeta2 = "KineticDataEndEffectorBeta2";

    public static string kineticDataEndEffectorGamma2 = "KineticDataEndEffectorGamma2";
}

/// <summary>
/// 基础方法名称
/// </summary>
public class BasicFunctionNames
{
    public static string endEffectorPosition = "End Effector Position Control";

    public static string endEffectorTorque = "End Effector Torque Force Control";

    public static string endEffectorVelocity = "End Effector Velocity Control";

    public static string jointTorque = "Joint Torque Force Control";

    public static string jointVelocity = "Joint Velocity Control";

    public static string jointPosition = "Joint Position Control";

    public static string jog = "Jog";
}

/// <summary>
/// 高级方法名称
/// </summary>
public class AdvanceFunctionNames
{
    public static string passiveDriver = "Passive – Driver Position Control";

    public static string passiveTCurve = "Passive - T-Curve Control";

    public static string passiveSCurve = "Passive - S-Curve Control";

    public static string passiveMJCurve = "Passive - MJ-Curve Control";

    public static string passiveTransparent = "Passive - Transparent Control";

    public static string passiveInfinity = "Passive – Infinity Curve Control";

    public static string passiveCircleCurve = "Passive – Circle Curve Control";

    public static string passiveExoMotusPassive = "Passive – ExoMotus Passive Control";

    public static string assistTransparent = "Assist - Transparent Control";

    public static string assistTransparent_1 = "Assist – Transparent Control-1";

    public static string assistKineticTarget = "Assist – Kinetic Control With Target Position";

    public static string assistKineticTarget1 = "Assist – Kinetic Control With Target Position-1";

    public static string activeTransparent = "Active - Transparent Control";

    public static string activeKinetic = "Active - Kinetic Assist Control";

    public static string activeTunnelGuidance = "Active – Tunnel Guidance Control";

    public static string activeAssistKineticNoSensor = "Active - Kinetic Assist Control Without Sensor";

    public static string activeMassSimulation = "Active - Mass Simulation Control";

    public static string activeMassSimulationNoSensor = "Active - Mass Simulation Control Without Sensor";

    public static string resistKinetic = "Resist - Kinetic Resist Control";

    public static string resistKinecticResistNoSensor = "Resist - Kinetic Resist Control Without Sensor";
}

/// <summary>
/// 配置设置方法名称
/// </summary>
public class SettinFunctionNames
{
    public static string network = "Network Configuration";

    public static string motor = "Motor Configuration";

    public static string robot = "Robot Configuration";

    public static string sensor = "Sensor Configuration";

    public static string update = "Update";

    public static string ambientLight = "Ambient Light";
}


/// <summary>
/// 输入框的参数类型
/// </summary>
public enum InputFieldPara
{
    Position,        //位置属性
    Velocity,        //速度属性
    Acceleration,    //加速度属性
    AxiLength,       //轴长 
    Time,            //时间属性
    Damping,        //摩檫力属性
    Spring,         //弹性属性
    Quality,         //质量属性
    Torque,           //力矩
    A_position,       //A位置点
    B_position,       //B位置点
    Ratio,            //比率
    MaxTorque         //最大力矩
}


/// <summary>
/// 输入框的参数类型
/// </summary>
public enum InputFieldMachine
{
    None,      //None  
    EE_X,      //End Effector x
    EE_Y,      //End Effector y
    EE_Z,      //End Effector x
    EE_RX,     //End Effector aphla
    EE_RY,     //End Effector beta
    EE_RZ,     //End Effector gamma
    joint,     //joint
}

/// <summary>
/// 运动类型
/// </summary>
public enum MoveType
{
    Line,           //直线运动
    Rotate,         //旋转运动
    None            //无运动属性
}
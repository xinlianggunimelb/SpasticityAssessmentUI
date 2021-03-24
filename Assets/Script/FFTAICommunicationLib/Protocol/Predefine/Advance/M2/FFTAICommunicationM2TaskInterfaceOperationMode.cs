﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationM2TaskInterfaceOperationMode 
    {
        // basic
        // basic : set work mode
        public const int BasicWorkMode = 0x01010101;

        public const int BasicFlagTaskInProcess = 0x01010201;
        public const int BasicFlagInformation = 0x01011001;

        // debug
        // debug : basic : set work mode
        public const int DebugSetWorkMode = 0x02010101;

        // relay
        // relay : basic : set work mode
        public const int RelaySetWorkMode = 0x03010101;

        // master Control
        // master Control : basic : set work mode
        public const int MasterControlSetWorkMode = 0x04010101;
        
        // subtask
        // subtask : basic
        // subtask : basic : joint kinetic control
        public const int SubtaskBasicSetJointKineticControlKinetic = 0x10000101;

        // subtask : basic : joint velocity control
        public const int SubtaskBasicSetJointVelocityControlAcceleration = 0x10000201;
        public const int SubtaskBasicSetJointVelocityControlVelocity = 0x10000202;

        // subtask : basic : joint position control
        public const int SubtaskBasicSetJointPositionControlAcceleration = 0x10000301;
        public const int SubtaskBasicSetJointPositionControlVelocity = 0x10000302;
        public const int SubtaskBasicSetJointPositionControlPosition = 0x10000303;

        // subtask : basic : end effector kinetic control
        public const int SubtaskBasicSetEndEffectorKineticControlKinetic = 0x10000401;

        // subtask : basic : end effector velocity control
        public const int SubtaskBasicSetEndEffectorVelocityControlAcceleration = 0x10000501;
        public const int SubtaskBasicSetEndEffectorVelocityControlVelocity = 0x10000502;

        // subtask : basic : end effector position control
        public const int SubtaskBasicSetEndEffectorPositionControlAcceleration = 0x10000601;
        public const int SubtaskBasicSetEndEffectorPositionControlVelocity = 0x10000602;
        public const int SubtaskBasicSetEndEffectorPositionControlPosition = 0x10000603;

        // subtask : basic : find home
        public const int SubtaskBasicSetFindHomeRequestKinetic = 0x10010101;
        public const int SubtaskBasicSetFindHomeAcceleration = 0x10010102;
        public const int SubtaskBasicSetFindHomeVelocity = 0x10010103;

        // subtask : basic : passive linear motion
        public const int SubtaskBasicSetPassiveLinearMotionAcceleration = 0x10010201;
        public const int SubtaskBasicSetPassiveLinearMotionVelocity = 0x10010202;
        public const int SubtaskBasicSetPassiveLinearMotionPosition = 0x10010203;

        // subtask : basic : mass simulation
        public const int SubtaskBasicSetMassSimulationMass = 0x10010301;
        public const int SubtaskBasicSetMassSimulationFrictionBcFactor = 0x10010302;
        public const int SubtaskBasicSetMassSimulationFrictionBvFactor = 0x10010303;


        // subtask : basic : force assist with sensor
        public const int SubtaskBasicSetForceAssistWithoutSensorForce = 0x10010401;
        public const int SubtaskBasicSetForceAssistWithSensorForce = 0x10010402;

        // subtask : basic : force assist with target position
        public const int SubtaskBasicSetForceAssistWithTargetPositionForce = 0x10010501;
        public const int SubtaskBasicSetForceAssistWithTargetPositionPosition = 0x10010502;

        // subtask : basic : force assist with target position1
        public const int SubtaskBasicSetForceAssistWithTargetPosition1Force = 0x10010503;
        public const int SubtaskBasicSetForceAssistWithTargetPosition1Position = 0x10010504;
        public const int SubtaskBasicSetForceAssistWithTargetPosition1ChangeInStep = 0x10010505;
        public const int SubtaskBasicSetForceAssistWithTargetPosition1MaxVelocity = 0x10010506;

        // subtask : basic : force resist with sensor
        public const int SubtaskBasicSetForceResistWithoutSensorForce = 0x10010601;
        public const int SubtaskBasicSetForceResistWithSensorForce = 0x10010602;

        // subtask : basic : transparent control
        public const int SubtaskBasicSetTransparentControlOriginPoint  = 0x10010701;
        public const int SubtaskBasicSetTransparentControlM = 0x10010702;
        public const int SubtaskBasicSetTransparentControlB = 0x10010703;
        public const int SubtaskBasicSetTransparentControlK = 0x10010704;
        public const int SubtaskBasicSetTransparentControlLimitSpeed = 0x1001070B;

        // subtask : basic : transparent control
        public const int SubtaskBasicSetTransparentControl1OriginPoint = 0x10010705;
        public const int SubtaskBasicSetTransparentControl1M = 0x10010706;
        public const int SubtaskBasicSetTransparentControl1B = 0x10010707;
        public const int SubtaskBasicSetTransparentControl1K = 0x10010708;
        public const int SubtaskBasicSetTransparentControl1Period = 0x10010709;
        public const int SubtaskBasicSetTransparentControl1ChangeOfK = 0x1001070A;
        public const int SubtaskBasicSetTransparentControl1LimitSpeed = 0x1001070C;

        // subtask : basic : tunnel guidance control
        public const int SubtaskBasicSetTunnelGuidanceControlPointA = 0x10010801;
        public const int SubtaskBasicSetTunnelGuidanceControlPointB = 0x10010802;
        public const int SubtaskBasicSetTunnelGuidanceControlM = 0x10010803;
        public const int SubtaskBasicSetTunnelGuidanceControlB = 0x10010804;
        public const int SubtaskBasicSetTunnelGuidanceControlK = 0x10010805;

        // subtask : basic : draw infinity curve
        public const int SubtaskBasicSetDrawInfinityCurveOriginPoint  = 0x10010901;
        public const int SubtaskBasicSetDrawInfinityCurveTimePeriod = 0x10010902;
        public const int SubtaskBasicSetDrawInfinityCurveScale = 0x10010903;

        // subtask : basic : draw circle curve
        public const int SubtaskBasicSetDrawCircleCurveOriginPoint  = 0x10010A01;
        public const int SubtaskBasicSetDrawCircleCurveTimePeriod = 0x10010A02;
        public const int SubtaskBasicSetDrawCircleCurveScale = 0x10010A03;

        // subtask : basic : kinetic control with sensor
        public const int SubtaskBasicSetKineticControlWithSensorForce = 0x10010B02;

        // subtask : basic : transparent control with limit spring force
        public const int SubtaskBasicSetTransparentControlWithLimitSpringForceOriginPoint  = 0x10010C01;
        public const int SubtaskBasicSetTransparentControlWithLimitSpringForceM = 0x10010C02;
        public const int SubtaskBasicSetTransparentControlWithLimitSpringForceB = 0x10010C03;
        public const int SubtaskBasicSetTransparentControlWithLimitSpringForceK = 0x10010C04;
        public const int SubtaskBasicSetTransparentControlWithLimitSpringForceLimitSpringForce = 0x10010C05;

        // subtask : basic : minimum jerk trajectory control
        public const int SubtaskBasicMinimumJerkTrajectoryControlPointA = 0x10010D01;
        public const int SubtaskBasicMinimumJerkTrajectoryControlPointB = 0x10010D02;
        public const int SubtaskBasicMinimumJerkTrajectoryControlInitialTime = 0x10010D03;
        public const int SubtaskBasicMinimumJerkTrajectoryControlTotalTime = 0x10010D04;

        // subtask : basic : force assist without sensor
        public const int SubtaskBasicSetForceAssistWithoutSensorRatio = 0x10010E01;
        public const int SubtaskBasicSetForceAssistWithoutSensorMaxForce = 0x10010E02;

        // subtask : basic : force resist without sensor
        public const int SubtaskBasicSetForceResistWithoutSensorRatio = 0x10010F01;
        public const int SubtaskBasicSetForceResistWithoutSensorMaxForce = 0x10010F02;

        // subtask : basic : mass simulation without sensor
        public const int SubtaskBasicSetMassSimulationWithoutSensor = 0x11010300;
        public const int SubtaskBasicSetMassSimulationWithoutSensorMass = 0x11010301;
        public const int SubtaskBasicSetMassSimulationWithoutSensorFrictionBc = 0x11010302;
        public const int SubtaskBasicSetMassSimulationWithoutSensorFrictionBv = 0x11010303;
    };

    public class FFTAICommunicationM2TaskInterfaceWorkMode
    {
        public const int NONE = 0x00;

        public const int DEBUG = 0x01;
        public const int RELAY = 0x02;
        public const int MASTER_CONTROL = 0x03;
    };

    public class FFTAICommunicationM2TaskInterfaceDebugWorkMode
    {
        public const int NONE = 0x0000;

        public const int JOINT_KINETIC_CONTROL = 0x0101;
        public const int JOINT_VELOCITY_CONTROL = 0x0102;
        public const int JOINT_POSITION_CONTROL = 0x0103;

        public const int END_EFFECTOR_KINETIC_CONTROL = 0x0201;
        public const int END_EFFECTOR_VELOCITY_CONTROL = 0x0202;
        public const int END_EFFECTOR_POSITION_CONTROL = 0x0203;
    }

    public class FFTAICommunicationM2TaskInterfaceRelayWorkMode
    {
        public const int None = 0x00;

        public const int FindHome = 0x0101;
		public const int ClearAlarm = 0x0102;
        public const int ClearFault = 0x0103;
        public const int ServoOn = 0x0104;
        public const int ServoOff = 0x0105;
        public const int PauseMotion = 0x0106;

        public const int PassiveLinearMotion = 0x0201;

        public const int MassSimulation = 0x0301;

        public const int ForceAssistWithSensor = 0x0402;

        public const int ForceAssistWithTargetPosition = 0x0501;

        public const int ForceResistWithSensor = 0x0602;

        public const int TransparentControl = 0x0701;
        public const int TunnelGuidanceControl = 0x0702;
        public const int TransparentControlWithLimitSpringForce = 0x0703;
        public const int TransparentControl1 = 0x0704;

        public const int DrawInfinityCurve = 0x0801;
        public const int DrawCircleCurve = 0x0802;

        public const int KineticControlWithSensor = 0x0901;

        public const int MinimumJerkTrajectoryControl = 0x0A01;

        public const int PassiveGaitTrajectory = 0x0902;
        public const int SinFunctionControl = 0x0903;

        public const int ForceAssistWithoutSensor = 0x0E01;

        public const int ForceResistWithoutSensor = 0x0F01;

        public const int KineticControlWithoutSensor = 0x1001;

        public const int MassSimulationWithoutSensor = 0x1101;

        public const int Test = 0xFFFF;

    }

    public class FFTAICommunicationM2TaskInterfaceMasterControlWorkMode
    {
        public const int None = 0x00;
    }
   
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationM1_LTaskInterfaceOperationMode
    {
        // Basic
        public const int BasicWorkMode = 0x01010101;

        public const int BasicFlagTaskInProcess = 0x01010201;
        public const int BasicFlagInformation = 0x01011001;

        // Debug
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
        public const int SubtaskBasicSetMassSimulationFrictionFactor = 0x10010302;

		// subtask : basic : force assist without sensor
		public const int SubtaskBasicSetForceAssistWithoutSensorForce = 0x10010401;

		// subtask : basic : force assist with sensor
		public const int SubtaskBasicSetForceAssistWithSensorForce = 0x10010402;

        // subtask : basic : force assist with target position
        public const int SubtaskBasicSetForceAssistWithTargetPositionForce = 0x10010501;
        public const int SubtaskBasicSetForceAssistWithTargetPositionPosition = 0x10010502;

        // subtask : basic : force resist without sensor
        public const int SubtaskBasicSetForceResistWithoutSensorForce = 0x10010601;

		// subtask : basic : force resist with sensor
		public const int SubtaskBasicSetForceResistWithSensorForce = 0x10010602;

        // subtask : basic : transparent control
        public const int SubtaskBasicSetTransparentControlOriginPosition = 0x10010701;
        public const int SubtaskBasicSetTransparentControlM = 0x10010702;
        public const int SubtaskBasicSetTransparentControlB = 0x10010703;
        public const int SubtaskBasicSetTransparentControlK = 0x10010704;

        // subtask : basic : kinetic control with sensor
        public const int SubtaskBasicSetKineticControlWithSensorForce = 0x10010802;

        // subtask : basic : transparent control with limit spring force
        public const int SubtaskBasicSetTransparentControlWithLimitSpringForceOriginPoint  = 0x10010901;
        public const int SubtaskBasicSetTransparentControlWithLimitSpringForceM = 0x10010902;
        public const int SubtaskBasicSetTransparentControlWithLimitSpringForceB = 0x10010903;
        public const int SubtaskBasicSetTransparentControlWithLimitSpringForceK = 0x10010904;
        public const int SubtaskBasicSetTransparentControlWithLimitSpringForceLimitSpringForce = 0x10010905;



    };

    public class FFTAICommunicationM1_LTaskInterfaceWorkMode
    {
        public const int NONE = 0x00;

        public const int DEBUG = 0x01;
        public const int RELAY = 0x02;
        public const int MASTER_CONTROL = 0x03;
    };

    public class FFTAICommunicationM1_LTaskInterfaceDebugWorkMode
    {
        public const int NONE = 0x0000;

        public const int JOINT_KINETIC_CONTROL = 0x0101;
        public const int JOINT_VELOCITY_CONTROL = 0x0102;
        public const int JOINT_POSITION_CONTROL = 0x0103;

        public const int END_EFFECTOR_KINETIC_CONTROL = 0x0201;
        public const int END_EFFECTOR_VELOCITY_CONTROL = 0x0202;
        public const int END_EFFECTOR_POSITION_CONTROL = 0x0203;
    }

    public class FFTAICommunicationM1_LTaskInterfaceRelayWorkMode
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

        public const int ForceAssistWithoutSensor = 0x0401;
        public const int ForceAssistWithSensor = 0x0402;

        public const int ForceAssistWithTargetPosition = 0x0501;

        public const int ForceResistWithoutSensor = 0x0601;
        public const int ForceResistWithSensor = 0x0602;

        public const int TransparentControl = 0x0701;
        public const int TunnelGuidanceControl = 0x0702;
        public const int TransparentControlWithLimitSpringForce = 0x0703;

        public const int DrawInfinityCurve = 0x0801;
        public const int DrawCircleCurve = 0x0802;

        public const int KineticControlWithSensor = 0x0901;
    }

    public class FFTAICommunicationM1_LTaskInterfaceMasterControlWorkMode
    {
        public const int None = 0x00;
    }

}

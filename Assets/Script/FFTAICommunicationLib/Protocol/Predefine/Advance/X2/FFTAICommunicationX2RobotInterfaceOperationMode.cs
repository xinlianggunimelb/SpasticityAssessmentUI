using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationX2RobotInterfaceOperationMode
    {
        // flag
        public const int FlagCalibration = 0x31010101;
        public const int FlagEmergentStop = 0x31010102;
        public const int FlagFault = 0x31010103;
        public const int FlagServoOn = 0x31010104;

        public const int FlagInformation = 0x31011101;

        public const int FlagOutOfJointKineticLimit = 0x31010201;
        public const int FlagOutOfJointAccelerationLimit = 0x31010202;
        public const int FlagOutOfJointVelocityLimit = 0x31010203;
        public const int FlagOutOfJointPositionLimit = 0x31010204;

        public const int FlagOutOfEndEffectorKineticLimit = 0x31010211;
        public const int FlagOutOfEndEffectorAccelerationLimit = 0x31010212;
        public const int FlagOutOfEndEffectorVelocityLimit = 0x31010213;
        public const int FlagOutOfEndEffectorPositionLimit = 0x31010214;

        public const int FlagOutOfJointLimitInformation = 0x31011201;
        public const int FlagOutOfEndEffectorLimitInformation = 0x31011202;

        // sensor : button sensor
        public const int RedButtonValue = 0x0A010101;
        public const int YellowButtonValue = 0x0A010102;
        public const int GreenButtonValue = 0x0A010103;
        public const int BlueButtonValue = 0x0A010104;

        public const int ButtonSensorInformation = 0x0A011101;
        public const int ButtonSensorInstalled = 0x0A011102;
        public const int ButtonSensorAccessible = 0x0A011103;
        public const int ButtonSensorCalibrate = 0x0A011104;

        // sensor : force sensor
        public const int LeftLegThighForceSensorValue = 0x0A010201;
        public const int LeftLegCalfForceSensorValue = 0x0A010202;
        public const int RightLegThighForceSensorValue = 0x0A010203;
        public const int RightLegCalfForceSensorValue = 0x0A010204;

        public const int ForceSensorInformation = 0x0A011201;
        public const int ForceSensorInstalled = 0x0A011202;
        public const int ForceSensorAccessible = 0x0A011203;
        public const int ForceSensorCalibrate = 0x0A011204;

        // sensor : pressure sensor
        public const int LeftLegFootPressureSensorValue  = 0x0A010301;
        public const int RightLegFootPressureSensorValue = 0x0A010302;

        public const int FootPressureInformation = 0x0A011301;
        public const int FootPressureInstalled = 0x0A011302;
        public const int FootPressureAccessible = 0x0A011303;
        public const int FootPressureCalibrate = 0x0A011304;

        // driver
        public const int DriverInformation = 0x0B011101;
        public const int DriverInstalled = 0x0B011102;
        public const int DriverAccessible = 0x0B011103;

        // basic motor configuration
        public const int ModeOfOperation = 0x01010101;
        public const int ControlWord = 0x01010102;
        public const int StatusWord = 0x01010103;
        public const int FaultClear = 0x01010104;
        public const int MotorEnable = 0x01010105;
        public const int MotorDisable = 0x01010106;

        // motor information
        public const int MotorCurrent = 0x02010101;

        public const int MotorInformation = 0x02011101;

        // joint information
        public const int JointTorque = 0x02010201;
        public const int JointVelocity = 0x02010202;
        public const int JointPosition = 0x02010203;

        public const int JointInformation = 0x02011201;

        // end effector information
        public const int EndEffectorTorque = 0x02010301;
        public const int EndEffectorVelocity = 0x02010302;
        public const int EndEffectorPosition = 0x02010303;

        public const int EndEffectorInformation = 0x02011301;

        // protection
        public const int JointLimitKinetic = 0x03010101;
        public const int JointLimitAcceleration = 0x03010102;
        public const int JointLimitVelocity = 0x03010103;
        public const int JointLimitPosition = 0x03010104;

        public const int CurrentValueAsJointLimitKinetic = 0x03010201;
        public const int CurrentValueAsJointLimitAcceleration = 0x03010202;
        public const int CurrentValueAsJointLimitVelocity = 0x03010203;
        public const int CurrentValueAsJointLimitPosition = 0x03010204;

        public const int EndEffectorLimitKinetic = 0x03020101;
        public const int EndEffectorLimitAcceleration = 0x03020102;
        public const int EndEffectorLimitVelocity = 0x03020103;
        public const int EndEffectorLimitPosition = 0x03020104;

        public const int CurrentValueAsEndEffectorLimitKinetic = 0x03020201;
        public const int CurrentValueAsEndEffectorLimitAcceleration = 0x03020202;
        public const int CurrentValueAsEndEffectorLimitVelocity = 0x03020203;
        public const int CurrentValueAsEndEffectorLimitPosition = 0x03020204;

        // home control
        public const int HomeControlZeroHomePosition = 0x10010101;

        // joint torque control
        public const int JointTorqueControlTorque    = 0x11010101;

        // joint velocity control
        public const int JointVelocityControlAcceleration = 0x12010101;
        public const int JointVelocityControlDeceleration = 0x12010201;
        public const int JointVelocityControlVelocity = 0x12010301;

        // joint position control
        public const int JointPositionControlAcceleration = 0x13010101;
        public const int JointPositionControlDeceleration = 0x13010201;
        public const int JointPositionControlVelocity = 0x13010301;
        public const int JointPositionControlPosition = 0x13010401;
        public const int JointPositionControlAddNewPoint = 0x13010501;

        // end effector torque control
        public const int EndEffectorTorqueControlTorque      = 0x21010101;

        // end effector velocity control
        public const int EndEffectorVelocityControlAcceleration  = 0x22010101;
        public const int EndEffectorVelocityControlDeceleration  = 0x22010201;
        public const int EndEffectorVelocityControlVelocity      = 0x22010301;

        // end effector position control
        public const int EndEffectorPositionControlAcceleration  = 0x23010101;
        public const int EndEffectorPositionControlDeceleration  = 0x23010201;
        public const int EndEffectorPositionControlVelocity      = 0x23010301;
        public const int EndEffectorPositionControlPosition      = 0x23010401;
        public const int EndEffectorPositionControlAddNewPoint    = 0x23010501;

    };
}

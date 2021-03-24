using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationH4RobotInterfaceOperationMode
    {
        // flag
        public const int  FLAG_CALIBRATION = 0x31010101;
        public const int  FLAG_SERVO_ON = 0x31010102;
        public const int  FLAG_EMERGENT_STOP = 0x31010103;
        public const int  FLAG_FAULT = 0x31010104;

        public const int  FLAG_INFORMATION = 0x31011101;

        // flag : limit
        public const int  FLAG_OUT_OF_JOINT_KINETIC_LIMIT = 0x31010201;
        public const int  FLAG_OUT_OF_JOINT_ACCELERATION_LIMIT = 0x31010202;
        public const int  FLAG_OUT_OF_JOINT_VELOCITY_LIMIT = 0x31010203;
        public const int  FLAG_OUT_OF_JOINT_POSITION_LIMIT = 0x31010204;

        public const int  FLAG_OUT_OF_END_EFFECTOR_KINETIC_LIMIT = 0x31010211;
        public const int  FLAG_OUT_OF_END_EFFECTOR_ACCELERATION_LIMIT = 0x31010212;
        public const int  FLAG_OUT_OF_END_EFFECTOR_VELOCITY_LIMIT = 0x31010213;
        public const int  FLAG_OUT_OF_END_EFFECTOR_POSITION_LIMIT = 0x31010214;

        public const int  FLAG_OUT_OF_JOINT_LIMIT_INFORMATION = 0x31011201;
        public const int  FLAG_OUT_OF_END_EFFECTOR_LIMIT_INFORMATION = 0x31011202;

        // sensor : button sensor
        public const int  RED_BUTTON_VALUE = 0x0A010101;
        public const int  YELLOW_BUTTON_VALUE = 0x0A010102;
        public const int  GREEN_BUTTON_VALUE = 0x0A010103;
        public const int  BLUE_BUTTON_VALUE = 0x0A010104;

        public const int  BUTTON_SENSOR_INFORMATION = 0x0A011101;
        public const int  BUTTON_SENSOR_INSTALLED = 0x0A011102;
        public const int  BUTTON_SENSOR_ACCESSIBLE = 0x0A011103;
        public const int  BUTTON_SENSOR_CALIBRATE = 0x0A011104;
        
        // sensor : imu sensor
        public const int  BODY_IMU_SENSOR_VALUE = 0x0A010401;

        public const int  IMU_SENSOR_INFORMATION = 0x0A011401;
        public const int  IMU_SENSOR_INSTALLED = 0x0A011402;
        public const int  IMU_SENSOR_ACCESSIBLE = 0x0A011403;
        public const int  IMU_SENSOR_CALIBRATE = 0x0A011404;

        // driver
        public const int  DRIVER_INFORMATION = 0x0B011101;
        public const int  DRIVER_INSTALLED = 0x0B011102;
        public const int  DRIVER_ACCESSIBLE = 0x0B011103;

        // basic motor configuration objects
        public const int  MODE_OF_OPERATION = 0x01010101;
        public const int  CONTROL_WORD = 0x01010102;
        public const int  STATUS_WORD = 0x01010103;
        public const int  CLEAR_FAULT = 0x01010104;
        public const int  MOTOR_ENABLE = 0x01010105;
        public const int  MOTOR_DISABLE = 0x01010106;

        // motor information
        public const int  MOTOR_CURRENT = 0x02010101;

        public const int  MOTOR_INFORMATION = 0x02011101;

        // joint information
        public const int  JOINT_KINETIC = 0x02010201;
        public const int  JOINT_VELOCITY = 0x02010202;
        public const int  JOINT_POSITION = 0x02010203;

        public const int  JOINT_INFORMATION = 0x02011201;

        // end effector information
        public const int  END_EFFECTOR_KINETIC = 0x02010301;
        public const int  END_EFFECTOR_VELOCITY = 0x02010302;
        public const int  END_EFFECTOR_POSITION = 0x02010303;

        public const int  END_EFFECTOR_INFORMATION = 0x02011301;

        // protection
        public const int  JOINT_LIMIT_KINETIC = 0x03010101;
        public const int  JOINT_LIMIT_ACCELERATION = 0x03010102;
        public const int  JOINT_LIMIT_VELOCITY = 0x03010103;
        public const int  JOINT_LIMIT_POSITION = 0x03010104;

        public const int  CURRENT_VALUE_AS_JOINT_LIMIT_KINETIC = 0x03010201;
        public const int  CURRENT_VALUE_AS_JOINT_LIMIT_ACCELERATION = 0x03010202;
        public const int  CURRENT_VALUE_AS_JOINT_LIMIT_VELOCITY = 0x03010203;
        public const int  CURRENT_VALUE_AS_JOINT_LIMIT_POSITION = 0x03010204;

        public const int  END_EFFECTOR_LIMIT_KINETIC = 0x03020101;
        public const int  END_EFFECTOR_LIMIT_ACCELERATION = 0x03020102;
        public const int  END_EFFECTOR_LIMIT_VELOCITY = 0x03020103;
        public const int  END_EFFECTOR_LIMIT_POSITION = 0x03020104;

        public const int  CURRENT_VALUE_AS_END_EFFECTOR_LIMIT_KINETIC = 0x03020201;
        public const int  CURRENT_VALUE_AS_END_EFFECTOR_LIMIT_ACCELERATION = 0x03020202;
        public const int  CURRENT_VALUE_AS_END_EFFECTOR_LIMIT_VELOCITY = 0x03020203;
        public const int  CURRENT_VALUE_AS_END_EFFECTOR_LIMIT_POSITION = 0x03020204;

        // home control
        public const int  HOME_CONTROL_ZERO_HOME_POSITION = 0x10010101;

        // joint torque control
        public const int  JOINT_TORQUE_CONTROL_TORQUE = 0x11010101;

        // joint velocity control
        public const int  JOINT_VELOCITY_CONTROL_ACCELERATION = 0x12010101;
        public const int  JOINT_VELOCITY_CONTROL_DECELERATION = 0x12010102;
        public const int  JOINT_VELOCITY_CONTROL_VELOCITY = 0x12010103;

        // joint position control
        public const int  JOINT_POSITION_CONTROL_ACCELERATION = 0x13010101;
        public const int  JOINT_POSITION_CONTROL_DECELERATION = 0x13010102;
        public const int  JOINT_POSITION_CONTROL_VELOCITY = 0x13010103;
        public const int  JOINT_POSITION_CONTROL_POSITION = 0x13010104;
        public const int  JOINT_POSITION_CONTROL_ADD_NEW_POINT = 0x13010105;

        // end effector torque control
        public const int  END_EFFECTOR_TORQUE_CONTROL_TORQUE = 0x21010101;

        // end effector velocity control
        public const int  END_EFFECTOR_VELOCITY_CONTROL_ACCELERATION = 0x22010101;
        public const int  END_EFFECTOR_VELOCITY_CONTROL_DECELERATION = 0x22010102;
        public const int  END_EFFECTOR_VELOCITY_CONTROL_VELOCITY = 0x22010103;

        // end effector position control
        public const int  END_EFFECTOR_POSITION_CONTROL_ACCELERATION = 0x23010101;
        public const int  END_EFFECTOR_POSITION_CONTROL_DECELERATION = 0x23010102;
        public const int  END_EFFECTOR_POSITION_CONTROL_VELOCITY = 0x23010103;
        public const int  END_EFFECTOR_POSITION_CONTROL_POSITION = 0x23010104;
        public const int  END_EFFECTOR_POSITION_CONTROL_ADD_NEW_POINT = 0x23010105;
    };
}

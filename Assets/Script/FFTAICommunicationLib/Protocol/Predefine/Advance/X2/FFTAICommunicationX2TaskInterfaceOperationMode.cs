using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationX2TaskInterfaceOperationMode 
    {
        // basic
        // basic : set work mode
        public const int BASIC_WORK_MODE = 0x01010101;

        // basic : flag
        public const int BASIC_FLAG_TASK_IN_PROCESS = 0x01010201;
        public const int BASIC_FLAG_INFORMATION = 0x01011001;

        // debug
        // debug : basic : set work mode
        public const int DEBUG_WORK_MODE = 0x02010101;

        // relay
        // relay : basic : set work mode
        public const int RELAY_WORK_MODE = 0x03010101;

        // master control
        // master control : basic : set work mode
        public const int MASTER_CONTROL_WORK_MODE = 0x04010101;

        public const int MASTER_CONTROL_WALK_PASSIVE_1_COMMAND = 0x04110101;
        public const int MASTER_CONTROL_WALK_PASSIVE_2_COMMAND = 0x04110201;

        public const int MASTER_CONTROL_WALK_ASSIST_1_COMMAND = 0x04120101;
        public const int MASTER_CONTROL_WALK_ASSIST_2_COMMAND = 0x04120201;

        public const int MASTER_CONTROL_WALK_ACTIVE_1_COMMAND = 0x04130101;
        public const int MASTER_CONTROL_WALK_ACTIVE_2_COMMAND = 0x04130201;

        // subtask
        // subtask : basic
        // subtask : basic : joint kinetic control
        public const int SUBTASK_BASIC_JOINT_KINETIC_CONTROL_KINETIC = 0x10000101;

        // subtask : basic : joint velocity control
        public const int SUBTASK_BASIC_JOINT_VELOCITY_CONTROL_ACCELERATION = 0x10000201;
        public const int SUBTASK_BASIC_JOINT_VELOCITY_CONTROL_VELOCITY = 0x10000202;

        // subtask : basic : joint position control
        public const int SUBTASK_BASIC_JOINT_POSITION_CONTROL_ACCELERATION = 0x10000301;
        public const int SUBTASK_BASIC_JOINT_POSITION_CONTROL_VELOCITY = 0x10000302;
        public const int SUBTASK_BASIC_JOINT_POSITION_CONTROL_POSITION = 0x10000303;

        // subtask : basic : end effector kinetic control
        public const int SUBTASK_BASIC_END_EFFECTOR_KINETIC_CONTROL_KINETIC = 0x10000401;

        // subtask : basic : end effector velocity control
        public const int SUBTASK_BASIC_END_EFFECTOR_VELOCITY_CONTROL_ACCELERATION = 0x10000501;
        public const int SUBTASK_BASIC_END_EFFECTOR_VELOCITY_CONTROL_VELOCITY = 0x10000502;

        // subtask : basic : end effector position control
        public const int SUBTASK_BASIC_END_EFFECTOR_POSITION_CONTROL_ACCELERATION = 0x10000601;
        public const int SUBTASK_BASIC_END_EFFECTOR_POSITION_CONTROL_VELOCITY = 0x10000602;
        public const int SUBTASK_BASIC_END_EFFECTOR_POSITION_CONTROL_POSITION = 0x10000603;

        // subtask : basic : find home

        // subtask : basic : passive move
        public const int SUBTASK_BASIC_PASSIVE_MOVE_ACCELERATION = 0x10010201;
        public const int SUBTASK_BASIC_PASSIVE_MOVE_VELOCITY = 0x10010202;
        public const int SUBTASK_BASIC_PASSIVE_MOVE_POSITION = 0x10010203;

        // subtask : basic : assist move
        public const int SUBTASK_BASIC_ASSIST_MOVE_KINETIC = 0x10010301;
        public const int SUBTASK_BASIC_ASSIST_MOVE_POSITION = 0x10010302;

        // subtask : basic : active move
        public const int SUBTASK_BASIC_ACTIVE_MOVE_KINETIC = 0x10010401;

        // subtask : basic : transparent control
        public const int SUBTASK_BASIC_TRANSPARENT_CONTROL_MOVE_ORIGIN_POINT = 0x10010501;
        public const int SUBTASK_BASIC_TRANSPARENT_CONTROL_MOVE_M = 0x10010502;
        public const int SUBTASK_BASIC_TRANSPARENT_CONTROL_MOVE_B = 0x10010503;
        public const int SUBTASK_BASIC_TRANSPARENT_CONTROL_MOVE_K = 0x10010504;

        // subtask : basic : passive : sit
        public const int SUBTASK_BASIC_PASSIVE_SIT_ACCELERATION = 0x10011101;
        public const int SUBTASK_BASIC_PASSIVE_SIT_VELOCITY = 0x10011102;
        public const int SUBTASK_BASIC_PASSIVE_SIT_POSITION = 0x10011103;
        public const int SUBTASK_BASIC_PASSIVE_SIT_POSITION_OFFSET = 0x10011104;
        public const int SUBTASK_BASIC_PASSIVE_SIT_RUN_SPEED_TIMES = 0x10011105;

        // subtask : basic : passive : stand
        public const int SUBTASK_BASIC_PASSIVE_STAND_ACCELERATION = 0x10011201;
        public const int SUBTASK_BASIC_PASSIVE_STAND_VELOCITY = 0x10011202;
        public const int SUBTASK_BASIC_PASSIVE_STAND_POSITION = 0x10011203;
        public const int SUBTASK_BASIC_PASSIVE_STAND_POSITION_OFFSET = 0x10011204;
        public const int SUBTASK_BASIC_PASSIVE_STAND_RUN_SPEED_TIMES = 0x10011205;

        // subtask : basic : passive : body ahead sit
        public const int SUBTASK_BASIC_PASSIVE_BASIT_ACCELERATION = 0x10011301;
        public const int SUBTASK_BASIC_PASSIVE_BASIT_VELOCITY = 0x10011302;
        public const int SUBTASK_BASIC_PASSIVE_BASIT_POSITION = 0x10011303;
        public const int SUBTASK_BASIC_PASSIVE_BASIT_POSITION_OFFSET = 0x10011304;
        public const int SUBTASK_BASIC_PASSIVE_BASIT_RUN_SPEED_TIMES = 0x10011305;

        // subtask : basic : passive : body ahead stand
        public const int SUBTASK_BASIC_PASSIVE_BASTAND_ACCELERATION = 0x10011401;
        public const int SUBTASK_BASIC_PASSIVE_BASTAND_VELOCITY = 0x10011402;
        public const int SUBTASK_BASIC_PASSIVE_BASTAND_POSITION = 0x10011403;
        public const int SUBTASK_BASIC_PASSIVE_BASTAND_POSITION_OFFSET = 0x10011404;
        public const int SUBTASK_BASIC_PASSIVE_BASTAND_RUN_SPEED_TIMES = 0x10011405;

        // subtask : basic : passive : left leg stand
        public const int SUBTASK_BASIC_PASSIVE_LLS_ACCELERATION = 0x10011501;
        public const int SUBTASK_BASIC_PASSIVE_LLS_VELOCITY = 0x10011502;
        public const int SUBTASK_BASIC_PASSIVE_LLS_POSITION = 0x10011503;
        public const int SUBTASK_BASIC_PASSIVE_LLS_POSITION_OFFSET = 0x10011504;
        public const int SUBTASK_BASIC_PASSIVE_LLS_RUN_SPEED_TIMES = 0x10011505;

        // subtask : basic : passive : right leg stand
        public const int SUBTASK_BASIC_PASSIVE_RLS_ACCELERATION = 0x10011601;
        public const int SUBTASK_BASIC_PASSIVE_RLS_VELOCITY = 0x10011602;
        public const int SUBTASK_BASIC_PASSIVE_RLS_POSITION = 0x10011603;
        public const int SUBTASK_BASIC_PASSIVE_RLS_POSITION_OFFSET = 0x10011604;
        public const int SUBTASK_BASIC_PASSIVE_RLS_RUN_SPEED_TIMES = 0x10011605;

        // subtask : basic : passive : left leg front
        public const int SUBTASK_BASIC_PASSIVE_LLF_ACCELERATION = 0x10011701;
        public const int SUBTASK_BASIC_PASSIVE_LLF_VELOCITY = 0x10011702;
        public const int SUBTASK_BASIC_PASSIVE_LLF_POSITION = 0x10011703;
        public const int SUBTASK_BASIC_PASSIVE_LLF_POSITION_OFFSET = 0x10011704;
        public const int SUBTASK_BASIC_PASSIVE_LLF_RUN_SPEED_TIMES = 0x10011705;

        // subtask : basic : passive : right leg front
        public const int SUBTASK_BASIC_PASSIVE_RLF_ACCELERATION = 0x10011801;
        public const int SUBTASK_BASIC_PASSIVE_RLF_VELOCITY = 0x10011802;
        public const int SUBTASK_BASIC_PASSIVE_RLF_POSITION = 0x10011803;
        public const int SUBTASK_BASIC_PASSIVE_RLF_POSITION_OFFSET = 0x10011804;
        public const int SUBTASK_BASIC_PASSIVE_RLF_RUN_SPEED_TIMES = 0x10011805;

        // subtask : basic : passive : right leg stand to stand
        public const int SUBTASK_BASIC_PASSIVE_RLSTOSTAND_ACCELERATION = 0x10011901;
        public const int SUBTASK_BASIC_PASSIVE_RLSTOSTAND_VELOCITY = 0x10011902;
        public const int SUBTASK_BASIC_PASSIVE_RLSTOSTAND_POSITION = 0x10011903;
        public const int SUBTASK_BASIC_PASSIVE_RLSTOSTAND_POSITION_OFFSET = 0x10011904;
        public const int SUBTASK_BASIC_PASSIVE_RLSTOSTAND_RUN_SPEED_TIMES = 0x10011905;

        // subtask : basic : passive : left leg stand to stand
        public const int SUBTASK_BASIC_PASSIVE_LLSTOSTAND_ACCELERATION = 0x10011A01;
        public const int SUBTASK_BASIC_PASSIVE_LLSTOSTAND_VELOCITY = 0x10011A02;
        public const int SUBTASK_BASIC_PASSIVE_LLSTOSTAND_POSITION = 0x10011A03;
        public const int SUBTASK_BASIC_PASSIVE_LLSTOSTAND_POSITION_OFFSET = 0x10011A04;
        public const int SUBTASK_BASIC_PASSIVE_LLSTOSTAND_RUN_SPEED_TIMES = 0x10011A05;

        // subtask : basic : passive : left leg stand to right leg front
        public const int SUBTASK_BASIC_PASSIVE_LLSTORLF_RUN_SPEED_TIMES = 0x10011B05;

        // subtask : basic : passive : right leg stand to left leg front
        public const int SUBTASK_BASIC_PASSIVE_RLSTOLLF_RUN_SPEED_TIMES = 0x10011C05;

        // subtask : basic : passive : left leg front to right leg front
        public const int SUBTASK_BASIC_PASSIVE_LLFTORLF_RUN_SPEED_TIMES = 0x10011D05;

        // subtask : basic : passive : right leg front to left leg front
        public const int SUBTASK_BASIC_PASSIVE_RLFTOLLF_RUN_SPEED_TIMES = 0x10011E05;

        // subtask : basic : passive : walk with llf
        public const int SUBTASK_BASIC_PASSIVE_WALKWITHLLF_RUN_SPEED_TIMES = 0x10012105;

        // subtask : basic : passive : walk with rlf
        public const int SUBTASK_BASIC_PASSIVE_WALKWITHRLF_RUN_SPEED_TIMES = 0x10012205;
    };

    public class FFTAICommunicationX2TaskInterfaceWorkMode
    {
        public const int NONE = 0x00;

        public const int DEBUG = 0x01;
        public const int RELAY = 0x02;
        public const int MASTER_CONTROL = 0x03;
    };

    public class FFTAICommunicationX2TaskInterfaceDebugWorkMode
    {
        public const int NONE = 0x0000;

        public const int JOINT_KINETIC_CONTROL = 0x0101;
        public const int JOINT_VELOCITY_CONTROL = 0x0102;
        public const int JOINT_POSITION_CONTROL = 0x0103;

        public const int END_EFFECTOR_KINETIC_CONTROL = 0x0201;
        public const int END_EFFECTOR_VELOCITY_CONTROL = 0x0202;
        public const int END_EFFECTOR_POSITION_CONTROL = 0x0203;
    }

    public class FFTAICommunicationX2TaskInterfaceRelayWorkMode
    {
        public const int NONE = 0x000000;

        public const int FIND_HOME = 0x000101;
        public const int CLEAR_ALARM = 0x000102;
        public const int CLEAR_FAULT = 0x000103;
        public const int SERVO_ON = 0x000104;
        public const int SERVO_OFF = 0x000105;
        public const int PAUSE_MOTION = 0x000106;

        public const int PASSIVE_MOVE = 0x010101;
        public const int PASSIVE_SIT = 0x010201;
        public const int PASSIVE_STAND = 0x010202;
        public const int PASSIVE_LLF = 0x010203;
        public const int PASSIVE_RLF = 0x010204;

        public const int ASSIST_MOVE = 0x020101;
        public const int ASSIST_SIT = 0x020201;
        public const int ASSIST_STAND = 0x020202;
        public const int ASSIST_LLF = 0x020203;
        public const int ASSIST_RLF = 0x020204;

        public const int ACTIVE_MOVE = 0x030101;
        public const int ACRIVE_SIT = 0x030201;
        public const int ACTIVE_STAND = 0x030202;
        public const int ACTIVE_LLF = 0x030203;
        public const int ACTIVE_RLF = 0x030204;

        public const int TRANSPARENT_MOVE = 0x040101;
    }

    public class FFTAICommunicationX2TaskInterfaceMasterControlWorkMode
    {
        public const int NONE = 0x00000000;

        public const int WALK_PASSIVE_1 = 0x01010101;
        public const int WALK_PASSIVE_2 = 0x01010201;

        public const int WALK_ASSIST_1 = 0x01020101;
        public const int WALK_ASSIST_2 = 0x01020201;

        public const int WALK_ACTIVE_1 = 0x01030101;
        public const int WALK_ACTIVE_2 = 0x01030201;
    }

    public class FFTAICommunicationX2TaskInterfaceMasterControlWalkPassive1Command
    {
        public const int SET_HOME = 0x10;
        public const int STOP = 0x01;
        public const int SIT = 0x02;
        public const int STAND = 0x03;
        public const int WALK = 0x04;
    }

    public class FFTAICommunicationV2X2TaskInterfaceMasterControlWalkPassive2Command
    {
        public const int SET_HOME = 0x10;
        public const int STOP = 0x01;
        public const int SIT = 0x02;
        public const int STAND = 0x03;
        public const int LLF = 0x04;
        public const int RLF = 0x05;
    }

    public class FFTAICommunicationV2X2TaskInterfaceMasterControlWalkPassive3Command
    {
        public const int SET_HOME = 0x10;
        public const int STOP = 0x01;
        public const int SIT = 0x02;
        public const int STAND = 0x03;
        public const int LLF = 0x04;
        public const int RLF = 0x05;
    }

    public class FFTAICommunicationV2X2TaskInterfaceMasterControlWalkPassive4Command
    {
        public const int SET_HOME = 0x10;
        public const int STOP = 0x01;
        public const int SIT = 0x02;
        public const int STAND = 0x03;
        public const int WALK = 0x04;
    }
    
    public class FFTAICommunicationV2X2TaskInterfaceMasterControlWalkActive1Command
    {
        public const int SET_HOME = 0x10;
        public const int STOP = 0x01;
        public const int WALK = 0x04;
    }

    public class FFTAICommunicationV2X2TaskInterfaceMasterControlWalkActive2Command
    {
        public const int SET_HOME = 0x10;
        public const int STOP = 0x01;
        public const int WALK = 0x04;
    }
}

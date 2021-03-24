using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationH4TaskInterfaceOperationMode
    {
        // basic
        // basic : set work mode
        public const int  BASIC_WORK_MODE = 0x01010101;

        // basic : flag
        public const int  BASIC_FLAG_TASK_IN_PROCESS = 0x01010201;
        public const int  BASIC_FLAG_INFORMATION = 0x01011001;

        // subtask
        // subtask : basic
        // subtask : basic : joint kinetic control
        public const int  SUBTASK_BASIC_JOINT_KINETIC_CONTROL_KINETIC = 0x10000101;

        // subtask : basic : joint velocity control
        public const int  SUBTASK_BASIC_JOINT_VELOCITY_CONTROL_ACCELERATION = 0x10000201;
        public const int  SUBTASK_BASIC_JOINT_VELOCITY_CONTROL_VELOCITY = 0x10000202;

        // subtask : basic : joint position control
        public const int  SUBTASK_BASIC_JOINT_POSITION_CONTROL_ACCELERATION = 0x10000301;
        public const int  SUBTASK_BASIC_JOINT_POSITION_CONTROL_VELOCITY = 0x10000302;
        public const int  SUBTASK_BASIC_JOINT_POSITION_CONTROL_POSITION = 0x10000303;

        // subtask : basic : end effector kinetic control
        public const int  SUBTASK_BASIC_END_EFFECTOR_KINETIC_CONTROL_KINETIC = 0x10000401;

        // subtask : basic : end effector velocity control
        public const int  SUBTASK_BASIC_END_EFFECTOR_VELOCITY_CONTROL_ACCELERATION = 0x10000501;
        public const int  SUBTASK_BASIC_END_EFFECTOR_VELOCITY_CONTROL_VELOCITY = 0x10000502;

        // subtask : basic : end effector position control
        public const int  SUBTASK_BASIC_END_EFFECTOR_POSITION_CONTROL_ACCELERATION = 0x10000601;
        public const int  SUBTASK_BASIC_END_EFFECTOR_POSITION_CONTROL_VELOCITY = 0x10000602;
        public const int  SUBTASK_BASIC_END_EFFECTOR_POSITION_CONTROL_POSITION = 0x10000603;

        // subtask : basic : find home

        // subtask : basic : passive move
        public const int  SUBTASK_BASIC_PASSIVE_MOVE_ACCELERATION = 0x10010201;
        public const int  SUBTASK_BASIC_PASSIVE_MOVE_VELOCITY = 0x10010202;
        public const int  SUBTASK_BASIC_PASSIVE_MOVE_POSITION = 0x10010203;

        // subtask : basic : assist move
        public const int  SUBTASK_BASIC_ASSIST_MOVE_KINETIC = 0x10010301;
        public const int  SUBTASK_BASIC_ASSIST_MOVE_POSITION = 0x10010302;

        // subtask : basic : active move
        public const int  SUBTASK_BASIC_ACTIVE_MOVE_KINETIC = 0x10010401;

        // subtask : basic : transparent control
        public const int  SUBTASK_BASIC_TRANSPARENT_CONTROL_MOVE_ORIGIN_POINT = 0x10010501;
        public const int  SUBTASK_BASIC_TRANSPARENT_CONTROL_MOVE_M = 0x10010502;
        public const int  SUBTASK_BASIC_TRANSPARENT_CONTROL_MOVE_B = 0x10010503;
        public const int  SUBTASK_BASIC_TRANSPARENT_CONTROL_MOVE_K = 0x10010504;

        // subtask : basic : passive : sit
        public const int  SUBTASK_BASIC_PASSIVE_SIT_ACCELERATION = 0x10011101;
        public const int  SUBTASK_BASIC_PASSIVE_SIT_VELOCITY = 0x10011102;
        public const int  SUBTASK_BASIC_PASSIVE_SIT_POSITION = 0x10011103;
        public const int  SUBTASK_BASIC_PASSIVE_SIT_POSITION_OFFSET = 0x10011104;
        public const int  SUBTASK_BASIC_PASSIVE_SIT_RUN_SPEED_TIMES = 0x10011105;

        // subtask : basic : passive : stand
        public const int  SUBTASK_BASIC_PASSIVE_STAND_ACCELERATION = 0x10011201;
        public const int  SUBTASK_BASIC_PASSIVE_STAND_VELOCITY = 0x10011202;
        public const int  SUBTASK_BASIC_PASSIVE_STAND_POSITION = 0x10011203;
        public const int  SUBTASK_BASIC_PASSIVE_STAND_POSITION_OFFSET = 0x10011204;
        public const int  SUBTASK_BASIC_PASSIVE_STAND_RUN_SPEED_TIMES = 0x10011205;

        // subtask : basic : passive : body ahead sit
        public const int  SUBTASK_BASIC_PASSIVE_BASIT_ACCELERATION = 0x10011301;
        public const int  SUBTASK_BASIC_PASSIVE_BASIT_VELOCITY = 0x10011302;
        public const int  SUBTASK_BASIC_PASSIVE_BASIT_POSITION = 0x10011303;
        public const int  SUBTASK_BASIC_PASSIVE_BASIT_POSITION_OFFSET = 0x10011304;
        public const int  SUBTASK_BASIC_PASSIVE_BASIT_RUN_SPEED_TIMES = 0x10011305;

        // subtask : basic : passive : body ahead stand
        public const int  SUBTASK_BASIC_PASSIVE_BASTAND_ACCELERATION = 0x10011401;
        public const int  SUBTASK_BASIC_PASSIVE_BASTAND_VELOCITY = 0x10011402;
        public const int  SUBTASK_BASIC_PASSIVE_BASTAND_POSITION = 0x10011403;
        public const int  SUBTASK_BASIC_PASSIVE_BASTAND_POSITION_OFFSET = 0x10011404;
        public const int  SUBTASK_BASIC_PASSIVE_BASTAND_RUN_SPEED_TIMES = 0x10011405;

        // subtask : basic : passive : left leg stand
        public const int  SUBTASK_BASIC_PASSIVE_LLS_ACCELERATION = 0x10011501;
        public const int  SUBTASK_BASIC_PASSIVE_LLS_VELOCITY = 0x10011502;
        public const int  SUBTASK_BASIC_PASSIVE_LLS_POSITION = 0x10011503;
        public const int  SUBTASK_BASIC_PASSIVE_LLS_POSITION_OFFSET = 0x10011504;
        public const int  SUBTASK_BASIC_PASSIVE_LLS_RUN_SPEED_TIMES = 0x10011505;

        // subtask : basic : passive : right leg stand
        public const int  SUBTASK_BASIC_PASSIVE_RLS_ACCELERATION = 0x10011601;
        public const int  SUBTASK_BASIC_PASSIVE_RLS_VELOCITY = 0x10011602;
        public const int  SUBTASK_BASIC_PASSIVE_RLS_POSITION = 0x10011603;
        public const int  SUBTASK_BASIC_PASSIVE_RLS_POSITION_OFFSET = 0x10011604;
        public const int  SUBTASK_BASIC_PASSIVE_RLS_RUN_SPEED_TIMES = 0x10011605;

        // subtask : basic : passive : left leg front
        public const int  SUBTASK_BASIC_PASSIVE_LLF_ACCELERATION = 0x10011701;
        public const int  SUBTASK_BASIC_PASSIVE_LLF_VELOCITY = 0x10011702;
        public const int  SUBTASK_BASIC_PASSIVE_LLF_POSITION = 0x10011703;
        public const int  SUBTASK_BASIC_PASSIVE_LLF_POSITION_OFFSET = 0x10011704;
        public const int  SUBTASK_BASIC_PASSIVE_LLF_RUN_SPEED_TIMES = 0x10011705;

        // subtask : basic : passive : right leg front
        public const int  SUBTASK_BASIC_PASSIVE_RLF_ACCELERATION = 0x10011801;
        public const int  SUBTASK_BASIC_PASSIVE_RLF_VELOCITY = 0x10011802;
        public const int  SUBTASK_BASIC_PASSIVE_RLF_POSITION = 0x10011803;
        public const int  SUBTASK_BASIC_PASSIVE_RLF_POSITION_OFFSET = 0x10011804;
        public const int  SUBTASK_BASIC_PASSIVE_RLF_RUN_SPEED_TIMES = 0x10011805;

        // subtask : basic : passive : right leg stand to stand
        public const int  SUBTASK_BASIC_PASSIVE_RLSTOSTAND_ACCELERATION = 0x10011901;
        public const int  SUBTASK_BASIC_PASSIVE_RLSTOSTAND_VELOCITY = 0x10011902;
        public const int  SUBTASK_BASIC_PASSIVE_RLSTOSTAND_POSITION = 0x10011903;
        public const int  SUBTASK_BASIC_PASSIVE_RLSTOSTAND_POSITION_OFFSET = 0x10011904;
        public const int  SUBTASK_BASIC_PASSIVE_RLSTOSTAND_RUN_SPEED_TIMES = 0x10011905;

        // subtask : basic : passive : left leg stand to stand
        public const int  SUBTASK_BASIC_PASSIVE_LLSTOSTAND_ACCELERATION = 0x10011A01;
        public const int  SUBTASK_BASIC_PASSIVE_LLSTOSTAND_VELOCITY = 0x10011A02;
        public const int  SUBTASK_BASIC_PASSIVE_LLSTOSTAND_POSITION = 0x10011A03;
        public const int  SUBTASK_BASIC_PASSIVE_LLSTOSTAND_POSITION_OFFSET = 0x10011A04;
        public const int  SUBTASK_BASIC_PASSIVE_LLSTOSTAND_RUN_SPEED_TIMES = 0x10011A05;

        // subtask : basic : passive : left leg stand to right leg front
        public const int  SUBTASK_BASIC_PASSIVE_LLSTORLF_RUN_SPEED_TIMES = 0x10011B05;

        // subtask : basic : passive : right leg stand to left leg front
        public const int  SUBTASK_BASIC_PASSIVE_RLSTOLLF_RUN_SPEED_TIMES = 0x10011C05;

        // subtask : basic : passive : left leg front to right leg front
        public const int  SUBTASK_BASIC_PASSIVE_LLFTORLF_RUN_SPEED_TIMES = 0x10011D05;

        // subtask : basic : passive : right leg front to left leg front
        public const int  SUBTASK_BASIC_PASSIVE_RLFTOLLF_RUN_SPEED_TIMES = 0x10011E05;

        // subtask : basic : passive : walk with llf
        public const int  SUBTASK_BASIC_PASSIVE_WALKWITHLLF_RUN_SPEED_TIMES = 0x10012105;

        // subtask : basic : passive : walk with rlf
        public const int  SUBTASK_BASIC_PASSIVE_WALKWITHRLF_RUN_SPEED_TIMES = 0x10012205;

        // subtask : passive : walk passive 1
        public const int SUBTASK_WALK_PASSIVE_1_PROCESS = 0x10110101;
        public const int  SUBTASK_WALK_PASSIVE_1_COMMAND = 0x10110102;
        public const int  SUBTASK_WALK_PASSIVE_1_STATE = 0x10110103;

        public const int SUBTASK_WALK_PASSIVE_FLAG_CALIBRATE = 0x10110201;

        public const int SUBTASK_WALK_PASSIVE_REQUEST_ANGLE_FOR_COMMAND_WALK = 0x10110301;

        public const int SUBTASK_WALK_PASSIVE_COMMAND_PARAMETER_THIGH_LENGTH = 0x10110401;
        public const int SUBTASK_WALK_PASSIVE_COMMAND_PARAMETER_SHANK_LENGTH = 0x10110402;
        public const int SUBTASK_WALK_PASSIVE_COMMAND_PARAMETER_STEP_LENGTH = 0x10110403;
        public const int SUBTASK_WALK_PASSIVE_COMMAND_PARAMETER_STEP_HEIGHT = 0x10110404;
        public const int SUBTASK_WALK_PASSIVE_COMMAND_PARAMETER_STEP_TIME = 0x10110405;
        public const int SUBTASK_WALK_PASSIVE_COMMAND_PARAMETER_SIT_TIME = 0x10110406;
        public const int SUBTASK_WALK_PASSIVE_COMMAND_PARAMETER_STAND_TIME = 0x10110407;
        public const int SUBTASK_WALK_PASSIVE_COMMAND_PARAMETER_TIME_PROPORTION = 0x10110408;

        public const int SUBTASK_WALK_PASSIVE_JOG_VELOCITY = 0x10110501;
    };
}

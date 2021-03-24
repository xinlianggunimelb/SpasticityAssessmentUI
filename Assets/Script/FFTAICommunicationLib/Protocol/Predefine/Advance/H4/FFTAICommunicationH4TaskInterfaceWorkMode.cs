using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationH4TaskInterfaceWorkMode
    {
        public static int NONE	= 0x00000000;
	
	    // debug
	    public static int JOINT_KINETIC_CONTROL			= 0x01010101;
	    public static int JOINT_VELOCITY_CONTROL		= 0x01010102;
	    public static int JOINT_POSITION_CONTROL		= 0x01010103;
	
	    public static int END_EFFECTOR_KINETIC_CONTROL	= 0x01010201;
	    public static int END_EFFECTOR_VELOCITY_CONTROL	= 0x01010202;
	    public static int END_EFFECTOR_POSITION_CONTROL	= 0x01010203;
	
	    // basic
	    public static int SET_HOME		= 0x02010101;
	    public static int CLEAR_ALARM	= 0x02010102;
	    public static int CLEAR_FAULT	= 0x02010103;
	    public static int SERVO_ON		= 0x02010104;
	    public static int SERVO_OFF		= 0x02010105;
	    public static int PAUSE_MOTION	= 0x02010106;
	
	    // passive move
	    public static int PASSIVE_MOVE	= 0x02020101;
	    public static int PASSIVE_SIT	= 0x02020201;
	    public static int PASSIVE_STAND	= 0x02020202;
	    public static int PASSIVE_LLF	= 0x02020203;
	    public static int PASSIVE_RLF	= 0x02020204;

	    // assist move
	    public static int ASSIST_MOVE	= 0x02030101;
	    public static int ASSIST_SIT	= 0x02030201;
	    public static int ASSIST_STAND	= 0x02030202;
	    public static int ASSIST_LLF	= 0x02030203;
	    public static int ASSIST_RLF	= 0x02030204;
	
	    // active move
	    public static int ACTIVE_MOVE	= 0x02040101;
	    public static int ACTIVE_SIT	= 0x02040201;
	    public static int ACTIVE_STAND	= 0x02040202;
	    public static int ACTIVE_LLF	= 0x02040203;
	    public static int ACTIVE_RLF	= 0x02040204;

	    // master control
	    public static int WALK_PASSIVE_1	= 0x03010101;
	    public static int WALK_ASSIST_1	    = 0x03020101;
	    public static int WALK_ACTIVE_1	    = 0x03030101;
    };
}

using CORC;

namespace CORC
{
    public class CORCM2 : CORCRobot
    {
        /// <summary>
        /// Specific class to define a CORC M2 robot object and manage communication with CORC server
        /// State dictionnary will contain X: end-effector position, dX: end-effector velocity, F: end-effector interaction force, t: running time of CORC server
        /// </summary>
        
        //public override void Init(string ip = "127.0.0.1", int port = 2048) //Locally
        //public override void Init(string ip = "192.168.6.2", int port = 2048) //Linux
        //public override void Init(string ip = "192.168.7.2", int port = 2048) //Windows
        public override void Init(long t0, string ip, int port) //Windows
        
        {
            
            if (Client.IsConnected())
                Client.Disconnect();

            if (Client.Connect(t0, ip, port))
            {
                //Define state values to receive (in pre-defined order: should match CORC implementation)
                State = new FixedDictionary
                {
                    ["t"] = new double[1],
                    ["X"] = new double[2],
                    ["dX"] = new double[2],
                    ["F"] = new double[2],
                    ["S"] = new double[1],
                    ["V"] = new double[1],
                    ["R"] = new double[1],
                    ["Ct"] = new double[2],
                    ["IA"] = new double[1]
                };
                State.Init(new string[] { "t", "X", "dX", "F", "S", "V", "R", "Ct", "IA" });
                Initialised = true;
            }
            else
            {
                Initialised = false;
            }
        }
    }
}

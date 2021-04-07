using CORC;

namespace CORC
{
    public class CORCM3 : CORCRobot
    {
        /// <summary>
        /// Specific class to define a CORC X2 robot object and manage communication with CORC server
        /// State dictionnary will contain X: end-effector position, dq: end-effector velocity, F: end-effector interaction force, t: running time of CORC server
        /// </summary>
        public override void Init(long t0, string ip = "192.168.7.2", int port = 2048)
        {
            if (Client.IsConnected())
                Client.Disconnect();

            if (Client.Connect(t0, ip, port))
            {
                //Define state values to receive (in pre-defined order: should match CORC implementation)
                State = new FixedDictionary
                {
                    ["t"] = new double[1],
                    ["X"] = new double[3],
                    ["dX"] = new double[3],
                    ["F"] = new double[3]
                };
                State.Init(new string[] { "t", "X", "dX", "F" });
                Initialised = true;
            }
            else
            {
                Initialised = false;
            }
        }
    }
}

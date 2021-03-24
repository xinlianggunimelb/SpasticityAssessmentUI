using CORC;

namespace CORC
{
    /// <summary>
    /// Specific class to define a CORC X2 robot object and manage communication with CORC server
    /// State dictionnary will contain q: joint position, dq: joint velocities, tau: joint torques, t: running time of CORC server
    /// </summary>
    public class CORCX2 : CORCRobot
    {
        public override void Init(string ip = "192.168.7.2", int port = 2048)
        {
            if (Client.IsConnected())
                Client.Disconnect();

            if (Client.Connect(ip, port))
            {
                //Define state values to receive (in pre-defined order: should match CORC implementation)
                State = new FixedDictionary
                {
                    ["t"] = new double[1],
                    ["q"] = new double[4],
                    ["dq"] = new double[4],
                    ["tau"] = new double[4]
                };
                State.Init(new string[] { "t", "q", "dq", "tau" });
                Initialised = true;
            }
            else
            {
                Initialised = false;
            }
        }
    }
}
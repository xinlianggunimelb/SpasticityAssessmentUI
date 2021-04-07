using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace CORC
{
    public struct FLNLCmd
    {
        public string cmd;
        public double[] parameters;
    };

    /// <summary>
    /// Low-level communication library for CORC allowing to exchange double values and commands (4 characters) with double values parameters.
    /// RT paradigm implementation: discard everything but last received.
    /// Based on libFLNL (https://github.com/vcrocher/libFLNL).
    /// </summary>
    public class FLNLClient
    {
        //These values should match the libFLNL server implementation
        private const int MESSAGE_SIZE = 255; //Messages (frame) size in bytes
        private const int EXPECTED_DOUBLE_SIZE = 8; //Size expected for the doubles: will be checked at startup and should be same on server and client size
        private const int CMD_SIZE = 4; //Commands length in chars
        private int MaxNbValues = (int)Math.Floor((MESSAGE_SIZE - 3 - CMD_SIZE) / (float)sizeof(double));
        private const char InitValueCode = 'V';
        private const char InitCmdCode = 'C';


        private IPAddress IP;
        private int Port;
        private TcpClient client;
        private Thread receptionThread = null;
        
        private long t0_in_ticks;

        private double[] ReceivedValues;
        private char[] ReceivedCmd = new char[CMD_SIZE];
        private double[] ReceivedCmdParams;
        private bool IsCmd = false;
        private bool IsValues = false;
        private bool Connected = false;
        private bool Logging = false;
        public StreamWriter LogFileStream;


        public FLNLClient()
        {
            client = new TcpClient();
            //Set buffers size to message size
            client.Client.ReceiveBufferSize = MESSAGE_SIZE*100; //Ensure enough space to avoide packets bouncing (and associated accumulation of old packets=> discard)
            client.Client.SendBufferSize = MESSAGE_SIZE;
            client.Client.NoDelay = true;
            //timeout when connection is closed to 1s
            client.Client.LingerState = new LingerOption(true, 1);

        }

        ~FLNLClient()
        {
            Disconnect();
            client.Dispose();
        }

        /// <summary>
        /// Attempt to connect to the server indicated by ip and port and create a reception thread
        /// </summary>
        public bool Connect(long t0, string ip, int port = 2048)
        {
            IP = IPAddress.Parse(ip);
            Port = port;
            t0_in_ticks = t0;
            
            try
            {
                client.Connect(ip, Port);
            }
            catch (SocketException)
            {
                Console.WriteLine("Connection error");
                return false;
            }
            
            if (client.Connected)
            {
                receptionThread = new Thread(new ThreadStart(Receive));
                receptionThread.IsBackground = true;
                receptionThread.Start();
                Connected = true;
                return true;
            }
            else
            {
                Console.WriteLine("Connection error");
                return false;
            }
        }

        /// <summary>
        /// Close connection and kill reception thread
        /// </summary>
        public void Disconnect()
        {
            Connected = false;
			try
			{
				LogFileStream.Close();
			}
			catch
			{
				//ok
			}
			
            if (receptionThread != null)
            {
                receptionThread.Abort();
            }
        }

        public bool IsConnected()
        {
            if (Connected)
            {
                if (!client.Connected)
                {
                    Disconnect();
                }
            }
            return Connected;
        }

        public bool SetLogging(bool val)
        {
            Logging = val;
            return Logging;
        }


        /// <summary>
        /// Send a CMD_SIZE characters command and double parameters
        /// </summary>
        public void SendCmd(char[] cmd, double[] parameters = null)
        {
            if (cmd.Length > CMD_SIZE)
            {
                Console.WriteLine("Command too long (>" + CMD_SIZE + " characters)");
                return;
            }
            parameters = parameters ?? new double[0];
            if (parameters.Length > MaxNbValues)
            {
                Console.WriteLine("Too many parameters");
                return;
            }

            if (Connected)
            {
                try
                {
                    NetworkStream stream = client.GetStream();
                    Byte[] bytes = new Byte[MESSAGE_SIZE];

                    bytes[0] = (Byte)('C');
                    bytes[1] = (Byte)parameters.Length;
                    //Copy cmd
                    for (int i = 0; i < cmd.Length; i++)
                    {
                        bytes[2 + i] = (Byte)cmd[i];
                    }
                    //pad if less than CMD_SIZE
                    for (int i = cmd.Length; i < CMD_SIZE; i++)
                    {
                        bytes[2 + cmd.Length] = 0;
                    }
                    //Add parameters
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        Byte[] val = new byte[sizeof(double)];
                        val = BitConverter.GetBytes(parameters[i]);
                        val.CopyTo(bytes, 2 + CMD_SIZE + i * sizeof(double));
                    }
                    //Pad with 0s
                    for (int i = 2 + CMD_SIZE + parameters.Length * sizeof(double); i < MESSAGE_SIZE - 1; i++)
                    {
                        bytes[i] = 0;
                    }
                    bytes[bytes.Length - 1] = Checksum(bytes);
                    stream.Write(bytes, 0, bytes.Length);
                }
                catch (SocketException socketException)
                {
                    Console.WriteLine("Server disconnected (SocketException " + socketException.ToString() + ")");
                }
            }
        }

        /// <summary>
        /// Send double values
        /// </summary>
        public void SendValues(double[] vals)
        {
            if (vals.Length > MaxNbValues)
            {
                Console.WriteLine("Too many values");
                return;
            }

            if (Connected)
            {
                try
                {
                    NetworkStream stream = client.GetStream();
                    Byte[] bytes = new Byte[MESSAGE_SIZE];
                    bytes[0] = (Byte)('V');
                    bytes[1] = (Byte)vals.Length;
                    for (int i = 0; i < vals.Length; i++)
                    {
                        Byte[] val = new byte[sizeof(double)];
                        val = BitConverter.GetBytes(vals[i]);
                        val.CopyTo(bytes, 2 + i * sizeof(double));
                    }
                    //Pad with 0s
                    for (int i = 2 + vals.Length * sizeof(double); i < MESSAGE_SIZE - 1; i++)
                    {
                        bytes[i] = 0;
                    }
                    bytes[bytes.Length - 1] = Checksum(bytes);
                    stream.Write(bytes, 0, bytes.Length);
                }
                catch (SocketException socketException)
                {
                    Console.WriteLine("Server disconnected (SocketException " + socketException.ToString() + ")");
                }
            }
        }

        /// <summary>
        /// return true if new values have been received since last call to GetReceivedValues()
        /// </summary>
        public bool IsReceivedValues()
        {
            return IsValues;
        }

        /// <summary>
        /// return true if a new command has been received since last call to GetReceivedCmd()
        /// </summary>
        public bool IsReceivedCmd()
        {
            return IsCmd;
        }

        /// <summary>
        /// Return array of latest received values from the server
        /// </summary>
        public double[] GetReceivedValues()
        {
            double[] values = new double[ReceivedValues.Length];
            Array.Copy(ReceivedValues, values, ReceivedValues.Length);
            IsValues = false;
            return values;
        }

        /// <summary>
        /// Return latest received cmd from the server
        /// </summary>
        public FLNLCmd GetReceivedCmd()
        {
            FLNLCmd cmd;
            cmd.cmd = new string(ReceivedCmd);
            cmd.parameters = new double[ReceivedCmdParams.Length];
            Array.Copy(ReceivedCmdParams, cmd.parameters, ReceivedCmdParams.Length);
            IsCmd = false;
            return cmd;
        }

        /// <summary>
        /// Compute message checksum
        /// </summary>
        private byte Checksum(Byte[] bytes)
        {
            byte ck = 0;
            for (int i = 2; i < bytes.Length - 1; i++)
                ck ^= bytes[i];

            return ck;
        }

        /// <summary>
        /// Receiving function: infinite loop while connected
        /// </summary>
        private void Receive()
        {
            try
            {
                using (NetworkStream stream = client.GetStream())
                {
                    int length;
                    Byte[] bytes = new Byte[MESSAGE_SIZE];
                    // Read incomming stream into byte array
                    while ((length = stream.Read(bytes, 0, bytes.Length)) != 0 && client.Connected)
                    {
                        if (length == MESSAGE_SIZE)
                        {
                            if (bytes[MESSAGE_SIZE - 1] == Checksum(bytes))
                            {
                                //Values
                                if (bytes[0] == InitValueCode)
                                {
                                    int nbValuesToReceive = bytes[1];
                                    ReceivedValues = new double[nbValuesToReceive];
                                    for (int i = 0; i < nbValuesToReceive; i++)
                                        ReceivedValues[i] = BitConverter.ToDouble(bytes, 2 + i * sizeof(double));

                                    IsValues = true;

                                    //Log to file as received
                                    if (Logging)
                                    {
                                        //Write to file
										for (int i = 0; i < nbValuesToReceive; i++)
											LogFileStream.Write(ReceivedValues[i] + ",");
										LogFileStream.Write((float)((DateTime.Now.Ticks - t0_in_ticks)/(float)10000000) + ",");
										LogFileStream.Write("\n");
                                    }

                                }
                                //Cmd
                                else if (bytes[0] == InitCmdCode)
                                {
                                    int nbparams = bytes[1];
                                    for (int i = 0; i < CMD_SIZE; i++)
                                        ReceivedCmd[i] = (char)bytes[2 + i];

                                    ReceivedCmdParams = new double[nbparams];
                                    for (int i = 0; i < nbparams; i++)
                                        ReceivedCmdParams[i] = BitConverter.ToDouble(bytes, 2 + CMD_SIZE + i * sizeof(double));

                                    IsCmd = true;
                                }
                                else
                                {
                                    Console.WriteLine("Wrong message type (header)");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Wrong message checksum");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Wrong message size (" + length + ")");
                        }
                    }
                }
            }
            catch (SocketException socketException)
            {
                Console.WriteLine("Server disconnected (SocketException " + socketException.ToString() + ")");
            }
        }
    }
}

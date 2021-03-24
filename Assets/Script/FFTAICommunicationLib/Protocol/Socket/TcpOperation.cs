/*
 * 文件说明：
 *      Basic Socket Operation Class
 * 
 * Reference:
 *      https://www.cnblogs.com/sdyinfang/p/5519708.html
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;

using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace FFTAICommunicationLib
{
    public class TcpOperation
    {
        //-------------------------------------------- TCP Property ---------------------------------------------
        
        private string TcpConnectServerIpAddressString;
        private IPAddress TcpConnectServerIpAddress;
        private int  TcpConnectServerPort;
        private IPEndPoint  TcpConnectServerEndPoint ;

        private int ConnectStatus;
        
        private TcpClient TcpClient;

        public static int messageAmount;
        //-------------------------------------------- TCP Property ---------------------------------------------

        public TcpOperation()
        {
            
        }

        //-------------------------------------------- TCP Functions --------------------------------------------

        /// @brief Tcp client connect to the server [TCP 客户端连接到服务器]
        public int TcpConnectClientToServer(string ipAddress, int  port)
        {
            // build server ip end point 
            TcpConnectServerIpAddressString = ipAddress;
            TcpConnectServerPort = port;

            try
            {
                TcpConnectServerIpAddress = IPAddress.Parse(TcpConnectServerIpAddressString);
            }
            catch (ArgumentNullException)
            {
                // log information
                Debugs.Log("ArgumentNullException", FFTAIRobotCommLogType.WARNING);

                return FunctionResult.ARGUMENT_NULL_EXCEPTION;
            }
            catch (FormatException)
            {
                // log information
                Debugs.Log("FormatException", FFTAIRobotCommLogType.WARNING);

                return FunctionResult.FORMAT_EXCEPTION;
            }

            try
            {
                TcpConnectServerEndPoint  = new IPEndPoint (TcpConnectServerIpAddress, TcpConnectServerPort);
            }
            catch (ArgumentOutOfRangeException)
            {
                // log information
                Debugs.Log("ArgumentOutOfRangeException", FFTAIRobotCommLogType.WARNING);

                return FunctionResult.ARGUMENT_OUT_OF_RANGE_EXCEPTION;
            }

            // build tcp model
            if (TcpClient == null)
            {
                ConnectStatus = StatusConnect.CONNECTING;

                TcpClient = new TcpClient();
            }

            // connect client to server
            if (TcpClient.Connected == true)
            {
                ConnectStatus = StatusConnect.CONNECTED;
            }
            else
            {
                try
                {
                    TcpClient.Connect(TcpConnectServerEndPoint);
                }
                catch
                {
                    // log information
                    Debugs.Log("SocketException", FFTAIRobotCommLogType.WARNING);
                    return FunctionResult.FAIL;
                }
                ConnectStatus = StatusConnect.CONNECTED;
            }

            return FunctionResult.SUCCESS;
        }

        /// @brief Tcp client disconnect to the server [TCP 客户端断开连接到服务器]
        public int TcpDisconnectClientToServer()
        {
            // in case of TcpClient is null itself
            if (TcpClient == null)
            {
                return FunctionResult.SUCCESS;
            }

            if (TcpClient.Connected == true)
            {
                ConnectStatus = StatusConnect.DISCONNECTING;
                TcpClient.Close();
                ConnectStatus = StatusConnect.DISCONNECTED;
            }
            else
            {
                ConnectStatus = StatusConnect.DISCONNECTED;
            }

            TcpClient = null;
            
            return FunctionResult.SUCCESS;
        }

        /// <summary>
        /// Tcp是否连接
        /// </summary>
        /// <returns></returns>
        public bool TcpConnectStatus()
        {
            if (TcpClient == null)
            {
                return false;
            }

            if (TcpClient.Connected == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// @brief Tcp client send message to the server [TCP 客户端发送数据到服务器]
        public int TcpConnectClientSendMessage(TcpOperationMessageModel tcpOperationMessageModel)
        {
            // in case of the connect state is building
            if (ConnectStatus == StatusConnect.CONNECTING)
            {
                return FunctionResult.SUCCESS;
            }

            // in case of TcpClient is null itself
            if (TcpClient == null)
            {
                return FunctionResult.FAIL;
            }

            try
            {
                if (TcpClient.Client.Connected)
                {
                    TcpClient.Client.Send(tcpOperationMessageModel.message, tcpOperationMessageModel.messageLength, SocketFlags.None);
                }
                //string aa = null;
                //for (int i = 0; i < tcpOperationMessageModel.messageLength; i++)
                //{
                //    aa += "    " + tcpOperationMessageModel.message[i];
                //}
                //messageAmount += tcpOperationMessageModel.messageLength;
            }
            catch (ArgumentNullException)
            {
                // log information
                Debugs.Log("ArgumentNullException", FFTAIRobotCommLogType.WARNING);

                return FunctionResult.ARGUMENT_NULL_EXCEPTION;
            }
            catch (SocketException)
            {
                // log information
                Debugs.Log("SocketException", FFTAIRobotCommLogType.WARNING);

                return FunctionResult.SOCKET_EXCEPTION;
            }
            catch (ObjectDisposedException)
            {
                // log information
                Debugs.Log("ObjectDisposedException", FFTAIRobotCommLogType.WARNING);

                return FunctionResult.OBJECT_DISPOSE_EXCEPTION;
            }

            return FunctionResult.SUCCESS;
        }

        /// @brief Tcp client receive message from the server [TCP 客户端从服务器接收数据]
        public int TcpConnectClientReceiveMessage(ref TcpOperationMessageModel tcpOperationMessageModel)
        {
            // in case of the connect state is building
            if (ConnectStatus == StatusConnect.CONNECTING)
            {
                tcpOperationMessageModel.messageLength = 0;
                tcpOperationMessageModel.message[0] = 0;
                return FunctionResult.SUCCESS;
            }

            // in case of TcpClient is null itself
            if (TcpClient == null)
            {
                return FunctionResult.FAIL;
            }

            try
            {
                // Receive() function is a blocking process.
                // the thread run this method will wait here, until next message received by hardware.
                
                if(TcpClient.Client.Connected)
                {
                    tcpOperationMessageModel.messageLength = TcpClient.Client.Receive(tcpOperationMessageModel.message);
                }
                //string aa = null;
                //for (int i = 0; i < tcpOperationMessageModel.messageLength; i++)
                //{
                //    aa += "   " + tcpOperationMessageModel.message[i].ToString("x");
                //}
                //UnityEngine.Debug.Log(aa);
            }
            catch (ArgumentNullException)
            {
                // log information
                Debugs.Log("ArgumentNullException", FFTAIRobotCommLogType.WARNING);

                return FunctionResult.ARGUMENT_NULL_EXCEPTION;
            }
            catch (SocketException)
            {
                // log information
                Debugs.Log("SocketException", FFTAIRobotCommLogType.WARNING);
                return FunctionResult.SOCKET_EXCEPTION;
            }
            catch (ThreadAbortException)
            {
                Debugs.Log("ThreadAbortException", FFTAIRobotCommLogType.WARNING);
                return FunctionResult.SOCKET_EXCEPTION;
            }
            catch (ObjectDisposedException)
            {
                // log information
                Debugs.Log("ObjectDisposedException", FFTAIRobotCommLogType.WARNING);

                return FunctionResult.OBJECT_DISPOSE_EXCEPTION;
            }
            catch (SecurityException)
            {
                // log information
                Debugs.Log("SecurityException", FFTAIRobotCommLogType.WARNING);

                return FunctionResult.SECURITY_EXCEPTION;
            }

            return FunctionResult.SUCCESS;
        }

        //-------------------------------------------- TCP Functions --------------------------------------------
        
    }
}

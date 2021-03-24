using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationNetworkOperation: IFFTAICommunicationNetworkOperationConnectionStatusObserver
    {
        private TcpOperation TcpOperation;
        
        private string MMUIpAddress;
        private int MMUPort;
        private int MMUConnectionType;
        private int MMUConnectStatus;

        private TcpOperationMessageModel TcpOperationReceiveMessageModel = new TcpOperationMessageModel();
        private TcpOperationMessageModel TcpOperationSendMessageModel = new TcpOperationMessageModel();

        //-------------------------------------------- Receive and Sned Message Handler Interface ---------------------------------------------

        private Thread FFTAICommunicationReceiveListenerThread;
		private static bool FFTAICommunicationReceiveListenerThreadActiveFlag;

        private Thread FFTAICommunicationSendListenerThread;
		private static bool FFTAICommunicationSendListenerThreadActiveFlag;

        //-------------------------------------------- Receive and Sned Message Handler Interface ---------------------------------------------

        //-------------------------------------------- Event Observer -------------------------------------------------------------------------

        private List<IFFTAICommunicationNetworkOperationObserver> Observers;
        private List<IFFTAICommunicationNetworkOperationConnectionStatusObserver> ConnectionStatusObservers;

        //-------------------------------------------- Event Observer -------------------------------------------------------------------------

        /// <summary>
        /// FFTAICommunicationOperation Init
        /// </summary>
        public FFTAICommunicationNetworkOperation()
        {
            TcpOperation = new TcpOperation();
            
            MMUConnectStatus = StatusConnect.DISCONNECTED;

            Observers = new List<IFFTAICommunicationNetworkOperationObserver>();
            ConnectionStatusObservers = new List<IFFTAICommunicationNetworkOperationConnectionStatusObserver>();
        }

        //-------------------------------------------- Connection Functions -------------------------------------------------------------------

        /// <summary>
        /// Connect to MMU
        /// </summary>
        /// <param name="mmuIpAddress"></param>
        /// <param name="mmuPort"></param>
        /// <param name="connectionType"></param>
        /// <returns></returns>
        public int Connect(
            string mmuIpAddress, 
            int mmuPort,
            int connectionType)
        {
            MMUIpAddress = mmuIpAddress;
            MMUPort = mmuPort;
            MMUConnectionType = connectionType;

            if (MMUConnectStatus == StatusConnect.DISCONNECTED)
            {
                switch (MMUConnectionType)
                {
                   
                    case NetworkConnectionType.TCP:
                        if (TcpOperation.TcpConnectClientToServer(MMUIpAddress, MMUPort) == FunctionResult.SUCCESS)
                        {
                           
                        }
                        else
                        {
                            return FunctionResult.FAIL;
                        }
                        break;
                    default:
                        return FunctionResult.FAIL;
                }
                
                // Note : MMUConnectStatus change must before create FFTAICommunicationReceiveListenerThread !!!
                MMUConnectStatus = StatusConnect.CONNECTED;
                
                // build children thread to handler data receive listening
                if (FFTAICommunicationReceiveListenerThread == null)
                {

                }
                else
                {
                    FFTAICommunicationReceiveListenerThread = null;
                }

                FFTAICommunicationReceiveListenerThread = new Thread(ReceiveListenerThreadFunction);
                FFTAICommunicationReceiveListenerThreadActiveFlag = true;
                FFTAICommunicationReceiveListenerThread.Start();
            }
            else
            {
                ObserverNotifyConnect();

                return FunctionResult.NETWORK_ALREADY_CONNECTED;
            }

            ObserverNotifyConnect();

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        /// Disconnect From MMU
        /// </summary>
        /// <returns></returns>
        public int Disconnect()
        {
            int functionResult;
            if (MMUConnectStatus == StatusConnect.CONNECTED)  // MMUConnectStatus == StatusConnect.DISCONNECTED
            {
                switch (MMUConnectionType)
                {
                    case NetworkConnectionType.TCP:
                        functionResult = TcpOperation.TcpDisconnectClientToServer();
                        if (functionResult == FunctionResult.SUCCESS)
                        {

                        }
                        else
                        {
                            return FunctionResult.FAIL;
                        }
                        break;
                    default:
                        return FunctionResult.FAIL;
                }
                FFTAICommunicationReceiveListenerThreadActiveFlag = false;
                // abort children thread handling data receive listening
                if (FFTAICommunicationReceiveListenerThread.ThreadState == ThreadState.Running)
                {
                    FFTAICommunicationReceiveListenerThread.Abort();
                    int maxWaitTime = 100;
                    int waitTime = 0;

                    while (FFTAICommunicationReceiveListenerThread.ThreadState != ThreadState.Aborted)
                    {
                        Thread.Sleep(10);

                        waitTime = waitTime + 10;
                        if (waitTime >= maxWaitTime)
                        {
                            break;
                        }
                    }

                    FFTAICommunicationReceiveListenerThread = null;
                }

                MMUConnectStatus = StatusConnect.DISCONNECTED;
            }
            else if (MMUConnectStatus == StatusConnect.DISCONNECTED)
            {
                switch (MMUConnectionType)
                {
                    case NetworkConnectionType.TCP:
                        functionResult = TcpOperation.TcpDisconnectClientToServer();
                        if (functionResult == FunctionResult.SUCCESS)
                        {

                        }
                        else
                        {
                            return FunctionResult.FAIL;
                        }
                        break;
                    default:
                        return FunctionResult.FAIL;
                }
                MMUConnectStatus = StatusConnect.DISCONNECTED;
            }
            else
            {
                ObserverNotifyDisconnect();

                return FunctionResult.NETWORK_ALREADY_DISCONNECTED;
            }

            ObserverNotifyDisconnect();
            
            return FunctionResult.SUCCESS;
        }

        /// <summary>
        /// Receive Message Listener
        /// </summary>
        public void ReceiveListenerThreadFunction()
        {
            while (FFTAICommunicationReceiveListenerThreadActiveFlag)
            {
                int functionResult = ReceiveMessage();
                if (functionResult == FunctionResult.SUCCESS)
                {
                    try
                    {
                        ReceiveMessageHandler();
                    }
                    catch(Exception exception)
                    {
                        Debugs.Log("ReceiveMessageHandler() catch an exception : " + exception, FFTAIRobotCommLogType.WARNING);
                    }
                }
                else if (functionResult == FunctionResult.NO_DATA)
                {
                    // zero data received, continue
                    continue;
                }
                else
                {
                    break;
                }
            }
            // abort the thread itself
            Thread.CurrentThread.Abort();
        }

        /// <summary>
        /// Receive Message Handler
        /// </summary>
        /// <param name="message"></param>
        /// <param name="messageLength"></param>
        /// <returns></returns>
        public int ReceiveMessageHandler()
        {
            ObserverNotifyReceiveMessage(TcpOperationReceiveMessageModel.message, TcpOperationReceiveMessageModel.messageLength);

            return FunctionResult.SUCCESS;
        }

        //-------------------------------------------- Connection Functions -------------------------------------------------------------------

        //-------------------------------------------- Data Operation Functions ---------------------------------------------------------------

        /// <summary>
        /// Receive Message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="messageLength"></param>
        /// <returns></returns>
        public int ReceiveMessage()
        {
            int functionResult;

            if (MMUConnectStatus == StatusConnect.CONNECTED)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            switch (MMUConnectionType)
            {
                case NetworkConnectionType.TCP:
                    functionResult = TcpOperation.TcpConnectClientReceiveMessage(ref TcpOperationReceiveMessageModel);

                    if (functionResult == FunctionResult.SUCCESS)
                    {
                    }
                    else if (functionResult == FunctionResult.SOCKET_EXCEPTION)
                    {
                        Disconnect();

                        return FunctionResult.FAIL;
                    }
                    else
                    {
                        return FunctionResult.FAIL;
                    }
                    break;
                default:
                    {
                        ObserverNotifyDisconnect();

                        return FunctionResult.FAIL;
                    }
            }

            if (TcpOperationReceiveMessageModel.messageLength == 0)
            {
                return FunctionResult.NO_DATA;
            }
            else
            {
                // only receive more than 0 byte. return success.
                return FunctionResult.SUCCESS;
            }
        }

        /// <summary>
        /// Send Message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="messageLength"></param>
        /// <returns></returns>
        public int SendMessage(byte[] message, int  messageLength)
        {
            int functionResult;

            if (MMUConnectStatus == StatusConnect.CONNECTED)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            TcpOperationSendMessageModel.message = message;
            TcpOperationSendMessageModel.messageLength = messageLength;

            switch (MMUConnectionType)
            {
                case NetworkConnectionType.TCP:
                    functionResult = TcpOperation.TcpConnectClientSendMessage(TcpOperationSendMessageModel);

                    if (functionResult == FunctionResult.SUCCESS)
                    {
                    }
                    else if (functionResult == FunctionResult.SOCKET_EXCEPTION)
                    {
                        Disconnect();

                        return FunctionResult.SOCKET_EXCEPTION;
                    }
                    else
                    {
                        return FunctionResult.FAIL;
                    }
                    break;
                default:
                    {
                        ObserverNotifyDisconnect();

                        return FunctionResult.FAIL;
                    }
            }

            return FunctionResult.SUCCESS;
        }

        //-------------------------------------------- Data Operation Functions ---------------------------------------------------------------

        //-------------------------------------------- Observer Notification Function ---------------------------------------------------------
        
        public int AddObserver(IFFTAICommunicationNetworkOperationObserver observer)
        {
            if (Observers.Contains(observer) == true)
            {
                return FunctionResult.SUCCESS;
            }

            Observers.Add(observer);

            return FunctionResult.SUCCESS;
        }
        
        public int RemoveObserver(IFFTAICommunicationNetworkOperationObserver observer)
        {
            if (Observers.Contains(observer) == true)
            {
                Observers.Remove(observer);
            }

            return FunctionResult.SUCCESS;
        }
        
        public int ObserverNotifyReceiveMessage(byte[] message, int  messageLength)
        {
            for (int  i = 0; i < Observers.Count; i++)
            {
                Observers[i].ReceiveMessageHandle(message, messageLength);
            }

            return FunctionResult.SUCCESS;
        }

        //-------------------------------------------- Observer Notification Function (Connection Status Observer) ----------------------------
        
        public int AddObserver(IFFTAICommunicationNetworkOperationConnectionStatusObserver observer)
        {
            if (ConnectionStatusObservers.Contains(observer) == true)
            {
                return FunctionResult.SUCCESS;
            }
            
            ConnectionStatusObservers.Add(observer);

            return FunctionResult.SUCCESS;
        }
        
        public int RemoveObserver(IFFTAICommunicationNetworkOperationConnectionStatusObserver observer)
        {
            if (ConnectionStatusObservers.Contains(observer) == true)
            {
                ConnectionStatusObservers.Remove(observer);
            }

            return FunctionResult.SUCCESS;
        }

        public int ObserverNotifyConnect()
        {
            for (int  i = 0; i < ConnectionStatusObservers.Count; i++)
            {
                ConnectionStatusObservers[i].ConnectedHandle();
            }

            return FunctionResult.SUCCESS;
        }

        public int ObserverNotifyDisconnect()
        {
            for (int  i = 0; i < ConnectionStatusObservers.Count; i++)
            {
                ConnectionStatusObservers[i].DisconnectedHandle();
            }

            return FunctionResult.SUCCESS;
        }

        public int ConnectedHandle()
        {
            DynaLinkHS.StatusFlag.FlagServerLinkActive = 0x01;

            return FunctionResult.SUCCESS;
        }

        public int DisconnectedHandle()
        {
            DynaLinkHS.StatusFlag.FlagServerLinkActive = 0x00;

            return FunctionResult.SUCCESS;
        }

        //-------------------------------------------- Observer Notification Function (Connection Status Observer) ----------------------------

        //-------------------------------------------- Observer Notification Function ---------------------------------------------------------

    }
}

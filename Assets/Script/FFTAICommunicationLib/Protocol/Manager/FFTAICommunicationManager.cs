using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTAICommunicationLib
{
    public sealed class FFTAICommunicationManager
    {
        // socket
        public FFTAICommunicationNetworkOperation networkOperation;

        //model
        public FFTAICommunicationInterfaceModel interfaceModel;

        // interface
        //public FFTAICommunicationSendAndReceive FFTAICommunicationInterface;

        // communication interface
        public FFTAICommunicationInterfaceManager interfaceManager;

        public FFTAICommunicationIAPInterface iapInterface;

        public FFTAICommunicationAPPInterface appInterface;
        public FFTAICommunicationCommunicationInterface communicationInterface;
        public FFTAICommunicationHardwareInterface hardwareInterface;
        public FFTAICommunicationRobotInterface robotInterface;

        public FFTAICommunicationH4RobotInterface H4RobotInterface;
        public FFTAICommunicationH4TaskInterface H4TaskInterface;

        public FFTAICommunicationM1RobotInterface M1RobotInterface;
        public FFTAICommunicationM1TaskInterface M1TaskInterface;

        public FFTAICommunicationM1_LRobotInterface M1_LRobotInterface;
        public FFTAICommunicationM1_LTaskInterface M1_LTaskInterface;

        public FFTAICommunicationM2RobotInterface M2RobotInterface;
        public FFTAICommunicationM2TaskInterface M2TaskInterface;

        public FFTAICommunicationM3RobotInterface M3RobotInterface;
        public FFTAICommunicationM3TaskInterface M3TaskInterface;

        public FFTAICommunicationM6RobotInterface M6RobotInterface;
        public FFTAICommunicationM6TaskInterface M6TaskInterface;

        public FFTAICommunicationX1RobotInterface X1RobotInterface;
        public FFTAICommunicationX1TaskInterface X1TaskInterface;

        public FFTAICommunicationX2RobotInterface X2RobotInterface;
        public FFTAICommunicationX2TaskInterface X2TaskInterface;

        

        //-------------------------------------------- Variables Definition ------------------------------------------------

        //-------------------------------------------- Singleton -----------------------------------------------------------

        private static FFTAICommunicationManager instance;

        public static FFTAICommunicationManager getInstance()
        {
            if (instance==null)
            {
                instance = new FFTAICommunicationManager();
            }   
            return instance;
        }

        private FFTAICommunicationManager()
        {
            // create object
            networkOperation = new FFTAICommunicationNetworkOperation();

            interfaceModel = new FFTAICommunicationInterfaceModel();
            //FFTAICommunicationInterface = new FFTAICommunicationSendAndReceive();

            interfaceManager = new FFTAICommunicationInterfaceManager();

            iapInterface = new FFTAICommunicationIAPInterface();

            appInterface = new FFTAICommunicationAPPInterface();
            communicationInterface = new FFTAICommunicationCommunicationInterface();
            hardwareInterface = new FFTAICommunicationHardwareInterface();
            robotInterface = new FFTAICommunicationRobotInterface();

            H4RobotInterface = new FFTAICommunicationH4RobotInterface();
            H4TaskInterface = new FFTAICommunicationH4TaskInterface();

            M1RobotInterface = new FFTAICommunicationM1RobotInterface();
            M1TaskInterface = new FFTAICommunicationM1TaskInterface();

            M1_LRobotInterface = new FFTAICommunicationM1_LRobotInterface();
            M1_LTaskInterface = new FFTAICommunicationM1_LTaskInterface();

            M2RobotInterface = new FFTAICommunicationM2RobotInterface();
            M2TaskInterface = new FFTAICommunicationM2TaskInterface();

            M3RobotInterface = new FFTAICommunicationM3RobotInterface();
            M3TaskInterface = new FFTAICommunicationM3TaskInterface();

            M6RobotInterface = new FFTAICommunicationM6RobotInterface();
            M6TaskInterface = new FFTAICommunicationM6TaskInterface();

            X1RobotInterface = new FFTAICommunicationX1RobotInterface();
            X1TaskInterface = new FFTAICommunicationX1TaskInterface();

            X2RobotInterface = new FFTAICommunicationX2RobotInterface();
            X2TaskInterface = new FFTAICommunicationX2TaskInterface();

            // build relationship
            networkOperation.AddObserver(interfaceManager);

            //FFTAICommunicationInterface.FFTAICommunicationNetworkOperation = networkOperation;
            //FFTAICommunicationInterface.interfaceManager = interfaceManager;

            //// v2 interface
            //interfaceManager.FFTAICommunicationSendAndReceive = FFTAICommunicationInterface;

            // children interface
            iapInterface.interfaceManager = interfaceManager;

            appInterface.interfaceManager = interfaceManager;
            communicationInterface.interfaceManager = interfaceManager;
            hardwareInterface.interfaceManager = interfaceManager;
            robotInterface.interfaceManager = interfaceManager;

            H4RobotInterface.interfaceManager = interfaceManager;
            H4TaskInterface.interfaceManager = interfaceManager;

            M1RobotInterface.interfaceManager = interfaceManager;
            M1TaskInterface.interfaceManager = interfaceManager;

            M1_LRobotInterface.interfaceManager = interfaceManager;
            M1_LTaskInterface.interfaceManager = interfaceManager;

            M2RobotInterface.interfaceManager = interfaceManager;
            M2TaskInterface.interfaceManager = interfaceManager;

            M3RobotInterface.interfaceManager = interfaceManager;
            M3TaskInterface.interfaceManager = interfaceManager;

            M6RobotInterface.interfaceManager = interfaceManager;
            M6TaskInterface.interfaceManager = interfaceManager;

            X1RobotInterface.interfaceManager = interfaceManager;
            X1TaskInterface.interfaceManager = interfaceManager;

            X2RobotInterface.interfaceManager = interfaceManager;
            X2TaskInterface.interfaceManager = interfaceManager;
        }
    }
}



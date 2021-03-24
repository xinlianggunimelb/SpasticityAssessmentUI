using System.Collections;
using System.Collections.Generic;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationInterfaceBasic
    {
        public FFTAICommunicationInterfaceModelBasic Model;

        public static List<IFFTAICommunicationInterfaceObserver> Observers = new List<IFFTAICommunicationInterfaceObserver>();

        public FFTAICommunicationInterfaceManager interfaceManager;

        public long currentFunctionType;

        public FFTAICommunicationInterfaceBasic()
        {
            Model = new FFTAICommunicationInterfaceModelBasic();
        }

    /// <summary>
    /// receive data and update buffer data
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="bufferLength"></param>
    /// <returns></returns>
    public virtual int Receive(byte[] buffer, int bufferLength)
        {
            if (Model.DataSectionModel.ResponseModel.Update(buffer, bufferLength) == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }

            //get current function type
            //if v2 
            if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_2)
            {
                currentFunctionType =FFTAICommunicationManager.getInstance().interfaceManager.Model.ResponseModel.FunctionType;
            }
            //if v3
            else if ((FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_3))
            {
                currentFunctionType = Model.DataSectionModel.ResponseModel.FunctionType;
            }
            else
            {
                currentFunctionType = FFTAICommunicationManager.getInstance().interfaceManager.Model.ResponseModel.FunctionType;
            }
           

            if (Update() == FunctionResult.SUCCESS)
            {

            }
            else
            {
                return FunctionResult.FAIL;
            }
            return FunctionResult.SUCCESS;
        }

        /// <summary>
        ///  update model info 
        /// </summary>
        /// <returns></returns>
        public virtual int Update()
        {
            ObserverNotifyModelUpdate();

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int ObserverNotifyModelUpdate()
        {

            for (int i = 0; i < Observers.Count; i++)
            {
                if (currentFunctionType== Observers[i].GetFunctionType())
                {
                    Observers[i].ModelUpdateHandle(Model);
                }
            }
            return FunctionResult.SUCCESS;
        }

        /// <summary>
        /// add event observer
        /// </summary>
        /// <param name="observer"></param>
        /// <returns></returns>
        public virtual int AddObserver(IFFTAICommunicationInterfaceObserver observer)
        {
            if (Observers.Contains(observer) == true)
            {
                return FunctionResult.SUCCESS;
            }

            Observers.Add(observer);

            return FunctionResult.SUCCESS;
        }

        /// <summary>
        /// remove event observer
        /// </summary>
        /// <param name="observer"></param>
        /// <returns></returns>
        public virtual int RemoveObserver(IFFTAICommunicationInterfaceObserver observer)
        {
            if (Observers.Contains(observer) == true)
            {
                Observers.Remove(observer);
            }

            return FunctionResult.SUCCESS;
        }
    }
}
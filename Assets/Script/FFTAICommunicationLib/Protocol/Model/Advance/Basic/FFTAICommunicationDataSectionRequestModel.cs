using System.Collections;
using System.Collections.Generic;

public class FFTAICommunicationDataSectionRequestModel
{
    // whole message buffer
    public byte[] MessageBuf;
    public uint MessageBufLength;
    public uint MessageBufParity;

    // different part variable
    public uint[] Parameter;

    public virtual int Update(byte[] message, uint messageLength)
    {
        return 0;
    }

    public virtual int Update(
            byte[] operationModeBuf,
            byte[] numberOfParameterBuf,
            byte[] readWriteOperationBuf,
            byte[] parameterTypeBuf,
            byte[] parameterBuf)
    {
        return 0;
    }

    public virtual int Update(
            uint operationMode,
            uint numberOfParameter,
            uint readWriteOperation,
            uint parameterType,
            uint[] parameter)
    {
        return 0;
    }
}

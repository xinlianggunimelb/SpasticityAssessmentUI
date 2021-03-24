using FFTAICommunicationLib;

public class FFTAICommunicationDataSectionResponseModel 
{
    // whole message buffer
    public byte[] MessageBuf;
    public int MessageBufLength;
    public int MessageBufParity;

    // different part variable
    public long FunctionType;
    public long OperationMode;

    private long readWirteOperation;

    public long OperationResult;
    public int[] Parameter;
    public long ReadWriteOperation 
    {
        get
        {
            if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion==FFTAICommunicationProtocolVersion.VERSION_2)
            {
                if (readWirteOperation == 0x10 )
                {
                    readWirteOperation = 1;
                }
                else if (readWirteOperation == 0x11 )
                {
                    readWirteOperation = 2;
                }
                else if (readWirteOperation == 0x00 )
                {
                    readWirteOperation = 3;
                }
                else if (readWirteOperation == 0x01 )
                {
                    readWirteOperation = 4;
                }
            }
            return readWirteOperation;
        }
        set 
        {
            readWirteOperation = value;
        }
    }

    public virtual int Update(byte[] message, int messageLength)
    {
        return 0;
    }

    public int GetFunctionType()
    {

        return 0;
    }

}

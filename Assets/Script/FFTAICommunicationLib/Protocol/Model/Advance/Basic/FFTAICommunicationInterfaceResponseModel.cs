using System.Collections;
using System.Collections.Generic;

public class FFTAICommunicationInterfaceResponseModel 
{
    // whole message buffer
    public byte[] MessageBuf;
    public int MessageBufLength;

    // different part buffer
    public byte[] FunctionTypeBuf;
    public byte[] DataSectionBuf;              // the field of data section
    public byte[] DataSectionLengthBuf;        // the field of data section length
    public byte[] DataSectionParityBuf;
    public byte[] EndOfFrameBuf;
    public byte[] CommunicationProtocolVersionBuf;

    // different part variable
    public long FunctionType;
    public long DataSectionLength;
    public long DataSectionParity;
    public long EndOfFrame;
    public long CommunicationProtocolVersion;

    // whole frame buffer
    public byte[] FrameBuf;
    public int FrameBufLength;
    public int MessageBufChecksum;
}

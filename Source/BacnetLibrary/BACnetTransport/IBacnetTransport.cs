using BacnetLibrary.BACnetBase;
using BacnetLibrary.BACnetBase.BACnetEnum;
using System;

namespace BacnetLibrary.BACnetTransport
{
    public delegate void MessageRecievedHandler(IBacnetTransport sender, byte[] buffer, int offset, int msg_length, BacnetAddress remote_address);

    public interface IBacnetTransport : IDisposable
    {
        event MessageRecievedHandler MessageRecieved;
        int Send(byte[] buffer, int offset, int data_length, BacnetAddress address, bool wait_for_transmission, int timeout);
        BacnetAddress GetBroadcastAddress();
        BacnetAddressTypes Type { get; }
        void Start();

        int HeaderLength { get; }
        int MaxBufferLength { get; }
        BacnetMaxApdu MaxAdpuLength { get; }

        bool WaitForAllTransmits(int timeout);
        byte MaxInfoFrames { get; set; }
    }

    public interface IBacnetSerialTransport : IDisposable
    {
        void Open();
        void Write(byte[] buffer, int offset, int length);
        int Read(byte[] buffer, int offset, int length, int timeout_ms);
        void Close();
        int BytesToRead { get; }
    }
}

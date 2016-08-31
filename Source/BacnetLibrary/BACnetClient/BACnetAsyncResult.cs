using System;
using System.Threading;
using BacnetLibrary.BACnetBase;
using BacnetLibrary.BACnetBase.BACnetEnum;

namespace BacnetLibrary.BACnetClient
{
    public class BacnetAsyncResult : IAsyncResult, IDisposable
    {
        private BacnetClient m_comm;
        private BacnetAddress m_adr;
        private byte m_wait_invoke_id;
        private Exception m_error;
        private byte[] m_result;
        private byte[] m_transmit_buffer;
        private int m_transmit_length;
        private bool m_wait_for_transmit;
        private int m_transmit_timeout;

        public byte[] Result { get { return m_result; } }
        public Exception Error
        {
            get { return m_error; }
            set
            {
                m_error = value;
                CompletedSynchronously = true;
                ((System.Threading.ManualResetEvent)AsyncWaitHandle).Set();
            }
        }
        public bool Segmented { get; private set; }

        public object AsyncState { get; set; }
        public WaitHandle AsyncWaitHandle { get; private set; }
        public bool CompletedSynchronously { get; private set; }
        public bool IsCompleted { get { return AsyncWaitHandle.WaitOne(0); } }

        public BacnetAsyncResult(BacnetClient comm, BacnetAddress adr, byte invoke_id, byte[] transmit_buffer, int transmit_length, bool wait_for_transmit, int transmit_timeout)
        {
            m_transmit_timeout = transmit_timeout;
            m_adr = adr;
            m_wait_for_transmit = wait_for_transmit;
            m_transmit_buffer = transmit_buffer;
            m_transmit_length = transmit_length;
            AsyncWaitHandle = new System.Threading.ManualResetEvent(false);
            m_comm = comm;
            m_wait_invoke_id = invoke_id;
            m_comm.OnComplexAck += new BacnetClient.ComplexAckHandler(m_comm_OnComplexAck);
            m_comm.OnError += new BacnetClient.ErrorHandler(m_comm_OnError);
            m_comm.OnAbort += new BacnetClient.AbortHandler(m_comm_OnAbort);
            m_comm.OnSimpleAck += new BacnetClient.SimpleAckHandler(m_comm_OnSimpleAck);
            m_comm.OnSegment += new BacnetClient.SegmentHandler(m_comm_OnSegment);
        }

        public void Resend()
        {
            try
            {
                if (m_comm.Transport.Send(m_transmit_buffer, m_comm.Transport.HeaderLength, m_transmit_length, m_adr, m_wait_for_transmit, m_transmit_timeout) < 0)
                {
                    Error = new System.IO.IOException("Write Timeout");
                }
            }
            catch (Exception ex)
            {
                Error = new Exception("Write Exception: " + ex.Message);
            }
        }

        private void m_comm_OnSegment(BacnetClient sender, BacnetAddress adr, BacnetPduTypes type, BacnetConfirmedServices service, byte invoke_id, BacnetMaxSegments max_segments, BacnetMaxApdu max_adpu, byte sequence_number, bool first, bool more_follows, byte[] buffer, int offset, int length)
        {
            if (invoke_id == m_wait_invoke_id)
            {
                Segmented = true;
                ((System.Threading.ManualResetEvent)AsyncWaitHandle).Set();
            }
        }

        private void m_comm_OnSimpleAck(BacnetClient sender, BacnetAddress adr, BacnetPduTypes type, BacnetConfirmedServices service, byte invoke_id, byte[] data, int data_offset, int data_length)
        {
            if (invoke_id == m_wait_invoke_id)
            {
                ((System.Threading.ManualResetEvent)AsyncWaitHandle).Set();
            }
        }

        private void m_comm_OnAbort(BacnetClient sender, BacnetAddress adr, BacnetPduTypes type, byte invoke_id, byte reason, byte[] buffer, int offset, int length)
        {
            if (invoke_id == m_wait_invoke_id)
            {
                Error = new Exception("Abort from device: " + reason);
            }
        }

        private void m_comm_OnError(BacnetClient sender, BacnetAddress adr, BacnetPduTypes type, BacnetConfirmedServices service, byte invoke_id, BacnetErrorClasses error_class, BacnetErrorCodes error_code, byte[] buffer, int offset, int length)
        {
            if (invoke_id == m_wait_invoke_id)
            {
                Error = new Exception("Error from device: " + error_class + " - " + error_code);
            }
        }

        private void m_comm_OnComplexAck(BacnetClient sender, BacnetAddress adr, BacnetPduTypes type, BacnetConfirmedServices service, byte invoke_id, byte[] buffer, int offset, int length)
        {
            if (invoke_id == m_wait_invoke_id)
            {
                Segmented = false;
                m_result = new byte[length];
                if (length > 0) Array.Copy(buffer, offset, m_result, 0, length);
                ((System.Threading.ManualResetEvent)AsyncWaitHandle).Set();     //notify waiter even if segmented
            }
        }

        /// <summary>
        /// Will continue waiting until all segments are recieved
        /// </summary>
        public bool WaitForDone(int timeout)
        {
            while (true)
            {
                if (!AsyncWaitHandle.WaitOne(timeout))
                    return false;
                if (Segmented)
                    ((System.Threading.ManualResetEvent)AsyncWaitHandle).Reset();
                else
                    return true;
            }
        }

        public void Dispose()
        {
            if (m_comm == null) return;
            m_comm.OnComplexAck -= m_comm_OnComplexAck;
            m_comm.OnError -= m_comm_OnError;
            m_comm.OnAbort -= m_comm_OnAbort;
            m_comm.OnSimpleAck -= m_comm_OnSimpleAck;
            m_comm.OnSegment -= m_comm_OnSegment;
            m_comm = null;
        }
    }
}

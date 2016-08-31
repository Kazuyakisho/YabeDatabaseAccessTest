using System;
using System.IO.Ports;

namespace BacnetLibrary.BACnetTransport
{
    public class BacnetSerialPortTransport : IBacnetSerialTransport
    {
        private string m_port_name;
        private int m_baud_rate;
        private SerialPort m_port;

        public BacnetSerialPortTransport(string port_name, int baud_rate)
        {
            m_port_name = port_name;
            m_baud_rate = baud_rate;
            m_port = new SerialPort(m_port_name, m_baud_rate, Parity.None, 8, StopBits.One);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is BacnetSerialPortTransport)) return false;
            BacnetSerialPortTransport a = (BacnetSerialPortTransport)obj;
            return m_port_name.Equals(a.m_port_name);
        }

        public override int GetHashCode()
        {
            return m_port_name.GetHashCode();
        }

        public override string ToString()
        {
            return m_port_name;
        }

        public void Open()
        {
            m_port.Open();
        }

        public void Write(byte[] buffer, int offset, int length)
        {
            m_port?.Write(buffer, offset, length);
        }

        public int Read(byte[] buffer, int offset, int length, int timeout_ms)
        {
            if (m_port == null) return 0;
            m_port.ReadTimeout = timeout_ms;
            try
            {
                int rx = m_port.Read(buffer, offset, length);
                return rx;
            }
            catch (TimeoutException)
            {
                return -BacnetMstpProtocolTransport.ETIMEDOUT;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public void Close()
        {
            m_port?.Close();
        }

        public int BytesToRead => m_port?.BytesToRead ?? 0;

        public void Dispose()
        {
            Close();
        }
    }
}

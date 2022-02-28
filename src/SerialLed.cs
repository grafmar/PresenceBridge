using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace PresenceBridge
{
	class SerialLed
	{
		SerialPort _serialPort = new SerialPort();

		public SerialLed()
		{
			_serialPort.BaudRate	= 115200;
			_serialPort.Parity		= Parity.None;
			_serialPort.DataBits	= 8;
			_serialPort.StopBits	= StopBits.One;
		}

		private void openPort()
		{
			try
			{
				if (_serialPort.PortName != Properties.Settings.Default.SerialPort)
				{
					if (_serialPort.IsOpen)
					{
						_serialPort.Close(); // Close old opened port
					}
					_serialPort.PortName = Properties.Settings.Default.SerialPort; // Set new port
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error closing serial port :: " + ex.Message, "Error!");
			}

			try
			{
				if (!_serialPort.IsOpen)
				{
					_serialPort.Open(); // Open serial port
				}
			}
			catch (Exception ex)
			{
				//MessageBox.Show("Error opening serial port :: " + ex.Message, "Error!");
			}
		}

		public void Close()
		{
			try
			{
				if (_serialPort.IsOpen)
				{
					_serialPort.Close();
				}
			}
			catch (Exception ex) { }
		}

		public void setLedColor(Color color)
		{
			openPort();
			if (_serialPort.IsOpen)
			{
				try
				{
					_serialPort.Write("rgb:" + color.R + "," + color.G + "," + color.B + "\r\n");
				}
				catch (Exception ex)
				{
					MessageBox.Show("Could not send message on open serial port :: " + ex.Message, "Error!");
				}
			}
		}
	}
}

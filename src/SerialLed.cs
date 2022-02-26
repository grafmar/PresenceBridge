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
		private static string usedPort = "";
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
			_serialPort.PortName = Properties.Settings.Default.SerialPort;
		}

		public void setLedColor(Color color)
		{
			_serialPort.PortName = Properties.Settings.Default.SerialPort;
			try
			{
				_serialPort.Open();


				_serialPort.Write("rgb:" + color.R + "," + color.G + "," + color.B + "\r\n");
				_serialPort.Close();
			}
			catch (Exception ex)
			{
				//MessageBox.Show("Error opening/writing to serial port :: " + ex.Message, "Error!");
			}
			//if ((comboBox1.SelectedItem != null) && (comboBox1.SelectedItem.ToString() != ""))
			//{
			//	SerialPort _serialPort = new SerialPort(comboBox1.SelectedItem.ToString(), 115200, Parity.None, 8, StopBits.One);
			//	_serialPort.Handshake = Handshake.None;
			//	try
			//	{
			//		if (!(_serialPort.IsOpen))
			//		{
			//			_serialPort.Open();


			//			_serialPort.Write("rgb:" + MyDialog.Color.R + "," + MyDialog.Color.G + "," + MyDialog.Color.B + "\r\n");
			//			_serialPort.Close();
			//		}
			//	}
			//	catch (Exception ex)
			//	{
			//		MessageBox.Show("Error opening/writing to serial port :: " + ex.Message, "Error!");
			//	}
			//	updateColorDescriptions();
			//}
		}
	}
}

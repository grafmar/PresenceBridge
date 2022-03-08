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
		private static log4net.ILog log;

		public SerialLed(log4net.ILog logger)
		{
			log = logger;
			_serialPort.BaudRate = 115200;
			_serialPort.Parity = Parity.None;
			_serialPort.DataBits = 8;
			_serialPort.StopBits = StopBits.One;
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
				log.Error("Error closing serial port :" + ex.Message);
				MessageBox.Show("Error closing serial port :" + ex.Message, "Error!");
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
				log.Error("Error opening serial port :" + ex.Message);
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
			catch (Exception ex)
			{
				log.Error(ex.Message);
			}
		}

		private int Clamp(int value, int min, int max)
		{
			return Math.Min(Math.Max(value, min), max);
		}

		public void setLedColor(Color color)
		{
			openPort();
			if (_serialPort.IsOpen)
			{
				try
				{
					var factor = Clamp(Properties.Settings.Default.Brightness, 0, 100) / 100.0;
					var newColor = Color.FromArgb(
						(int)(color.R * factor),
						(int)(color.G * factor),
						(int)(color.B * factor));
					_serialPort.Write("rgb:" + newColor.R + "," + newColor.G + "," + newColor.B + "\r\n");
				}
				catch (Exception ex)
				{
					log.Error("Could not send message on open serial port :" + ex.Message);
				}
			}
		}
	}
}

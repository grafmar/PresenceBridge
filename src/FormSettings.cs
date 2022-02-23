using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using Microsoft.Graph; // NuGet Package
using Azure.Identity;  // NuGet Package


namespace PresenceBridge
{
	public partial class FormSettings : Form
	{
		public FormSettings()
		{
			InitializeComponent();

			// initialize for SystemTrayApp

			this.CenterToScreen();

			// Set application icon and system tray icon
			this.Icon = Properties.Resources.icon_mix_UPh_icon;
			this.SystemTrayIcon.Icon = Properties.Resources.trayicon_512_Olk_icon;

			// Change the Text property to the name of your application
			this.SystemTrayIcon.Text = "PresenceBridge";
			this.SystemTrayIcon.Visible = true;

			// Modify the right-click menu of your system tray icon here
			ContextMenu menu = new ContextMenu();
			menu.MenuItems.Add("Settings", ContextMenuSettings);
			menu.MenuItems.Add("Exit", ContextMenuExit);
			this.SystemTrayIcon.ContextMenu = menu;

			this.Resize += WindowResize;
			this.FormClosing += WindowClosing;

			//updateColorDescriptions();
			applySettings();
			getSerialPorts();
		}

		private void ContextMenuSettings(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
			this.Show();
			this.WindowState = FormWindowState.Normal;
		}

		private void ContextMenuExit(object sender, EventArgs e)
		{
			this.SystemTrayIcon.Visible = false;
			System.Windows.Forms.Application.Exit();
			Environment.Exit(0);
		}

		private void WindowResize(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized)
			{
				this.Hide();
			}
		}

		private void WindowClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			this.Hide();
		}

		private void selectColor(object sender, EventArgs e)
		{
			ColorDialog MyDialog = new ColorDialog();
			MyDialog.AllowFullOpen = true;
			MyDialog.FullOpen = true;
			MyDialog.CustomColors = new int[] { 0x0000FF, 0x00FF00, 0x0064FF, 0x9600FF, 0x330000 };
			MyDialog.Color = (sender as Button).BackColor;

			// Update the text box color if the user clicks OK 
			if (MyDialog.ShowDialog() == DialogResult.OK)
				(sender as Button).BackColor = MyDialog.Color;

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
			saveSettings();

		}

		private void trackBarBrightness_Scroll(object sender, EventArgs e)
		{
			labelBrightness.Text = "Brightness " + trackBarBrightness.Value + "%";
			saveSettings();
		}

		private int Clamp(int value, int min, int max)
		{
			return Math.Min(Math.Max(value, min), max);
		}

		private void applySettings()
		{
			btnAvailable.BackColor		= System.Drawing.ColorTranslator.FromHtml(Properties.Settings.Default.ColorAvailable);
			btnBusy.BackColor			= System.Drawing.ColorTranslator.FromHtml(Properties.Settings.Default.ColorBusy);
			btnAway.BackColor			= System.Drawing.ColorTranslator.FromHtml(Properties.Settings.Default.ColorAway);
			btnDoNotDisturb.BackColor	= System.Drawing.ColorTranslator.FromHtml(Properties.Settings.Default.ColorDoNotDisturb);
			btnOffline.BackColor		= System.Drawing.ColorTranslator.FromHtml(Properties.Settings.Default.ColorOffline);
			trackBarBrightness.Value	= Clamp(Properties.Settings.Default.Brightness, 0, 100);
			labelBrightness.Text		= "Brightness " + trackBarBrightness.Value + "%";
			comboBoxSerialPort.Text		= Properties.Settings.Default.SerialPort;
		}

		private void saveSettings()
		{
			Properties.Settings.Default.ColorAvailable		= System.Drawing.ColorTranslator.ToHtml(btnAvailable.BackColor);
			Properties.Settings.Default.ColorBusy			= System.Drawing.ColorTranslator.ToHtml(btnBusy.BackColor);
			Properties.Settings.Default.ColorAway			= System.Drawing.ColorTranslator.ToHtml(btnAway.BackColor);
			Properties.Settings.Default.ColorDoNotDisturb	= System.Drawing.ColorTranslator.ToHtml(btnDoNotDisturb.BackColor);
			Properties.Settings.Default.ColorOffline		= System.Drawing.ColorTranslator.ToHtml(btnOffline.BackColor);
			Properties.Settings.Default.Brightness			= trackBarBrightness.Value;
			Properties.Settings.Default.SerialPort			= comboBoxSerialPort.Text;
		}

		private void getSerialPorts()
		{
			string[] ports = SerialPort.GetPortNames();
			comboBoxSerialPort.Items.Clear();
			foreach (string s in SerialPort.GetPortNames())
			{
				comboBoxSerialPort.Items.Add(s);
			}
		}
		private void setPresenceColor(Color color)
		{
			// Alter System Tray Icon color
			Bitmap bmp = SystemTrayIcon.Icon.ToBitmap();
			using (Graphics gr = Graphics.FromImage(bmp))
			{
				int size = bmp.Width;
				SolidBrush brush = new SolidBrush(color);
				gr.FillRectangle(brush, 6*size/32, 2*size/32, 19*size/32, 18*size/32);
			}
			IntPtr Hicon = bmp.GetHicon();
			SystemTrayIcon.Icon = Icon.FromHandle(Hicon);

			// Show Color in Profile Photo
			if (pictureBoxFoto.Image != null)
			{
				var Foto = pictureBoxFoto.Image;
				using (Graphics gr = Graphics.FromImage(Foto))
				{
					SolidBrush brush = new SolidBrush(color);
					gr.FillEllipse(brush, pictureBoxFoto.Width - 40, pictureBoxFoto.Height - 40, 40, 40);
				}
				pictureBoxFoto.Image = Foto;
			}
		}

		private void comboBoxSerialPort_SelectedIndexChanged(object sender, EventArgs e)
		{
			saveSettings();
		}

		private void comboBoxSerialPort_Click(object sender, EventArgs e)
		{
			getSerialPorts();
		}

		private void btnReload_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.Reload();
			applySettings();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.Save();
		}


		private void btnLogin_Click(object sender, EventArgs e)
		{
			if (btnLogin.Text == "Logout")
			{
				doLogout();
				btnLogin.Text = "Login";
			}
			else
			{
				doLogin();
				btnLogin.Text = "Logout";
			}
		}

		private async void doLogout()
		{ 
		}

		private async void doLogin()
		{
			var scopes = new[] { "User.Read", "Presence.Read" };
			// multi-tenant apps can use "common",
			// single-tenant apps must use the tenant id from the azure portal
			var tenantId = "common";

			// value from app registration
			//var clientId = Properties.Settings.Default.ClientId;
			var clientId = "3bd2647e-821e-48dd-a4b3-158e87fd7945";

			// using Azure.Identity;
			var options = new InteractiveBrowserCredentialOptions
			{
				TenantId = tenantId,
				ClientId = clientId,
				AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
				// MUST be http://localhost or http://localhost:PORT
				// See https://github.com/AzureAD/microsoft-authentication-library-for-dotnet/wiki/System-Browser-on-.Net-Core
				RedirectUri = new Uri("http://localhost"),
			};

			// https://docs.microsoft.com/dotnet/api/azure.identity.interactivebrowsercredential
			var interactiveCredential = new InteractiveBrowserCredential(options);


			var graphClient = new GraphServiceClient(interactiveCredential, scopes);

			//var user = await graphClient.Me.Request().GetAsync();

			// Get account photo
			System.IO.Stream photo = await graphClient.Me.Photo.Content.Request().GetAsync();
			if (photo != null)
			{
				System.IO.MemoryStream ms = new System.IO.MemoryStream();
				photo.CopyTo(ms);
				Bitmap bmp = new Bitmap(System.Drawing.Image.FromStream(ms), pictureBoxFoto.Size);
				pictureBoxFoto.Image = ClipToCircle(bmp);
			}
			else
			{
				// create image for Profile Photo if none is set
				pictureBoxFoto.Image = new Bitmap(pictureBoxFoto.Width, pictureBoxFoto.Height);
			}

			Presence presence = await graphClient.Me.Presence.Request().GetAsync();
			setPresenceColor(getColorFromPresence(presence));

			//interactiveCredential.Authenticate();

			//interactiveCredential.AuthenticationRecord
			//if (interactiveCredential.Record.Username != null)
			//{

			//}
		}

		private Color getColorFromPresence(Presence presence)
		{
			Color retVal= Color.Black;
			switch (presence.Availability)
			{
				case "Available":
				case "AvailableIdle":
					retVal = System.Drawing.ColorTranslator.FromHtml(Properties.Settings.Default.ColorAvailable);
					break;
				case "Busy":
				case "BusyIdle":
					retVal = System.Drawing.ColorTranslator.FromHtml(Properties.Settings.Default.ColorBusy);
					break;
				case "DoNotDisturb":
					retVal = System.Drawing.ColorTranslator.FromHtml(Properties.Settings.Default.ColorDoNotDisturb);
					break;
				case "Away":
				case "BeRightBack":
					retVal = System.Drawing.ColorTranslator.FromHtml(Properties.Settings.Default.ColorAway);
					break;
				case "Offline":
				case "PresenceUnknown":
				default:
					retVal = System.Drawing.ColorTranslator.FromHtml(Properties.Settings.Default.ColorOffline);
					break;
			}
			return retVal;
		}

		public Bitmap ClipToCircle(Bitmap bm)
		{
			Bitmap bt = new Bitmap(bm.Width, bm.Height);
			Graphics g = Graphics.FromImage(bt);
			GraphicsPath gp = new GraphicsPath();
			gp.AddEllipse(10, 10, bm.Width - 20, bm.Height - 20);
			g.Clear(Color.Magenta);
			g.SetClip(gp);
			g.DrawImage(bm, new
			Rectangle(0, 0, bm.Width, bm.Height), 0, 0, bm.Width, bm.Height, GraphicsUnit.Pixel);
			g.Dispose();
			bt.MakeTransparent(Color.Magenta);
			return bt;
		}
		            
		private void SystemTrayIcon_MouseClick(object sender, MouseEventArgs e)
		{
			ContextMenuSettings(sender, e);
		}
	}
}

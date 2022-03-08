using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using Microsoft.Graph; // NuGet Package
using Microsoft.Identity; // NuGet Package
using Microsoft.Identity.Client;
using Azure.Identity;  // NuGet Package


namespace PresenceBridge
{
	public partial class FormSettings : Form
	{
		private static bool serialPortConfiguredAvailable = false;
		private static SerialLed serialLed = new SerialLed();
		private static GraphHandler graphHandler = new GraphHandler();

		private const string presenceAvailable = "Available";
		private const string presenceAvailableIdle = "AvailableIdle";
		private const string presenceBusy = "Busy";
		private const string presenceBusyIdle = "BusyIdle";
		private const string presenceDoNotDisturb = "DoNotDisturb";
		private const string presenceAway = "Away";
		private const string presenceBeRightBack = "BeRightBack";
		private const string presenceOffline = "Offline";
		private const string presencePresenceUnknown = "PresenceUnknown";


		public FormSettings()
		{
			InitializeComponent();

			// initialize for SystemTrayApp

			this.CenterToScreen();

			// Set application icon and system tray icon
			this.Icon = Properties.Resources.icon_mix_UPh_icon;
			this.SystemTrayIcon.Icon = Properties.Resources.TrayIcon_blue;

			// Change the Text property to the name of your application
			this.SystemTrayIcon.Text = "PresenceBridge";
			this.SystemTrayIcon.Visible = true;

			// Modify the right-click menu of your system tray icon here
			ContextMenu menu = new ContextMenu();
			menu.MenuItems.Add("Available", (sender, e) => ContextMenuSetPresence(sender,e,radioButtonAvailable));
			menu.MenuItems.Add("Busy", (sender, e) => ContextMenuSetPresence(sender,e,radioButtonBusy));
			menu.MenuItems.Add("Away", (sender, e) => ContextMenuSetPresence(sender,e,radioButtonAway));
			menu.MenuItems.Add("DoNotDisturb", (sender, e) => ContextMenuSetPresence(sender,e,radioButtonDoNotDisturb));
			menu.MenuItems.Add("Offline", (sender, e) => ContextMenuSetPresence(sender,e,radioButtonOffline));
			menu.MenuItems.Add("SyncToTeams", (sender, e) => ContextMenuSetPresence(sender,e,radioButtonSyncToTeams));
			menu.MenuItems.Add("-");
			menu.MenuItems.Add("Settings", ContextMenuSettings);
			menu.MenuItems.Add("About", ContextMenuAbout);
			menu.MenuItems.Add("Exit", ContextMenuExit);
			this.SystemTrayIcon.ContextMenu = menu;
			this.ContextMenu = menu;

			this.Resize += WindowResize;
			this.FormClosing += WindowClosing;

			//updateColorDescriptions();
			applySettings();
			getSerialPorts();

			if (!serialPortConfiguredAvailable)
			{
				MessageBox.Show("Configured serial port \"" + Properties.Settings.Default.SerialPort + "\" is not available! Try to configure correct serail port.");
			}

			doLogin();

			// startup only in SystemTray
			this.WindowState = FormWindowState.Minimized;
			this.Close();
		}

		private void ContextMenuSetPresence(object sender, EventArgs e, System.Windows.Forms.RadioButton radioButtonToSet)
		{
			radioButtonToSet.Checked = true;
		}
		
		private void ContextMenuAbout(object sender, EventArgs e)
		{
			AboutWindow aboutWindow = new AboutWindow();
			aboutWindow.Show();
		}

		private void ContextMenuSettings(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
			this.Show();
			this.WindowState = FormWindowState.Normal;
		}

		private void ContextMenuExit(object sender, EventArgs e)
		{
			applyPresenceFromString(presenceOffline);
			serialLed.Close();
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

			copyColorsToSettings();
		}

		private void trackBarBrightness_Scroll(object sender, EventArgs e)
		{
			labelBrightness.Text = "Brightness " + trackBarBrightness.Value + "%";
			copyColorsToSettings();
		}

		private int Clamp(int value, int min, int max)
		{
			return Math.Min(Math.Max(value, min), max);
		}

		private void applySettings()
		{
			btnAvailable.BackColor = System.Drawing.ColorTranslator.FromHtml(Properties.Settings.Default.ColorAvailable);
			btnBusy.BackColor = System.Drawing.ColorTranslator.FromHtml(Properties.Settings.Default.ColorBusy);
			btnAway.BackColor = System.Drawing.ColorTranslator.FromHtml(Properties.Settings.Default.ColorAway);
			btnDoNotDisturb.BackColor = System.Drawing.ColorTranslator.FromHtml(Properties.Settings.Default.ColorDoNotDisturb);
			btnOffline.BackColor = System.Drawing.ColorTranslator.FromHtml(Properties.Settings.Default.ColorOffline);
			trackBarBrightness.Value = Clamp(Properties.Settings.Default.Brightness, 0, 100);
			labelBrightness.Text = "Brightness " + trackBarBrightness.Value + "%";
			comboBoxSerialPort.Text = Properties.Settings.Default.SerialPort;
		}

		private void copyColorsToSettings()
		{
			Properties.Settings.Default.ColorAvailable = System.Drawing.ColorTranslator.ToHtml(btnAvailable.BackColor);
			Properties.Settings.Default.ColorBusy = System.Drawing.ColorTranslator.ToHtml(btnBusy.BackColor);
			Properties.Settings.Default.ColorAway = System.Drawing.ColorTranslator.ToHtml(btnAway.BackColor);
			Properties.Settings.Default.ColorDoNotDisturb = System.Drawing.ColorTranslator.ToHtml(btnDoNotDisturb.BackColor);
			Properties.Settings.Default.ColorOffline = System.Drawing.ColorTranslator.ToHtml(btnOffline.BackColor);
			Properties.Settings.Default.Brightness = trackBarBrightness.Value;
			var serialPortString = comboBoxSerialPort.Text;
			Properties.Settings.Default.SerialPort = serialPortString.Substring(0, serialPortString.IndexOf(" "));
		}

		private void getSerialPorts()
		{
			using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Caption like '%(COM%'"))
			{
				string[] ports = SerialPort.GetPortNames();
				var portDescriptions = searcher.Get().Cast<ManagementBaseObject>().ToList().Select(p => p["Caption"].ToString());
				var portList = ports.Select(n => n + " - " + portDescriptions.FirstOrDefault(s => s.Contains(n))).ToList();

				comboBoxSerialPort.Items.Clear();
				serialPortConfiguredAvailable = false;
				foreach (string s in portList)
				{
					comboBoxSerialPort.Items.Add(s); // add port with description
				}
				foreach (string s in ports)
				{
					if (s == Properties.Settings.Default.SerialPort) // check if configured port is available
					{
						serialPortConfiguredAvailable = true;
					}
				}
			}
		}

		private void applyPresence(Presence presence)
		{
			applyPresenceFromString(presence.Availability);
		}

		private void applyPresenceFromString(String presenceString)
		{
			serialLed.setLedColor(getLedColorFromPresence(presenceString));

			try {
				SystemTrayIcon.Icon = getTrayIconFromPresenceString(presenceString);
			}
			catch (Exception ex) {
				MessageBox.Show("Exception in FormSettings::setPresenceColor, SystemTrayIcon:\n" + ex.Message);
			}

			try
			{
				// Show Color in Profile Photo
				Color color = getSystemColorFromPresence(presenceString);
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
			catch (Exception ex) {
				MessageBox.Show("Exception in FormSettings::setPresenceColor, ProfileFoto:\n" + ex.Message);
			}
		}

		private void comboBoxSerialPort_SelectedIndexChanged(object sender, EventArgs e)
		{
			copyColorsToSettings();
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
				graphHandler.Logout();
				//await SetColor("Off").ConfigureAwait(true);
				pictureBoxFoto.Visible = false;
				applyPresenceFromString(presenceOffline);
				timerPeriodic.Stop();

				//doLogout();
				btnLogin.Text = "Login";
			}
			else
			{
				doLogin();
			}
		}

		private void setPhoto(System.IO.Stream photo)
		{
			if (photo != null)
			{
				System.IO.MemoryStream ms = new System.IO.MemoryStream();
				photo.CopyTo(ms);
				Bitmap bmp = new Bitmap(System.Drawing.Image.FromStream(ms), pictureBoxFoto.Size);
				pictureBoxFoto.Image = ClipToCircle(bmp);
				pictureBoxFoto.Visible = true;
			}
			else
			{
				// create image for Profile Photo if none is set
				pictureBoxFoto.Image = new Bitmap(pictureBoxFoto.Width, pictureBoxFoto.Height);
			}
		}

		private async void doLogin()
		{
			graphHandler.Login();

			try { 
				setPhoto(await graphHandler.GetPhoto());
				applyPresence(await graphHandler.GetPresence());
			}
			catch (Exception ex)
			{
				MessageBox.Show("Exception in FormSettings::doLogin:\n" + ex.Message);
			}

			
			timerPeriodic.Start();

			// doLogin();
			btnLogin.Text = "Logout";
		}

		private Icon getTrayIconFromPresenceString(string presenceString)
		{
			switch (presenceString)
			{
				case presenceAvailable:
				case presenceAvailableIdle:
					return Properties.Resources.TrayIcon_green;
				case presenceBusy:
				case presenceBusyIdle:
					return Properties.Resources.TrayIcon_red;
				case presenceDoNotDisturb:
					return Properties.Resources.TrayIcon_magenta;
				case presenceAway:
				case presenceBeRightBack:
					return Properties.Resources.TrayIcon_yellow;
				case presenceOffline:
				case presencePresenceUnknown:
				default:
					return Properties.Resources.TrayIcon_blue;
			}

		}

		private Color getLedColorFromPresence(string presenceString)
		{
			Color retVal= Color.Black;
			switch (presenceString)
			{
				case presenceAvailable:
				case presenceAvailableIdle:
					retVal = System.Drawing.ColorTranslator.FromHtml(Properties.Settings.Default.ColorAvailable);
					break;
				case presenceBusy:
				case presenceBusyIdle:
					retVal = System.Drawing.ColorTranslator.FromHtml(Properties.Settings.Default.ColorBusy);
					break;
				case presenceDoNotDisturb:
					retVal = System.Drawing.ColorTranslator.FromHtml(Properties.Settings.Default.ColorDoNotDisturb);
					break;
				case presenceAway:
				case presenceBeRightBack:
					retVal = System.Drawing.ColorTranslator.FromHtml(Properties.Settings.Default.ColorAway);
					break;
				case presenceOffline:
				case presencePresenceUnknown:
				default:
					retVal = System.Drawing.ColorTranslator.FromHtml(Properties.Settings.Default.ColorOffline);
					break;
			}
			return retVal;
		}

		private Color getSystemColorFromPresence(string presenceString)
		{
			switch (presenceString)
			{
				case presenceAvailable:
				case presenceAvailableIdle:
					return Color.FromArgb(0, 255, 0);
				case presenceBusy:
				case presenceBusyIdle:
					return Color.FromArgb(255, 0, 0);
				case presenceDoNotDisturb:
					return Color.FromArgb(255, 0, 255);
				case presenceAway:
				case presenceBeRightBack:
					return Color.FromArgb(255, 255, 0);
				case presenceOffline:
				case presencePresenceUnknown:
				default:
					return Color.FromArgb(0,0, 150);
			}
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

		private void SystemTrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			ContextMenuSettings(sender, e);
		}

		private async void timerPeriodic_Tick(object sender, EventArgs e)
		{
			if (radioButtonSyncToTeams.Checked)
			{
				try
				{
					applyPresence(await graphHandler.GetPresence());
				}
				catch (Exception ex)
				{
					MessageBox.Show("Exception in FormSettings::timerPeriodic_Tick, applyPresence:\n" + ex.Message);
				}
			}
			else if (radioButtonAvailable.Checked) applyPresenceFromString(presenceAvailable);
			else if (radioButtonBusy.Checked) applyPresenceFromString(presenceBusy);
			else if (radioButtonAway.Checked) applyPresenceFromString(presenceAway);
			else if (radioButtonDoNotDisturb.Checked) applyPresenceFromString(presenceDoNotDisturb);
			else if (radioButtonOffline.Checked) applyPresenceFromString(presenceOffline);
		}

	}
}

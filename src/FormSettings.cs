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
		private static bool executingTimer = false;

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
			menu.MenuItems.Add("Settings", ContextMenuSettings);
			menu.MenuItems.Add("Exit", ContextMenuExit);
			this.SystemTrayIcon.ContextMenu = menu;

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
			Properties.Settings.Default.SerialPort = comboBoxSerialPort.Text;
		}

		private void getSerialPorts()
		{
			string[] ports = SerialPort.GetPortNames();
			comboBoxSerialPort.Items.Clear();
			serialPortConfiguredAvailable = false;
			foreach (string s in SerialPort.GetPortNames())
			{
				comboBoxSerialPort.Items.Add(s);
				if (s == Properties.Settings.Default.SerialPort)
				{
					serialPortConfiguredAvailable = true;
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

			setPhoto(await graphHandler.GetPhoto());
			applyPresence(await graphHandler.GetPresence());
			timerPeriodic.Start();

			// doLogin();
			btnLogin.Text = "Logout";

			/*
			//graphClient = GraphService.Get

			List<string> scopes = new List<string>
			{
				"https://graph.microsoft.com/.default"
			};

			var clientId = "3bd2647e-821e-48dd-a4b3-158e87fd7945";
			//var pca = PublicClientApplicationBuilder.Create(aadSettings.ClientId)
			var pca = PublicClientApplicationBuilder.Create(clientId)
													//var pca = PublicClientApplicationBuilder.Create(aadSettings.ClientId)
													//.WithAuthority($"{aadSettings.Instance}common/")
													.WithRedirectUri(Properties.Settings.Default.RedirectUri)
													.Build();

			//TokenCacheHelper.EnableSerialization(pca.UserTokenCache);

			//var authProvider = new WPFAuthorizationProvider(pca, scopes);

			var accounts = await pca.GetAccountsAsync().ConfigureAwait(true);
			Microsoft.Identity.Client.AuthenticationResult result;
			try
			{
				result = await pca.AcquireTokenSilent(scopes, accounts.FirstOrDefault()).ExecuteAsync();
			}
			catch (Microsoft.Identity.Client.MsalUiRequiredException)
			{
				result = await pca.AcquireTokenInteractive(scopes).ExecuteAsync();
			}


			var graphScopes = new[] { "User.Read", "Presence.Read" };
			var graphClient = new GraphServiceClient(result.AccessToken, graphScopes);



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


			*/



			/*



			var scopes = new[] { "User.Read", "Presence.Read" };

			// Multi-tenant apps can use "common",
			// single-tenant apps must use the tenant ID from the Azure portal
			var tenantId = "common";

			// Value from app registration
			var clientId = "3bd2647e-821e-48dd-a4b3-158e87fd7945";
			//Microsoft.Identity.Client.IPublicClientApplication

			var app = Microsoft.Identity.Client.PublicClientApplicationBuilder.Create(clientId).Build();
			var accounts = await app.GetAccountsAsync();
			Microsoft.Identity.Client.AuthenticationResult result;
			try
			{
				result = await app.AcquireTokenSilent(scopes, accounts.FirstOrDefault()).ExecuteAsync();
			}
			catch (Microsoft.Identity.Client.MsalUiRequiredException)
			{
				result = await app.AcquireTokenInteractive(scopes).ExecuteAsync();
			}

			// using Azure.Identity;
			var options = new TokenCredentialOptions
			{
				AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
			};

			// Callback function that receives the user prompt
			// Prompt contains the generated device code that use must
			// enter during the auth process in the browser
			Func<DeviceCodeInfo, System.Threading.CancellationToken, Task> callback = (code, cancellation) => {
				Console.WriteLine(code.Message);
				return Task.FromResult(0);
			};

			// https://docs.microsoft.com/dotnet/api/azure.identity.devicecodecredential
			var deviceCodeCredential = new DeviceCodeCredential(
				callback, tenantId, clientId, options);

			var graphClient = new GraphServiceClient(deviceCodeCredential, scopes);



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


			*/



			/*
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

			var requestContext = new Azure.Core.TokenRequestContext(scopes, clientId, null, tenantId);
			var result = await interactiveCredential.GetTokenAsync(requestContext);
			Properties.Settings.Default.Token = result.Token;
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
			*/





			//interactiveCredential.Authenticate();

			//interactiveCredential.AuthenticationRecord
			//if (interactiveCredential.Record.Username != null)
			//{

			//}
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
		            
		private void SystemTrayIcon_MouseClick(object sender, MouseEventArgs e)
		{
			ContextMenuSettings(sender, e);
		}

		private void SystemTrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			ContextMenuSettings(sender, e);
		}

		private async void timerPeriodic_Tick(object sender, EventArgs e)
		{
			if (!executingTimer) // only enter if the last one is finished
			{
				executingTimer = true;
				applyPresence(await graphHandler.GetPresence());
				executingTimer = false;
			}
		}
	}
}

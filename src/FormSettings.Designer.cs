
namespace PresenceBridge
{
	partial class FormSettings
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.SystemTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.btnAvailable = new System.Windows.Forms.Button();
			this.labelAvailable = new System.Windows.Forms.Label();
			this.labelBusy = new System.Windows.Forms.Label();
			this.btnBusy = new System.Windows.Forms.Button();
			this.labelAway = new System.Windows.Forms.Label();
			this.btnAway = new System.Windows.Forms.Button();
			this.labelDoNotDisturb = new System.Windows.Forms.Label();
			this.btnDoNotDisturb = new System.Windows.Forms.Button();
			this.labelOffline = new System.Windows.Forms.Label();
			this.btnOffline = new System.Windows.Forms.Button();
			this.trackBarBrightness = new System.Windows.Forms.TrackBar();
			this.labelBrightness = new System.Windows.Forms.Label();
			this.comboBoxSerialPort = new System.Windows.Forms.ComboBox();
			this.labelSerialPort = new System.Windows.Forms.Label();
			this.labelTeamsConnection = new System.Windows.Forms.Label();
			this.pictureBoxFoto = new System.Windows.Forms.PictureBox();
			this.btnLogin = new System.Windows.Forms.Button();
			this.btnReload = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto)).BeginInit();
			this.SuspendLayout();
			// 
			// SystemTrayIcon
			// 
			this.SystemTrayIcon.Text = "SystemTrayIcon";
			this.SystemTrayIcon.Visible = true;
			this.SystemTrayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SystemTrayIcon_MouseClick);
			// 
			// btnAvailable
			// 
			this.btnAvailable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAvailable.Location = new System.Drawing.Point(12, 12);
			this.btnAvailable.Name = "btnAvailable";
			this.btnAvailable.Size = new System.Drawing.Size(20, 20);
			this.btnAvailable.TabIndex = 0;
			this.btnAvailable.UseVisualStyleBackColor = true;
			this.btnAvailable.Click += new System.EventHandler(this.selectColor);
			// 
			// labelAvailable
			// 
			this.labelAvailable.AutoSize = true;
			this.labelAvailable.Location = new System.Drawing.Point(38, 16);
			this.labelAvailable.Name = "labelAvailable";
			this.labelAvailable.Size = new System.Drawing.Size(50, 13);
			this.labelAvailable.TabIndex = 1;
			this.labelAvailable.Text = "Available";
			this.labelAvailable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelBusy
			// 
			this.labelBusy.AutoSize = true;
			this.labelBusy.Location = new System.Drawing.Point(38, 42);
			this.labelBusy.Name = "labelBusy";
			this.labelBusy.Size = new System.Drawing.Size(30, 13);
			this.labelBusy.TabIndex = 3;
			this.labelBusy.Text = "Busy";
			this.labelBusy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnBusy
			// 
			this.btnBusy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBusy.Location = new System.Drawing.Point(12, 38);
			this.btnBusy.Name = "btnBusy";
			this.btnBusy.Size = new System.Drawing.Size(20, 20);
			this.btnBusy.TabIndex = 2;
			this.btnBusy.UseVisualStyleBackColor = true;
			this.btnBusy.Click += new System.EventHandler(this.selectColor);
			// 
			// labelAway
			// 
			this.labelAway.AutoSize = true;
			this.labelAway.Location = new System.Drawing.Point(38, 68);
			this.labelAway.Name = "labelAway";
			this.labelAway.Size = new System.Drawing.Size(33, 13);
			this.labelAway.TabIndex = 5;
			this.labelAway.Text = "Away";
			this.labelAway.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnAway
			// 
			this.btnAway.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAway.Location = new System.Drawing.Point(12, 64);
			this.btnAway.Name = "btnAway";
			this.btnAway.Size = new System.Drawing.Size(20, 20);
			this.btnAway.TabIndex = 4;
			this.btnAway.UseVisualStyleBackColor = true;
			this.btnAway.Click += new System.EventHandler(this.selectColor);
			// 
			// labelDoNotDisturb
			// 
			this.labelDoNotDisturb.AutoSize = true;
			this.labelDoNotDisturb.Location = new System.Drawing.Point(38, 94);
			this.labelDoNotDisturb.Name = "labelDoNotDisturb";
			this.labelDoNotDisturb.Size = new System.Drawing.Size(71, 13);
			this.labelDoNotDisturb.TabIndex = 7;
			this.labelDoNotDisturb.Text = "DoNotDisturb";
			this.labelDoNotDisturb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnDoNotDisturb
			// 
			this.btnDoNotDisturb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDoNotDisturb.Location = new System.Drawing.Point(12, 90);
			this.btnDoNotDisturb.Name = "btnDoNotDisturb";
			this.btnDoNotDisturb.Size = new System.Drawing.Size(20, 20);
			this.btnDoNotDisturb.TabIndex = 6;
			this.btnDoNotDisturb.UseVisualStyleBackColor = true;
			this.btnDoNotDisturb.Click += new System.EventHandler(this.selectColor);
			// 
			// labelOffline
			// 
			this.labelOffline.AutoSize = true;
			this.labelOffline.Location = new System.Drawing.Point(38, 120);
			this.labelOffline.Name = "labelOffline";
			this.labelOffline.Size = new System.Drawing.Size(37, 13);
			this.labelOffline.TabIndex = 9;
			this.labelOffline.Text = "Offline";
			this.labelOffline.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnOffline
			// 
			this.btnOffline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnOffline.Location = new System.Drawing.Point(12, 116);
			this.btnOffline.Name = "btnOffline";
			this.btnOffline.Size = new System.Drawing.Size(20, 20);
			this.btnOffline.TabIndex = 8;
			this.btnOffline.UseVisualStyleBackColor = true;
			this.btnOffline.Click += new System.EventHandler(this.selectColor);
			// 
			// trackBarBrightness
			// 
			this.trackBarBrightness.LargeChange = 10;
			this.trackBarBrightness.Location = new System.Drawing.Point(12, 186);
			this.trackBarBrightness.Maximum = 100;
			this.trackBarBrightness.Name = "trackBarBrightness";
			this.trackBarBrightness.Size = new System.Drawing.Size(260, 45);
			this.trackBarBrightness.TabIndex = 10;
			this.trackBarBrightness.TickFrequency = 10;
			this.trackBarBrightness.Value = 100;
			this.trackBarBrightness.Scroll += new System.EventHandler(this.trackBarBrightness_Scroll);
			// 
			// labelBrightness
			// 
			this.labelBrightness.AutoSize = true;
			this.labelBrightness.Location = new System.Drawing.Point(12, 170);
			this.labelBrightness.Name = "labelBrightness";
			this.labelBrightness.Size = new System.Drawing.Size(56, 13);
			this.labelBrightness.TabIndex = 11;
			this.labelBrightness.Text = "Brightness";
			this.labelBrightness.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// comboBoxSerialPort
			// 
			this.comboBoxSerialPort.FormattingEnabled = true;
			this.comboBoxSerialPort.Location = new System.Drawing.Point(12, 250);
			this.comboBoxSerialPort.Name = "comboBoxSerialPort";
			this.comboBoxSerialPort.Size = new System.Drawing.Size(260, 21);
			this.comboBoxSerialPort.TabIndex = 12;
			this.comboBoxSerialPort.SelectedIndexChanged += new System.EventHandler(this.comboBoxSerialPort_SelectedIndexChanged);
			this.comboBoxSerialPort.Click += new System.EventHandler(this.comboBoxSerialPort_Click);
			// 
			// labelSerialPort
			// 
			this.labelSerialPort.AutoSize = true;
			this.labelSerialPort.Location = new System.Drawing.Point(12, 234);
			this.labelSerialPort.Name = "labelSerialPort";
			this.labelSerialPort.Size = new System.Drawing.Size(133, 13);
			this.labelSerialPort.TabIndex = 13;
			this.labelSerialPort.Text = "PresenceLight\'s Serial Port";
			this.labelSerialPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelTeamsConnection
			// 
			this.labelTeamsConnection.AutoSize = true;
			this.labelTeamsConnection.Location = new System.Drawing.Point(12, 329);
			this.labelTeamsConnection.Name = "labelTeamsConnection";
			this.labelTeamsConnection.Size = new System.Drawing.Size(96, 13);
			this.labelTeamsConnection.TabIndex = 14;
			this.labelTeamsConnection.Text = "Teams Connection";
			this.labelTeamsConnection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pictureBoxFoto
			// 
			this.pictureBoxFoto.Location = new System.Drawing.Point(69, 345);
			this.pictureBoxFoto.Name = "pictureBoxFoto";
			this.pictureBoxFoto.Size = new System.Drawing.Size(150, 150);
			this.pictureBoxFoto.TabIndex = 15;
			this.pictureBoxFoto.TabStop = false;
			// 
			// btnLogin
			// 
			this.btnLogin.Location = new System.Drawing.Point(103, 528);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(75, 23);
			this.btnLogin.TabIndex = 16;
			this.btnLogin.Text = "Login";
			this.btnLogin.UseVisualStyleBackColor = true;
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// btnReload
			// 
			this.btnReload.Location = new System.Drawing.Point(63, 277);
			this.btnReload.Name = "btnReload";
			this.btnReload.Size = new System.Drawing.Size(75, 23);
			this.btnReload.TabIndex = 17;
			this.btnReload.Text = "Reload";
			this.btnReload.UseVisualStyleBackColor = true;
			this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(144, 277);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 18;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// FormSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 563);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnReload);
			this.Controls.Add(this.btnLogin);
			this.Controls.Add(this.pictureBoxFoto);
			this.Controls.Add(this.labelTeamsConnection);
			this.Controls.Add(this.labelSerialPort);
			this.Controls.Add(this.comboBoxSerialPort);
			this.Controls.Add(this.labelBrightness);
			this.Controls.Add(this.trackBarBrightness);
			this.Controls.Add(this.labelOffline);
			this.Controls.Add(this.btnOffline);
			this.Controls.Add(this.labelDoNotDisturb);
			this.Controls.Add(this.btnDoNotDisturb);
			this.Controls.Add(this.labelAway);
			this.Controls.Add(this.btnAway);
			this.Controls.Add(this.labelBusy);
			this.Controls.Add(this.btnBusy);
			this.Controls.Add(this.labelAvailable);
			this.Controls.Add(this.btnAvailable);
			this.Name = "FormSettings";
			this.Text = "PresenceBridge";
			((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NotifyIcon SystemTrayIcon;
		private System.Windows.Forms.Button btnAvailable;
		private System.Windows.Forms.Label labelAvailable;
		private System.Windows.Forms.Label labelBusy;
		private System.Windows.Forms.Button btnBusy;
		private System.Windows.Forms.Label labelAway;
		private System.Windows.Forms.Button btnAway;
		private System.Windows.Forms.Label labelDoNotDisturb;
		private System.Windows.Forms.Button btnDoNotDisturb;
		private System.Windows.Forms.Label labelOffline;
		private System.Windows.Forms.Button btnOffline;
		private System.Windows.Forms.TrackBar trackBarBrightness;
		private System.Windows.Forms.Label labelBrightness;
		private System.Windows.Forms.ComboBox comboBoxSerialPort;
		private System.Windows.Forms.Label labelSerialPort;
		private System.Windows.Forms.Label labelTeamsConnection;
		private System.Windows.Forms.PictureBox pictureBoxFoto;
		private System.Windows.Forms.Button btnLogin;
		private System.Windows.Forms.Button btnReload;
		private System.Windows.Forms.Button btnSave;
	}
}


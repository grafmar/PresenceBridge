
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
			this.btnBusy = new System.Windows.Forms.Button();
			this.btnAway = new System.Windows.Forms.Button();
			this.btnDoNotDisturb = new System.Windows.Forms.Button();
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
			this.timerPeriodic = new System.Windows.Forms.Timer(this.components);
			this.radioButtonAvailable = new System.Windows.Forms.RadioButton();
			this.radioButtonBusy = new System.Windows.Forms.RadioButton();
			this.radioButtonAway = new System.Windows.Forms.RadioButton();
			this.radioButtonDoNotDisturb = new System.Windows.Forms.RadioButton();
			this.radioButtonOffline = new System.Windows.Forms.RadioButton();
			this.radioButtonSyncToTeams = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto)).BeginInit();
			this.SuspendLayout();
			// 
			// SystemTrayIcon
			// 
			this.SystemTrayIcon.Text = "SystemTrayIcon";
			this.SystemTrayIcon.Visible = true;
			this.SystemTrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SystemTrayIcon_MouseDoubleClick);
			// 
			// btnAvailable
			// 
			this.btnAvailable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAvailable.Location = new System.Drawing.Point(12, 33);
			this.btnAvailable.Name = "btnAvailable";
			this.btnAvailable.Size = new System.Drawing.Size(20, 20);
			this.btnAvailable.TabIndex = 0;
			this.btnAvailable.UseVisualStyleBackColor = true;
			this.btnAvailable.Click += new System.EventHandler(this.selectColor);
			// 
			// labelAvailable
			// 
			this.labelAvailable.AutoSize = true;
			this.labelAvailable.Location = new System.Drawing.Point(12, 9);
			this.labelAvailable.Name = "labelAvailable";
			this.labelAvailable.Size = new System.Drawing.Size(133, 13);
			this.labelAvailable.TabIndex = 1;
			this.labelAvailable.Text = "Set LED-Light to this state:";
			this.labelAvailable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnBusy
			// 
			this.btnBusy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBusy.Location = new System.Drawing.Point(12, 59);
			this.btnBusy.Name = "btnBusy";
			this.btnBusy.Size = new System.Drawing.Size(20, 20);
			this.btnBusy.TabIndex = 2;
			this.btnBusy.UseVisualStyleBackColor = true;
			this.btnBusy.Click += new System.EventHandler(this.selectColor);
			// 
			// btnAway
			// 
			this.btnAway.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAway.Location = new System.Drawing.Point(12, 85);
			this.btnAway.Name = "btnAway";
			this.btnAway.Size = new System.Drawing.Size(20, 20);
			this.btnAway.TabIndex = 4;
			this.btnAway.UseVisualStyleBackColor = true;
			this.btnAway.Click += new System.EventHandler(this.selectColor);
			// 
			// btnDoNotDisturb
			// 
			this.btnDoNotDisturb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDoNotDisturb.Location = new System.Drawing.Point(12, 111);
			this.btnDoNotDisturb.Name = "btnDoNotDisturb";
			this.btnDoNotDisturb.Size = new System.Drawing.Size(20, 20);
			this.btnDoNotDisturb.TabIndex = 6;
			this.btnDoNotDisturb.UseVisualStyleBackColor = true;
			this.btnDoNotDisturb.Click += new System.EventHandler(this.selectColor);
			// 
			// btnOffline
			// 
			this.btnOffline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnOffline.Location = new System.Drawing.Point(12, 137);
			this.btnOffline.Name = "btnOffline";
			this.btnOffline.Size = new System.Drawing.Size(20, 20);
			this.btnOffline.TabIndex = 8;
			this.btnOffline.UseVisualStyleBackColor = true;
			this.btnOffline.Click += new System.EventHandler(this.selectColor);
			// 
			// trackBarBrightness
			// 
			this.trackBarBrightness.LargeChange = 10;
			this.trackBarBrightness.Location = new System.Drawing.Point(13, 227);
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
			this.labelBrightness.Location = new System.Drawing.Point(13, 211);
			this.labelBrightness.Name = "labelBrightness";
			this.labelBrightness.Size = new System.Drawing.Size(56, 13);
			this.labelBrightness.TabIndex = 11;
			this.labelBrightness.Text = "Brightness";
			this.labelBrightness.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// comboBoxSerialPort
			// 
			this.comboBoxSerialPort.FormattingEnabled = true;
			this.comboBoxSerialPort.Location = new System.Drawing.Point(13, 291);
			this.comboBoxSerialPort.Name = "comboBoxSerialPort";
			this.comboBoxSerialPort.Size = new System.Drawing.Size(260, 21);
			this.comboBoxSerialPort.TabIndex = 12;
			this.comboBoxSerialPort.SelectedIndexChanged += new System.EventHandler(this.comboBoxSerialPort_SelectedIndexChanged);
			this.comboBoxSerialPort.Click += new System.EventHandler(this.comboBoxSerialPort_Click);
			// 
			// labelSerialPort
			// 
			this.labelSerialPort.AutoSize = true;
			this.labelSerialPort.Location = new System.Drawing.Point(13, 275);
			this.labelSerialPort.Name = "labelSerialPort";
			this.labelSerialPort.Size = new System.Drawing.Size(133, 13);
			this.labelSerialPort.TabIndex = 13;
			this.labelSerialPort.Text = "PresenceLight\'s Serial Port";
			this.labelSerialPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelTeamsConnection
			// 
			this.labelTeamsConnection.AutoSize = true;
			this.labelTeamsConnection.Location = new System.Drawing.Point(13, 370);
			this.labelTeamsConnection.Name = "labelTeamsConnection";
			this.labelTeamsConnection.Size = new System.Drawing.Size(96, 13);
			this.labelTeamsConnection.TabIndex = 14;
			this.labelTeamsConnection.Text = "Teams Connection";
			this.labelTeamsConnection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pictureBoxFoto
			// 
			this.pictureBoxFoto.Location = new System.Drawing.Point(70, 386);
			this.pictureBoxFoto.Name = "pictureBoxFoto";
			this.pictureBoxFoto.Size = new System.Drawing.Size(150, 150);
			this.pictureBoxFoto.TabIndex = 15;
			this.pictureBoxFoto.TabStop = false;
			// 
			// btnLogin
			// 
			this.btnLogin.Location = new System.Drawing.Point(104, 569);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(75, 23);
			this.btnLogin.TabIndex = 16;
			this.btnLogin.Text = "Login";
			this.btnLogin.UseVisualStyleBackColor = true;
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// btnReload
			// 
			this.btnReload.Location = new System.Drawing.Point(64, 318);
			this.btnReload.Name = "btnReload";
			this.btnReload.Size = new System.Drawing.Size(75, 23);
			this.btnReload.TabIndex = 17;
			this.btnReload.Text = "Reload";
			this.btnReload.UseVisualStyleBackColor = true;
			this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(145, 318);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 18;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// timerPeriodic
			// 
			this.timerPeriodic.Interval = 1000;
			this.timerPeriodic.Tick += new System.EventHandler(this.timerPeriodic_Tick);
			// 
			// radioButtonAvailable
			// 
			this.radioButtonAvailable.AutoSize = true;
			this.radioButtonAvailable.Location = new System.Drawing.Point(38, 35);
			this.radioButtonAvailable.Name = "radioButtonAvailable";
			this.radioButtonAvailable.Size = new System.Drawing.Size(68, 17);
			this.radioButtonAvailable.TabIndex = 20;
			this.radioButtonAvailable.Text = "Available";
			this.radioButtonAvailable.UseVisualStyleBackColor = true;
			// 
			// radioButtonBusy
			// 
			this.radioButtonBusy.AutoSize = true;
			this.radioButtonBusy.Location = new System.Drawing.Point(38, 61);
			this.radioButtonBusy.Name = "radioButtonBusy";
			this.radioButtonBusy.Size = new System.Drawing.Size(48, 17);
			this.radioButtonBusy.TabIndex = 21;
			this.radioButtonBusy.Text = "Busy";
			this.radioButtonBusy.UseVisualStyleBackColor = true;
			// 
			// radioButtonAway
			// 
			this.radioButtonAway.AutoSize = true;
			this.radioButtonAway.Location = new System.Drawing.Point(38, 87);
			this.radioButtonAway.Name = "radioButtonAway";
			this.radioButtonAway.Size = new System.Drawing.Size(51, 17);
			this.radioButtonAway.TabIndex = 22;
			this.radioButtonAway.Text = "Away";
			this.radioButtonAway.UseVisualStyleBackColor = true;
			// 
			// radioButtonDoNotDisturb
			// 
			this.radioButtonDoNotDisturb.AutoSize = true;
			this.radioButtonDoNotDisturb.Location = new System.Drawing.Point(38, 113);
			this.radioButtonDoNotDisturb.Name = "radioButtonDoNotDisturb";
			this.radioButtonDoNotDisturb.Size = new System.Drawing.Size(89, 17);
			this.radioButtonDoNotDisturb.TabIndex = 23;
			this.radioButtonDoNotDisturb.Text = "DoNotDisturb";
			this.radioButtonDoNotDisturb.UseVisualStyleBackColor = true;
			// 
			// radioButtonOffline
			// 
			this.radioButtonOffline.AutoSize = true;
			this.radioButtonOffline.Location = new System.Drawing.Point(38, 139);
			this.radioButtonOffline.Name = "radioButtonOffline";
			this.radioButtonOffline.Size = new System.Drawing.Size(55, 17);
			this.radioButtonOffline.TabIndex = 24;
			this.radioButtonOffline.Text = "Offline";
			this.radioButtonOffline.UseVisualStyleBackColor = true;
			// 
			// radioButtonSyncToTeams
			// 
			this.radioButtonSyncToTeams.AutoSize = true;
			this.radioButtonSyncToTeams.Checked = true;
			this.radioButtonSyncToTeams.Location = new System.Drawing.Point(38, 165);
			this.radioButtonSyncToTeams.Name = "radioButtonSyncToTeams";
			this.radioButtonSyncToTeams.Size = new System.Drawing.Size(94, 17);
			this.radioButtonSyncToTeams.TabIndex = 25;
			this.radioButtonSyncToTeams.TabStop = true;
			this.radioButtonSyncToTeams.Text = "SyncToTeams";
			this.radioButtonSyncToTeams.UseVisualStyleBackColor = true;
			// 
			// FormSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 602);
			this.Controls.Add(this.radioButtonSyncToTeams);
			this.Controls.Add(this.radioButtonOffline);
			this.Controls.Add(this.radioButtonDoNotDisturb);
			this.Controls.Add(this.radioButtonAway);
			this.Controls.Add(this.radioButtonBusy);
			this.Controls.Add(this.radioButtonAvailable);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnReload);
			this.Controls.Add(this.btnLogin);
			this.Controls.Add(this.pictureBoxFoto);
			this.Controls.Add(this.labelTeamsConnection);
			this.Controls.Add(this.labelSerialPort);
			this.Controls.Add(this.comboBoxSerialPort);
			this.Controls.Add(this.labelBrightness);
			this.Controls.Add(this.trackBarBrightness);
			this.Controls.Add(this.btnOffline);
			this.Controls.Add(this.btnDoNotDisturb);
			this.Controls.Add(this.btnAway);
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
		private System.Windows.Forms.Button btnBusy;
		private System.Windows.Forms.Button btnAway;
		private System.Windows.Forms.Button btnDoNotDisturb;
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
		private System.Windows.Forms.Timer timerPeriodic;
		private System.Windows.Forms.RadioButton radioButtonAvailable;
		private System.Windows.Forms.RadioButton radioButtonBusy;
		private System.Windows.Forms.RadioButton radioButtonAway;
		private System.Windows.Forms.RadioButton radioButtonDoNotDisturb;
		private System.Windows.Forms.RadioButton radioButtonOffline;
		private System.Windows.Forms.RadioButton radioButtonSyncToTeams;
	}
}


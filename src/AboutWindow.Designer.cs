
namespace PresenceBridge
{
	partial class AboutWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.logoPictureBox = new System.Windows.Forms.PictureBox();
			this.labelProductName = new System.Windows.Forms.Label();
			this.labelVersion = new System.Windows.Forms.Label();
			this.labelCopyright = new System.Windows.Forms.Label();
			this.okButton = new System.Windows.Forms.Button();
			this.linkLabelDescription = new System.Windows.Forms.LinkLabel();
			this.labelCompanyName = new System.Windows.Forms.Label();
			this.tableLayoutPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.ColumnCount = 2;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
			this.tableLayoutPanel.Controls.Add(this.logoPictureBox, 0, 0);
			this.tableLayoutPanel.Controls.Add(this.labelProductName, 1, 0);
			this.tableLayoutPanel.Controls.Add(this.labelVersion, 1, 1);
			this.tableLayoutPanel.Controls.Add(this.labelCopyright, 1, 2);
			this.tableLayoutPanel.Controls.Add(this.labelCompanyName, 1, 3);
			this.tableLayoutPanel.Controls.Add(this.okButton, 1, 5);
			this.tableLayoutPanel.Controls.Add(this.linkLabelDescription, 1, 4);
			this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel.Location = new System.Drawing.Point(9, 9);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 6;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel.Size = new System.Drawing.Size(417, 265);
			this.tableLayoutPanel.TabIndex = 0;
			// 
			// logoPictureBox
			// 
			this.logoPictureBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.logoPictureBox.Image = global::PresenceBridge.Properties.Resources.Icon_mix;
			this.logoPictureBox.Location = new System.Drawing.Point(3, 3);
			this.logoPictureBox.Name = "logoPictureBox";
			this.tableLayoutPanel.SetRowSpan(this.logoPictureBox, 6);
			this.logoPictureBox.Size = new System.Drawing.Size(131, 131);
			this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.logoPictureBox.TabIndex = 12;
			this.logoPictureBox.TabStop = false;
			// 
			// labelProductName
			// 
			this.labelProductName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelProductName.Location = new System.Drawing.Point(143, 0);
			this.labelProductName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
			this.labelProductName.MaximumSize = new System.Drawing.Size(0, 17);
			this.labelProductName.Name = "labelProductName";
			this.labelProductName.Size = new System.Drawing.Size(271, 17);
			this.labelProductName.TabIndex = 19;
			this.labelProductName.Text = "Product Name";
			this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelVersion
			// 
			this.labelVersion.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelVersion.Location = new System.Drawing.Point(143, 26);
			this.labelVersion.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
			this.labelVersion.MaximumSize = new System.Drawing.Size(0, 17);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new System.Drawing.Size(271, 17);
			this.labelVersion.TabIndex = 0;
			this.labelVersion.Text = "Version";
			this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelCopyright
			// 
			this.labelCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelCopyright.Location = new System.Drawing.Point(143, 52);
			this.labelCopyright.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
			this.labelCopyright.MaximumSize = new System.Drawing.Size(0, 17);
			this.labelCopyright.Name = "labelCopyright";
			this.labelCopyright.Size = new System.Drawing.Size(271, 17);
			this.labelCopyright.TabIndex = 21;
			this.labelCopyright.Text = "Copyright";
			this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.okButton.Location = new System.Drawing.Point(339, 239);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 24;
			this.okButton.Text = "&OK";
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// linkLabelDescription
			// 
			this.linkLabelDescription.AutoSize = true;
			this.linkLabelDescription.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
			this.linkLabelDescription.Location = new System.Drawing.Point(143, 104);
			this.linkLabelDescription.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
			this.linkLabelDescription.MaximumSize = new System.Drawing.Size(271, 126);
			this.linkLabelDescription.MinimumSize = new System.Drawing.Size(271, 126);
			this.linkLabelDescription.Name = "linkLabelDescription";
			this.linkLabelDescription.Size = new System.Drawing.Size(271, 126);
			this.linkLabelDescription.TabIndex = 1;
			this.linkLabelDescription.Text = "linkLabel1";
			this.linkLabelDescription.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// labelCompanyName
			// 
			this.labelCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelCompanyName.Location = new System.Drawing.Point(143, 78);
			this.labelCompanyName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
			this.labelCompanyName.MaximumSize = new System.Drawing.Size(0, 17);
			this.labelCompanyName.Name = "labelCompanyName";
			this.labelCompanyName.Size = new System.Drawing.Size(271, 17);
			this.labelCompanyName.TabIndex = 22;
			this.labelCompanyName.Text = "Company Name";
			this.labelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AboutWindow
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(435, 283);
			this.Controls.Add(this.tableLayoutPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutWindow";
			this.Padding = new System.Windows.Forms.Padding(9);
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "AboutWindow";
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.PictureBox logoPictureBox;
		private System.Windows.Forms.Label labelProductName;
		private System.Windows.Forms.Label labelVersion;
		private System.Windows.Forms.Label labelCopyright;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.LinkLabel linkLabelDescription;
		private System.Windows.Forms.Label labelCompanyName;
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresenceBridge
{
	partial class AboutWindow : Form
	{
		private static log4net.ILog log;

		public AboutWindow(log4net.ILog logger)
		{
			log = logger;
			try
			{
				InitializeComponent();
				this.Text = String.Format("About {0}", AssemblyTitle);
				this.labelProductName.Text = AssemblyProduct;
				this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
				this.labelCopyright.Text = AssemblyCopyright;
				this.labelCompanyName.Text = AssemblyCompany;

				this.linkLabelDescription.Text = "https://github.com/grafmar/PresenceBridge \n\nControlls LED-Light through serial port and synchronizes with Teams Status.\n\nThe serial protocol is very simple and a Light such as the LyncDisplayLight can easily be build up.";
				this.linkLabelDescription.Links.Add(0, 41, "https://github.com/grafmar/PresenceBridge");
				this.linkLabelDescription.Links.Add(180, 16, "https://github.com/grafmar/LyncDisplayLight");
			}
			catch (Exception ex)
			{
				log.Error(ex.Message);
			}
		}

		#region Assembly Attribute Accessors

		public string AssemblyTitle
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				if (attributes.Length > 0)
				{
					AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
					if (titleAttribute.Title != "")
					{
						return titleAttribute.Title;
					}
				}
				return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}

		public string AssemblyVersion
		{
			get
			{
				return Assembly.GetExecutingAssembly().GetName().Version.ToString();
			}
		}

		public string AssemblyDescription
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyDescriptionAttribute)attributes[0]).Description;
			}
		}

		public string AssemblyProduct
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyProductAttribute)attributes[0]).Product;
			}
		}

		public string AssemblyCopyright
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
			}
		}

		public string AssemblyCompany
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyCompanyAttribute)attributes[0]).Company;
			}
		}
		#endregion

		private void okButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				System.Diagnostics.Process.Start(e.Link.LinkData as string);
			}
			catch (Exception ex)
			{
				log.Error(ex.Message);
			}
		}
	}
}

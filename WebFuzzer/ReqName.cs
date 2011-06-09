using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebFuzzer
{
	public partial class ReqName : Form
	{
		public bool saveURI = true;
		public bool saveProxy = true;
		public bool saveRequest = true;
		public bool saveResponse = true;
		public bool wasCanceled = false;
		public string name = "";

		public ReqName()
		{
			InitializeComponent();
		}

		private void Save_Click(object sender, EventArgs e)
		{
			saveURI = SaveURI.Checked;
			saveProxy = SaveProxyBox.Checked;
			saveRequest = SaveRequest.Checked;
			saveResponse = SaveResponse.Checked;

			name = NameBox.Text;

			this.Close();
		}

		private void Cancel_Click(object sender, EventArgs e)
		{
			wasCanceled = true;
			this.Close();
		}

		private void ReqName_Load(object sender, EventArgs e)
		{
			NameBox.Select();
		}

		private void NameBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				saveURI = SaveURI.Checked;
				saveProxy = SaveProxyBox.Checked;
				saveRequest = SaveRequest.Checked;
				saveResponse = SaveResponse.Checked;

				name = NameBox.Text;

				this.Close();
			}
		}
	}
}

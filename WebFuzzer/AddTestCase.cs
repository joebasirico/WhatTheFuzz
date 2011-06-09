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
	public partial class AddTestCase : Form
	{
		public bool wasCanceled = false;
		public string Name = "";
		public string Value = "";

		public AddTestCase()
		{
			InitializeComponent();
		}

		private void Cancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}

		private void Add_Click(object sender, EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
			Name = NameBox.Text;
			Value = ValueBox.Text;
			this.Close();
		}
	}
}

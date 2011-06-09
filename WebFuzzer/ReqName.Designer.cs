namespace WhatTheFuzz
{
	partial class ReqName
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
			this.SaveURI = new System.Windows.Forms.CheckBox();
			this.SaveProxyBox = new System.Windows.Forms.CheckBox();
			this.SaveRequest = new System.Windows.Forms.CheckBox();
			this.SaveResponse = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.Save = new System.Windows.Forms.Button();
			this.Cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// SaveURI
			// 
			this.SaveURI.AutoSize = true;
			this.SaveURI.Checked = true;
			this.SaveURI.CheckState = System.Windows.Forms.CheckState.Checked;
			this.SaveURI.Location = new System.Drawing.Point(12, 32);
			this.SaveURI.Name = "SaveURI";
			this.SaveURI.Size = new System.Drawing.Size(45, 17);
			this.SaveURI.TabIndex = 0;
			this.SaveURI.Text = "URI";
			this.SaveURI.UseVisualStyleBackColor = true;
			// 
			// SaveProxyBox
			// 
			this.SaveProxyBox.AutoSize = true;
			this.SaveProxyBox.Checked = true;
			this.SaveProxyBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.SaveProxyBox.Location = new System.Drawing.Point(110, 32);
			this.SaveProxyBox.Name = "SaveProxyBox";
			this.SaveProxyBox.Size = new System.Drawing.Size(52, 17);
			this.SaveProxyBox.TabIndex = 1;
			this.SaveProxyBox.Text = "Proxy";
			this.SaveProxyBox.UseVisualStyleBackColor = true;
			// 
			// SaveRequest
			// 
			this.SaveRequest.AutoSize = true;
			this.SaveRequest.Checked = true;
			this.SaveRequest.CheckState = System.Windows.Forms.CheckState.Checked;
			this.SaveRequest.Location = new System.Drawing.Point(215, 32);
			this.SaveRequest.Name = "SaveRequest";
			this.SaveRequest.Size = new System.Drawing.Size(66, 17);
			this.SaveRequest.TabIndex = 2;
			this.SaveRequest.Text = "Request";
			this.SaveRequest.UseVisualStyleBackColor = true;
			// 
			// SaveResponse
			// 
			this.SaveResponse.AutoSize = true;
			this.SaveResponse.Checked = true;
			this.SaveResponse.CheckState = System.Windows.Forms.CheckState.Checked;
			this.SaveResponse.Location = new System.Drawing.Point(334, 32);
			this.SaveResponse.Name = "SaveResponse";
			this.SaveResponse.Size = new System.Drawing.Size(74, 17);
			this.SaveResponse.TabIndex = 3;
			this.SaveResponse.Text = "Response";
			this.SaveResponse.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(210, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Select which values you would like to save";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(207, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Give this request a name to reference later";
			// 
			// NameBox
			// 
			this.NameBox.Location = new System.Drawing.Point(12, 68);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(396, 20);
			this.NameBox.TabIndex = 6;
			this.NameBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NameBox_KeyPress);
			// 
			// Save
			// 
			this.Save.Location = new System.Drawing.Point(333, 94);
			this.Save.Name = "Save";
			this.Save.Size = new System.Drawing.Size(75, 23);
			this.Save.TabIndex = 7;
			this.Save.Text = "Save";
			this.Save.UseVisualStyleBackColor = true;
			this.Save.Click += new System.EventHandler(this.Save_Click);
			// 
			// Cancel
			// 
			this.Cancel.Location = new System.Drawing.Point(15, 94);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(75, 23);
			this.Cancel.TabIndex = 8;
			this.Cancel.Text = "Cancel";
			this.Cancel.UseVisualStyleBackColor = true;
			this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
			// 
			// ReqName
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(423, 133);
			this.Controls.Add(this.Cancel);
			this.Controls.Add(this.Save);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.SaveResponse);
			this.Controls.Add(this.SaveRequest);
			this.Controls.Add(this.SaveProxyBox);
			this.Controls.Add(this.SaveURI);
			this.Name = "ReqName";
			this.Text = "ReqName";
			this.Load += new System.EventHandler(this.ReqName_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox SaveURI;
		private System.Windows.Forms.CheckBox SaveProxyBox;
		private System.Windows.Forms.CheckBox SaveRequest;
		private System.Windows.Forms.CheckBox SaveResponse;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.Button Save;
		private System.Windows.Forms.Button Cancel;
	}
}
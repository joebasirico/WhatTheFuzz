namespace WebFuzzer
{
	partial class AddTestCase
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
			this.Add = new System.Windows.Forms.Button();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.ValueBox = new System.Windows.Forms.TextBox();
			this.Cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// Add
			// 
			this.Add.Location = new System.Drawing.Point(226, 64);
			this.Add.Name = "Add";
			this.Add.Size = new System.Drawing.Size(75, 23);
			this.Add.TabIndex = 0;
			this.Add.Text = "Add";
			this.Add.UseVisualStyleBackColor = true;
			this.Add.Click += new System.EventHandler(this.Add_Click);
			// 
			// NameBox
			// 
			this.NameBox.Location = new System.Drawing.Point(54, 12);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(241, 20);
			this.NameBox.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Name";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Value";
			// 
			// ValueBox
			// 
			this.ValueBox.Location = new System.Drawing.Point(54, 38);
			this.ValueBox.Name = "ValueBox";
			this.ValueBox.Size = new System.Drawing.Size(241, 20);
			this.ValueBox.TabIndex = 3;
			// 
			// Cancel
			// 
			this.Cancel.Location = new System.Drawing.Point(12, 64);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(75, 23);
			this.Cancel.TabIndex = 5;
			this.Cancel.Text = "Cancel";
			this.Cancel.UseVisualStyleBackColor = true;
			this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
			// 
			// AddTestCase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(313, 104);
			this.Controls.Add(this.Cancel);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.ValueBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.Add);
			this.Name = "AddTestCase";
			this.Text = "AddTestCase";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button Add;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox ValueBox;
		private System.Windows.Forms.Button Cancel;
	}
}
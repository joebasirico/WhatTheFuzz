namespace WhatTheFuzz
{
	partial class Form1
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
			this.requestInput = new System.Windows.Forms.TextBox();
			this.Begin = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadTestFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.testCasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearAllTestValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.saveSelectedTestCaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAllTestCasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.loadSingleTestCaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.manuallyAddTestCaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveResponseAsHTMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hostName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.regexTestVal = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.proxyValue = new System.Windows.Forms.TextBox();
			this.testValues = new System.Windows.Forms.ListBox();
			this.label4 = new System.Windows.Forms.Label();
			this.HelpLabel = new System.Windows.Forms.Label();
			this.saveReq = new System.Windows.Forms.Button();
			this.URLEncodeAttack = new System.Windows.Forms.CheckBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.responseOutput = new System.Windows.Forms.RichTextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.browser = new System.Windows.Forms.WebBrowser();
			this.invalidRegex = new System.Windows.Forms.ErrorProvider(this.components);
			this.followRedirects = new System.Windows.Forms.CheckBox();
			this.Reset = new System.Windows.Forms.Button();
			this.tabControl2 = new System.Windows.Forms.TabControl();
			this.OriginalRequestTab = new System.Windows.Forms.TabPage();
			this.FuzzedRequestTab = new System.Windows.Forms.TabPage();
			this.fuzzedRequest = new System.Windows.Forms.TextBox();
			this.NextMatch = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.invalidRegex)).BeginInit();
			this.tabControl2.SuspendLayout();
			this.OriginalRequestTab.SuspendLayout();
			this.FuzzedRequestTab.SuspendLayout();
			this.SuspendLayout();
			// 
			// requestInput
			// 
			this.requestInput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.requestInput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.requestInput.Location = new System.Drawing.Point(3, 3);
			this.requestInput.Multiline = true;
			this.requestInput.Name = "requestInput";
			this.requestInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.requestInput.Size = new System.Drawing.Size(666, 141);
			this.requestInput.TabIndex = 2;
			this.requestInput.Text = "[Paste POST Data Here, if left blank a GET request will be made]";
			// 
			// Begin
			// 
			this.Begin.Location = new System.Drawing.Point(841, 571);
			this.Begin.Name = "Begin";
			this.Begin.Size = new System.Drawing.Size(75, 23);
			this.Begin.TabIndex = 3;
			this.Begin.Text = "Begin";
			this.Begin.UseVisualStyleBackColor = true;
			this.Begin.Click += new System.EventHandler(this.Begin_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.testCasesToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(928, 24);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadTestFileToolStripMenuItem,
            this.toolStripSeparator1,
            this.quitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// loadTestFileToolStripMenuItem
			// 
			this.loadTestFileToolStripMenuItem.Name = "loadTestFileToolStripMenuItem";
			this.loadTestFileToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.loadTestFileToolStripMenuItem.Text = "Load Attack String File";
			this.loadTestFileToolStripMenuItem.Click += new System.EventHandler(this.loadTestFileToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(189, 6);
			// 
			// quitToolStripMenuItem
			// 
			this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
			this.quitToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.quitToolStripMenuItem.Text = "Quit";
			this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
			// 
			// testCasesToolStripMenuItem
			// 
			this.testCasesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearAllTestValuesToolStripMenuItem,
            this.toolStripSeparator3,
            this.saveSelectedTestCaseToolStripMenuItem,
            this.saveAllTestCasesToolStripMenuItem,
            this.toolStripSeparator2,
            this.loadSingleTestCaseToolStripMenuItem,
            this.manuallyAddTestCaseToolStripMenuItem});
			this.testCasesToolStripMenuItem.Name = "testCasesToolStripMenuItem";
			this.testCasesToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
			this.testCasesToolStripMenuItem.Text = "Test Cases";
			// 
			// clearAllTestValuesToolStripMenuItem
			// 
			this.clearAllTestValuesToolStripMenuItem.Name = "clearAllTestValuesToolStripMenuItem";
			this.clearAllTestValuesToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
			this.clearAllTestValuesToolStripMenuItem.Text = "Clear All Test Values";
			this.clearAllTestValuesToolStripMenuItem.Click += new System.EventHandler(this.clearAllTestValuesToolStripMenuItem_Click_1);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(230, 6);
			// 
			// saveSelectedTestCaseToolStripMenuItem
			// 
			this.saveSelectedTestCaseToolStripMenuItem.Name = "saveSelectedTestCaseToolStripMenuItem";
			this.saveSelectedTestCaseToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
			this.saveSelectedTestCaseToolStripMenuItem.Text = "Save Selected Test Case to File";
			this.saveSelectedTestCaseToolStripMenuItem.Click += new System.EventHandler(this.saveSelectedTestCaseToolStripMenuItem_Click);
			// 
			// saveAllTestCasesToolStripMenuItem
			// 
			this.saveAllTestCasesToolStripMenuItem.Name = "saveAllTestCasesToolStripMenuItem";
			this.saveAllTestCasesToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
			this.saveAllTestCasesToolStripMenuItem.Text = "Save All Test Cases to File";
			this.saveAllTestCasesToolStripMenuItem.Click += new System.EventHandler(this.saveAllTestCasesToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(230, 6);
			// 
			// loadSingleTestCaseToolStripMenuItem
			// 
			this.loadSingleTestCaseToolStripMenuItem.Name = "loadSingleTestCaseToolStripMenuItem";
			this.loadSingleTestCaseToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
			this.loadSingleTestCaseToolStripMenuItem.Text = "Load Test Case(s) from File";
			this.loadSingleTestCaseToolStripMenuItem.Click += new System.EventHandler(this.loadSingleTestCaseToolStripMenuItem_Click);
			// 
			// manuallyAddTestCaseToolStripMenuItem
			// 
			this.manuallyAddTestCaseToolStripMenuItem.Name = "manuallyAddTestCaseToolStripMenuItem";
			this.manuallyAddTestCaseToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
			this.manuallyAddTestCaseToolStripMenuItem.Text = "Manually Add Test Case";
			this.manuallyAddTestCaseToolStripMenuItem.Click += new System.EventHandler(this.manuallyAddTestCaseToolStripMenuItem_Click);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveResponseAsHTMLToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.toolsToolStripMenuItem.Text = "Tools";
			// 
			// saveResponseAsHTMLToolStripMenuItem
			// 
			this.saveResponseAsHTMLToolStripMenuItem.Name = "saveResponseAsHTMLToolStripMenuItem";
			this.saveResponseAsHTMLToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
			this.saveResponseAsHTMLToolStripMenuItem.Text = "Save Response as HTML";
			this.saveResponseAsHTMLToolStripMenuItem.Click += new System.EventHandler(this.saveResponseAsHTMLToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewHelpToolStripMenuItem,
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// viewHelpToolStripMenuItem
			// 
			this.viewHelpToolStripMenuItem.Name = "viewHelpToolStripMenuItem";
			this.viewHelpToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
			this.viewHelpToolStripMenuItem.Text = "View Help (Online)";
			this.viewHelpToolStripMenuItem.Click += new System.EventHandler(this.viewHelpToolStripMenuItem_Click);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// hostName
			// 
			this.hostName.Location = new System.Drawing.Point(307, 27);
			this.hostName.Name = "hostName";
			this.hostName.Size = new System.Drawing.Size(609, 20);
			this.hostName.TabIndex = 5;
			this.hostName.Text = "http://example.com";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(229, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Request URI:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(229, 574);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(74, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Regex Tester:";
			// 
			// regexTestVal
			// 
			this.regexTestVal.Location = new System.Drawing.Point(309, 571);
			this.regexTestVal.Name = "regexTestVal";
			this.regexTestVal.Size = new System.Drawing.Size(489, 20);
			this.regexTestVal.TabIndex = 7;
			this.regexTestVal.TextChanged += new System.EventHandler(this.regexTestVal_TextChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(229, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(33, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Proxy";
			// 
			// proxyValue
			// 
			this.proxyValue.Location = new System.Drawing.Point(307, 53);
			this.proxyValue.Name = "proxyValue";
			this.proxyValue.Size = new System.Drawing.Size(609, 20);
			this.proxyValue.TabIndex = 9;
			// 
			// testValues
			// 
			this.testValues.FormattingEnabled = true;
			this.testValues.Location = new System.Drawing.Point(12, 82);
			this.testValues.Name = "testValues";
			this.testValues.Size = new System.Drawing.Size(211, 498);
			this.testValues.TabIndex = 11;
			this.testValues.SelectedIndexChanged += new System.EventHandler(this.testValues_SelectedIndexChanged);
			this.testValues.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.testValues_KeyPress);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(229, 88);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(545, 13);
			this.label4.TabIndex = 12;
			this.label4.Text = "Replace the value you\'d like to test with &&val&& and it will be replaced by each" +
				" of the test values in the list to the left";
			// 
			// HelpLabel
			// 
			this.HelpLabel.AutoSize = true;
			this.HelpLabel.Location = new System.Drawing.Point(12, 27);
			this.HelpLabel.Name = "HelpLabel";
			this.HelpLabel.Size = new System.Drawing.Size(181, 52);
			this.HelpLabel.TabIndex = 13;
			this.HelpLabel.Text = "Load test values from the File Menu. \r\n\r\nSelect Items and press delete or \r\n     " +
				"  backspace to remove items.";
			// 
			// saveReq
			// 
			this.saveReq.Location = new System.Drawing.Point(863, 79);
			this.saveReq.Name = "saveReq";
			this.saveReq.Size = new System.Drawing.Size(53, 23);
			this.saveReq.TabIndex = 14;
			this.saveReq.Text = "Save";
			this.saveReq.UseVisualStyleBackColor = true;
			this.saveReq.Click += new System.EventHandler(this.saveReq_Click);
			// 
			// URLEncodeAttack
			// 
			this.URLEncodeAttack.AutoSize = true;
			this.URLEncodeAttack.Checked = true;
			this.URLEncodeAttack.CheckState = System.Windows.Forms.CheckState.Checked;
			this.URLEncodeAttack.Location = new System.Drawing.Point(759, 287);
			this.URLEncodeAttack.Name = "URLEncodeAttack";
			this.URLEncodeAttack.Size = new System.Drawing.Size(157, 17);
			this.URLEncodeAttack.TabIndex = 15;
			this.URLEncodeAttack.Text = "URL Encode Attack Strings";
			this.URLEncodeAttack.UseVisualStyleBackColor = true;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(232, 310);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(684, 255);
			this.tabControl1.TabIndex = 16;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.responseOutput);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(676, 229);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "HTML";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// responseOutput
			// 
			this.responseOutput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.responseOutput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.responseOutput.Location = new System.Drawing.Point(3, 3);
			this.responseOutput.Name = "responseOutput";
			this.responseOutput.Size = new System.Drawing.Size(670, 223);
			this.responseOutput.TabIndex = 2;
			this.responseOutput.Text = "";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.browser);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(676, 229);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Render";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// browser
			// 
			this.browser.AllowWebBrowserDrop = false;
			this.browser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.browser.Location = new System.Drawing.Point(3, 3);
			this.browser.MinimumSize = new System.Drawing.Size(20, 20);
			this.browser.Name = "browser";
			this.browser.ScriptErrorsSuppressed = true;
			this.browser.Size = new System.Drawing.Size(670, 223);
			this.browser.TabIndex = 0;
			// 
			// invalidRegex
			// 
			this.invalidRegex.ContainerControl = this;
			// 
			// followRedirects
			// 
			this.followRedirects.AutoSize = true;
			this.followRedirects.Location = new System.Drawing.Point(649, 287);
			this.followRedirects.Name = "followRedirects";
			this.followRedirects.Size = new System.Drawing.Size(104, 17);
			this.followRedirects.TabIndex = 17;
			this.followRedirects.Text = "Follow Redirects";
			this.followRedirects.UseVisualStyleBackColor = true;
			// 
			// Reset
			// 
			this.Reset.Location = new System.Drawing.Point(804, 79);
			this.Reset.Name = "Reset";
			this.Reset.Size = new System.Drawing.Size(53, 23);
			this.Reset.TabIndex = 18;
			this.Reset.Text = "Reset";
			this.Reset.UseVisualStyleBackColor = true;
			this.Reset.Click += new System.EventHandler(this.Reset_Click);
			// 
			// tabControl2
			// 
			this.tabControl2.Controls.Add(this.OriginalRequestTab);
			this.tabControl2.Controls.Add(this.FuzzedRequestTab);
			this.tabControl2.Location = new System.Drawing.Point(232, 108);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(680, 173);
			this.tabControl2.TabIndex = 19;
			// 
			// OriginalRequestTab
			// 
			this.OriginalRequestTab.Controls.Add(this.requestInput);
			this.OriginalRequestTab.Location = new System.Drawing.Point(4, 22);
			this.OriginalRequestTab.Name = "OriginalRequestTab";
			this.OriginalRequestTab.Padding = new System.Windows.Forms.Padding(3);
			this.OriginalRequestTab.Size = new System.Drawing.Size(672, 147);
			this.OriginalRequestTab.TabIndex = 0;
			this.OriginalRequestTab.Text = "Original Request";
			this.OriginalRequestTab.UseVisualStyleBackColor = true;
			// 
			// FuzzedRequestTab
			// 
			this.FuzzedRequestTab.Controls.Add(this.fuzzedRequest);
			this.FuzzedRequestTab.Location = new System.Drawing.Point(4, 22);
			this.FuzzedRequestTab.Name = "FuzzedRequestTab";
			this.FuzzedRequestTab.Padding = new System.Windows.Forms.Padding(3);
			this.FuzzedRequestTab.Size = new System.Drawing.Size(672, 147);
			this.FuzzedRequestTab.TabIndex = 1;
			this.FuzzedRequestTab.Text = "Fuzzed Request";
			this.FuzzedRequestTab.UseVisualStyleBackColor = true;
			// 
			// fuzzedRequest
			// 
			this.fuzzedRequest.Dock = System.Windows.Forms.DockStyle.Fill;
			this.fuzzedRequest.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.fuzzedRequest.Location = new System.Drawing.Point(3, 3);
			this.fuzzedRequest.Multiline = true;
			this.fuzzedRequest.Name = "fuzzedRequest";
			this.fuzzedRequest.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.fuzzedRequest.Size = new System.Drawing.Size(666, 141);
			this.fuzzedRequest.TabIndex = 3;
			// 
			// NextMatch
			// 
			this.NextMatch.Location = new System.Drawing.Point(804, 571);
			this.NextMatch.Name = "NextMatch";
			this.NextMatch.Size = new System.Drawing.Size(30, 23);
			this.NextMatch.TabIndex = 20;
			this.NextMatch.Text = ">";
			this.NextMatch.UseVisualStyleBackColor = true;
			this.NextMatch.Click += new System.EventHandler(this.NextMatch_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(928, 606);
			this.Controls.Add(this.NextMatch);
			this.Controls.Add(this.tabControl2);
			this.Controls.Add(this.Reset);
			this.Controls.Add(this.followRedirects);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.URLEncodeAttack);
			this.Controls.Add(this.saveReq);
			this.Controls.Add(this.HelpLabel);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.testValues);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.proxyValue);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.regexTestVal);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.hostName);
			this.Controls.Add(this.Begin);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "WhatTheFuzz - a basic fuzzer";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.invalidRegex)).EndInit();
			this.tabControl2.ResumeLayout(false);
			this.OriginalRequestTab.ResumeLayout(false);
			this.OriginalRequestTab.PerformLayout();
			this.FuzzedRequestTab.ResumeLayout(false);
			this.FuzzedRequestTab.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox requestInput;
		private System.Windows.Forms.Button Begin;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadTestFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
		private System.Windows.Forms.TextBox hostName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox regexTestVal;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox proxyValue;
		private System.Windows.Forms.ListBox testValues;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label HelpLabel;
		private System.Windows.Forms.Button saveReq;
		private System.Windows.Forms.CheckBox URLEncodeAttack;
		private System.Windows.Forms.ToolStripMenuItem testCasesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveSelectedTestCaseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveAllTestCasesToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem loadSingleTestCaseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem clearAllTestValuesToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.WebBrowser browser;
		private System.Windows.Forms.ErrorProvider invalidRegex;
		private System.Windows.Forms.ToolStripMenuItem manuallyAddTestCaseToolStripMenuItem;
		private System.Windows.Forms.CheckBox followRedirects;
		private System.Windows.Forms.Button Reset;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewHelpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.TabControl tabControl2;
		private System.Windows.Forms.TabPage OriginalRequestTab;
		private System.Windows.Forms.TabPage FuzzedRequestTab;
		private System.Windows.Forms.TextBox fuzzedRequest;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveResponseAsHTMLToolStripMenuItem;
		private System.Windows.Forms.RichTextBox responseOutput;
		private System.Windows.Forms.Button NextMatch;
	}
}


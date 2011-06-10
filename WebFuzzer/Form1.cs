using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using System.Web;
using System.Net.Sockets;

namespace WhatTheFuzz
{
	public partial class Form1 : Form
	{
		string originalRequest = "";
		public Form1()
		{
			InitializeComponent();
		}

		private void loadTestFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.RestoreDirectory = true;
			ofd.Multiselect = true;
			if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				foreach (string file in ofd.FileNames)
				{
					if (File.Exists(file))
					{
						foreach (string val in File.ReadAllLines(ofd.FileName))
						{
							testValues.Items.Add(new ReqResPair("Not Sent: " + val, val));
						}
					}
				}
			}

			HelpLabel.Text = "";
		}

		private void Begin_Click(object sender, EventArgs e)
		{
			if (requestInput.Text.Contains("&&val&&") || MessageBox.Show("Your request doesn't have a &&val&& replaced value in it. If you click yes you will send "
					+ testValues.Items.Count + " of the same request to the server. Do you want to do that?",
					"No Replacement Value Found", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
					System.Windows.Forms.DialogResult.Yes)
			{

				//move this up here so we can use it later.
				ReqResPair newVal = new ReqResPair("", "");
				List<ReqResPair> values = new List<ReqResPair>();
				foreach (ReqResPair item in testValues.Items)
				{
					values.Add(item);
				}

				foreach (ReqResPair val in values)
				{
					newVal = new ReqResPair(val.Name, val.AttackString);
					//remove it so we can re-add it later
					testValues.Items.Remove(val);

					newVal.Host = hostName.Text;
					newVal.Proxy = proxyValue.Text;
					string attackStr = val.AttackString;
					if (URLEncodeAttack.Checked)
						attackStr = HttpUtility.UrlEncode(attackStr);
					newVal.Request = Regex.Replace(requestInput.Text, "&&val&&", attackStr, RegexOptions.IgnoreCase);
					newVal.Response = SendRequest(newVal.Host, newVal.Request, newVal.Proxy);

					newVal.Name = "Completed: " + newVal.AttackString;
					testValues.Items.Add(newVal);
				}

				tabControl2.SelectTab(1);
				fuzzedRequest.Text = newVal.Request;
				browser.DocumentText = newVal.Response;
				responseOutput.Text = newVal.Response;
			}
		}

		private string SendRequest(string host, string requestBody, string proxy)
		{
			string responseFromServer = "";
			try
			{
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
				request.AllowAutoRedirect = followRedirects.Checked;
				Stream dataStream;
				if (!string.IsNullOrEmpty(proxy))
				{
					request.Proxy = new WebProxy(proxy);
				}
				if (!string.IsNullOrEmpty(requestBody))
				{
					if (requestBody.StartsWith("POST"))
						dataStream = SendCompletePost(requestBody, request);
					else
						dataStream = SendPartialPost(requestBody, request);
				}
				else
					request.Method = "GET";

				WebResponse response = request.GetResponse();
				foreach (string h in response.Headers.AllKeys)
				{
					responseFromServer += h + ": " + response.Headers[h] + "\r\n";
				}
				responseFromServer += "\r\n";

				dataStream = response.GetResponseStream();
				StreamReader reader = new StreamReader(dataStream);
				responseFromServer += reader.ReadToEnd();
				reader.Close();
				dataStream.Close();
				response.Close();
			}
			catch (Exception ex)
			{
				responseFromServer = ex.ToString();
			}
			return responseFromServer;
		}

		private Stream SendCompletePost(string requestBody, HttpWebRequest request)
		{
			Stream dataStream;
			request.Method = "POST";
			foreach (string line in Regex.Split(requestBody, "\r\n"))
			{
				string[] kvp = line.Split(':');
				if (2 == kvp.Length)
				{
					//some headers have to be set using their accessors :S
					if (kvp[0].ToLower() == "accept")
						request.Accept = kvp[1].TrimStart();
					else if (kvp[0].ToLower() == "connection")
						request.Connection = kvp[1].TrimStart();
					else if (kvp[0].ToLower() == "content-type")
						request.ContentType = kvp[1].TrimStart();
					else if (kvp[0].ToLower() == "date")
						request.Date = Convert.ToDateTime(kvp[1]);
					else if (kvp[0].ToLower() == "expect")
						request.Expect = kvp[1].TrimStart();
					else if (kvp[0].ToLower() == "host")
						request.Host = kvp[1].TrimStart();
					else if (kvp[0].ToLower() == "if-modified-since")
						request.IfModifiedSince = Convert.ToDateTime(kvp[1].TrimStart());
					else if (kvp[0].ToLower() == "referer")
						request.Referer = kvp[1].TrimStart();
					else if (kvp[0].ToLower() == "user-agent")
						request.UserAgent = kvp[1].TrimStart();
					else if (!(kvp[0].ToLower() == "content-length" || kvp[0].ToLower() == "proxy-connection"))
						request.Headers.Add(kvp[0], kvp[1].TrimStart());

				}
			}

			Match cl = Regex.Match(requestBody, "Content-Length: \\d+");
			int headerOffset = cl.Index + cl.Length;
			byte[] byteArray = Encoding.UTF8.GetBytes(requestBody.Substring(headerOffset).TrimStart());
			request.ContentLength = byteArray.Length;
			dataStream = request.GetRequestStream();
			dataStream.Write(byteArray, 0, byteArray.Length);
			dataStream.Close();
			return dataStream;
		}

		private static Stream SendPartialPost(string requestBody, HttpWebRequest request)
		{
			Stream dataStream;
			request.Method = "POST";
			byte[] byteArray = Encoding.UTF8.GetBytes(requestBody);
			request.ContentType = "application/x-www-form-urlencoded";
			request.ContentLength = byteArray.Length;
			dataStream = request.GetRequestStream();
			dataStream.Write(byteArray, 0, byteArray.Length);
			dataStream.Close();
			return dataStream;
		}

		private void testValues_SelectedIndexChanged(object sender, EventArgs e)
		{
			ReqResPair selectedVal = (ReqResPair)testValues.SelectedItem;
			if (null != selectedVal)
			{
				//replace host, proxy, req and response with the selected value
				fuzzedRequest.Text = selectedVal.Request;
				responseOutput.Text = selectedVal.Response;
				browser.DocumentText = selectedVal.Response;
				hostName.Text = selectedVal.Host;
				proxyValue.Text = selectedVal.Proxy;
			}
		}

		private void testValues_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\b' && -1 != testValues.SelectedIndex)
			{
				int curIndex = testValues.SelectedIndex;

				testValues.Items.RemoveAt(testValues.SelectedIndex);
				if (testValues.Items.Count > curIndex)
					testValues.SelectedIndex = curIndex;
				else if (testValues.Items.Count > 0)
					testValues.SelectedIndex = curIndex - 1;

			}
		}

		private void saveReq_Click(object sender, EventArgs e)
		{
			ReqName rn = new ReqName();
			if (rn.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				ReqResPair newRRP = new ReqResPair(rn.name, "");
				if (rn.saveRequest)
					newRRP.Request = requestInput.Text;
				if (rn.saveResponse)
					newRRP.Response = responseOutput.Text;
				if (rn.saveURI)
					newRRP.Host = hostName.Text;
				if (rn.saveProxy)
					newRRP.Proxy = proxyValue.Text;

				testValues.Items.Insert(0, newRRP);
			}
		}

		private void quitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void saveSelectedTestCaseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (testValues.SelectedIndex != -1)
			{
				ReqResPair rrp = (ReqResPair)testValues.SelectedValue;
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.RestoreDirectory = true;
				sfd.Filter = "WhatTheFuzz Files (*.wtf)|*.wtf|All files (*.*)|*.*";
				if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					string testCase = GenerateTestCaseString(rrp);
					File.WriteAllText(sfd.FileName, testCase);
				}
			}
			else
			{
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.RestoreDirectory = true;
				sfd.Filter = "WhatTheFuzz Files (*.wtf)|*.wtf|All files (*.*)|*.*";
				if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					string testCase = Base64Encode("NoName") + "|" +
						Base64Encode("") + "|" +
						Base64Encode(hostName.Text) + "|" +
						Base64Encode(proxyValue.Text) + "|" +
						Base64Encode(requestInput.Text) + "|" +
						Base64Encode(responseOutput.Text);
					File.WriteAllText(sfd.FileName, testCase);
				}
			}
		}

		private string Base64Encode(string str)
		{
			return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(str));
		}

		public static string Base64Decode(string str)
		{
			try
			{
				byte[] toDecodeByte = Convert.FromBase64String(str);

				System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
				System.Text.Decoder utf8Decode = encoder.GetDecoder();

				int charCount = utf8Decode.GetCharCount(toDecodeByte, 0, toDecodeByte.Length);

				char[] decodedChar = new char[charCount];
				utf8Decode.GetChars(toDecodeByte, 0, toDecodeByte.Length, decodedChar, 0);
				return new String(decodedChar);
			}
			catch
			{
				return "Invalid input: This does not seem to be a valid Base64 encoded string. Try adding an equals or two on the end ;)";
			}
		}

		private void saveAllTestCasesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.RestoreDirectory = true;
			sfd.Filter = "WhatTheFuzz Files (*.wtf)|*.wtf|All files (*.*)|*.*";
			if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				StringBuilder sb = new StringBuilder();
				foreach (ReqResPair rrp in testValues.Items)
				{
					sb.Append(GenerateTestCaseString(rrp) + "&");
				}
				File.WriteAllText(sfd.FileName, sb.ToString());
			}
		}

		private string GenerateTestCaseString(ReqResPair rrp)
		{
			string testCase = Base64Encode(rrp.Name) + "|" +
					Base64Encode(rrp.AttackString) + "|" +
					Base64Encode(rrp.Host) + "|" +
					Base64Encode(rrp.Proxy) + "|" +
					Base64Encode(rrp.Request) + "|" +
					Base64Encode(rrp.Response);

			return testCase;
		}


		private void loadSingleTestCaseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.RestoreDirectory = true;
			ofd.Filter = "WhatTheFuzz Files (*.wtf)|*.wtf|All files (*.*)|*.*";

			if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				string file = File.ReadAllText(ofd.FileName);
				if (file.Contains("&"))
				{
					string[] testCases = file.Split('&');
					foreach (string testCase in testCases)
					{
						testValues.Items.Add(ParseTestCase(testCase));
					}
				}
				else
				{
					ReqResPair lastLoaded = ParseTestCase(file);
					testValues.Items.Add(lastLoaded);
					if (MessageBox.Show("Do you want to load this test case into the window? If you select No the request will be loaded into the testcases list on the left.", "Replace existing informaiton?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
					{
						requestInput.Text = lastLoaded.Request;
						hostName.Text = lastLoaded.Host;
						proxyValue.Text = lastLoaded.Proxy;
						responseOutput.Text = lastLoaded.Response;
						browser.DocumentText = lastLoaded.Response;
					}
				}
			}
		}

		private ReqResPair ParseTestCase(string testCase)
		{
			ReqResPair item = new ReqResPair("", "");
			string[] pieces = testCase.Split('|');
			if (pieces.Length == 6)
			{
				item = new ReqResPair(Base64Decode(pieces[0]), Base64Decode(pieces[1]));
				item.Host = Base64Decode(pieces[2]);
				item.Proxy = Base64Decode(pieces[3]);
				item.Request = Base64Decode(pieces[4]);
				item.Response = Base64Decode(pieces[5]);
			}
			return item;
		}

		private void clearAllTestValuesToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			if (MessageBox.Show("This will remove all the values from the left column of test cases. \r\n\r\nAre you sure you want to do that?",
				"Warning, you're about to delete your test cases", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
			{
				tabControl2.SelectTab(0);
				testValues.Items.Clear();
				fuzzedRequest.Text = "";
				responseOutput.Text = "";
				browser.DocumentText = "";
			}
		}

		private void responseOutput_TextChanged(object sender, EventArgs e)
		{
			CheckResponse(0);
		}

		private void CheckResponse(int startLocation)
		{
			try
			{
				string text = responseOutput.Text;
				responseOutput.ResetText();
				responseOutput.Text = text;
				invalidRegex.SetError(regexTestVal, "");
				if (!string.IsNullOrEmpty(regexTestVal.Text))
				{
					Match m = Regex.Match(responseOutput.Text.Substring(startLocation),
						regexTestVal.Text, RegexOptions.IgnoreCase | RegexOptions.Multiline);
					if (m.Captures.Count > 0)
					{
						responseOutput.SelectionStart = m.Index + startLocation;
						responseOutput.SelectionLength = m.Length;
						responseOutput.BackColor = Color.LightGreen;
						responseOutput.ScrollToCaret();
						responseOutput.SelectionFont = new Font(responseOutput.SelectionFont, FontStyle.Bold | FontStyle.Underline);
					}
					else
						responseOutput.BackColor = Color.White;
				}
				else
				{
					ReqResPair rrp = (ReqResPair)testValues.SelectedValue;
					if (null != rrp)
					{
						if (responseOutput.Text.Contains(rrp.AttackString))
							responseOutput.BackColor = Color.LightGreen;
						else
							responseOutput.BackColor = Color.White;
					}
					else
						responseOutput.BackColor = Color.White;
				}
			}
			catch (Exception ex)
			{
				invalidRegex.SetError(regexTestVal, ex.Message);
			}
		}

		private void regexTestVal_TextChanged(object sender, EventArgs e)
		{
			CheckResponse(0);
		}

		private void manuallyAddTestCaseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AddTestCase atc = new AddTestCase();
			if (atc.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				ReqResPair rrp = new ReqResPair(atc.Name, atc.Value);
				testValues.Items.Add(rrp);
			}
		}

		private void Reset_Click(object sender, EventArgs e)
		{
			requestInput.Text = originalRequest;
			responseOutput.Text = "";
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AboutBox1 ab = new AboutBox1();
			ab.Show();
		}

		private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/SecurityInnovation/WhatTheFuzz");
		}

		private void saveResponseAsHTMLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "HTML Files (*.html)|*.html|All files (*.*)|*.*";
			if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				File.WriteAllText(sfd.FileName, responseOutput.Text);
			}
		}

		private void NextMatch_Click(object sender, EventArgs e)
		{
			CheckResponse(responseOutput.SelectionStart + 1);
			if (responseOutput.SelectionLength == 0)
				CheckResponse(0);
		}

		private void highlightAllMatchingTestValuesmayTakeAWhileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(regexTestVal.Text))
			{
				List<ReqResPair> values = new List<ReqResPair>();
				foreach (ReqResPair item in testValues.Items)
				{
					values.Add(item);
				}

				foreach (ReqResPair rrp in values)
				{
					ReqResPair newVal = CloneRRP(rrp);
					if (Regex.IsMatch(rrp.Response, regexTestVal.Text))
						newVal.Name = "*" + newVal.Name;
					testValues.Items.Add(newVal);
				}
			}
		}

		private ReqResPair CloneRRP(ReqResPair rrp)
		{
			ReqResPair newVal = new ReqResPair(rrp.Name, rrp.AttackString);
			//remove it so we can re-add it later
			testValues.Items.Remove(rrp);
			newVal.Host = rrp.Host;
			newVal.Proxy = rrp.Proxy;
			newVal.AttackString = rrp.AttackString;
			newVal.Request = rrp.Request;
			newVal.Response = rrp.Response;
			return newVal;
		}

		private void clearHighligtedResultsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			List<ReqResPair> values = new List<ReqResPair>();
			foreach (ReqResPair item in testValues.Items)
			{
				values.Add(item);
			}

			foreach (ReqResPair rrp in values)
			{
				ReqResPair newVal = CloneRRP(rrp);
				if (rrp.Name.StartsWith("*"))
					newVal.Name = newVal.Name.Substring(1);
				testValues.Items.Add(newVal);
			}
		}

		private void requestInput_TextChanged(object sender, EventArgs e)
		{
			try
			{
				int caretLoc = requestInput.SelectionStart;
				string currText = requestInput.Text;
				requestInput.ResetText();
				requestInput.Text = currText;
				foreach (Match m in Regex.Matches(requestInput.Text, "&&val&&", RegexOptions.IgnoreCase))
				{
					requestInput.SelectionStart = m.Index;
					requestInput.SelectionLength = m.Length;
					requestInput.SelectionFont = new Font(responseOutput.SelectionFont, FontStyle.Bold | FontStyle.Underline);
				}

				requestInput.SelectionStart = caretLoc;
				requestInput.SelectionLength = 0;
			}
			catch
			{
			}
		}
	}
}

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

namespace WebFuzzer
{
	public partial class Form1 : Form
	{
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
				ReqResPair currVal = val;
				//remove it so we can re-add it later
				testValues.Items.Remove(val);

				newVal.Host = hostName.Text;
				newVal.Proxy = proxyValue.Text;
				string attackStr = currVal.AttackString;
				if (URLEncodeAttack.Checked)
					attackStr = HttpUtility.UrlEncode(attackStr);
				newVal.Request = requestInput.Text.Replace("&&val&&", attackStr);
				newVal.Response = SendRequest(newVal.Host, newVal.Request, newVal.Proxy);

				newVal.Name = "Completed: " + newVal.AttackString;
				testValues.Items.Add(newVal);
			}
			browser.DocumentText = newVal.Response;
			responseOutput.Text = newVal.Response;
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
					request.Method = "POST";
					byte[] byteArray = Encoding.UTF8.GetBytes(requestBody);
					request.ContentType = "application/x-www-form-urlencoded";
					request.ContentLength = byteArray.Length;
					dataStream = request.GetRequestStream();
					dataStream.Write(byteArray, 0, byteArray.Length);
					dataStream.Close();
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

		private void testValues_SelectedIndexChanged(object sender, EventArgs e)
		{
			ReqResPair selectedVal = (ReqResPair)testValues.SelectedItem;
			if (null != selectedVal)
			{
				//replace host, proxy, req and response with the selected value
				requestInput.Text = selectedVal.Request;
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
				sfd.Filter = "WebFuzzer Files (*.wff)|*.wff|All files (*.*)|*.*";
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
				sfd.Filter = "WebFuzzer Files (*.wff)|*.wff|All files (*.*)|*.*";
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
			sfd.Filter = "WebFuzzer Files (*.wff)|*.wff|All files (*.*)|*.*";
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
			ofd.Filter = "WebFuzzer Files (*.wff)|*.wff|All files (*.*)|*.*";
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
					testValues.Items.Add(ParseTestCase(file));
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
				testValues.Items.Clear();
		}

		private void responseOutput_TextChanged(object sender, EventArgs e)
		{
			CheckResponse();
		}

		private void CheckResponse()
		{
			try
			{
				invalidRegex.SetError(regexTestVal, "");
				//at this point newVal has been filled with data
				if (!string.IsNullOrEmpty(regexTestVal.Text))
				{
					if (Regex.IsMatch(responseOutput.Text, regexTestVal.Text))
						responseOutput.BackColor = Color.LightGreen;
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
			CheckResponse();
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
	}
}

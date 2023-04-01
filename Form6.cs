using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bubble_admin
{
    public partial class Form6 : Form
    {
        public bool IsLoggedIn { get; private set; }
        public Form6()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            if (!ValidateLogin())
            {
                return;
            }

            // Create JSON object from parameters
            JObject requestObject = new JObject();
            requestObject["email"] = txtEmailSignin.Text;
            requestObject["password"] = txtPasswordSignin.Text;
            string json = JsonConvert.SerializeObject(requestObject);

            // Send HTTP request with Authorization header and request body
            using (var client = new HttpClient())
            {
                // Set request method to POST
                HttpMethod httpMethod = HttpMethod.Post;

                // Create request message
                HttpRequestMessage request = new HttpRequestMessage(httpMethod, $"{Properties.Settings.Default.baseurl}{Properties.Settings.Default.wfurl}{"sign_in"}");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Properties.Settings.Default.apitoken);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                // Send request and get response
                HttpResponseMessage response = await client.SendAsync(request);

                // Process response
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    JObject responseObject = JObject.Parse(responseContent);                   
                    bool isBaPaid = (bool)responseObject["response"]["ba_status"];

                    if (isBaPaid)
                    {
                        IsLoggedIn = true; // Set the IsLoggedIn property to true
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Your account is not paid. Please contact support.");                                          
                    }

                }
                else
                {
                    MessageBox.Show("Sign in failed with status code: " + response.StatusCode);
                }
            }
        }
        private bool ValidateLogin()
        {
            if (string.IsNullOrEmpty(txtEmailSignin.Text))
            {
                MessageBox.Show("Please enter your email.");
                return false;
            }

            if (string.IsNullOrEmpty(txtPasswordSignin.Text))
            {
                MessageBox.Show("Please enter your password.");
                return false;
            }

            return true;
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.None)
            {
                IsLoggedIn = false; // Set the IsLoggedIn property to false
            }
        }


        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("https://thirdsoft.io");
            psi.UseShellExecute = true;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
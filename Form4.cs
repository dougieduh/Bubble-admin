using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace Bubble_admin
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void btnAddParameter_Click(object sender, EventArgs e)
        {
            string key = tbParameter.Text;
            string value = tbParameterValue.Text;

            // Add key-value pair to ListBox
            lbParameters.Items.Add(key + ": " + value);
            tbParameter.Clear();
            tbParameterValue.Clear();
        }

        private async void btnRunWf_Click(object sender, EventArgs e)
        {
            // Create JSON object from ListBox items
            JObject requestObject = new JObject();
            foreach (var item in lbParameters.Items)
            {
                string[] parts = item.ToString().Split(':');
                string key = parts[0].Trim();
                string value = parts[1].Trim();
                requestObject[key] = value;
            }
            string json = JsonConvert.SerializeObject(requestObject);

            // Send HTTP request with Authorization header and request body
            using (var client = new HttpClient())
            {
                // Set request method based on selected ComboBox item
                string method = cbMethod.SelectedItem.ToString();
                HttpMethod httpMethod = new HttpMethod(method);

                // Create request message
                HttpRequestMessage request = new HttpRequestMessage(httpMethod, $"{Properties.Settings.Default.baseurl}{Properties.Settings.Default.wfurl}{tbWorkflowName.Text}");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Properties.Settings.Default.apitoken);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                // Send request and get response
                HttpResponseMessage response = await client.SendAsync(request);

                // Process response
                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Request succeeded: " + responseString);
                }
                else
                {
                    MessageBox.Show("Request failed with status code: " + response.StatusCode);
                }
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
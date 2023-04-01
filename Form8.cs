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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            LoadData(); 
        }
        private async void LoadData()
        {
            try
            {
               // string appType = tbSetType.Text.ToLower().Replace(" ", "");

                // Create an HttpClient object with the base URL and Bearer token authentication
                var client = new HttpClient();
                client.BaseAddress = new Uri(Properties.Settings.Default.baseurl);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Properties.Settings.Default.thirdToken);

                // Make an HTTP GET request to the API endpoint and retrieve the response
                var response = await client.GetAsync(client.BaseAddress + Properties.Settings.Default.dataurl + "ticketsystem");

                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response content into a dynamic object
                    var content = await response.Content.ReadAsStringAsync();
                    dynamic data = JsonConvert.DeserializeObject(content);

                    // Extract all the property names from the JSON objects
                    var propertyNames = new HashSet<string>();
                    foreach (var result in data.response.results)
                    {
                        foreach (JProperty property in result)
                        {
                            if (!propertyNames.Contains(property.Name) && property.Name != "user_signed_up")
                            {
                                propertyNames.Add(property.Name);
                            }
                        }
                    }

                    // Clear existing columns from the DataGridView
                    dgvTickets.Columns.Clear();
                    dgvTickets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                    // Set the column headers to the property names from the response object
                    foreach (var propertyName in propertyNames)
                    {
                        if (propertyName == "authentication")
                        {
                            dgvTickets.Columns.Add("email", "Email");
                        }
                        else
                        {
                            var column = new DataGridViewTextBoxColumn();
                            column.HeaderText = propertyName;
                            column.Name = propertyName;
                            column.DataPropertyName = propertyName;
                            dgvTickets.Columns.Add(column);
                        }
                    }

                    if (dgvTickets.Columns.Contains("Email"))
                    {
                        dgvTickets.Columns["Email"].DataPropertyName = "authentication";
                    }


                    // Add each row of data to the DataGridView
                    foreach (var result in data.response.results)
                    {
                        var row = new DataGridViewRow();

                        foreach (var propertyName in propertyNames)
                        {
                            var cell = new DataGridViewTextBoxCell();

                            if (propertyName == "authentication" && ((IDictionary<string, JToken>)result).ContainsKey(propertyName))
                            {
                                cell.Value = ((IDictionary<string, JToken>)result)[propertyName]["email"]["email"].ToString();
                            }
                            else if (((IDictionary<string, JToken>)result).ContainsKey(propertyName))
                            {
                                cell.Value = ((IDictionary<string, JToken>)result)[propertyName];
                            }

                            row.Cells.Add(cell);
                        }

                        dgvTickets.Rows.Add(row);
                    }

                }
                else
                {
                    // Display an error message if the API request fails
                    MessageBox.Show("Failed to load data from API: " + response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs
                MessageBox.Show("An error occurred while loading data: " + ex.Message);
            }
        }
    }
}

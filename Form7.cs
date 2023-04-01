using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bubble_admin
{
    public partial class Form7 : Form
    {
        private string selectedUserId;
        public Form7(string selectedUserId)

        {
            InitializeComponent();
            this.selectedUserId = selectedUserId;
            label1.Text = "User " + selectedUserId;
        }     

        private void Form7_Load(object sender, EventArgs e)
        {                        
          

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Generate a unique ticket number
                string ticketNumber = DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(10000, 99999);

                // Get the issue description from the textbox
                string issueDescription = textBox1.Text;

                // Check if a user has been selected
                if (string.IsNullOrEmpty(this.selectedUserId))
                {
                    MessageBox.Show("Please select a user first.");
                    return;
                }

                // Create a dictionary with the request parameters
                var data = new Dictionary<string, string>
        {
            { "Ticket Number", ticketNumber },
            { "Issue Description", issueDescription },
            { "Status", "open" },
            { "Affected User ID", this.selectedUserId }
        };

                // Convert the dictionary to a JSON string
                var json = JsonConvert.SerializeObject(data);

                // Create a new StringContent object with the JSON data
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Create an HttpClient object with the base URL and Bearer token authentication
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://thirdsoft.io/api/1.1/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Properties.Settings.Default.thirdToken);

                // Make a POST request to the API endpoint to create a new ticket
                var response = await client.PostAsync("obj/ticketsystem", content);

                if (response.IsSuccessStatusCode)
                {
                    // The ticket was created successfully
                    // Display a message to confirm that the ticket was created and show the ticket number
                    MessageBox.Show($"Ticket created successfully. Ticket number: {ticketNumber}");
                }
                else
                {
                    // Display an error message if the API request fails
                    MessageBox.Show("Failed to create ticket: " + response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs
                MessageBox.Show("An error occurred while creating the ticket: " + ex.Message);
            }

            // Set the issueDescription textbox to empty string
            textBox1.Text = "";
        }
    }
}
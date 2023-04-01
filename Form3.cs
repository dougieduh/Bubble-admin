using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using Stripe;

namespace Bubble_admin
{
    public partial class Form3 : Form
    {
        public int currentCursor = 0;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private async void LoadData(int cursor = 0)
        {
            try
            {
                string appType = tbSetType.Text.ToLower().Replace(" ", "");

                // Create an HttpClient object with the base URL and Bearer token authentication
                var client = new HttpClient();
                client.BaseAddress = new Uri(Properties.Settings.Default.baseurl);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Properties.Settings.Default.apitoken);

                // Make an HTTP GET request to the API endpoint and retrieve the response
                var response = await client.GetAsync(client.BaseAddress + Properties.Settings.Default.dataurl + appType + $"?cursor={cursor}&count=100");

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
                    dgvCustom.Columns.Clear();
                    dgvCustom.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                    // Set the column headers to the property names from the response object
                    foreach (var propertyName in propertyNames)
                    {
                        if (propertyName == "authentication")
                        {
                            dgvCustom.Columns.Add("email", "Email");
                        }
                        else
                        {
                            var column = new DataGridViewTextBoxColumn();
                            column.HeaderText = propertyName;
                            column.Name = propertyName;
                            column.DataPropertyName = propertyName;
                            dgvCustom.Columns.Add(column);
                        }
                    }

                    if (dgvCustom.Columns.Contains("Email"))
                    {
                        dgvCustom.Columns["Email"].DataPropertyName = "authentication";
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

                        dgvCustom.Rows.Add(row);
                    }

                }
                else
                {
                    // Display an error message if the API request fails
                    MessageBox.Show("Failed to load data from API: " + response.ReasonPhrase);
                }
                currentCursor = cursor;
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs
                MessageBox.Show("An error occurred while loading data: " + ex.Message);
            }
        }

        private async void dgvCustom_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string appType = tbSetType.Text.ToLower().Replace(" ", "");
                // Get the updated row from the DataGridView
                var row = dgvCustom.Rows[e.RowIndex];

                // Get the _id value of the user to update
                var _id = row.Cells["_id"].Value.ToString();

                // Create a new Dictionary to hold the updated data
                var data = new Dictionary<string, object>();

                // Add each column value to the dictionary
                foreach (DataGridViewColumn col in dgvCustom.Columns)
                {
                    data[col.DataPropertyName] = row.Cells[col.Index].Value;
                }

                // Remove the _id value from the dictionary (we don't want to include it in the request body)
                data.Remove("_id");
                data.Remove("authentication");
                data.Remove("Created Date");
                data.Remove("Created By");
                data.Remove("Modified Date");
                data.Remove("user_signed_up");

                // Convert the dictionary to a JSON string
                var json = JsonConvert.SerializeObject(data);

                // Create a new StringContent object with the JSON data
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Create an HttpClient object with the base URL and Bearer token authentication
                var client = new HttpClient();
                client.BaseAddress = new Uri(Properties.Settings.Default.baseurl);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Properties.Settings.Default.apitoken);

                // Make a PATCH request to the API endpoint to update the user
                var response = await client.PatchAsync(Properties.Settings.Default.dataurl + appType + "/" + _id, content);

                if (response.IsSuccessStatusCode)
                {
                    // The user was updated successfully
                    // Reload the data to reflect the changes in the DataGridView
                    LoadData();
                }
                else
                {
                    // Display an error message if the API request fails
                    MessageBox.Show("Failed to update user: " + response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs
                MessageBox.Show("An error occurred while updating data: " + ex.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // Create a new Excel workbook and worksheet
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.Sheets[1];

            // Write the column headers to the first row of the worksheet
            int colIndex = 1;
            foreach (DataGridViewColumn col in dgvCustom.Columns)
            {
                worksheet.Cells[1, colIndex] = col.HeaderText;
                colIndex++;
            }

            // Write the data to the worksheet
            int rowIndex = 2;
            foreach (DataGridViewRow row in dgvCustom.Rows)
            {
                colIndex = 1;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null)
                    {
                        worksheet.Cells[rowIndex, colIndex] = cell.Value.ToString();
                    }
                    colIndex++;
                }
                rowIndex++;
            }

            // Save the workbook to a file
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
            saveDialog.FileName = tbSetType.Text + ".xlsx";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveDialog.FileName);
            }

            // Close the workbook and release the COM objects
            workbook.Close(false);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);

            // Quit the Excel application and release the COM objects
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower(); // get the search text and convert to lowercase

            for (int i = 0; i < dgvCustom.Columns.Count; i++) // loop through each column
            {
                DataGridViewColumn column = dgvCustom.Columns[i];
                if (column.Visible) // check if the column is visible
                {
                    foreach (DataGridViewRow row in dgvCustom.Rows) // loop through each row
                    {
                        if (row.Cells[column.Index].Value != null && row.Cells[column.Index].Value.ToString().ToLower().Contains(searchText)) // check if the cell value contains the search text
                        {
                            dgvCustom.CurrentCell = row.Cells[column.Index]; // set the current cell to the found cell
                            return; // stop searching once a match is found
                        }
                    }
                }
            }
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Get the value of the _id column for the selected row in the DataGridView
                string id = dgvCustom.CurrentRow.Cells["_id"].Value.ToString();

                // Prompt the user to confirm the deletion
                var confirmResult = MessageBox.Show($"Are you sure you want to delete this {tbSetType.Text}?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    // Create an HttpClient object with the base URL and Bearer token authentication
                    var client = new HttpClient();
                    client.BaseAddress = new Uri(Properties.Settings.Default.baseurl);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Properties.Settings.Default.apitoken);

                    // Make an HTTP DELETE request to the API endpoint with the _id value in the URL
                    var response = await client.DeleteAsync(client.BaseAddress + Properties.Settings.Default.dataurl + tbSetType.Text + "/" + id);

                    if (response.IsSuccessStatusCode)
                    {
                        // Remove the row from the DataGridView with the matching _id value
                        foreach (DataGridViewRow row in dgvCustom.Rows)
                        {
                            if (row.Cells["_id"].Value.ToString() == id)
                            {
                                dgvCustom.Rows.Remove(row);
                                break;
                            }
                        }
                    }
                    else
                    {
                        // Display an error message if the API request fails
                        MessageBox.Show("Failed to delete user: " + response.ReasonPhrase);
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs
                MessageBox.Show("An error occurred while deleting user: " + ex.Message);
            }
        }

        private async void button1_Click_2(object sender, EventArgs e)
        {
            if (dgvCustom.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select a cell containing a charge or payment intent ID.");
                return;
            }

            var selectedCell = dgvCustom.SelectedCells[0];
            string chargeOrPaymentIntentId = selectedCell.Value.ToString();

            try
            {
                StripeConfiguration.ApiKey = Properties.Settings.Default.stripeSecret; // Replace this with your Stripe API key

                if (chargeOrPaymentIntentId.StartsWith("ch_"))
                {
                    // Refund a charge
                    var refundOptions = new RefundCreateOptions
                    {
                        Charge = chargeOrPaymentIntentId,
                    };
                    var refundService = new RefundService();
                    Refund refund = await refundService.CreateAsync(refundOptions);
                    MessageBox.Show($"Refund created: {refund.Id}");
                }
                else if (chargeOrPaymentIntentId.StartsWith("pi_"))
                {
                    // Refund a payment intent
                    var chargeService = new ChargeService();
                    var chargeListOptions = new ChargeListOptions
                    {
                        PaymentIntent = chargeOrPaymentIntentId,
                    };
                    var charges = await chargeService.ListAsync(chargeListOptions);

                    if (charges.Count() > 0)
                    {
                        var charge = charges.FirstOrDefault();
                        var refundOptions = new RefundCreateOptions
                        {
                            Charge = charge.Id,
                        };
                        var refundService = new RefundService();
                        Refund refund = await refundService.CreateAsync(refundOptions);
                        MessageBox.Show($"Refund created: {refund.Id}");
                    }
                    else
                    {
                        MessageBox.Show("No charges associated with this payment intent.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid charge or payment intent ID.");
                }
            }
            catch (StripeException ex)
            {
                MessageBox.Show($"Stripe error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while processing the refund: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentCursor - 100 >= 0)
            {
                currentCursor -= 100;
                LoadData(currentCursor);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            currentCursor += 100;
            LoadData(currentCursor);
        }
    }
}
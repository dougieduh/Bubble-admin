using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace Bubble_admin
{
    public partial class Form1 : Form

    {
        public string selectedUserId = "";
        public int currentCursor = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblNumberOfUsers.Text = string.Empty;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private async void LoadData(int cursor = 0)
        {
            try
            {
                // Create an HttpClient object with the base URL and Bearer token authentication
                var client = new HttpClient();
                client.BaseAddress = new Uri(Properties.Settings.Default.baseurl);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Properties.Settings.Default.apitoken);

                // Make an HTTP GET request to the API endpoint and retrieve the response
                var response = await client.GetAsync(client.BaseAddress + Properties.Settings.Default.dataurl + $"user?cursor={cursor}&count=100");

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
                    dgvUsersInfo.Columns.Clear();
                    dgvUsersInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                    // Set the column headers to the property names from the response object
                    foreach (var propertyName in propertyNames)
                    {
                        if (propertyName == "authentication")
                        {
                            dgvUsersInfo.Columns.Add("email", "Email");
                        }
                        else
                        {
                            var column = new DataGridViewTextBoxColumn();
                            column.HeaderText = propertyName;
                            column.Name = propertyName;
                            column.DataPropertyName = propertyName;
                            dgvUsersInfo.Columns.Add(column);
                        }
                    }
                    // Set the DataPropertyName property for the "Email" column
                    dgvUsersInfo.Columns["Email"].DataPropertyName = "authentication";

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

                        dgvUsersInfo.Rows.Add(row);
                    }

                    // Update the label with the number of users
                    try
                    {
                        lblNumberOfUsers.Text = string.Format("Number of users: {0}", dgvUsersInfo.Rows.Count);
                    } catch(Exception ex)
                    {
                        currentCursor -= 100;
                        MessageBox.Show("An error occurred while loading data: " + ex.Message);
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

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void dgvUsersInfo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Get the updated row from the DataGridView
                var row = dgvUsersInfo.Rows[e.RowIndex];

                // Get the _id value of the user to update
                var userId = row.Cells["_id"].Value.ToString();

                // Create a new Dictionary to hold the updated data
                var data = new Dictionary<string, object>();

                // Add each column value to the dictionary
                foreach (DataGridViewColumn col in dgvUsersInfo.Columns)
                {
                    data[col.DataPropertyName] = row.Cells[col.Index].Value;
                }

                // Remove the _id value from the dictionary (we don't want to include it in the request body)
                data.Remove("_id");
                data.Remove("authentication");
                data.Remove("Created Date");
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
                var response = await client.PatchAsync(Properties.Settings.Default.dataurl + "user/" + userId, content);

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.ToLower();
            foreach (DataGridViewRow row in dgvUsersInfo.Rows)
            {
                string email = row.Cells["Email"].Value.ToString().ToLower();
                if (email.Contains(searchValue))
                {
                    row.Visible = true;
                }
                else
                {
                    HideRow(row);
                }
            }
        }
        private void HideRow(DataGridViewRow row)
        {
            // Deselect the current cell to avoid "Row associated with the currency manager's position cannot be made invisible" exception
            dgvUsersInfo.CurrentCell = null;

            // Hide the row
            row.Visible = false;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // Create a new Excel workbook and worksheet
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.Sheets[1];

            // Write the column headers to the first row of the worksheet
            int colIndex = 1;
            foreach (DataGridViewColumn col in dgvUsersInfo.Columns)
            {
                worksheet.Cells[1, colIndex] = col.HeaderText;
                colIndex++;
            }

            // Write the data to the worksheet
            int rowIndex = 2;
            foreach (DataGridViewRow row in dgvUsersInfo.Rows)
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
            saveDialog.FileName = "users.xlsx";
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

        private void bubbleAppDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void bubbleBackendWorkflowRunnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }

        private void bulkDataUploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            // Check if any rows are selected
            if (dgvUsersInfo.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row first.");
            }
            else
            {
                // Save the _id field of the selected row to a variable
                DataGridViewRow selectedRow = dgvUsersInfo.SelectedRows[0];
                DataGridViewCell idCell = selectedRow.Cells["_id"];
                selectedUserId = idCell.Value.ToString();
                Form7 form7 = new Form7(selectedUserId);
                form7.ShowDialog();
            }
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            LoadData();
            btnExport.Visible = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e) // Previous data
        {

            if (currentCursor - 100 >= 0)
            {
                currentCursor -= 100;
                LoadData(currentCursor);
            }
        }

        private void button5_Click(object sender, EventArgs e) // Next data
        {
            currentCursor += 100;
            LoadData(currentCursor);
        }
    }
}
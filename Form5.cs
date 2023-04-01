using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Application = Microsoft.Office.Interop.Excel.Application;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace Bubble_admin
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbExcelFile.Text = openFileDialog.FileName;
            }
        }

        private async void btnUpload_Click(object sender, EventArgs e)
        {
            // Open Excel file
            Application excel = new Application();
            Workbook workbook = excel.Workbooks.Open(tbExcelFile.Text);
            Worksheet worksheet = workbook.Sheets[1];
            Range range = worksheet.UsedRange;

            // Parse data in each row into a dictionary
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            for (int row = 2; row <= range.Rows.Count; row++)
            {
                Dictionary<string, object> rowValues = new Dictionary<string, object>();
                for (int col = 1; col <= range.Columns.Count; col++)
                {
                    string fieldName = ((Range)worksheet.Cells[1, col]).Value.ToString();
                    object fieldValue = ((Range)worksheet.Cells[row, col]).Value;
                    rowValues[fieldName] = fieldValue;
                }
                data.Add(rowValues);
            }

            // Serialize list of new things to text document with one JSON object per line
            StringBuilder requestBodyBuilder = new StringBuilder();
            foreach (Dictionary<string, object> rowValues in data)
            {
                requestBodyBuilder.Append(JsonConvert.SerializeObject(rowValues));
                requestBodyBuilder.Append('\n');
            }
            string requestBody = requestBodyBuilder.ToString();

            // Send HTTP request with request body
            using (var client = new HttpClient())
            {
                // Create request message
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, Properties.Settings.Default.baseurl + Properties.Settings.Default.dataurl + tbThing.Text + "/bulk");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Properties.Settings.Default.apitoken);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "text/plain");

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

            // Close Excel file
            workbook.Close(false);
            excel.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
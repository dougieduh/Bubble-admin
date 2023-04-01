namespace Bubble_admin
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            // Check if the text in tbBaseUrl starts with "https://"
            if (!tbBaseUrl.Text.StartsWith("https://"))
            {
                // If it does not, add "https://" to the beginning of the text
                tbBaseUrl.Text = "https://" + tbBaseUrl.Text;
            }

            Properties.Settings.Default.apitoken = tbApiToken.Text;
            Properties.Settings.Default.thirdToken = tbThirdToken.Text;
            if (!tbBaseUrl.Text.EndsWith("/"))
            {
                Properties.Settings.Default.baseurl = tbBaseUrl.Text + "/";
            }

            Properties.Settings.Default.dataurl = "api/1.1/obj/";
            Properties.Settings.Default.wfurl = "api/1.1/wf/";
            Properties.Settings.Default.stripeSecret = tbStripeSecret.Text;

            // Save the changes to the application settings
            Properties.Settings.Default.Save();

            ClearTextBoxes();
        }
        private void ClearTextBoxes()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = string.Empty;
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            tbApiToken.Text = Properties.Settings.Default.apitoken;
            tbBaseUrl.Text = Properties.Settings.Default.baseurl;
            tbThirdToken.Text = Properties.Settings.Default.thirdToken;
            tbStripeSecret.Text = Properties.Settings.Default.stripeSecret;
        }

        public string Token
        {
            get { return tbThirdToken.Text; }
        }
    }
}
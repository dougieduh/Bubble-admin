namespace Bubble_admin
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            tbApiToken = new TextBox();
            label2 = new Label();
            tbBaseUrl = new TextBox();
            btnSaveSettings = new Button();
            tbThirdToken = new TextBox();
            label3 = new Label();
            tbStripeSecret = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(21, 96);
            label1.Name = "label1";
            label1.Size = new Size(137, 20);
            label1.TabIndex = 0;
            label1.Text = "Bubble API Token";
            // 
            // tbApiToken
            // 
            tbApiToken.Location = new Point(21, 127);
            tbApiToken.Name = "tbApiToken";
            tbApiToken.Size = new Size(253, 23);
            tbApiToken.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(21, 28);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 2;
            label2.Text = "Base URL";
            // 
            // tbBaseUrl
            // 
            tbBaseUrl.Location = new Point(21, 59);
            tbBaseUrl.Name = "tbBaseUrl";
            tbBaseUrl.Size = new Size(253, 23);
            tbBaseUrl.TabIndex = 3;
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.Location = new Point(158, 370);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Size = new Size(116, 44);
            btnSaveSettings.TabIndex = 4;
            btnSaveSettings.Text = "Save";
            btnSaveSettings.UseVisualStyleBackColor = true;
            btnSaveSettings.Click += btnSaveSettings_Click;
            // 
            // tbThirdToken
            // 
            tbThirdToken.Location = new Point(21, 194);
            tbThirdToken.Name = "tbThirdToken";
            tbThirdToken.Size = new Size(253, 23);
            tbThirdToken.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(21, 163);
            label3.Name = "label3";
            label3.Size = new Size(149, 20);
            label3.TabIndex = 5;
            label3.Text = "Thirdsoft API Token";
            // 
            // tbStripeSecret
            // 
            tbStripeSecret.Location = new Point(21, 264);
            tbStripeSecret.Name = "tbStripeSecret";
            tbStripeSecret.Size = new Size(253, 23);
            tbStripeSecret.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(21, 233);
            label4.Name = "label4";
            label4.Size = new Size(102, 20);
            label4.TabIndex = 7;
            label4.Text = "Stripe Secret";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(297, 426);
            Controls.Add(tbStripeSecret);
            Controls.Add(label4);
            Controls.Add(tbThirdToken);
            Controls.Add(label3);
            Controls.Add(btnSaveSettings);
            Controls.Add(tbBaseUrl);
            Controls.Add(label2);
            Controls.Add(tbApiToken);
            Controls.Add(label1);
            Name = "Form2";
            Text = "Settings";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbApiToken;
        private Label label2;
        private TextBox tbBaseUrl;
        private Button btnSaveSettings;
        private TextBox tbThirdToken;
        private Label label3;
        private TextBox tbStripeSecret;
        private Label label4;
    }
}
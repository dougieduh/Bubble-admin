namespace Bubble_admin
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            label1 = new Label();
            tbExcelFile = new TextBox();
            button1 = new Button();
            label2 = new Label();
            btnUpload = new Button();
            tbThing = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlLight;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 0;
            label1.Text = "Choose xlsx file";
            // 
            // tbExcelFile
            // 
            tbExcelFile.Location = new Point(12, 37);
            tbExcelFile.Name = "tbExcelFile";
            tbExcelFile.Size = new Size(533, 23);
            tbExcelFile.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(551, 37);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Browse";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.ForeColor = SystemColors.ControlLight;
            label2.Location = new Point(12, 113);
            label2.Name = "label2";
            label2.Size = new Size(456, 93);
            label2.TabIndex = 3;
            label2.Text = resources.GetString("label2.Text");
            // 
            // btnUpload
            // 
            btnUpload.Location = new Point(528, 158);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(98, 48);
            btnUpload.TabIndex = 4;
            btnUpload.Text = "Upload";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // tbThing
            // 
            tbThing.Location = new Point(12, 87);
            tbThing.Name = "tbThing";
            tbThing.Size = new Size(166, 23);
            tbThing.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlLight;
            label3.Location = new Point(12, 69);
            label3.Name = "label3";
            label3.Size = new Size(97, 15);
            label3.TabIndex = 5;
            label3.Text = "App Type (Thing)";
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(638, 218);
            Controls.Add(tbThing);
            Controls.Add(label3);
            Controls.Add(btnUpload);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(tbExcelFile);
            Controls.Add(label1);
            Name = "Form5";
            Text = "Bulk Data Upload";
            Load += Form5_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbExcelFile;
        private Button button1;
        private Label label2;
        private Button btnUpload;
        private TextBox tbThing;
        private Label label3;
    }
}
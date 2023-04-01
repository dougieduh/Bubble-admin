namespace Bubble_admin
{
    partial class Form4
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
            tbWorkflowName = new TextBox();
            label2 = new Label();
            tbParameter = new TextBox();
            tbParameterValue = new TextBox();
            label3 = new Label();
            lbParameters = new ListBox();
            btnAddParameter = new Button();
            btnRunWf = new Button();
            cbMethod = new ComboBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlLight;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(91, 15);
            label1.TabIndex = 0;
            label1.Text = "Workflow name";
            // 
            // tbWorkflowName
            // 
            tbWorkflowName.Location = new Point(12, 37);
            tbWorkflowName.Name = "tbWorkflowName";
            tbWorkflowName.Size = new Size(200, 23);
            tbWorkflowName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlLight;
            label2.Location = new Point(12, 90);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 2;
            label2.Text = "Parameter";
            // 
            // tbParameter
            // 
            tbParameter.Location = new Point(12, 108);
            tbParameter.Name = "tbParameter";
            tbParameter.Size = new Size(200, 23);
            tbParameter.TabIndex = 3;
            // 
            // tbParameterValue
            // 
            tbParameterValue.Location = new Point(218, 108);
            tbParameterValue.Name = "tbParameterValue";
            tbParameterValue.Size = new Size(200, 23);
            tbParameterValue.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlLight;
            label3.Location = new Point(218, 90);
            label3.Name = "label3";
            label3.Size = new Size(35, 15);
            label3.TabIndex = 4;
            label3.Text = "Value";
            // 
            // lbParameters
            // 
            lbParameters.FormattingEnabled = true;
            lbParameters.ItemHeight = 15;
            lbParameters.Location = new Point(12, 137);
            lbParameters.Name = "lbParameters";
            lbParameters.Size = new Size(406, 124);
            lbParameters.TabIndex = 6;
            // 
            // btnAddParameter
            // 
            btnAddParameter.Location = new Point(343, 79);
            btnAddParameter.Name = "btnAddParameter";
            btnAddParameter.Size = new Size(75, 23);
            btnAddParameter.TabIndex = 7;
            btnAddParameter.Text = "Add";
            btnAddParameter.UseVisualStyleBackColor = true;
            btnAddParameter.Click += btnAddParameter_Click;
            // 
            // btnRunWf
            // 
            btnRunWf.Location = new Point(333, 267);
            btnRunWf.Name = "btnRunWf";
            btnRunWf.Size = new Size(86, 48);
            btnRunWf.TabIndex = 8;
            btnRunWf.Text = "Run";
            btnRunWf.UseVisualStyleBackColor = true;
            btnRunWf.Click += btnRunWf_Click;
            // 
            // cbMethod
            // 
            cbMethod.FormattingEnabled = true;
            cbMethod.Items.AddRange(new object[] { "GET", "POST" });
            cbMethod.Location = new Point(218, 37);
            cbMethod.Name = "cbMethod";
            cbMethod.Size = new Size(121, 23);
            cbMethod.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ControlLight;
            label4.Location = new Point(218, 19);
            label4.Name = "label4";
            label4.Size = new Size(75, 15);
            label4.TabIndex = 10;
            label4.Text = "Method type";
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(431, 329);
            Controls.Add(label4);
            Controls.Add(cbMethod);
            Controls.Add(btnRunWf);
            Controls.Add(btnAddParameter);
            Controls.Add(lbParameters);
            Controls.Add(tbParameterValue);
            Controls.Add(label3);
            Controls.Add(tbParameter);
            Controls.Add(label2);
            Controls.Add(tbWorkflowName);
            Controls.Add(label1);
            Name = "Form4";
            Text = "Workflow runner";
            Load += Form4_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbWorkflowName;
        private Label label2;
        private TextBox tbParameter;
        private TextBox tbParameterValue;
        private Label label3;
        private ListBox lbParameters;
        private Button btnAddParameter;
        private Button btnRunWf;
        private ComboBox cbMethod;
        private Label label4;
    }
}
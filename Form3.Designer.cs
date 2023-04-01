namespace Bubble_admin
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            label1 = new Label();
            tbSetType = new TextBox();
            label2 = new Label();
            dgvCustom = new DataGridView();
            btnSet = new Button();
            btnExport = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnDeleteRecord = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCustom).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlLight;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 0;
            label1.Text = "Set Type";
            // 
            // tbSetType
            // 
            tbSetType.Location = new Point(12, 42);
            tbSetType.Name = "tbSetType";
            tbSetType.PlaceholderText = "User";
            tbSetType.Size = new Size(144, 23);
            tbSetType.TabIndex = 1;
            // 
            // label2
            // 
            label2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ControlLight;
            label2.Location = new Point(12, 68);
            label2.Name = "label2";
            label2.Size = new Size(235, 53);
            label2.TabIndex = 2;
            label2.Text = "Your Type name you want to retrieve from your database. ie: User";
            // 
            // dgvCustom
            // 
            dgvCustom.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustom.Location = new Point(12, 124);
            dgvCustom.Name = "dgvCustom";
            dgvCustom.RowTemplate.Height = 25;
            dgvCustom.Size = new Size(1305, 633);
            dgvCustom.TabIndex = 3;
            dgvCustom.CellEndEdit += dgvCustom_CellEndEdit;
            // 
            // btnSet
            // 
            btnSet.Location = new Point(172, 42);
            btnSet.Name = "btnSet";
            btnSet.Size = new Size(75, 23);
            btnSet.TabIndex = 4;
            btnSet.Text = "Set";
            btnSet.UseVisualStyleBackColor = true;
            btnSet.Click += button1_Click;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(1207, 12);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(110, 26);
            btnExport.TabIndex = 5;
            btnExport.Text = "Export to excel";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(885, 95);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search";
            txtSearch.Size = new Size(432, 23);
            txtSearch.TabIndex = 6;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = SystemColors.Control;
            btnSearch.BackgroundImage = (Image)resources.GetObject("btnSearch.BackgroundImage");
            btnSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = SystemColors.Desktop;
            btnSearch.Location = new Point(1295, 95);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(22, 22);
            btnSearch.TabIndex = 7;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnDeleteRecord
            // 
            btnDeleteRecord.BackColor = Color.DarkRed;
            btnDeleteRecord.FlatAppearance.BorderSize = 0;
            btnDeleteRecord.FlatStyle = FlatStyle.Flat;
            btnDeleteRecord.ForeColor = SystemColors.ButtonFace;
            btnDeleteRecord.Location = new Point(551, 12);
            btnDeleteRecord.Name = "btnDeleteRecord";
            btnDeleteRecord.Size = new Size(111, 23);
            btnDeleteRecord.TabIndex = 8;
            btnDeleteRecord.Text = "Delete record";
            btnDeleteRecord.UseVisualStyleBackColor = false;
            btnDeleteRecord.Click += button1_Click_1;
            // 
            // button1
            // 
            button1.Location = new Point(668, 10);
            button1.Name = "button1";
            button1.Size = new Size(110, 26);
            button1.TabIndex = 9;
            button1.Text = "Refund customer";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_2;
            // 
            // button2
            // 
            button2.Location = new Point(519, 763);
            button2.Name = "button2";
            button2.Size = new Size(142, 30);
            button2.TabIndex = 10;
            button2.Text = "< Previous";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(667, 763);
            button3.Name = "button3";
            button3.Size = new Size(142, 30);
            button3.TabIndex = 11;
            button3.Text = "Next >";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form3
            // 
            AcceptButton = btnSet;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1329, 805);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btnDeleteRecord);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnExport);
            Controls.Add(btnSet);
            Controls.Add(dgvCustom);
            Controls.Add(label2);
            Controls.Add(tbSetType);
            Controls.Add(label1);
            Name = "Form3";
            Text = "Bubble App Data";
            Load += Form3_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCustom).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbSetType;
        private Label label2;
        private DataGridView dgvCustom;
        private Button btnSet;
        private Button btnExport;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnDeleteRecord;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}
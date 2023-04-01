namespace Bubble_admin
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            bubbleAppDataToolStripMenuItem = new ToolStripMenuItem();
            bubbleBackendWorkflowRunnerToolStripMenuItem = new ToolStripMenuItem();
            bulkDataUploadToolStripMenuItem = new ToolStripMenuItem();
            dgvUsersInfo = new DataGridView();
            lblNumberOfUsers = new Label();
            txtSearch = new TextBox();
            label2 = new Label();
            btnExport = new Button();
            label5 = new Label();
            panel1 = new Panel();
            label6 = new Label();
            button1 = new Button();
            panel3 = new Panel();
            label4 = new Label();
            button3 = new Button();
            panel2 = new Panel();
            label3 = new Label();
            button2 = new Button();
            button4 = new Button();
            button5 = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsersInfo).BeginInit();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, settingsToolStripMenuItem, bubbleAppDataToolStripMenuItem, bubbleBackendWorkflowRunnerToolStripMenuItem, bulkDataUploadToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1137, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { closeToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(103, 22);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(61, 20);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // bubbleAppDataToolStripMenuItem
            // 
            bubbleAppDataToolStripMenuItem.Name = "bubbleAppDataToolStripMenuItem";
            bubbleAppDataToolStripMenuItem.Size = new Size(43, 20);
            bubbleAppDataToolStripMenuItem.Text = "Data";
            bubbleAppDataToolStripMenuItem.Click += bubbleAppDataToolStripMenuItem_Click;
            // 
            // bubbleBackendWorkflowRunnerToolStripMenuItem
            // 
            bubbleBackendWorkflowRunnerToolStripMenuItem.Name = "bubbleBackendWorkflowRunnerToolStripMenuItem";
            bubbleBackendWorkflowRunnerToolStripMenuItem.Size = new Size(123, 20);
            bubbleBackendWorkflowRunnerToolStripMenuItem.Text = "Backend Workflows";
            bubbleBackendWorkflowRunnerToolStripMenuItem.Click += bubbleBackendWorkflowRunnerToolStripMenuItem_Click;
            // 
            // bulkDataUploadToolStripMenuItem
            // 
            bulkDataUploadToolStripMenuItem.Name = "bulkDataUploadToolStripMenuItem";
            bulkDataUploadToolStripMenuItem.Size = new Size(110, 20);
            bulkDataUploadToolStripMenuItem.Text = "Bulk Data Upload";
            bulkDataUploadToolStripMenuItem.Click += bulkDataUploadToolStripMenuItem_Click;
            // 
            // dgvUsersInfo
            // 
            dgvUsersInfo.AllowUserToAddRows = false;
            dgvUsersInfo.AllowUserToDeleteRows = false;
            dgvUsersInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsersInfo.Location = new Point(12, 90);
            dgvUsersInfo.Name = "dgvUsersInfo";
            dgvUsersInfo.RowTemplate.Height = 25;
            dgvUsersInfo.Size = new Size(1113, 643);
            dgvUsersInfo.TabIndex = 1;
            dgvUsersInfo.CellEndEdit += dgvUsersInfo_CellEndEdit;
            // 
            // lblNumberOfUsers
            // 
            lblNumberOfUsers.AutoSize = true;
            lblNumberOfUsers.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblNumberOfUsers.ForeColor = SystemColors.ControlLight;
            lblNumberOfUsers.Location = new Point(12, 736);
            lblNumberOfUsers.Name = "lblNumberOfUsers";
            lblNumberOfUsers.Size = new Size(35, 20);
            lblNumberOfUsers.TabIndex = 3;
            lblNumberOfUsers.Text = "Test";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(826, 61);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(299, 23);
            txtSearch.TabIndex = 4;
            txtSearch.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlLight;
            label2.Location = new Point(826, 43);
            label2.Name = "label2";
            label2.Size = new Size(74, 15);
            label2.TabIndex = 5;
            label2.Text = "Search email";
            // 
            // btnExport
            // 
            btnExport.Location = new Point(997, 736);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(128, 56);
            btnExport.TabIndex = 6;
            btnExport.Text = "Export to excel";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Visible = false;
            btnExport.Click += btnExport_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ControlLight;
            label5.Location = new Point(12, 782);
            label5.Name = "label5";
            label5.Size = new Size(119, 15);
            label5.TabIndex = 9;
            label5.Text = "Powered by Thirdsoft";
            // 
            // panel1
            // 
            panel1.BackColor = Color.DodgerBlue;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label6);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(190, 48);
            panel1.Name = "panel1";
            panel1.Size = new Size(172, 39);
            panel1.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Cursor = Cursors.Hand;
            label6.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(43, 13);
            label6.Name = "label6";
            label6.Size = new Size(124, 13);
            label6.TabIndex = 1;
            label6.Text = "Create a support ticket";
            label6.Click += label6_Click;
            // 
            // button1
            // 
            button1.BackgroundImage = Properties.Resources.ticket_svgrepo_com;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Enabled = false;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(3, 2);
            button1.Name = "button1";
            button1.Size = new Size(37, 33);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.BackColor = Color.IndianRed;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label4);
            panel3.Controls.Add(button3);
            panel3.Location = new Point(368, 48);
            panel3.Name = "panel3";
            panel3.Size = new Size(172, 39);
            panel3.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Cursor = Cursors.Hand;
            label4.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(43, 13);
            label4.Name = "label4";
            label4.Size = new Size(112, 13);
            label4.TabIndex = 1;
            label4.Text = "View support tickets";
            label4.Click += label4_Click;
            // 
            // button3
            // 
            button3.BackgroundImage = Properties.Resources.view_alt_1_svgrepo_com;
            button3.BackgroundImageLayout = ImageLayout.Stretch;
            button3.Enabled = false;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(3, 2);
            button3.Name = "button3";
            button3.Size = new Size(37, 33);
            button3.TabIndex = 0;
            button3.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Goldenrod;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label3);
            panel2.Controls.Add(button2);
            panel2.Location = new Point(12, 48);
            panel2.Name = "panel2";
            panel2.Size = new Size(172, 39);
            panel2.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Cursor = Cursors.Hand;
            label3.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(43, 13);
            label3.Name = "label3";
            label3.Size = new Size(102, 13);
            label3.TabIndex = 1;
            label3.Text = "Load users             ";
            label3.Click += label3_Click_1;
            // 
            // button2
            // 
            button2.BackgroundImage = Properties.Resources.user_right_arrow_svgrepo_com;
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.Enabled = false;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(3, 2);
            button2.Name = "button2";
            button2.Size = new Size(37, 33);
            button2.TabIndex = 0;
            button2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(475, 739);
            button4.Name = "button4";
            button4.Size = new Size(121, 23);
            button4.TabIndex = 13;
            button4.Text = "< Load Previous";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(602, 739);
            button5.Name = "button5";
            button5.Size = new Size(121, 23);
            button5.TabIndex = 14;
            button5.Text = "Load Next >";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateGray;
            ClientSize = new Size(1137, 806);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(label5);
            Controls.Add(btnExport);
            Controls.Add(label2);
            Controls.Add(txtSearch);
            Controls.Add(lblNumberOfUsers);
            Controls.Add(dgvUsersInfo);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "CS Companion";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsersInfo).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private DataGridView dgvUsersInfo;
        private Label lblNumberOfUsers;
        private TextBox txtSearch;
        private Label label2;
        private Button btnExport;
        private ToolStripMenuItem bubbleAppDataToolStripMenuItem;
        private ToolStripMenuItem bubbleBackendWorkflowRunnerToolStripMenuItem;
        private ToolStripMenuItem bulkDataUploadToolStripMenuItem;
        private Label label5;
        private Panel panel1;
        private Label label6;
        private Button button1;
        private Panel panel3;
        private Label label4;
        private Button button3;
        private Panel panel2;
        private Label label3;
        private Button button2;
        private Button button4;
        private Button button5;
    }
}
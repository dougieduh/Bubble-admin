namespace Bubble_admin
{
    partial class Form6
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
            pnlLogin = new Panel();
            button1 = new Button();
            txtPasswordSignin = new TextBox();
            txtEmailSignin = new TextBox();
            label1 = new Label();
            label2 = new Label();
            linkLabel1 = new LinkLabel();
            pnlLogin.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLogin
            // 
            pnlLogin.Controls.Add(button1);
            pnlLogin.Controls.Add(txtPasswordSignin);
            pnlLogin.Controls.Add(txtEmailSignin);
            pnlLogin.Controls.Add(label1);
            pnlLogin.Location = new Point(25, 26);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(355, 172);
            pnlLogin.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(233, 131);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtPasswordSignin
            // 
            txtPasswordSignin.Location = new Point(46, 102);
            txtPasswordSignin.Name = "txtPasswordSignin";
            txtPasswordSignin.PlaceholderText = "Password:";
            txtPasswordSignin.Size = new Size(262, 23);
            txtPasswordSignin.TabIndex = 2;
            txtPasswordSignin.UseSystemPasswordChar = true;
            // 
            // txtEmailSignin
            // 
            txtEmailSignin.Location = new Point(46, 73);
            txtEmailSignin.Name = "txtEmailSignin";
            txtEmailSignin.PlaceholderText = "Email:";
            txtEmailSignin.Size = new Size(262, 23);
            txtEmailSignin.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(148, 20);
            label1.Name = "label1";
            label1.Size = new Size(59, 25);
            label1.TabIndex = 0;
            label1.Text = "Login";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 221);
            label2.Name = "label2";
            label2.Size = new Size(116, 15);
            label2.TabIndex = 1;
            label2.Text = "Create an account at";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(137, 221);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(65, 15);
            linkLabel1.TabIndex = 2;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "thirdsoft.io";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // Form6
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(405, 245);
            Controls.Add(linkLabel1);
            Controls.Add(label2);
            Controls.Add(pnlLogin);
            Name = "Form6";
            Text = "User sign in";
            Load += Form6_Load;
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlLogin;
        private Button button1;
        private TextBox txtPasswordSignin;
        private TextBox txtEmailSignin;
        private Label label1;
        private Label label2;
        private LinkLabel linkLabel1;
    }
}
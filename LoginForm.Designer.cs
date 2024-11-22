namespace desainperpus_vanya
{
    partial class LoginForm
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
            label1 = new Label();
            panel1 = new Panel();
            label2 = new Label();
            lblUsn = new Label();
            txtUsername = new TextBox();
            txtPass = new TextBox();
            label3 = new Label();
            linkLabel1 = new LinkLabel();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Montserrat SemiBold", 8.999999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(16, 9);
            label1.Name = "label1";
            label1.Size = new Size(76, 18);
            label1.TabIndex = 0;
            label1.Text = "LibraryApp";
            // 
            // panel1
            // 
            panel1.BackColor = Color.SlateBlue;
            panel1.Location = new Point(-2, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(12, 445);
            panel1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Montserrat SemiBold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(16, 36);
            label2.Name = "label2";
            label2.Size = new Size(96, 42);
            label2.TabIndex = 2;
            label2.Text = "Login";
            // 
            // lblUsn
            // 
            lblUsn.AutoSize = true;
            lblUsn.Location = new Point(30, 90);
            lblUsn.Name = "lblUsn";
            lblUsn.Size = new Size(60, 15);
            lblUsn.TabIndex = 3;
            lblUsn.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(122, 87);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(212, 23);
            txtUsername.TabIndex = 4;
            // 
            // txtPass
            // 
            txtPass.Location = new Point(122, 116);
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '*';
            txtPass.Size = new Size(212, 23);
            txtPass.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 119);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 5;
            label3.Text = "Password";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.Black;
            linkLabel1.Location = new Point(207, 142);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(127, 15);
            linkLabel1.TabIndex = 7;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Forgot your password?";
            linkLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            button1.Location = new Point(190, 174);
            button1.Name = "button1";
            button1.Size = new Size(144, 31);
            button1.TabIndex = 8;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(92, 174);
            button2.Name = "button2";
            button2.Size = new Size(92, 31);
            button2.TabIndex = 9;
            button2.Text = "Quit";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(359, 218);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(linkLabel1);
            Controls.Add(txtPass);
            Controls.Add(label3);
            Controls.Add(txtUsername);
            Controls.Add(lblUsn);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label label2;
        private Label lblUsn;
        private TextBox txtUsername;
        private TextBox txtPass;
        private Label label3;
        private LinkLabel linkLabel1;
        private Button button1;
        private Button button2;
    }
}

namespace desainperpus_vanya
{
    partial class AdminDash
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
            pnlMain = new Panel();
            adminReturning1 = new AdminReturning();
            adminDashContent1 = new AdminDashContent();
            pnlSide = new Panel();
            label3 = new Label();
            pnlHighlight = new Panel();
            lblGreeting = new Label();
            label1 = new Label();
            button6 = new Button();
            button5 = new Button();
            button3 = new Button();
            button4 = new Button();
            button2 = new Button();
            button1 = new Button();
            adminBookData1 = new AdminBookData();
            adminBorrowing1 = new AdminBorrowing();
            adminStudentData1 = new AdminStudentData();
            pnlMain.SuspendLayout();
            pnlSide.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(adminDashContent1);
            pnlMain.Controls.Add(adminStudentData1);
            pnlMain.Controls.Add(adminBookData1);
            pnlMain.Controls.Add(adminBorrowing1);
            pnlMain.Controls.Add(adminReturning1);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1162, 661);
            pnlMain.TabIndex = 0;
            pnlMain.Paint += panel1_Paint;
            // 
            // adminReturning1
            // 
            adminReturning1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            adminReturning1.BackColor = SystemColors.ControlLightLight;
            adminReturning1.Location = new Point(237, 0);
            adminReturning1.Name = "adminReturning1";
            adminReturning1.Size = new Size(925, 661);
            adminReturning1.TabIndex = 4;
            // 
            // adminDashContent1
            // 
            adminDashContent1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            adminDashContent1.BackColor = SystemColors.ControlLightLight;
            adminDashContent1.Location = new Point(237, 0);
            adminDashContent1.Name = "adminDashContent1";
            adminDashContent1.Size = new Size(925, 661);
            adminDashContent1.TabIndex = 0;
            // 
            // pnlSide
            // 
            pnlSide.BackColor = Color.DarkSlateBlue;
            pnlSide.Controls.Add(label3);
            pnlSide.Controls.Add(pnlHighlight);
            pnlSide.Controls.Add(lblGreeting);
            pnlSide.Controls.Add(label1);
            pnlSide.Controls.Add(button6);
            pnlSide.Controls.Add(button5);
            pnlSide.Controls.Add(button3);
            pnlSide.Controls.Add(button4);
            pnlSide.Controls.Add(button2);
            pnlSide.Controls.Add(button1);
            pnlSide.Dock = DockStyle.Left;
            pnlSide.Location = new Point(0, 0);
            pnlSide.Name = "pnlSide";
            pnlSide.Size = new Size(234, 661);
            pnlSide.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Montserrat Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(3, 592);
            label3.Name = "label3";
            label3.Size = new Size(126, 25);
            label3.TabIndex = 8;
            label3.Text = "Administrator";
            // 
            // pnlHighlight
            // 
            pnlHighlight.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlHighlight.BackColor = Color.PaleGoldenrod;
            pnlHighlight.Location = new Point(227, 86);
            pnlHighlight.Name = "pnlHighlight";
            pnlHighlight.Size = new Size(7, 42);
            pnlHighlight.TabIndex = 6;
            // 
            // lblGreeting
            // 
            lblGreeting.AutoSize = true;
            lblGreeting.Font = new Font("Montserrat Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGreeting.ForeColor = SystemColors.ControlLightLight;
            lblGreeting.Location = new Point(3, 567);
            lblGreeting.Name = "lblGreeting";
            lblGreeting.Size = new Size(97, 25);
            lblGreeting.TabIndex = 7;
            lblGreeting.Text = "Welcome, ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Montserrat SemiBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(133, 33);
            label1.TabIndex = 0;
            label1.Text = "LibraryApp";
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Montserrat Medium", 12F, FontStyle.Bold);
            button6.ForeColor = SystemColors.ControlLightLight;
            button6.Location = new Point(0, 616);
            button6.Name = "button6";
            button6.Size = new Size(235, 42);
            button6.TabIndex = 5;
            button6.Text = "Logout";
            button6.TextAlign = ContentAlignment.MiddleLeft;
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Montserrat Medium", 12F, FontStyle.Bold);
            button5.ForeColor = SystemColors.ControlLightLight;
            button5.Location = new Point(0, 278);
            button5.Name = "button5";
            button5.Size = new Size(235, 42);
            button5.TabIndex = 4;
            button5.Text = "Pengembalian";
            button5.TextAlign = ContentAlignment.MiddleLeft;
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Montserrat Medium", 12F, FontStyle.Bold);
            button3.ForeColor = SystemColors.ControlLightLight;
            button3.Location = new Point(0, 230);
            button3.Name = "button3";
            button3.Size = new Size(235, 42);
            button3.TabIndex = 3;
            button3.Text = "Peminjaman";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Montserrat Medium", 12F, FontStyle.Bold);
            button4.ForeColor = SystemColors.ControlLightLight;
            button4.Location = new Point(0, 182);
            button4.Name = "button4";
            button4.Size = new Size(235, 42);
            button4.TabIndex = 2;
            button4.Text = "Data Buku";
            button4.TextAlign = ContentAlignment.MiddleLeft;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Montserrat Medium", 12F, FontStyle.Bold);
            button2.ForeColor = SystemColors.ControlLightLight;
            button2.Location = new Point(0, 134);
            button2.Name = "button2";
            button2.Size = new Size(235, 42);
            button2.TabIndex = 1;
            button2.Text = "Data Siswa";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button1.BackColor = Color.DarkSlateBlue;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Montserrat Medium", 12F, FontStyle.Bold);
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(0, 86);
            button1.Name = "button1";
            button1.Size = new Size(235, 42);
            button1.TabIndex = 0;
            button1.Text = "Dashboard";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // adminBookData1
            // 
            adminBookData1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            adminBookData1.BackColor = SystemColors.ControlLightLight;
            adminBookData1.Location = new Point(230, 0);
            adminBookData1.Name = "adminBookData1";
            adminBookData1.Size = new Size(932, 661);
            adminBookData1.TabIndex = 6;
            // 
            // adminBorrowing1
            // 
            adminBorrowing1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            adminBorrowing1.BackColor = SystemColors.ControlLightLight;
            adminBorrowing1.Location = new Point(230, 0);
            adminBorrowing1.Name = "adminBorrowing1";
            adminBorrowing1.Size = new Size(932, 661);
            adminBorrowing1.TabIndex = 7;
            // 
            // adminStudentData1
            // 
            adminStudentData1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            adminStudentData1.BackColor = SystemColors.ControlLightLight;
            adminStudentData1.Location = new Point(230, 0);
            adminStudentData1.Name = "adminStudentData1";
            adminStudentData1.Size = new Size(932, 661);
            adminStudentData1.TabIndex = 8;
            // 
            // AdminDash
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1162, 661);
            Controls.Add(pnlSide);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AdminDash";
            Text = "AdminDash";
            FormClosing += AdminDash_FormClosing;
            Load += AdminDash_Load;
            pnlMain.ResumeLayout(false);
            pnlSide.ResumeLayout(false);
            pnlSide.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMain;
        private Panel pnlSide;
        private Button button1;
        private Button button3;
        private Button button4;
        private Button button2;
        private Panel pnlHighlight;
        private Button button6;
        private Button button5;
        private Label label1;
        private Label lblGreeting;
        private AdminDashContent adminDashContent1;
        private AdminStudentData adminStudentData1;
        private AdminBookData adminBookData2;
        private AdminBorrowing adminBorrowing1;
        private AdminReturning adminReturning1;
        private Label label3;
        private AdminBookData adminBookData1;
    }
}
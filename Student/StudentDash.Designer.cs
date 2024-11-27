namespace desainperpus_vanya
{
    partial class StudentDash
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
            pnlSide = new Panel();
            label3 = new Label();
            lblGreeting = new Label();
            pnlHighlight = new Panel();
            label1 = new Label();
            button6 = new Button();
            button3 = new Button();
            button4 = new Button();
            button2 = new Button();
            button1 = new Button();
            searchBook1 = new Student.SearchBook();
            searchBorrowing1 = new Student.SearchBorrowing();
            searchReturned1 = new Student.SearchReturned();
            pnlMain.SuspendLayout();
            pnlSide.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(searchReturned1);
            pnlMain.Controls.Add(searchBorrowing1);
            pnlMain.Controls.Add(searchBook1);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1127, 661);
            pnlMain.TabIndex = 0;
            pnlMain.Paint += panel1_Paint;
            // 
            // pnlSide
            // 
            pnlSide.BackColor = Color.DarkSlateBlue;
            pnlSide.Controls.Add(label3);
            pnlSide.Controls.Add(lblGreeting);
            pnlSide.Controls.Add(pnlHighlight);
            pnlSide.Controls.Add(label1);
            pnlSide.Controls.Add(button6);
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
            label3.Location = new Point(3, 588);
            label3.Name = "label3";
            label3.Size = new Size(79, 25);
            label3.TabIndex = 10;
            label3.Text = "Student";
            // 
            // lblGreeting
            // 
            lblGreeting.AutoSize = true;
            lblGreeting.Font = new Font("Montserrat Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGreeting.ForeColor = SystemColors.ControlLightLight;
            lblGreeting.Location = new Point(3, 563);
            lblGreeting.Name = "lblGreeting";
            lblGreeting.Size = new Size(97, 25);
            lblGreeting.TabIndex = 9;
            lblGreeting.Text = "Welcome, ";
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
            button3.Text = "Pengembalian";
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
            button4.Text = "Riwayat Peminjaman";
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
            button2.Text = "Cari Buku";
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
            // searchBook1
            // 
            searchBook1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            searchBook1.BackColor = SystemColors.ControlLightLight;
            searchBook1.Location = new Point(234, 0);
            searchBook1.Name = "searchBook1";
            searchBook1.Size = new Size(893, 661);
            searchBook1.TabIndex = 0;
            // 
            // searchBorrowing1
            // 
            searchBorrowing1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            searchBorrowing1.BackColor = SystemColors.ControlLightLight;
            searchBorrowing1.Location = new Point(234, 0);
            searchBorrowing1.Name = "searchBorrowing1";
            searchBorrowing1.Size = new Size(893, 661);
            searchBorrowing1.TabIndex = 1;
            // 
            // searchReturned1
            // 
            searchReturned1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            searchReturned1.BackColor = SystemColors.ControlLightLight;
            searchReturned1.Location = new Point(234, 0);
            searchReturned1.Name = "searchReturned1";
            searchReturned1.Size = new Size(893, 661);
            searchReturned1.TabIndex = 2;
            // 
            // StudentDash
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1127, 661);
            Controls.Add(pnlSide);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.None;
            Name = "StudentDash";
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
        private Label label1;
        private AdminDashContent adminDashContent1;
        private AdminStudentData adminStudentData1;
        private AdminBookData adminBookData2;
        private AdminBorrowing adminBorrowing1;
        private AdminReturning adminReturning1;
        private Label label3;
        private Label lblGreeting;
        private Student.SearchBorrowing searchBorrowing1;
        private Student.SearchBook searchBook1;
        private Student.SearchReturned searchReturned1;
    }
}
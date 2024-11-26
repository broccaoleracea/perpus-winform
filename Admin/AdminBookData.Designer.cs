namespace desainperpus_vanya
{
    partial class AdminBookData
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            id_buku = new DataGridViewTextBoxColumn();
            judul_buku = new DataGridViewTextBoxColumn();
            pengarang = new DataGridViewTextBoxColumn();
            penerbit = new DataGridViewTextBoxColumn();
            tahun_terbit = new DataGridViewTextBoxColumn();
            stok = new DataGridViewTextBoxColumn();
            label9 = new Label();
            button2 = new Button();
            button1 = new Button();
            panel2 = new Panel();
            txtSearch = new TextBox();
            label10 = new Label();
            textBox6 = new TextBox();
            txtPengarang = new TextBox();
            label3 = new Label();
            txtJudul = new TextBox();
            label1 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            btnDel = new Button();
            dateTimePicker1 = new DateTimePicker();
            numStok = new NumericUpDown();
            button3 = new Button();
            button4 = new Button();
            label6 = new Label();
            label4 = new Label();
            txtPenerbit = new TextBox();
            label5 = new Label();
            btnRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numStok).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { id_buku, judul_buku, pengarang, penerbit, tahun_terbit, stok });
            dataGridView1.Location = new Point(8, 43);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(533, 488);
            dataGridView1.TabIndex = 23;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // id_buku
            // 
            id_buku.DataPropertyName = "id_buku";
            id_buku.HeaderText = "ID Buku";
            id_buku.Name = "id_buku";
            id_buku.ReadOnly = true;
            id_buku.Visible = false;
            // 
            // judul_buku
            // 
            judul_buku.DataPropertyName = "judul_buku";
            judul_buku.HeaderText = "Judul Buku";
            judul_buku.Name = "judul_buku";
            judul_buku.ReadOnly = true;
            // 
            // pengarang
            // 
            pengarang.DataPropertyName = "pengarang";
            pengarang.HeaderText = "Pengarang";
            pengarang.Name = "pengarang";
            pengarang.ReadOnly = true;
            // 
            // penerbit
            // 
            penerbit.DataPropertyName = "penerbit";
            penerbit.HeaderText = "Penerbit";
            penerbit.Name = "penerbit";
            penerbit.ReadOnly = true;
            // 
            // tahun_terbit
            // 
            tahun_terbit.DataPropertyName = "tahun_terbit";
            tahun_terbit.HeaderText = "Tahun Terbit";
            tahun_terbit.Name = "tahun_terbit";
            tahun_terbit.ReadOnly = true;
            // 
            // stok
            // 
            stok.DataPropertyName = "stok";
            stok.HeaderText = "Stok";
            stok.Name = "stok";
            stok.ReadOnly = true;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new Point(939, 13);
            label9.Name = "label9";
            label9.Size = new Size(51, 15);
            label9.TabIndex = 21;
            label9.Text = "Search : ";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button2.Location = new Point(15, 972);
            button2.Name = "button2";
            button2.Size = new Size(290, 34);
            button2.TabIndex = 20;
            button2.Text = "Edit";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.Location = new Point(15, 932);
            button1.Name = "button1";
            button1.Size = new Size(290, 34);
            button1.TabIndex = 2;
            button1.Text = "Insert";
            button1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(btnRefresh);
            panel2.Controls.Add(txtSearch);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(dataGridView1);
            panel2.Controls.Add(textBox6);
            panel2.Controls.Add(label9);
            panel2.Location = new Point(322, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(557, 546);
            panel2.TabIndex = 3;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.Location = new Point(330, 10);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(211, 23);
            txtSearch.TabIndex = 25;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Location = new Point(282, 13);
            label10.Name = "label10";
            label10.Size = new Size(51, 15);
            label10.TabIndex = 24;
            label10.Text = "Search : ";
            // 
            // textBox6
            // 
            textBox6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox6.Location = new Point(987, 10);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(211, 23);
            textBox6.TabIndex = 22;
            // 
            // txtPengarang
            // 
            txtPengarang.Location = new Point(94, 123);
            txtPengarang.Name = "txtPengarang";
            txtPengarang.Size = new Size(211, 23);
            txtPengarang.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 126);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 7;
            label3.Text = "Pengarang";
            // 
            // txtJudul
            // 
            txtJudul.Location = new Point(94, 94);
            txtJudul.Name = "txtJudul";
            txtJudul.Size = new Size(211, 23);
            txtJudul.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 97);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 5;
            label1.Text = "Judul Buku";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Montserrat SemiBold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(15, 10);
            label2.Name = "label2";
            label2.Size = new Size(161, 42);
            label2.TabIndex = 4;
            label2.Text = "Book Data";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnDel);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(numStok);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtPenerbit);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(txtPengarang);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtJudul);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(324, 546);
            panel1.TabIndex = 2;
            // 
            // btnDel
            // 
            btnDel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDel.Location = new Point(15, 497);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(290, 34);
            btnDel.TabIndex = 30;
            btnDel.Text = "Delete";
            btnDel.UseVisualStyleBackColor = true;
            btnDel.Click += btnDel_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "yyyy";
            dateTimePicker1.Location = new Point(92, 181);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.Size = new Size(213, 23);
            dateTimePicker1.TabIndex = 29;
            // 
            // numStok
            // 
            numStok.Location = new Point(94, 213);
            numStok.Name = "numStok";
            numStok.Size = new Size(211, 23);
            numStok.TabIndex = 28;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button3.Location = new Point(15, 454);
            button3.Name = "button3";
            button3.Size = new Size(290, 34);
            button3.TabIndex = 27;
            button3.Text = "Edit";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button4.Location = new Point(15, 414);
            button4.Name = "button4";
            button4.Size = new Size(290, 34);
            button4.TabIndex = 26;
            button4.Text = "Insert";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 213);
            label6.Name = "label6";
            label6.Size = new Size(30, 15);
            label6.TabIndex = 25;
            label6.Text = "Stok";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 184);
            label4.Name = "label4";
            label4.Size = new Size(71, 15);
            label4.TabIndex = 23;
            label4.Text = "Tahun Terbit";
            // 
            // txtPenerbit
            // 
            txtPenerbit.Location = new Point(94, 152);
            txtPenerbit.Name = "txtPenerbit";
            txtPenerbit.Size = new Size(211, 23);
            txtPenerbit.TabIndex = 22;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 155);
            label5.Name = "label5";
            label5.Size = new Size(51, 15);
            label5.TabIndex = 21;
            label5.Text = "Penerbit";
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.Location = new Point(201, 10);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 23);
            btnRefresh.TabIndex = 26;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // AdminBookData
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "AdminBookData";
            Size = new Size(879, 546);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numStok).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label9;
        private Button button2;
        private Button button1;
        private Panel panel2;
        private TextBox textBox6;
        private TextBox txtPengarang;
        private Label label3;
        private TextBox txtJudul;
        private Label label1;
        private Label label2;
        private Panel panel1;
        private TextBox txtSearch;
        private Label label10;
        private Label label6;
        private Label label4;
        private TextBox txtPenerbit;
        private Label label5;
        private Button button3;
        private Button button4;
        private NumericUpDown numStok;
        private DateTimePicker dateTimePicker1;
        private Button btnDel;
        private DataGridViewTextBoxColumn id_buku;
        private DataGridViewTextBoxColumn judul_buku;
        private DataGridViewTextBoxColumn pengarang;
        private DataGridViewTextBoxColumn penerbit;
        private DataGridViewTextBoxColumn tahun_terbit;
        private DataGridViewTextBoxColumn stok;
        private Button btnRefresh;
    }
}

namespace desainperpus_vanya
{
    partial class AdminReturning
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
            label7 = new Label();
            dtgvPeminjaman = new DataGridView();
            idpeminjaman = new DataGridViewTextBoxColumn();
            iduser = new DataGridViewTextBoxColumn();
            nama = new DataGridViewTextBoxColumn();
            tgl_pinjam = new DataGridViewTextBoxColumn();
            tgl_kembali = new DataGridViewTextBoxColumn();
            durasi_pinjam = new DataGridViewTextBoxColumn();
            denda = new DataGridViewTextBoxColumn();
            panel2 = new Panel();
            btnRefresh = new Button();
            label2 = new Label();
            textBox7 = new TextBox();
            label10 = new Label();
            textBox8 = new TextBox();
            textBox6 = new TextBox();
            label9 = new Label();
            button7 = new Button();
            button5 = new Button();
            numDenda = new NumericUpDown();
            button6 = new Button();
            cbJudul = new ComboBox();
            txtIdBuku = new TextBox();
            button3 = new Button();
            button4 = new Button();
            label6 = new Label();
            label5 = new Label();
            button2 = new Button();
            button1 = new Button();
            txtNIS = new TextBox();
            label1 = new Label();
            panel1 = new Panel();
            txtNama = new TextBox();
            label8 = new Label();
            label4 = new Label();
            dtpPengembalian = new DateTimePicker();
            label3 = new Label();
            dtgvPengembalian = new DataGridView();
            idpengembalian = new DataGridViewTextBoxColumn();
            idpeminjaman1 = new DataGridViewTextBoxColumn();
            id_buku = new DataGridViewTextBoxColumn();
            judul_buku = new DataGridViewTextBoxColumn();
            tglkembali1 = new DataGridViewTextBoxColumn();
            denda1 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dtgvPeminjaman).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDenda).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvPengembalian).BeginInit();
            SuspendLayout();
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(999, 13);
            label7.Name = "label7";
            label7.Size = new Size(51, 15);
            label7.TabIndex = 26;
            label7.Text = "Search : ";
            // 
            // dtgvPeminjaman
            // 
            dtgvPeminjaman.AllowUserToAddRows = false;
            dtgvPeminjaman.AllowUserToDeleteRows = false;
            dtgvPeminjaman.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtgvPeminjaman.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvPeminjaman.Columns.AddRange(new DataGridViewColumn[] { idpeminjaman, iduser, nama, tgl_pinjam, tgl_kembali, durasi_pinjam, denda });
            dtgvPeminjaman.Location = new Point(9, 65);
            dtgvPeminjaman.MultiSelect = false;
            dtgvPeminjaman.Name = "dtgvPeminjaman";
            dtgvPeminjaman.ReadOnly = true;
            dtgvPeminjaman.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvPeminjaman.Size = new Size(928, 148);
            dtgvPeminjaman.TabIndex = 23;
            dtgvPeminjaman.CellClick += dtgvPeminjaman_CellClick;
            // 
            // idpeminjaman
            // 
            idpeminjaman.DataPropertyName = "id_peminjaman";
            idpeminjaman.HeaderText = "ID Peminjaman";
            idpeminjaman.Name = "idpeminjaman";
            idpeminjaman.ReadOnly = true;
            idpeminjaman.Visible = false;
            // 
            // iduser
            // 
            iduser.DataPropertyName = "id_user";
            iduser.HeaderText = "ID User";
            iduser.Name = "iduser";
            iduser.ReadOnly = true;
            iduser.Visible = false;
            // 
            // nama
            // 
            nama.DataPropertyName = "nama";
            nama.HeaderText = "Nama";
            nama.Name = "nama";
            nama.ReadOnly = true;
            // 
            // tgl_pinjam
            // 
            tgl_pinjam.DataPropertyName = "tgl_pinjam";
            tgl_pinjam.HeaderText = "Tanggal Pinjam";
            tgl_pinjam.Name = "tgl_pinjam";
            tgl_pinjam.ReadOnly = true;
            // 
            // tgl_kembali
            // 
            tgl_kembali.DataPropertyName = "tgl_kembali";
            tgl_kembali.HeaderText = "Tanggal Kembali Seharusnya";
            tgl_kembali.Name = "tgl_kembali";
            tgl_kembali.ReadOnly = true;
            // 
            // durasi_pinjam
            // 
            durasi_pinjam.DataPropertyName = "durasi_pinjam";
            durasi_pinjam.HeaderText = "Durasi Pinjam";
            durasi_pinjam.Name = "durasi_pinjam";
            durasi_pinjam.ReadOnly = true;
            // 
            // denda
            // 
            denda.DataPropertyName = "denda";
            denda.HeaderText = "Total Denda";
            denda.Name = "denda";
            denda.ReadOnly = true;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(btnRefresh);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(textBox7);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(textBox8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(dtgvPeminjaman);
            panel2.Controls.Add(textBox6);
            panel2.Controls.Add(label9);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(952, 229);
            panel2.TabIndex = 7;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.Location = new Point(597, 27);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 23);
            btnRefresh.TabIndex = 36;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Montserrat SemiBold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(9, 14);
            label2.Name = "label2";
            label2.Size = new Size(195, 42);
            label2.TabIndex = 35;
            label2.Text = "Peminjaman";
            // 
            // textBox7
            // 
            textBox7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox7.Location = new Point(726, 28);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(211, 23);
            textBox7.TabIndex = 29;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Location = new Point(678, 31);
            label10.Name = "label10";
            label10.Size = new Size(51, 15);
            label10.TabIndex = 28;
            label10.Text = "Search : ";
            // 
            // textBox8
            // 
            textBox8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox8.Location = new Point(1047, 10);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(211, 23);
            textBox8.TabIndex = 27;
            // 
            // textBox6
            // 
            textBox6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox6.Location = new Point(2061, 10);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(211, 23);
            textBox6.TabIndex = 22;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new Point(2013, 13);
            label9.Name = "label9";
            label9.Size = new Size(51, 15);
            label9.TabIndex = 21;
            label9.Text = "Search : ";
            // 
            // button7
            // 
            button7.Location = new Point(280, 20);
            button7.Name = "button7";
            button7.Size = new Size(125, 34);
            button7.TabIndex = 33;
            button7.Text = "Delete";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button5
            // 
            button5.Location = new Point(149, 20);
            button5.Name = "button5";
            button5.Size = new Size(125, 34);
            button5.TabIndex = 32;
            button5.Text = "Edit";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // numDenda
            // 
            numDenda.Enabled = false;
            numDenda.Location = new Point(132, 214);
            numDenda.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numDenda.Name = "numDenda";
            numDenda.Size = new Size(182, 23);
            numDenda.TabIndex = 31;
            // 
            // button6
            // 
            button6.Location = new Point(18, 20);
            button6.Name = "button6";
            button6.Size = new Size(125, 34);
            button6.TabIndex = 28;
            button6.Text = "Insert";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // cbJudul
            // 
            cbJudul.FormattingEnabled = true;
            cbJudul.Location = new Point(132, 127);
            cbJudul.Name = "cbJudul";
            cbJudul.Size = new Size(273, 23);
            cbJudul.TabIndex = 30;
            // 
            // txtIdBuku
            // 
            txtIdBuku.Enabled = false;
            txtIdBuku.Location = new Point(132, 156);
            txtIdBuku.Name = "txtIdBuku";
            txtIdBuku.Size = new Size(273, 23);
            txtIdBuku.TabIndex = 29;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button3.Location = new Point(15, 1083);
            button3.Name = "button3";
            button3.Size = new Size(290, 34);
            button3.TabIndex = 27;
            button3.Text = "Edit";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button4.Location = new Point(15, 1043);
            button4.Name = "button4";
            button4.Size = new Size(290, 34);
            button4.TabIndex = 26;
            button4.Text = "Insert";
            button4.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 216);
            label6.Name = "label6";
            label6.Size = new Size(41, 15);
            label6.TabIndex = 25;
            label6.Text = "Denda";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 130);
            label5.Name = "label5";
            label5.Size = new Size(65, 15);
            label5.TabIndex = 21;
            label5.Text = "Judul Buku";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button2.Location = new Point(15, 1557);
            button2.Name = "button2";
            button2.Size = new Size(290, 34);
            button2.TabIndex = 20;
            button2.Text = "Edit";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.Location = new Point(15, 1517);
            button1.Name = "button1";
            button1.Size = new Size(290, 34);
            button1.TabIndex = 2;
            button1.Text = "Insert";
            button1.UseVisualStyleBackColor = true;
            // 
            // txtNIS
            // 
            txtNIS.Enabled = false;
            txtNIS.Location = new Point(132, 98);
            txtNIS.Name = "txtNIS";
            txtNIS.Size = new Size(273, 23);
            txtNIS.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 72);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 5;
            label1.Text = "Nama";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(txtNama);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(dtpPengembalian);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(dtgvPengembalian);
            panel1.Controls.Add(button7);
            panel1.Controls.Add(numDenda);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(cbJudul);
            panel1.Controls.Add(txtIdBuku);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(txtNIS);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 215);
            panel1.Name = "panel1";
            panel1.Size = new Size(952, 277);
            panel1.TabIndex = 6;
            // 
            // txtNama
            // 
            txtNama.Enabled = false;
            txtNama.Location = new Point(132, 69);
            txtNama.Name = "txtNama";
            txtNama.Size = new Size(273, 23);
            txtNama.TabIndex = 41;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(25, 164);
            label8.Name = "label8";
            label8.Size = new Size(48, 15);
            label8.TabIndex = 40;
            label8.Text = "ID Buku";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 191);
            label4.Name = "label4";
            label4.Size = new Size(101, 15);
            label4.TabIndex = 38;
            label4.Text = "Tgl Pengembalian";
            // 
            // dtpPengembalian
            // 
            dtpPengembalian.Location = new Point(132, 185);
            dtpPengembalian.Name = "dtpPengembalian";
            dtpPengembalian.Size = new Size(273, 23);
            dtpPengembalian.TabIndex = 37;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 101);
            label3.Name = "label3";
            label3.Size = new Size(25, 15);
            label3.TabIndex = 36;
            label3.Text = "NIS";
            // 
            // dtgvPengembalian
            // 
            dtgvPengembalian.AllowUserToAddRows = false;
            dtgvPengembalian.AllowUserToDeleteRows = false;
            dtgvPengembalian.AllowUserToOrderColumns = true;
            dtgvPengembalian.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtgvPengembalian.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvPengembalian.Columns.AddRange(new DataGridViewColumn[] { idpengembalian, idpeminjaman1, id_buku, judul_buku, tglkembali1, denda1 });
            dtgvPengembalian.Location = new Point(432, 23);
            dtgvPengembalian.MultiSelect = false;
            dtgvPengembalian.Name = "dtgvPengembalian";
            dtgvPengembalian.ReadOnly = true;
            dtgvPengembalian.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvPengembalian.Size = new Size(505, 241);
            dtgvPengembalian.TabIndex = 35;
            dtgvPengembalian.CellClick += dtgvPengembalian_CellClick;
            // 
            // idpengembalian
            // 
            idpengembalian.DataPropertyName = "id_pengembalian";
            idpengembalian.HeaderText = "ID Pengembalian";
            idpengembalian.Name = "idpengembalian";
            idpengembalian.ReadOnly = true;
            idpengembalian.Visible = false;
            // 
            // idpeminjaman1
            // 
            idpeminjaman1.DataPropertyName = "id_peminjaman";
            idpeminjaman1.HeaderText = "ID Peminjaman";
            idpeminjaman1.Name = "idpeminjaman1";
            idpeminjaman1.ReadOnly = true;
            idpeminjaman1.Visible = false;
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
            // tglkembali1
            // 
            tglkembali1.DataPropertyName = "tgl_kembali";
            tglkembali1.HeaderText = "Tanggal Kembali Ril";
            tglkembali1.Name = "tglkembali1";
            tglkembali1.ReadOnly = true;
            // 
            // denda1
            // 
            denda1.DataPropertyName = "denda";
            denda1.HeaderText = "Denda";
            denda1.Name = "denda1";
            denda1.ReadOnly = true;
            // 
            // AdminReturning
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "AdminReturning";
            Size = new Size(952, 492);
            ((System.ComponentModel.ISupportInitialize)dtgvPeminjaman).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDenda).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvPengembalian).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label label7;
        private DataGridView dtgvPeminjaman;
        private Panel panel2;
        private TextBox textBox8;
        private TextBox textBox6;
        private Label label9;
        private Button button7;
        private Button button5;
        private NumericUpDown numDenda;
        private Button button6;
        private ComboBox cbJudul;
        private TextBox txtIdBuku;
        private Button button3;
        private Button button4;
        private Label label6;
        private Label label5;
        private Button button2;
        private Button button1;
        private TextBox txtNIS;
        private Label label1;
        private Panel panel1;
        private TextBox textBox7;
        private Label label10;
        private Label label2;
        private DataGridView dtgvPengembalian;
        private Label label3;
        private Label label4;
        private DateTimePicker dtpPengembalian;
        private DataGridViewTextBoxColumn idpengembalian;
        private DataGridViewTextBoxColumn idpeminjaman1;
        private DataGridViewTextBoxColumn id_buku;
        private DataGridViewTextBoxColumn judul_buku;
        private DataGridViewTextBoxColumn tglkembali1;
        private DataGridViewTextBoxColumn denda1;
        private Button btnRefresh;
        private Label label8;
        private DataGridViewTextBoxColumn idpeminjaman;
        private DataGridViewTextBoxColumn iduser;
        private DataGridViewTextBoxColumn nama;
        private DataGridViewTextBoxColumn tgl_pinjam;
        private DataGridViewTextBoxColumn tgl_kembali;
        private DataGridViewTextBoxColumn durasi_pinjam;
        private DataGridViewTextBoxColumn denda;
        private TextBox txtNama;
    }
}

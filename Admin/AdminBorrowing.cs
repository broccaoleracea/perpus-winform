using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desainperpus_vanya
{
    public partial class AdminBorrowing : UserControl
    {

        int? id_peminjaman;
        public AdminBorrowing()
        {
            InitializeComponent();
            LoginForm.connOpen();
            displayTable();
        }

        private void displayTable()
        {
            LoginForm.connOpen();

            //Fetch data for the main peminjaman table (right side of the screen)
            SqlCommand peminjaman = new SqlCommand("SELECT * FROM peminjaman", LoginForm.conn);
            SqlDataAdapter sda = new SqlDataAdapter(peminjaman);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dtgvPeminjaman.DataSource = dt;
            sda.Dispose();

            // Fetch data for the name combobox
            SqlCommand kjsdnhkashdkabnxcvcxv = new SqlCommand("SELECT * FROM [user] WHERE role='siswa'", LoginForm.conn);
            sda = new SqlDataAdapter(kjsdnhkashdkabnxcvcxv);
            dt = new DataTable();
            sda.Fill(dt);

            cbNama.DataSource = dt;
            cbNama.DisplayMember = "nama";
            cbNama.ValueMember = "id_user";
            cbNama.SelectedIndex = -1;

            // Fetch data for the book titles combobox
            SqlCommand asdgsdhsdgjasgdasdg = new SqlCommand("SELECT * FROM buku", LoginForm.conn);
            sda = new SqlDataAdapter(asdgsdhsdgjasgdasdg);
            dt = new DataTable();
            sda.Fill(dt);

            cbJudul.DataSource = dt;
            cbJudul.DisplayMember = "judul_buku";
            cbJudul.ValueMember = "id_buku";
            cbJudul.SelectedIndex = -1;

            //Close the connection
            LoginForm.conn.Close();
        }

        private void ResetValues()
        {
            cbNama.SelectedValue = -1;
            cbJudul.SelectedValue = -1;
            numStok.Value = 0;
            dtgvPeminjamanDetail.DataSource = null;
        }

        private void AddNewPeminjaman()
        {
            int idUser = Convert.ToInt32(cbNama.SelectedValue);
            int idBuku = Convert.ToInt32(cbJudul.SelectedValue);
            int jumlahPinjam = (int)numStok.Value;
            DateTime tanggalPinjam = DateTime.Now; // get current date 
            DateTime tanggalKembali = tanggalPinjam.AddDays(7);
            int durasiPinjam = 7; // ? tbh idk
            int denda = 0;

            try
            {
                LoginForm.connOpen();

                //insert peminjaman
                string qryAddPeminjaman = @"
            INSERT INTO peminjaman (id_user, tgl_pinjam, tgl_kembali, durasi_pinjam, denda)
            VALUES (@id_user, @tgl_pinjam, @tgl_kembali, @durasi_pinjam, @denda);";

                SqlCommand cmdPeminjaman = new SqlCommand(qryAddPeminjaman, LoginForm.conn);
                cmdPeminjaman.Parameters.AddWithValue("@id_user", idUser);
                cmdPeminjaman.Parameters.AddWithValue("@tgl_pinjam", tanggalPinjam);
                cmdPeminjaman.Parameters.AddWithValue("@tgl_kembali", tanggalKembali);
                cmdPeminjaman.Parameters.AddWithValue("@durasi_pinjam", durasiPinjam);
                cmdPeminjaman.Parameters.AddWithValue("@denda", denda);


                int idPeminjaman = Convert.ToInt32(cmdPeminjaman.ExecuteScalar());

                // insert into peminjaman_buku
                string qryPeminjamanBuku = @"
            INSERT INTO peminjaman_buku (id_peminjaman, id_buku, jml_pinjam)
            VALUES (@id_peminjaman, @id_buku, @jml_pinjam);";

                SqlCommand cmdPeminjamanBuku = new SqlCommand(qryPeminjamanBuku, LoginForm.conn);
                cmdPeminjamanBuku.Parameters.AddWithValue("@id_peminjaman", idPeminjaman);
                cmdPeminjamanBuku.Parameters.AddWithValue("@id_buku", idBuku);
                cmdPeminjamanBuku.Parameters.AddWithValue("@jml_pinjam", jumlahPinjam);

                cmdPeminjamanBuku.ExecuteNonQuery();

                MessageBox.Show("Peminjaman berhasil ditambahkan.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
            }
            finally
            {
                if (LoginForm.conn.State == ConnectionState.Open)
                    LoginForm.conn.Close();
                ResetValues();
            }
        }

        private static bool CheckDuplicate(int idPeminjaman, int idBuku)
        {
            try
            {
                string qry = @"
        SELECT COUNT(*) 
        FROM peminjaman_buku 
        WHERE id_peminjaman = @id_peminjaman AND id_buku = @id_buku";

                SqlCommand cmd = new SqlCommand(qry, LoginForm.conn);
                cmd.Parameters.AddWithValue("@id_peminjaman", idPeminjaman);
                cmd.Parameters.AddWithValue("@id_buku", idBuku);

                LoginForm.connOpen();

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
            }
        }

        private void AddDetailPeminjaman()
        {
            int idUser = Convert.ToInt32(cbNama.SelectedValue);
            int idBuku = Convert.ToInt32(cbJudul.SelectedValue);

            if (CheckDuplicate((int)id_peminjaman, idBuku))
            {
                MessageBox.Show("Buku ini telah terpinjam oleh peminjaman yang sama. Mohon pilih buku lain.");
                return;
            }

            int jumlahPinjam = (int)numStok.Value;


            try
            {
                LoginForm.connOpen();
                // insert into peminjaman_buku
                string qryPeminjamanBuku = @"
            INSERT INTO peminjaman_buku (id_peminjaman, id_buku, jml_pinjam)
            VALUES (@id_peminjaman, @id_buku, @jml_pinjam);";

                SqlCommand cmdPeminjamanBuku = new SqlCommand(qryPeminjamanBuku, LoginForm.conn);
                cmdPeminjamanBuku.Parameters.AddWithValue("@id_peminjaman", id_peminjaman);
                cmdPeminjamanBuku.Parameters.AddWithValue("@id_buku", idBuku);
                cmdPeminjamanBuku.Parameters.AddWithValue("@jml_pinjam", jumlahPinjam);

                cmdPeminjamanBuku.ExecuteNonQuery();

                MessageBox.Show("Detail peminjaman berhasil ditambahkan.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
            }
            finally
            {
                if (LoginForm.conn.State == ConnectionState.Open)
                    LoginForm.conn.Close();
                ResetValues();
            }
        }

        private void UpdateData()
        {
            int idUser = Convert.ToInt32(cbNama.SelectedValue);
            int idBuku = Convert.ToInt32(cbJudul.SelectedValue);
            int jumlahPinjam = (int)numStok.Value;
            DateTime tanggalPinjam = DateTime.Now; // get current date 
            DateTime tanggalKembali = tanggalPinjam.AddDays(7);

            try
            {
                LoginForm.connOpen();

                // Update peminjaman
                string qryUpdatePeminjaman = @"
            UPDATE peminjaman
            SET tgl_pinjam = @tgl_pinjam, 
                tgl_kembali = @tgl_kembali, 
                durasi_pinjam = DATEDIFF(DAY, @tgl_pinjam, @tgl_kembali)
            WHERE id_peminjaman = @id_peminjaman";

                SqlCommand updatePeminjamanCmd = new SqlCommand(qryUpdatePeminjaman, LoginForm.conn);
                updatePeminjamanCmd.Parameters.AddWithValue("@tgl_pinjam", tanggalPinjam);
                updatePeminjamanCmd.Parameters.AddWithValue("@tgl_kembali", tanggalKembali);
                updatePeminjamanCmd.Parameters.AddWithValue("@id_peminjaman", id_peminjaman);
                updatePeminjamanCmd.ExecuteNonQuery();

                // Update peminjaman_buku 
                string updatePeminjamanBukuQuery = @"
            UPDATE peminjaman_buku
            SET jml_pinjam = @jml_pinjam
            WHERE id_peminjaman = @id_peminjaman AND id_buku = @id_buku";

                SqlCommand updatePeminjamanBukuCmd = new SqlCommand(updatePeminjamanBukuQuery, LoginForm.conn);
                updatePeminjamanBukuCmd.Parameters.AddWithValue("@jml_pinjam", jumlahPinjam);
                updatePeminjamanBukuCmd.Parameters.AddWithValue("@id_peminjaman", id_peminjaman);
                updatePeminjamanBukuCmd.Parameters.AddWithValue("@id_buku", idBuku);
                updatePeminjamanBukuCmd.ExecuteNonQuery();

                MessageBox.Show("Data peminjaman berhasil di update!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"An error occurred while updating the data: {ex.Message}");
            }
            finally
            {
                if (LoginForm.conn.State == System.Data.ConnectionState.Open)
                    LoginForm.conn.Close();
                ResetValues();
            }
        }

        private void DeleteData()
        {
            try
            {
                // confirm if the user really want to delete the data
                // enetered parameters based on the order theyre appearing in : the message box content, message box title, messagebox type 
                DialogResult confirmDelete = MessageBox.Show("Anda yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo);
                if (confirmDelete == DialogResult.Yes)
                {
                    // 1. delete every peminjaman detail with the current selected id_peminjaman 
                    SqlCommand delPeminjamanDetail = new SqlCommand("DELETE FROM peminjaman_buku WHERE id_peminjaman=@id_peminjaman", LoginForm.conn);
                    delPeminjamanDetail.Parameters.AddWithValue("@id_peminjaman", SqlDbType.VarChar).Value = id_peminjaman;

                    // 2. delete peminjaman
                    SqlCommand delPeminjaman = new SqlCommand("DELETE FROM [peminjaman] WHERE id_peminjaman=@id_peminjaman", LoginForm.conn);
                    delPeminjaman.Parameters.AddWithValue("@id_peminjaman", SqlDbType.VarChar).Value = id_peminjaman;

                    //execute
                    delPeminjamanDetail.ExecuteNonQuery();
                    delPeminjaman.ExecuteNonQuery();  
                }
                else if (confirmDelete == DialogResult.No)
                {
                    MessageBox.Show("Aksi menghapus dibatalkan.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
            }
            finally
            {
                if (LoginForm.conn.State == ConnectionState.Open)
                    LoginForm.conn.Close();
                ResetValues();
                displayTable();

                MessageBox.Show("Data berhasil dihapus");
            }

        }

        private void dtgvPeminjaman_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dtgvPeminjaman.Rows[index];
            id_peminjaman = (int)selectedRow.Cells[0].Value;

            SqlCommand detail = new SqlCommand("SELECT * FROM peminjaman_buku WHERE id_peminjaman=" + id_peminjaman + ";", LoginForm.conn);
            SqlDataAdapter detailsda = new SqlDataAdapter(detail);
            DataTable detaildt = new DataTable();
            detailsda.Fill(detaildt);

            dtgvPeminjamanDetail.DataSource = detaildt;
            detailsda.Dispose();

            cbNama.SelectedValue = (int)selectedRow.Cells[1].Value;
            //cbJudul.SelectedValue = 
            //numStok.Value = 
        }

        private void dtgvPeminjamanDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dtgvPeminjamanDetail.Rows[index];

            cbJudul.SelectedValue = (int)selectedRow.Cells[2].Value;
            numStok.Value = (int)selectedRow.Cells[3].Value;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddNewPeminjaman();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddDetailPeminjaman();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

      
    }
}

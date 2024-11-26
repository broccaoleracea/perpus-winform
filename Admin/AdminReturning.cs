using Microsoft.Data.SqlClient;
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
    public partial class AdminReturning : UserControl
    {
        int? id_peminjaman;
        public AdminReturning()
        {
            InitializeComponent();
            displayTable();
            ResetValues();
        }
        // Check if there's enough book stock to perform the transaction
        private bool ValidateBookStock(int idBuku, int jumlahPinjam)
        {
            try
            {
                LoginForm.connOpen();
                SqlCommand query = new SqlCommand("SELECT * FROM buku WHERE id_buku=@id_buku", LoginForm.conn);
                query.Parameters.AddWithValue("@id_buku", idBuku);
                SqlDataAdapter asdbadsghasdhg = new SqlDataAdapter(query);
                DataTable dt = new DataTable();
                asdbadsghasdhg.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        SqlDataReader reader = query.ExecuteReader();
                        reader.Read();
                        UserInfo.UserName = reader.GetString(1);

                        //If there current book stock is not enough, cancel the action
                        if ((int)dr["stok"] < jumlahPinjam)
                        {
                            MessageBox.Show("Stok tidak cukup untuk memenuhi peminjaman! Stok buku saat ini : " + dr["stok"].ToString() + "");
                            reader.Close();
                            dt.Dispose();
                            return false;
                        }
                        reader.Close();
                        dt.Dispose();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
                return false;
            }
            finally
            {
                if (LoginForm.conn.State == ConnectionState.Open)
                    LoginForm.conn.Close();
            }
        }


        private void ResetValues()
        {
            cbNama.SelectedValue = -1;
            cbJudul.SelectedValue = -1;
            dtpPengembalian.Value = DateTime.Now;
            dtgvPengembalian.DataSource = null;
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
        private void ReduceBookStock(int idBuku, int jumlahPinjam)
        {
            ValidateBookStock(idBuku, jumlahPinjam);
            try
            {
                LoginForm.connOpen();


                SqlCommand updateStok = new SqlCommand("UPDATE buku set stok=stok-@jumlahpinjam  WHERE id_buku=@id_buku AND stok >= @jumlahpinjam", LoginForm.conn);
                updateStok.Parameters.AddWithValue("@id_buku", idBuku);
                updateStok.Parameters.AddWithValue("@jumlahpinjam", jumlahPinjam);
                MessageBox.Show("Reducing book stock by : " + jumlahPinjam);
                updateStok.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
            }
            finally
            {
                if (LoginForm.conn.State == ConnectionState.Open)
                    LoginForm.conn.Close();
            }

        }

        private void AddBookStock(int idBuku, int jumlahPinjam)
        {
            try
            {
                using (SqlCommand cmdUpdateStock = new SqlCommand("UPDATE buku set stok=stok+@jumlahpinjam  WHERE id_buku=@id_buku AND stok >= @jumlahpinjam", new SqlConnection(LoginForm.conn.ConnectionString)))
                {
                    cmdUpdateStock.Parameters.AddWithValue("@id_buku", idBuku);
                    cmdUpdateStock.Parameters.AddWithValue("@jumlahpinjam", jumlahPinjam);

                    cmdUpdateStock.Connection.Open(); // Use a separate connection
                    MessageBox.Show("Adding book stock by : " + jumlahPinjam);
                    cmdUpdateStock.ExecuteNonQuery();
                    cmdUpdateStock.Connection.Close();
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
            }

        }


        private void AddData()
        {
            int idUser = Convert.ToInt32(cbNama.SelectedValue);
            int idBuku = Convert.ToInt32(cbJudul.SelectedValue);
            DateTime tanggalKembali = dtpPengembalian.Value;
            int denda = (int)numDenda.Value;
            try
            {
                // insert into peminjaman_buku
                string qryPeminjamanBuku = @"
            INSERT INTO pengembalian
           ([id_peminjaman]
           ,[id_buku]
           ,[tgl_kembali]
           ,[denda])
     VALUES
           (@id_peminjaman
           ,@id_buku
           ,@tglKembali
           ,@denda)";


                SqlCommand cmdPeminjamanBuku = new SqlCommand(qryPeminjamanBuku, LoginForm.conn);
                cmdPeminjamanBuku.Parameters.AddWithValue("@id_peminjaman", id_peminjaman);
                cmdPeminjamanBuku.Parameters.AddWithValue("@id_buku", idBuku);
                cmdPeminjamanBuku.Parameters.AddWithValue("@tglKembali", tanggalKembali);
                cmdPeminjamanBuku.Parameters.AddWithValue("@denda", tanggalKembali);

                LoginForm.connOpen();
                cmdPeminjamanBuku.ExecuteNonQuery();


                //ReduceBookStock(idBuku, jumlahPinjam);

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

        private void dtgvPeminjaman_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Safeguard if thw user clicked on invalid row
            if (e.RowIndex < 0) return;

            int index = e.RowIndex;
            DataGridViewRow selectedRow = dtgvPeminjaman.Rows[index];
            id_peminjaman = (int)selectedRow.Cells[0].Value;

            SqlCommand detail = new SqlCommand("SELECT * FROM pengembalian WHERE id_peminjaman=" + id_peminjaman + ";", LoginForm.conn);
            SqlDataAdapter detailsda = new SqlDataAdapter(detail);
            DataTable detaildt = new DataTable();
            detailsda.Fill(detaildt);

            dtgvPengembalian.DataSource = detaildt;
            detailsda.Dispose();

            cbNama.SelectedValue = (int)selectedRow.Cells[1].Value;
        }
    }
}

using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Net;
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

        // Refresh tables
        private void displayTable()
        {
            LoginForm.connOpen();

            //Fetch data for the main peminjaman table (right side of the screen)
            SqlCommand peminjaman = new SqlCommand("SELECT pm.*, u.nama " +
    "FROM peminjaman pm " +
    "JOIN [user] u ON pm.id_user = u.id_user", LoginForm.conn);
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

        // Reset field values
        private void ResetValues()
        {
            idpeminjaman = null;
            txtIDBuku.Text = null;
            txtNIS.Text = null;
            cbNama.SelectedValue = -1;
            cbJudul.SelectedValue = -1;
            numStok.Value = 0;
            dtgvPeminjamanDetail.DataSource = null;
        }
        public void SearchData()
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                try
                {
                    LoginForm.conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM peminjaman WHERE buku.judul_buku LIKE '%' + @query + '%' OR buku.pengarang LIKE '%' + @query + '%' OR buku.penerbit LIKE '%' + @query + '%' OR buku.tahun_terbit LIKE '%' + @query + '%' OR buku.stok LIKE '%' + @query + '%';", LoginForm.conn);
                    cmd.Parameters.AddWithValue("@query", txtSearch.Text.Trim());
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dtgvPeminjaman.DataSource = dt;
                    LoginForm.conn.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error encountered : " + ex);
                }
            }
            else
            {
                displayTable();
            }
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
    VALUES (@id_user, @tgl_pinjam, @tgl_kembali, @durasi_pinjam, @denda);
    SELECT SCOPE_IDENTITY();";

                SqlCommand cmdPeminjaman = new SqlCommand(qryAddPeminjaman, LoginForm.conn);
                cmdPeminjaman.Parameters.AddWithValue("@id_user", idUser);
                cmdPeminjaman.Parameters.AddWithValue("@tgl_pinjam", tanggalPinjam);
                cmdPeminjaman.Parameters.AddWithValue("@tgl_kembali", tanggalKembali);
                cmdPeminjaman.Parameters.AddWithValue("@durasi_pinjam", durasiPinjam);
                cmdPeminjaman.Parameters.AddWithValue("@denda", denda);


                object result = cmdPeminjaman.ExecuteScalar();
                int idPeminjaman = Convert.ToInt32(result);


                if (idBuku > 0 && jumlahPinjam > 0)
                {
                    DialogResult confirmAdd = MessageBox.Show("Apakah anda hendak menambahakn detail pada peminjaman?", "Konfirmasi", MessageBoxButtons.YesNo);
                    if (confirmAdd == DialogResult.Yes)
                    {
                        id_peminjaman = idPeminjaman;
                        AddDetailPeminjaman();
                    }
                    else if (confirmAdd == DialogResult.No)
                    {
                        MessageBox.Show("Aksi menambahkan detail peminjaman dibatalkan.");
                    }
                }


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
                displayTable();
            }
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

        // Check for duplicate book under one peminjaman
        private static bool CheckDuplicate(int idPeminjaman, int idBuku)
        {
            try
            {
                LoginForm.connOpen();
                string qry = @"
        SELECT COUNT(*) 
        FROM peminjaman_buku 
        WHERE id_peminjaman = @id_peminjaman AND id_buku = @id_buku";

                SqlCommand cmd = new SqlCommand(qry, LoginForm.conn);
                cmd.Parameters.AddWithValue("@id_peminjaman", idPeminjaman);
                cmd.Parameters.AddWithValue("@id_buku", idBuku);


                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
            }
            return false;
        }

        // Add the, you guessed it, detail peminjaman
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
                // insert into peminjaman_buku
                string qryPeminjamanBuku = @"
            INSERT INTO peminjaman_buku (id_peminjaman, id_buku, jml_pinjam)
            VALUES (@id_peminjaman, @id_buku, @jml_pinjam);";


                SqlCommand cmdPeminjamanBuku = new SqlCommand(qryPeminjamanBuku, LoginForm.conn);
                cmdPeminjamanBuku.Parameters.AddWithValue("@id_peminjaman", id_peminjaman);
                cmdPeminjamanBuku.Parameters.AddWithValue("@id_buku", idBuku);
                cmdPeminjamanBuku.Parameters.AddWithValue("@jml_pinjam", jumlahPinjam);

                LoginForm.connOpen();
                cmdPeminjamanBuku.ExecuteNonQuery();


                ReduceBookStock(idBuku, jumlahPinjam);

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
                LoginForm.connOpen();
                updatePeminjamanCmd.ExecuteNonQuery();


                // Get currently borrowed book stock
                string qryGetStock = "SELECT jml_pinjam FROM peminjaman_buku WHERE id_buku = @id_buku AND id_peminjaman=@id_peminjaman";
                SqlCommand cmdGetStock = new SqlCommand(qryGetStock, LoginForm.conn);
                cmdGetStock.Parameters.AddWithValue("@id_peminjaman", id_peminjaman);
                cmdGetStock.Parameters.AddWithValue("@id_buku", idBuku);
                object result = cmdGetStock.ExecuteScalar();

                int currentlyBorrowedStock = result != null ? Convert.ToInt32(result) : 0;
                // Add it back to the book stock
                AddBookStock(idBuku, currentlyBorrowedStock);

                // Update peminjaman_buku 
                string updatePeminjamanBukuQuery = @"
            UPDATE peminjaman_buku
            SET jml_pinjam = @jml_pinjam
            WHERE id_peminjaman = @id_peminjaman AND id_buku = @id_buku";
                SqlCommand updatePeminjamanBukuCmd = new SqlCommand(updatePeminjamanBukuQuery, LoginForm.conn);
                updatePeminjamanBukuCmd.Parameters.AddWithValue("@jml_pinjam", jumlahPinjam);
                updatePeminjamanBukuCmd.Parameters.AddWithValue("@id_peminjaman", id_peminjaman);
                updatePeminjamanBukuCmd.Parameters.AddWithValue("@id_buku", idBuku);

                LoginForm.connOpen();
                updatePeminjamanBukuCmd.ExecuteNonQuery();

                //then add it again to reflect the newly added value
                ReduceBookStock(idBuku, jumlahPinjam);
                MessageBox.Show("Data peminjaman berhasil di update!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"An error occurred while updating the data: {ex.Message}");
            }
            finally
            {
                if (LoginForm.conn.State == ConnectionState.Open)
                    LoginForm.conn.Close();
                ResetValues();
            }
        }

        private void DeleteData()
        {
            try
            {
                LoginForm.connOpen();
                // confirm if the user really want to delete the data
                // enetered parameters based on the order theyre appearing in : the message box content, message box title, messagebox type 
                DialogResult confirmDelete = MessageBox.Show("Anda yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo);
                if (confirmDelete == DialogResult.Yes)
                {
                    // Query to get stock information
                    string qryGetStock = "SELECT id_buku, jml_pinjam FROM peminjaman_buku WHERE id_peminjaman = @id_peminjaman";
                    DataTable dataTable = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(qryGetStock, LoginForm.conn))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@id_peminjaman", id_peminjaman);
                        adapter.Fill(dataTable);
                    }

                    // Iterate over rows in DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        int bookId = Convert.ToInt32(row["id_buku"]);
                        int borrowedStock = Convert.ToInt32(row["jml_pinjam"]);

                        // Safely update book stock
                        AddBookStock(bookId, borrowedStock);
                    }


                    // 1. delete every peminjaman detail with the current selected id_peminjaman 
                    SqlCommand delPeminjamanDetail = new SqlCommand("DELETE FROM peminjaman_buku WHERE id_peminjaman=@id_peminjaman", LoginForm.conn);
                    delPeminjamanDetail.Parameters.AddWithValue("@id_peminjaman", SqlDbType.VarChar).Value = id_peminjaman;

                    // 2. delete peminjaman
                    SqlCommand delPeminjaman = new SqlCommand("DELETE FROM [peminjaman] WHERE id_peminjaman=@id_peminjaman", LoginForm.conn);
                    delPeminjaman.Parameters.AddWithValue("@id_peminjaman", SqlDbType.VarChar).Value = id_peminjaman;



                    //execute
                    LoginForm.connOpen();
                    delPeminjamanDetail.ExecuteNonQuery();
                    delPeminjaman.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil dihapus");
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

            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchData();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            AddDetailPeminjaman();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            DeleteData();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddNewPeminjaman();
        }

        private void dtgvPeminjaman_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Safeguard if thw user clicked on invalid row
            if (e.RowIndex < 0) return;

            int index = e.RowIndex;
            DataGridViewRow selectedRow = dtgvPeminjaman.Rows[index];
            id_peminjaman = (int)selectedRow.Cells[0].Value;
            int userid = (int)selectedRow.Cells[1].Value;

            SqlCommand detail = new SqlCommand("SELECT pb.*, b.judul_buku " +
    "FROM peminjaman_buku pb " +
    "JOIN buku b ON pb.id_buku = b.id_buku " +
    "WHERE pb.id_peminjaman = @id_peminjaman;", LoginForm.conn);
            detail.Parameters.AddWithValue("@id_peminjaman", id_peminjaman);
            SqlDataAdapter detailsda = new SqlDataAdapter(detail);
            DataTable detaildt = new DataTable();
            detailsda.Fill(detaildt);

            dtgvPeminjamanDetail.DataSource = detaildt;
            detailsda.Dispose();

            LoginForm.connOpen();
            SqlCommand nis = new SqlCommand("SELECT nis FROM siswa WHERE id_user=@id_user", LoginForm.conn);
            nis.Parameters.AddWithValue("@id_user", userid);
            object result = nis.ExecuteScalar();
            LoginForm.conn.Close();
            txtNIS.Text =result.ToString();

            cbNama.SelectedValue = (int)selectedRow.Cells[1].Value;
        }

        private void dtgvPeminjamanDetail_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Safeguard if thw user clicked on invalid row
            if (e.RowIndex < 0) return;

            int index = e.RowIndex;
            DataGridViewRow selectedRow = dtgvPeminjamanDetail.Rows[index];

            cbJudul.SelectedValue = (int)selectedRow.Cells[2].Value;
            txtIDBuku.Text = selectedRow.Cells[2].Value.ToString();
            numStok.Value = (int)selectedRow.Cells[3].Value;
        }

        private void dtgvPeminjamanDetail_AllowUserToDeleteRowsChanged(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            displayTable();
            ResetValues();
        }
    }
}

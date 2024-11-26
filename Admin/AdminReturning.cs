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
        int? id_peminjaman, id_pengembalian;
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
            displayTable();
        }
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

        private static bool CheckDuplicate(int idPeminjaman, int idBuku)
        {
            try
            {
                LoginForm.connOpen();
                string qry = @"
        SELECT COUNT(*) 
        FROM pengembalian 
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
            try
            {
                LoginForm.connOpen();
                if (id_peminjaman != null && cbJudul.SelectedValue != null)
                {
                    if (!CheckDuplicate((int)id_peminjaman, (int)cbJudul.SelectedValue))
                    {
                        SqlCommand peminjaman = new SqlCommand("SELECT tgl_kembali FROM peminjaman WHERE id_peminjaman=@id_peminjaman", LoginForm.conn);
                        peminjaman.Parameters.AddWithValue("@id_peminjaman", id_peminjaman);

                        object result = peminjaman.ExecuteScalar();

                        DateTime tglKembaliRil = Convert.ToDateTime(result);
                        DateTime tglKembali = dtpPengembalian.Value;



                        int denda = (tglKembali.Subtract(tglKembaliRil).Days) * 1000;


                        if (denda < 0)
                        {
                            DialogResult conf = MessageBox.Show("Anda hendak melakukan pengembalian sebelum tenggat. Apakah anda yakin?", "Konfirmasi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (conf == DialogResult.OK)
                            {
                                denda = 0;
                            }
                            else if (conf == DialogResult.Cancel)
                            {
                                return;
                            }
                        }
                        SqlCommand addData = new SqlCommand("INSERT INTO [dbo].[pengembalian]([id_peminjaman],[id_buku],[tgl_kembali],[denda]) VALUES(@id_peminjaman,@id_buku,@tgl_kembali,@denda)", LoginForm.conn);

                        addData.Parameters.AddWithValue("@id_peminjaman", id_peminjaman);
                        addData.Parameters.AddWithValue("@id_buku", cbJudul.SelectedValue);
                        addData.Parameters.AddWithValue("@tgl_kembali", tglKembali);
                        addData.Parameters.AddWithValue("@denda", denda);

                        addData.ExecuteNonQuery();

                        SqlCommand sumDendaCmd = new SqlCommand("SELECT SUM(denda) FROM pengembalian WHERE id_peminjaman = @id_peminjaman", LoginForm.conn);
                        sumDendaCmd.Parameters.AddWithValue("@id_peminjaman", id_peminjaman);

                        object shdbajd = sumDendaCmd.ExecuteScalar();
                        int totalDenda = Convert.ToInt32(shdbajd);

                        string qryUpdatePeminjaman = @"UPDATE peminjaman SET denda = @denda WHERE id_peminjaman = @id_peminjaman";

                        SqlCommand updatePeminjamanCmd = new SqlCommand(qryUpdatePeminjaman, LoginForm.conn);
                        updatePeminjamanCmd.Parameters.AddWithValue("@denda", totalDenda);
                        updatePeminjamanCmd.Parameters.AddWithValue("@id_peminjaman", id_peminjaman);
                        LoginForm.connOpen();
                        updatePeminjamanCmd.ExecuteNonQuery();

                        LoginForm.conn.Close();

                        MessageBox.Show("Data added successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        displayTable();
                        ResetValues();
                    }
                    else
                    {
                        MessageBox.Show("Buku ini sudah dikembalikan!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Mohon pilih peminjaman dan judul buku terlebih dahulu!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error encountered : " + ex);
            }
        }

        private void UpdateData()
        {
            try
            {
                LoginForm.connOpen();

                if (id_peminjaman != null && cbJudul.SelectedValue != null)
                {
                    // Check if the data already exists
                    SqlCommand checkDataCmd = new SqlCommand(
                        "SELECT COUNT(*) FROM pengembalian WHERE id_peminjaman = @id_peminjaman AND id_buku = @id_buku",
                        LoginForm.conn
                    );
                    checkDataCmd.Parameters.AddWithValue("@id_peminjaman", id_peminjaman);
                    checkDataCmd.Parameters.AddWithValue("@id_buku", cbJudul.SelectedValue);

                    int dataExists = Convert.ToInt32(checkDataCmd.ExecuteScalar());

                    if (dataExists > 0)
                    {
                        // If data exists, proceed with updating it
                        SqlCommand peminjaman = new SqlCommand("SELECT tgl_kembali FROM peminjaman WHERE id_peminjaman=@id_peminjaman", LoginForm.conn);
                        peminjaman.Parameters.AddWithValue("@id_peminjaman", id_peminjaman);

                        object result = peminjaman.ExecuteScalar();

                        DateTime tglKembaliRil = Convert.ToDateTime(result);
                        DateTime tglKembali = dtpPengembalian.Value;

                        int denda = (tglKembali.Subtract(tglKembaliRil).Days) * 1000;

                        if (denda < 0)
                        {
                            DialogResult conf = MessageBox.Show(
                                "Anda hendak melakukan pengembalian sebelum tenggat. Apakah anda yakin?",
                                "Konfirmasi",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Question
                            );

                            if (conf == DialogResult.OK)
                            {
                                denda = 0;
                            }
                            else if (conf == DialogResult.Cancel)
                            {
                                return;
                            }
                        }

                        // Update the existing data
                        SqlCommand updateDataCmd = new SqlCommand(
                            "UPDATE [dbo].[pengembalian] " +
                            "SET tgl_kembali = @tgl_kembali, denda = @denda " +
                            "WHERE id_peminjaman = @id_peminjaman AND id_buku = @id_buku",
                            LoginForm.conn
                        );

                        updateDataCmd.Parameters.AddWithValue("@id_peminjaman", id_peminjaman);
                        updateDataCmd.Parameters.AddWithValue("@id_buku", cbJudul.SelectedValue);
                        updateDataCmd.Parameters.AddWithValue("@tgl_kembali", tglKembali);
                        updateDataCmd.Parameters.AddWithValue("@denda", denda);

                        updateDataCmd.ExecuteNonQuery();

                        // Update total denda for the `peminjaman`
                        SqlCommand sumDendaCmd = new SqlCommand(
                            "SELECT SUM(denda) FROM pengembalian WHERE id_peminjaman = @id_peminjaman",
                            LoginForm.conn
                        );
                        sumDendaCmd.Parameters.AddWithValue("@id_peminjaman", id_peminjaman);

                        object totalDendaObj = sumDendaCmd.ExecuteScalar();
                        int totalDenda = Convert.ToInt32(totalDendaObj ?? 0);

                        SqlCommand updatePeminjamanCmd = new SqlCommand(
                            "UPDATE peminjaman SET denda = @denda WHERE id_peminjaman = @id_peminjaman",
                            LoginForm.conn
                        );
                        updatePeminjamanCmd.Parameters.AddWithValue("@denda", totalDenda);
                        updatePeminjamanCmd.Parameters.AddWithValue("@id_peminjaman", id_peminjaman);

                        updatePeminjamanCmd.ExecuteNonQuery();

                        MessageBox.Show("Data updated successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        displayTable();
                        ResetValues();
                    }
                    else
                    {
                        MessageBox.Show("Data tidak ditemukan untuk diperbarui!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Mohon pilih peminjaman dan judul buku terlebih dahulu!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error encountered: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (LoginForm.conn.State == ConnectionState.Open)
                    LoginForm.conn.Close();
            }
        }

        public void DeleteData()
        {
            try
            {
                LoginForm.connOpen();

                // confirm if the user really want to delete the data 
                DialogResult confirmDelete = MessageBox.Show("Anda yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo);
                if (confirmDelete == DialogResult.Yes)
                {
                    SqlCommand delPeminjamanDetail = new SqlCommand("DELETE FROM pengembalian WHERE id_peminjaman=@id_peminjaman AND id_pengembalian = @id_pengembalian", LoginForm.conn);
                    delPeminjamanDetail.Parameters.AddWithValue("@id_peminjaman", SqlDbType.VarChar).Value = id_peminjaman;
                    delPeminjamanDetail.Parameters.AddWithValue("@id_peminjaman", SqlDbType.VarChar);

                    //execute
                    LoginForm.connOpen();
                    delPeminjamanDetail.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil dihapus");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error encountered: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dtgvPeminjaman_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Safeguard if thw user clicked on invalid row
            if (e.RowIndex < 0) return;

            int index = e.RowIndex;
            DataGridViewRow selectedRow = dtgvPeminjaman.Rows[index];
            id_peminjaman = (int)selectedRow.Cells[0].Value;

            SqlCommand pengembalian = new SqlCommand("SELECT p.*, b.judul_buku " + "FROM pengembalian p " + "INNER JOIN buku b ON p.id_buku = b.id_buku " + "WHERE p.id_peminjaman = " + id_peminjaman + ";", LoginForm.conn);
            SqlDataAdapter pengembaliansda = new SqlDataAdapter(pengembalian);
            DataTable pengembaliandt = new DataTable();
            pengembaliansda.Fill(pengembaliandt);

            SqlCommand detail = new SqlCommand(@"SELECT peminjaman_buku.id_buku,buku.judul_buku FROM peminjaman_buku JOIN buku ON peminjaman_buku.id_buku = buku.id_buku WHERE peminjaman_buku.id_peminjaman = @id_peminjaman;", LoginForm.conn);
            detail.Parameters.AddWithValue("@id_peminjaman", id_peminjaman);
            SqlDataAdapter detailsda = new SqlDataAdapter(detail);
            DataTable detaildt = new DataTable();
            detailsda.Fill(detaildt);


            cbJudul.DataSource = detaildt;
            cbJudul.DisplayMember = "judul_buku";
            cbJudul.ValueMember = "id_buku";

            cbJudul.SelectedIndex = -1;
            dtgvPengembalian.DataSource = pengembaliandt;
            pengembaliansda.Dispose();

            cbNama.SelectedValue = (int)selectedRow.Cells[1].Value;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void dtgvPengembalian_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

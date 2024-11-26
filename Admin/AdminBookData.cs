using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desainperpus_vanya
{
    public partial class AdminBookData : UserControl
    {
        int? id;
        public AdminBookData()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy";
            dateTimePicker1.ShowUpDown = true;
            displayTable();
        }

        private void addData()
        {
            try
            {
                LoginForm.connOpen();
                SqlCommand addData = new SqlCommand("INSERT into buku values (@judul,@pengarang,@penerbit,@tahunterbit,@stok)", LoginForm.conn);

                addData.Parameters.AddWithValue("@judul", txtJudul.Text);
                addData.Parameters.AddWithValue("@pengarang", txtPengarang.Text);
                addData.Parameters.AddWithValue("@penerbit", txtPenerbit.Text);
                addData.Parameters.AddWithValue("@tahunterbit", dateTimePicker1.Value.Year);
                addData.Parameters.AddWithValue("@stok", numStok.Value);
                addData.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Terdapat kesalahan: {ex.Message}");
            }
            finally
            {
                if (LoginForm.conn.State == ConnectionState.Open)
                    LoginForm.conn.Close();
                MessageBox.Show("Data berhasil ditambahkan.");
                displayTable();
                ResetValues();
            }
        }

        private void displayTable()
        {

            LoginForm.connOpen();
            SqlCommand query = new SqlCommand("SELECT * FROM buku", LoginForm.conn);
            SqlDataAdapter sda = new SqlDataAdapter(query);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;
            sda.Dispose();
        }

        private void updateData()
        {
            try
            {
                SqlCommand updateData = new SqlCommand("UPDATE buku set judul_buku=@judul, pengarang=@pengarang, penerbit=@penerbit,  tahun_terbit=@tahunterbit, stok=@stok  WHERE id_buku=@id_buku", LoginForm.conn);
                updateData.Parameters.AddWithValue("@id_buku", SqlDbType.VarChar).Value = id;
                updateData.Parameters.AddWithValue("@judul", txtJudul.Text);
                updateData.Parameters.AddWithValue("@pengarang", txtPengarang.Text);
                updateData.Parameters.AddWithValue("@penerbit", txtPenerbit.Text);
                updateData.Parameters.AddWithValue("@tahunterbit", dateTimePicker1.Value.Year);
                updateData.Parameters.AddWithValue("@stok", numStok.Value);
                updateData.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Terdapat kesalahan: {ex.Message}");
            }
            finally
            {
                if (LoginForm.conn.State == ConnectionState.Open)
                    LoginForm.conn.Close();
                MessageBox.Show("Data berhasil di update.");
                displayTable();
                ResetValues();
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            id = (int)selectedRow.Cells[0].Value;

            txtJudul.Text = selectedRow.Cells[1].Value.ToString();
            txtPengarang.Text = selectedRow.Cells[2].Value.ToString();
            txtPenerbit.Text = selectedRow.Cells[3].Value.ToString();
            int year = int.Parse(selectedRow.Cells[4].Value.ToString());
            dateTimePicker1.Value = new DateTime(year, 1, 1);

            numStok.Value = (Int32)selectedRow.Cells[5].Value;
        }
        private void DelData()
        {
            SqlCommand deleteData = new SqlCommand("DELETE buku WHERE id_buku=@id_buku", LoginForm.conn);
            deleteData.Parameters.AddWithValue("@id_buku", SqlDbType.VarChar).Value = id;
            deleteData.ExecuteNonQuery();

            displayTable();
            MessageBox.Show("Data berhasil dihapus");
            ResetValues();

        }

        private void ResetValues()
        {
            id = null;
            txtJudul.Text = null;
            txtPengarang.Text = null;
            txtPenerbit.Text = null;
            dateTimePicker1.Value = DateTime.Now;
            numStok.Value = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtJudul.Text) || String.IsNullOrEmpty(txtPengarang.Text) || String.IsNullOrEmpty(txtPenerbit.Text))
            {
                MessageBox.Show("Semua kolom harus terisi untuk menambahkan data.");
            }
            else
            {
                updateData();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtJudul.Text) || String.IsNullOrEmpty(txtPengarang.Text) || String.IsNullOrEmpty(txtPenerbit.Text))
            {
                MessageBox.Show("Semua kolom harus terisi untuk menambahkan data.");
            }
            else if (id != null)
            {
                MessageBox.Show("Semua kolom harus terisi untuk menambahkan data.");
            }
            else
            {
                addData();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (id == null)
            {
                MessageBox.Show("Mohon pilih data terlebih dahulu!");
            }
            else
            {
                DelData();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void SearchData()
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                try
                {
                    LoginForm.connOpen();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM buku WHERE buku.judul_buku LIKE '%' + @query + '%' OR buku.pengarang LIKE '%' + @query + '%' OR buku.penerbit LIKE '%' + @query + '%' OR buku.tahun_terbit LIKE '%' + @query + '%' OR buku.stok LIKE '%' + @query + '%';", LoginForm.conn);
                    cmd.Parameters.AddWithValue("@query", txtSearch.Text.Trim());
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ResetValues();
            displayTable();
        }
    }
}

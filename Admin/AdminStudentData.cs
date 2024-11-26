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
    public partial class AdminStudentData : UserControl
    {
        int? studentId;
        int? userId;
        public AdminStudentData()
        {
            InitializeComponent();
            displayTable();
        }
        private void displayTable()
        {
            LoginForm.connOpen();
            SqlCommand query = new SqlCommand("SELECT \r\n    u.id_user,\r\n    u.nama AS UserName,\r\n    u.username,\r\n    u.password,\r\n    u.email,\r\n    u.no_telp,\r\n    s.id_siswa,\r\n    s.nis,\r\n    s.kelas,\r\n    s.alamat\r\nFROM \r\n    dbo.[user] u\r\nLEFT JOIN \r\n    dbo.siswa s ON u.id_user = s.id_user\r\n WHERE u.role='siswa'", LoginForm.conn);
            SqlDataAdapter sda = new SqlDataAdapter(query);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;
            sda.Dispose();
        }

        private void AddData()
        {
            SqlCommand addUser = new SqlCommand(
       "INSERT INTO [user] (nama, username, password, role, no_telp, email) OUTPUT INSERTED.id_user VALUES (@nama, @username, @password, @role, @telp, @email)",
       LoginForm.conn);

            addUser.Parameters.AddWithValue("@nama", txtNama.Text);
            addUser.Parameters.AddWithValue("@username", txtUsername.Text);
            addUser.Parameters.AddWithValue("@password", txtPassword.Text);
            addUser.Parameters.AddWithValue("@role", "siswa");
            addUser.Parameters.AddWithValue("@telp", txtTelp.Text);
            addUser.Parameters.AddWithValue("@email", txtEmail.Text);

            int newUserId = (int)addUser.ExecuteScalar();

            SqlCommand addSiswa = new SqlCommand(
                "INSERT INTO siswa (id_user, nis, kelas, alamat) VALUES (@id_user, @nis, @kelas, @alamat)",
                LoginForm.conn);

            addSiswa.Parameters.AddWithValue("@id_user", newUserId);
            addSiswa.Parameters.AddWithValue("@nis", txtNIS.Text);
            addSiswa.Parameters.AddWithValue("@kelas", txtKelas.Text);
            addSiswa.Parameters.AddWithValue("@alamat", txtAlamat.Text);

            addSiswa.ExecuteNonQuery();

            displayTable();
            ResetValues();

            MessageBox.Show("Data berhasil ditambahkan");


        }
        private void UpdateData()
        {
            SqlCommand updateUser = new SqlCommand("UPDATE dbo.[user]\r\nSET \r\n    nama = @nama,\r\n    username = @username,\r\n    password = @password,\r\n    email = @email,\r\n    no_telp = @no_telp,\r\n    role = @role\r\nWHERE \r\n    id_user = @id_user;", LoginForm.conn);
            SqlCommand updateSiswa = new SqlCommand("UPDATE dbo.siswa\r\nSET \r\n    nis = @nis,\r\n    kelas = @kelas,\r\n    alamat = @alamat\r\nWHERE \r\n    id_user = @id_user;", LoginForm.conn);

            updateUser.Parameters.AddWithValue("@nama", txtNama.Text);
            updateUser.Parameters.AddWithValue("@username", txtUsername.Text);
            updateUser.Parameters.AddWithValue("@password", txtPassword.Text);
            updateUser.Parameters.AddWithValue("@email", txtEmail.Text);
            updateUser.Parameters.AddWithValue("@no_telp", txtTelp.Text);
            updateUser.Parameters.AddWithValue("@role", "siswa");
            updateUser.Parameters.AddWithValue("@id_user", userId);

            updateSiswa.Parameters.AddWithValue("@nis", txtNIS.Text);
            updateSiswa.Parameters.AddWithValue("@kelas", txtKelas.Text);
            updateSiswa.Parameters.AddWithValue("@alamat", txtAlamat.Text);
            updateSiswa.Parameters.AddWithValue("@id_user", userId);

            updateUser.ExecuteNonQuery();
            updateSiswa.ExecuteNonQuery();

            MessageBox.Show("Data berhasil di update.");

            displayTable();
            ResetValues();
        }

        private void DeleteData()
        {
            LoginForm.connOpen();
            SqlCommand deleteStudent = new SqlCommand("DELETE FROM siswa WHERE id_siswa=@id_siswa", LoginForm.conn);
            deleteStudent.Parameters.AddWithValue("@id_siswa", SqlDbType.VarChar).Value = studentId;

            SqlCommand deleteUser = new SqlCommand("DELETE FROM [user] WHERE id_user=@id_user", LoginForm.conn);
            deleteUser.Parameters.AddWithValue("@id_user", SqlDbType.VarChar).Value = userId;

            deleteStudent.ExecuteNonQuery();
            deleteUser.ExecuteNonQuery();

            displayTable();
            ResetValues();
            MessageBox.Show("Data berhasil dihapus");
        }

        private void ResetValues()
        {
            txtNIS.Text = null;
            txtAlamat.Text = null;
            txtKelas.Text = null;
            txtNama.Text = null;
            txtPassword.Text = null;
            txtEmail.Text = null;
            txtTelp.Text = null;
            txtUsername.Text = null;
        }

        //Add button
        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm.connOpen();
            AddData();

            MessageBox.Show("Data berhasil ditambahkan");
        }
        //Edit btn
        private void button2_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        //Del btn
        private void btnDel_Click(object sender, EventArgs e)
        {
            DeleteData();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            userId = (int)selectedRow.Cells[0].Value;
            txtNama.Text = selectedRow.Cells[1].Value.ToString();
            txtUsername.Text = selectedRow.Cells[2].Value.ToString();
            txtPassword.Text = selectedRow.Cells[3].Value.ToString();
            txtEmail.Text = selectedRow.Cells[4].Value.ToString();
            txtTelp.Text = selectedRow.Cells[5].Value.ToString();
            studentId = (int)selectedRow.Cells[6].Value;
            txtNIS.Text = selectedRow.Cells[7].Value.ToString();
            txtKelas.Text = selectedRow.Cells[8].Value.ToString();
            txtAlamat.Text = selectedRow.Cells[9].Value.ToString();
        }
        public void SearchData()
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                try
                {
                    LoginForm.connOpen();

                    // Joins the user and siswa tables and searches for any matches in the specified columns (nis, nama, kelas, alamat, no_telp, username, and password)
                    SqlCommand cmd = new SqlCommand("SELECT \r\n    u.id_user,\r\n    u.nama AS UserName,\r\n    u.username,\r\n    u.password,\r\n    u.email,\r\n    u.no_telp,\r\n    s.id_siswa,\r\n    s.nis,\r\n    s.kelas,\r\n    s.alamat\r\nFROM \r\n    dbo.[user] u\r\nLEFT JOIN \r\n    dbo.siswa s ON u.id_user = s.id_user\r\n WHERE  s.nis LIKE '%' + @query + '%' OR u.nama LIKE '%' + @query + '%' OR s.kelas LIKE '%' + @query + '%' OR s.alamat LIKE '%' + @query + '%' OR u.no_telp LIKE '%' + @query + '%' OR u.username LIKE '%' + @query + '%' OR u.password LIKE '%' + @query + '%';", LoginForm.conn);
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
    }
}

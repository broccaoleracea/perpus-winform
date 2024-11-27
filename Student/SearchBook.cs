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

namespace desainperpus_vanya.Student
{
    public partial class SearchBook : UserControl
    {
        public SearchBook()
        {
            InitializeComponent();
            ShowTables();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
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
                ShowTables();
            }
        }

        private void ShowTables()
        {
            try
            {
                LoginForm.connOpen();

                SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand("SELECT * FROM buku", LoginForm.conn));
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
    }
}

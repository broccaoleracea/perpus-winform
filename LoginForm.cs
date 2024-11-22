using Microsoft.Data.SqlClient;
using System.Data;

namespace desainperpus_vanya
{
    public partial class LoginForm : Form
    {

        public static SqlConnection conn = new SqlConnection(Connection.conn);
        public SqlCommand cmd;
        public SqlDataAdapter adapter;
        public DataTable dt;
        public SqlDataReader reader;


        public static bool connOpen()
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                return true;
            }
            else
            {
                conn.Close();
                conn.Open();
                return false;
            }
        }

        public void ResetFields()
        {
            txtUsername.Text = null;
            txtPass.Text = null;
        }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connOpen();
            string sqlcmd = "SELECT * FROM [user] WHERE username ='" + txtUsername.Text + "'AND password ='" + txtPass.Text + "'";
            cmd = new SqlCommand(sqlcmd, conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                        reader = cmd.ExecuteReader();
                        reader.Read();
                        UserInfo.UserName= reader.GetString(1);

                    if (dr["role"].ToString() == "admin")
                    {
                        AdminDash dash = new AdminDash(this);
                        dash.Show();
                    }
                    else if (dr["role"].ToString() == "siswa")
                    {
                        StudentDash dash = new StudentDash(this);
                        dash.Show();
                    }
                    ResetFields();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Username atau Password salah!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

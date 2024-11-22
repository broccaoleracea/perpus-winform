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
    public partial class StudentDash : Form
    {
        private LoginForm loginForm;
        public StudentDash(LoginForm login)
        {
            InitializeComponent();
            lblGreeting.Text = "Welcome, " + UserInfo.UserName + "!";
            loginForm = login;
            pnlHighlight.Height = button1.Height;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void adminDashContent1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlHighlight.Location = new Point(
                 227,
                 button1.Location.Y
             );
            //adminDashContent1.BringToFront();
        }

        private void AdminDash_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlHighlight.Location = new Point(
                 227,
                 button2.Location.Y
             );
            //adminStudentData1.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pnlHighlight.Location = new Point(
                 227,
                 button4.Location.Y
             );
            //adminBookData2.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pnlHighlight.Location = new Point(
                 227,
                 button3.Location.Y
             );
            //adminBorrowing1.BringToFront();
        }

        private void AdminDash_FormClosing(object sender, FormClosingEventArgs e)
        {
            loginForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

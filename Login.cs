using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore
{
    public partial class Login : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=HQ\\SQLEXPRESS;Initial Catalog=acc_data;Integrated Security=true;");
        SqlCommand cmd;
        SqlDataAdapter adapt;


        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            this.Hide();
            Home hm = new Home();
            hm.ShowDialog();

        }

        private void btnForgetPass_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangePassword cp = new ChangePassword();
            cp.ShowDialog();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txbPassword.PasswordChar == '\0')
            {
                txbPassword.PasswordChar = '*';
            }
        }
        private void txtPassword_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

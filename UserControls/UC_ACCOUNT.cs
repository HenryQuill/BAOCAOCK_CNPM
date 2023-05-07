﻿using Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore.UserControls
{
    public partial class UC_ACCOUNT : UserControl

    {
        UserModel dm;
        public UC_ACCOUNT()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string passhashdouble = SecurityUtils.SaltedHash(txbPassword.Text);
            
            dm = new UserModel(txbUsername.Text,passhashdouble);
            SqlConnection conn = ConnectionSingleton.GetConnection();
            // check if user email already existed
            if (dm.CheckIfUserExists(ConnectionSingleton.GetConnection()))
            {
                MessageBox.Show("User already existed");
                txbUsername.Focus();
            }
            else
            {
                dm.InsertUser(conn);
            }
        }
    }
}

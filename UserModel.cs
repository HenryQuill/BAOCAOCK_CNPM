using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Login
{
    internal class UserModel
    {

        public string Username { get; set; }
        public string Pass { get; set; }


        public UserModel() { }

        public UserModel(string username, string pass)
        {

            Username = username;
            Pass = pass;

        }

        public void InsertUser(SqlConnection connection)
        {
            string query = "INSERT INTO account (username, pass) " +
                           "VALUES (@Username,@Pass)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.AddWithValue("@Username", Username);
                command.Parameters.AddWithValue("@Pass", Pass);
                command.ExecuteNonQuery();
            }
        }

        public bool CheckIfUserExists(SqlConnection connection)
        {
            string query = "SELECT COUNT(*) FROM account WHERE username = @Username";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", Username);
                //MessageBox.Show(Username);
                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }

        public bool CheckIfNewPasswordIsSameAsOld(SqlConnection connection)
        {
            string query = "SELECT pass FROM account WHERE username = @Username";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", Username);

                string oldPassword = (string)command.ExecuteScalar();

                return Pass == oldPassword;
            }
        }
    }
}

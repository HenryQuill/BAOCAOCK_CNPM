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

namespace BookStore.UserControls
{
    public partial class UC_Purchase2 : UserControl
    {
        public UC_Purchase2()
        {
            InitializeComponent();
            DisplayData();
        }
        SqlConnection conn = new SqlConnection("Data Source=HQ\\SQLEXPRESS;Initial Catalog=acc_data;Integrated Security=true;");
        SqlCommand cmd;
        SqlDataAdapter adapt;

        private void DisplayData()
        {
            //SqlConnection conn = ConnectionSingleton.GetConnection();
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt;
            adapt = new SqlDataAdapter("select * from nhaphang", conn);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" && txtTitle.Text != "" && txtAuthor.Text != "" && txtNXB.Text != "" && txtSL.Text != "")
            {
                cmd = new SqlCommand("insert into nhaphang(ID,tenSach,tacGia,NXB_nhap,SoLuong) values(@ID,@tenSach,@tacGia,@NXB_nhap,@SoLuong)", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@ID", txtID.Text);
                cmd.Parameters.AddWithValue("@tenSach", txtTitle.Text);
                cmd.Parameters.AddWithValue("@tacGia", txtAuthor.Text);
                cmd.Parameters.AddWithValue("@NXB_nhap", txtNXB.Text);
                cmd.Parameters.AddWithValue("@SoLuong", txtSL.Text);

                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("them sach thanh cong");
                DisplayData();
                //ClearData();
            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                //SqlConnection conn = ConnectionSingleton.GetConnection();
                cmd = new SqlCommand("delete nhaphang where ID=@ID", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@ID", txtID.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Record Deleted Successfully!");
                DisplayData();
                //ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }
    }
}

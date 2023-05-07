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
using System.Configuration;

namespace BookStore.UserControls
{
    public partial class UC_PURCHASE : UserControl
    {
        public UC_PURCHASE()
        {
            InitializeComponent();
            DisplayData();
        }

        SqlConnection conn = new SqlConnection("Data Source=CUC-CUC-CUTE\\SQLEXPRESS;Initial Catalog=data;Integrated Security=true;");
        SqlCommand cmd;
        SqlDataAdapter adapt;


        private void DisplayData()
        {
            //SqlConnection conn = ConnectionSingleton.GetConnection();
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt;
            adapt = new SqlDataAdapter("select * from nhaphang2", conn);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UC_PURCHASE_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (/*txtID.Text != "" &&*/ txtTitle.Text != "" && txtAuthor.Text != "" && txtNXB.Text != "" && txtSL.Text != "")
            {
                cmd = new SqlCommand("insert into nhaphang(tenSach,tacGia,NXB_nhap,SoLuong) values(@tenSach,@tacGia,@NXB_nhap,@SoLuong)", conn);
                //da xoa id va @id
                conn.Open();
                //cmd.Parameters.AddWithValue("@ID", txtID.Text);
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
    }
}

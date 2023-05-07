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
    public partial class UC_STORAGE : UserControl
    {
        SqlConnection conn = new SqlConnection("Data Source=HQ\\SQLEXPRESS;Initial Catalog=acc_data;Integrated Security=true;");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        public UC_STORAGE()
        {
            InitializeComponent();
            DisplayData();
        }

        private void btnAddNewBooks_Click(object sender, EventArgs e)
        {
            this.Hide();
            add ad = new add();
            ad.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public bool KTThongTin()
        {
            if (txbMasach.Text == "")
            {
                MessageBox.Show("Vui lòng nhập ID", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbMasach.Focus();
                return false;
            }
            if (txbTensach.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbTensach.Focus();
                return false;
            }
            if (txbTacgia.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên tác giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbTacgia.Focus();
                return false;
            }
            if (txbNXB.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên NXB", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbNXB.Focus();
                return false;
            }
            if (txbSoluong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbSoluong.Focus();
                return false;
            }
            return true;
        }

        //them sach
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txbMasach.Text != "" && txbTensach.Text != "" && txbTacgia.Text != "" && txbNXB.Text != "" && txbGiatien.Text != "" && txbSoluong.Text != "")
            {
                cmd = new SqlCommand("insert into Sach(masach,tensach,tacgia,nxb,giatien,soluong) values(  @Masach, @Tensach, @Tacgia, @NXB, @Giatien,@Soluong)", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@Masach", txbMasach.Text);
                cmd.Parameters.AddWithValue("@Tensach", txbTensach.Text);
                cmd.Parameters.AddWithValue("@Tacgia", txbTacgia.Text);
                cmd.Parameters.AddWithValue("@NXB", txbNXB.Text);
                cmd.Parameters.AddWithValue("@Giatien", txbGiatien.Text);
                cmd.Parameters.AddWithValue("@Soluong", txbSoluong.Text);
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

       
        // bieu dien du lieu len form 
        private void DisplayData()
        {
            //SqlConnection conn = ConnectionSingleton.GetConnection();
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt;
            adapt = new SqlDataAdapter("select * from Sach", conn);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        // sua thong tin sach
        private void btnChange_Click(object sender, EventArgs e)
        {
            if (txbMasach.Text != "" && txbTensach.Text != "" && txbTacgia.Text != "" && txbNXB.Text != "" && txbGiatien.Text != "" && txbSoluong.Text != "")
            {
                //SqlConnection conn = ConnectionSingleton.GetConnection();
                SqlCommand cmd = new SqlCommand("update Sach set masach=@Masach, tensach=@Tensach,  tacgia=@Tacgia, nxb=@NXB, giatien=@Giatien, soluong=@Soluong where masach=@Masach", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@Masach", txbMasach.Text);
                cmd.Parameters.AddWithValue("@Tensach", txbTensach.Text);
                cmd.Parameters.AddWithValue("@Tacgia", txbTacgia.Text);
                cmd.Parameters.AddWithValue("@NXB", txbNXB.Text);
                cmd.Parameters.AddWithValue("@Giatien", txbGiatien.Text);
                cmd.Parameters.AddWithValue("@Soluong", txbSoluong.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                conn.Close();
                DisplayData();
                //ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }
        }

        //xoa sach
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txbMasach.Text != "")
            {
                //SqlConnection conn = ConnectionSingleton.GetConnection();

                cmd = new SqlCommand("delete Sach where masach=@Masach", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@Masach", txbMasach.Text);
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

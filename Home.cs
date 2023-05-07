using BookStore.UserControls;
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
    public partial class Home : Form
    {
       
        public Home()
        {
            InitializeComponent();
            UC_Home uch = new UC_Home();
            AddControlsToPanel(uch);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddControlsToPanel(Control c)
        {
            c.Dock= DockStyle.Fill;
            panelControls.Controls.Clear();
            panelControls.Controls.Add(c);
        }
        private void btnSell_Click(object sender, EventArgs e)
        {
            UC_SELL ucs = new UC_SELL();
            AddControlsToPanel(ucs);
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            UC_Purchase2 ucp2 = new UC_Purchase2();
            AddControlsToPanel(ucp2);
        }

        private void btnStorage_Click(object sender, EventArgs e)
        {
            UC_STORAGE ucstorage = new UC_STORAGE();
            AddControlsToPanel(ucstorage);
        }

        private void btnSale_Click(object sender, EventArgs e)
        {

        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            UC_ACCOUNT uca = new UC_ACCOUNT();
            AddControlsToPanel(uca);
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void Title_Click(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            UC_Home uch = new UC_Home();
            AddControlsToPanel(uch);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

namespace Menu
{
    public partial class MoreMenu : Form
    {
        int i;
        public MoreMenu()
        {
            InitializeComponent();
            //conn = new SqlConnection(connectstring);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textCarbs.Enabled = textPro.Enabled = textfat.Enabled = textTen.Enabled = textDD.Enabled = textLoai.Enabled = false;
            dtMenu.Enabled = btnCancel.Enabled = btnSave.Enabled = textKl.Enabled = textDD.Enabled = textCalo.Enabled = false;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dtMenu.Enabled =  textCarbs.Enabled = textPro.Enabled = textfat.Enabled = textTen.Enabled = textDD.Enabled = textLoai.Enabled = true;
            btnCancel.Enabled = btnSave.Enabled = textKl.Enabled = textDD.Enabled = textCalo.Enabled = true;
            btnEdit.Enabled = btnEdit.Enabled = btnEra.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            textCarbs.Enabled = textPro.Enabled = textfat.Enabled = textTen.Enabled = textDD.Enabled = textLoai.Enabled = false;
            textCarbs.Text = textPro.Text = textfat.Text = textTen.Text = textDD.Text = textLoai.Text = "";
            btnSave.Enabled = false;
            btnEdit.Enabled = btnEra.Enabled = btnSearch.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnEra_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            textCalo.Text = textPro.Text = textCarbs.Text = textDD.Text = textKl.Text = textTen.Text = textLoai.Text = textfat.Text = "";
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtMenu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
        }
    }
}

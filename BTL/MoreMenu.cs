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
using Test_1;
using System.Collections;
using System.Windows.Controls;

namespace Menu
{
    public partial class MoreMenu : Form
    {
        int i;
        Form1 f = null;
        private SqlConnection conn;
        SqlDataAdapter da = null;
        DataTable dt = null;
        string check = "";
        string cellValue = "";
        int ok = 1;
        List<ThucDon> Menus = new List<ThucDon>();
        public MoreMenu()
        {
            InitializeComponent();
            f = new Form1();
            conn = f.GetConnection();
        }


        // hàm check dữ liệu null
        private void checkNull()
        {
            if (textCalo.Text == "" || textCarbs.Text == "" || textDD.Text == "" || textfat.Text == "" || textKl.Text == ""
                || textPro.Text == "" || textLoai.Text == "" || textTen.Text == "")
            {
                ok = 0;
            }
            else ok = 1;
        }
        // hàm check dữ liệu là 1 số
        private bool IsConvertibleToDouble(ref System.Windows.Forms.TextBox textBox)
        {
            double result;
            return double.TryParse(textBox.Text, out result); // sẽ trả về true hoặc false
        }
        private void ClearText()
        {
            textCarbs.Text = textPro.Text = textfat.Text = textTen.Text = textDD.Text = textLoai.Text = textCalo.Text = textKl.Text = "";
        }
        private void LoadData()
        {
            string query = "Select * from Menu";
            da = new SqlDataAdapter(query, conn);
            dt = new DataTable();
            da.Fill(dt);
            dtMenu.DataSource = dt;
            Menus.Clear();
            // thêm các  giá trị từ sql vào danh sách
            foreach (DataRow row in dt.Rows)
            {
                // Tạo một đối tượng ThucDon từ giá trị của mỗi dòng
                ThucDon td = new ThucDon();

                // Thiết lập các thuộc tính của đối tượng ThucDon từ giá trị của từng cột trong DataRow
                td.Name = row["Ten"].ToString();
                td.Loai = row["Loai"].ToString();
                td.Calories = Convert.ToInt32(row["Calo"]);
                td.carb = Convert.ToDouble(row["Carbs"]);
                td.fat = Convert.ToDouble(row["Fat"]);
                td.pro = Convert.ToDouble(row["Protein"]);
                td.Kl = Convert.ToDouble(row["KhoiLuong"]);
                td.nutrients = row["Chatddkhac"].ToString();
                // Thêm đối tượng ThucDon vào danh sách
                Menus.Add(td);
            }
        } 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            dtMenu.Enabled =  textCarbs.Enabled = textPro.Enabled = textfat.Enabled = textTen.Enabled = textDD.Enabled = textLoai.Enabled = true;
            btnCancel.Enabled = btnSave.Enabled = textKl.Enabled = textDD.Enabled = textCalo.Enabled = true;
            btnEdit.Enabled = btnEdit.Enabled = btnEra.Enabled = false;
            check = "Add";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            textCarbs.Enabled = textPro.Enabled = textfat.Enabled = textTen.Enabled = textDD.Enabled = textLoai.Enabled = textCalo.Enabled = textKl.Enabled = false;
            ClearText();
            btnSave.Enabled = false;
            btnEdit.Enabled = btnEra.Enabled = btnSearch.Enabled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = btnCancel.Enabled = btnEdit.Enabled = btnEra.Enabled = textTen.Enabled = true;
            btnSave.Enabled = false;
            check = "Search";
        }
        private void dtMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                DataGridViewCell selectedCell = dtMenu.Rows[e.RowIndex].Cells[1];
                cellValue = selectedCell.Value.ToString();
                //MessageBox.Show(cellValue);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dữ liệu hợp lệ!!");
                return;
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            check = "Edit";
            btnSave.Enabled = btnCancel.Enabled = true;
            btnAdd.Enabled = btnEra.Enabled = btnSearch.Enabled = textTen.Enabled = false;
            textCalo.Enabled = textCarbs.Enabled = textPro.Enabled = textKl.Enabled = textDD.Enabled = textLoai.Enabled = textfat.Enabled = true;
                foreach (ThucDon monan in Menus)
                {
                    if (monan.Name == cellValue)
                    {
                        textTen.Text = monan.Name;
                        textLoai.Text = monan.Loai;
                        textCalo.Text = monan.Calories.ToString();
                        textCarbs.Text = monan.carb.ToString();
                        textDD.Text = monan.nutrients;
                        textKl.Text = monan.Kl.ToString();
                        textPro.Text = monan.pro.ToString();
                        textfat.Text = monan.fat.ToString();
                    }
            }
        }

        private void btnEra_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(cellValue);
            string Eraquery = string.Format("DELETE FROM Menu WHERE Ten = N'{0}'", cellValue);
            SqlCommand EraCmd = new SqlCommand(Eraquery, conn);
            EraCmd.ExecuteNonQuery();
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (check == "Add")
            {
                checkNull();
                if(ok == 1)
                {
                    if (IsConvertibleToDouble(ref textCalo) && IsConvertibleToDouble(ref textKl) && IsConvertibleToDouble(ref textPro)
                    && IsConvertibleToDouble(ref textfat) && IsConvertibleToDouble(ref textCarbs))
                    {
                        string query1 = string.Format("INSERT INTO Menu VALUES (N'{0}', N'{1}', {2}, {3}, {4}, {5}, {6}, N'{7}')",
                        textLoai.Text, textTen.Text, Convert.ToDouble(textCalo.Text), Convert.ToDouble(textCarbs.Text),
                        Convert.ToDouble(textfat.Text), Convert.ToDouble(textPro.Text), Convert.ToDouble(textKl.Text), textDD.Text);
                        textCalo.Text = textPro.Text = textCarbs.Text = textDD.Text = textKl.Text = textTen.Text = textLoai.Text = textfat.Text = "";
                        SqlCommand cmdInsert = new SqlCommand(query1, conn);
                        cmdInsert.ExecuteNonQuery();
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập dữ liệu là số cho các trường:Carbs,Pro,Fat,KL,Calo!!"); return;
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập Đầy đủ dữ liệu"); return;
                }

            }    
            if(check == "Edit")
            {
                //update lại dữ liệu trong sql
                checkNull();
                if(ok==1)
                {
                    if (IsConvertibleToDouble(ref textCalo) && IsConvertibleToDouble(ref textKl) && IsConvertibleToDouble(ref textPro)
                    && IsConvertibleToDouble(ref textfat) && IsConvertibleToDouble(ref textCarbs))
                    {
                        string EditQuery = string.Format("UPDATE Menu SET Loai = N'{0}', Calo = {1}, Carbs = {2}, Fat = {3}, Protein = {4}, KhoiLuong = {5}, Chatddkhac = N'{6}' WHERE Ten = N'{7}'",
                         textLoai.Text, Convert.ToDouble(textCalo.Text), Convert.ToDouble(textCarbs.Text),
                        Convert.ToDouble(textfat.Text), Convert.ToDouble(textPro.Text), Convert.ToDouble(textKl.Text), textDD.Text, textTen.Text);
                        SqlCommand EditCmd = new SqlCommand(EditQuery, conn);
                        EditCmd.ExecuteNonQuery();
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập dữ liệu là số cho các trường:Carbs,Pro,Fat,KL,Calo!!"); return;
                    }
                }
                else 
                {
                    MessageBox.Show("Vui lòng nhập Đầy đủ dữ liệu"); return;
                }
            }
            ClearText();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MoreMenu_Load(object sender, EventArgs e)
        {
            btnAdd.Enabled = btnEdit.Enabled = btnEra.Enabled = btnSearch.Enabled = dtMenu.Enabled = true;
            btnCancel.Enabled = btnSave.Enabled = false;
            textCalo.Enabled = textCarbs.Enabled = textPro.Enabled = textKl.Enabled = textDD.Enabled = textLoai.Enabled = textTen.Enabled = textfat.Enabled = false;
            LoadData();
        }


        private void textDD_TextChanged(object sender, EventArgs e)
        {

        }


        // xử lý tìm kiếm theo tên
        private void textTen_TextChanged(object sender, EventArgs e)
        {
            //List<ThucDon> FindList = new List<ThucDon>();
            //string TenMon = textTen.Text;
            //foreach (ThucDon monan in Menus)
            //{
            //    string tmp = monan.Name.ToLower();
            //    TenMon.ToLower();
            //    if (tmp.Contains(TenMon))
            //    {
            //        FindList.Add(monan);
            //    }
            //}
            //dt.Clear();
            //dtMenu.DataSource = FindList;
        }
    }
}

using CircularProgressBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Test_1;

namespace Macro
{
    public partial class FoodnDrink : Form
    {
        private SqlConnection conn;
        Form1 f = null;
        string cellValue, Weight, dailycell;
        double weightValue = 0;
        int Skcal = 0;
        int TDEE = 2500;
        string check = "";
        int quaC = 0, quaP = 0, quaF = 0;
        public FoodnDrink()
        {
            InitializeComponent();
            f = new Form1();    
            conn = f.GetConnection();
        }
        
        SqlDataAdapter adt = new SqlDataAdapter();
        List<ThucDon> dsTd = new List<ThucDon>();

        //Hàm xử lý tràn ở các thanh process
        private void XuLyTran(ref ProgressBar progressBar, double valueToAdd, ref int Qua)
        {
            int newValue = progressBar.Value + Convert.ToInt32(valueToAdd);
            if (newValue <= progressBar.Maximum)
            {
                progressBar.Value = newValue;
                Qua = newValue;
            }
            else
            {
                Qua = newValue;
                progressBar.Value = progressBar.Maximum;
                // Xử lý trường hợp giá trị mới vượt quá giá trị tối đa
                // Hiển thị thông báo hoặc thực hiện các hành động khác tùy theo yêu cầu của ứng dụng
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = btnHuy.Enabled = dtDaily.Enabled = dtMenu.Enabled = trackBar1.Enabled = false;
            textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = false;
            labPercent.Text = TDEE.ToString();
            circularProgressBar1.Minimum = 0;
            circularProgressBar1.Maximum = TDEE;
            circularProgressBar1.Value = 0;
            circularProgressBar1.Update();
            // Tạo một DataTable để chứa dữ liệu
            DataTable Menu = new DataTable();
            labelchart.Text = "0 Calo";
            chart1.Series["Series1"].Points.AddXY("Carbs", 33.3);
            chart1.Series["Series1"].Points.AddXY("Fat", 33.3);
            chart1.Series["Series1"].Points.AddXY("Proteins", 100 - 66.6);

            // chọn hết bảng để thêm dữ liệu vào danh sách
            string query = string.Format("SELECT * FROM Menu");
            adt = new SqlDataAdapter(query, conn);
            adt.Fill(Menu);
            //xóa hết dữ liệu mỗi lần loadForm để không trùng lặp dữ liệu
            dsTd.Clear();
            // thêm các  giá trị từ sql vào danh sách
            foreach (DataRow row in Menu.Rows)
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
                dsTd.Add(td);
            }

            //chọn 3 cột để show lên
            query = string.Format("SELECT Ten, Loai, KhoiLuong FROM Menu");
            adt = new SqlDataAdapter(query, conn);
            DataTable Menu2 = new DataTable();
            adt.Fill(Menu2);
            dtMenu.DataSource = Menu2;
        }

        private void circularProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //cập nhật số trong textbox khi kéo trackbar
            textBox3.Text = trackBar1.Value.ToString();
            Weight = textBox3.Text;
            label9.Text = textBox3.Text + " Grams";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dtDaily.Enabled = btnEdit.Enabled = btnEra.Enabled = textBox1.Enabled = textBox2.Enabled = btnSearch.Enabled = true;
            textBox3.Enabled = trackBar1.Enabled = dtMenu.Enabled = btnHuy.Enabled = btnSave.Enabled = true;
            if (check == "Add")
            {
                double c = 0, p = 0, f = 0; // Gán giá trị mặc định cho biến c, p, f
                int kcal = 0;
                double W = Convert.ToDouble(Weight);
                string Chatdd = "";
                foreach (ThucDon monan in dsTd)
                {
                    if (monan.Name == cellValue)
                    {
                        c = monan.carb * (W / monan.Kl);
                        p = monan.pro * (W / monan.Kl);
                        f = monan.fat * (W / monan.Kl);
                        Chatdd = monan.nutrients;
                        kcal = Convert.ToInt32(monan.Calories * (W / monan.Kl));
                        Skcal += kcal;
                    }
                }

                // update thanh process bar tổng số calo cần nạp
                int Check = circularProgressBar1.Value + kcal;
                if (Check <= circularProgressBar1.Maximum)
                {
                    circularProgressBar1.Value = Check;
                }
                else circularProgressBar1.Value = circularProgressBar1.Maximum;
                circularProgressBar1.Update();

                //update thanh chỉ số carb, pro, fat
                XuLyTran(ref progressBar4, c, ref quaC);
                XuLyTran(ref progressBar3, f, ref quaF);
                XuLyTran(ref progressBar5, p, ref quaP);

                // update lại label chỉ số
                label10.Text = quaC.ToString() + "/" + progressBar4.Maximum.ToString() + " Grams";
                label8.Text = quaF.ToString() + "/" + progressBar3.Maximum.ToString() + " Grams";
                label11.Text = quaP.ToString() + "/" + progressBar5.Maximum.ToString() + " Grams";
                labPercent.Text = Skcal.ToString() + "/" + TDEE.ToString();
                string Nutrients = c.ToString("F1") + " gr carbs" + p.ToString("F1") + " gr pro" + f.ToString("F1") + " gr fat" + Chatdd;
                dtDaily.Rows.Add(cellValue, W, kcal, Nutrients);

                // xóa hết dữ liệu trên biểu đồ
                chart1.Series["Series1"].Points.Clear();
                // cập nhật chart khi chọn thực phẩm
                //chart1.Series["Series1"].Points.AddXY("Carbs", c);
                //chart1.Series["Series1"].Points.AddXY("Fat", f);
                //chart1.Series["Series1"].Points.AddXY("Proteins", p);

                DataPoint carbDataPoint = new DataPoint(0, c);
                DataPoint fatDataPoint = new DataPoint(1, f);
                DataPoint proteinDataPoint = new DataPoint(2, p);

                // Thêm các điểm dữ liệu vào chuỗi dữ liệu "Series1"
                chart1.Series["Series1"].Points.Add(carbDataPoint);
                chart1.Series["Series1"].Points.Add(fatDataPoint);
                chart1.Series["Series1"].Points.Add(proteinDataPoint);

                // Thiết lập nhãn cho các điểm dữ liệu
                //LegendText để thiết lập nội dung hiển thị trong phần chú thích của mỗi điểm dữ liệu.
                carbDataPoint.LegendText = Convert.ToDouble(c).ToString("F1") + " Carbs";
                fatDataPoint.LegendText = Convert.ToDouble(f).ToString("F1") + " Fat";
                proteinDataPoint.LegendText = Convert.ToDouble(p).ToString("F1") + " Proteins";

                //Lưu món ăn đã thêm vào DailyMenu trong data
                string InsertQuery = string.Format("Insert Into DailyMenu Values (N'{0}', '{1}', N'{2}', '{3}')",
                    cellValue, W, Nutrients, kcal);
                SqlCommand Insertcmd = new SqlCommand(InsertQuery, conn);
                Insertcmd.ExecuteNonQuery();

                //sau khi lưu xong . clear dữ liệu
                textBox3.Text = "";
            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            //btnAdd.Enabled = btnAdd0.Enabled =
            btnEra.Enabled = btnEdit.Enabled = true;
            dtDaily.Enabled = btnSave.Enabled = false;
            //trackBar1.Enabled = textBox3.Enabled = false;
            textBox1.Enabled = textBox2.Enabled = btnHuy.Enabled = dtMenu.Enabled = true;
            check = "search";
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            check = "Edit";
            btnAdd0.Enabled = btnEra.Enabled = textBox1.Enabled = textBox2.Enabled = false;
            btnSearch.Enabled = btnSave.Enabled = false;
            dtDaily.Enabled = btnSave.Enabled = btnHuy.Enabled = trackBar1.Enabled = textBox3.Enabled = true;
            textBox3.Text = dailycell;
        }

        private void dtDaily_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Bắt sự kiện click vào datagridview để sửa món ăn
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                DataGridViewCell selectedCell = dtDaily.Rows[e.RowIndex].Cells[1];
                dailycell = selectedCell.Value.ToString();
                //MessageBox.Show(cellValue);
            }
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = "";
            btnSave.Enabled = btnHuy.Enabled = dtDaily.Enabled = dtMenu.Enabled = trackBar1.Enabled = false;
            textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = false;
            btnAdd0.Enabled = btnEdit.Enabled = btnEra.Enabled = btnSearch.Enabled = true;
        
        }

        private void dtMenu_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //Bắt sự kiện click vào datagridview để chọn món ăn
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                DataGridViewCell selectedCell = dtMenu.Rows[e.RowIndex].Cells[0];
                cellValue = selectedCell.Value.ToString();
                //MessageBox.Show(cellValue);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //Textbox chứa khối lượng
            // cập nhật giá trị của trackbar khi thay đổi text
            Weight = textBox3.Text;
            //trackBar1.Value = Convert.ToInt32(Convert.ToDouble(Weight));
            //label9.Text = Weight + " Grams";
            if (string.IsNullOrEmpty(Weight))
            {
                trackBar1.Value = 0;
                label9.Text = "0 Grams";
                Weight = "0";
            }
            else
            {
                if (double.TryParse(Weight, out weightValue))
                {
                    // Nếu chuỗi có thể được chuyển đổi thành số, thì weightValue sẽ giữ giá trị đó
                    trackBar1.Value = Convert.ToInt32(weightValue);
                    label9.Text = weightValue.ToString() + " Grams";
                    Weight = weightValue.ToString();
                }
                else
                {
                    // Nếu chuỗi không phải là số, hiển thị thông báo và đặt giá trị mặc định cho trackBar và label
                    MessageBox.Show("Hãy nhập số!!");
                    trackBar1.Value = 0;
                    label9.Text = "0 Grams";
                    textBox3.Text = "0";
                }
            }
        }

        private void btnAdd0_Click(object sender, EventArgs e)
        {
            check = "Add";
            dtDaily.Enabled = btnEdit.Enabled = btnEra.Enabled = textBox1.Enabled = textBox2.Enabled = false;
            textBox3.Enabled = trackBar1.Enabled = dtMenu.Enabled = btnHuy.Enabled = btnSave.Enabled = true;

        }
    }
}

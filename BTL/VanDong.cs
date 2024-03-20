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

namespace Vận_động
{
    public partial class vanDong : Form
    {

        private DataTable dt;
        private SqlConnection conn;
        Form1 f = null;
        public vanDong()
        {
            InitializeComponent();
            //InitializeDataGridView();
            f = new Form1();
            conn = f.GetConnection();
        }

        double Calo = 0;
        int calories = 0;
        double trackBar_Num = 0;
        double tong = 0;
        string Tentt = "", status = "";
        int Tg, minute;
        private void UpdateResult()
        {
            // Lấy giá trị từ TrackBar
            int trackBarValue = trackBar_walk.Value;

            // Thực hiện phép tính
            tong = calories * trackBarValue;

            // Hiển thị kết quả trong TextBox
            textBox2.Text = tong.ToString();
        }

        private void walk_Click(object sender, EventArgs e)
        {

        }

        private void Tinh()
        {
            Calo = Convert.ToDouble(Tg / minute) * calories;
        }


        private void LoadData()
        {
            string query = "Select Ten as [Tên], SoGio as [Thời gian vận động(p)], SoCalo As [Số calo tiêu hao], Ngay as [Ngày] from DailyVD";
            DataTable dt = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter(query, conn);
            adt.Fill(dt);
            dtDaily.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // thay đổi định dạng cucar datetime picker
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            btnSave.Enabled =  btnCancel.Enabled = dtVD.Enabled = textTen.Enabled = false;
            trackBar_walk.Enabled = false;
            string query = "Select  Ten as [Tên môn thể thao], Sogio As [Thời gian(p)],  Socalo as [Số calo đốt/tg] From VanDong";
            SqlDataAdapter adt = new SqlDataAdapter(query,conn);
            dt = new DataTable();
            adt.Fill(dt);
            dtVD.DataSource = dt;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = "0";
                textBox1.SelectAll();
            }
            else
            {
                // Kiểm tra nếu giá trị không phải số
                if (!int.TryParse(textBox1.Text, out int number))
                {
                    MessageBox.Show("Vui lòng nhập một số.");
                    textBox1.Text = string.Empty; // Xóa nội dung TextBox
                    textBox1.Focus();
                }
                else
                {
                    Calo = Convert.ToDouble(textBox1.Text);
                    int calo;
                    if (int.TryParse(textBox1.Text, out calo))
                    {
                        // Giới hạn giá trị của namSinh trong khoảng của TrackBar
                        if (calo < trackBar_walk.Minimum)
                            calo = trackBar_walk.Minimum;
                        else if (calo > trackBar_walk.Maximum)
                            calo = trackBar_walk.Maximum;

                        // Cập nhật giá trị của TrackBar
                        trackBar_walk.Value = calo;
                        // trackBar_Num = Convert.ToDouble(trackBar_walk.Value);
                     
                        if (!string.IsNullOrEmpty(textBox1.Text) || !string.IsNullOrEmpty(textTen.Text))
                        {
                            btnSave.Enabled = true;
                        }
                    }
                }
            }
        }

        private void trackBar_walk_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = trackBar_walk.Value.ToString();
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textTen.Text))
            {
                trackBar_walk.Enabled = true;
            }    
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = btnCancel.Enabled = true;
            btnSearch.Enabled = btnEra.Enabled = btnEdit.Enabled = textTen.Enabled = false;
            dtVD.Enabled = true;
            status = "Add";
            trackBar_walk.Enabled = textBox1.Enabled = true;
        }

        private void dtDaily_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                DataGridViewCell selectedCell = dtDaily.Rows[e.RowIndex].Cells[1];
                DataGridViewCell selectedCell1 = dtDaily.Rows[e.RowIndex].Cells[2];
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dữ liệu hợp lệ");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            status = "Edit";
            dtVD.Enabled = btnAdd.Enabled = btnSearch.Enabled = textTen.Enabled = btnEra.Enabled = false;
            btnSave.Enabled = btnCancel.Enabled = btnEdit.Enabled = dtDaily.Enabled = trackBar_walk.Enabled = textBox1.Enabled = textBox2.Enabled = true;
       }

        private void dtVD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
             {
                DataGridViewCell selectedCell = dtVD.Rows[e.RowIndex].Cells[0];
                DataGridViewCell selectedCell1 = dtVD.Rows[e.RowIndex].Cells[1];
                DataGridViewCell selectedCell2 = dtVD.Rows[e.RowIndex].Cells[2];
                Tentt = selectedCell.Value.ToString();
                minute = Convert.ToInt32(selectedCell1.Value);
                calories = Convert.ToInt32(selectedCell1.Value);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dữ liệu hợp lệ");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            textTen.Enabled = dtDaily.Enabled = btnSave.Enabled = btnCancel.Enabled = false;
            if(status == "Add")
            {
                //đổi kiểu dữ liệu date time để add vào bảng
                DateTime ngayVd = dateTimePicker1.Value;
                string Ngay = ngayVd.ToString("yyyy-MM-dd");
                Tg = Convert.ToInt32(textBox1.Text);
                Tinh();
                string insertQuery = string.Format("Insert into Dailyvd values (N'{0}', '{1}' , '{2}', '{3}') ", Tentt, Tg, Convert.ToInt32(Calo),Ngay);
                SqlCommand Insertcmd = new SqlCommand(insertQuery,conn);
                Insertcmd.ExecuteNonQuery();
                LoadData();
            }
        }
    }
}

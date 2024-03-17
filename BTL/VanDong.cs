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

namespace Vận_động
{
    public partial class vanDong : Form
    {

        private DataTable dataTable;
        public vanDong()
        {
            InitializeComponent();
            //InitializeDataGridView();
        }

        double Calo = 0;
        double calories = 0;
        double trackBar_Num = 0;
        double tong = 0;

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

        private void AddDataToDataGridView(string data)
        {
            // Tạo một hàng mới cho DataGridView
            

        }
            
        private void button1_Click(object sender, EventArgs e)
        {
            string data = textBox3.Text;

            // Thêm dữ liệu vào DataGridView
            AddDataToDataGridView(data);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                textBox3.Text = selectedRow.Cells[1].Value.ToString();
                calories = Convert.ToDouble(selectedRow.Cells[2].Value);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            trackBar_walk.Enabled = false;

            //textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = false;
            //labPercent.Text = TDEE.ToString();
            //circularProgressBar1.Minimum = 0;
            //circularProgressBar1.Maximum = TDEE;
            //circularProgressBar1.Value = 0;
            //circularProgressBar1.Update();
            // Tạo một DataTable để chứa dữ liệu
            dataTable = new DataTable();
            dataTable.Columns.Add("Số thứ tự", typeof(double));
            dataTable.Columns.Add("Tên môn thể thao", typeof(string));
            dataTable.Columns.Add("Calo/Giờ", typeof(double));


            //Thêm dữ liệu vào datagridView
            dataTable.Rows.Add(1, "Đi bộ", 25);
            dataTable.Rows.Add(2, "Chạy bộ", 30);
            dataTable.Rows.Add(3, "Đạp xe", 28);
            dataTable.Rows.Add(4, "Bơi", 25);
            dataTable.Rows.Add(5, "Yoga", 30);
            dataTable.Rows.Add(6, "Plank", 28);

            dataGridView1.DataSource = dataTable;
            UpdateResult();
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
                     
                        if (!string.IsNullOrEmpty(textBox1.Text) || !string.IsNullOrEmpty(textBox3.Text))
                        {
                            button1.Enabled = true;
                        }
                    }
                }
            }
        }

        private void trackBar_walk_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = trackBar_walk.Value.ToString();
            UpdateResult();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox3.Text))
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

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}

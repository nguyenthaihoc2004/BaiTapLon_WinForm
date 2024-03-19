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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Test_1
{
    public partial class Calculation : Form
    {
        Form1 f = null;

        private SqlConnection conn;

        public Calculation()
        {
            InitializeComponent();
            f = new Form1();
            // Gán giá trị của biến conn cho connection
            conn = f.GetConnection();
        }

        int namSinh = 0;
        double Weight = 0;
        double Height = 0;
        string Gender = "";
        int CuongDo = 0;
        double BMI, BMR, TDEE;
        double hso = 0;

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox3.Text = trackBar1.Value.ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            textBox5.Text = trackBar3.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            textBox4.Text =  trackBar2.Value.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.Text = "0";
                textBox3.SelectAll();
            }
            else
            {
                // Kiểm tra nếu giá trị không phải số
                if (!int.TryParse(textBox3.Text, out int number))
                {
                    MessageBox.Show("Vui lòng nhập một số.");
                    textBox3.Text = string.Empty; // Xóa nội dung TextBox
                    textBox3.Focus();
                }
                else
                {
                    namSinh = Convert.ToInt32(textBox3.Text);
                    int ns;
                    if (int.TryParse(textBox3.Text, out ns))
                    {
                        // Giới hạn giá trị của namSinh trong khoảng của TrackBar
                        if (ns < trackBar1.Minimum)
                            ns = trackBar1.Minimum;
                        else if (ns > trackBar1.Maximum)
                            ns = trackBar1.Maximum;

                        // Cập nhật giá trị của TrackBar
                        trackBar1.Value = ns;

                        // Hiển thị giá trị trong Label hoặc TextBox khác nếu cần
                        // label1.Text = "Năm sinh: " + ns.ToString();
                    }

                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                textBox4.Text = "0";
                textBox4.SelectAll();
            }
            else
            {
                // Kiểm tra nếu giá trị không phải số
                if (!int.TryParse(textBox4.Text, out int number))
                {
                    MessageBox.Show("Vui lòng nhập một số.");
                    textBox4.Text = string.Empty; // Xóa nội dung TextBox
                    textBox4.Focus();
                }
                else
                {
                    Weight = Convert.ToDouble(textBox4.Text);
                    int can_nang;
                    if (int.TryParse(textBox4.Text, out can_nang))
                    {
                        // Giới hạn giá trị của namSinh trong khoảng của TrackBar
                        if (can_nang < trackBar2.Minimum)
                            can_nang = trackBar2.Minimum;
                        else if (can_nang > trackBar2.Maximum)
                            can_nang = trackBar2.Maximum;

                        // Cập nhật giá trị của TrackBar
                        trackBar2.Value = can_nang;
                    }
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                textBox5.Text = "0";
                textBox5.SelectAll();
            }
            else
            {
                // Kiểm tra nếu giá trị không phải số
                if (!int.TryParse(textBox5.Text, out int number))
                {
                    MessageBox.Show("Vui lòng nhập một số.");
                    textBox5.Text = string.Empty; // Xóa nội dung TextBox
                    textBox5.Focus();
                }
                else
                {
                    Height = Convert.ToDouble(textBox5.Text);
                    int chieu_cao;
                    if (int.TryParse(textBox5.Text, out chieu_cao))
                    {
                        // Giới hạn giá trị của namSinh trong khoảng của TrackBar
                        if (chieu_cao < trackBar3.Minimum)
                            chieu_cao = trackBar3.Minimum;
                        else if (chieu_cao > trackBar3.Maximum)
                            chieu_cao = trackBar3.Maximum;

                        // Cập nhật giá trị của TrackBar
                        trackBar3.Value = chieu_cao;
                    }
                }
            }

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void vbButton1_Click(object sender, EventArgs e)
        {
            // tính BMI

            if (namSinh == 0 || CuongDo == 0 || Height == 0 || Weight == 0 || Gender == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!!");
                return;
            }
            else
            {

                BMI = Weight / Math.Pow(Height / 100, 2);
                // Tính BMR
                if (Gender == "Nam")
                {
                    BMR = (10 * Weight) + (6.25 * Height) - (5 * (2024 - namSinh)) + 5;
                }
                else BMR = (10 * Weight) + (6.25 * Height) - (5 * (2024 - namSinh)) - 161;
                //Tính TDEE
                TDEE = BMR * hso;

                //xét BMI để phân loại
                if (BMI <= 18.5)
                {
                    label11.Text = "Chỉ số BMI của bạn là " + BMI.ToString("F2") + ", bạn thuộc loại cân nặng thấp";
                    //label8.Font = new Font(label1.Font, FontStyle.Bold);
                    //label9.Font = new Font(label1.Font, FontStyle.Bold);
                    label8.BackColor = Color.FromArgb(170, 167, 167);
                    label9.BackColor = Color.FromArgb(170, 167, 167);
                }
                else if (BMI > 18.5 && BMI <= 24.9)
                {
                    label11.Text = "Chỉ số BMI của bạn là " + BMI.ToString("F2") + ", bạn thuộc loại bình thường";
                    //label14.Font = new Font(label1.Font, FontStyle.Bold);
                    // label15.Font = new Font(label1.Font, FontStyle.Bold);
                    label14.BackColor = Color.FromArgb(170, 167, 167);
                    label15.BackColor = Color.FromArgb(170, 167, 167);
                }
                else if (BMI > 24.9 && BMI <= 29.9)
                {
                    label11.Text = "Chỉ số BMI của bạn là " + BMI.ToString("F2") + ", bạn thuộc loại tiền béo phì";
                    // label16.Font = new Font(label1.Font, FontStyle.Bold);
                    // label17.Font = new Font(label1.Font, FontStyle.Bold);
                    label16.BackColor = Color.FromArgb(170, 167, 167);
                    label17.BackColor = Color.FromArgb(170, 167, 167);
                }
                else if (BMI > 29.9 && BMI <= 34.9)
                {
                    label11.Text = "Chỉ số BMI của bạn là " + BMI.ToString("F2") + ", bạn thuộc loại béo phì độ I";
                    //label18.Font = new Font(label1.Font, FontStyle.Bold);
                    // label19.Font = new Font(label1.Font, FontStyle.Bold);
                    label18.BackColor = Color.FromArgb(170, 167, 167);
                    label19.BackColor = Color.FromArgb(170, 167, 167);
                }
                else if (BMI > 34.9 && BMI <= 39.9)
                {
                    label11.Text = "Chỉ số BMI của bạn là " + BMI.ToString("F2") + ", bạn thuộc loại béo phì độ II";
                    //label18.Font = new Font(label1.Font, FontStyle.Bold);
                    // label19.Font = new Font(label1.Font, FontStyle.Bold);
                    label37.BackColor = Color.FromArgb(170, 167, 167);
                    label38.BackColor = Color.FromArgb(170, 167, 167);
                }
                else if (BMI >= 40)
                {
                    label11.Text = "Chỉ số BMI của bạn là " + BMI.ToString("F2") + ", bạn thuộc loại béo phì độ III";
                    //label18.Font = new Font(label1.Font, FontStyle.Bold);
                    // label19.Font = new Font(label1.Font, FontStyle.Bold);
                    label39.BackColor = Color.FromArgb(170, 167, 167);
                    label40.BackColor = Color.FromArgb(170, 167, 167);
                }

                // in ra chỉ số BMR
                label21.Text = "Chỉ số BMR của bạn là " + BMR.ToString("F0") + " calo/ngày";

                // xét chỉ số TDEE để phân loại

                if (CuongDo == 1)
                {
                    label27.BackColor = Color.FromArgb(170, 167, 167);
                    label28.BackColor = Color.FromArgb(170, 167, 167);
                }
                if (CuongDo == 2)
                {
                    label29.BackColor = Color.FromArgb(170, 167, 167);
                    label30.BackColor = Color.FromArgb(170, 167, 167);
                }
                if (CuongDo == 3)
                {
                    label31.BackColor = Color.FromArgb(170, 167, 167);
                    label32.BackColor = Color.FromArgb(170, 167, 167);
                }
                if (CuongDo == 4)
                {
                    label33.BackColor = Color.FromArgb(170, 167, 167);
                    label34.BackColor = Color.FromArgb(170, 167, 167);
                }
                if (CuongDo == 5)
                {
                    label35.BackColor = Color.FromArgb(170, 167, 167);
                    label36.BackColor = Color.FromArgb(170, 167, 167);
                }
                label24.Text = "Chỉ số TDEE của bạn là  " + TDEE.ToString("F0") + " calo/ngày";

                // Khai báo giá trị cho f để Mở hàm constructor trong form1(nếu dùng cách k có hàm Getconn)
                //f = new Form1();
                string BMI0 = BMI.ToString("F2");
                BMI = Convert.ToDouble(BMI0);
                //string query = string.Format("Insert Into UserInfor Values (N'{0}' , '{1}', '{2}', '{3}', '{4}','{5}', '{6}','{7}) ",
                //    Gender, Convert.ToDouble(Weight), Convert.ToDouble(Height), BMI, Convert.ToInt32(BMR), Convert.ToInt32(TDEE),
                //    namSinh, CuongDo);
                string query = string.Format("Insert Into UserInfor Values (N'{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')",
                Gender, Convert.ToDouble(Weight), Convert.ToDouble(Height), BMI, Convert.ToInt32(BMR), Convert.ToInt32(TDEE),
                namSinh, CuongDo);
                SqlCommand cmdInsert = new SqlCommand(query, conn);
                cmdInsert.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }


        private void label27_Click(object sender, EventArgs e)
        {

        }


        private void label36_Click(object sender, EventArgs e)
        {

        }
        private void Calculation_Load(object sender, EventArgs e)
        {
   
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Gender  = comboBox1.SelectedItem.ToString();// lấy item là lấy giá trị của item còn selectedindex là lấy chỉ số của giá trị đó ở list
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            CuongDo = comboBox3.SelectedIndex + 1;
            if (CuongDo == 1) hso = 1.2;
            if (CuongDo == 2) hso = 1.375;
            if (CuongDo == 3) hso = 1.55;
            if (CuongDo == 4) hso = 1.725;
            if (CuongDo == 5) hso = 1.9;
        }

    }
}

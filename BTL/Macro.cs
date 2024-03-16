using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Test_1
{
    public partial class Macro : Form
    {
        private void ControlEnable(bool check)
        {
            trackBar1.Enabled = check;
            trackBar2.Enabled = check;
            trackBar3.Enabled = check;
            btTruC.Enabled = check;
            btTruP.Enabled = check;
            btTruF.Enabled = check;
            btCongC.Enabled = check;
            btCongP.Enabled = check;
            btCongF.Enabled = check;

        }

        List<CheDoAn> ds = new List<CheDoAn>();

        private int value1, value2, value3, TDEE;
        public Macro()
        {
            InitializeComponent();
            //ds = new List<CheDoAn>()
            //{
            //    new CheDoAn(){Ten = "LowCarbs", Carbs = 5, Protein = 60, Fat = 35},
            //    new CheDoAn(){ Ten = "HighCarbs", Carbs = 20, Protein = 40, Fat = 40},
            //};
            //cbbTuychon.DataSource = ds;
            //cbbTuychon.DisplayMember = "Ten";
            //addBinding();
        }

        void addBinding()
        {
            tbC.DataBindings.Add(new Binding("Text", cbbTuychon.DataSource, "Carbs"));
            tbP.DataBindings.Add(new Binding("Text", cbbTuychon.DataSource, "Protein"));
            tbF.DataBindings.Add(new Binding("Text", cbbTuychon.DataSource, "Fat"));
            trackBar1.DataBindings.Add(new Binding("Value", cbbTuychon.DataSource, "Carbs"));
            trackBar2.DataBindings.Add(new Binding("Value", cbbTuychon.DataSource, "Protein"));
            trackBar3.DataBindings.Add(new Binding("Value", cbbTuychon.DataSource, "Fat"));
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            value1 = trackBar1.Value;
            value2 = trackBar2.Value;
            value3 = trackBar3.Value;
            cbbTuychon.Items.Add("Tùy chọn 1");
            cbbTuychon.Items.Add("Tùy chọn 2");
            cbbTuychon.Items.Add("Tùy chọn 3");


            cbbTuychon.SelectedIndexChanged += cbbTuychon_SelectedIndexChanged;



            // Thêm series vào khu vực biểu đồ dạng Doughnut
            Series doughnutSeries = new Series("DoughnutSeries");
            doughnutSeries.ChartType = SeriesChartType.Doughnut;
            chart1.Series.Add(doughnutSeries);

            // Thêm các điểm dữ liệu vào series
            doughnutSeries.Points.Add(value1);
            doughnutSeries.Points.Add(value2);
            doughnutSeries.Points.Add(value3);

            doughnutSeries.Points[0].AxisLabel = "Carbs";
            doughnutSeries.Points[1].AxisLabel = "Protein";
            doughnutSeries.Points[2].AxisLabel = "Fat";

            chart1.Invalidate();


            cbbTuychon.SelectedIndex = 0;
            lbTongpt.Text = (value1 + value2 + value3).ToString() + "%";
            ControlEnable(false);
            tbC.Enabled = false;
            tbP.Enabled = false;
            tbF.Enabled = false;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            value1 = trackBar1.Value;
            lbtrack1.Text = (value1) + "%";
            lbTongpt.Text = (value1 + value2 + value3).ToString() + "%";
            chart1.Series["DoughnutSeries"].Points[0].SetValueY(value1);
            chart1.Invalidate();
            lbgC.Text = Math.Round((TDEE * (value1 / 100.0) / 4), 1).ToString() + " Grams";
            tbC.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            value2 = trackBar2.Value;
            lbtrack2.Text = (value2) + "%";
            lbTongpt.Text = (value1 + value2 + value3).ToString() + "%";
            chart1.Series["DoughnutSeries"].Points[1].SetValueY(value2);
            chart1.Invalidate();
            lbgP.Text = Math.Round((TDEE * (value2 / 100.0) / 4), 1).ToString() + " Grams";
            tbP.Text = trackBar2.Value.ToString();
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            value3 = trackBar3.Value;
            lbtrack3.Text = (value3) + "%";
            lbTongpt.Text = (value1 + value2 + value3).ToString() + "%";
            chart1.Series["DoughnutSeries"].Points[2].SetValueY(value3);
            chart1.Invalidate();
            lbgF.Text = Math.Round((TDEE * (value3 / 100.0) / 9), 1).ToString() + " Grams";
            tbF.Text = trackBar3.Value.ToString();
        }

        private void ttTrucl_Click(object sender, EventArgs e)
        {
            trbCalo.Value -= 1;
        }

        private void trbCalo_ValueChanged(object sender, EventArgs e)
        {
            tbCalo.Text = trbCalo.Value.ToString();
        }

        private void btCongcl_Click(object sender, EventArgs e)
        {
            trbCalo.Value += 1;
        }

        private void tbCalo_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text;

            // Kiểm tra nếu giá trị là null hoặc rỗng
            if (string.IsNullOrEmpty(input))
            {
                tbCalo.Text = "0";
                tbCalo.SelectAll();
            }
            else
            {
                // Kiểm tra nếu giá trị không phải số
                if (!int.TryParse(input, out int number))
                {
                    MessageBox.Show("Vui lòng nhập một số nguyên vào TextBox.");
                    textBox.Text = string.Empty; // Xóa nội dung TextBox
                    tbCalo.Focus();
                }
                else
                {
                    TDEE = number;
                    lbgC.Text = Math.Round((TDEE * (value1 / 100.0) / 4), 1).ToString() + " Grams";
                    lbgP.Text = Math.Round((TDEE * (value2 / 100.0) / 4), 1).ToString() + " Grams";
                    lbgF.Text = Math.Round((TDEE * (value3 / 100.0) / 9), 1).ToString() + " Grams";
                }

                if (int.TryParse(tbCalo.Text, out int newValue))
                {
                    if (newValue >= trbCalo.Minimum && newValue <= trbCalo.Maximum)
                    {
                        trbCalo.Value = newValue;
                    }
                }
            }
        }

        private void btCustom_Click(object sender, EventArgs e)
        {
            lbTongpt.Text = (value1 + value2 + value3).ToString() + "%";
            ControlEnable(true);
            tbC.Enabled = true; 
            tbP.Enabled = true;
            tbF.Enabled = true;
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if ((value1 + value2 + value3) != 100)
            {
                MessageBox.Show("Tổng phần trăm không bằng 100%");
            }
        }

        private void btTruC_Click(object sender, EventArgs e)
        {
            trackBar1.Value -= 1;
        }

        private void btTruP_Click(object sender, EventArgs e)
        {
            trackBar2.Value -= 1;
        }

        private void btTruF_Click(object sender, EventArgs e)
        {
            trackBar3.Value -= 1;
        }

        private void btCongC_Click(object sender, EventArgs e)
        {
            trackBar1.Value += 1;
        }

        private void btCongP_Click(object sender, EventArgs e)
        {
            trackBar2.Value += 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbC.Enabled = true;
            tbP.Enabled = true;
            tbF.Enabled = true;
            ControlEnable(true);
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            ds = new List<CheDoAn>()
            {
                new CheDoAn(){Ten = textBox5.Text, Carbs = Convert.ToInt16(tbC.Text), Protein = Convert.ToInt16(tbP.Text), Fat = Convert.ToInt16(tbF.Text)}
            };
            cbbTuychon.DataSource = ds;
            cbbTuychon.DisplayMember = "Ten";
        }

        private void tbC_TextChanged(object sender, EventArgs e)
        {
            trackBar1.Value = Convert.ToInt32(tbC.Text);
        }

        private void tbP_TextChanged(object sender, EventArgs e)
        {
            trackBar2.Value = Convert.ToInt32(tbP.Text);
        }

        private void tbF_TextChanged(object sender, EventArgs e)
        {
            trackBar3.Value = Convert.ToInt32(tbF.Text);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {
            Form currentForm1 = this;
            Panel parentPanel1 = (Panel)currentForm1.Parent;

            // Tạo một thể hiện của Form2
            MacroButton macroButton = new MacroButton();

            // Thiết lập Parent của Form2 là panel
            macroButton.TopLevel = false;
            macroButton.Parent = parentPanel1;
            macroButton.FormBorderStyle = FormBorderStyle.None; // đóng dấu x và mở rộng của form con
            macroButton.Dock = DockStyle.Fill;

            // Đặt kích thước và vị trí của Form2 để nó đè chính xác lên form hiện tại
            macroButton.Size = currentForm1.Size;
            macroButton.Location = currentForm1.Location;
            currentForm1.Hide();
            // Hiển thị Form2 và ẩn form hiện tại
            macroButton.Show();
        }

        private void btCongF_Click(object sender, EventArgs e)
        {
            trackBar3.Value += 1;
        }

        private void tbCalo_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(tbCalo.Text, out int newValue))
            {
                if (newValue >= trbCalo.Minimum && newValue <= trbCalo.Maximum)
                {
                    trbCalo.Value = newValue;
                }
            }
        }
        private void cbbTuychon_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOption = cbbTuychon.SelectedItem as string;
            if (selectedOption == "Tùy chọn 1")
            {
                // Thiết lập giá trị cho các TrackBar khi chọn "Tùy chọn 1"
                trackBar1.Value = 40;
                trackBar2.Value = 30;
                trackBar3.Value = 30;
            }
            else if (selectedOption == "Tùy chọn 2")
            {
                // Thiết lập giá trị cho các TrackBar khi chọn "Tùy chọn 2"
                trackBar1.Value = 20;
                trackBar2.Value = 40;
                trackBar3.Value = 40;
            }
            else if (selectedOption == "Tùy chọn 3")
            {
                // Thiết lập giá trị cho các TrackBar khi chọn "Tùy chọn 3"
                trackBar1.Value = 50;
                trackBar2.Value = 25;
                trackBar3.Value = 25;
            }
        }
    }
}

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
            List<CheDoAn> ds = new List<CheDoAn>();
            cbbTuychon.DisplayMember = "Ten";
            cbbTuychon.ValueMember = "Ten"; // Chỉ định Ten làm giá trị cho mục được chọn

            cbbTuychon.DataSource = ds;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            value1 = trackBar1.Value;
            value2 = trackBar2.Value;
            value3 = trackBar3.Value;

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

            //cbbTuychon.SelectedIndex = 0;
            lbTongpt.Text = (value1 + value2 + value3).ToString() + "%";
            lbTongpt.Text = (value1 + value2 + value3).ToString() + "%";
            ControlEnable(false);
            tbC.Enabled = false;
            tbP.Enabled = false;
            tbF.Enabled = false;
            tbTenCDA.Enabled = false;

            ds.Add(new CheDoAn("Low Carbs", 20, 40, 40));
            ds.Add(new CheDoAn("High Carbs", 40, 30, 30));
            cbbTuychon.DataSource = ds;
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
            else
            {
                CheDoAn newOption = new CheDoAn("", 0, 0, 0)
                {
                    Ten = tbTenCDA.Text.ToString(),
                    Carbs = value1,
                    Protein = value2,
                    Fat = value3,
                };

                ds.Add(newOption);
                // Refresh the combo box data source
                cbbTuychon.DataSource = null; // Clear the current data source
                cbbTuychon.DataSource = ds;
                cbbTuychon.DisplayMember = "Ten";
                // Select the newly added item in the combo box
                cbbTuychon.SelectedIndex = ds.Count - 1;
                tbTenCDA.Text = default;
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

        private void btCongF_Click(object sender, EventArgs e)
        {
            trackBar3.Value += 1;
        }

        private void ResetOptions()
        {
            // Thiết lập giá trị mặc định cho TrackBar
            trackBar1.Value = default;
            trackBar2.Value = default;
            trackBar3.Value = default;

            // Thiết lập giá trị mặc định cho TextBox
            tbC.Text = default;
            tbP.Text = default;
            tbF.Text = default;

            // Thiết lập giá trị mặc định cho ComboBox
            cbbTuychon.Text = " ";
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            tbTenCDA.Enabled = true;
            tbC.Enabled = true;
            tbP.Enabled = true;
            tbF.Enabled = true;
            ControlEnable(true);
            ResetOptions();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            btLuuTC.Visible = true;
            ControlEnable(true);
            tbTenCDA.Enabled = true;
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (cbbTuychon.SelectedIndex >= 0)
            {
                // Lấy tùy chọn được chọn
                CheDoAn selectedOption = (CheDoAn)cbbTuychon.SelectedItem;

                // Kiểm tra xem tùy chọn đang được chọn có bị xóa không
                bool isSelectedOptionRemoved = false;
                if (selectedOption == cbbTuychon.SelectedItem)
                    isSelectedOptionRemoved = true;

                // Xóa tùy chọn khỏi danh sách nguồn dữ liệu
                ds.Remove(selectedOption);

                // Cập nhật lại combobox
                cbbTuychon.DataSource = null;
                cbbTuychon.DataSource = ds;
                cbbTuychon.DisplayMember = "Ten";

                // Thiết lập lại selectedIndex nếu cần
                if (isSelectedOptionRemoved && cbbTuychon.Items.Count > 0)
                    cbbTuychon.SelectedIndex = 0;
            }
        }

        private void tbC_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text;

            // Kiểm tra nếu giá trị là null hoặc rỗng
            if (string.IsNullOrEmpty(input))
            {
                tbC.Text = "0";
                tbC.SelectAll();
            }
            else
            {
                // Kiểm tra nếu giá trị không phải số
                if (!int.TryParse(input, out int number))
                {
                    MessageBox.Show("Vui lòng nhập một số nguyên vào TextBox.");
                    textBox.Text = string.Empty; // Xóa nội dung TextBox
                    tbC.Focus();
                }
                else
                {
                    if (number < trackBar1.Minimum)
                    {
                        number = trackBar1.Minimum;
                        tbC.Text = number.ToString();
                    }
                    else if (number > trackBar1.Maximum)
                    {
                        number = trackBar1.Maximum;
                        tbC.Text = number.ToString();
                    }

                    trackBar1.Value = number;
                }
            }
        }

        private void tbP_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text;

            // Kiểm tra nếu giá trị là null hoặc rỗng
            if (string.IsNullOrEmpty(input))
            {
                tbP.Text = "0";
                tbP.SelectAll();
            }
            else
            {
                // Kiểm tra nếu giá trị không phải số
                if (!int.TryParse(input, out int number))
                {
                    MessageBox.Show("Vui lòng nhập một số nguyên vào TextBox.");
                    textBox.Text = string.Empty; // Xóa nội dung TextBox
                    tbP.Focus();
                }
                else
                {
                    if (number < trackBar2.Minimum)
                    {
                        number = trackBar2.Minimum;
                        tbP.Text = number.ToString();
                    }
                    else if (number > trackBar2.Maximum)
                    {
                        number = trackBar1.Maximum;
                        tbP.Text = number.ToString();
                    }

                    trackBar2.Value = number;
                }
            }
        }

        private void tbF_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text;

            // Kiểm tra nếu giá trị là null hoặc rỗng
            if (string.IsNullOrEmpty(input))
            {
                tbF.Text = "0";
                tbF.SelectAll();
            }
            else
            {
                // Kiểm tra nếu giá trị không phải số
                if (!int.TryParse(input, out int number))
                {
                    MessageBox.Show("Vui lòng nhập một số nguyên vào TextBox.");
                    textBox.Text = string.Empty; // Xóa nội dung TextBox
                    tbF.Focus();
                }
                else
                {
                    if (number < trackBar3.Minimum)
                    {
                        number = trackBar3.Minimum;
                        tbF.Text = number.ToString();
                    }
                    else if (number > trackBar3.Maximum)
                    {
                        number = trackBar3.Maximum;
                        tbF.Text = number.ToString();
                    }

                    trackBar3.Value = number;
                }
            }
        }

        private void btLuuTC_Click(object sender, EventArgs e)
        {
            if ((value1 + value2 + value3) != 100)
            {
                MessageBox.Show("Tổng phần trăm không bằng 100%");
            }
            else
            {
                CheDoAn selectedOption = (CheDoAn)cbbTuychon.SelectedItem;

                // Cập nhật giá trị chỉ số của tùy chọn từ các trường nhập liệu
                selectedOption.Carbs = int.Parse(tbC.Text);
                selectedOption.Protein = int.Parse(tbP.Text);
                selectedOption.Fat = int.Parse(tbF.Text);

                // Refresh combo box data source để hiển thị các thay đổi
                cbbTuychon.DataSource = null;
                cbbTuychon.DataSource = ds;
                cbbTuychon.DisplayMember = "Ten";
                btLuuTC.Visible = false;
            }
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
            if (cbbTuychon.SelectedIndex >= 0)
            {
                CheDoAn selectedOptionItem = (CheDoAn)cbbTuychon.SelectedItem;
                trackBar1.Value = selectedOptionItem.Carbs;
                trackBar2.Value = selectedOptionItem.Protein;
                trackBar3.Value = selectedOptionItem.Fat;
            }
        }
    }
}

using Macro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_1
{
    public partial class MacroButton : Form
    {
        public MacroButton()
        {
            InitializeComponent();
        }

        private void vbButton1_Click(object sender, EventArgs e)
        {
            
            // Xác định form hiện tại và panel chứa nó
            Form currentForm1 = this;
            Panel parentPanel1 = (Panel)currentForm1.Parent;

            // Tạo một thể hiện của Form2
            Macro macro = new Macro();

            // Thiết lập Parent của Form2 là panel
            macro.TopLevel = false;
            macro.Parent = parentPanel1;
            macro.FormBorderStyle = FormBorderStyle.None; // đóng dấu x và mở rộng của form con
            macro.Dock = DockStyle.Fill;

            // Đặt kích thước và vị trí của Form2 để nó đè chính xác lên form hiện tại
            macro.Size = currentForm1.Size;
            macro.Location = currentForm1.Location;
            currentForm1.Hide();
            // Hiển thị Form2 và ẩn form hiện tại
            macro.Show();
            
        }

        private void MacroButton_Load(object sender, EventArgs e)
        {

        }

        private void vbButton2_Click(object sender, EventArgs e)
        {
            
        }
    }
}

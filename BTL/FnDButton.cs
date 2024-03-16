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
    public partial class FnDButton : Form
    {
        public FnDButton()
        {
            InitializeComponent();
        }
        private Form currentFormchild;

        private void nhatKy_Click(object sender, EventArgs e)
        {
            
            // Xác định form hiện tại và panel chứa nó
            Form currentForm = this;
            Panel parentPanel = (Panel)currentForm.Parent;

            // Tạo một thể hiện của Form2
            FoodnDrink foodnDrink = new FoodnDrink();

            // Thiết lập Parent của FnDbutton là panel
            foodnDrink.TopLevel = false;
            foodnDrink.Parent = parentPanel;
            foodnDrink.FormBorderStyle = FormBorderStyle.None; // đóng dấu x và mở rộng của form con
            foodnDrink.Dock = DockStyle.Fill;

            // Đặt kích thước và vị trí của Form2 để nó đè chính xác lên form hiện tại
            foodnDrink.Size = currentForm.Size;
            foodnDrink.Location = currentForm.Location;
            currentForm.Hide();
            // Hiển thị Form2 và ẩn form hiện tại
            foodnDrink.Show();
            
        }

        private void FnDButton_Load(object sender, EventArgs e)
        {

        }
    }
}

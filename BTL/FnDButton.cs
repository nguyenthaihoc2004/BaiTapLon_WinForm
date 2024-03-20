using Macro;
using Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Test_1
{
    public partial class FnDButton : Form
    {
        Form1 f = null;
        public FnDButton()
        {
            InitializeComponent();
            //f = new Form1();

        }
        private Form currentFormchild;


        private void OpenchildForm(Form ChildForm)
        {
            if (currentFormchild != null)
            {
                currentFormchild.Hide();
            }
            currentFormchild = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None; // đóng dấu x và mở rộng của form con
            ChildForm.Dock = DockStyle.Fill;
            panelBody1.Controls.Add(ChildForm);
            panelBody1.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
        }

        FoodnDrink foodnDrink = new FoodnDrink();
        private void nhatKy_Click(object sender, EventArgs e)
        {

            if(foodnDrink == null)
            {
                OpenchildForm(new FoodnDrink());
            }
            else OpenchildForm(foodnDrink);
            //// Xác định form hiện tại và panel chứa nó
            //Form currentForm = this;
            //Panel parentPanel = (Panel)currentForm.Parent;

            //// Tạo một thể hiện của Form2
            //FoodnDrink foodnDrink = new FoodnDrink();

            //// Thiết lập Parent của FnDbutton là panel
            //foodnDrink.TopLevel = false;
            //foodnDrink.Parent = parentPanel;
            //foodnDrink.FormBorderStyle = FormBorderStyle.None; // đóng dấu x và mở rộng của form con
            //foodnDrink.Dock = DockStyle.Fill;

            //// Đặt kích thước và vị trí của Form2 để nó đè chính xác lên form hiện tại
            //foodnDrink.Size = currentForm.Size;
            //foodnDrink.Location = currentForm.Location;
            //currentForm.Hide();
            //// Hiển thị Form2 và ẩn form hiện tại
            //foodnDrink.Show();

        }

        private void FnDButton_Load(object sender, EventArgs e)
        {
            //f = new Form1();
        }

        private void ThucDon_Click(object sender, EventArgs e)
        {
            Form currentForm = this;
            Panel parentPanel = (Panel)currentForm.Parent;

            // Tạo một thể hiện của Form2
            MoreMenu moremenu = new MoreMenu();

            // Thiết lập Parent của FnDbutton là panel
            moremenu.TopLevel = false;
            moremenu.Parent = parentPanel;
            moremenu.FormBorderStyle = FormBorderStyle.None; // đóng dấu x và mở rộng của form con
            moremenu.Dock = DockStyle.Fill;

            //// Đặt kích thước và vị trí của Form2 để nó đè chính xác lên form hiện tại
            moremenu.Size = currentForm.Size;
            moremenu.Location = currentForm.Location;
            currentForm.Hide();
            // Hiển thị Form2 và ẩn form hiện tại
            moremenu.Show();
        }

        private void panelBody1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

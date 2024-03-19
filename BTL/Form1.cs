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
using Vận_động;
using System.Data.SqlClient;
using Menu;

namespace Test_1
{
    public partial class Form1 : Form
    {
        //      public MoreMenu moremenu = new MoreMenu();
        //f1

        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
            conn.Open();
            this.Setting();
            //MoreMenu moremenu = new MoreMenu();
            //Panel parentPanel = (Panel)moremenu.Parent;
            //moremenu.TopLevel = false;
            //moremenu.Parent = parentPanel;
            //moremenu.FormBorderStyle = FormBorderStyle.None; // đóng dấu x và mở rộng của form con
            //moremenu.Dock = DockStyle.Fill;
            //moremenu.Size = moremenu.Size;
            //moremenu.Location = moremenu.Location;
            //moremenu.Hide();
        }
        public void Setting()
        {
            //moremenu.TopLevel = false;
            //Panel parentPanel = (Panel)moremenu.Parent;
            //moremenu.Parent = parentPanel;
            //moremenu.FormBorderStyle = FormBorderStyle.None; // đóng dấu x và mở rộng của form con
            //moremenu.Dock = DockStyle.Fill;
            //moremenu.Size = moremenu.Size;
            //moremenu.Location = moremenu.Location;
            //moremenu.Hide();
        }

        string connectionString = "Data Source=LAPTOP-HR6I9NPG;Initial Catalog=QLDinhduong;Integrated Security=True;Encrypt=False";
        //public SqlConnection conn = null;
        private SqlConnection conn = null;

        // hàm lấy connection cho form khác
        public SqlConnection GetConnection()
        {
            return conn;
        }

        private Form currentFormchild;

        private void OpenchildForm(Form ChildForm)
        {
            if(currentFormchild != null)
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

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Caculate_Click(object sender, EventArgs e)
        {

            OpenchildForm(new Calculation());
            
        }

        private void MacroSplit_Click(object sender, EventArgs e)
        {
            panelBody1.Controls.Clear();
            OpenchildForm(new MacroButton());
            
        }

        private void panelBody1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconPictureBoxHome_Click(object sender, EventArgs e)
        {
            panelBody1.Controls.Clear();
        }

        private void AddFood_Click(object sender, EventArgs e)
        {
            panelBody1.Controls.Clear();
            OpenchildForm(new FnDButton());
            
        }

        private void Chart_Click(object sender, EventArgs e)
        {
            panelBody1.Controls.Clear();
        }

        private void labelHome_Click(object sender, EventArgs e)
        {
            panelBody1.Controls.Clear();
        }

        private void imageLogo_Click(object sender, EventArgs e)
        {
            panelBody1.Controls.Clear();
        }

        private void WorkOut_Click(object sender, EventArgs e)
        {
            panelBody1.Controls.Clear();
            OpenchildForm(new vanDong());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

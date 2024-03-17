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

namespace Test_1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private Form currentFormchild;

        private void OpenchildForm(Form ChildForm)
        {
            if(currentFormchild != null)
            {
                currentFormchild.Close();
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
    }
}

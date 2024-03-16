using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_1
{
    public partial class ThucDon : Component
    {
        private string ten, type;
        private double kl, Carb, Pro, Fat;
        private int calories;

        public string Name { get => ten; set => ten = value; }
        public string Loai { get => type; set => type = value; }
        public double Kl { get => kl; set => kl = value; }
        public double carb { get => Carb; set => Carb = value; }
        public double pro { get => Pro; set => Pro = value; }
        public double fat { get => Fat; set => Fat = value; }
        public int Calories { get => calories; set => calories = value; }

        public ThucDon()
        {
            InitializeComponent();
        }

        public ThucDon(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_1
{
    public class ThucDon
    {
        private string ten, type;
        private double kl, Carb, Pro, Fat;
        private int calories;
        public string Nutrients;
        public string Loai { get => type; set => type = value; }

        public string Name { get => ten; set => ten = value; }
        public double Kl { get => kl; set => kl = value; }
        public double carb { get => Carb; set => Carb = value; }
        public double pro { get => Pro; set => Pro = value; }
        public double fat { get => Fat; set => Fat = value; }

        public string nutrients { get => Nutrients; set => Nutrients = value; }
        public int Calories { get => calories; set => calories = value; }
        public ThucDon() { }
    }
}

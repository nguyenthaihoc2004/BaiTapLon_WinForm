using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_1
{
    public class CheDoAn
    {
        private string ten;
        private int carbs;
        private int protein;
        private int fat;

        //public string Ten { get; set; }
        //public int Carbs { get; set; }
        //public int Protein { get; set; }
        //public int Fat { get; set; }

        //Hàm getter, setter
        public string Ten { get => ten; set => ten = value; }
        public int Carbs { get => carbs; set => carbs = value; }
        public int Protein { get => protein; set => protein = value; }
        public int Fat { get => fat; set => fat = value; }

        //hàm khởi tạo
        public CheDoAn(string Ten, int Carbs, int Protein, int Fat)
        {
            ten = Ten;
            carbs = Carbs;
            protein = Protein;
            fat = Fat;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrototipeSIL.Models
{
    public class RekomendasiSuplai
    {
        public int KodeBarang { get; set; }
        public String NamaBarang { get; set; }
        public int JumlahPasok { get; set; }
        public String NamaSupplier { get; set; }
    }

    public class RekomendasiSuplaiModel
    {
        public List<RekomendasiSuplai> item { get; set; }
        public int anggaranInput { get; set; }
        public int anggaranHasil { get; set; }
    }
}
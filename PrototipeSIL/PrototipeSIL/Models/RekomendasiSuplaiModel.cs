using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrototipeSIL.Models
{
    public class RekomendasiSuplaiModel
    {
        public int KodeBarang { get; set; }
        public String NamaBarang { get; set; }
        public int JumlahPasok { get; set; }
        public String NamaSupplier { get; set; }
    }
}
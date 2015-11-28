using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrototipeSIL.Models
{
    public class EconomicOrderQuantity
    {
        public static int calculateEOQ(int D, int biayaPengiriman, int holdingCost)
        {
            return (int) Math.Sqrt((2 * D * biayaPengiriman) / holdingCost);
        }
    }
}
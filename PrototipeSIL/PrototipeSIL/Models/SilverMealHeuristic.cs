using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrototipeSIL.Models
{
    public class SilverMealHeuristic
    {
        public static int calculateSMH(int initialCost, int holdingCost, int[] kebutuhan){
            int jumlah = 0;
            int cost = initialCost;
            int calcCost = initialCost;
            int count = 1;

            int indeks = 0;
            bool yes = false;

            while (indeks<kebutuhan.Length&&!yes){
                calcCost += holdingCost * kebutuhan[indeks];
                count++;
                if (calcCost / count > cost)
                {
                    yes = true;
                    cost = calcCost;
                }
                indeks++;
            }

            count = 0;
            for (int i = 0; i < indeks; i++)
            {
                jumlah += kebutuhan[i];
                if (kebutuhan[i] != 0)
                {
                    count++;
                }
            }

            if (count != 0)
            {
                return jumlah / count;
            }
            else
            {
                return jumlah;
            }
        }
    }
}
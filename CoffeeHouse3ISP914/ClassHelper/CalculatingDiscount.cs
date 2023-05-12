using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeHouse3ISP914.ClassHelper
{
    public class CalculatingDiscount
    {
        public static decimal Discount(decimal price, decimal discount)
        {
            return Math.Round(price - (price * discount),2);
        }
    }
}

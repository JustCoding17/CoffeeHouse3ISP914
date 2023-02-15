using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeHouse3ISP914.DB;

namespace CoffeeHouse3ISP914.ClassHelper
{
    public class EFClass
    {
        public static Entities Context { get; } = new Entities();



    }
}

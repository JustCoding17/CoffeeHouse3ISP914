//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoffeeHouse3ISP914.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class VW_InfoSale
    {
        public int IdSale { get; set; }
        public int IdClient { get; set; }
        public int IdEmployee { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public int IdProduct { get; set; }
        public int Count { get; set; }
        public Nullable<decimal> FinalPrice { get; set; }
    }
}

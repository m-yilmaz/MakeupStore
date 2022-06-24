using System;

namespace Web.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public DateTimeOffset OrderDate { get; set; }

        public decimal TotalPrice { get; set; }

        public string TotalPriceTry => TotalPrice.ToString("C2");


    }
}

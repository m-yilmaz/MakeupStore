using System.Collections.Generic;
using System.Linq;

namespace Web.Models
{
    public class BasketViewModel
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public List<BasketItemViewModel> Items { get; set; }
        public decimal TotalPrice => Items.Sum(x => x.TotalPrice);
        public string TotalPriceTry => TotalPrice.ToString("c2");
        public int TotalItems => Items.Sum(x => x.Quantity);
    }
}

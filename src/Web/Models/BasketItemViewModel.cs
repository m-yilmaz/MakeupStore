namespace Web.Models
{
    public class BasketItemViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string UnitPriceTry => UnitPrice.ToString("c2");
        public int Quantity { get; set; }
        public string PictureUri { get; set; }
        public decimal TotalPrice => UnitPrice * Quantity;
        public string TotalPriceTry => TotalPrice.ToString("c2");

    }
}

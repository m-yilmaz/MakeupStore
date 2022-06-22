using ApplicationCore.Entities;
using System.Linq;
using Web.Models;

namespace Web.Extensions
{
    public static class ViewModelExtensions
    {
        public static BasketViewModel ToBasketViewModel(this Basket basket)
        {
            return new BasketViewModel()
            {
                Id = basket.Id,
                BuyerId = basket.BuyerId,
                Items = basket.Items.Select(x => new BasketItemViewModel()
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    ProductName = x.Product.Name,
                    UnitPrice = x.Product.Price,
                    Quantity = x.Quantity,
                    PictureUri = x.Product.PictureUri
                }).ToList()
            };
        }
    }
}

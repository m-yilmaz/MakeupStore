using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IBasketService
    {
        Task<Basket> GetBasketAsync(string buyerId);
        Task<Basket> AddItemToBasketAsync(string buyerId, int productId, int quantity);
        Task<int> GetBasketItemsCountAsync(string buyerId);
        Task TransferBasketAsync(string sourceBuyerId, string targetBuyerId);
        Task DeleteBasketAsync(string buyerId);
        Task DeleteBasketItemAsync(string buyerId, int basketItemId);
        Task<Basket> SetQuantitiesAsync(string buyerId,Dictionary<int,int> quantities);

    }
}

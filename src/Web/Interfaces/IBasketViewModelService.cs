using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Interfaces
{
    public interface IBasketViewModelService
    {
        Task<BasketViewModel> GetBasketViewModelAsync();

        Task<int> AddItemToBasketAsync(int product, int quantity);

        Task<NavBasketViewModel> GetNavBasketViewModelAsync();
        Task DeleteBasketAsync();
        Task DeleteBasketItemAsync(int basketItemId);

        Task<BasketViewModel> SetQuantities(Dictionary<int, int> quantities); 

    }
}

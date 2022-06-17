using ApplicationCore.Entities;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Interfaces
{
    public interface IBasketViewModelService
    {
        Task<BasketViewModel> GetBasketViewModelAsync();

        Task<int> AddItemToBasketAsync(int product, int quantity);

        Task<NavBasketViewModel> GetNavBasketViewModelAsync();
    }
}

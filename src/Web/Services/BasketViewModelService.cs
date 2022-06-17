using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.Models;

namespace Web.Services
{
    public class BasketViewModelService : IBasketViewModelService
    {
        private readonly IBasketService _basketService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        public string BuyerId => UserId ?? AnonymousId;

        public HttpContext HttpContext => _httpContextAccessor.HttpContext;

        public string UserId => HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier); // get user id

        public string AnonymousId => HttpContext.Request.Cookies[Constants.BASKET_COOKIENAME];

        public BasketViewModelService(IBasketService basketService, IHttpContextAccessor httpContextAccessor)
        {
            _basketService = basketService;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<int> AddItemToBasketAsync(int product, int quantity)
        {
            var buyerId = BuyerId ?? CreateAnonymouseId();
            var basket = await _basketService.AddItemToBasketAsync(buyerId, product, quantity);
            return basket.Items.Sum(x => x.Quantity);
        }

        private string CreateAnonymouseId()
        {
            string newId = Guid.NewGuid().ToString();
            HttpContext.Response.Cookies.Append(Constants.BASKET_COOKIENAME, newId, new CookieOptions()
            {
                Expires = DateTime.Now.AddYears(1),
                IsEssential = true,
            });
            return newId;
        }

        public async Task<NavBasketViewModel> GetNavBasketViewModelAsync() => new NavBasketViewModel() { TotalItems = await _basketService.GetBasketItemsCountAsync(BuyerId) };

        public async Task<BasketViewModel> GetBasketViewModelAsync()
        {
            var basket = await _basketService.GetBasketAsync(BuyerId);

            if (basket == null) return null;

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

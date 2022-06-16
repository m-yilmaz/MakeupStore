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

namespace Web.Services
{
    public class BasketViewModelService : IBasketViewModelService
    {
        private readonly IBaskerService _baskerService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;

        public HttpContext HttpContext => _httpContextAccessor.HttpContext;

        public string UserId => HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier); // get user id

        public string AnonymousId => HttpContext.Request.Cookies[Constants.BASKET_COOKIENAME];

        public BasketViewModelService(IBaskerService baskerService, IHttpContextAccessor httpContextAccessor)
        {
            _baskerService = baskerService;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<int> AddItemToBasketAsync(int product, int quantity)
        {
            var buyerId = UserId ?? AnonymousId ?? CreateAnonymouseId();
            var basket = await _baskerService.AddItemToBasketAsync(buyerId, product, quantity);
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
    }
}

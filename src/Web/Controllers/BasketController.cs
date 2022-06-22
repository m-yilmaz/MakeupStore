using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Interfaces;

namespace Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketViewModelService _basketViewModelService;

        public BasketController(IBasketViewModelService basketViewModelService)
        {
            _basketViewModelService = basketViewModelService;
        }

        [HttpGet]
        public async Task<IActionResult> Index() => View(await _basketViewModelService.GetBasketViewModelAsync());

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(Dictionary<int, int> quantities)
        {
            var basket = await _basketViewModelService.SetQuantities(quantities);
            TempData["Message"] = "Items updated successfully";
            return View(basket);
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(int productId, int quantity = 1)
        {
            int totalItems = await _basketViewModelService.AddItemToBasketAsync(productId, quantity);
            return Json(new { totalItems });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EmptyBasket()
        {
            await _basketViewModelService.DeleteBasketAsync();
            TempData["Message"] = "All items removed from cart successfully";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveItem(int itemId)
        {
            await _basketViewModelService.DeleteBasketItemAsync(itemId);
            TempData["Message"] = "Item removed from cart successfully";
            return RedirectToAction(nameof(Index));
        }

    }
}
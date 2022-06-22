using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class BasketService : IBasketService
    {
        private readonly IRepository<Basket> _basketRepo;

        public BasketService(IRepository<Basket> basketRepo)
        {
            _basketRepo = basketRepo;
        }

        public async Task<Basket> AddItemToBasketAsync(string buyerId, int productId, int quantity)
        {
            var basket = await GetBasketAsync(buyerId);

            if (basket == null)
            {
                basket = new Basket() { BuyerId = buyerId };
                await _basketRepo.AddAsnyc(basket);
            }

            var basketItem = basket.Items.FirstOrDefault(x => x.ProductId == productId);

            if (basketItem == null)
                basket.Items.Add(new BasketItem() { ProductId = productId, Quantity = quantity });
            else
                basketItem.Quantity += quantity;

            await _basketRepo.UpdateAsnyc(basket);

            return basket;
        }

        public async Task DeleteBasketAsync(string buyerId)
        {
            var specBasket = new BasketSpecification(buyerId);
            var basket = await _basketRepo.FirstOrDefaultAsync(specBasket);
            if (basket != null)
            {
                await _basketRepo.DeleteAsnyc(basket);
            }
        }

        public async Task DeleteBasketItemAsync(string buyerId, int basketItemId)
        {
            var basket = await GetBasketAsync(buyerId);
            var basketItem = basket.Items.FirstOrDefault(x => x.Id == basketItemId);
            basket.Items.Remove(basketItem);
            await _basketRepo.UpdateAsnyc(basket);
        }

        public async Task<Basket> GetBasketAsync(string buyerId)
        {
            var specBasket = new BasketWithItemsSpecification(buyerId);
            return await _basketRepo.FirstOrDefaultAsync(specBasket);
        }

        public async Task<int> GetBasketItemsCountAsync(string buyerId)
        {
            if (buyerId == null) return 0;
            var basket = await GetBasketAsync(buyerId);

            return basket == null ? 0 : basket.Items.Sum(x => x.Quantity);

        }

        public async Task<Basket> SetQuantities(string buyerId, Dictionary<int, int> quantities)
        {
            var basket = await GetBasketAsync(buyerId);
            if (basket == null) return null;
            foreach (var item in basket.Items)
            {
                try
                {
                    item.Quantity = quantities[item.Id];
                }
                catch (Exception) { }
            }
            await _basketRepo.UpdateAsnyc(basket);
            return basket;
        }

        public async Task TransferBasketAsync(string sourceBuyerId, string targetBuyerId)
        {
            if (sourceBuyerId == null || targetBuyerId == null) return;

            var sourceBasket = await GetBasketAsync(sourceBuyerId);
            if (sourceBasket == null || sourceBasket.Items.Count == 0) return;
            var targetBasket = await GetBasketAsync(targetBuyerId) ?? await _basketRepo.AddAsnyc(new(targetBuyerId));

            foreach (var sourceItem in sourceBasket.Items)
            {
                var targetItem = targetBasket.Items.FirstOrDefault(x => x.ProductId == sourceItem.ProductId);
                if (targetItem == null)
                {
                    targetBasket.Items.Add(new BasketItem() { ProductId = sourceItem.ProductId, Quantity = sourceItem.Quantity });
                }
                else
                {
                    targetItem.Quantity += sourceItem.Quantity;
                }
            }

            await _basketRepo.UpdateAsnyc(targetBasket);
            await _basketRepo.DeleteAsnyc(sourceBasket);

        }
    }
}

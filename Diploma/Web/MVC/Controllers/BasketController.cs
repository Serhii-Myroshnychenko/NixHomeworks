using Infrastructure.Models.Items;
using MVC.Services.Interfaces;
using MVC.ViewModels;
using MVC.ViewModels.BasketViewModels;

namespace MVC.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;
        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }
        public async Task<IActionResult> Index()
        {
            var items = await _basketService.GetBasketItems();
            var total = items.Sum(c => c.Price * c.Quantity);

            var basketViewModel = new BasketIndexViewModel()
            {
                CatalogBasketCars = items,
                Total = total
            };

            return View(basketViewModel);
        }
        public async Task<IActionResult> AddToBasket(CatalogCar car)
        {
            await _basketService.AddToBasket(car);
            return RedirectToAction(nameof(CatalogController.Index), "Catalog");
        }
        public async Task<IActionResult> RemoveFromBasket(CatalogBasketCar car)
        {
            await _basketService.RemoveFromBasket(car);
            return RedirectToAction("Index");
        }
    }
}

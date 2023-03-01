using Microsoft.AspNetCore.Mvc;
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
            var basketViewModel = new BasketIndexViewModel()
            {
                CatalogBasketCars = await _basketService.GetBasketItems(),
                Total = 12
            };

            return View(basketViewModel);
        }
        public async Task<IActionResult> AddToBasket(CatalogCar car)
        {
            await _basketService.AddToBasket(car);
            return RedirectToAction("Index");
        }
    }
}

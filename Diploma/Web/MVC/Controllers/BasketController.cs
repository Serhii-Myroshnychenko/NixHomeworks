using Microsoft.AspNetCore.Mvc;
using MVC.ViewModels;
using MVC.ViewModels.BasketViewModels;

namespace MVC.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            var basketViewModel = new BasketIndexViewModel()
            {
                CatalogCars = new List<CatalogCar>()
                {
                    new CatalogCar()
                    {
                        Id = 1, 
                        Model = "Tessssst",
                        Year = new DateTime(2002, 12,11),
                        Transmission = "Tesssssst",
                        Price = 111,
                        Description = "Tesssssssssst",
                        PictureUrl = "1.png",
                        EngineDisplacement = 2.2,
                        CatalogManufacturer = new CatalogManufacturer()
                        {
                            Id = 1,
                            Name = "Test",
                            FoundationYear = new DateTime(2002, 11, 21),
                            HeadquartersLocation = "Testssssssssss"
                        }
                    }
                },
                Total = 11
            };

            return View(basketViewModel);
        }
    }
}

using Catalog.Host.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static readonly Product[] _products = new[]
        {
            new Product() { Id = 1, Name = "Car", Price = 1200},
            new Product() { Id = 2, Name = "Bike", Price = 750},
            new Product() { Id = 1, Name = "Spaceship", Price = 3500}
        };

        [HttpGet]
        public IActionResult GetProducts()
        {
            try
            {
                return Ok(_products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

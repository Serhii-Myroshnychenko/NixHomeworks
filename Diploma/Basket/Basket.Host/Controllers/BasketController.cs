using Basket.Host.Models.Responses;
using Basket.Host.Services.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Basket.Host.Controllers
{
    [ApiController]
    [Authorize(Policy = AuthPolicy.AllowClientPolicy)]
    [Scope("basket.products")]
    [Route(ComponentDefaults.DefaultRoute)]
    public class BasketController : ControllerBase
    {
        private readonly ILogger<BasketController> _logger;
        private readonly IBasketService _basketService;

        public BasketController(
            ILogger<BasketController> logger,
            IBasketService basketService)
        {
            _logger = logger;
            _basketService = basketService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(GetBasketResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBasket()
        {
            _logger.LogInformation($"Basket Request--------------------------------");
            var basketId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
            var response = await _basketService.GetItems(basketId!);
            _logger.LogInformation($"Everything is ok--------------------------------");
            return Ok(new GetBasketResponse() { Data = response.Data });
        }

        [HttpPost]
        [ProducesResponseType(typeof(GetBasketResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBasketById([FromBody]string id)
        {
            _logger.LogInformation($"Basket Request--------------------------------");
            var response = await _basketService.GetItems(id);
            _logger.LogInformation($"Everything is ok--------------------------------");
            return Ok(new GetBasketResponse() { Data = response.Data });
        }

    }
}

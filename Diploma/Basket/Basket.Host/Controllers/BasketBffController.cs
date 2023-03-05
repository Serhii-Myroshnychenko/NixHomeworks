using Basket.Host.Models;
using Basket.Host.Models.Items;
using Basket.Host.Models.Requests;
using Basket.Host.Models.Responses;
using Basket.Host.Services.Interfaces;
using Infrastructure.Filters;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Basket.Host.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
[Route(ComponentDefaults.DefaultRoute)]
public class BasketBffController : ControllerBase
{
    private readonly ILogger<BasketBffController> _logger;
    private readonly IBasketService _basketService;

    public BasketBffController(
        ILogger<BasketBffController> logger,
        IBasketService basketService)
    {
        _logger = logger;
        _basketService = basketService;
    }
    
    [HttpPost]
    [RateLimit]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> AddCarsToBasket(AddToBasketRequest request)
    {
        _logger.LogInformation($"Basket Request-------------------------------- Count of data: {request.Data.Count()}");
        var basketId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
        await _basketService.AddItems(basketId!, request.Data);
        return Ok();
    }

    [HttpPost]
    [RateLimit]
    [ProducesResponseType(typeof(GetBasketResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetBasket()
    {
        _logger.LogInformation($"Basket Request--------------------------------");
        var basketId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
        var response = await _basketService.GetItems(basketId!);
        _logger.LogInformation($"Everything is ok--------------------------------");
        return Ok(new GetBasketResponse() { Data = response.Data});
    }

}
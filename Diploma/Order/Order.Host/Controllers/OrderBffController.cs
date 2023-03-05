using Order.Host.Configurations;
using Order.Host.Models.Dtos;
using Order.Host.Services.Interfaces;
using Infrastructure.Filters;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Order.Host.Models.Response;
using Order.Host.Models.Requests;
using Order.Host.Models;

namespace Order.Host.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
[Route(ComponentDefaults.DefaultRoute)]
public class OrderBffController : ControllerBase
{
    private readonly ILogger<OrderBffController> _logger;
    private readonly IPurchaseSevice _purchaseSevice;
    private readonly IClientService _clientService;
    private readonly IProductService _productService;
    private readonly IOptions<OrderConfig> _config;

    public OrderBffController(
        ILogger<OrderBffController> logger,
        IPurchaseSevice purchaseSevice,
        IClientService clientService,
        IProductService productService,
        IOptions<OrderConfig> config)
    {
        _logger = logger;
        _purchaseSevice = purchaseSevice;
        _clientService = clientService;
        _productService = productService;
        _config = config;
    }

    [HttpPost]
    [LogAsyncActionFilter("Get")]
    [ProducesResponseType(typeof(GroupedEntitiesResponse<PurchaseDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Get()
    {
        var id = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
        _logger.LogInformation($"Iddddddddddddd: {id}");

        return Ok(await _purchaseSevice.GetPurchasesAsync());
    }

    [HttpPost]
    [LogAsyncActionFilter("GetById")]
    [ProducesResponseType(typeof(GroupedEntitiesResponse<PurchaseDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetById(int clientId)
    {
        var id = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
        return Ok(await _purchaseSevice.GetPurchasesByIdAsync(clientId));
    }

    [HttpPost]
    [LogAsyncActionFilter("DeleteById")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteById(int id)
    {
        return Ok(await _purchaseSevice.DeletePurchaseAsync(id));
    }

    [HttpPost]
    [LogAsyncActionFilter("GetOrderBasketByClientId")]
    [ProducesResponseType(typeof(GroupedEntitiesResponse<CatalogBasketCar>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetOrderBasketByClientId()
    {
        var id = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;

        return Ok(await _purchaseSevice.GetPurchasesByClientIdAsync(int.Parse(id!)));
    }

    [HttpPost]
    [LogAsyncActionFilter("PlaceOrder")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> PlaceOrder([FromBody] PlaceOrderRequest request)
    {
        var id = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
        _logger.LogInformation($"Place an Order--------------: id: {id}, firstName: {request.FirstName}, lastName: {request.LastName}");

        await _purchaseSevice.PlaceOrder(int.Parse(id!), request.FirstName, request.LastName);
        return Ok();
    }

    [HttpPost]
    [LogAsyncActionFilter("GetClients")]
    [ProducesResponseType(typeof(GroupedEntitiesResponse<ClientDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetClients()
    {
        var id = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
        return Ok(await _clientService.GetClientsAsync());
    }

    [HttpPost]
    [LogAsyncActionFilter("GetProducts")]
    [ProducesResponseType(typeof(GroupedEntitiesResponse<ProductDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProducts()
    {
        var id = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
        return Ok(await _productService.GetProductsAsync());
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteProductById(int id)
    {
        return Ok(await _productService.DeleteProductAsync(id));
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteClientById(int id)
    {
        return Ok(await _clientService.DeleteClientAsync(id));
    }
}
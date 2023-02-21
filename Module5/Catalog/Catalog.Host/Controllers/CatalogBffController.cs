using Catalog.Host.Configurations;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Enums;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Catalog.Host.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogBffController : ControllerBase
{
    private readonly ILogger<CatalogBffController> _logger;
    private readonly ICatalogCarService _catalogCarService;
    private readonly ICatalogManufacturerService _catalogManufacturerService;
    private readonly IOptions<CatalogConfig> _config;

    public CatalogBffController(
        ILogger<CatalogBffController> logger,
        ICatalogCarService catalogCarService,
        IOptions<CatalogConfig> config,
        ICatalogManufacturerService catalogManufacturerService)
    {
        _logger = logger;
        _catalogCarService = catalogCarService;
        _config = config;
        _catalogManufacturerService = catalogManufacturerService;
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogCarDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Items(PaginatedItemsRequest<CatalogTypeFilter> request)
    {
        return Ok(await _catalogCarService.GetCatalogCarsAsync(request.PageSize, request.PageIndex, request.Filters));
    }

    [HttpPost]
    [ProducesResponseType(typeof(GroupedEntitiesResponse<CatalogManufacturerDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetManufacturers()
    {
        _logger.LogInformation($"User Id {User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value}");
        return Ok(await _catalogManufacturerService.GetCatalogManufacturersAsync());
    }
}
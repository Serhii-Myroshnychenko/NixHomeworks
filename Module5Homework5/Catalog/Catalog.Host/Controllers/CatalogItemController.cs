using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Requests.CatalogItemRequests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogItemController : ControllerBase
{
    private readonly ILogger<CatalogItemController> _logger;
    private readonly ICatalogItemService _catalogItemService;

    public CatalogItemController(
        ILogger<CatalogItemController> logger,
        ICatalogItemService catalogItemService)
    {
        _logger = logger;
        _catalogItemService = catalogItemService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CatalogItemResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Add(CreateCatalogItemRequest request)
    {
        var result = await _catalogItemService.AddCatalogItemAsync(request.Name, request.Description, request.Price, request.AvailableStock, request.CatalogBrandId, request.CatalogTypeId, request.PictureFileName);
        return Ok(new CatalogItemResponse() { Id = result.Id, Name = result.Name, Description = result.Description, Price = result.Price, AvailableStock = result.AvailableStock, CatalogBrandId = result.CatalogBrand.Id, CatalogTypeId = result.CatalogType.Id, PictureFileName = result.PictureUrl });
    }

    [HttpPost]
    [ProducesResponseType(typeof(CatalogItemResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Put(UpdateCatalogItemRequest request)
    {
        var result = await _catalogItemService.UpdateCatalogItemAsync(request.Id, request.Name, request.Description, request.Price, request.AvailableStock, request.CatalogBrandId, request.CatalogTypeId, request.PictureFileName);
        return Ok(new CatalogItemResponse() { Id = result.Id, Name = result.Name, Description = result.Description, Price = result.Price, AvailableStock = result.AvailableStock, CatalogBrandId = result.CatalogBrand.Id, CatalogTypeId = result.CatalogType.Id, PictureFileName = result.PictureUrl });
    }

    [HttpPost]
    [ProducesResponseType(typeof(CatalogItemResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _catalogItemService.DeleteCatalogItemAsync(id);
        return Ok(new CatalogItemResponse() { Id = result.Id, Name = result.Name, Description = result.Description, Price = result.Price, AvailableStock = result.AvailableStock, CatalogBrandId = result.CatalogBrand.Id, CatalogTypeId = result.CatalogType.Id, PictureFileName = result.PictureUrl });
    }
}
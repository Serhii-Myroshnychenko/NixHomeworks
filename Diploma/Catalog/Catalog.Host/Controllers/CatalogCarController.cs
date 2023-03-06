using Catalog.Host.Services.Interfaces;
using Infrastructure.Filters;
using Infrastructure.Identity;
using Infrastructure.Models.Requests.CatalogCarRequests;
using Infrastructure.Models.Responses;
using Microsoft.AspNetCore.Authorization;

namespace Catalog.Host.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowClientPolicy)]
[Scope("catalog.catalogcar")]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogCarController : ControllerBase
{
    private readonly ILogger<CatalogCarController> _logger;
    private readonly ICatalogCarService _catalogCarService;

    public CatalogCarController(
        ILogger<CatalogCarController> logger,
        ICatalogCarService catalogCarService)
    {
        _logger = logger;
        _catalogCarService = catalogCarService;
    }

    [HttpPost]
    [LogAsyncActionFilter("Add")]
    [ProducesResponseType(typeof(CatalogCarResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Add(CreateCatalogCarRequest request)
    {
        var result = await _catalogCarService.AddCatalogCarAsync(request.Model, request.Year, request.Transmission, request.Price, request.Description, request.PictureFileName, request.EngineDisplacement, request.Quantity, request.CatalogManufacturerId);
        return Ok(new CatalogCarResponse() { Id = result.Id, Model = result.Model, Year = result.Year, Transmission = result.Transmission, Description = result.Description, Price = result.Price, EngineDisplacement = result.EngineDisplacement, PictureUrl = result.PictureUrl, Quantity = result.Quantity });
    }

    [HttpPost]
    [LogAsyncActionFilter("Put")]
    [ProducesResponseType(typeof(CatalogCarResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Put(UpdateCatalogCarRequest request)
    {
        var result = await _catalogCarService.UpdateCatalogCarAsync(request.Id, request.Model, request.Year, request.Transmission, request.Price, request.Description, request.PictureFileName, request.EngineDisplacement, request.Quantity, request.CatalogManufacturerId);
        return Ok(new CatalogCarResponse() { Id = result.Id, Model = result.Model, Year = result.Year, Transmission = result.Transmission, Description = result.Description, Price = result.Price, EngineDisplacement = result.EngineDisplacement, PictureUrl = result.PictureUrl, Quantity = result.Quantity });
    }

    [HttpPost]
    [LogAsyncActionFilter("Delete")]
    [ProducesResponseType(typeof(CatalogCarResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _catalogCarService.DeleteCatalogCarAsync(id);
        return Ok(new CatalogCarResponse() { Id = result.Id, Model = result.Model, Year = result.Year, Transmission = result.Transmission, Description = result.Description, Price = result.Price, EngineDisplacement = result.EngineDisplacement, PictureUrl = result.PictureUrl, Quantity = result.Quantity });
    }

    [HttpPost]
    [LogAsyncActionFilter("GetById")]
    [ProducesResponseType(typeof(CatalogCarResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _catalogCarService.GetCatalogCarByIdAsync(id);
        return Ok(new CatalogCarResponse() { Id = result.Id, Model = result.Model, Year = result.Year, Transmission = result.Transmission, Description = result.Description, Price = result.Price, EngineDisplacement = result.EngineDisplacement, PictureUrl = result.PictureUrl, Quantity = result.Quantity });
    }

    [HttpPost]
    [LogAsyncActionFilter("GetByManufacturer")]
    [ProducesResponseType(typeof(GroupedEntitiesResponse<CatalogCarResponse>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByManufacturer(int manufacturerId)
    {
        return Ok(await _catalogCarService.GetCatalogCarByManufacturerAsync(manufacturerId));
    }

    [HttpPost]
    [LogAsyncActionFilter("UpdateAllCars")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateAllCars([FromBody]string id)
    {
        await _catalogCarService.UpdateCatalogCarQuantity(int.Parse(id!));
        return Ok();
    }
}
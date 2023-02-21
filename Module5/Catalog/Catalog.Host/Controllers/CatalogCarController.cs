using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Requests.CatalogCarRequests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Catalog.Host.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowClientPolicy)]
[Scope("catalog.catalogitem")]
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
    [ProducesResponseType(typeof(CatalogCarResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Add(CreateCatalogCarRequest request)
    {
        var result = await _catalogCarService.AddCatalogCarAsync(request.Model, request.Year, request.Transmission, request.Price, request.Description, request.PictureFileName, request.EngineDisplacement, request.CatalogManufacturerId);
        return Ok(new CatalogCarResponse() { Id = result.Id, Model = result.Model, Year = result.Year, Transmission = result.Transmission, Description = result.Description, Price = result.Price, EngineDisplacement = result.EngineDisplacement, PictureUrl = result.PictureUrl });
    }

    [HttpPost]
    [ProducesResponseType(typeof(CatalogCarResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Put(UpdateCatalogCarRequest request)
    {
        var result = await _catalogCarService.UpdateCatalogCarAsync(request.Id, request.Model, request.Year, request.Transmission, request.Price, request.Description, request.PictureFileName, request.EngineDisplacement, request.CatalogManufacturerId);
        return Ok(new CatalogCarResponse() { Id = result.Id, Model = result.Model, Year = result.Year, Transmission = result.Transmission, Description = result.Description, Price = result.Price, EngineDisplacement = result.EngineDisplacement, PictureUrl = result.PictureUrl });
    }

    [HttpPost]
    [ProducesResponseType(typeof(CatalogCarResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _catalogCarService.DeleteCatalogCarAsync(id);
        return Ok(new CatalogCarResponse() { Id = result.Id, Model = result.Model, Year = result.Year, Transmission = result.Transmission, Description = result.Description, Price = result.Price, EngineDisplacement = result.EngineDisplacement, PictureUrl = result.PictureUrl });
    }
}
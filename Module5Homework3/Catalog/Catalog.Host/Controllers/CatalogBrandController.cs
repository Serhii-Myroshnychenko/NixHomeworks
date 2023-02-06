using System.Net;
using Catalog.Host.Models.Requests.CatalogRequests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogBrandController : ControllerBase
{
    private readonly ILogger<CatalogBrandController> _logger;
    private readonly ICatalogBrandService _catalogBrandService;

    public CatalogBrandController(
        ILogger<CatalogBrandController> logger,
        ICatalogBrandService catalogBrandService)
    {
        _logger = logger;
        _catalogBrandService = catalogBrandService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CatalogBrandResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Add(CreateBrandRequest request)
    {
        var result = await _catalogBrandService.CreateCatalogBrandAsync(request.Brand);
        return Ok(new CatalogBrandResponse() { Id = result.Id, Brand = result.Brand });
    }

    [HttpPost]
    [ProducesResponseType(typeof(CatalogBrandResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Put(UpdateBrandRequest request)
    {
        var result = await _catalogBrandService.UpdateCatalogBrandAsync(request.Id, request.Brand);
        return Ok(new CatalogBrandResponse() { Id = result.Id, Brand = result.Brand });
    }

    [HttpPost]
    [ProducesResponseType(typeof(CatalogBrandResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _catalogBrandService.DeleteCatalogBrandAsync(id);
        return Ok(new CatalogBrandResponse() { Id = result.Id, Brand = result.Brand });
    }
}
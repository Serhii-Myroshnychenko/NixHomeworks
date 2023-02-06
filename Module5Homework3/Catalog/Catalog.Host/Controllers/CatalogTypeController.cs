using System.Net;
using Catalog.Host.Models.Requests.CatalogTypeRequests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogTypeController : ControllerBase
{
    private readonly ILogger<CatalogTypeController> _logger;
    private readonly ICatalogTypeService _catalogTypeService;

    public CatalogTypeController(
        ILogger<CatalogTypeController> logger, ICatalogTypeService catalogTypeService)
    {
        _logger = logger;
        _catalogTypeService = catalogTypeService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CatalogTypeResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Add(CreateCatalogTypeRequest request)
    {
        var result = await _catalogTypeService.CreateCatalogTypeAsync(request.Type);
        return Ok(new CatalogTypeResponse() { Id = result.Id, Type = result.Type });
    }

    [HttpPost]
    [ProducesResponseType(typeof(CatalogTypeResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Put(UpdateCatalogTypeRequest request)
    {
        var result = await _catalogTypeService.UpdateCatalogTypeAsync(request.Id, request.Type);
        return Ok(new CatalogTypeResponse() { Id = result.Id, Type = result.Type });
    }

    [HttpPost]
    [ProducesResponseType(typeof(CatalogTypeResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _catalogTypeService.DeleteCatalogTypeAsync(id);
        return Ok(new CatalogTypeResponse() { Id = result.Id, Type = result.Type });
    }
}
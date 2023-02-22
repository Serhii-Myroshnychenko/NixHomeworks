using Catalog.Host.Models.Requests.CatalogManufacturerRequests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Filters;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Catalog.Host.Controllers
{
    [ApiController]
    [Authorize(Policy = AuthPolicy.AllowClientPolicy)]
    [Scope("catalog.catalogmanufacturer")]
    [Route(ComponentDefaults.DefaultRoute)]
    public class CatalogManufacturerController : ControllerBase
    {
        private readonly ILogger<CatalogManufacturerController> _logger;
        private readonly ICatalogManufacturerService _catalogManufacturerService;

        public CatalogManufacturerController(
            ILogger<CatalogManufacturerController> logger,
            ICatalogManufacturerService catalogManufacturerService)
        {
            _logger = logger;
            _catalogManufacturerService = catalogManufacturerService;
        }

        [HttpPost]
        [LogAsyncActionFilter("Add")]
        [ProducesResponseType(typeof(CatalogManufacturerResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(CreateCatalogManufacturerRequest request)
        {
            var result = await _catalogManufacturerService.CreateCatalogManufacturerAsync(request.Name, request.FoundationYear, request.HeadquartersLocation);
            return Ok(new CatalogManufacturerResponse() { Id = result.Id, Name = result.Name, FoundationYear = result.FoundationYear, HeadquartersLocation = result.HeadquartersLocation });
        }

        [HttpPost]
        [LogAsyncActionFilter("Put")]
        [ProducesResponseType(typeof(CatalogManufacturerResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put(UpdateCatalogManufacturerRequest request)
        {
            var result = await _catalogManufacturerService.UpdateCatalogManufacturerAsync(request.Id, request.Name, request.FoundationYear, request.HeadquartersLocation);
            return Ok(new CatalogManufacturerResponse() { Id = result.Id, Name = result.Name, FoundationYear = result.FoundationYear, HeadquartersLocation = result.HeadquartersLocation });
        }

        [HttpPost]
        [LogAsyncActionFilter("Delete")]
        [ProducesResponseType(typeof(CatalogManufacturerResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _catalogManufacturerService.DeleteCatalogManufacturerAsync(id);
            return Ok(new CatalogManufacturerResponse() { Id = result.Id, Name = result.Name, FoundationYear = result.FoundationYear, HeadquartersLocation = result.HeadquartersLocation });
        }
    }
}

using Basket.Host.Models;
using Basket.Host.Services.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Basket.Host.Controllers
{
    [ApiController]
    [Authorize(Policy = AuthPolicy.AllowClientPolicy)]
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
    }
}

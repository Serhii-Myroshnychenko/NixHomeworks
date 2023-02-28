using Infrastructure.Services.Interfaces;
using MVC.Dtos;
using MVC.Models.Enums;
using MVC.Services.Interfaces;
using MVC.ViewModels;

namespace MVC.Services;

public class CatalogService : ICatalogService
{
    private readonly IOptions<AppSettings> _settings;
    private readonly IHttpClientService _httpClient;
    private readonly ILogger<CatalogService> _logger;

    public CatalogService(IHttpClientService httpClient, ILogger<CatalogService> logger, IOptions<AppSettings> settings)
    {
        _httpClient = httpClient;
        _settings = settings;
        _logger = logger;
    }

    public async Task<Catalog> GetCatalogCars(int page, int take, int? manufacturer)
    {
        var filters = new Dictionary<CatalogTypeFilter, int>();
        
        if (manufacturer.HasValue)
        {
            filters.Add(CatalogTypeFilter.Manufacturer, manufacturer.Value);
        }
        
        var result = await _httpClient.SendAsync<Catalog, PaginatedItemsRequest<CatalogTypeFilter>>($"{_settings.Value.CatalogUrl}/items",
           HttpMethod.Post, 
           new PaginatedItemsRequest<CatalogTypeFilter>()
           {
                PageIndex = page,
                PageSize = take,
                Filters = filters
           });

        return result;
    }

    public async Task<IEnumerable<SelectListItem>> GetCatalogManufacturers()
    {

        var result = await _httpClient.SendAsync<GroupedEntities<CatalogManufacturer>, GroupedEntities<CatalogManufacturer>>($"{_settings.Value.CatalogUrl}/GetManufacturers",
            HttpMethod.Post, null);

        var list = new List<SelectListItem>();

        list.AddRange(result.Data.Select(e => new SelectListItem()
        {
            Text = e.Name,
            Value = e.Id.ToString(),
        }));

        return list;
    }
}

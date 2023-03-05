using Catalog.Host.Configurations;
using Catalog.Host.Data;
using Catalog.Host.Models;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Enums;
using Catalog.Host.Models.Response;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogCarService : BaseDataService<ApplicationDbContext>, ICatalogCarService
{
    private readonly ICatalogCarRepository _catalogCarRepository;
    private readonly IInternalHttpClientService _internalHttpClientService;
    private readonly IOptions<CatalogConfig> _settings;
    private readonly IMapper _mapper;

    public CatalogCarService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogCarRepository catalogCarRepository,
        IInternalHttpClientService internalHttpClientService,
        IOptions<CatalogConfig> settings,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogCarRepository = catalogCarRepository;
        _internalHttpClientService = internalHttpClientService;
        _mapper = mapper;
        _settings = settings;
    }

    public async Task<CatalogCarDto> AddCatalogCarAsync(string model, DateTime year, string transmission, decimal price, string description, string pictureFileName, double engineDisplacement, int quantity, int catalogManufacturerId)
    {
        return await ExecuteSafeAsync(async () =>
        {
            return _mapper.Map<CatalogCarDto>(await _catalogCarRepository.AddCatalogCarAsync(model, year, transmission, price, description, pictureFileName, engineDisplacement, quantity, catalogManufacturerId));
        });
    }

    public async Task<CatalogCarDto> DeleteCatalogCarAsync(int id)
    {
        return await ExecuteSafeAsync(async () =>
        {
            return _mapper.Map<CatalogCarDto>(await _catalogCarRepository.DeleteCatalogCarAsync(id));
        });
    }

    public async Task<CatalogCarDto> GetCatalogCarByIdAsync(int id)
    {
        return await ExecuteSafeAsync(async () =>
        {
            return _mapper.Map<CatalogCarDto>(await _catalogCarRepository.GetByIdAsync(id));
        });
    }

    public async Task<GroupedEntitiesResponse<CatalogCarDto>> GetCatalogCarByManufacturerAsync(int manufacturerId)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogCarRepository.GetByManufacturerAsync(manufacturerId);
            return new GroupedEntitiesResponse<CatalogCarDto>()
            {
                Data = result.Data.Select(s => _mapper.Map<CatalogCarDto>(s)).ToList()
            };
        });
    }

    public async Task<PaginatedItemsResponse<CatalogCarDto>?> GetCatalogCarsAsync(int pageSize, int pageIndex, Dictionary<CatalogTypeFilter, int>? filters)
    {
        return await ExecuteSafeAsync(async () =>
        {
            int? manufacturerFilter = null;

            if (filters != null)
            {
                if (filters.TryGetValue(CatalogTypeFilter.Manufacturer, out var manufacturer))
                {
                    manufacturerFilter = manufacturer;
                }
            }

            var result = await _catalogCarRepository.GetByPageAsync(pageIndex, pageSize, manufacturerFilter);
            if (result == null)
            {
                return null;
            }

            return new PaginatedItemsResponse<CatalogCarDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<CatalogCarDto>(s)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        });
    }

    public async Task<CatalogCarDto> UpdateCatalogCarAsync(int id, string model, DateTime year, string transmission, decimal price, string description, string pictureFileName, double engineDisplacement, int quantity, int catalogManufacturerId)
    {
        return await ExecuteSafeAsync(async () =>
        {
            return _mapper.Map<CatalogCarDto>(await _catalogCarRepository.UpdateCatalogCarAsync(id, model, year, transmission, price, description, pictureFileName, engineDisplacement, quantity, catalogManufacturerId));
        });
    }

    public async Task UpdateCatalogCarQuantity(int clientId)
    {
        await ExecuteSafeAsync(async () =>
        {
            Console.WriteLine($"UpdateCatalogCarQuantity----------------------------------: clientId : {clientId}");

            var result = await _internalHttpClientService.SendAsync<GroupedEntities<CatalogBasketCar>, object>(
                $"{_settings.Value.BasketApi}/GetBasketById",
                HttpMethod.Post,
                clientId.ToString()).ConfigureAwait(false);

            var catalogCars = await _catalogCarRepository.GetCatalogCarsAsync();
            var basketItems = result.Data;
            var catalogItems = catalogCars.Data;

            Console.WriteLine($"UpdateCatalogCarQuantity----------------------------------: catalogCarsCount = {catalogItems.Count()}, basketItemsCount: {basketItems.Count()}");

            foreach (var basketItem in basketItems)
            {
                foreach (var catalogItem in catalogItems)
                {
                    if (basketItem.Id == catalogItem.Id)
                    {
                        await _catalogCarRepository.UpdateCatalogCarAsync(catalogItem.Id, catalogItem.Model, catalogItem.Year, catalogItem.Transmission, catalogItem.Price, catalogItem.Description, catalogItem.PictureFileName, catalogItem.EngineDisplacement, catalogItem.Quantity - basketItem.Quantity, catalogItem.CatalogManufacturerId);
                    }
                }
            }
        });
    }
}

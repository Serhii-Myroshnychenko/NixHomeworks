using Catalog.Host.Configurations;
using Catalog.Host.Data;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Enums;
using Infrastructure.Models;
using Infrastructure.Models.Dtos;
using Infrastructure.Models.Items;
using Infrastructure.Models.Responses;

namespace Catalog.Host.Services;

public class CatalogCarService : BaseDataService<ApplicationDbContext>, ICatalogCarService
{
    private readonly ICatalogCarRepository _catalogCarRepository;
    private readonly IInternalHttpClientService _internalHttpClientService;
    private readonly IOptions<CatalogConfig> _settings;
    private readonly IMapper _mapper;
    private readonly ILogger<BaseDataService<ApplicationDbContext>> _logger;

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
        _logger = logger;
    }

    public async Task<CatalogCarDto> AddCatalogCarAsync(string model, DateTime year, string transmission, decimal price, string description, string pictureFileName, double engineDisplacement, int quantity, int catalogManufacturerId)
    {
        _logger.LogInformation($"AddCatalogCarAsync method with the following parameters: model = {model}, year = {year}, price = {price}, description = {description}, pictureFileName = {pictureFileName}, engineDisplacement = {engineDisplacement}, quantity = {quantity}, catalogManufacturerId = {catalogManufacturerId}");
        return await ExecuteSafeAsync(async () =>
        {
            return _mapper.Map<CatalogCarDto>(await _catalogCarRepository.AddCatalogCarAsync(model, year, transmission, price, description, pictureFileName, engineDisplacement, quantity, catalogManufacturerId));
        });
    }

    public async Task<CatalogCarDto> DeleteCatalogCarAsync(int id)
    {
        _logger.LogInformation($"DeleteCatalogCarAsync method with the following parameters: id = {id}");
        return await ExecuteSafeAsync(async () =>
        {
            return _mapper.Map<CatalogCarDto>(await _catalogCarRepository.DeleteCatalogCarAsync(id));
        });
    }

    public async Task<CatalogCarDto> GetCatalogCarByIdAsync(int id)
    {
        _logger.LogInformation($"GetCatalogCarByIdAsync method with the following parameters: id = {id}");
        return await ExecuteSafeAsync(async () =>
        {
            return _mapper.Map<CatalogCarDto>(await _catalogCarRepository.GetByIdAsync(id));
        });
    }

    public async Task<GroupedEntitiesResponse<CatalogCarDto>> GetCatalogCarByManufacturerAsync(int manufacturerId)
    {
        _logger.LogInformation($"GetCatalogCarByManufacturerAsync method with the following parameters: manufacturerId = {manufacturerId}");
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
        _logger.LogInformation($"GetCatalogCarsAsync method with the following parameters: pageSize = {pageSize}, pageIndex = {pageIndex}");
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
        _logger.LogInformation($"UpdateCatalogCarAsync method with the following parameters: id = {id}, model = {model}, year = {year}, price = {price}, description = {description}, pictureFileName = {pictureFileName}, engineDisplacement = {engineDisplacement}, quantity = {quantity}, catalogManufacturerId = {catalogManufacturerId}");
        return await ExecuteSafeAsync(async () =>
        {
            return _mapper.Map<CatalogCarDto>(await _catalogCarRepository.UpdateCatalogCarAsync(id, model, year, transmission, price, description, pictureFileName, engineDisplacement, quantity, catalogManufacturerId));
        });
    }

    public async Task UpdateCatalogCarQuantity(int clientId)
    {
        _logger.LogInformation($"UpdateCatalogCarQuantity method with the following parameters: clientId = {clientId}");
        await ExecuteSafeAsync(async () =>
        {
            var result = await _internalHttpClientService.SendAsync<GroupedEntities<CatalogBasketCar>, object>(
                $"{_settings.Value.BasketApi}/GetBasketById",
                HttpMethod.Post,
                clientId.ToString()).ConfigureAwait(false);

            var catalogCars = await _catalogCarRepository.GetCatalogCarsAsync();
            var basketItems = result.Data;
            var catalogItems = catalogCars.Data;

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

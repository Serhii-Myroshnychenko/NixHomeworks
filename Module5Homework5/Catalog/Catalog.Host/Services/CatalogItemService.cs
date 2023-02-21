using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogItemService : BaseDataService<ApplicationDbContext>, ICatalogItemService
{
    private readonly ICatalogItemRepository _catalogItemRepository;
    private readonly IMapper _mapper;

    public CatalogItemService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogItemRepository catalogItemRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogItemRepository = catalogItemRepository;
        _mapper = mapper;
    }

    public async Task<CatalogItemDto> AddCatalogItemAsync(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName)
    {
        return await ExecuteSafeAsync(async () =>
        {
            return _mapper.Map<CatalogItemDto>(await _catalogItemRepository.AddCatalogItemAsync(name, description, price, availableStock, catalogBrandId, catalogTypeId, pictureFileName));
        });
    }

    public async Task<CatalogItemDto> DeleteCatalogItemAsync(int id)
    {
        return await ExecuteSafeAsync(async () =>
        {
            return _mapper.Map<CatalogItemDto>(await _catalogItemRepository.DeleteCatalogItemAsync(id));
        });
    }

    public async Task<CatalogItemDto> GetCatalogItemByBrandAsync(int brandId)
    {
        return await ExecuteSafeAsync(async () =>
        {
            return _mapper.Map<CatalogItemDto>(await _catalogItemRepository.GetByBrandAsync(brandId));
        });
    }

    public async Task<CatalogItemDto> GetCatalogItemByIdAsync(int id)
    {
        return await ExecuteSafeAsync(async () =>
        {
            return _mapper.Map<CatalogItemDto>(await _catalogItemRepository.GetByIdAsync(id));
        });
    }

    public async Task<CatalogItemDto> GetCatalogItemByTypeAsync(int typeId)
    {
        return await ExecuteSafeAsync(async () =>
        {
            return _mapper.Map<CatalogItemDto>(await _catalogItemRepository.GetByTypeAsync(typeId));
        });
    }

    public async Task<CatalogItemDto> UpdateCatalogItemAsync(int id, string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName)
    {
        return await ExecuteSafeAsync(async () =>
        {
            return _mapper.Map<CatalogItemDto>(await _catalogItemRepository.UpdateCatalogItemAsync(id, name, description, price, availableStock, catalogBrandId, catalogTypeId, pictureFileName));
        });
    }
}
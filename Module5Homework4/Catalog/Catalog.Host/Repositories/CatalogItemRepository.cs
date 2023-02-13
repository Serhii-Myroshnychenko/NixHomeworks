using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;

namespace Catalog.Host.Repositories;

public class CatalogItemRepository : ICatalogItemRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogItemRepository> _logger;

    public CatalogItemRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogItemRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<PaginatedItems<CatalogItem>> GetByPageAsync(int pageIndex, int pageSize)
    {
        var totalItems = await _dbContext.CatalogItems
            .LongCountAsync();

        var itemsOnPage = await _dbContext.CatalogItems
            .Include(i => i.CatalogBrand)
            .Include(i => i.CatalogType)
            .OrderBy(c => c.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogItem>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<CatalogItem?> AddCatalogItemAsync(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName)
    {
        var catalogBrand = await _dbContext.CatalogBrands.FirstOrDefaultAsync(c => c.Id == catalogBrandId);
        var catalogType = await _dbContext.CatalogTypes.FirstOrDefaultAsync(c => c.Id == catalogTypeId);
        if (catalogBrand != null && catalogType != null)
        {
            var item = await _dbContext.AddAsync(new CatalogItem
            {
                CatalogBrandId = catalogBrandId,
                CatalogTypeId = catalogTypeId,
                CatalogBrand = catalogBrand,
                CatalogType = catalogType,
                Description = description,
                AvailableStock = availableStock,
                Name = name,
                PictureFileName = pictureFileName,
                Price = price
            });

            await _dbContext.SaveChangesAsync();

            return item.Entity;
        }

        return default;
    }

    public async Task<CatalogItem?> GetByIdAsync(int id)
    {
        return await _dbContext.CatalogItems.Include(c => c.CatalogBrand).Include(c => c.CatalogType).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<CatalogItem?> GetByBrandAsync(int brandId)
    {
        return await _dbContext.CatalogItems.Include(c => c.CatalogBrand).Include(c => c.CatalogType).FirstOrDefaultAsync(c => c.CatalogBrandId == brandId);
    }

    public async Task<CatalogItem?> GetByTypeAsync(int typeId)
    {
        return await _dbContext.CatalogItems.Include(c => c.CatalogBrand).Include(c => c.CatalogType).FirstOrDefaultAsync(c => c.CatalogTypeId == typeId);
    }

    public async Task<CatalogItem?> UpdateCatalogItemAsync(int id, string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName)
    {
        var item = await _dbContext.CatalogItems.Include(c => c.CatalogBrand).Include(c => c.CatalogType).FirstOrDefaultAsync(c => c.Id == id);
        var catalogBrand = await _dbContext.CatalogBrands.FirstOrDefaultAsync(c => c.Id == catalogBrandId);
        var catalogType = await _dbContext.CatalogTypes.FirstOrDefaultAsync(c => c.Id == catalogTypeId);

        if (item != null && catalogBrand != null && catalogType != null)
        {
            item.Name = name;
            item.Description = description;
            item.Price = price;
            item.AvailableStock = availableStock;
            item.CatalogBrandId = catalogBrandId;
            item.PictureFileName = pictureFileName;
            item.CatalogTypeId = catalogTypeId;
            item.CatalogBrand = catalogBrand;
            item.CatalogType = catalogType;

            _dbContext.CatalogItems.Update(item);
            await _dbContext.SaveChangesAsync();
        }

        return item;
    }

    public async Task<CatalogItem?> DeleteCatalogItemAsync(int id)
    {
        var item = await _dbContext.CatalogItems.Include(c => c.CatalogBrand).Include(c => c.CatalogType)
                .FirstOrDefaultAsync(c => c.Id == id);
        if (item != null)
        {
            _dbContext.CatalogItems.Remove(item);
            await _dbContext.SaveChangesAsync();
        }

        return item;
    }
}
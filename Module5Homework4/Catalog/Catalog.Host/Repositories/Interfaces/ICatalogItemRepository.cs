using Catalog.Host.Data;
using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogItemRepository
{
    Task<PaginatedItems<CatalogItem>> GetByPageAsync(int pageIndex, int pageSize);
    Task<CatalogItem?> GetByIdAsync(int id);
    Task<CatalogItem?> GetByBrandAsync(int brandId);
    Task<CatalogItem?> GetByTypeAsync(int typeId);
    Task<CatalogItem?> AddCatalogItemAsync(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName);
    Task<CatalogItem?> UpdateCatalogItemAsync(int id, string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName);
    Task<CatalogItem?> DeleteCatalogItemAsync(int id);
}
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICatalogBrandRepository
    {
        Task<GroupedEntities<CatalogBrand>> GetCatalogBrandsAsync();
        Task<CatalogBrand> AddCatalogBrandAsync(string brand);
        Task<CatalogBrand?> DeleteCatalogBrandAsync(int id);
        Task<CatalogBrand?> UpdateCatalogBrandAsync(int id, string brand);
    }
}

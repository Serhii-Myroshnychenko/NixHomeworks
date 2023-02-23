using Catalog.Host.Data;
using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICatalogTypeRepository
    {
        Task<GroupedEntities<CatalogType>> GetCatalogTypesAsync();
        Task<CatalogType?> AddCatalogTypeAsync(string type);
        Task<CatalogType?> DeleteCatalogTypeAsync(int id);
        Task<CatalogType?> UpdateCatalogTypeAsync(int id, string type);
    }
}

using Catalog.Host.Data.Entities;
using Infrastructure.Models;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICatalogManufacturerRepository
    {
        Task<GroupedEntities<CatalogManufacturer>> GetCatalogManufacturersAsync();
        Task<CatalogManufacturer> AddCatalogManufacturerAsync(string name, DateTime foundationYear, string headquartersLocation);
        Task<CatalogManufacturer?> DeleteCatalogManufacturerAsync(int id);
        Task<CatalogManufacturer?> UpdateCatalogManufacturerAsync(int id, string name, DateTime foundationYear, string headquartersLocation);
    }
}

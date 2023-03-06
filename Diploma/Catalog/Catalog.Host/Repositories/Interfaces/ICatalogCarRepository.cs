using Catalog.Host.Data.Entities;
using Infrastructure.Models;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogCarRepository
{
    Task<PaginatedItems<CatalogCar>> GetByPageAsync(int pageIndex, int pageSize, int? manufacturerFilter);
    Task<GroupedEntities<CatalogCar>> GetCatalogCarsAsync();
    Task<CatalogCar?> GetByIdAsync(int id);
    Task<GroupedEntities<CatalogCar>> GetByManufacturerAsync(int manufacturerId);
    Task<CatalogCar?> AddCatalogCarAsync(string model, DateTime year, string transmission, decimal price, string description, string pictureFileName, double engineDisplacement, int quantity, int catalogManufacturerId);
    Task<CatalogCar?> UpdateCatalogCarAsync(int id, string model, DateTime year, string transmission, decimal price, string description, string pictureFileName, double engineDisplacement, int quantity, int catalogManufacturerId);
    Task<CatalogCar?> DeleteCatalogCarAsync(int id);
}
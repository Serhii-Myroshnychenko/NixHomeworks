using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Enums;
using Catalog.Host.Models.Response;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogCarService
{
    Task<PaginatedItemsResponse<CatalogCarDto>?> GetCatalogCarsAsync(int pageSize, int pageIndex, Dictionary<CatalogTypeFilter, int>? filters);
    Task<CatalogCarDto> GetCatalogCarByIdAsync(int id);
    Task<CatalogCarDto> GetCatalogCarByManufacturerAsync(int manufacturerId);
    Task<CatalogCarDto> AddCatalogCarAsync(string model, DateTime year, string transmission, decimal price, string description, string pictureFileName, double engineDisplacement, int catalogManufacturerId);
    Task<CatalogCarDto> UpdateCatalogCarAsync(int id, string model, DateTime year, string transmission, decimal price, string description, string pictureFileName, double engineDisplacement, int catalogManufacturerId);
    Task<CatalogCarDto> DeleteCatalogCarAsync(int id);
}

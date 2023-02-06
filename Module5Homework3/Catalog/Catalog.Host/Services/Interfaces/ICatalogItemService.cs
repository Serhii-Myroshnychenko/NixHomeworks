using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogItemService
{
    Task<CatalogItemDto> GetCatalogItemByIdAsync(int id);
    Task<CatalogItemDto> GetCatalogItemByBrandAsync(int brandId);
    Task<CatalogItemDto> GetCatalogItemByTypeAsync(int typeId);
    Task<CatalogItemDto> AddCatalogItemAsync(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName);
    Task<CatalogItemDto> UpdateCatalogItemAsync(int id, string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName);
    Task<CatalogItemDto> DeleteCatalogItemAsync(int id);
}
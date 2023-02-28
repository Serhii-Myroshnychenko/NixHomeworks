using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogManufacturerService
{
    Task<GroupedEntitiesResponse<CatalogManufacturerDto>> GetCatalogManufacturersAsync();
    Task<CatalogManufacturerDto> CreateCatalogManufacturerAsync(string name, DateTime foundationYear, string headquartersLocation);
    Task<CatalogManufacturerDto> UpdateCatalogManufacturerAsync(int id, string name, DateTime foundationYear, string headquartersLocation);
    Task<CatalogManufacturerDto> DeleteCatalogManufacturerAsync(int id);
}

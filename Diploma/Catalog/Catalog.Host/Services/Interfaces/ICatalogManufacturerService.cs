using Infrastructure.Models.Dtos;
using Infrastructure.Models.Responses;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogManufacturerService
{
    Task<GroupedEntitiesResponse<CatalogManufacturerDto>> GetCatalogManufacturersAsync();
    Task<CatalogManufacturerDto> CreateCatalogManufacturerAsync(string name, DateTime foundationYear, string headquartersLocation);
    Task<CatalogManufacturerDto> UpdateCatalogManufacturerAsync(int id, string name, DateTime foundationYear, string headquartersLocation);
    Task<CatalogManufacturerDto> DeleteCatalogManufacturerAsync(int id);
}

using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;

namespace Catalog.Host.Services.Interfaces
{
    public interface ICatalogTypeService
    {
        Task<GroupedEntitiesResponse<CatalogTypeDto>> GetCatalogTypesAsync();
        Task<CatalogTypeDto> CreateCatalogTypeAsync(string type);
        Task<CatalogTypeDto> UpdateCatalogTypeAsync(int id, string type);
        Task<CatalogTypeDto> DeleteCatalogTypeAsync(int id);
    }
}

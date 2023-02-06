using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;

namespace Catalog.Host.Services.Interfaces
{
    public interface ICatalogBrandService
    {
        Task<GroupedEntitiesResponse<CatalogBrandDto>> GetCatalogBrandsAsync();
        Task<CatalogBrandDto> CreateCatalogBrandAsync(string brand);
        Task<CatalogBrandDto> UpdateCatalogBrandAsync(int id, string brand);
        Task<CatalogBrandDto> DeleteCatalogBrandAsync(int id);
    }
}

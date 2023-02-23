using Basket.Host.Models;

namespace Basket.Host.Services.Interfaces
{
    public interface ICatalogItemService
    {
        Task<CatalogItemDto> AddCatalogItemAsync(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName);
    }
}

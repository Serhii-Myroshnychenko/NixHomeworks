using Infrastructure.Models.Dtos;
using Infrastructure.Models.Items;
using Infrastructure.Models.Responses;

namespace Order.Host.Services.Interfaces
{
    public interface IPurchaseSevice
    {
        Task<GroupedEntitiesResponse<PurchaseDto>> GetPurchasesAsync();
        Task<PurchaseDto> CreatePurchaseAsync(int productId, int clientId, int quantity);
        Task<PurchaseDto> UpdatePurchaseAsync(int id, int productId, int clientId, int quantity);
        Task<PurchaseDto> DeletePurchaseAsync(int id);
        Task<GroupedEntitiesResponse<PurchaseDto>> GetPurchasesByIdAsync(int clientId);
        Task<GroupedEntitiesResponse<CatalogBasketCar>> GetPurchasesByClientIdAsync(int clientId);
        Task PlaceOrder(int id, string firtsName, string lastName);
    }
}

using Order.Host.Models.Dtos;
using Order.Host.Models.Response;

namespace Order.Host.Services.Interfaces
{
    public interface IPurchaseSevice
    {
        Task<GroupedEntitiesResponse<PurchaseDto>> GetPurchasesAsync();
        Task<PurchaseDto> CreatePurchaseAsync(int productId, int clientId, int quantity);
        Task<PurchaseDto> UpdatePurchaseAsync(int id, int productId, int clientId, int quantity);
        Task<PurchaseDto> DeletePurchaseAsync(int id);
        Task<GroupedEntitiesResponse<PurchaseDto>> GetPurchasesByIdAsync(int clientId);
        Task PlaceOrder(int id, string firtsName, string lastName);
    }
}

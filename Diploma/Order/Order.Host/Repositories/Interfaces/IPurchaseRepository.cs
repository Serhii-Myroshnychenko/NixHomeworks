using Order.Host.Data;
using Order.Host.Data.Entities;
using Order.Host.Models;

namespace Order.Host.Repositories.Interfaces
{
    public interface IPurchaseRepository
    {
        Task<GroupedEntities<Purchase>> GetPurchasesAsync();
        Task<Purchase?> AddPurchaseAsync(int productId, int clientId, int quantity);
        Task<Purchase?> DeletePurchaseAsync(int id);
        Task<Purchase?> UpdatePurchaseAsync(int id, int productId, int clientId, int quantity);
        Task<GroupedEntities<CatalogBasketCar>> GetPurchasesByClientIdAsync(int clientId);
    }
}

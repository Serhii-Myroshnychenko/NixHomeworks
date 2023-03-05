using Order.Host.Data;
using Order.Host.Data.Entities;

namespace Order.Host.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<GroupedEntities<Product>> GetProductsAsync();
        Task<Product?> AddProductAsync(int id, string model, decimal price);
        Task<Product?> DeleteProductAsync(int id);
        Task<Product?> UpdateProductAsync(int id, string model, decimal price);
    }
}

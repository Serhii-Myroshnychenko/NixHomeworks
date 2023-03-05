using Order.Host.Data;
using Order.Host.Data.Entities;
using Order.Host.Repositories.Interfaces;

namespace Order.Host.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<ProductRepository> logger)
        {
            _dbContext = dbContextWrapper.DbContext;
            _logger = logger;
        }

        public async Task<Product?> AddProductAsync(int id, string model, decimal price)
        {
            _logger.LogInformation($"AddProductAsync method with the following input parameters: id = {id}, model = {model}, price = {price}");

            var item = await _dbContext.AddAsync(new Product()
            {
                Id = id,
                Model = model,
                Price = price,
            });

            await _dbContext.SaveChangesAsync();

            _logger.LogInformation($"Added new Product with the following parameters: id = {id}, model = {model}, price = {price}");

            return item.Entity;
        }

        public async Task<Product?> DeleteProductAsync(int id)
        {
            var product = await _dbContext.Products
                    .FirstOrDefaultAsync(c => c.Id == id);

            if (product != null)
            {
                _dbContext.Products.Remove(product);

                await _dbContext.SaveChangesAsync();

                _logger.LogInformation($"Deleted an existing Product with Id = {id}");
            }

            return product;
        }

        public async Task<GroupedEntities<Product>> GetProductsAsync()
        {
            _logger.LogInformation($"GetProductsAsync method");

            return new GroupedEntities<Product>()
            {
                Data = await _dbContext.Products.ToListAsync()
            };
        }

        public async Task<Product?> UpdateProductAsync(int id, string model, decimal price)
        {
            _logger.LogInformation($"UpdateProductAsync method with the following input parameters: id = {id}, model = {model}, price = {price}");

            var item = await _dbContext.Products
                .FirstOrDefaultAsync(c => c.Id == id);

            if (item != null)
            {
                item.Id = id;
                item.Model = model;
                item.Price = price;
                item.Purchases = item.Purchases;

                _dbContext.Products.Update(item);

                await _dbContext.SaveChangesAsync();

                _logger.LogInformation($"Updated an existing Product with the following parameters: id = {id}, model = {model}, price = {price}");
            }

            return item;
        }
    }
}

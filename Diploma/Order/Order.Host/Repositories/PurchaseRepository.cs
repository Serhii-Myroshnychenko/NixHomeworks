using Order.Host.Data;
using Order.Host.Data.Entities;
using Order.Host.Repositories.Interfaces;

namespace Order.Host.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<PurchaseRepository> _logger;

        public PurchaseRepository(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<PurchaseRepository> logger)
        {
            _dbContext = dbContextWrapper.DbContext;
            _logger = logger;
        }

        public async Task<Purchase?> AddPurchaseAsync(int productId, int clientId, int quantity)
        {
            _logger.LogInformation($"AddPurchaseAsync input parameters: productId = {productId}, clientId = {clientId}, quantity = {quantity}");

            var client = await _dbContext.Clients
                .FirstOrDefaultAsync(c => c.Id == clientId);

            var product = await _dbContext.Products
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (client != null && product != null)
            {
                var item = await _dbContext.AddAsync(new Purchase
                {
                    ClientId = clientId,
                    Client = client,
                    Quantity = quantity,
                    ProductId = productId,
                    Product = product
                });

                await _dbContext.SaveChangesAsync();

                _logger.LogInformation($"Added new purchase with the following parameters: productId = {productId}, clientId = {clientId}, quantity = {quantity}");

                return item.Entity;
            }

            return default;
        }

        public async Task<Purchase?> DeletePurchaseAsync(int id)
        {
            var item = await _dbContext.Purchases
                    .Include(c => c.Product)
                    .Include(c => c.Client)
                    .FirstOrDefaultAsync(c => c.Id == id);

            if (item != null)
            {
                _dbContext.Purchases.Remove(item);

                await _dbContext.SaveChangesAsync();

                _logger.LogInformation($"Deleted an existing Purchase with Id = {id}");
            }

            return item;
        }

        public async Task<GroupedEntities<Purchase>> GetPurchasesAsync()
        {
            _logger.LogInformation($"GetPurchasesAsync method");

            return new GroupedEntities<Purchase>()
            {
                Data = await _dbContext.Purchases.ToListAsync()
            };
        }

        public async Task<Purchase?> UpdatePurchaseAsync(int id, int productId, int clientId, int quantity)
        {
            _logger.LogInformation($"UpdatePurchaseAsync method with the following input parameters: id = {id}, productId = {productId}, clientId = {clientId}, quantity = {quantity}");

            var item = await _dbContext.Purchases
                .Include(c => c.Client)
                .Include(c => c.Product)
                .FirstOrDefaultAsync(c => c.Id == id);

            var client = await _dbContext.Clients
                .FirstOrDefaultAsync(c => c.Id == clientId);

            var product = await _dbContext.Products
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (item != null && client != null && product != null)
            {
                item.Product = product;
                item.ProductId = productId;
                item.Client = client;
                item.ClientId = clientId;
                item.Quantity = quantity;

                _dbContext.Purchases.Update(item);

                await _dbContext.SaveChangesAsync();

                _logger.LogInformation($"Updated an existing Purchase with the following parameters:id = {id}, productId = {productId}, clientId = {clientId}, quantity = {quantity}");
            }

            return item;
        }
    }
}

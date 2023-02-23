using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;

namespace Catalog.Host.Repositories
{
    public class CatalogBrandRepository : ICatalogBrandRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<CatalogBrandRepository> _logger;

        public CatalogBrandRepository(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<CatalogBrandRepository> logger)
        {
            _dbContext = dbContextWrapper.DbContext;
            _logger = logger;
        }

        public async Task<CatalogBrand?> AddCatalogBrandAsync(string brand)
        {
            var item = await _dbContext.AddAsync(new CatalogBrand()
            {
                Brand = brand
            });

            await _dbContext.SaveChangesAsync();

            return item.Entity;
        }

        public async Task<CatalogBrand?> DeleteCatalogBrandAsync(int id)
        {
            var brand = await _dbContext.CatalogBrands
                .FirstOrDefaultAsync(c => c.Id == id);
            if (brand != null)
            {
                _dbContext.CatalogBrands.Remove(brand);
                await _dbContext.SaveChangesAsync();
            }

            return brand;
        }

        public async Task<GroupedEntities<CatalogBrand>> GetCatalogBrandsAsync()
        {
            return new GroupedEntities<CatalogBrand>()
            {
                Data = await _dbContext.CatalogBrands.ToListAsync()
            };
        }

        public async Task<CatalogBrand?> UpdateCatalogBrandAsync(int id, string brand)
        {
            var item = await _dbContext.CatalogBrands.FirstOrDefaultAsync(c => c.Id == id);
            if (item != null)
            {
                item.Brand = brand;
                _dbContext.CatalogBrands.Update(item);
                await _dbContext.SaveChangesAsync();
            }

            return item;
        }
    }
}

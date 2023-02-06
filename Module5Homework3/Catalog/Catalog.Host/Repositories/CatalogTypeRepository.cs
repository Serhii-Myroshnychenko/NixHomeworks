using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories
{
    public class CatalogTypeRepository : ICatalogTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<CatalogTypeRepository> _logger;

        public CatalogTypeRepository(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<CatalogTypeRepository> logger)
        {
            _dbContext = dbContextWrapper.DbContext;
            _logger = logger;
        }

        public async Task<CatalogType> AddCatalogTypeAsync(string type)
        {
            var item = await _dbContext.AddAsync(new CatalogType()
            {
                Type = type
            });

            await _dbContext.SaveChangesAsync();

            return item.Entity;
        }

        public async Task<CatalogType?> DeleteCatalogTypeAsync(int id)
        {
            var type = await _dbContext.CatalogTypes
                .FirstOrDefaultAsync(c => c.Id == id);
            if (type != null)
            {
                _dbContext.CatalogTypes.Remove(type);
                await _dbContext.SaveChangesAsync();
            }

            return type;
        }

        public async Task<GroupedEntities<CatalogType>> GetCatalogTypesAsync()
        {
            return new GroupedEntities<CatalogType>()
            {
                Data = await _dbContext.CatalogTypes.ToListAsync()
            };
        }

        public async Task<CatalogType?> UpdateCatalogTypeAsync(int id, string type)
        {
            var item = await _dbContext.CatalogTypes.FirstOrDefaultAsync(c => c.Id == id);
            if (item != null)
            {
                item.Type = type;
                _dbContext.CatalogTypes.Update(item);
                await _dbContext.SaveChangesAsync();
            }

            return item;
        }
    }
}

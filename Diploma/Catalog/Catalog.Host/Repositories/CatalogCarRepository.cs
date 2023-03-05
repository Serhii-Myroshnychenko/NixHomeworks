using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;

namespace Catalog.Host.Repositories;

public class CatalogCarRepository : ICatalogCarRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogCarRepository> _logger;

    public CatalogCarRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogCarRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<CatalogCar?> AddCatalogCarAsync(string model, DateTime year, string transmission, decimal price, string description, string pictureFileName, double engineDisplacement, int quantity, int catalogManufacturerId)
    {
        _logger.LogInformation($"AddCatalogCarAsync input parameters: model = {model}, year = {year}, transmission = {transmission}, price = {price}, description = {description}, pictureFileName = {pictureFileName}, engineDisplacement = {engineDisplacement}, quantity = {quantity}, catalogManufacturerId = {catalogManufacturerId}");

        var catalogManufacturer = await _dbContext.CatalogManufacturers
            .FirstOrDefaultAsync(c => c.Id == catalogManufacturerId);

        if (catalogManufacturer != null)
        {
            var item = await _dbContext.AddAsync(new CatalogCar
            {
                Model = model,
                Year = year.ToUniversalTime(),
                Transmission = transmission,
                Price = price,
                Description = description,
                PictureFileName = pictureFileName,
                EngineDisplacement = engineDisplacement,
                Quantity = quantity,
                CatalogManufacturerId = catalogManufacturerId,
                CatalogManufacturer = catalogManufacturer
            });

            await _dbContext.SaveChangesAsync();

            _logger.LogInformation($"Added new CatalogCar with the following parameters: model = {model}, year = {year}, transmission = {transmission}, price = {price}, description = {description}, pictureFileName = {pictureFileName}, engineDisplacement = {engineDisplacement}, catalogManufacturerId = {catalogManufacturerId}");

            return item.Entity;
        }

        return default;
    }

    public async Task<CatalogCar?> DeleteCatalogCarAsync(int id)
    {
        var item = await _dbContext.CatalogCars
                .Include(c => c.CatalogManufacturer)
                .FirstOrDefaultAsync(c => c.Id == id);

        if (item != null)
        {
            _dbContext.CatalogCars.Remove(item);

            await _dbContext.SaveChangesAsync();

            _logger.LogInformation($"Deleted an existing CatalogCar with Id = {id}");
        }

        return item;
    }

    public async Task<CatalogCar?> GetByIdAsync(int id)
    {
        _logger.LogInformation($"GetByIdAsync method CatalogCar with the following parameters: id = {id}");

        return await _dbContext.CatalogCars
            .Include(c => c.CatalogManufacturer)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<GroupedEntities<CatalogCar>> GetByManufacturerAsync(int manufacturerId)
    {
        _logger.LogInformation($"GetByManufacturerAsync method CatalogCar with the following parameters: manufacturerId = {manufacturerId}");

        return new GroupedEntities<CatalogCar>()
        {
            Data = await _dbContext.CatalogCars
                .Where(cc => cc.CatalogManufacturerId == manufacturerId)
                .Include(cc => cc.CatalogManufacturer)
                .ToListAsync()
        };
    }

    public async Task<PaginatedItems<CatalogCar>> GetByPageAsync(int pageIndex, int pageSize, int? manufacturerFilter)
    {
        _logger.LogInformation($"GetByPageAsync method with the following input parameters: pageIndex = {pageIndex}, pageSize = {pageSize}, manufacturerFilter = {manufacturerFilter}");

        IQueryable<CatalogCar> query = _dbContext.CatalogCars;

        if (manufacturerFilter.HasValue)
        {
            query = query.Where(w => w.CatalogManufacturerId == manufacturerFilter.Value);
        }

        var totalItems = await query.LongCountAsync();

        var itemsOnPage = await query.OrderBy(c => c.Model)
           .Include(i => i.CatalogManufacturer)
           .Skip(pageSize * pageIndex)
           .Take(pageSize)
           .ToListAsync();

        _logger.LogInformation($"Result GetByPageAsync method with the following parameters: TotalCount = {totalItems}");

        return new PaginatedItems<CatalogCar>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<GroupedEntities<CatalogCar>> GetCatalogCarsAsync()
    {
        return new GroupedEntities<CatalogCar>()
        {
            Data = await _dbContext.CatalogCars.ToListAsync()
        };
    }

    public async Task<CatalogCar?> UpdateCatalogCarAsync(int id, string model, DateTime year, string transmission, decimal price, string description, string pictureFileName, double engineDisplacement, int quantity, int catalogManufacturerId)
    {
        _logger.LogInformation($"UpdateCatalogCarAsync method with the following input parameters: id = {id}, model = {model}, year = {year}, transmission = {transmission}, price = {price}, description = {description}, pictureFileName = {pictureFileName}, engineDisplacement = {engineDisplacement}, quantity = {quantity}, catalogManufacturerId = {catalogManufacturerId}");

        var item = await _dbContext.CatalogCars
            .Include(c => c.CatalogManufacturer)
            .FirstOrDefaultAsync(c => c.Id == id);

        var catalogManufacturer = await _dbContext.CatalogManufacturers
            .FirstOrDefaultAsync(c => c.Id == catalogManufacturerId);

        if (item != null && catalogManufacturer != null)
        {
            item.Model = model;
            item.Year = year.ToUniversalTime();
            item.Transmission = transmission;
            item.Price = price;
            item.Description = description;
            item.PictureFileName = pictureFileName;
            item.EngineDisplacement = engineDisplacement;
            item.Quantity = quantity;
            item.CatalogManufacturerId = catalogManufacturerId;
            item.CatalogManufacturer = catalogManufacturer;

            _dbContext.CatalogCars.Update(item);

            await _dbContext.SaveChangesAsync();

            _logger.LogInformation($"Updated an existing CatalogCar with the following parameters: model = {model}, year = {year}, transmission = {transmission}, price = {price}, description = {description}, pictureFileName = {pictureFileName}, engineDisplacement = {engineDisplacement}, catalogManufacturerId = {catalogManufacturerId}");
        }

        return item;
    }
}

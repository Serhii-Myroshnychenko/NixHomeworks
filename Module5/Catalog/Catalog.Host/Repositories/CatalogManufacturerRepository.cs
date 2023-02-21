using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;

namespace Catalog.Host.Repositories;

public class CatalogManufacturerRepository : ICatalogManufacturerRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogManufacturerRepository> _logger;

    public CatalogManufacturerRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogManufacturerRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<CatalogManufacturer> AddCatalogManufacturerAsync(string name, DateTime foundationYear, string headquartersLocation)
    {
        var item = await _dbContext.AddAsync(new CatalogManufacturer()
        {
            Name = name,
            FoundationYear = foundationYear,
            HeadquartersLocation = headquartersLocation
        });

        await _dbContext.SaveChangesAsync();

        _logger.LogInformation($"Added new CatalogManufacturer with the following parameters: name = {name}, foundationYear = {foundationYear}, headquartersLocation = {headquartersLocation}");

        return item.Entity;
    }

    public async Task<CatalogManufacturer?> DeleteCatalogManufacturerAsync(int id)
    {
        var manufacturer = await _dbContext.CatalogManufacturers
                .FirstOrDefaultAsync(c => c.Id == id);

        if (manufacturer != null)
        {
            _dbContext.CatalogManufacturers.Remove(manufacturer);

            await _dbContext.SaveChangesAsync();

            _logger.LogInformation($"Deleted an existing CatalogManufacturer with Id = {id}");
        }

        return manufacturer;
    }

    public async Task<GroupedEntities<CatalogManufacturer>> GetCatalogManufacturersAsync()
    {
        return new GroupedEntities<CatalogManufacturer>()
        {
            Data = await _dbContext.CatalogManufacturers.ToListAsync()
        };
    }

    public async Task<CatalogManufacturer?> UpdateCatalogManufacturerAsync(int id, string name, DateTime foundationYear, string headquartersLocation)
    {
        var item = await _dbContext.CatalogManufacturers
            .FirstOrDefaultAsync(c => c.Id == id);

        if (item != null)
        {
            item.Name = name;
            item.FoundationYear = foundationYear;
            item.HeadquartersLocation = headquartersLocation;
            item.CatalogCars = item.CatalogCars;

            _dbContext.CatalogManufacturers.Update(item);

            await _dbContext.SaveChangesAsync();

            _logger.LogInformation($"Updated an existing CatalogManufacturer with the following parameters: name = {name}, foundationYear = {foundationYear}, headquartersLocation = {headquartersLocation}");
        }

        return item;
    }
}

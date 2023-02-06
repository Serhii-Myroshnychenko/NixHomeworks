using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services
{
    public class CatalogBrandService : BaseDataService<ApplicationDbContext>, ICatalogBrandService
    {
        private readonly ICatalogBrandRepository _catalogBrandRepository;
        private readonly IMapper _mapper;

        public CatalogBrandService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ICatalogBrandRepository catalogBrandRepository,
            IMapper mapper)
            : base(dbContextWrapper, logger)
        {
            _catalogBrandRepository = catalogBrandRepository;
            _mapper = mapper;
        }

        public async Task<CatalogBrandDto> CreateCatalogBrandAsync(string brand)
        {
            return await ExecuteSafeAsync(async () =>
            {
                return _mapper.Map<CatalogBrandDto>(await _catalogBrandRepository.AddCatalogBrandAsync(brand));
            });
        }

        public async Task<CatalogBrandDto> DeleteCatalogBrandAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                return _mapper.Map<CatalogBrandDto>(await _catalogBrandRepository.DeleteCatalogBrandAsync(id));
            });
        }

        public async Task<GroupedEntitiesResponse<CatalogBrandDto>> GetCatalogBrandsAsync()
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _catalogBrandRepository.GetCatalogBrandsAsync();
                return new GroupedEntitiesResponse<CatalogBrandDto>()
                {
                    Data = result.Data.Select(s => _mapper.Map<CatalogBrandDto>(s)).ToList()
                };
            });
        }

        public async Task<CatalogBrandDto> UpdateCatalogBrandAsync(int id, string brand)
        {
            return await ExecuteSafeAsync(async () =>
            {
                return _mapper.Map<CatalogBrandDto>(await _catalogBrandRepository.UpdateCatalogBrandAsync(id, brand));
            });
        }
    }
}

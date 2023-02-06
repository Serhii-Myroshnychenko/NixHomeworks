using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services
{
    public class CatalogTypeService : BaseDataService<ApplicationDbContext>, ICatalogTypeService
    {
        private readonly ICatalogTypeRepository _catalogTypeRepository;
        private readonly IMapper _mapper;

        public CatalogTypeService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ICatalogTypeRepository catalogTypeRepository,
            IMapper mapper)
            : base(dbContextWrapper, logger)
        {
            _catalogTypeRepository = catalogTypeRepository;
            _mapper = mapper;
        }

        public async Task<CatalogTypeDto> CreateCatalogTypeAsync(string type)
        {
            return await ExecuteSafeAsync(async () =>
            {
                return _mapper.Map<CatalogTypeDto>(await _catalogTypeRepository.AddCatalogTypeAsync(type));
            });
        }

        public async Task<CatalogTypeDto> DeleteCatalogTypeAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                return _mapper.Map<CatalogTypeDto>(await _catalogTypeRepository.DeleteCatalogTypeAsync(id));
            });
        }

        public async Task<GroupedEntitiesResponse<CatalogTypeDto>> GetCatalogTypesAsync()
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _catalogTypeRepository.GetCatalogTypesAsync();
                return new GroupedEntitiesResponse<CatalogTypeDto>()
                {
                    Data = result.Data.Select(s => _mapper.Map<CatalogTypeDto>(s)).ToList()
                };
            });
        }

        public async Task<CatalogTypeDto> UpdateCatalogTypeAsync(int id, string type)
        {
            return await ExecuteSafeAsync(async () =>
            {
                return _mapper.Map<CatalogTypeDto>(await _catalogTypeRepository.UpdateCatalogTypeAsync(id, type));
            });
        }
    }
}
using Infrastructure.Models.Dtos;
using Infrastructure.Models.Responses;
using Order.Host.Data;
using Order.Host.Repositories.Interfaces;
using Order.Host.Services.Interfaces;

namespace Order.Host.Services
{
    public class ProductService : BaseDataService<ApplicationDbContext>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<BaseDataService<ApplicationDbContext>> _logger;

        public ProductService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            IProductRepository productRepository,
            IMapper mapper)
            : base(dbContextWrapper, logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ProductDto> CreateProductAsync(int id, string model, decimal price)
        {
            _logger.LogInformation($"CreateProductAsync method with the following parameters: id = {id}, model = {model}, price = {price}");
            return await ExecuteSafeAsync(async () =>
            {
                return _mapper.Map<ProductDto>(await _productRepository.AddProductAsync(id, model, price));
            });
        }

        public async Task<ProductDto> DeleteProductAsync(int id)
        {
            _logger.LogInformation($"DeleteProductAsync method with the following parameters: id = {id}");
            return await ExecuteSafeAsync(async () =>
            {
                return _mapper.Map<ProductDto>(await _productRepository.DeleteProductAsync(id));
            });
        }

        public async Task<GroupedEntitiesResponse<ProductDto>> GetProductsAsync()
        {
            _logger.LogInformation($"GetProductsAsync executed");
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _productRepository.GetProductsAsync();
                return new GroupedEntitiesResponse<ProductDto>()
                {
                    Data = result.Data.Select(s => _mapper.Map<ProductDto>(s)).ToList()
                };
            });
        }

        public async Task<ProductDto> UpdateProductAsync(int id, string model, decimal price)
        {
            _logger.LogInformation($"UpdateProductAsync method with the following parameters: id = {id}, model = {model}, price = {price}");
            return await ExecuteSafeAsync(async () =>
            {
                return _mapper.Map<ProductDto>(await _productRepository.UpdateProductAsync(id, model, price));
            });
        }
    }
}

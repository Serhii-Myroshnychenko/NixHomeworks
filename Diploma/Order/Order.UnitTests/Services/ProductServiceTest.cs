using System.Threading;
using Infrastructure.Models;
using Infrastructure.Models.Dtos;
using Infrastructure.Services;
using Order.Host.Data.Entities;

namespace Order.UnitTests.Services
{
    public class ProductServiceTest
    {
        private readonly IProductService _productService;
        private readonly Mock<IProductRepository> _productRepository;
        private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
        private readonly Mock<ILogger<BaseDataService<ApplicationDbContext>>> _logger;
        private readonly Mock<IMapper> _mapper;

        private readonly Product _testProduct = new ()
        {
            Id = 1,
            Model = "Test",
            Price = 0
        };

        private readonly ProductDto _testProductDto = new ()
        {
            Id = 1,
            Model = "Test",
            Price = 0
        };

        public ProductServiceTest()
        {
            _productRepository = new Mock<IProductRepository>();
            _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();

            _logger = new Mock<ILogger<BaseDataService<ApplicationDbContext>>>();
            _mapper = new Mock<IMapper>();

            var dbContextTransaction = new Mock<IDbContextTransaction>();
            _dbContextWrapper.Setup(s => s.BeginTransactionAsync(CancellationToken.None)).ReturnsAsync(dbContextTransaction.Object);

            _productService = new ProductService(_dbContextWrapper.Object, _logger.Object, _productRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task AddProductAsync_Success()
        {
            // arrange
            _productRepository.Setup(s => s.AddProductAsync(
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<decimal>())).ReturnsAsync(_testProduct);

            _mapper.Setup(s => s.Map<ProductDto>(
               It.Is<Product>(i => i.Equals(_testProduct)))).Returns(_testProductDto);

            // act
            var result = await _productService.CreateProductAsync(_testProduct.Id, _testProduct.Model, _testProduct.Price);

            // assert
            result.Should().Be(_testProductDto);
        }

        [Fact]
        public async Task AddProductAsync_Failed()
        {
            // arrange
            Product? testResult = null;

            _productRepository.Setup(s => s.AddProductAsync(
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<decimal>())).ReturnsAsync(testResult);

            // act
            var result = await _productService.CreateProductAsync(_testProduct.Id, _testProduct.Model, _testProduct.Price);

            // assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task UpdateProductAsync_Success()
        {
            // arrange
            _productRepository.Setup(s => s.UpdateProductAsync(
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<decimal>())).ReturnsAsync(_testProduct);

            _mapper.Setup(s => s.Map<ProductDto>(
               It.Is<Product>(i => i.Equals(_testProduct)))).Returns(_testProductDto);

            // act
            var result = await _productService.UpdateProductAsync(_testProduct.Id, _testProduct.Model, _testProduct.Price);

            // assert
            result.Should().Be(_testProductDto);
        }

        [Fact]
        public async Task UpdateProductAsync_Failed()
        {
            // arrange
            Product? testResult = null;

            _productRepository.Setup(s => s.UpdateProductAsync(
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<decimal>())).ReturnsAsync(testResult);

            // act
            var result = await _productService.UpdateProductAsync(_testProduct.Id, _testProduct.Model, _testProduct.Price);

            // assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task DeleteProductAsync_Success()
        {
            // arrange
            _productRepository.Setup(s => s.DeleteProductAsync(
                It.IsAny<int>())).ReturnsAsync(_testProduct);

            _mapper.Setup(s => s.Map<ProductDto>(
               It.Is<Product>(i => i.Equals(_testProduct)))).Returns(_testProductDto);

            // act
            var result = await _productService.DeleteProductAsync(_testProduct.Id);

            // assert
            result.Should().Be(_testProductDto);
        }

        [Fact]
        public async Task DeleteProductAsync_Failed()
        {
            // arrange
            Product? testResult = null;

            _productRepository.Setup(s => s.DeleteProductAsync(
                It.IsAny<int>())).ReturnsAsync(testResult);

            // act
            var result = await _productService.DeleteProductAsync(_testProduct.Id);

            // assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task GetProductsAsync_Success()
        {
            // arrange
            GroupedEntities<Product> testProducts = new ()
            {
                Data = new List<Product>()
                {
                    new Product()
                    {
                        Model = "Test",
                        Price = 0
                    },
                    new Product()
                    {
                        Model = "Test",
                        Price = 0
                    }
                }
            };

            _productRepository.Setup(s => s.GetProductsAsync()).ReturnsAsync(testProducts);
            _mapper.Setup(m => m.Map<ProductDto>(It.IsAny<Product>())).Returns(_testProductDto);

            // act
            var result = await _productService.GetProductsAsync();

            // assert
            result.Data.Should().NotBeNull();
            result.Data.Should().HaveCount(2);
        }

        [Fact]
        public async Task GetProductsAsync_Failed()
        {
            // arrange
            _productRepository.Setup(s => s.GetProductsAsync()).ReturnsAsync((Func<GroupedEntities<Product>>)null!);

            // act
            var result = await _productService.GetProductsAsync();

            // assert
            result.Should().BeNull();
        }
    }
}

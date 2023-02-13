using System.Threading;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;

namespace Catalog.UnitTests.Services
{
    public class CatalogBrandServiceTest
    {
        private readonly ICatalogBrandService _catalogService;
        private readonly Mock<ICatalogBrandRepository> _catalogBrandRepository;
        private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
        private readonly Mock<ILogger<CatalogService>> _logger;
        private readonly Mock<IMapper> _mapper;

        private readonly CatalogBrand _testBrand = new ()
        {
            Id = 1,
            Brand = "Test"
        };

        private readonly CatalogBrandDto _testCatalogBrandDto = new ()
        {
            Id = 1,
            Brand = "Test"
        };

        public CatalogBrandServiceTest()
        {
            _catalogBrandRepository = new Mock<ICatalogBrandRepository>();
            _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
            _logger = new Mock<ILogger<CatalogService>>();
            _mapper = new Mock<IMapper>();

            var dbContextTransaction = new Mock<IDbContextTransaction>();
            _dbContextWrapper.Setup(s => s.BeginTransactionAsync(CancellationToken.None)).ReturnsAsync(dbContextTransaction.Object);

            _catalogService = new CatalogBrandService(_dbContextWrapper.Object, _logger.Object, _catalogBrandRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task AddCatalogBrandAsync_Success()
        {
            // arrange
            _catalogBrandRepository.Setup(s => s.AddCatalogBrandAsync(
                It.IsAny<string>())).ReturnsAsync(_testBrand);

            _mapper.Setup(s => s.Map<CatalogBrandDto>(
               It.Is<CatalogBrand>(i => i.Equals(_testBrand)))).Returns(_testCatalogBrandDto);

            // act
            var result = await _catalogService.CreateCatalogBrandAsync(_testBrand.Brand);

            // assert
            result.Should().Be(_testCatalogBrandDto);
        }

        [Fact]
        public async Task AddCatalogBrandAsync_Failed()
        {
            // arrange
            CatalogBrand? testResult = null;

            _catalogBrandRepository.Setup(s => s.AddCatalogBrandAsync(
                It.IsAny<string>())).ReturnsAsync(testResult);

            // act
            var result = await _catalogService.CreateCatalogBrandAsync(_testBrand.Brand);

            // assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task UpdateCatalogBrandAsync_Success()
        {
            // arrange
            _catalogBrandRepository.Setup(s => s.UpdateCatalogBrandAsync(
                It.IsAny<int>(),
                It.IsAny<string>())).ReturnsAsync(_testBrand);

            _mapper.Setup(s => s.Map<CatalogBrandDto>(
               It.Is<CatalogBrand>(i => i.Equals(_testBrand)))).Returns(_testCatalogBrandDto);

            // act
            var result = await _catalogService.UpdateCatalogBrandAsync(_testBrand.Id, _testBrand.Brand);

            // assert
            result.Should().Be(_testCatalogBrandDto);
        }

        [Fact]
        public async Task UpdateCatalogBrandAsync_Failed()
        {
            // arrange
            CatalogBrand? testResult = null;

            _catalogBrandRepository.Setup(s => s.UpdateCatalogBrandAsync(
                It.IsAny<int>(),
                It.IsAny<string>())).ReturnsAsync(testResult);

            // act
            var result = await _catalogService.UpdateCatalogBrandAsync(_testBrand.Id, _testBrand.Brand);

            // assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task DeleteCatalogBrandAsync_Success()
        {
            // arrange
            _catalogBrandRepository.Setup(s => s.DeleteCatalogBrandAsync(
                It.IsAny<int>())).ReturnsAsync(_testBrand);

            _mapper.Setup(s => s.Map<CatalogBrandDto>(
               It.Is<CatalogBrand>(i => i.Equals(_testBrand)))).Returns(_testCatalogBrandDto);

            // act
            var result = await _catalogService.DeleteCatalogBrandAsync(_testBrand.Id);

            // assert
            result.Should().Be(_testCatalogBrandDto);
        }

        [Fact]
        public async Task DeleteCatalogBrandAsync_Failed()
        {
            // arrange
            CatalogBrand? testResult = null;

            _catalogBrandRepository.Setup(s => s.DeleteCatalogBrandAsync(
                It.IsAny<int>())).ReturnsAsync(testResult);

            // act
            var result = await _catalogService.DeleteCatalogBrandAsync(_testBrand.Id);

            // assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task GetCatalogBrandsAsync_Success()
        {
            // arrange
            GroupedEntities<CatalogBrand> testGroupedBrands = new ()
            {
                Data = new List<CatalogBrand>()
                {
                    new CatalogBrand()
                    {
                        Id = 1,
                        Brand = "Test"
                    },
                    new CatalogBrand()
                    {
                        Id = 1,
                        Brand = "Test"
                    }
                }
            };

            _catalogBrandRepository.Setup(s => s.GetCatalogBrandsAsync()).ReturnsAsync(testGroupedBrands);
            _mapper.Setup(m => m.Map<CatalogBrandDto>(It.IsAny<CatalogBrand>())).Returns(new CatalogBrandDto() { Id = 1, Brand = "Test" });

            // act
            var result = await _catalogService.GetCatalogBrandsAsync();

            // assert
            result.Data.Should().NotBeNull();
            result.Data.Should().HaveCount(2);
        }

        [Fact]
        public async Task GetCatalogBrandsAsync_Failed()
        {
            // arrange
            _catalogBrandRepository.Setup(s => s.GetCatalogBrandsAsync()).ReturnsAsync((Func<GroupedEntities<CatalogBrand>>)null!);

            // act
            var result = await _catalogService.GetCatalogBrandsAsync();

            // assert
            result.Should().BeNull();
        }
    }
}

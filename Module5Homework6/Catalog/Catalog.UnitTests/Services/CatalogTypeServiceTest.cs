using System.Threading;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;

namespace Catalog.UnitTests.Services;
public class CatalogTypeServiceTest
{
    private readonly ICatalogTypeService _catalogService;
    private readonly Mock<ICatalogTypeRepository> _catalogTypeRepository;
    private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
    private readonly Mock<ILogger<CatalogService>> _logger;
    private readonly Mock<IMapper> _mapper;

    private readonly CatalogType _testType = new ()
    {
        Id = 1,
        Type = "Test"
    };

    private readonly CatalogTypeDto _testCatalogTypeDto = new ()
    {
        Id = 1,
        Type = "Test"
    };

    public CatalogTypeServiceTest()
    {
        _catalogTypeRepository = new Mock<ICatalogTypeRepository>();
        _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
        _logger = new Mock<ILogger<CatalogService>>();
        _mapper = new Mock<IMapper>();
        var dbContextTransaction = new Mock<IDbContextTransaction>();
        _dbContextWrapper.Setup(s => s.BeginTransactionAsync(CancellationToken.None)).ReturnsAsync(dbContextTransaction.Object);
        _catalogService = new CatalogTypeService(_dbContextWrapper.Object, _logger.Object, _catalogTypeRepository.Object, _mapper.Object);
    }

    [Fact]
    public async Task AddCatalogTypeAsync_Success()
    {
        // arrange
        _catalogTypeRepository.Setup(s => s.AddCatalogTypeAsync(
            It.IsAny<string>())).ReturnsAsync(_testType);

        _mapper.Setup(s => s.Map<CatalogTypeDto>(
           It.Is<CatalogType>(i => i.Equals(_testType)))).Returns(_testCatalogTypeDto);

        // act
        var result = await _catalogService.CreateCatalogTypeAsync(_testType.Type);

        // assert
        result.Should().Be(_testCatalogTypeDto);
    }

    [Fact]
    public async Task AddCatalogTypeAsync_Failed()
    {
        // arrange
        CatalogType? testResult = null;

        _catalogTypeRepository.Setup(s => s.AddCatalogTypeAsync(
            It.IsAny<string>())).ReturnsAsync(testResult);

        // act
        var result = await _catalogService.CreateCatalogTypeAsync(_testType.Type);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task UpdateCatalogTypeAsync_Success()
    {
        // arrange
        _catalogTypeRepository.Setup(s => s.UpdateCatalogTypeAsync(
            It.IsAny<int>(),
            It.IsAny<string>())).ReturnsAsync(_testType);

        _mapper.Setup(s => s.Map<CatalogTypeDto>(
           It.Is<CatalogType>(i => i.Equals(_testType)))).Returns(_testCatalogTypeDto);

        // act
        var result = await _catalogService.UpdateCatalogTypeAsync(_testType.Id, _testType.Type);

        // assert
        result.Should().Be(_testCatalogTypeDto);
    }

    [Fact]
    public async Task UpdateCatalogTypeAsync_Failed()
    {
        // arrange
        CatalogType? testResult = null;

        _catalogTypeRepository.Setup(s => s.UpdateCatalogTypeAsync(
            It.IsAny<int>(),
            It.IsAny<string>())).ReturnsAsync(testResult);

        // act
        var result = await _catalogService.UpdateCatalogTypeAsync(_testType.Id, _testType.Type);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task DeleteCatalogTypeAsync_Success()
    {
        // arrange
        _catalogTypeRepository.Setup(s => s.DeleteCatalogTypeAsync(
            It.IsAny<int>())).ReturnsAsync(_testType);

        _mapper.Setup(s => s.Map<CatalogTypeDto>(
           It.Is<CatalogType>(i => i.Equals(_testType)))).Returns(_testCatalogTypeDto);

        // act
        var result = await _catalogService.DeleteCatalogTypeAsync(_testType.Id);

        // assert
        result.Should().Be(_testCatalogTypeDto);
    }

    [Fact]
    public async Task DeleteCatalogTypeAsync_Failed()
    {
        // arrange
        CatalogType? testResult = null;

        _catalogTypeRepository.Setup(s => s.DeleteCatalogTypeAsync(
            It.IsAny<int>())).ReturnsAsync(testResult);

        // act
        var result = await _catalogService.DeleteCatalogTypeAsync(_testType.Id);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task GetCatalogTypesAsync_Success()
    {
        // arrange
        GroupedEntities<CatalogType> testGroupedTypes = new ()
        {
            Data = new List<CatalogType>()
            {
                new CatalogType()
                {
                    Id = 1,
                    Type = "Test"
                },
                new CatalogType()
                {
                    Id = 1,
                    Type = "Test"
                }
            }
        };

        _catalogTypeRepository.Setup(s => s.GetCatalogTypesAsync()).ReturnsAsync(testGroupedTypes);
        _mapper.Setup(m => m.Map<CatalogTypeDto>(It.IsAny<CatalogType>())).Returns(new CatalogTypeDto() { Id = 1, Type = "Test" });

        // act
        var result = await _catalogService.GetCatalogTypesAsync();

        // assert
        result.Data.Should().NotBeNull();
        result.Data.Should().HaveCount(2);
    }

    [Fact]
    public async Task GetCatalogTypesAsync_Failed()
    {
        // arrange
        _catalogTypeRepository.Setup(s => s.GetCatalogTypesAsync()).ReturnsAsync((Func<GroupedEntities<CatalogType>>)null!);

        // act
        var result = await _catalogService.GetCatalogTypesAsync();

        // assert
        result.Should().BeNull();
    }
}

using System.Threading;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;

namespace Catalog.UnitTests.Services;

public class CatalogItemServiceTest
{
    private readonly ICatalogItemService _catalogService;
    private readonly Mock<ICatalogItemRepository> _catalogItemRepository;
    private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
    private readonly Mock<ILogger<CatalogService>> _logger;
    private readonly Mock<IMapper> _mapper;

    private readonly CatalogItem _testItem = new ()
    {
        Id = 1,
        Name = "Name",
        Description = "Description",
        Price = 1000,
        AvailableStock = 100,
        CatalogBrandId = 1,
        CatalogTypeId = 1,
        PictureFileName = "1.png"
    };

    private readonly CatalogItemDto _testCatalogItemDto = new ()
    {
        Id = 1,
        Name = "Name",
        Description = "Description",
        Price = 1000,
        AvailableStock = 100,
        CatalogBrand = new () { Brand = "Test", Id = 1 },
        CatalogType = new () { Type = "Test", Id = 1 },
        PictureUrl = "1.png"
    };

    public CatalogItemServiceTest()
    {
        _catalogItemRepository = new Mock<ICatalogItemRepository>();
        _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
        _logger = new Mock<ILogger<CatalogService>>();
        _mapper = new Mock<IMapper>();

        var dbContextTransaction = new Mock<IDbContextTransaction>();
        _dbContextWrapper.Setup(s => s.BeginTransactionAsync(CancellationToken.None)).ReturnsAsync(dbContextTransaction.Object);

        _catalogService = new CatalogItemService(_dbContextWrapper.Object, _logger.Object, _catalogItemRepository.Object, _mapper.Object);
    }

    [Fact]
    public async Task AddCatalogItemAsync_Success()
    {
        // arrange
        _catalogItemRepository.Setup(s => s.AddCatalogItemAsync(
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<decimal>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<string>())).ReturnsAsync(_testItem);

        _mapper.Setup(s => s.Map<CatalogItemDto>(
           It.Is<CatalogItem>(i => i.Equals(_testItem)))).Returns(_testCatalogItemDto);

        // act
        var result = await _catalogService.AddCatalogItemAsync(_testItem.Name, _testItem.Description, _testItem.Price, _testItem.AvailableStock, _testItem.CatalogBrandId, _testItem.CatalogTypeId, _testItem.PictureFileName);

        // assert
        result.Should().Be(_testCatalogItemDto);
    }

    [Fact]
    public async Task AddCatalogItemAsync_Failed()
    {
        // arrange
        CatalogItem? testResult = null;

        _catalogItemRepository.Setup(s => s.AddCatalogItemAsync(
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<decimal>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<string>())).ReturnsAsync(testResult);

        // act
        var result = await _catalogService.AddCatalogItemAsync(_testItem.Name, _testItem.Description, _testItem.Price, _testItem.AvailableStock, _testItem.CatalogBrandId, _testItem.CatalogTypeId, _testItem.PictureFileName);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task UpdateCatalogItemAsync_Success()
    {
        // arrange
        _catalogItemRepository.Setup(s => s.UpdateCatalogItemAsync(
            It.IsAny<int>(),
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<decimal>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<string>())).ReturnsAsync(_testItem);

        _mapper.Setup(s => s.Map<CatalogItemDto>(
           It.Is<CatalogItem>(i => i.Equals(_testItem)))).Returns(_testCatalogItemDto);

        // act
        var result = await _catalogService.UpdateCatalogItemAsync(_testItem.Id, _testItem.Name, _testItem.Description, _testItem.Price, _testItem.AvailableStock, _testItem.CatalogBrandId, _testItem.CatalogTypeId, _testItem.PictureFileName);

        // assert
        result.Should().Be(_testCatalogItemDto);
    }

    [Fact]
    public async Task UpdateCatalogItemAsync_Failed()
    {
        // arrange
        CatalogItem? testResult = null;

        _catalogItemRepository.Setup(s => s.UpdateCatalogItemAsync(
            It.IsAny<int>(),
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<decimal>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<string>())).ReturnsAsync(testResult);

        // act
        var result = await _catalogService.UpdateCatalogItemAsync(_testItem.Id, _testItem.Name, _testItem.Description, _testItem.Price, _testItem.AvailableStock, _testItem.CatalogBrandId, _testItem.CatalogTypeId, _testItem.PictureFileName);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task DeleteCatalogItemAsync_Success()
    {
        // arrange
        _catalogItemRepository.Setup(s => s.DeleteCatalogItemAsync(
            It.IsAny<int>())).ReturnsAsync(_testItem);

        _mapper.Setup(s => s.Map<CatalogItemDto>(
           It.Is<CatalogItem>(i => i.Equals(_testItem)))).Returns(_testCatalogItemDto);

        // act
        var result = await _catalogService.DeleteCatalogItemAsync(_testItem.Id);

        // assert
        result.Should().Be(_testCatalogItemDto);
    }

    [Fact]
    public async Task DeleteCatalogItemAsync_Failed()
    {
        // arrange
        CatalogItem? testResult = null;

        _catalogItemRepository.Setup(s => s.DeleteCatalogItemAsync(
            It.IsAny<int>())).ReturnsAsync(testResult);

        // act
        var result = await _catalogService.DeleteCatalogItemAsync(_testItem.Id);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task GetCatalogItemByIdAsync_Success()
    {
        // arrange
        _catalogItemRepository.Setup(s => s.GetByIdAsync(
            It.IsAny<int>())).ReturnsAsync(_testItem);

        _mapper.Setup(s => s.Map<CatalogItemDto>(
           It.Is<CatalogItem>(i => i.Equals(_testItem)))).Returns(_testCatalogItemDto);

        // act
        var result = await _catalogService.GetCatalogItemByIdAsync(_testItem.Id);

        // assert
        result.Should().Be(_testCatalogItemDto);
    }

    [Fact]
    public async Task GetCatalogItemByIdAsync_Failed()
    {
        // arrange
        CatalogItem? testResult = null;

        _catalogItemRepository.Setup(s => s.GetByIdAsync(
            It.IsAny<int>())).ReturnsAsync(testResult);

        // act
        var result = await _catalogService.GetCatalogItemByIdAsync(_testItem.Id);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task GetCatalogItemByBrandAsync_Success()
    {
        // arrange
        _catalogItemRepository.Setup(s => s.GetByBrandAsync(
            It.IsAny<int>())).ReturnsAsync(_testItem);

        _mapper.Setup(s => s.Map<CatalogItemDto>(
           It.Is<CatalogItem>(i => i.Equals(_testItem)))).Returns(_testCatalogItemDto);

        // act
        var result = await _catalogService.GetCatalogItemByBrandAsync(_testItem.Id);

        // assert
        result.Should().Be(_testCatalogItemDto);
    }

    [Fact]
    public async Task GetCatalogItemByBrandAsync_Failed()
    {
        // arrange
        CatalogItem? testResult = null;

        _catalogItemRepository.Setup(s => s.GetByBrandAsync(
            It.IsAny<int>())).ReturnsAsync(testResult);

        // act
        var result = await _catalogService.GetCatalogItemByBrandAsync(_testItem.Id);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task GetCatalogItemByTypeAsync_Success()
    {
        // arrange
        _catalogItemRepository.Setup(s => s.GetByTypeAsync(
            It.IsAny<int>())).ReturnsAsync(_testItem);

        _mapper.Setup(s => s.Map<CatalogItemDto>(
           It.Is<CatalogItem>(i => i.Equals(_testItem)))).Returns(_testCatalogItemDto);

        // act
        var result = await _catalogService.GetCatalogItemByTypeAsync(_testItem.Id);

        // assert
        result.Should().Be(_testCatalogItemDto);
    }

    [Fact]
    public async Task GetCatalogItemByTypeAsync_Failed()
    {
        // arrange
        CatalogItem? testResult = null;

        _catalogItemRepository.Setup(s => s.GetByTypeAsync(
            It.IsAny<int>())).ReturnsAsync(testResult);

        // act
        var result = await _catalogService.GetCatalogItemByTypeAsync(_testItem.Id);

        // assert
        result.Should().Be(testResult);
    }
}
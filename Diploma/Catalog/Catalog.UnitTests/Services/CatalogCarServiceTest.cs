using System.Threading;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;

namespace Catalog.UnitTests.Services;

public class CatalogCarServiceTest
{
    private readonly ICatalogCarService _catalogCarService;
    private readonly Mock<ICatalogCarRepository> _catalogCarRepository;
    private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
    private readonly Mock<ILogger<CatalogCarService>> _logger;
    private readonly Mock<IMapper> _mapper;

    private readonly CatalogCar _testCatalogCar = new ()
    {
        Id = 1,
        Model = "Test",
        Year = new DateTime(2002, 12, 12),
        Transmission = "Test",
        Price = 1000,
        Description = "TestTestTestTest",
        PictureFileName = "3.png",
        EngineDisplacement = 2.2,
        Quantity = 5,
        CatalogManufacturerId = 1
    };

    private readonly CatalogCarDto _testCatalogCarDto = new ()
    {
        Id = 1,
        Model = "Test",
        Year = new DateTime(2002, 12, 12),
        Transmission = "Test",
        Price = 1000,
        Description = "TestTestTestTest",
        PictureUrl = "3.png",
        EngineDisplacement = 2.2,
        Quantity = 5,
        CatalogManufacturer = new () { Id = 1, Name = "Test", FoundationYear = new DateTime(2002, 12, 12), HeadquartersLocation = "Test" }
    };

    public CatalogCarServiceTest()
    {
        _catalogCarRepository = new Mock<ICatalogCarRepository>();
        _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
        _logger = new Mock<ILogger<CatalogCarService>>();
        _mapper = new Mock<IMapper>();

        var dbContextTransaction = new Mock<IDbContextTransaction>();
        _dbContextWrapper.Setup(s => s.BeginTransactionAsync(CancellationToken.None)).ReturnsAsync(dbContextTransaction.Object);

        _catalogCarService = new CatalogCarService(_dbContextWrapper.Object, _logger.Object, _catalogCarRepository.Object, _mapper.Object);
    }

    [Fact]
    public async Task AddCatalogCarAsync_Success()
    {
        // arrange
        _catalogCarRepository.Setup(s => s.AddCatalogCarAsync(
            It.IsAny<string>(),
            It.IsAny<DateTime>(),
            It.IsAny<string>(),
            It.IsAny<decimal>(),
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<double>(),
            It.IsAny<int>(),
            It.IsAny<int>())).ReturnsAsync(_testCatalogCar);

        _mapper.Setup(s => s.Map<CatalogCarDto>(
           It.Is<CatalogCar>(i => i.Equals(_testCatalogCar)))).Returns(_testCatalogCarDto);

        // act
        var result = await _catalogCarService.AddCatalogCarAsync(_testCatalogCar.Model, _testCatalogCar.Year, _testCatalogCar.Transmission, _testCatalogCar.Price, _testCatalogCar.Description, _testCatalogCar.PictureFileName, _testCatalogCar.EngineDisplacement, _testCatalogCar.Quantity, _testCatalogCar.CatalogManufacturerId);

        // assert
        result.Should().Be(_testCatalogCarDto);
    }

    [Fact]
    public async Task AddCatalogCarAsync_Failed()
    {
        // arrange
        CatalogCar? testResult = null;

        _catalogCarRepository.Setup(s => s.AddCatalogCarAsync(
            It.IsAny<string>(),
            It.IsAny<DateTime>(),
            It.IsAny<string>(),
            It.IsAny<decimal>(),
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<double>(),
            It.IsAny<int>(),
            It.IsAny<int>())).ReturnsAsync(testResult);

        // act
        var result = await _catalogCarService.AddCatalogCarAsync(_testCatalogCar.Model, _testCatalogCar.Year, _testCatalogCar.Transmission, _testCatalogCar.Price, _testCatalogCar.Description, _testCatalogCar.PictureFileName, _testCatalogCar.EngineDisplacement, _testCatalogCar.Quantity, _testCatalogCar.CatalogManufacturerId);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task UpdateCatalogCarAsync_Success()
    {
        // arrange
        _catalogCarRepository.Setup(s => s.UpdateCatalogCarAsync(
            It.IsAny<int>(),
            It.IsAny<string>(),
            It.IsAny<DateTime>(),
            It.IsAny<string>(),
            It.IsAny<decimal>(),
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<double>(),
            It.IsAny<int>(),
            It.IsAny<int>())).ReturnsAsync(_testCatalogCar);

        _mapper.Setup(s => s.Map<CatalogCarDto>(
           It.Is<CatalogCar>(i => i.Equals(_testCatalogCar)))).Returns(_testCatalogCarDto);

        // act
        var result = await _catalogCarService.UpdateCatalogCarAsync(_testCatalogCar.Id, _testCatalogCar.Model, _testCatalogCar.Year, _testCatalogCar.Transmission, _testCatalogCar.Price, _testCatalogCar.Description, _testCatalogCar.PictureFileName, _testCatalogCar.EngineDisplacement, _testCatalogCar.Quantity, _testCatalogCar.CatalogManufacturerId);

        // assert
        result.Should().Be(_testCatalogCarDto);
    }

    [Fact]
    public async Task UpdateCatalogCarAsync_Failed()
    {
        // arrange
        CatalogCar? testResult = null;

        _catalogCarRepository.Setup(s => s.UpdateCatalogCarAsync(
            It.IsAny<int>(),
            It.IsAny<string>(),
            It.IsAny<DateTime>(),
            It.IsAny<string>(),
            It.IsAny<decimal>(),
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<double>(),
            It.IsAny<int>(),
            It.IsAny<int>())).ReturnsAsync(testResult);

        // act
        var result = await _catalogCarService.UpdateCatalogCarAsync(_testCatalogCar.Id, _testCatalogCar.Model, _testCatalogCar.Year, _testCatalogCar.Transmission, _testCatalogCar.Price, _testCatalogCar.Description, _testCatalogCar.PictureFileName, _testCatalogCar.EngineDisplacement, _testCatalogCar.Quantity, _testCatalogCar.CatalogManufacturerId);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task DeleteCatalogCarAsync_Success()
    {
        // arrange
        _catalogCarRepository.Setup(s => s.DeleteCatalogCarAsync(
            It.IsAny<int>())).ReturnsAsync(_testCatalogCar);

        _mapper.Setup(s => s.Map<CatalogCarDto>(
           It.Is<CatalogCar>(i => i.Equals(_testCatalogCar)))).Returns(_testCatalogCarDto);

        // act
        var result = await _catalogCarService.DeleteCatalogCarAsync(_testCatalogCar.Id);

        // assert
        result.Should().Be(_testCatalogCarDto);
    }

    [Fact]
    public async Task DeleteCatalogCarAsync_Failed()
    {
        // arrange
        CatalogCar? testResult = null;

        _catalogCarRepository.Setup(s => s.DeleteCatalogCarAsync(
            It.IsAny<int>())).ReturnsAsync(testResult);

        // act
        var result = await _catalogCarService.DeleteCatalogCarAsync(_testCatalogCar.Id);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task GetCatalogCarById_Success()
    {
        // arrange
        _catalogCarRepository.Setup(s => s.GetByIdAsync(
            It.IsAny<int>())).ReturnsAsync(_testCatalogCar);

        _mapper.Setup(s => s.Map<CatalogCarDto>(
           It.Is<CatalogCar>(i => i.Equals(_testCatalogCar)))).Returns(_testCatalogCarDto);

        // act
        var result = await _catalogCarService.GetCatalogCarByIdAsync(_testCatalogCar.Id);

        // assert
        result.Should().Be(_testCatalogCarDto);
    }

    [Fact]
    public async Task GetCatalogCarById_Failed()
    {
        // arrange
        CatalogCar? testResult = null;

        _catalogCarRepository.Setup(s => s.GetByIdAsync(
            It.IsAny<int>())).ReturnsAsync(testResult);

        // act
        var result = await _catalogCarService.GetCatalogCarByIdAsync(_testCatalogCar.Id);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task GetCatalogCarByManufacturerId_Success()
    {
        // arrange
        GroupedEntities<CatalogCar> testGroupedCars = new ()
        {
            Data = new List<CatalogCar>()
            {
                new CatalogCar()
                {
                    Id = 1,
                    Model = "Test",
                    Year = new DateTime(2002, 12, 12),
                    Transmission = "Test",
                    Price = 1000,
                    Description = "TestTestTestTest",
                    PictureFileName = "3.png",
                    EngineDisplacement = 2.2,
                    CatalogManufacturerId = 1
                }
            }
        };

        _catalogCarRepository.Setup(s => s.GetByManufacturerAsync(
            It.IsAny<int>())).ReturnsAsync(testGroupedCars);

        _mapper.Setup(s => s.Map<CatalogCarDto>(
           It.Is<CatalogCar>(i => i.Equals(_testCatalogCar)))).Returns(_testCatalogCarDto);

        // act
        var result = await _catalogCarService.GetCatalogCarByManufacturerAsync(_testCatalogCar.Id);

        // assert
        result.Data.Should().NotBeNull();
        result.Data.Should().HaveCount(1);
    }

    [Fact]
    public async Task GetCatalogCarByManufacturerId_Failed()
    {
        // arrange
        _catalogCarRepository.Setup(s => s.GetByManufacturerAsync(
            It.IsAny<int>())).ReturnsAsync((Func<GroupedEntities<CatalogCar>>)null!);

        // act
        var result = await _catalogCarService.GetCatalogCarByManufacturerAsync(_testCatalogCar.Id);

        // assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetCatalogCarsAsync_Success()
    {
        // arrange
        var testPageIndex = 0;
        var testPageSize = 4;
        var testTotalCount = 12;

        var pagingPaginatedItemsSuccess = new PaginatedItems<CatalogCar>()
        {
            Data = new List<CatalogCar>()
            {
                new CatalogCar()
                {
                    Id = 1,
                    Model = "Test",
                    Year = new DateTime(2002, 12, 12),
                    Transmission = "Test",
                    Price = 1000,
                    Description = "TestTestTestTest",
                    PictureFileName = "3.png",
                    EngineDisplacement = 2.2,
                    CatalogManufacturerId = 1
                },
            },
            TotalCount = testTotalCount,
        };

        _catalogCarRepository.Setup(s => s.GetByPageAsync(
            It.Is<int>(i => i == testPageIndex),
            It.Is<int>(i => i == testPageSize),
            It.IsAny<int?>())).ReturnsAsync(pagingPaginatedItemsSuccess);

        _mapper.Setup(s => s.Map<CatalogCarDto>(
            It.Is<CatalogCar>(i => i.Equals(_testCatalogCar)))).Returns(_testCatalogCarDto);

        // act
        var result = await _catalogCarService.GetCatalogCarsAsync(testPageSize, testPageIndex, null);

        // assert
        result.Should().NotBeNull();
        result?.Data.Should().NotBeNull();
        result?.Count.Should().Be(testTotalCount);
        result?.PageIndex.Should().Be(testPageIndex);
        result?.PageSize.Should().Be(testPageSize);
    }

    [Fact]
    public async Task GetCatalogCarsAsync_Failed()
    {
        // arrange
        var testPageIndex = 1000;
        var testPageSize = 10000;

        _catalogCarRepository.Setup(s => s.GetByPageAsync(
            It.Is<int>(i => i == testPageIndex),
            It.Is<int>(i => i == testPageSize),
            It.IsAny<int?>())).Returns((Func<PaginatedItemsResponse<CatalogCarDto>>)null!);

        // act
        var result = await _catalogCarService.GetCatalogCarsAsync(testPageSize, testPageIndex, null);

        // assert
        result.Should().BeNull();
    }
}
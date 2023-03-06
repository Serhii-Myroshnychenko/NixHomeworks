using System.Threading;
using Catalog.Host.Data.Entities;
using Infrastructure.Models;
using Infrastructure.Models.Dtos;

namespace Catalog.UnitTests.Services;

public class CatalogManufacturerServiceTest
{
    private readonly ICatalogManufacturerService _catalogManufacturerService;
    private readonly Mock<ICatalogManufacturerRepository> _catalogManufacturerRepository;
    private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
    private readonly Mock<ILogger<CatalogManufacturerService>> _logger;
    private readonly Mock<IMapper> _mapper;

    private readonly CatalogManufacturer _testCatalogManufacturer = new ()
    {
        Id = 1,
        Name = "Test",
        FoundationYear = new DateTime(2002, 12, 12),
        HeadquartersLocation = "Test"
    };

    private readonly CatalogManufacturerDto _testCatalogManufacturerDto = new ()
    {
        Id = 1,
        Name = "Test",
        FoundationYear = new DateTime(2002, 12, 12),
        HeadquartersLocation = "Test"
    };

    public CatalogManufacturerServiceTest()
    {
        _catalogManufacturerRepository = new Mock<ICatalogManufacturerRepository>();
        _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
        _logger = new Mock<ILogger<CatalogManufacturerService>>();
        _mapper = new Mock<IMapper>();

        var dbContextTransaction = new Mock<IDbContextTransaction>();
        _dbContextWrapper.Setup(s => s.BeginTransactionAsync(CancellationToken.None)).ReturnsAsync(dbContextTransaction.Object);

        _catalogManufacturerService = new CatalogManufacturerService(_dbContextWrapper.Object, _logger.Object, _catalogManufacturerRepository.Object, _mapper.Object);
    }

    [Fact]
    public async Task AddCatalogManufacturerAsync_Success()
    {
        // arrange
        _catalogManufacturerRepository.Setup(s => s.AddCatalogManufacturerAsync(
            It.IsAny<string>(),
            It.IsAny<DateTime>(),
            It.IsAny<string>())).ReturnsAsync(_testCatalogManufacturer);

        _mapper.Setup(s => s.Map<CatalogManufacturerDto>(
           It.Is<CatalogManufacturer>(i => i.Equals(_testCatalogManufacturer)))).Returns(_testCatalogManufacturerDto);

        // act
        var result = await _catalogManufacturerService.CreateCatalogManufacturerAsync(_testCatalogManufacturer.Name, _testCatalogManufacturer.FoundationYear, _testCatalogManufacturer.HeadquartersLocation);

        // assert
        result.Should().Be(_testCatalogManufacturerDto);
    }

    [Fact]
    public async Task AddCatalogCarAsync_Failed()
    {
        // arrange
        CatalogManufacturer? testResult = null;

        _catalogManufacturerRepository.Setup(s => s.AddCatalogManufacturerAsync(
            It.IsAny<string>(),
            It.IsAny<DateTime>(),
            It.IsAny<string>())).ReturnsAsync(_testCatalogManufacturer);

        // act
        var result = await _catalogManufacturerService.CreateCatalogManufacturerAsync(_testCatalogManufacturer.Name, _testCatalogManufacturer.FoundationYear, _testCatalogManufacturer.HeadquartersLocation);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task UpdateCatalogCarAsync_Success()
    {
        // arrange
        _catalogManufacturerRepository.Setup(s => s.UpdateCatalogManufacturerAsync(
            It.IsAny<int>(),
            It.IsAny<string>(),
            It.IsAny<DateTime>(),
            It.IsAny<string>())).ReturnsAsync(_testCatalogManufacturer);

        _mapper.Setup(s => s.Map<CatalogManufacturerDto>(
           It.Is<CatalogManufacturer>(i => i.Equals(_testCatalogManufacturer)))).Returns(_testCatalogManufacturerDto);

        // act
        var result = await _catalogManufacturerService.UpdateCatalogManufacturerAsync(_testCatalogManufacturer.Id, _testCatalogManufacturer.Name, _testCatalogManufacturer.FoundationYear, _testCatalogManufacturer.HeadquartersLocation);

        // assert
        result.Should().Be(_testCatalogManufacturerDto);
    }

    [Fact]
    public async Task UpdateCatalogCarAsync_Failed()
    {
        // arrange
        CatalogManufacturer? testResult = null;

        _catalogManufacturerRepository.Setup(s => s.UpdateCatalogManufacturerAsync(
            It.IsAny<int>(),
            It.IsAny<string>(),
            It.IsAny<DateTime>(),
            It.IsAny<string>())).ReturnsAsync(_testCatalogManufacturer);

        // act
        var result = await _catalogManufacturerService.UpdateCatalogManufacturerAsync(_testCatalogManufacturer.Id, _testCatalogManufacturer.Name, _testCatalogManufacturer.FoundationYear, _testCatalogManufacturer.HeadquartersLocation);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task DeleteCatalogCarAsync_Success()
    {
        // arrange
        _catalogManufacturerRepository.Setup(s => s.DeleteCatalogManufacturerAsync(
            It.IsAny<int>())).ReturnsAsync(_testCatalogManufacturer);

        _mapper.Setup(s => s.Map<CatalogManufacturerDto>(
           It.Is<CatalogManufacturer>(i => i.Equals(_testCatalogManufacturer)))).Returns(_testCatalogManufacturerDto);

        // act
        var result = await _catalogManufacturerService.DeleteCatalogManufacturerAsync(_testCatalogManufacturer.Id);

        // assert
        result.Should().Be(_testCatalogManufacturerDto);
    }

    [Fact]
    public async Task DeleteCatalogCarAsync_Failed()
    {
        // arrange
        CatalogManufacturer? testResult = null;

        _catalogManufacturerRepository.Setup(s => s.DeleteCatalogManufacturerAsync(
            It.IsAny<int>())).ReturnsAsync(_testCatalogManufacturer);

        // act
        var result = await _catalogManufacturerService.DeleteCatalogManufacturerAsync(_testCatalogManufacturer.Id);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task GetCatalogManufacturersAsync_Success()
    {
        // arrange
        GroupedEntities<CatalogManufacturer> testGroupedManufacturers = new ()
        {
            Data = new List<CatalogManufacturer>()
                {
                    new CatalogManufacturer()
                    {
                        Name = "Test",
                        FoundationYear = new DateTime(2002, 12, 12),
                        HeadquartersLocation = "Test",
                    },
                    new CatalogManufacturer()
                    {
                        Name = "Test",
                        FoundationYear = new DateTime(2002, 12, 12),
                        HeadquartersLocation = "Test",
                    }
                }
        };

        _catalogManufacturerRepository.Setup(s => s.GetCatalogManufacturersAsync()).ReturnsAsync(testGroupedManufacturers);
        _mapper.Setup(m => m.Map<CatalogManufacturerDto>(It.IsAny<CatalogManufacturer>())).Returns(_testCatalogManufacturerDto);

        // act
        var result = await _catalogManufacturerService.GetCatalogManufacturersAsync();

        // assert
        result.Data.Should().NotBeNull();
        result.Data.Should().HaveCount(2);
    }

    [Fact]
    public async Task GetCatalogManufacturersAsync_Failed()
    {
        // arrange
        _catalogManufacturerRepository.Setup(s => s.GetCatalogManufacturersAsync()).ReturnsAsync((Func<GroupedEntities<CatalogManufacturer>>)null!);

        // act
        var result = await _catalogManufacturerService.GetCatalogManufacturersAsync();

        // assert
        result.Should().BeNull();
    }
}

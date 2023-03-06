using System.Threading;
using Infrastructure.Models;
using Infrastructure.Models.Dtos;
using Infrastructure.Services;
using Order.Host.Data.Entities;

namespace Order.UnitTests.Services
{
    public class ClientServiceTest
    {
        private readonly IClientService _clientService;
        private readonly Mock<IClientRepository> _clientRepository;
        private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
        private readonly Mock<ILogger<BaseDataService<ApplicationDbContext>>> _logger;
        private readonly Mock<IMapper> _mapper;

        private readonly Client _testClient = new ()
        {
            Id = 1,
            FirstName = "Test",
            LastName = "Test"
        };

        private readonly ClientDto _testClientDto = new ()
        {
            Id = 1,
            FirstName = "Test",
            LastName = "Test"
        };

        public ClientServiceTest()
        {
            _clientRepository = new Mock<IClientRepository>();
            _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();

            _logger = new Mock<ILogger<BaseDataService<ApplicationDbContext>>>();
            _mapper = new Mock<IMapper>();

            var dbContextTransaction = new Mock<IDbContextTransaction>();
            _dbContextWrapper.Setup(s => s.BeginTransactionAsync(CancellationToken.None)).ReturnsAsync(dbContextTransaction.Object);

            _clientService = new ClientService(_dbContextWrapper.Object, _logger.Object, _clientRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task AddClientAsync_Success()
        {
            // arrange
            _clientRepository.Setup(s => s.AddClientAsync(
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<string>())).ReturnsAsync(_testClient);

            _mapper.Setup(s => s.Map<ClientDto>(
               It.Is<Client>(i => i.Equals(_testClient)))).Returns(_testClientDto);

            // act
            var result = await _clientService.CreateClientAsync(_testClient.Id, _testClient.FirstName, _testClient.LastName);

            // assert
            result.Should().Be(_testClientDto);
        }

        [Fact]
        public async Task AddClientAsync_Failed()
        {
            // arrange
            Client? testResult = null;

            _clientRepository.Setup(s => s.AddClientAsync(
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<string>())).ReturnsAsync(testResult);

            // act
            var result = await _clientService.CreateClientAsync(_testClient.Id, _testClient.FirstName, _testClient.LastName);

            // assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task UpdateClientAsync_Success()
        {
            // arrange
            _clientRepository.Setup(s => s.UpdateClientAsync(
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<string>())).ReturnsAsync(_testClient);

            _mapper.Setup(s => s.Map<ClientDto>(
               It.Is<Client>(i => i.Equals(_testClient)))).Returns(_testClientDto);

            // act
            var result = await _clientService.UpdateClientAsync(_testClient.Id, _testClient.FirstName, _testClient.LastName);

            // assert
            result.Should().Be(_testClientDto);
        }

        [Fact]
        public async Task UpdateClientAsync_Failed()
        {
            // arrange
            Client? testResult = null;

            _clientRepository.Setup(s => s.UpdateClientAsync(
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<string>())).ReturnsAsync(testResult);

            // act
            var result = await _clientService.UpdateClientAsync(_testClient.Id, _testClient.FirstName, _testClient.LastName);

            // assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task DeleteClientAsync_Success()
        {
            // arrange
            _clientRepository.Setup(s => s.DeleteClientAsync(
                It.IsAny<int>())).ReturnsAsync(_testClient);

            _mapper.Setup(s => s.Map<ClientDto>(
               It.Is<Client>(i => i.Equals(_testClient)))).Returns(_testClientDto);

            // act
            var result = await _clientService.DeleteClientAsync(_testClient.Id);

            // assert
            result.Should().Be(_testClientDto);
        }

        [Fact]
        public async Task DeleteClientAsync_Failed()
        {
            // arrange
            Client? testResult = null;

            _clientRepository.Setup(s => s.DeleteClientAsync(
                It.IsAny<int>())).ReturnsAsync(testResult);

            // act
            var result = await _clientService.DeleteClientAsync(_testClient.Id);

            // assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task GetClientsAsync_Success()
        {
            // arrange
            GroupedEntities<Client> testClients = new ()
            {
                Data = new List<Client>()
                {
                    new Client()
                    {
                        FirstName = "Test",
                        LastName = "Test"
                    },
                    new Client()
                    {
                        FirstName = "Test",
                        LastName = "Test"
                    }
                }
            };

            _clientRepository.Setup(s => s.GetClientsAsync()).ReturnsAsync(testClients);
            _mapper.Setup(m => m.Map<ClientDto>(It.IsAny<Client>())).Returns(_testClientDto);

            // act
            var result = await _clientService.GetClientsAsync();

            // assert
            result.Data.Should().NotBeNull();
            result.Data.Should().HaveCount(2);
        }

        [Fact]
        public async Task GetClientsAsync_Failed()
        {
            // arrange
            _clientRepository.Setup(s => s.GetClientsAsync()).ReturnsAsync((Func<GroupedEntities<Client>>)null!);

            // act
            var result = await _clientService.GetClientsAsync();

            // assert
            result.Should().BeNull();
        }
    }
}

using Infrastructure.Models.Dtos;
using Infrastructure.Models.Responses;
using Order.Host.Data;
using Order.Host.Repositories.Interfaces;
using Order.Host.Services.Interfaces;

namespace Order.Host.Services
{
    public class ClientService : BaseDataService<ApplicationDbContext>, IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<BaseDataService<ApplicationDbContext>> _logger;

        public ClientService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            IClientRepository clientRepository,
            IMapper mapper)
            : base(dbContextWrapper, logger)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ClientDto> CreateClientAsync(int id, string firstName, string lastName)
        {
            _logger.LogInformation($"CreateClientAsync method with the following parameters: id = {id}, firstName = {firstName}, lastName = {lastName}");
            return await ExecuteSafeAsync(async () =>
            {
                return _mapper.Map<ClientDto>(await _clientRepository.AddClientAsync(id, firstName, lastName));
            });
        }

        public async Task<ClientDto> DeleteClientAsync(int id)
        {
            _logger.LogInformation($"DeleteClientAsync method with the following parameters: id = {id}");
            return await ExecuteSafeAsync(async () =>
            {
                 return _mapper.Map<ClientDto>(await _clientRepository.DeleteClientAsync(id));
            });
        }

        public async Task<GroupedEntitiesResponse<ClientDto>> GetClientsAsync()
        {
            _logger.LogInformation($"GetClientsAsync method executed");
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _clientRepository.GetClientsAsync();
                return new GroupedEntitiesResponse<ClientDto>()
                {
                    Data = result.Data.Select(s => _mapper.Map<ClientDto>(s)).ToList()
                };
            });
        }

        public async Task<ClientDto> UpdateClientAsync(int id, string firstName, string lastName)
        {
            _logger.LogInformation($"UpdateClientAsync method with the following parameters: id = {id}, firstName = {firstName}, lastName = {lastName}");
            return await ExecuteSafeAsync(async () =>
            {
                return _mapper.Map<ClientDto>(await _clientRepository.UpdateClientAsync(id, firstName, lastName));
            });
        }
    }
}

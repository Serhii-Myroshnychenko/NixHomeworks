using Infrastructure.Models.Dtos;
using Infrastructure.Models.Responses;

namespace Order.Host.Services.Interfaces
{
    public interface IClientService
    {
        Task<GroupedEntitiesResponse<ClientDto>> GetClientsAsync();
        Task<ClientDto> CreateClientAsync(int id, string firstName, string lastName);
        Task<ClientDto> UpdateClientAsync(int id, string firstName, string lastName);
        Task<ClientDto> DeleteClientAsync(int id);
    }
}

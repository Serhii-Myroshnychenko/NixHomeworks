using Order.Host.Data;
using Order.Host.Data.Entities;

namespace Order.Host.Repositories.Interfaces
{
    public interface IClientRepository
    {
        Task<GroupedEntities<Client>> GetClientsAsync();
        Task<Client?> AddClientAsync(int id, string firstName, string lastName);
        Task<Client?> DeleteClientAsync(int id);
        Task<Client?> UpdateClientAsync(int id, string firstName, string lastName);
    }
}

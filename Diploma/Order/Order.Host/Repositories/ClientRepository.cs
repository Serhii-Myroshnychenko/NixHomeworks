using Infrastructure.Models;
using Order.Host.Data;
using Order.Host.Data.Entities;
using Order.Host.Repositories.Interfaces;

namespace Order.Host.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<ClientRepository> _logger;

        public ClientRepository(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<ClientRepository> logger)
        {
            _dbContext = dbContextWrapper.DbContext;
            _logger = logger;
        }

        public async Task<Client?> AddClientAsync(int id, string firstName, string lastName)
        {
            _logger.LogInformation($"AddClientAsync method with the following input parameters: id = {id}, firstName = {firstName}, lastName = {lastName}");

            var item = await _dbContext.AddAsync(new Client()
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
            });

            await _dbContext.SaveChangesAsync();

            _logger.LogInformation($"Added new Client with the following parameters: id = {id}, firstName = {firstName}, lastName = {lastName}");

            return item.Entity;
        }

        public async Task<Client?> DeleteClientAsync(int id)
        {
            _logger.LogInformation($"DeleteClientAsync method with the following input parameters: Id = {id}");

            var client = await _dbContext.Clients
                    .FirstOrDefaultAsync(c => c.Id == id);

            if (client != null)
            {
                _dbContext.Clients.Remove(client);

                await _dbContext.SaveChangesAsync();

                _logger.LogInformation($"Deleted an existing Client with Id = {id}");
            }

            return client;
        }

        public async Task<GroupedEntities<Client>> GetClientsAsync()
        {
            _logger.LogInformation($"GetClientsAsync method");

            return new GroupedEntities<Client>()
            {
                Data = await _dbContext.Clients.ToListAsync()
            };
        }

        public async Task<Client?> UpdateClientAsync(int id, string firstName, string lastName)
        {
            _logger.LogInformation($"UpdateClientAsync method with the following input parameters: id = {id}, firstName = {firstName}, lastName = {lastName}");

            var item = await _dbContext.Clients
                .FirstOrDefaultAsync(c => c.Id == id);

            if (item != null)
            {
                item.Id = id;
                item.FirstName = firstName;
                item.LastName = lastName;
                item.Purchases = item.Purchases;

                _dbContext.Clients.Update(item);

                await _dbContext.SaveChangesAsync();

                _logger.LogInformation($"Updated an existing Client with the following parameters: id = {id}, firstName = {firstName}, lastName = {lastName}");
            }

            return item;
        }
    }
}

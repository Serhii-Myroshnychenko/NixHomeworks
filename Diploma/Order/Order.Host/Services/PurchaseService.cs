using Infrastructure.Models;
using Infrastructure.Models.Dtos;
using Infrastructure.Models.Items;
using Infrastructure.Models.Responses;
using Order.Host.Configurations;
using Order.Host.Data;
using Order.Host.Repositories.Interfaces;
using Order.Host.Services.Interfaces;

namespace Order.Host.Services
{
    public class PurchaseService : BaseDataService<ApplicationDbContext>, IPurchaseSevice
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IInternalHttpClientService _httpClient;
        private readonly IProductRepository _productRepository;
        private readonly IOptions<OrderConfig> _settings;
        private readonly ILogger<BaseDataService<ApplicationDbContext>> _logger;
        private readonly IMapper _mapper;

        public PurchaseService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            IPurchaseRepository purchaseRepository,
            IClientRepository clientRepository,
            IProductRepository productRepository,
            IInternalHttpClientService httpClient,
            IOptions<OrderConfig> settings,
            IMapper mapper)
            : base(dbContextWrapper, logger)
        {
            _purchaseRepository = purchaseRepository;
            _clientRepository = clientRepository;
            _productRepository = productRepository;
            _mapper = mapper;
            _httpClient = httpClient;
            _settings = settings;
            _logger = logger;
        }

        public async Task<PurchaseDto> CreatePurchaseAsync(int productId, int clientId, int quantity)
        {
            _logger.LogInformation($"CreatePurchaseAsync method with the following parameters: productId = {productId}, clientId = {clientId}, quantity = {quantity}");
            return await ExecuteSafeAsync(async () =>
            {
                return _mapper.Map<PurchaseDto>(await _purchaseRepository.AddPurchaseAsync(productId, clientId, quantity));
            });
        }

        public async Task<PurchaseDto> DeletePurchaseAsync(int id)
        {
            _logger.LogInformation($"DeletePurchaseAsync method with the following parameters: id = {id}");
            return await ExecuteSafeAsync(async () =>
            {
                return _mapper.Map<PurchaseDto>(await _purchaseRepository.DeletePurchaseAsync(id));
            });
        }

        public async Task<GroupedEntitiesResponse<PurchaseDto>> GetPurchasesAsync()
        {
            _logger.LogInformation($"GetPurchasesAsync executed");
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _purchaseRepository.GetPurchasesAsync();
                return new GroupedEntitiesResponse<PurchaseDto>()
                {
                    Data = result.Data.Select(s => _mapper.Map<PurchaseDto>(s)).ToList()
                };
            });
        }

        public async Task<GroupedEntitiesResponse<CatalogBasketCar>> GetPurchasesByClientIdAsync(int clientId)
        {
            _logger.LogInformation($"GetPurchasesByClientIdAsync method with the following parameters: clientId = {clientId}");
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _purchaseRepository.GetPurchasesByClientIdAsync(clientId);
                return new GroupedEntitiesResponse<CatalogBasketCar>()
                {
                    Data = result.Data
                };
            });
        }

        public async Task<GroupedEntitiesResponse<PurchaseDto>> GetPurchasesByIdAsync(int clientId)
        {
            _logger.LogInformation($"GetPurchasesByIdAsync method with the following parameters: clientId = {clientId}");
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _purchaseRepository.GetPurchasesAsync();
                return new GroupedEntitiesResponse<PurchaseDto>()
                {
                    Data = result.Data.Where(c => c.ClientId == clientId).Select(s => _mapper.Map<PurchaseDto>(s)).ToList()
                };
            });
        }

        public async Task PlaceOrder(int id, string firtsName, string lastName)
        {
            _logger.LogInformation($"PlaceOrder method with the following parameters: id = {id}, firstName = {firtsName}, lastName = {lastName}");
            await ExecuteSafeAsync(async () =>
            {
                var basketElementsResponse = await _httpClient.SendAsync<GroupedEntities<CatalogBasketCar>, string>(
                                                    $"{_settings.Value.BasketUrl}/GetBasketById",
                                                    HttpMethod.Post,
                                                    id.ToString()).ConfigureAwait(false);

                var basketElements = basketElementsResponse.Data;
                var clients = await _clientRepository.GetClientsAsync().ConfigureAwait(false);
                var products = await _productRepository.GetProductsAsync().ConfigureAwait(false);
                var orders = await _purchaseRepository.GetPurchasesAsync().ConfigureAwait(false);

                var newProducts = basketElements
                       .Where(item => !products.Data.Any(p => p.Id == item.Id))
                       .Select(item => _productRepository.AddProductAsync(item.Id, item.Model, item.Price));

                await Task.WhenAll(newProducts).ConfigureAwait(false);

                if (!clients.Data.Any(c => c.Id == id))
                {
                    await _clientRepository.AddClientAsync(id, firtsName, lastName).ConfigureAwait(false);
                    _logger.LogInformation($"Added new client.");
                }

                var orderDictionary = orders.Data.ToDictionary(o => o.ProductId);

                foreach (var elem in basketElements)
                {
                    if (orderDictionary.TryGetValue(elem.Id, out var orderElem) && id == orderElem.ClientId)
                    {
                        await _purchaseRepository.UpdatePurchaseAsync(orderElem.Id, elem.Id, id, orderElem.Quantity + elem.Quantity);
                    }
                    else
                    {
                        await _purchaseRepository.AddPurchaseAsync(elem.Id, id, elem.Quantity);
                        _logger.LogInformation($"Added new purchase");
                    }
                }

                await _httpClient.SendAsync<object, object>(
                                       $"{_settings.Value.CatalogApi}/UpdateAllCars",
                                       HttpMethod.Post,
                                       id.ToString()).ConfigureAwait(false);
            });
        }

        public async Task<PurchaseDto> UpdatePurchaseAsync(int id, int productId, int clientId, int quantity)
        {
            _logger.LogInformation($"UpdatePurchaseAsync method with the following parameters: id = {id}, productId = {productId}, clientId = {clientId}, quantity = {quantity}");
            return await ExecuteSafeAsync(async () =>
            {
                return _mapper.Map<PurchaseDto>(await _purchaseRepository.UpdatePurchaseAsync(id, productId, clientId, quantity));
            });
        }
    }
}

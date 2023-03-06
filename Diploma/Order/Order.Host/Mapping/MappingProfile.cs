using Infrastructure.Models.Dtos;
using Order.Host.Data.Entities;

namespace Order.Host.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientDto>();
            CreateMap<Purchase, PurchaseDto>();
            CreateMap<Product, ProductDto>();
        }
    }
}

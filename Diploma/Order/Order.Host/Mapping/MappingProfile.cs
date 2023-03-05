using Order.Host.Data.Entities;
using Order.Host.Models.Dtos;

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

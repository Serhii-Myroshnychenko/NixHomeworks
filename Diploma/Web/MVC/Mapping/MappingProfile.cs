using AutoMapper;
using MVC.ViewModels;

namespace MVC.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CatalogCar, CatalogBasketCar>();
        }
    }
}

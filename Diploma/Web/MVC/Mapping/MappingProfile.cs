using AutoMapper;
using Infrastructure.Models.Items;
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

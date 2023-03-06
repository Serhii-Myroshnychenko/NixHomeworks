using Catalog.Host.Data.Entities;
using Infrastructure.Models.Dtos;

namespace Catalog.Host.Mapping;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CatalogCar, CatalogCarDto>()
            .ForMember("PictureUrl", opt
                => opt.MapFrom<CatalogItemPictureResolver, string>(c => c.PictureFileName));
        CreateMap<CatalogManufacturer, CatalogManufacturerDto>();
    }
}
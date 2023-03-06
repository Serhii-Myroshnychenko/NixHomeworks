using Catalog.Host.Configurations;
using Catalog.Host.Data.Entities;
using Infrastructure.Models.Dtos;

namespace Catalog.Host.Mapping;

public class CatalogItemPictureResolver : IMemberValueResolver<CatalogCar, CatalogCarDto, string, object>
{
    private readonly CatalogConfig _config;

    public CatalogItemPictureResolver(IOptionsSnapshot<CatalogConfig> config)
    {
        _config = config.Value;
    }

    public object Resolve(CatalogCar source, CatalogCarDto destination, string sourceMember, object destMember, ResolutionContext context)
    {
        return $"{_config.CdnHost}/{_config.ImgUrl}/{sourceMember}";
    }
}
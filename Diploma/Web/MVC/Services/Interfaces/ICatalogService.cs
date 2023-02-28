using MVC.ViewModels;

namespace MVC.Services.Interfaces;

public interface ICatalogService
{
    Task<Catalog> GetCatalogCars(int page, int take, int? manufacturer);
    Task<IEnumerable<SelectListItem>> GetCatalogManufacturers();
}

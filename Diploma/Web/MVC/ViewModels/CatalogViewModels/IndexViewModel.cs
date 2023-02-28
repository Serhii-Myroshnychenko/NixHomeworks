using MVC.ViewModels.Pagination;

namespace MVC.ViewModels.CatalogViewModels;

public class IndexViewModel
{
    public IEnumerable<CatalogCar> CatalogCars { get; set; }
    public IEnumerable<SelectListItem> CatalogManufacturers { get; set; }
    public int? ManufacturerFilterApplied { get; set; }
    public PaginationInfo PaginationInfo { get; set; }
}

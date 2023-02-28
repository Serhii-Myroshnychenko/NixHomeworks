namespace MVC.ViewModels
{
    public class CatalogManufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime FoundationYear { get; set; }
        public string HeadquartersLocation { get; set; } = null!;
    }
}

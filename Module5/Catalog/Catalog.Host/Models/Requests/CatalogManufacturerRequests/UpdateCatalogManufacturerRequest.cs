using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests.CatalogManufacturerRequests
{
    public class UpdateCatalogManufacturerRequest
    {
        [Required]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter valid Number")]
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string Name { get; set; } = null!;
        [Required]
        public DateTime FoundationYear { get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string HeadquartersLocation { get; set; } = null!;
    }
}

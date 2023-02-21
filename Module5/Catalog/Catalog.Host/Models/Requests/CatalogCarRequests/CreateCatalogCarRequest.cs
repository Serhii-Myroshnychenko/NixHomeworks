using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests.CatalogCarRequests
{
    public class CreateCatalogCarRequest
    {
        [Required]
        [StringLength(100, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string Model { get; set; } = null!;
        [Required]
        public DateTime Year { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string Transmission { get; set; } = null!;
        [Required]
        [Range(0.0, 100000000, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal Price { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 10)]
        public string Description { get; set; } = null!;
        [Required]
        public string PictureFileName { get; set; } = null!;
        [Required]
        [Range(0.2, 10.0, ErrorMessage = "The field {0} must be greater than {1}.")]
        public double EngineDisplacement { get; set; }
        [Required]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter valid Number")]
        public int CatalogManufacturerId { get; set; }
    }
}

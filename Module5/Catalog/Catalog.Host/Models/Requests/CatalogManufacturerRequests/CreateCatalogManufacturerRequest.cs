﻿using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests.CatalogManufacturerRequests
{
    public class CreateCatalogManufacturerRequest
    {
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

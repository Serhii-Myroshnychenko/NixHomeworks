using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models.Requests
{
    public class PlaceOrderRequest
    {
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
    }
}

using System.ComponentModel.DataAnnotations;

namespace Order.Host.Models.Requests
{
    public class PlaceOrderRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
    }
}

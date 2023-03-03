﻿using Basket.Host.Models.Items;
using System.ComponentModel.DataAnnotations;

namespace Basket.Host.Models.Requests
{
    public class AddToBasketRequest
    {
        [Required]
        public List<CatalogBasketCar> Data { get; set; } = null!;
    }
}

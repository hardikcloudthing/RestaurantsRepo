using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantModel
{
    public class Restaurant
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Locality { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Postcode { get; set; }
        public float Lat { get; set; }
        public float Lang { get; set; }
        
        public virtual List<Rating> Rating { get; set; }
        
        public virtual List<RestaurantCuisines> Restaurantcuisines { get; set; }
    }
}

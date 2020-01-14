using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantModel
{
    public class RestaurantDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Locality { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }
        public float Lat { get; set; }
        public float Lang { get; set; }
        public List<RatingDTO> Rating { get; set; }
        public List<RestaurantCuisinesDTO> Restaurantcuisines { get; set; }
    }
}

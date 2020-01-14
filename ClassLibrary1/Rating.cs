using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RestaurantModel
{
    public class Rating
    {
        public int Id { get; set; }
        [Required]
        public int Rate { get; set; }
        
        // Foreign Key
        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}

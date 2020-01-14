using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantModel
{
   public class RestaurantCuisines
    {
        public int Id { get; set; }
        //Foreign Key for Restaurant ID
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        //Foreign Key for CuisneType
        public int CuisinetypeId { get; set; }
        public virtual CuisineType Cuisinetype { get; set; }
    }
}

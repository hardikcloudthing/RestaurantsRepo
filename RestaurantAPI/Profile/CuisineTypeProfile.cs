using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace RestaurantModel
{
    public class CuisineTypeProfile :Profile
    {
        public CuisineTypeProfile()
        {
            CreateMap<CuisineType, CuisineTypeDTO>().ReverseMap();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace RestaurantModel
{
    public class RestaurantProfile : Profile
    {
       public RestaurantProfile()
        {
            CreateMap<Restaurant, RestaurantDTO>().ReverseMap();
        }
    }
}

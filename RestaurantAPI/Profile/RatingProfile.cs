using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace RestaurantModel
{
    public class RatingProfile : Profile
    {
        public RatingProfile()
        {
            CreateMap<Rating, RatingDTO>().ReverseMap();
        }
    }
}
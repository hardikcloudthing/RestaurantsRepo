using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
namespace RestaurantModel
{
    public class RestaurantCuisinesProfile : Profile
    {
        public RestaurantCuisinesProfile()
        {
            CreateMap<RestaurantCuisines, RestaurantCuisinesDTO>().ReverseMap()
                .ForMember(
                dest => dest.Cuisinetype,
                opt => opt.MapFrom(src => src.Cuisinetype));
                
        }
    }
}

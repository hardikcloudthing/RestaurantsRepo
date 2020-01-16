using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantModel;
using RestaurantRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Controllers
{
    public class RatingsController : ControllerBase
    {
        private readonly IRestaurantManager _restaurantManager;
        private readonly IMapper _mapper;
        public RatingsController(IRestaurantManager restaurantManager, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _restaurantManager = restaurantManager ?? throw new ArgumentNullException(nameof(restaurantManager));
        }
        //get ratings of any restaurant
        [HttpGet("api/restaurants/{id}/ratings")]
        public async Task<ActionResult<List<RatingDTO>>> GetRatings(int id)
        {
            var ratings = await _restaurantManager.GetRatings(id);
            if (ratings != null)
                return Ok(_mapper.Map<List<RatingDTO>>(ratings));
            else
                return NotFound();
        }

        //add new rating to any restaurant
        [HttpPost("api/restaurants/{id}/ratings")]
        public async Task<ActionResult<RatingDTO>> AddRating(int id,[FromBody]Rating rate)
        {
            var rating = await _restaurantManager.AddRating(id,rate);
            if (rating != null)
                return Ok(_mapper.Map<RatingDTO>(rating));
            else
                return NotFound();
        }
        //update existing rating of any restaurant with rating id
        [HttpPut("api/restaurants/{restaurantid}/ratings/{ratingid}")]
        public async Task<ActionResult<RatingDTO>> UpdateRating(int restaurantid, int ratingid, [FromBody]Rating rate)
        {
            var rating = await _restaurantManager.UpdateRating(restaurantid, ratingid, rate);
            if (rating != null)
                return Ok(_mapper.Map<RatingDTO>(rating));
            else
                return NotFound();
        }
        //delete any rating of any restaurant with rating id
        [HttpDelete("api/restaurants/{restaurantid}/ratings/{ratingid}")]
        public async Task<ActionResult<RatingDTO>> DeleteRating(int restaurantid, int ratingid)
        {
            var rating = await _restaurantManager.DeleteRating(restaurantid, ratingid);
            if (rating != null)
                return Ok(_mapper.Map<RatingDTO>(rating));
            else
                return NotFound();
        }
    }
}

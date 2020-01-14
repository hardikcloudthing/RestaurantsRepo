using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestaurantData;
using RestaurantModel;
using RestaurantRepo;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace RestaurantAPI.Controllers
{
    [ApiController]
   
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantManager _restaurantManager;
        private readonly IMapper _mapper;
        public RestaurantsController(IRestaurantManager restaurantManager,IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _restaurantManager = restaurantManager ?? throw new ArgumentNullException(nameof(restaurantManager));
        }

        [HttpGet("api/restaurants/{id}")]
        public async Task<ActionResult<RestaurantDTO>> GetRestaurants(int ID)
        {
            var restaurant = await _restaurantManager.Get(ID);
            if (restaurant != null)
                return Ok(_mapper.Map<RestaurantDTO>(restaurant));
            else
                return NotFound();
        }

        
        [HttpGet("api/restaurants")]
        public async Task<ActionResult<List<RestaurantDTO>>> GetAllRestaurants()
        {
            var restaurants = await _restaurantManager.GetAll();
            if (restaurants != null)
                return Ok(_mapper.Map<List<RestaurantDTO>>(restaurants));
            else
                return NotFound();
        }

        
        [HttpPost("api/restaurants")]
        public ActionResult<RestaurantDTO> AddRestaurant([FromBody]RestaurantDTO restaurantDTO)
        {
            var restaurant = _mapper.Map<Restaurant>(restaurantDTO);
            var restaurantToAdd = _restaurantManager.Add(restaurant);
            return Ok(_mapper.Map<RestaurantDTO>(restaurantToAdd));
        }

        [HttpPut("api/restaurants/{id}")]
        public async Task<ActionResult<RestaurantDTO>> UpdateRestaurant(int id,[FromBody]Restaurant restaurant)
        {
            var restaurantToUpdate = await _restaurantManager.Update(id,restaurant);
            return Ok(_mapper.Map<RestaurantDTO>(restaurantToUpdate));
        }   
        [HttpDelete("api/restaurants/{id}")]
        public async Task<ActionResult> DeleteRestaurant(int id)
        {
            var checkDelete =  await _restaurantManager.Delete(id);
            if (checkDelete != 0)
                return Ok();
            else
                return NotFound();
        }

        [HttpGet("api/getrestaurantbyquery/{searchQuery}")]
        public async Task<ActionResult<List<RestaurantDTO>>> GetRestaurantByQuery(string searchQuery)
        {
            var restaurant = await _restaurantManager.GetByQuery(searchQuery);
            if (restaurant != null)
                return Ok(_mapper.Map<List<RestaurantDTO>>(restaurant));
            else
                return NotFound();
        }
    }
}
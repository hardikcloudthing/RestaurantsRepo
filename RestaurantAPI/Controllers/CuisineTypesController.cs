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
    public class CuisineTypesController : ControllerBase
    {

        private readonly IRestaurantManager _restaurantManager;
        private readonly IMapper _mapper;
        public CuisineTypesController(IRestaurantManager restaurantManager, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _restaurantManager = restaurantManager ?? throw new ArgumentNullException(nameof(restaurantManager));
        }

        [HttpGet("api/cuisinetypes/{id}")]
        public async Task<ActionResult<CuisineTypeDTO>> GetCuisinetype(int id)
        {
            var cuisine = await _restaurantManager.GetCuisineType(id);
            if (cuisine != null)
                return Ok(_mapper.Map<CuisineTypeDTO>(cuisine));
            else
                return NotFound();
        }

        [HttpGet("api/cuisinetypes")]
        public async Task<ActionResult<List<CuisineTypeDTO>>> GetCuisineTypes()
        {
            var cuisines = await _restaurantManager.GetCuisineTypes();
            if (cuisines != null)
                return Ok(_mapper.Map<List<CuisineTypeDTO>>(cuisines));
            else
                return NotFound();
        }

        [HttpPost("api/cuisinetypes")]
        public async Task<ActionResult<CuisineTypeDTO>> AddCuisinetype([FromBody]CuisineType newcuisine)
        {
            var cuisine = await _restaurantManager.AddCuisineType(newcuisine);
            if (cuisine != null)
                return Ok(_mapper.Map<CuisineTypeDTO>(cuisine));
            else
                return NotFound();
        }

        [HttpDelete("api/cuisinetypes/{id}")]
        public async Task<ActionResult<CuisineTypeDTO>> DeleteCuisinetype(int id)
        {
            var cuisine = await _restaurantManager.DeleteCuisineType(id);
            if (cuisine != null)
                return Ok(_mapper.Map<CuisineTypeDTO>(cuisine));
            else
                return NotFound();
        }
    }
}

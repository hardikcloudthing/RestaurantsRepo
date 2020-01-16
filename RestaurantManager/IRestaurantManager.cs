using RestaurantModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantRepo
{
    public interface IRestaurantManager
    {
        Task<Restaurant> Add(Restaurant restaurant);
        Task<Restaurant> Update(int id, Restaurant newRestaurant);
        Task<int> Delete(int id);
        Task<Restaurant> Get(int id);
        Task<List<Restaurant>> GetAll();
        Task<List<Restaurant>> GetByQuery(string searchQuery);
        Task<CuisineType> GetCuisineType(int id);
        Task<List<CuisineType>> GetCuisineTypes();
        Task<List<Rating>> GetRatings(int id);
        Task<Rating> AddRating(int id, Rating rate);
        Task<Rating> UpdateRating(int restaurantid, int ratingid, Rating rating);
        Task<Rating> DeleteRating(int restaurantid, int ratingid);
        Task<CuisineType> AddCuisineType(CuisineType newcuisine);
        Task<CuisineType> DeleteCuisineType(int id);
    }
}
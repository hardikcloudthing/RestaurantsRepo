using RestaurantModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantRepo
{
    public interface IRestaurantManager
    {
        Restaurant Add(Restaurant restaurant);
        Task<Restaurant> Update(int id, Restaurant newRestaurant);
        Task<int> Delete(int id);
        Task<Restaurant> Get(int id);
        Task<List<Restaurant>> GetAll();
        Task<List<Restaurant>> GetByQuery(string searchQuery);
    }
}
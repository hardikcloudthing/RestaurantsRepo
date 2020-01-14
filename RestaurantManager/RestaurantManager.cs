using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantData;
using RestaurantModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRepo
{
    public class RestaurantManager : IRestaurantManager
    {
        private readonly RestaurantContext context;
        
        public RestaurantManager(RestaurantContext context)
        {
            this.context = context;
        }
        public Restaurant Add(Restaurant restaurant)
        {
            
                context.Restaurants.Add(restaurant);
                context.SaveChanges();
           
            return restaurant;
        }
        public async Task<Restaurant> Update(int id,Restaurant newRestaurant)
        {
            
                newRestaurant.Id = id;
                context.Restaurants.Update(newRestaurant);
                await context.SaveChangesAsync();
                return await context.Restaurants.Where(r=> r.Id == id).FirstOrDefaultAsync();
            
        }


        public async Task<int> Delete(int id)
        {
            
                var restaurant = context.Restaurants.Where(r => r.Id == id).FirstOrDefault();
                if (restaurant != null)
                {
                    context.Restaurants.Remove(restaurant);
                    return await context.SaveChangesAsync();
                }
                return await context.SaveChangesAsync();
            
        }
        public async Task<Restaurant> Get(int id)
        {
                  
                var restaurant = context.Restaurants.Where(r => r.Id == id).Include(r => r.Rating)
                                                       .Include(rc => rc.Restaurantcuisines)
                                                       .ThenInclude(c => c.Cuisinetype)
                                                       .FirstOrDefaultAsync();     
                return await restaurant;
           
           

        }
        public async Task<List<Restaurant>> GetAll()
        {
            
                return await context.Restaurants.Include(ra => ra.Rating)
                                                .Include(rc => rc.Restaurantcuisines)
                                                .ThenInclude(c => c.Cuisinetype)
                                                .ToListAsync();
                    
        }
        

        public async Task<List<Restaurant>> GetByQuery(string searchQuery)
        {
            
                var restaurants = await context.Restaurants.Include(r => r.Rating)
                                                            .Include(rc => rc.Restaurantcuisines)
                                                            .ThenInclude(c => c.Cuisinetype)
                                                            .ToListAsync();
                if (!string.IsNullOrWhiteSpace(searchQuery) && !string.IsNullOrEmpty(searchQuery))
                {
                    searchQuery = searchQuery.Trim();
                    return  restaurants.Where(r => r.Name == searchQuery || r.Street == searchQuery
                                            || r.Locality == searchQuery || r.State == searchQuery
                                            || r.City == searchQuery || r.Country == searchQuery).ToList();
                }
                
                return restaurants.ToList();
            
        }
    }
}

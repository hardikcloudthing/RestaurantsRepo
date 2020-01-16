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
    public class RestuarantManager : IRestaurantManager
    {
        private readonly RestaurantContext context;
        
        public RestuarantManager(RestaurantContext context)
        {
            this.context = context;
        }
        public async Task<Restaurant> Add(Restaurant restaurant)
        {
            
                await context.Restaurants.AddAsync(restaurant);
                await context.SaveChangesAsync();
           
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
            
                var restaurant = await context.Restaurants.Where(r => r.Id == id).FirstOrDefaultAsync();
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


        public async Task<CuisineType> GetCuisineType(int id)
        {
            return await context.Cuisinetypes.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<CuisineType>> GetCuisineTypes()
        {
            return await context.Cuisinetypes.ToListAsync();
        }

        public async Task<List<Rating>> GetRatings(int id)
        {
            return await context.Ratings.Where(r => r.RestaurantId == id).ToListAsync();
        }

        public async Task<Rating> AddRating(int id, Rating rating)
        {
            rating.RestaurantId = id;
            await context.Ratings.AddAsync(rating);
            await context.SaveChangesAsync();
            return rating;
        }

        public async Task<Rating> UpdateRating(int restaurantid, int ratingid, Rating rating)
        {
            rating.RestaurantId = restaurantid;
            rating.Id = ratingid;
            context.Ratings.Update(rating);
            await context.SaveChangesAsync();
            return rating;
        }

        public async Task<Rating> DeleteRating(int restaurantid,int ratingid)
        {
            var rating = await context.Ratings.Where(r => r.RestaurantId == restaurantid && r.Id == ratingid).FirstOrDefaultAsync();
            //rating.Id = ratingid;
            context.Ratings.Remove(rating);
            await context.SaveChangesAsync();
            return rating;
            
        }

        public async Task<CuisineType> AddCuisineType(CuisineType newcuisine)
        {
            await context.Cuisinetypes.AddAsync(newcuisine);
            await context.SaveChangesAsync();
            return newcuisine;
        }

        public async Task<CuisineType> DeleteCuisineType(int id)
        {
            var cuisine = await context.Cuisinetypes.Where(c => c.Id == id).FirstOrDefaultAsync();
            context.Cuisinetypes.Remove(cuisine);
            await context.SaveChangesAsync();
            return cuisine;
        }
        ~RestuarantManager()
        {
            context.Dispose();
        }
    }
}

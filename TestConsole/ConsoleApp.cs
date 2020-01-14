using RestaurantData;
using RestaurantRepo;
using RestaurantModel;
using System;
using System.Collections.Generic;

namespace RestaurantConsole
{
   public class ConsoleApp
    {
        public static void Main(string[] args)
        {
            RestaurantManager manager = new RestaurantManager();
            //manager.Add(TableData());
            //manager.Update(24, TableData());
            //manager.Delete(21);
            //Restaurant restaurant = manager.Get(1);
            //Console.WriteLine(restaurant.Restaurantcuisines[0].Cuisinetype.Cuisinename);

            List<Restaurant> restaurants = manager.GetAll();
            foreach (var rest in restaurants)
            {
                Console.WriteLine(rest.Restaurantcuisines[0].Cuisinetype.Cuisinename);
                Console.WriteLine(rest.Restaurantcuisines[1].Cuisinetype.Cuisinename);
            }



        }
        public static Restaurant TableData()
        {
            return new Restaurant
            {
                Name = "RAJRAJ",
                Street = "bandheri",
                Locality = "AAA",
                City = "Bangalore",
                State = "Karnataka",
                Country = "India",
                Postcode = "290009",
                Lat = 55.5f,
                Lang = 51.6f,
                Rating = new List<Rating>
                {
                    new Rating
                    {
                        Rate = 4
                    },
                    new Rating
                    {
                        Rate = 5
                    }
                },
                Restaurantcuisines = new List<RestaurantCuisines>
                {
                    new RestaurantCuisines
                    {
                        CuisinetypeId = 2
                    }
                }
            };
        }
    }
}

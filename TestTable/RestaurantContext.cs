using RestaurantModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace RestaurantData
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext()
        {
        }

        public RestaurantContext(DbContextOptions<RestaurantContext> options)
           : base(options)
        {
        }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<CuisineType> Cuisinetypes { get; set; }
        public DbSet<RestaurantCuisines> Restaurantcuisines { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //var connectionstring = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
        //    optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=RestaurantDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        IConfigurationRoot configuration = new ConfigurationBuilder()
        //           .SetBasePath(Directory.GetCurrentDirectory())
        //           .AddJsonFile("appsettings.json")
        //           .Build();
        //        var connectionString = configuration.GetConnectionString("connectionString");
        //        optionsBuilder.UseSqlServer(connectionString);
        //    }
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CuisineType>().HasData(
                new CuisineType {Id = 1,Cuisinename = "Indian"},
                new CuisineType { Id = 2,Cuisinename = "Chinese"},
                new CuisineType { Id = 3, Cuisinename = "Japanese" }
            );
        }
    }
}

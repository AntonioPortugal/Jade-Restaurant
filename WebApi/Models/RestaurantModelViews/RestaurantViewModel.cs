using RECODME.RD.Jade.Data.RestaurantInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RECODME.RD.Jade.WebApi.Models.RestaurantModelViews
{
    public class RestaurantViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string OpeningHours { get; set; }
        public string ClosingHours { get; set; }
        public string ClosingDays { get; set; }
        public int TableCount { get; set; }

        public Restaurant ToRestaurant()
        {
            return new Restaurant(Id, DateTime.UtcNow, DateTime.UtcNow, false, Name, Address, OpeningHours, ClosingHours, ClosingDays, TableCount);
        }

        public static RestaurantViewModel Parse(Restaurant restaurant)
        {
            return new RestaurantViewModel()
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Address = restaurant.Address,
                OpeningHours = restaurant.OpeningHours,
                ClosingHours = restaurant.ClosingHours,
                ClosingDays = restaurant.ClosingDays,
                TableCount = restaurant.TableCount
            };
        }
    }
}

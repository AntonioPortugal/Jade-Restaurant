using RECODME.RD.Jade.Data.MenuInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RECODME.RD.Jade.WebApi.Models.MenuModelViews
{
    public class MealViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string StartingHours { get; set; }
        public string EndingHours { get; set; }

        public Meal ToMeal()
        {
            return new Meal(Id, DateTime.UtcNow, DateTime.UtcNow, false, Name, StartingHours, EndingHours);
        }

        public static MealViewModel Parse(Meal meal)
        {
            return new MealViewModel()
            {
                Id = meal.Id,
                Name = meal.Name,
                StartingHours = meal.StartingHours,
                EndingHours = meal.EndingHours
            };
        }
    }
}

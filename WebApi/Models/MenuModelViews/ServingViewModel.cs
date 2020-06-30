using RECODME.RD.Jade.Data.MenuInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.MenuModelViews
{
    public class ServingViewModel
    {
        public Guid Id { get; set; }      
        public Guid MenuId { get; set; }
        public Guid DishId { get; set; }
        public Guid CourseId { get; set; }

        public Serving ToServing()
        {
            return new Serving(Id, DateTime.UtcNow, DateTime.UtcNow, false, MenuId, DishId, CourseId);
        }

        public static ServingViewModel Parse(Serving serving)
        {
            return new ServingViewModel()
            {
                Id = serving.Id,                
                MenuId = serving.MenuId,
                DishId = serving.DishId,
                CourseId = serving.CourseId,
            };
        }


    }
}

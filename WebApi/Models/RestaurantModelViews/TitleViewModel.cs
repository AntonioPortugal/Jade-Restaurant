using RECODME.RD.Jade.Data.RestaurantInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.RestaurantModelViews
{
    public class TitleViewModel
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }

        public Title ToDietaryRestriction()
        {
            return new Title(Id, DateTime.UtcNow, DateTime.UtcNow, IsDeleted, Name, Position, Description);
        }

        public static TitleViewModel Parse(Title title)
        {
            return new TitleViewModel()
            {
                Id = title.Id,
                IsDeleted = title.IsDeleted,
                Name = title.Name,
                Position = title.Position,
                Description = title.Description
            };
        }
    }
}

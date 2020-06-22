using Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.MenuInfo
{
    public class Dish : NamedEntity
    {
        [ForeignKey("Dietary Restriction")]
        public Guid DietaryRestrictionId { get; set; }
        public virtual DietaryRestriction DietaryRestriction { get; set; }


        public virtual ICollection<Serving> ServingsRecords { get; set; }
        public Dish(string name) : base(name)
        {
        }

        public Dish(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, string name) : base(id, createdAt, updatedAt, isDeleted, name)
        {
        }
    }
}

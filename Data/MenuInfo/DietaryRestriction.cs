using Data.Base;
using System;
using System.Collections.Generic;

namespace Data.MenuInfo
{
    public class DietaryRestriction : NamedEntity
    {
        public virtual ICollection<Dish> Dishes{ get; set; }

        public DietaryRestriction(string name) : base(name)
        {
        }

        public DietaryRestriction(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, string name) : base(id, createdAt, updatedAt, isDeleted, name)
        {
        }
    }
}

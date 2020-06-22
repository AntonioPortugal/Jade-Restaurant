using Data.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.MenuInfo
{
    public class DietaryRestriction : NamedEntity
    {
        public DietaryRestriction(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, string name) : base(id, createdAt, updatedAt, isDeleted, name)
        {
        }
    }
}

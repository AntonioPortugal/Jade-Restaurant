using Data.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.MenuInfo
{
    public class Course : NamedEntity
    {
        public virtual ICollection<Serving> ServingsRecords { get; set; }

        public Course(string name) : base(name)
        {
        }

        public Course(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, string name) : base(id, createdAt, updatedAt, isDeleted, name)
        {
        }
    }
}

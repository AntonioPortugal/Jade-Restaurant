﻿using RECODME.RD.Jade.Data.Base;
using System;
using System.Collections.Generic;

namespace RECODME.RD.Jade.Data.MenuInfo
{
    public class Course : NamedEntity
    {
        public virtual ICollection<Serving> Servings { get; set; }

        public Course(string name) : base(name)
        {
        }

        public Course(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, string name) : base(id, createdAt, updatedAt, isDeleted, name)
        {
        }
    }
}

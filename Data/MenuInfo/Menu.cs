using Data.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.MenuInfo
{
    public class Menu : Entity
    {
        public DateTime Date { get; set; }

        public Menu(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted) : base(id, createdAt, updatedAt, isDeleted)
        {
        }
    }
}

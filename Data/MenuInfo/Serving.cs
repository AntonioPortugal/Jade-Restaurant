using Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.MenuInfo
{
    public class Serving : Entity
    {
        [ForeignKey("Menu")]
        public Guid MenuId { get; set; }

        [ForeignKey("Dish")]
        public Guid DishId { get; set; }

        [ForeignKey("Course")]
        public Guid CourseId { get; set; }



        public Serving()
        {
        }

        public Serving(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted) : base(id, createdAt, updatedAt, isDeleted)
        {
        }
    }
}

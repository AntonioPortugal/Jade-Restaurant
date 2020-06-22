using Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.MenuInfo
{
    public class Menu : Entity
    {
        private DateTime _date;
        public DateTime Date 
        {
            get => _date;
            set
            {
                _date = value;
                RegisterChange();
            }
        }

        [ForeignKey("Meal")]
        public Guid MealId { get; set; }
        public virtual Meal Meal { get; set; }//??

        [ForeignKey("Restaurant")]
        public Guid RestaurantId { get; set; }

        public virtual ICollection<Serving> ServingsRecords { get; set; }//ServingsRecords ???

        public Menu(DateTime date)
        {
            _date = date;
        }

        public Menu(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, DateTime date) : base(id, createdAt, updatedAt, isDeleted)
        {
            _date = date;
        }

    }
}

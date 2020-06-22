using Data.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Data.RestaurantInfo
{
    public class Booking : Entity
    {
        private DateTime _date;

        [Required]
        [Display(Name = "Date")]
        public DateTime Date
        {
            get => _date;

            set
            {
                _date = value;
                RegisterChange();
            }
        }

        public Booking(DateTime date)
        {
            _date = date;
        }

        public Booking(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, DateTime date) : base(id, createdAt, updatedAt, isDeleted)
        {
            _date = date;
        }
    }
}

using Data.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("ClientRecord")]        
        public Guid ClientRecordId { get; set; }


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

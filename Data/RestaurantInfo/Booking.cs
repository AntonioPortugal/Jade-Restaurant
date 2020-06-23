using Data.Base;
using Data.UserInfo;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.RestaurantInfo
{
    public class Booking : Entity
    {
        private DateTime _date;

        [Required(ErrorMessage = "Required Attribute")]
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
        public virtual ClientRecord ClientRecord { get; set; }


        public Booking(DateTime date, Guid clientRecordId)
        {
            _date = date;
            ClientRecordId = clientRecordId;
        }

        public Booking(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, DateTime date, Guid clientRecordId) : base(id, createdAt, updatedAt, isDeleted)
        {
            _date = date;
            ClientRecordId = clientRecordId;
        }
    }
}

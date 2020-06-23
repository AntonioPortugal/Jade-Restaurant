using Data.Base;
using Data.RestaurantInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.UserInfo
{
    public class ClientRecord : Entity
    {
        private DateTime _registerDate;

        [Required]
        [Display(Name = "Register Date")]
        public DateTime RegisterDate 
        {
            get => _registerDate;

            set
            {
                _registerDate = value;
                RegisterChange();

            }

        }

        [ForeignKey("Person")]
        public Guid PersonId { get; set; }
        public virtual Person Person { get; set; }

        [ForeignKey("Restaurant")]
        public Guid RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }

        public ClientRecord (DateTime registrationDate, Guid personId, Guid restaurantId)
        {
            _registerDate = registrationDate;
            PersonId = personId;
            RestaurantId = restaurantId;

        }
        public ClientRecord(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, DateTime registrationDate, Guid personId, Guid restaurantId) : base(id, createdAt, updatedAt, isDeleted)
        {
            _registerDate = registrationDate;
            PersonId = personId;
            RestaurantId = restaurantId;
        }

    }

}

using RECODME.RD.Jade.Data.RestaurantInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.RestaurantModelViews
{
    public class BookingViewModel
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Date { get; set; }
        public Guid ClientRecordId { get; set; }


        public Booking ToDietaryRestriction()
        {
            return new Booking(Id, DateTime.UtcNow, DateTime.UtcNow, IsDeleted, Date, ClientRecordId);
        }

        public static BookingViewModel Parse(Booking booking)
        {
            return new BookingViewModel()
            {
                Id = booking.Id,
                IsDeleted = booking.IsDeleted,
                Date = booking.Date,
                ClientRecordId = booking.ClientRecordId
            };
        }
    }
}

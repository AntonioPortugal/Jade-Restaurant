using RECODME.RD.Jade.Data.RestaurantInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RECODME.RD.Jade.WebApi.Models.RestaurantModelViews
{
    public class BookingViewModel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid ClientRecordId { get; set; }


        public Booking ToBooking()
        {
            return new Booking(Id, DateTime.UtcNow, DateTime.UtcNow, false, Date, ClientRecordId);
        }

        public static BookingViewModel Parse(Booking booking)
        {
            return new BookingViewModel()
            {
                Id = booking.Id,
                Date = booking.Date,
                ClientRecordId = booking.ClientRecordId
            };
        }
    }
}

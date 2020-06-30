using RECODME.RD.Jade.Data.UserInfo;
using System;

namespace RECODME.RD.Jade.WebApi.Models.UserModelViews
{
    public class StaffViewModel
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public Guid RestaurantId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

        public StaffRecord ToStaff()
        {
            return new StaffRecord(Id, DateTime.UtcNow, DateTime.UtcNow, false, BeginDate, EndDate, PersonId, RestaurantId);

        }

        public static StaffViewModel Parse(StaffRecord Staff)
        {
            return new StaffViewModel()
            {
                Id = Staff.Id,
                PersonId = Staff.PersonId,
                RestaurantId = Staff.RestaurantId,
                BeginDate = Staff.BeginDate,
                EndDate = Staff.EndDate,

            };

        }

    }

}

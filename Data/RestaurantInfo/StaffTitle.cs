using Data.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.RestaurantInfo
{
    public class StaffTitle : Entity
    {
        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate;

        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate;

        [ForeignKey("Title")]
        public Guid TitleId { get; set; }

        public StaffTitle(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;

        }
        public StaffTitle(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, DateTime startDate, DateTime endDate) : base(id, createdAt, updatedAt, isDeleted)
        {
            StartDate = startDate;
            EndDate = endDate;

        }
    }
}

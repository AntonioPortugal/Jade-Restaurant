using Data.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.UserInfo
{
    public class StaffRecord : Entity
    {
        private DateTime _beginDate;

        [Required]
        [Display(Name = "Begin Date")]
        public DateTime BeginDate
        {
            get => _beginDate;

            set
            {
                _beginDate = value;
                RegisterChange();

            }

        }

        private DateTime _endDate;

        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate
        {
            get => _endDate;

            set
            {
                _endDate = value;
                RegisterChange();

            }

        }

        [ForeignKey("Person")]
        public Guid PersonId { get; set; }

        public StaffRecord(DateTime beginDate, DateTime endDate)
        {
            _beginDate = beginDate;
            _endDate = endDate;

        }

        public StaffRecord(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, DateTime beginDate, DateTime endDate) : base(id, createdAt, updatedAt, isDeleted)
        {
            _beginDate = beginDate;
            _endDate = endDate;

        }

    }

}

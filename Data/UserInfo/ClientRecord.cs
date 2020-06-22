using Data.Base;
using System;
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

        public ClientRecord (DateTime registrationDate)
        {
            _registerDate = registrationDate;

        }
        public ClientRecord(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, DateTime registrationDate) : base(id, createdAt, updatedAt, isDeleted)
        {
            _registerDate = registrationDate;

        }

    }

}

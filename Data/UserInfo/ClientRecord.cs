using Data.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Data.UserInfo
{
    class ClientRecord : Entity
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

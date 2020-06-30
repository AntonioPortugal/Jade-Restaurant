using RECODME.RD.Jade.Data.UserInfo;
using System;

namespace RECODME.RD.Jade.WebApi.Models.UserModelViews
{
    public class PersonViewModel
    {
        public Guid Id { get; set; }
        public long VATNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public Guid UserId { get; set; }

        public Person ToPerson()
        {
            return new Person(Id, DateTime.UtcNow, DateTime.UtcNow, false, VATNumber, FirstName, LastName, PhoneNumber, Birthdate, UserId);

        }

        public static PersonViewModel Parse(Person Staff)
        {
            return new PersonViewModel()
            {
                Id = Staff.Id,
                VATNumber = Staff.VatNumber,
                FirstName = Staff.FirstName,
                LastName = Staff.LastName,
                PhoneNumber = Staff.PhoneNumber,
                Birthdate = Staff.BirthDate,
                UserId = Staff.UserId,

            };

        }

    }

}

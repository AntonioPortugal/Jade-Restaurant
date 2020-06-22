using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.UserInfo
{
    public class JadeUser : IdentityUser
    {
        [Key]
        public Guid Id { get; private set; }

        [ForeignKey("Person")]
        public Guid PersonId { get; set; }

        public JadeUser() : base()
        {
            Id = Guid.NewGuid();

        }

    }

}

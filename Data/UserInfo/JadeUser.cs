using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.UserInfo
{
    public class JadeUser : IdentityUser 
    {
        [Key]
        public new Guid Id { get; private set; }

        [ForeignKey("Person")]
        public Guid PersonId { get; set; }
        public virtual Person Person { get; set; }

        public JadeUser() : base()
        {
            Id = Guid.NewGuid();

        }

    }

}

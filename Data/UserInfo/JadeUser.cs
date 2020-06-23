using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.UserInfo
{
    public class JadeUser : IdentityUser<Guid>
    {
        [Key]
        public override Guid Id { get; set; }

        [ForeignKey("Person")]
        public Guid PersonId { get; set; }
        public virtual Person Person { get; set; }

        public JadeUser(Guid personId)
        {
            Id = Guid.NewGuid();
            PersonId = personId;
        }

    }

}

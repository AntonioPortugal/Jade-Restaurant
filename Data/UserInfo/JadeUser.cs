using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;

namespace Data.UserInfo
{
    public class JadeUser : IdentityUser
    {
        [Key]
        public Guid Id { get; private set; }

        public JadeUser()
        {
            Id = Guid.NewGuid();

        }

    }

}

using System;
using System.Collections.Generic;
using MediAR.Core.Contracts.Entities;

namespace MediAR.Modules.Membership.Core.Entities
{
    public class ApplicationUser : BaseEntity<Guid>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<ApplicationUserRole> Roles { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<UserToken> Tokens { get; set; }
        public UserProfile UserProfile { get; set; }

        public ApplicationUser()
        {
            Id = Guid.NewGuid();
        }
    }
}
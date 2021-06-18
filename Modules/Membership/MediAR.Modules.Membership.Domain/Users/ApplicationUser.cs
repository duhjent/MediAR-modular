using System;
using System.Collections.Generic;
using MediAR.Core.Domain;
using MediAR.Modules.Membership.Domain.Roles;
using MediAR.Modules.Membership.Domain.Tokens;

namespace MediAR.Modules.Membership.Domain.Users
{
    public class ApplicationUser : BaseEntityWithId<string>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public IList<ApplicationUserRole> Roles { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<UserToken> Tokens { get; set; }
        public UserProfile UserProfile { get; set; }

        public ApplicationUser()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
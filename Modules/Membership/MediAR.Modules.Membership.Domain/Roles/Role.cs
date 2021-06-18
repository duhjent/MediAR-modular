using System;
using System.Collections.Generic;
using MediAR.Core.Domain;

namespace MediAR.Modules.Membership.Domain.Roles
{
    public class Role : BaseEntityWithId<string>
    {
        public string Name { get; set; }

        public ICollection<ApplicationUserRole> ApplicationUsers { get; set; }

        public Role()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
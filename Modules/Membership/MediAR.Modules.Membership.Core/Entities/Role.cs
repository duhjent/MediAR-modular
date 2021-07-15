using System;
using System.Collections.Generic;
using MediAR.Core.Contracts.Entities;

namespace MediAR.Modules.Membership.Core.Entities
{
    public class Role : BaseEntity<Guid>
    {
        public string Name { get; set; }

        public ICollection<ApplicationUserRole> ApplicationUsers { get; set; }

        public Role()
        {
            Id = Guid.NewGuid();
        }
    }
}
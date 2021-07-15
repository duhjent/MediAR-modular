using System;

namespace MediAR.Modules.Membership.Core.Entities
{
    public class ApplicationUserRole
    {
        public ApplicationUser ApplicationUser { get; set; }
        public Guid ApplicationUserId { get; set; }

        public Role Role { get; set; }
        public string RoleId { get; set; }
    }
}
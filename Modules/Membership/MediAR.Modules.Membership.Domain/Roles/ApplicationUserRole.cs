using MediAR.Modules.Membership.Domain.Users;

namespace MediAR.Modules.Membership.Domain.Roles
{
    public class ApplicationUserRole
    {
        public ApplicationUser Type { get; set; }
        public string ApplicationUserId { get; set; }

        public Role Role { get; set; }
        public string RoleId { get; set; }
    }
}
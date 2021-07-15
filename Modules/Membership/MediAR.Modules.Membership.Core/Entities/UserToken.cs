using System;

namespace MediAR.Modules.Membership.Core.Entities
{
    public class UserToken
    {
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; }
        public DateTimeOffset ExpTime { get; set; }
    }
}
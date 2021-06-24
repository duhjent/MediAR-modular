using System;
using MediAR.Modules.Membership.Domain.Users;

namespace MediAR.Modules.Membership.Domain.Tokens
{
    public class UserToken
    {
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; }
        public DateTimeOffset ExpTime { get; set; }
    }
}
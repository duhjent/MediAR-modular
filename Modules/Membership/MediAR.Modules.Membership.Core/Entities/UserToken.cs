using System;
using MediAR.Core.Contracts.Entities;

namespace MediAR.Modules.Membership.Core.Entities
{
    public class UserToken : BaseEntity<int>
    {
        public ApplicationUser User { get; set; }
        public Guid UserId { get; set; }
        public string Token { get; set; }
        public DateTimeOffset ExpTime { get; set; }
    }
}
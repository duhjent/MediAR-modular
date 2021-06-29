using System;

namespace MediAR.Modules.Membership.Application.Users.RegisterUser
{
    public class UserRegistrationDto
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Guid TenantId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
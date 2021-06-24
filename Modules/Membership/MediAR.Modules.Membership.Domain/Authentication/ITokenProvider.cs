using MediAR.Modules.Membership.Domain.Users;

namespace MediAR.Modules.Membership.Domain.Authentication
{
    public interface ITokenProvider
    {
        string GenerateToken(ApplicationUser user);
    }
}
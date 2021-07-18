using MediAR.Modules.Membership.Core.Entities;

namespace MediAR.Modules.Membership.Core.Contracts
{
    public interface IAuthTokenProvider
    {
        string GenerateToken(ApplicationUser user);
    }
}
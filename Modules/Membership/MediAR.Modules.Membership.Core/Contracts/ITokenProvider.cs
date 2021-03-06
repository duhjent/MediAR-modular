using MediAR.Modules.Membership.Core.Entities;

namespace MediAR.Modules.Membership.Core.Contracts
{
    public interface ITokenProvider
    {
        string GenerateToken(string purpose, ApplicationUser user);
    }
}
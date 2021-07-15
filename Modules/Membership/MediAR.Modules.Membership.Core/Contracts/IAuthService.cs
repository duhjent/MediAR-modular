using MediAR.Modules.Membership.Core.Dtos;

namespace MediAR.Modules.Membership.Core.Contracts
{
    public interface IAuthService
    {
        AuthenticationResult Authenticate(AuthenticationDto authModel);
    }
}
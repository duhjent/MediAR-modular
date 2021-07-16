using System.Threading.Tasks;
using MediAR.Modules.Membership.Core.Dtos;

namespace MediAR.Modules.Membership.Core.Contracts
{
    public interface IAuthService
    {
        Task<AuthenticationResult> AuthenticateAsync(AuthenticationDto authModel);
    }
}
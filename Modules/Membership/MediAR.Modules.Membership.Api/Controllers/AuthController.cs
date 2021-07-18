using System.Threading.Tasks;
using MediAR.Modules.Membership.Core.Contracts;
using MediAR.Modules.Membership.Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MediAR.Modules.Membership.Api.Controllers
{
    internal class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<ActionResult<AuthenticationResult>> Authenticate(AuthenticationRequestModel model) =>
            await _authService.AuthenticateAsync(model);
    }
}
using System.Threading.Tasks;
using MediAR.Modules.Membership.Core.Contracts;
using MediAR.Modules.Membership.Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediAR.Modules.Membership.Api.Controllers
{
    internal class UsersController : BaseController
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _service;

        public UsersController(ILogger<UsersController> logger, IUserService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("")]
        public async Task<ActionResult> GetHome() =>
            await Task.FromResult(Ok(new {Message = "Hello from membership api"}));

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResult>> Register(UserRegistrationDto model) =>
            await _service.RegisterAsync(model);
    }
}
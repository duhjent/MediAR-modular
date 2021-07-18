using System.Threading.Tasks;
using MediAR.Core.Contracts.Configuration;
using MediAR.Modules.Membership.Core.Contracts;
using MediAR.Modules.Membership.Core.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace MediAR.Modules.Membership.Api.Controllers
{
    internal class UsersController : BaseController
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _service;
        private readonly IExecutionContextAccessor _executionContextAccessor;

        public UsersController(ILogger<UsersController> logger, IUserService service, IExecutionContextAccessor _executionContextAccessor)
        {
            _logger = logger;
            _service = service;
            this._executionContextAccessor = _executionContextAccessor;
        }

        [HttpGet("")]
        public async Task<ActionResult> GetHome() =>
            await Task.FromResult(Ok(new {Message = "Hello from membership api"}));

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResult>> Register(UserRegistrationRequestModel model) =>
            await _service.RegisterAsync(model);

        [HttpPost("passwordReset")]
        [Authorize]
        public async Task<ActionResult> GeneratePasswordResetToken()
        {
            var token = await _service.GeneratePasswordResetTokenAsync(_executionContextAccessor.UserId);
            return Ok(new {Token = token});
        }
        
        [HttpGet("passwordReset")]
        public async Task<ActionResult> ResetPassword(string userName, string token, string newPassword)
        {
            var result = await _service.ResetPasswordAsync(userName, token, newPassword);
            return Ok(result);
        }
    }
}
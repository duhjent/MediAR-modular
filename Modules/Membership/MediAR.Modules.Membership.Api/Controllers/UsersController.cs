using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediAR.Modules.Membership.Api.Controllers
{
    internal class UsersController : BaseController
    {
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public async Task<ActionResult> GetHome() =>
            await Task.FromResult(Ok(new {Message = "Hello from membership api"}));
    }
}
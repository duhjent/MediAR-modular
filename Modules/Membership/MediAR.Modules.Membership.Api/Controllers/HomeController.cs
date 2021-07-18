using System.Threading.Tasks;
using MediAR.Core.Contracts.Configuration;
using MediAR.Modules.Membership.Core.Configurations;
using MediAR.Modules.Membership.Core.Contracts;
using MediAR.Modules.Membership.Core.DAL;
using MediAR.Modules.Membership.Core.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MediAR.Modules.Membership.Api.Controllers
{
    [Route(BaseUrl)]
    internal class HomeController : BaseController
    {
        private readonly MembershipDbContext _ctx;
        private readonly ILogger<HomeController> _logger;
        private readonly IExecutionContextAccessor _contextAccessor;
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;
        private readonly AdminConfiguration _adminConfig;

        public HomeController(MembershipDbContext ctx, ILogger<HomeController> logger,
            IExecutionContextAccessor contextAccessor, IRoleService roleService, IUserService userService,
            AdminConfiguration adminConfig)
        {
            _ctx = ctx;
            _logger = logger;
            _contextAccessor = contextAccessor;
            _roleService = roleService;
            _userService = userService;
            _adminConfig = adminConfig;
        }

        [HttpPost("dbUp")]
        public async Task<ActionResult> DbUp()
        {
            await _ctx.Database.MigrateAsync();

            var existingAdmin = await _userService.GetByNameAsync(_adminConfig.DefaultUserName);
            if (existingAdmin is not null)
            {
                return Ok();
            }

            var adminRole = await _roleService.CreateRoleWithName(_adminConfig.DefaultRoleName);
            var registrationModel = new UserRegistrationRequestModel
            {
                UserName = _adminConfig.DefaultUserName,
                Email = _adminConfig.DefaultEmail,
                Password = _adminConfig.DefaultPassword,
                FirstName = _adminConfig.DefaultFirstName,
                LastName = _adminConfig.DefaultLastName
            };
            var adminUserRegResult = await _userService.RegisterAsync(registrationModel);
            if (!adminUserRegResult.IsSuccessful)
            {
                return BadRequest();
            }

            var adminUser = await _userService.GetByNameAsync(_adminConfig.DefaultUserName);
            await _roleService.AddRoleToUser(adminUser.Id, adminRole.Id);

            return Ok();
        }

        [HttpGet("secret")]
        [Authorize]
        public async Task<ActionResult> GetSecret()
        {
            return Ok(await Task.FromResult(new {Secret = "shhhh..."}));
        }
    }
}
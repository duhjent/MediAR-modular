using System.Threading.Tasks;
using MediAR.Core.Contracts.Configuration;
using MediAR.Core.Infrastructure.Authorization;
using MediAR.Modules.Membership.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Routing;

namespace MediAR.Modules.Membership.Api.Configuration.Authorization
{
    public class HasRoleAttributeAuthorizationHandler : AuthorizationHandler<HasRoleAuthorizationRequirement>
    {
        private readonly IExecutionContextAccessor _executionContextAccessor;
        private readonly IRoleService _roleService;

        public HasRoleAttributeAuthorizationHandler(IExecutionContextAccessor executionContextAccessor,
            IRoleService roleService)
        {
            _executionContextAccessor = executionContextAccessor;
            _roleService = roleService;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
            HasRoleAuthorizationRequirement requirement)
        {
            var attribute = (context.Resource as RouteEndpoint)?.Metadata.GetMetadata<HasRoleAttribute>();

            if (await _roleService.UserHasRole(_executionContextAccessor.UserId, attribute!.Name))
            {
                context.Succeed(requirement);
                return;
            }

            context.Fail();
        }
    }
}
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using MediAR.Core.Contracts.Configuration;
using Microsoft.AspNetCore.Http;

namespace MediAR.MainApi.Configuration
{
    public class ExecutionContextAccessor : IExecutionContextAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExecutionContextAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid UserId
        {
            get
            {
                if (_httpContextAccessor
                    .HttpContext?
                    .User?
                    .Claims?
                    .SingleOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub)?
                    .Value != null)
                {
                    return Guid.Parse(_httpContextAccessor.HttpContext.User.Claims.Single(
                        x => x.Type == JwtRegisteredClaimNames.Sub).Value);
                }

                throw new ApplicationException("User context is not available");
            }
        }

        public Guid TenantId
        {
            get
            {
                if (_httpContextAccessor
                    .HttpContext?
                    .Request
                    .Headers
                    .Keys
                    .SingleOrDefault(x => x == "TenantApiKey") != null)
                {
                    return Guid.Parse(_httpContextAccessor.HttpContext?.Request
                        .Headers.Keys.Single(x => x == "TenantApiKey"));
                }

                throw new ApplicationException("Tenant context is not available");
            }
        }
    }
}
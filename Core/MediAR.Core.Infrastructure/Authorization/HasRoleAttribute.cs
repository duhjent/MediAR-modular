using System;
using Microsoft.AspNetCore.Authorization;

namespace MediAR.Core.Infrastructure.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class HasRoleAttribute : AuthorizeAttribute
    {
        public const string HasRolePolicyName = "HasRole";
        
        public string Name { get; }

        public HasRoleAttribute(string name)
            : base(HasRolePolicyName)
        {
            Name = name;
        }
    }
}
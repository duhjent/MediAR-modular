using System;

namespace MediAR.Core.Contracts.Configuration
{
    public interface IExecutionContextAccessor
    {
        public Guid UserId { get; }
        public Guid TenantId { get; }
    }
}
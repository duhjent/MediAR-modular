using System;

namespace MediAR.Core.Contracts.Entities
{
    public class BaseEntityWithTenantInformation : BaseEntity
    {
        public Guid TenantId { get; set; }
    }
    
    public class BaseEntityWithTenantInformation<TId> : BaseEntity<TId>
    {
        public Guid TenantId { get; set; }
    }
}
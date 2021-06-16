using System;

namespace MediAR.Core.Domain
{
    class DomainEventBase : IDomainEvent
    {
        public Guid Id { get; set; }

        public DateTime OccuredOn { get; set; }

        public DomainEventBase()
        {
            Id = Guid.NewGuid();
            OccuredOn = DateTime.Now;
        }
    }
}

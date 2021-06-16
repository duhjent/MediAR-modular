using MediAR.Core.Domain;
using System.Collections.Generic;

namespace MediAR.Core.Infrastructure.DomainEvents
{
    interface IDomainEventsAccessor
    {
        IReadOnlyCollection<IDomainEvent> GetAllDomainEvents();

        void ClearAllDomainEvents();
    }
}

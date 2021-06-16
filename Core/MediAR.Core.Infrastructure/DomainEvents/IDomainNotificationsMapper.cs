using System;

namespace MediAR.Core.Infrastructure.DomainEvents
{
    interface IDomainNotificationsMapper
    {
        string GetName(Type type);

        Type GetType(string name);
    }
}

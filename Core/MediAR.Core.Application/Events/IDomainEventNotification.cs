using MediatR;
using System;

namespace MediAR.Core.Application.Events
{
    public interface IDomainEventNotification<out TEventType>: IDomainEventNotification
    {
        TEventType DomainEvent { get; }
    }

    public interface IDomainEventNotification : INotification
    {
        Guid Id { get; }
    }
}

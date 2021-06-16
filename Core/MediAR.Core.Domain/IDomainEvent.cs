using MediatR;
using System;

namespace MediAR.Core.Domain
{
    public interface IDomainEvent : INotification
    {
        Guid Id { get; }

        DateTime OccuredOn { get; }
    }
}

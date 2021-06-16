using MediatR;
using System;

namespace MediAR.Core.Infrastructure.Events
{
    public abstract class IntegrationEvent : INotification
    {
        public Guid Id { get; }

        public DateTime OccuredOn { get; }

        protected IntegrationEvent(Guid id, DateTime occuredOn)
        {
            Id = id;
            OccuredOn = occuredOn;
        }
    }
}

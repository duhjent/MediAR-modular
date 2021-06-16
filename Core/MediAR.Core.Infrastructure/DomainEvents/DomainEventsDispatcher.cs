using Autofac;
using Autofac.Core;
using MediAR.Core.Application.Events;
using MediAR.Core.Application.Outbox;
using MediAR.Core.Domain;
using MediAR.Core.Infrastructure.Serialization;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediAR.Core.Infrastructure.DomainEvents
{
    class DomainEventsDispatcher : IDomainEventsDispatcher
    {
        private readonly IMediator _mediator;
        private readonly ILifetimeScope _scope;
        private readonly IOutbox _outbox;
        private readonly IDomainEventsAccessor _domainEventsAccessor;
        private readonly IDomainNotificationsMapper _domainNotificationsMapper;

        public DomainEventsDispatcher(
            IMediator mediator,
            ILifetimeScope scope,
            IOutbox outbox,
            IDomainEventsAccessor domainEventsAccessor,
            IDomainNotificationsMapper domainNotificationsMapper)
        {
            _mediator = mediator;
            _scope = scope;
            _outbox = outbox;
            _domainEventsAccessor = domainEventsAccessor;
            _domainNotificationsMapper = domainNotificationsMapper;
        }

        public async Task DispatchEventAsync()
        {
            var domainEvents = _domainEventsAccessor.GetAllDomainEvents();

            var notifications = new List<IDomainEventNotification<IDomainEvent>>();

            foreach(var domainEvent in domainEvents)
            {
                Type domainEventNotificationType = typeof(IDomainEventNotification<>);
                var domainNotificationWithGeneric = domainEventNotificationType.MakeGenericType(domainEvent.GetType());

                var domainNotification = _scope.ResolveOptional(domainNotificationWithGeneric, new List<Parameter>
                {
                    new NamedParameter("domainEvent", domainEvent),
                    new NamedParameter("id", domainEvent.Id)
                });

                if (domainNotification != null)
                {
                    notifications.Add(domainNotification as IDomainEventNotification<IDomainEvent>);
                }
            }

            _domainEventsAccessor.ClearAllDomainEvents();

            foreach(var domainEvent in domainEvents)
            {
                await _mediator.Publish(domainEvent);
            }

            foreach(var notification in notifications)
            {
                var type = _domainNotificationsMapper.GetName(notification.GetType());

                var data = JsonConvert.SerializeObject(notification, new JsonSerializerSettings
                {
                    ContractResolver = new AllPropertiesContractResolver()
                });

                var message = new OutboxMessage(notification.Id, notification.DomainEvent.OccuredOn, type, data);

                _outbox.Add(message);
            }
        }
    }
}

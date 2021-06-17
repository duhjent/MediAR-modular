using System.Collections.Generic;
using System.Threading.Tasks;
using MediAR.Core.Infrastructure.Events;

namespace MediAR.Core.EventBus
{
    public sealed class InMemoryEventBus
    {
        private readonly IDictionary<string, List<IIntegrationEventHandler>> _handlers;

        public static InMemoryEventBus Instance => new InMemoryEventBus();

        static InMemoryEventBus()
        {
        }

        private InMemoryEventBus()
        {
            _handlers = new Dictionary<string, List<IIntegrationEventHandler>>();
        }

        public async Task Publish<T>(T @event) where T : IntegrationEvent
        {
            var eventType = @event.GetType().FullName;

            if (eventType != null)
            {
                foreach (var genericHandler in _handlers[eventType])
                {
                    if (genericHandler is IIntegrationEventHandler<T> handler)
                    {
                        await handler.Handle(@event);
                    }
                }
            }
        }

        public void Subscribe<T>(IIntegrationEventHandler<T> handler) where T : IntegrationEvent
        {
            var eventType = typeof(T).FullName;
            if (eventType == null) return;
            if (_handlers.ContainsKey(eventType))
            {
                _handlers[eventType].Add(handler);
            }
            else
            {
                _handlers.Add(eventType, new List<IIntegrationEventHandler> {handler});
            }
        }
    }
}
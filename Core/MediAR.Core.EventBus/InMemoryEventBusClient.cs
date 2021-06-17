using System.Threading.Tasks;
using MediAR.Core.Infrastructure.Events;
using Serilog;

namespace MediAR.Core.EventBus
{
    public class InMemoryEventBusClient : IEventBus
    {
        private readonly ILogger _logger;

        public InMemoryEventBusClient(ILogger logger)
        {
            _logger = logger;
        }

        public void Dispose()
        {
            // do nothing
        }

        public async Task Publish<T>(T @event) where T : IntegrationEvent
        {
            _logger.Information($"Publishing {@event.GetType().FullName}");
            await InMemoryEventBus.Instance.Publish(@event);
        }

        public void Subscribe<T>(IIntegrationEventHandler<T> handler) where T : IntegrationEvent
        {
            InMemoryEventBus.Instance.Subscribe(handler);
        }

        public void StartConsuming()
        {
        }
    }
}
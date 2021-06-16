using System.Threading.Tasks;

namespace MediAR.Core.Infrastructure.DomainEvents
{
    interface IDomainEventsDispatcher
    {
        Task DispatchEventAsync();
    }
}

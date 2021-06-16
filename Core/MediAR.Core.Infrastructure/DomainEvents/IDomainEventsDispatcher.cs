using System.Threading.Tasks;

namespace MediAR.Core.Infrastructure.DomainEvents
{
    public interface IDomainEventsDispatcher
    {
        Task DispatchEventAsync();
    }
}

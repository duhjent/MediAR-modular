using System.Threading.Tasks;

namespace MediAR.Core.Application.Outbox
{
    public interface IOutbox
    {
        void Add(OutboxMessage message);

        Task Save();
    }
}

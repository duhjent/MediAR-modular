using System.Threading.Tasks;
using MediAR.Core.Application.Contracts;

namespace MediAR.Modules.Membership.Application.Contracts
{
    public interface IMembershipModule
    {
        Task<T> ExecuteCommandAsync<T>(ICommand<T> command);

        Task ExecuteCommandAsync(ICommand command);

        Task<T> ExecuteQueryAsync<T>(IQuery<T> query);
    }
}
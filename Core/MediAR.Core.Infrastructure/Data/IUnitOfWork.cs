using System;
using System.Threading.Tasks;

namespace MediAR.Core.Infrastructure.Data
{
    interface IUnitOfWork
    {
        Task<int> CommitAsync(Guid? internalCommandId = null);
    }
}

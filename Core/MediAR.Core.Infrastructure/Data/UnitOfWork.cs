using MediAR.Core.Infrastructure.DomainEvents;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MediAR.Core.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _appDbContext;
        private readonly IDomainEventsDispatcher _eventsDispatcher;

        public UnitOfWork(DbContext appDbContext, IDomainEventsDispatcher eventsDispatcher)
        {
            _appDbContext = appDbContext;
            _eventsDispatcher = eventsDispatcher;
        }

        public async Task<int> CommitAsync(Guid? internalCommandId = null)
        {
            await _eventsDispatcher.DispatchEventAsync();
            return await _appDbContext.SaveChangesAsync();
        }
    }
}

using MediAR.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediAR.Core.Infrastructure.DomainEvents
{
    class DomainEventsAccessor : IDomainEventsAccessor
    {
        private readonly DbContext _appDbContext;

        public DomainEventsAccessor(DbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void ClearAllDomainEvents()
        {
            var domainEntities = _appDbContext.ChangeTracker
                .Entries<BaseEntity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();

            domainEntities
                .ForEach(entity => entity.Entity.ClearDomainEvents());
        }

        public IReadOnlyCollection<IDomainEvent> GetAllDomainEvents()
        {
            var domainEntities = _appDbContext.ChangeTracker
                .Entries<BaseEntity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();

            return domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();
        }
    }
}

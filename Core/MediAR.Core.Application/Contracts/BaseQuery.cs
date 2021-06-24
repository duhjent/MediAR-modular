using System;

namespace MediAR.Core.Application.Contracts
{
    public class BaseQuery<T> : IQuery<T>
    {
        public Guid Id { get; set; }

        protected BaseQuery()
        {
            Id = Guid.NewGuid();
        }

        private BaseQuery(Guid id)
        {
            Id = id;
        }
    }
}
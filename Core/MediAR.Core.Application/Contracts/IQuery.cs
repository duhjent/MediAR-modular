using System;
using MediatR;

namespace MediAR.Core.Application.Contracts
{
    public interface IQuery<out T> : IRequest<T>
    {
        public Guid Id { get; set; }
    }
}
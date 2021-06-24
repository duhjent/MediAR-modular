using System;
using MediatR;

namespace MediAR.Core.Application.Contracts
{
    public interface ICommand : IRequest
    {
        Guid Id { get; set; }
    }

    public interface ICommand<out T> : IRequest<T>
    {
        Guid Id { get; set; }
    }
}
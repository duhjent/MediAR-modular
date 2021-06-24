using System;

namespace MediAR.Core.Application.Contracts
{
    public class BaseCommand : ICommand
    {
        public Guid Id { get; set; }

        protected BaseCommand()
        {
            Id = Guid.NewGuid();
        }

        private BaseCommand(Guid id)
        {
            Id = id;
        }
    }
    
    public class BaseCommand<T> : ICommand<T>
    {
        public Guid Id { get; set; }

        protected BaseCommand()
        {
            Id = Guid.NewGuid();
        }

        private BaseCommand(Guid id)
        {
            Id = id;
        }
    }
}
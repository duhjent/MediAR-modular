using System;

namespace MediAR.Core.Contracts.Exceptions
{
    public class ApplicationException : Exception
    {
        public ApplicationException(string message) : base(message) { }
    }
}
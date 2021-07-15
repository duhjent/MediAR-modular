using System;

namespace MediAR.Core.Contracts.Exceptions
{
    public class CustomException : Exception
    {
        public string Message { get; }
        
        public CustomException(string message) : base(message)
        {
            Message = message;
        }
    }
}
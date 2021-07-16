using MediAR.Core.Contracts.Exceptions;

namespace MediAR.Modules.Membership.Core.Exceptions
{
    public class UserExistsException : CustomException
    {
        public UserExistsException(string message) : base(message)
        {
        }
    }
}
using System.Collections.Generic;

namespace MediAR.Modules.Membership.Core.Dtos
{
    public class AuthenticationResult
    {
        public bool IsSuccessful { get; }
        public string AuthToken { get;  }
        public IEnumerable<string> Errors { get;  }

        public AuthenticationResult(string token)
        {
            IsSuccessful = true;
            AuthToken = token;
        }

        public AuthenticationResult(IEnumerable<string> errors)
        {
            IsSuccessful = false;
            Errors = errors;
        }
    }
}
using System.Collections.Generic;
using System.Diagnostics;

namespace MediAR.Modules.Membership.Core.Dtos
{
    public class RegistrationResult
    {
        public bool IsSuccessful { get; set; }
        public string Token { get; set; }
        public IEnumerable<string> Errors { get; set; }
        
        private RegistrationResult() {}

        public RegistrationResult(string token)
        {
            IsSuccessful = true;
            Token = token;
        }

        public RegistrationResult(IEnumerable<string> errors)
        {
            IsSuccessful = false;
            Errors = errors;
        }
    }
}
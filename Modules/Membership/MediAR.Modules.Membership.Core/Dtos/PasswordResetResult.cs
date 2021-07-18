using System.Collections.Generic;

namespace MediAR.Modules.Membership.Core.Dtos
{
    public class PasswordResetResult
    {
        public bool IsSuccessful { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public PasswordResetResult()
        {
            IsSuccessful = true;
        }

        public PasswordResetResult(IEnumerable<string> errors)
        {
            IsSuccessful = false;
            Errors = errors;
        }
    }
}
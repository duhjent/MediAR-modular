using System;

namespace MediAR.Core.Domain
{
    class BusinessRuleValidationException : Exception
    {
        public IBusinessRule BrokenRule { get; set; }

        public string Details { get; set; }

        public BusinessRuleValidationException(IBusinessRule brokenRule) : base(brokenRule.Message)
        {
            BrokenRule = brokenRule;
            Details = brokenRule.Message;
        }

        public override string ToString()
        {
            return $"{BrokenRule.GetType().FullName}: {BrokenRule.Message}";
        }
    }
}

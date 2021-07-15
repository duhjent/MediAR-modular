namespace MediAR.Core.Contracts.Dtos
{
    public class BaseErrorDetailsResponse : BaseErrorResponse
    {
        public string CallStack { get; set; }
        public string ExceptionType { get; set; }

        public BaseErrorDetailsResponse(string message, string callStack, string type) : base(message)
        {
            CallStack = callStack;
            ExceptionType = type;
        }
    }
}
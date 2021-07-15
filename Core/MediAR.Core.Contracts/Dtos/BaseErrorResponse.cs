namespace MediAR.Core.Contracts.Dtos
{
    public class BaseErrorResponse
    {
        public string ErrorMessage { get; set; }

        public BaseErrorResponse(string message)
        {
            ErrorMessage = message;
        }
    }
}
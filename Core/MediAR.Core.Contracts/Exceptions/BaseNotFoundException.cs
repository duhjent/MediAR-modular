namespace MediAR.Core.Contracts.Exceptions
{
    public class BaseNotFoundException<T>: CustomException
    {
        public BaseNotFoundException() : base($"{typeof(T)} is not found")
        {
        }
    }
}
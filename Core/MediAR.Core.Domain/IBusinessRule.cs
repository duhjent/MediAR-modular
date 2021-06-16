namespace MediAR.Core.Domain
{
    public interface IBusinessRule
    {
        public string Message { get; }

        bool IsBroken();
    }
}

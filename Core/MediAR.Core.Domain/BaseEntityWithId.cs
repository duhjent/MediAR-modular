namespace MediAR.Core.Domain
{
    public class BaseEntityWithId<T> : BaseEntity
    {
        public T Id { get; set; }
    }
}
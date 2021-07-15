namespace MediAR.Core.Contracts.Entities
{
    // Marker
    public class BaseEntity { }

    public class BaseEntity<TId> : BaseEntity
    {
        public TId Id { get; set; }
    }
}
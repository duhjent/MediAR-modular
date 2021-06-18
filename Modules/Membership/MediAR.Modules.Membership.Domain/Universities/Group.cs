using MediAR.Core.Domain;

namespace MediAR.Modules.Membership.Domain.Universities
{
    public class Group : BaseEntityWithId<int>
    {
        public Year Year { get; set; }
        public int YearId { get; set; }

        public string Name { get; set; }
        
    }
}
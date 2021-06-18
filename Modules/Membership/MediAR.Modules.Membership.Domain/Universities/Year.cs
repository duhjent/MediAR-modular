using System.Collections.Generic;
using MediAR.Core.Domain;

namespace MediAR.Modules.Membership.Domain.Universities
{
    public class Year : BaseEntityWithId<int>
    {
        public University University { get; set; }
        public int UniversityId { get; set; }

        public string Name { get; set; }
        
        public ICollection<Group> Groups { get; set; }
    }
}
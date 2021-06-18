using System.Collections.Generic;
using MediAR.Core.Domain;

namespace MediAR.Modules.Membership.Domain.Universities
{
    public class University : BaseEntityWithId<int>
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string EmailDomain { get; set; }

        public ICollection<Year> Years { get; set; }
    }
}
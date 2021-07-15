using System;

namespace MediAR.Modules.Membership.Core.Entities
{
    public class UserProfile
    {
        public Guid ApplicationUserId { get; set; }
        
        public ApplicationUser ApplicationUser { get; set; }

        public string TenantId { get; set; }

        // comment out for now, need to think about module segregation
        // public IList<UserCourse> Courses { get; set; }
        // public int GroupId { get; set; }
        // public Group Group { get; set; }
        // comment out for now, need to think about module segregation
        // public IList<Reminder> Reminders { get; set; }
        
        public string Country { get; set; }
        
        public string City { get; set; }
        
        public string ProfilePhotoUrl { get; set; }

        public string UDF1 { get; set; }

        public string UDF2 { get; set; }

        public string UDF3 { get; set; }

        public string UDF4 { get; set; }

        public string UDF5 { get; set; }
    }
}
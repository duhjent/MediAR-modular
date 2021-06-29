using MediAR.Modules.Membership.Domain.Universities;
using MediAR.Modules.Membership.Domain.Users;

namespace MediAR.Modules.Membership.Domain.Users
{
    public class UserProfile
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        // comment out for now, need to think about module segregation
        // public IList<UserCourse> Courses { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        // comment out for now, need to think about module segregation
        // public IList<Reminder> Reminders { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ProfilePhotoUrl { get; set; }
    }
}
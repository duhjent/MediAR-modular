using System.Threading.Tasks;

namespace MediAR.Modules.Membership.Domain.Users
{
    public interface IUserRepository
    {
        Task<ApplicationUser> AddUser(ApplicationUser user);
    }
}
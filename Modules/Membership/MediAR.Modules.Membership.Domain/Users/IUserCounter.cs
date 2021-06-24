namespace MediAR.Modules.Membership.Domain.Users
{
    public interface IUserCounter
    {
        int CountUsersWithUserName(string userName);
    }
}
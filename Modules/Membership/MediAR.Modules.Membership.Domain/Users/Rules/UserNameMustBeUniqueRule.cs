using MediAR.Core.Domain;

namespace MediAR.Modules.Membership.Domain.Users.Rules
{
    public class UserNameMustBeUniqueRule : IBusinessRule
    {
        private readonly string _userName;
        private readonly IUserCounter _counter;

        public UserNameMustBeUniqueRule(IUserCounter counter, string userName)
        {
            _counter = counter;
            _userName = userName;
        }
        public string Message => "Username has to be unique";
        public bool IsBroken()
        {
            var usersWithLogin = await _counter.CountUsersWithUserName(_userName);
            return usersWithLogin > 0;
        }
    }
}
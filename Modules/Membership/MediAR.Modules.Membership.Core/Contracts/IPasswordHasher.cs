namespace MediAR.Modules.Membership.Core.Contracts
{
    public interface IPasswordHasher
    {
        string Encode(string password);
        bool VerifyEncoded(string hashedPassword, string password);
    }
}
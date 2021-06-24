namespace MediAR.Modules.Membership.Domain.Authentication
{
    public interface IPasswordHasher
    {
        string Encode(string password);
        bool VerifyEncoded(string hashedPassword, string password);
    }
}
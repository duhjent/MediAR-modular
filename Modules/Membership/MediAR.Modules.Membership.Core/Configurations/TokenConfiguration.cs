namespace MediAR.Modules.Membership.Core.Configurations
{
    public class TokenConfiguration
    {
        public int ClaimsTokenExpMinutes { get; set; }
        public int MembershipTokenExpDays { get; set; }
        public string JwtSecret { get; set; }
        public string JwtIssuer { get; set; }
        public string JwtAudience { get; set; }
    }
}
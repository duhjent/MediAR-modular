using System;
using System.Text;
using System.Threading.Tasks;
using MediAR.Modules.Membership.Core.Contracts;
using MediAR.Modules.Membership.Core.Entities;

namespace MediAR.Modules.Membership.Core.Services
{
    internal class TokenProvider : ITokenProvider
    {
        public string GenerateToken(string purpose, ApplicationUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }

            var token = Guid.NewGuid().ToString();
            token += purpose;

            return Base64Encode(token);
        }

        private string Base64Encode(string input)
        {
            var plainBytes = Encoding.UTF8.GetBytes(input);
            var result = Convert.ToBase64String(plainBytes);

            return result;
        }

    }
}
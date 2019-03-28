using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Authentication;

namespace kin_leaderboard_api.Authentication
{
    public class CustomAuthOptions : AuthenticationSchemeOptions
    {
        public string ApiKey { get; internal set; }
        public ClaimsIdentity Identity { get; set; }

        public CustomAuthOptions()
        {
            Identity = new GenericIdentity("Admin");
        }
    }
}
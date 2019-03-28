using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using kin_leaderboard_api.Exceptions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace kin_leaderboard_api.Authentication
{
    internal class CustomAuthHandler : AuthenticationHandler<CustomAuthOptions>
    {
        public CustomAuthHandler(IOptionsMonitor<CustomAuthOptions> options, ILoggerFactory logger, UrlEncoder encoder,
            ISystemClock clock) : base(options, logger, encoder, clock)
        {
            // store custom services here...
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string requestApiKeyValue = Context.Request.Headers["Authorization"].FirstOrDefault();

            if (requestApiKeyValue != null && requestApiKeyValue.Equals($"Bearer {Options.ApiKey}"))
            {
                return Task.FromResult(
                    AuthenticateResult.Success(
                        new AuthenticationTicket(
                            new ClaimsPrincipal(Options.Identity),
                            new AuthenticationProperties(),
                            Scheme.Name)));
            }

            return Task.FromResult(AuthenticateResult.NoResult());

            throw new UnauthorizedApiException("Authorization header missing or incorrect");

            //return Task.FromResult(AuthenticateResult.Fail("sd"));
        }
    }
}
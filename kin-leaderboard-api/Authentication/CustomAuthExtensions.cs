using System;
using Microsoft.AspNetCore.Authentication;

namespace kin_leaderboard_api.Authentication
{
    public static class CustomAuthExtensions
    {
        public static AuthenticationBuilder AddCustomAuth(this AuthenticationBuilder builder,
            Action<CustomAuthOptions> configureOptions)
        {
            return builder.AddScheme<CustomAuthOptions, CustomAuthHandler>("CustomScheme", "CustomAuth",
                configureOptions);
        }
    }
}
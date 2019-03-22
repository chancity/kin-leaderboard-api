using System;

namespace kin_leaderboard_api.Exceptions
{
    public class BaseApiException : Exception
    {
        public BaseApiException(string message) : base(message)
        {}
        public BaseApiException() 
        { }
    }
}
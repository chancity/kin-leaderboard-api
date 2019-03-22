namespace kin_leaderboard_api.Exceptions {
    public class RateLimitApiException : BaseApiException
    {
        public RateLimitApiException(string message) : base(message) { }
        public RateLimitApiException() { }
    }
}
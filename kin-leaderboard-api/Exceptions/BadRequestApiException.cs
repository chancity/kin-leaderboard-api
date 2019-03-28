namespace kin_leaderboard_api.Exceptions
{
    public class BadRequestApiException : BaseApiException
    {
        public BadRequestApiException(string message) : base(message) { }
        public BadRequestApiException() { }
    }
}
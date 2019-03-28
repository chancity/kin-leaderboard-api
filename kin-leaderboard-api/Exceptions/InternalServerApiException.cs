namespace kin_leaderboard_api.Exceptions
{
    public class InternalServerApiException : BaseApiException
    {
        public InternalServerApiException(string message) : base(message) { }
        public InternalServerApiException() { }
    }
}
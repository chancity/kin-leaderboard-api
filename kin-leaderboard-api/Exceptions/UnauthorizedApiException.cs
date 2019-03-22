namespace kin_leaderboard_api.Exceptions {
    public class UnauthorizedApiException : BaseApiException
    {
        public UnauthorizedApiException(string message) : base(message) { }
        public UnauthorizedApiException() { }
    }
}
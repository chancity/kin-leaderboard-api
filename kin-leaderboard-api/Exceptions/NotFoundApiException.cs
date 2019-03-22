namespace kin_leaderboard_api.Exceptions {
    public class NotFoundApiException : BaseApiException
    {
        public NotFoundApiException(string message) : base(message) { }
        public NotFoundApiException() { }
    }
}
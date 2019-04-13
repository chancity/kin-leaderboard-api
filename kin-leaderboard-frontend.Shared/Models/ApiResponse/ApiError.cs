namespace kin_leaderboard_frontend.Shared.Models.ApiResponse
{
    public class ApiError
    {
        public string Message { get; set; }

        public string Stacktrace { get; set; }

        public ApiError() { }

        public ApiError(string message, string stacktrace)
        {
            Message = message;
            Stacktrace = stacktrace;
        }
    }
}
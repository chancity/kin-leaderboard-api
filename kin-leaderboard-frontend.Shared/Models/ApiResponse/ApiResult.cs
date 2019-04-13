namespace kin_leaderboard_frontend.Shared.Models.ApiResponse
{
    public class ApiResult
    {
        public bool Success { get; set; }

        public ApiResult(bool success)
        {
            Success = success;
        }

        public ApiResult() { }
    }
}
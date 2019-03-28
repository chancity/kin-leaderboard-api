namespace kin_leaderboard_api.Models.ApiResponse
{
    public class ApiResult
    {
        public bool Success { get; }

        public ApiResult(bool success)
        {
            Success = success;
        }
    }
}
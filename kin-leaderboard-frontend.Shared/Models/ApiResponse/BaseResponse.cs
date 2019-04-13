namespace kin_leaderboard_frontend.Shared.Models.ApiResponse
{
    public class BaseResponse
    {
        public ApiError ApiError { get; set; }


        public BaseResponse() { }

        public BaseResponse(ApiError apiError)
        {
            ApiError = apiError;
        }
    }
}
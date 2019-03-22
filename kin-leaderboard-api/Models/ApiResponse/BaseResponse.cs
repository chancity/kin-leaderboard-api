namespace kin_leaderboard_api.Models.ApiResponse
{
    public class BaseResponse
    {
        public ApiError ApiError { get; }


        protected BaseResponse() { }

        public BaseResponse(ApiError apiError)
        {
            ApiError = apiError;
        }
    }
}
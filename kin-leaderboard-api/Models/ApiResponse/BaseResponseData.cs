namespace kin_leaderboard_api.Models.ApiResponse
{
    public class BaseResponseData<T> : BaseResponse where T : class
    {
        public T Data { get; }

        public BaseResponseData(T data)
        {
            Data = data;
        }
    }
}
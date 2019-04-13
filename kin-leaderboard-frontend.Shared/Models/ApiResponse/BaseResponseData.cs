namespace kin_leaderboard_frontend.Shared.Models.ApiResponse
{
    public class BaseResponseData<T> : BaseResponse where T : class
    {
        public T Data { get; set; }

        public BaseResponseData(T data)
        {
            Data = data;
        }

        public BaseResponseData()
        {
        }
    }
}
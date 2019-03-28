using Newtonsoft.Json;

namespace kin_leaderboard_api.Models.ApiResponse
{
    public class PaginatedResponse<T> where T : class
    {
        public T[] Items { get; set; }

        [JsonProperty]
        public bool HasPreviousPage => PageIndex > 1;

        [JsonProperty]
        public bool HasNextPage => PageIndex < TotalPages;

        [JsonProperty]
        public int PageIndex { get; set; }

        [JsonProperty]
        public int TotalPages { get; set; }

        [JsonProperty]
        public int TotalCount { get; set; }

        public PaginatedResponse(PaginatedList<T> paginatedList)
        {
            Items = paginatedList.ToArray();
            PageIndex = paginatedList.PageIndex;
            TotalPages = paginatedList.TotalPages;
            TotalCount = paginatedList.TotalCount;
        }
    }
}
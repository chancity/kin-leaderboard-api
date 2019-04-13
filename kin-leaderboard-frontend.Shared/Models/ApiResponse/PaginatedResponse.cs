namespace kin_leaderboard_frontend.Shared.Models.ApiResponse
{
    public class PaginatedResponse<T> where T : class
    {
        public T[] Items { get; set; }

 
        public bool HasPreviousPage => PageIndex > 1;

 
        public bool HasNextPage => PageIndex < TotalPages;

 
        public int PageIndex { get; set; }

 
        public int TotalPages { get; set; }

        public int TotalCount { get; set; }

        public PaginatedResponse(PaginatedList<T> paginatedList)
        {
            Items = paginatedList.ToArray();
            PageIndex = paginatedList.PageIndex;
            TotalPages = paginatedList.TotalPages;
            TotalCount = paginatedList.TotalCount;
        }

        public PaginatedResponse() { }
    }
}
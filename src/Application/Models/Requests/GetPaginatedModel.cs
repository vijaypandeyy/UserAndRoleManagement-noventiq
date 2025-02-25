namespace Application.Models.Requests
{
    public class GetPaginatedModel
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }

        public string SortField { get; set; }
        public string SortOrder { get; set; }

        public string SearchTerm { get; set; }
    }
}

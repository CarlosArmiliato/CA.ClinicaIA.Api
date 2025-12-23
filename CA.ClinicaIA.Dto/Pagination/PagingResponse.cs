using System.Collections.Generic;

namespace CA.ClinicaIA.Dto.Pagination
{
    public class PagingResponse<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public IEnumerable<T> Data { get; set; } = new List<T>();
    }
}

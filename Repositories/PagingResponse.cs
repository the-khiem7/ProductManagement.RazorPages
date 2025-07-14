using System.Collections.Generic;

namespace ProductManagement.RazorPages.Repositories
{
    public class PagingResponse<T>
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
} 
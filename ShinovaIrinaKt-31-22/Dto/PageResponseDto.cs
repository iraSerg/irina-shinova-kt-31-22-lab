using System.ComponentModel.DataAnnotations;

namespace ShinovaIrinaKt_31_22.Dto
{
    public class PageResponseDto<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }


    }
}

using System.Collections;

namespace Owl.Overdrive.Business.Services.Models
{
    public class DataResult<T>
    {
        public IEnumerable<T>? Data { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; } = 0;
    }
}

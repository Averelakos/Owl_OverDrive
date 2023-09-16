using Owl.Overdrive.Business.Services.Models;
using Owl.Overdrive.Infrastructure.Services.Models;

namespace Owl.Overdrive.Business.DTOs.ServiceResults
{
    public class ServiceSearchResultData<T>: ServiceResultBase
    {
        public T? Result { get; set; }
        public int TotalCount { get; set; } = 0;
        public int TotalPages { get; set; } = 0;
    }
}

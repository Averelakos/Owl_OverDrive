using Owl.Overdrive.Infrastructure.Services.Models;

namespace Owl.Overdrive.Business.DTOs.ServiceResults
{
    public class ServiceResult<T> :ServiceResultBase
    {
        public T? Result { get; set; }
    }
}

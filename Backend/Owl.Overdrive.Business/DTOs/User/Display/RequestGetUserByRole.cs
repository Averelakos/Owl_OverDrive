using Owl.Overdrive.Business.Services.Models;
using Owl.Overdrive.Domain.Enums;

namespace Owl.Overdrive.Business.DTOs.User.Display
{
    public class RequestGetUserByRole
    { 
        public ERole? Role { get; set; }
        public DataLoaderOptions Options { get; set; } = null!;
        
    }
}

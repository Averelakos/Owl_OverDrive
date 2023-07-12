namespace Owl.Overdrive.Infrastructure.Services.Models
{
    public class ServiceResultBase
    {
        public bool Success { get; set; } = true;
        public string? Error { get; set; }
    }
}

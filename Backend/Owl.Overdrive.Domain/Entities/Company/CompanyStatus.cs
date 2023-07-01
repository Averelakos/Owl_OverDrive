using Owl.Overdrive.Domain.Entities.Base;

namespace Owl.Overdrive.Domain.Entities.Company
{
    public class CompanyStatus : BaseEntity
    {
        /// <summary>
        /// Company status name
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// Company description
        /// </summary>
        public string? Description { get; set; } = null!;
    }
}

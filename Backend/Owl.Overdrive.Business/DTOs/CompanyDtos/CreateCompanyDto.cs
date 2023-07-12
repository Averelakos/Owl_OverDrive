using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owl.Overdrive.Business.DTOs.CompanyDtos
{
    /// <summary>
    /// Create company Dto
    /// </summary>
    public class CreateCompanyDto
    {
        public long? Id { get; set; }
        /// <summary>
        /// Company name
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// Company description
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Parent company identifier
        /// </summary>
        public long? ParentCompanyId { get; set; }
        /// <summary>
        /// When the company founded
        /// </summary>
        public DateTime? FoundedIn { get; set; }
        /// <summary>
        /// In which country founded
        /// </summary>
        public long? CountryId { get; set; }
        /// <summary>
        /// Current company status
        /// </summary>
        public long? StatusId { get; set; }
        /// <summary>
        /// Status change
        /// </summary>
        public DateTime? ChangedDate { get; set; }
        /// <summary>
        /// Company official website
        /// </summary>
        public string? OfficialWebsite { get; set; }
        /// <summary>
        /// Company official twitter page
        /// </summary>
        public string? Twitter { get; set; }

        public Guid imageGuid { get; set; }
    }
}

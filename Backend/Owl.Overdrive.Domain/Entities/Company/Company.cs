using Owl.Overdrive.Domain.Entities.Base;

namespace Owl.Overdrive.Domain.Entities.Company
{
    public class Company : BaseEntity
    {
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
        public DateTime FoundedIn { get; set; }
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
        public long? CompanyLogoId { get; set; }


        // Refernce table
        public virtual CountryCode? Country { get; set; }
        public virtual Company? ParentCompany { get; set; }
        public virtual CompanyStatus? Status { get; set; }
        public virtual CompanyLogo? CompanyLogo { get; set; }
    }
}

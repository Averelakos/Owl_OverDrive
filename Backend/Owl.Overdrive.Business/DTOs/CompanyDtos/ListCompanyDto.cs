using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owl.Overdrive.Business.DTOs.CompanyDtos
{
    /// <summary>
    /// List company Dto
    /// </summary>
    public class ListCompanyDto
    {
        public long Id { get; set; }
        /// <summary>
        /// Company name
        /// </summary>
        public string Name { get; set; } = null!;
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
    }
}

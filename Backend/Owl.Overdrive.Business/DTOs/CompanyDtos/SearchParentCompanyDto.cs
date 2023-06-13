using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owl.Overdrive.Business.DTOs.CompanyDtos
{
    /// <summary>
    /// Search parent company Dto
    /// </summary>
    public class SearchParentCompanyDto
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>

        public long Id { get; set; }
        /// <summary>
        /// Company name
        /// </summary>
        public string Name { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owl.Overdrive.Business.DTOs.LookupsDtos
{
    /// <summary>
    /// Lookup dto
    /// </summary>
    public class LookupsDto
    {
        /// <summary>
        /// Gets or sets the company status lookup.
        /// </summary>
        /// <value>
        /// The company status lookup.
        /// </value>
        public List<CompanyStatusLookupDto> CompanyStatus { get; set; } = null!;
        /// <summary>
        /// Gets or sets the country code lookup.
        /// </summary>
        /// <value>
        /// The country code lookup.
        /// </value>
        public List<CountryCodeLookupDto> CountryCode { get; set; } = null!;
        /// <summary>
        /// Gets or sets the regions.
        /// </summary>
        /// <value>
        /// The regions.
        /// </value>
        public List<RegionLookupDto> Regions { get; set; } = null!;
        /// <summary>
        /// Gets or sets the languages.
        /// </summary>
        /// <value>
        /// The languages.
        /// </value>
        public List<LanguageLookupDto> Languages { get; set; } = null!;

    }
}

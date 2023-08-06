using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owl.Overdrive.Business.DTOs.LookupsDtos
{
    /// <summary>
    /// Region lookup dto
    /// </summary>
    /// <seealso cref="Owl.Overdrive.Business.DTOs.LookupsDtos.BaseLookupDto" />
    public class RegionLookupDto: BaseLookupDto
    {
        /// <summary>
        /// Region code
        /// </summary>
        public string? RegionCode { get; set; } = null!;
    }
}

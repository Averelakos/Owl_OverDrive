using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Owl.Overdrive.Business.DTOs.CompanyDtos
{
    /// <summary>
    /// Simple company Dto
    /// </summary>
    public class UpdateCompanyLogoDto
    {
        /// <summary>
        /// Image File name.
        /// </summary>
        public string ImageTitle { get; set; } = null!;
        /// <summary>
        /// Image data.
        /// </summary>
        public byte[] ImageData { get; set; } = null!;

    }
}

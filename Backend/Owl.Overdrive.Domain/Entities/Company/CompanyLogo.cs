using Owl.Overdrive.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owl.Overdrive.Domain.Entities.Company
{
    public class CompanyLogo: BaseEntity
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

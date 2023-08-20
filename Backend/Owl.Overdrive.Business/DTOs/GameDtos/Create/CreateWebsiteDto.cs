using Owl.Overdrive.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owl.Overdrive.Business.DTOs.GameDtos.Create
{
    public class CreateWebsiteDto
    {
        public string Url { get; set; } = null!;
        public EWebsiteCategory Category { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owl.Overdrive.Business.DTOs.GameDtos.Create
{
    public class CreateGameLocalizationDto
    {
        public long RegionId { get; set; }
        public string LocalizedTitle { get; set; } = null!;
    }
}

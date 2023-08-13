using Owl.Overdrive.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owl.Overdrive.Domain.Entities
{
    public class Language : BaseEntity
    {
        public string Name { get; set; } = null!;
    }
}

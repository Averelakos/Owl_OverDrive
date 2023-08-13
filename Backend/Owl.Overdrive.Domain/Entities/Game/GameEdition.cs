using Owl.Overdrive.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owl.Overdrive.Domain.Entities.Game
{
    public class GameEdition : BaseEntity
    {
        public long EditionGameId { get; set; }
        public long ParentGameId{ get; set; }

        public virtual Game EditionGame { get; set; } = null!;
        public virtual Game ParentGame { get; set; } = null!;
    }
}

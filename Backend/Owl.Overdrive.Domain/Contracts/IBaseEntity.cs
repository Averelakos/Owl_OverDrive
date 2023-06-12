using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owl.Overdrive.Domain.Contracts
{
    public interface IBaseEntity
    {
        /// <summary>
        /// Entry Identifier
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Entry Created date
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Lastupdated date entry
        /// </summary>
        public DateTime LastUpdated { get; set; }
        /// <summary>
        /// User identifier who created the entry
        /// </summary>
        public long CreatedById { get; set; }
        /// <summary>
        /// User identifier who last updated the entry
        /// </summary>
        public long LastUpdatedById { get; set; }
    }
}

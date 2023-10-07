using Owl.Overdrive.Domain.Entities.Base;

namespace Owl.Overdrive.Domain.Entities.Auth
{
    public class RolePermission : BaseEntity
    {
        public long RoleId { get; set; }
        public virtual Role Role { get; set; } = null!;
        public string Permission { get; set; } = null!;
    }
}

using Owl.Overdrive.Domain.Entities.Base;

namespace Owl.Overdrive.Domain.Entities.Auth
{
    public class Role: BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public virtual List<RolePermission> RolePermissions { get; set; } = new();
    }
}

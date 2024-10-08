﻿using Owl.Overdrive.Domain.Entities.Base;

namespace Owl.Overdrive.Domain.Entities.Auth
{
    public class UserRole: BaseEntity
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;
    }
}

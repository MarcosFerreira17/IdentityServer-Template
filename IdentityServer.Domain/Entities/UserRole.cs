using IdentityServer.Domain.Common;

namespace IdentityServer.Domain.Entities;

public class UserRole : EntityBase<long>
{
    public int UserId { get; private set; }
    public int RoleId { get; private set; }
    public User User { get; private set; }
    public Role Role { get; private set; }
}

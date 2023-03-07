using IdentityServer.Domain.Common;

namespace IdentityServer.Domain.Entities;

public class UserRole : EntityBase<long>
{
    public UserRole(long userId, long roleId)
    {
        UserId = userId;
        RoleId = roleId;
    }
    public long UserId { get; private set; }
    public long RoleId { get; private set; }
    public User User { get; private set; }
    public Role Role { get; private set; }
}

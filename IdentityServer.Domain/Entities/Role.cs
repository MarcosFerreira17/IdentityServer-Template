using IdentityServer.Domain.Common;

namespace IdentityServer.Domain.Entities;

public class Role : EntityBase<long>
{
    public Role(string name, string description)
    {
        Name = name;
        Description = description;
    }
    public string Name { get; set; }
    public string Description { get; set; }
    public IEnumerable<UserRole> UserRoles { get; set; }
}
